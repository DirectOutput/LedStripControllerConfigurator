using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTD2XX;
using System.Threading;

namespace LedStripController_Configurator
{
    public class BootLoader
    {
        FTDI FTDIAPI = new FTDI();

        public bool IsOpen { get; private set; }

        public bool BootLoaderStarted { get; private set; }

        public void Open(FTDI.FT_DEVICE_INFO_NODE Controller)
        {
            IsOpen = false;


            FTDI.FT_STATUS FTStatus;
            if (Controller != null)
            {

                if (Controller.Type == FTDI.FT_DEVICE.FT_DEVICE_232R)
                {
                    int dummy;
                    if (Controller.Description.StartsWith(Properties.Settings.Default.LedStripControllerDeviceDescriptionBase) && int.TryParse(Controller.Description.Substring(Properties.Settings.Default.LedStripControllerDeviceDescriptionBase.Length), out dummy))
                    {
                        FTStatus = FTDIAPI.OpenByLocation(Controller.LocId);
                        if (FTStatus == FTDI.FT_STATUS.FT_OK)
                        {
                            FTStatus = FTDIAPI.Purge(FTDI.FT_PURGE.FT_PURGE_RX + FTDI.FT_PURGE.FT_PURGE_TX);
                            if (FTStatus == FTDI.FT_STATUS.FT_OK)
                            {
                                IsOpen = true;

                            }
                            else
                            {
                                throw new Exception("Could not purge buffers.");
                            }
                        }
                        else
                        {
                            throw new Exception("Could not open connection to controller.");
                        }
                    }
                    else
                    {
                        throw new Exception("Controller has a invalid description.");
                    }
                }
                else
                {
                    throw new ArgumentException("Wrong controller type.");
                }
            }
            else
            {
                throw new ArgumentException("Controller is null.");
            }
        }

        public void Close()
        {
            try
            {
                FTDIAPI.Close();
                IsOpen = false;
                BootLoaderStarted = false;
            }
            catch { };
        }

        public void Send(string Data)
        {
            Send(System.Text.Encoding.ASCII.GetBytes(Data));
        }
        public void Send(byte Data)
        {
            Send(new byte[1] { Data });
        }
        public void Send(byte[] Data)
        {
            uint BytesWritten = 0;
            FTDI.FT_STATUS FTStatus = FTDIAPI.Write(Data, Data.Length, ref BytesWritten);
            if (FTStatus == FTDI.FT_STATUS.FT_OK)
            {
                if (BytesWritten != Data.Length)
                {
                    throw new Exception("Wrong number of bytes sent.");
                }
            }
            else
            {
                throw new Exception("Could not send data to controller.");
            }
        }

        public uint BytesWaiting()
        {
            uint BytesToRead = 0;
            FTDI.FT_STATUS FTStatus = FTDIAPI.GetRxBytesAvailable(ref BytesToRead);
            if (FTStatus != FTDI.FT_STATUS.FT_OK)
            {
                throw new Exception("Could not get number of bytes to read");
            }
            return BytesToRead;
        }

        public byte[] ReadAll()
        {
            uint ReadBytes = BytesWaiting();

            byte[] ReceiveBuffer = new byte[ReadBytes];
            if (ReadBytes > 0)
            {

                uint BytesRead = 0;
                FTDI.FT_STATUS FTStatus = FTDIAPI.Read(ReceiveBuffer, ReadBytes, ref BytesRead);
                if (FTStatus == FTDI.FT_STATUS.FT_OK)
                {
                    if (BytesRead != ReadBytes)
                    {
                        throw new Exception("Wrong number of bytes read.");
                    }
                }
                else
                {
                    throw new Exception("Could not read from controller.");
                }
            }
            return ReceiveBuffer;
        }


        public bool CheckBootLoader()
        {
            try
            {
                StartBootLoader();
                return true;
            }
            catch
            {

                return false;
            }
        }

