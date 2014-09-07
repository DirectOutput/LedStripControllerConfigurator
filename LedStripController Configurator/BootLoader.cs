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
                while (BytesWaiting() == 0 && (DateTime.Now - Start).TotalMilliseconds < 100)
                {
                    Thread.Sleep(1);
                }
                if (BytesWaiting() == 0)
                {
                    for (int i = 0; i < 400; i++)
                    {
                        Send(new byte[50]);
                        Thread.Sleep(10);
                        ReceiveBuffer = ReadAll();
                        if (ReceiveBuffer.Length > 0 && ReceiveBuffer[ReceiveBuffer.Length - 1] == 'N') break;
                    }
                    Thread.Sleep(20);
                    ReadAll();
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
                    case (byte)'O':
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

            if (ReceiveBuffer[0] != 'O')
            {
                throw new Exception("Could not start bootloader.");
            }

            Send((byte)'B');
            Send(Properties.Settings.Default.BootLoaderPassword);

            Start = DateTime.Now;
            while (BytesWaiting() == 0 && (DateTime.Now - Start).TotalMilliseconds < 30)
            {
                Thread.Sleep(1);
            }
            Thread.Sleep(1);

            ReceiveBuffer = ReadAll();
            if (ReceiveBuffer.Length == 0)
            {
                throw new Exception("No answer received after password.");
            }
            else if (ReceiveBuffer.Length > 1)
            {
                //PW was likely wrong
                throw new Exception("Password has not been accepted by the controller. Password was likely wrong.");
            }
            else if (ReceiveBuffer[0] != 'O')
            {
                //No connect received. PW likely wrong.
                throw new Exception("No OK received after password. Password was likely wrong.");
            }
            BootLoaderStarted = true;

        }


        public string GetBootloaderVersion()
        {

            if (!BootLoaderStarted)
            {
                throw new Exception("Bootloader has not been started.");
            }
            ReadAll();
            Send((byte)'2');

            DateTime Start = DateTime.Now;
            do
            {
                Thread.Sleep(10);
            } while (BytesWaiting() < 2 && (DateTime.Now - Start).TotalMilliseconds < 30);
            byte[] ReceiveBuffer = ReadAll();

            if (ReceiveBuffer.Length < 3 || ReceiveBuffer[0] != ReceiveBuffer.Length - 1 || ReceiveBuffer[ReceiveBuffer.Length - 1] != (byte)'O')
            {
                throw new Exception("Could not read bootloader version");
            }

            return System.Text.Encoding.UTF8.GetString(ReceiveBuffer.Where((B, I) => I > 0 && I < ReceiveBuffer.Length - 1).ToArray());
        }


        public int GetBufferSize()
        {

            if (!BootLoaderStarted)
            {
                throw new Exception("Bootloader has not been started.");
            }
            ReadAll();

            Send((byte)'3');
            DateTime Start = DateTime.Now;
            do
            {
                Thread.Sleep(10);
            } while (BytesWaiting() < 4 && (DateTime.Now - Start).TotalMilliseconds < 30);
            byte[] ReceiveBuffer = ReadAll();


            if (ReceiveBuffer.Length == 4 && ReceiveBuffer[0] == 3 && ReceiveBuffer[3] == 'O')
            {

                return ReceiveBuffer[1] * 256 + ReceiveBuffer[2];

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

            Send((byte)'4');
            DateTime Start = DateTime.Now;
            do
            {
                Thread.Sleep(10);
            } while (BytesWaiting() < 5 && (DateTime.Now - Start).TotalMilliseconds < 30);
            byte[] ReceiveBuffer = ReadAll();

            if (ReceiveBuffer.Length == 5 && ReceiveBuffer[0] == 4 && ReceiveBuffer[4] == 'O')
            {
                int Signature = ReceiveBuffer[1] * 65536 + ReceiveBuffer[2] * 256 + ReceiveBuffer[3];
                if (Enum.IsDefined(typeof(AVRTypeEnum), Signature))
                {
                    return Enum.GetName(typeof(AVRTypeEnum), Signature);
                }
                else
                {
                    return "Unknown" + ReceiveBuffer[1].ToString("X") + " " + ReceiveBuffer[2].ToString("X") + ReceiveBuffer[3].ToString("X");
                }


            }
            else
            {
                throw new Exception("Could not read signature bytes/controller cpu");
            }


        }



        public int GetUserFlashSize()
        {

            if (!BootLoaderStarted)
            {
                throw new Exception("Bootloader has not been started.");
            }
            ReadAll();

            Send((byte)'5');
            DateTime Start = DateTime.Now;
            do
            {
                Thread.Sleep(10);
            } while (BytesWaiting() < 5 && (DateTime.Now - Start).TotalMilliseconds < 30);
            byte[] ReceiveBuffer = ReadAll();


            if (ReceiveBuffer.Length == 5 && ReceiveBuffer[0] == 4 && ReceiveBuffer[4] == 'O')
            {

                return ReceiveBuffer[1] * 65536 + ReceiveBuffer[2] * 256 + ReceiveBuffer[3];

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
            if (Data.Length == 0)
            {
                throw new Exception("0 Firmware bytes found in file " + FirmwareFilename);
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
            if (BufferSize != 256)
            {
                throw new Exception("Buffersize is not 256bytes (Hardware reports " + BufferSize.ToString() + " bytes)");
            }


            int FlashSize = GetUserFlashSize();
            OnInstallProgress(14, "Flash size read: " + FlashSize + " / 0x" + FlashSize.ToString("X"));


            if (FlashSize < Data.Length)
            {
                throw new Exception("Firmware size is to big for controller flash memory.");
            }

            ReadAll();


            int BlockCnt = (Data.Length >> 8) + ((Data.Length & 255) != 0 ? 1 : 0);
            OnInstallProgress(15, string.Format("Uploading {0} blocks of firmware data.",BlockCnt));

            DateTime Start;

            int Pos = 0;

            for (int CurrentBlock = 0; CurrentBlock < BlockCnt; CurrentBlock++)
            {
                Pos = CurrentBlock * 256;

                #region Prepare Datablock
                byte[] DataBlock = new byte[260];

                DataBlock[0] = (byte)'>';
                DataBlock[1] = (byte)((Pos >> 16) & 255);
                DataBlock[2] = (byte)((Pos >> 8) & 255);

                Buffer.BlockCopy(Data, Pos, DataBlock, 3, (Pos + 256 <= Data.Length ? 256 : Data.Length - Pos));

                byte CheckSum = 0x55;
                for (int i = 1; i <= 258; i++)
                {
                    CheckSum ^= DataBlock[i];
                }
                DataBlock[259] = CheckSum;

                #endregion

                byte[] Response;
                int BlockState = 0;
                int TryCnt = 0;
                const int Tries = 5;
                do
                {
                    switch (BlockState)
                    {
                        case 0:
                            Send(DataBlock);
                            Start = DateTime.Now;
                            while (BytesWaiting() == 0 && (DateTime.Now - Start).TotalMilliseconds < 100)
                            {
                                Thread.Sleep(1);
                            }

                            Response = ReadAll();
                            if (Response.Length != 1 || Response[0] != 'O')
                            {
                                //Data upload failed
                                Thread.Sleep(5);
                                if (Response.Length > 1 || BytesWaiting() != 0)
                                {
                                    //Bootloader in unknown state. Restart bootloader
                                    OnInstallProgress((int)(15 + ((double)84 / BlockCnt / 2) * ((double)CurrentBlock * 2)), string.Format("Uploading block {0} at address {1} / 0x{1:x} failed. Restarting bootloader.", CurrentBlock, Pos));
                                    StartBootLoader();
                                    OnInstallProgress((int)(15 + ((double)84 / BlockCnt / 2) * ((double)CurrentBlock * 2)), string.Format("Bootloader restarted.{0}", (TryCnt < Tries - 1 ? " Will try again." : "")));
                                }
                                else
                                {
                                    //only the current command has failed. just try again
                                    OnInstallProgress((int)(15 + ((double)84 / BlockCnt / 2) * ((double)CurrentBlock * 2)), string.Format("Uploading block {0} at address {1} / 0x{1:x} failed.{2}", CurrentBlock, Pos, (TryCnt < Tries - 1 ? " Will try again." : "")));
                                }
                                TryCnt++;
                            }
                            else
                            {
                                //Upload is ok. Write.
                                BlockState = 1;
                            }
                            OnInstallProgress((int)(15 + ((double)84 / BlockCnt / 2) * ((double)CurrentBlock * 2)));
                            break;
                        case 1:
                            Send((byte)'!');
                            Start = DateTime.Now;
                            while (BytesWaiting() == 0 && (DateTime.Now - Start).TotalMilliseconds < 100)
                            {
                                Thread.Sleep(1);
                            }

                            Response = ReadAll();
                            if (Response.Length != 1 || Response[0] != 'O')
                            {
                                //Data write/verify failed
                                Thread.Sleep(5);

                                if (Response.Length > 1 || BytesWaiting() != 0)
                                {
                                    //Bootloader in unknown state. Restart bootloader
                                    OnInstallProgress((int)(15 + ((double)84 / BlockCnt / 2) * ((double)(CurrentBlock * 2) + 1)), string.Format("Verify of block {0} at address {1} / 0x{1:x} failed. Restarting bootloader.", CurrentBlock, Pos));
                                    StartBootLoader();
                                    OnInstallProgress((int)(15 + ((double)84 / BlockCnt / 2) * ((double)(CurrentBlock * 2) + 1)), string.Format("Bootloader restarted.{0}", (TryCnt < Tries - 1 ? " Will try again." : "")));
                                    BlockState = 0;
                                }
                                else
                                {
                                    //only the current command has failed. just try again
                                    OnInstallProgress((int)(15 + ((double)84 / BlockCnt / 2) * ((double)(CurrentBlock * 2) + 1)), string.Format("Verify of block {0} at address {1} / 0x{1:x} failed.{2}", CurrentBlock, Pos, (TryCnt < Tries - 1 ? " Will try again." : "")));
                                }
                                TryCnt++;
                            }
                            else
                            {
                                //Verify ok, exit loop
                                BlockState = 2;

                            }



                            break;
                        default:
                            throw new Exception("Unknown state");
                            break;
                    }



                } while (BlockState < 2 && TryCnt < Tries);

                if (BlockState != 2)
                {
                    throw new Exception(string.Format("Upload or verify of block {0} at address {1} / 0x{1:x} failed.", CurrentBlock, Pos));
                }



            }


            OnInstallProgress(99, "Firmware upload and veryfication complete and OK.");

            OnInstallProgress(100, "Firmware installation complete.");

        }





        public event EventHandler<ProgressEventArgs> InstallProgress;
        /// <summary>
        /// Occurs when the class is MyEvent
        /// </summary>
        protected void OnInstallProgress(int Percentage, string Text = "")
        {
            if (InstallProgress != null)
            {
                InstallProgress(this, new ProgressEventArgs() { Percentage = Percentage, Text = Text });
            }
        }

        public class ProgressEventArgs : EventArgs
        {
            public int Percentage { get; set; }
            public string Text { get; set; }
        }



    }



}