        public void StartBootLoader()
        {
            byte[] ReceiveBuffer;
            DateTime Start;
            bool TryAgain = false;
            int TriedTimes = 0;
            if (!IsOpen)
            {
                throw new Exception("Connection to controller is not open.");
            }
            ReadAll();
            do
            {
                TryAgain = false;
                Send((byte)'Z');

                Start = DateTime.Now;
                while (BytesWaiting() == 0 && (DateTime.Now - Start).TotalMilliseconds < 30)
                {
                    Thread.Sleep(1);
                }
                if (BytesWaiting() == 0)
                {
                    for (int i = 0; i < 200; i++)
                    {
                        Send(new byte[50]);
                        Thread.Sleep(10);
                        ReceiveBuffer = ReadAll();
                        if (ReceiveBuffer.Length > 0 && ReceiveBuffer[ReceiveBuffer.Length - 1] == 'N') break;
                    }
                    Send((byte)'Z');
                    Start = DateTime.Now;
                    while (BytesWaiting() == 0 && (DateTime.Now - Start).TotalMilliseconds < 30)
                    {
                        Thread.Sleep(1);
                    }
                }
                if (BytesWaiting() != 1)
                {
                    throw new Exception("Wrong number of bytes waiting after bootloader start char (Z)");
                }
                ReceiveBuffer = ReadAll();
                if (ReceiveBuffer.Length != 1)
                {
                    throw new Exception("Wrong number of bytes received after bootloader start char (Z)");
                }

                switch (ReceiveBuffer[0])
                {
                    case (byte)'P':
                        //Bootloader expects password
                        break;
                    case (byte)'A':
                        //Need to try again
                        TryAgain = true;
                        Thread.Sleep(3000);
                        break;

                    default:
                        //Need to try again
                        TryAgain = true;
                        break;
                }
                TriedTimes++;
            } while (TriedTimes < 3 && TryAgain == true);

            if (ReceiveBuffer[0] != 'P')
            {
                throw new Exception("Bootloader password request char (P) not received.");
            }

            Send(Properties.Settings.Default.BootLoaderPassword);

            Start = DateTime.Now;
            while (BytesWaiting() == 0 && (DateTime.Now - Start).TotalMilliseconds < 30)
            {
                Thread.Sleep(1);
            }

            ReceiveBuffer = ReadAll();
            if (ReceiveBuffer.Length == 0)
            {
                throw new Exception("No answer received after password");
            }
            else if (ReceiveBuffer.Length > 1)
            {
                //PW was likely wrong
                throw new Exception("Password has not been accepted by the controller");
            }
            else if (ReceiveBuffer[0] != 'A')
            {
                //No connect received. PW likely wrong.
                throw new Exception("No ack received after password. Password was likely wrong.");
            }
            BootLoaderStarted = true;

        }


        public double GetBootloaderVersion()
        {

            if (!BootLoaderStarted)
            {
                throw new Exception("Bootloader has not been started.");
            }
            ReadAll();
            Send(new byte[] { (byte)'C', 1 });

            DateTime Start = DateTime.Now;
            do
            {
                Thread.Sleep(10);
            } while (BytesWaiting() < 4 && (DateTime.Now - Start).TotalMilliseconds < 30);
            byte[] ReceiveBuffer = ReadAll();

            if (ReceiveBuffer.Length == 5 && ReceiveBuffer[0] == '>' && ReceiveBuffer[1] == 3 && ReceiveBuffer[3] < 100 && ReceiveBuffer[4] == 'A')
            {

                return (double)ReceiveBuffer[2] + ((double)ReceiveBuffer[3] / 100);

            }
            else
            {
                throw new Exception("Could not read bootloader version");
            }
        }


        public int GetBufferSize()
        {

            if (!BootLoaderStarted)
            {
                throw new Exception("Bootloader has not been started.");
            }
            ReadAll();

            Send(new byte[] { (byte)'C', 2 });
            DateTime Start = DateTime.Now;
            do
            {
                Thread.Sleep(10);
            } while (BytesWaiting() < 4 && (DateTime.Now - Start).TotalMilliseconds < 30);
            byte[] ReceiveBuffer = ReadAll();

            if (ReceiveBuffer.Length == 5 && ReceiveBuffer[0] == '>' && ReceiveBuffer[1] == 3 && ReceiveBuffer[4] == 'A')
            {

                return ReceiveBuffer[2] * 256 + ReceiveBuffer[3];

            }
            else
            {
                throw new Exception("Could not read buffer size version");
            }
        }

        public string GetControllerCPU()
        {
            if (!BootLoaderStarted)
            {
                throw new Exception("Bootloader has not been started.");
            }
            ReadAll();

            Send(new byte[] { (byte)'C', 3 });
            DateTime Start = DateTime.Now;
            do
            {
                Thread.Sleep(10);
            } while (BytesWaiting() < 5 && (DateTime.Now - Start).TotalMilliseconds < 30);
            byte[] ReceiveBuffer = ReadAll();

            if (ReceiveBuffer.Length == 6 && ReceiveBuffer[0] == '>' && ReceiveBuffer[1] == 4 && ReceiveBuffer[5] == 'A')
            {
                int Signature = ReceiveBuffer[2] * 65536 + ReceiveBuffer[3] * 256 + ReceiveBuffer[4];
                if (Enum.IsDefined(typeof(AVRTypeEnum), Signature))
                {
                    return Enum.GetName(typeof(AVRTypeEnum), Signature);
                }
                else
                {
                    return "Unknown" + ReceiveBuffer[2].ToString("X") + " " + ReceiveBuffer[3].ToString("X") + ReceiveBuffer[4].ToString("X");
                }


            }
            else
            {
                throw new Exception("Could not read signature bytes/controller type");
            }


        }



        public int GetUserFlashSize()
        {

            if (!BootLoaderStarted)
            {
                throw new Exception("Bootloader has not been started.");
            }
            ReadAll();

            Send(new byte[] { (byte)'C', 4 });
            DateTime Start = DateTime.Now;
            do
            {
                Thread.Sleep(10);
            } while (BytesWaiting() < 4 && (DateTime.Now - Start).TotalMilliseconds < 30);
            byte[] ReceiveBuffer = ReadAll();


            if (ReceiveBuffer.Length == 6 && ReceiveBuffer[0] == '>' && ReceiveBuffer[1] == 4 && ReceiveBuffer[5] == 'A')
            {

                return ReceiveBuffer[2] * 65536 + ReceiveBuffer[3] * 256 + ReceiveBuffer[4];

            }
            else
            {
                throw new Exception("Could not read user flash size");
            }
        }



        public void InstallFirmware(string FirmwareFilename)
        {
            if (!BootLoaderStarted)
            {
                throw new Exception("Bootloader has not been started.");
            }
            ReadAll();


            OnInstallProgress(1, "Loading hex file: " + FirmwareFilename);
            HexFile H = new HexFile();

            try
            {
                H.LoadFile(FirmwareFilename);

            }
            catch (Exception E)
            {
                throw new Exception("Could not load firmware file " + FirmwareFilename, E);
            }
            OnInstallProgress(6, "Extracting binary data");

            byte[] Data;
            try
            {
                Data = H.GetBinaryData();

            }
            catch (Exception E)
            {
                throw new Exception("Could not extract binary data from file " + FirmwareFilename, E);
            }
            OnInstallProgress(10, "Data loaded. " + Data.Length + " / 0x" + Data.Length.ToString("X") + " bytes");


            try
            {
                StartBootLoader();
            }
            catch (Exception E)
            {
                throw new Exception("Could not start bootloader", E);
            }

            if (!BootLoaderStarted)
            {
                throw new Exception("Bootloader could not start");
            }
            OnInstallProgress(12, "Bootloader activated");

            int BufferSize = GetBufferSize();
            OnInstallProgress(13, "Buffersize read: " + BufferSize + " / 0x" + BufferSize.ToString("X"));


            int FlashSize = GetUserFlashSize();
            OnInstallProgress(14, "Flash size read: " + FlashSize + " / 0x"+FlashSize.ToString("X"));


            if (FlashSize < Data.Length)
            {
                throw new Exception("Firmware size is to big for controller flash memory.");
            }

            ReadAll();

            OnInstallProgress(15,  "Initializing firmware upload");

            Send(new byte[] { (byte)'C', 5 });  //Send program command

            int BlockCnt = 0;
            int Pos = 0;
            do
            {
                List<byte> SendData = new List<byte>();

                int L = (Data.Length - Pos < BufferSize ? Data.Length - Pos : BufferSize);
                for (int t = Pos; t < L+Pos; t++)
                {
                    switch (Data[t])
                    {
                        case (byte)'C':
                            SendData.Add((byte)'C');
                            SendData.Add((byte)'C'+0x80);
                            break;
                        default:
                            SendData.Add(Data[t]);
                            break;
                    }
                }

                BlockCnt++;

                if (L == BufferSize)
                {
                    OnInstallProgress(15+(int)(((double)Pos/Data.Length)*45), "Uploading block "+BlockCnt);

                    Send(SendData.ToArray());


                    DateTime Start = DateTime.Now;
                    do
                    {
                        Thread.Sleep(10);
                    } while (BytesWaiting() < 1 && (DateTime.Now - Start).TotalMilliseconds < 500);
                    byte[] ReceiveBuffer = ReadAll();

                    if (ReceiveBuffer.Length != 1 || ReceiveBuffer[0] != 0xA9)
                    {
                        throw new Exception("Installing firmware failed. No continue signal during programming.");

                    }

                }
                else
                {
                    OnInstallProgress(15 + (int)(((double)Pos / Data.Length) * 45), (BlockCnt>1?"Uploading last block":"Data block uploaded."));

                    SendData.Add((byte)'C');
                    SendData.Add(0x80);
                    Send(SendData.ToArray());
                    break;
                }
                Pos += BufferSize;
            } while (true);

            DateTime S = DateTime.Now;
            do
            {
                Thread.Sleep(10);
            } while (BytesWaiting() < 1 && (DateTime.Now - S).TotalMilliseconds < 500);
            Thread.Sleep(10);
            byte[] R = ReadAll();

            if (R.Length != 1 || R[0] != 'A')
            {
                throw new Exception("Installing firmware failed. No ack after programming.");

            }
            OnInstallProgress(60, "Firmware upload complete.");

            //Firmware has been installed, now verify

            OnInstallProgress(60, "Verifying firmware.");
            Send(new byte[] { (byte)'C', 7 });
            for (int i = 0; i < Data.Length; i++)
            {
                if (Data[i] != 'C')
                {
                    Send(Data[i]);
                }
                else
                {
                    Send((byte)'C');
                    Send((byte)'C' + 0x80);
                }
                if ((i % 50) == 0)
                {
                    OnInstallProgress(60 + (int)(((double)i / Data.Length) * 39));
                }
            }
            Send((byte)'C');
            Send( 0x80);

            S = DateTime.Now;
            do
            {
                Thread.Sleep(10);
            } while (BytesWaiting() < 1 && (DateTime.Now - S).TotalMilliseconds < 500);
            R = ReadAll();

            if (R.Length != 1 || R[0] != 'A')
            {
                throw new Exception("Verify failed");

            }
            OnInstallProgress(99, "Firmware veryfication complete and OK.");

            OnInstallProgress(100, "Firmware installation complete.");

        }

        public event EventHandler<ProgressEventArgs> InstallProgress;
        /// <summary>
        /// Occurs when the class is MyEvent
        /// </summary>
        protected void OnInstallProgress(int Percentage, string Text="")
        {
            if (InstallProgress != null)
            {
                InstallProgress(this, new ProgressEventArgs() { Percentage = Percentage, Text = Text });
            }
        }

        public class ProgressEventArgs:EventArgs
        {
            public int Percentage { get; set; }
            public string Text { get; set; }
        }



    }



}
