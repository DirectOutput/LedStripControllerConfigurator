using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FTD2XX;
using System.Threading;

namespace LedStripController_Configurator
{
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            PopulateDeviceLists();
        }


  
        private void PopulateDeviceLists()
        {
            StripControllerList.Rows.Clear();
            OtherDeviceList.Rows.Clear();
            FTDI F = new FTDI();

            FTDI.FT_STATUS State = FTDI.FT_STATUS.FT_OK;

            uint DeviceCount = 0;

            State = F.GetNumberOfDevices(ref DeviceCount);
            if (State == FTDI.FT_STATUS.FT_OK)
            {
                if (DeviceCount > 0)
                {
                    FTDI.FT_DEVICE_INFO_NODE[] Devicelist = new FTDI.FT_DEVICE_INFO_NODE[DeviceCount];

                    State = F.GetDeviceList(Devicelist);
                    if (State == FTDI.FT_STATUS.FT_OK)
                    {

                        StripControllerList.Rows.Clear();
                        foreach (FTDI.FT_DEVICE_INFO_NODE D in Devicelist.Where(DE => DE.Type == FTDI.FT_DEVICE.FT_DEVICE_232R && DE.Description.StartsWith(Properties.Settings.Default.LedStripControllerDeviceDescriptionBase)).OrderBy(Co => Co.Description))
                        {
                            int RowIndex = StripControllerList.Rows.Add();
                            StripControllerList.Rows[RowIndex].Tag = D;
                            StripControllerList.Rows[RowIndex].Cells[StripControllerDescription.Name].Value = D.Description;
                            StripControllerList.Rows[RowIndex].Cells[StripControllerNumber.Name].Value = D.Description.Substring(Properties.Settings.Default.LedStripControllerDeviceDescriptionBase.Length);
                            StripControllerList.Rows[RowIndex].Cells[StripControllerSerial.Name].Value = D.SerialNumber;
                            StripControllerList.Rows[RowIndex].Cells[StripControllerHasBootLoader.Name].Value = false;
                            BootLoader B = new BootLoader();
                            try
                            {
                                B.Open(D);
                                B.StartBootLoader();
                                StripControllerList.Rows[RowIndex].Cells[StripControllerHasBootLoader.Name].Value = B.BootLoaderStarted;
                                StripControllerList.Rows[RowIndex].Cells[StripControllerBootLoaderVersion.Name].Value = B.GetBootloaderVersion();
                                StripControllerList.Rows[RowIndex].Cells[StripControllerCPU.Name].Value = B.GetControllerCPU();
                                StripControllerList.Rows[RowIndex].Cells[StripControllerHardwareRevision.Name].Value = B.GetHardwareRevision();
                                try
                                {
                                    StripControllerList.Rows[RowIndex].Cells[StripControllerFirmwareVersion.Name].Value = B.GetFirmwareVersion();
                                    StripControllerList.Rows[RowIndex].Cells[StripControllerFirmwareHardwareRevision.Name].Value = B.GetFirmwareHardwareRevision();
                                }
                                catch 
                                {
                                    StripControllerList.Rows[RowIndex].Cells[StripControllerFirmwareVersion.Name].Value = "";
                                    StripControllerList.Rows[RowIndex].Cells[StripControllerFirmwareHardwareRevision.Name].Value = "";
                                }


                            }
                            catch { }
                            B.Close();
                        }
                        StripControllerList.ClearSelection();

                        OtherDeviceList.Rows.Clear();
                        foreach (FTDI.FT_DEVICE_INFO_NODE D in Devicelist.Where(DE => DE.Type == FTDI.FT_DEVICE.FT_DEVICE_232R && !DE.Description.StartsWith(Properties.Settings.Default.LedStripControllerDeviceDescriptionBase)))
                        {
                            int RowIndex = OtherDeviceList.Rows.Add();
                            OtherDeviceList.Rows[RowIndex].Tag = D;
                            OtherDeviceList.Rows[RowIndex].Cells[OtherDeviceDescription.Name].Value = D.Description;
                            OtherDeviceList.Rows[RowIndex].Cells[OtherDeviceSerial.Name].Value = D.SerialNumber;
                        }

                        OtherDeviceList.ClearSelection();


                    }
                    else
                    {
                        //Error when fetching device list
                        MessageBox.Show(this, "Could not fetch the list of connected devices", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //No devices found
                    MessageBox.Show(this, "No matching USB devices found", "No devices found", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                //Error when getting count of devices
                MessageBox.Show(this, "Could not get number of connected devices", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateSelectionDependencies();
        }



        private void DefineAsLedStripController_Click(object sender, EventArgs e)
        {

            bool OK = false;

            if (CurrentOtherDevice != null)
            {


                DefineLedStripController D = new DefineLedStripController(CurrentOtherDevice, GetValidNumbers());

                if (D.ShowDialog(this) == DialogResult.OK)
                {

                    if (D.ControllerNumber.SelectedIndex >= 0 && D.ControllerNumber.SelectedItem != null)
                    {

                        int Nr = -1;
                        int.TryParse(D.ControllerNumber.SelectedItem.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0], out Nr);

                        if (Nr > 0)
                        {

                            PleaseWait W = new PleaseWait();
                            W.Show(this);
                            W.Refresh();

                            FTDI.FT232R_EEPROM_STRUCTURE EE = new FTDI.FT232R_EEPROM_STRUCTURE();

                            FTDI F = new FTDI();

                            uint OrgDevCount = 0;
                            F.GetNumberOfDevices(ref OrgDevCount);


                            if (F.OpenBySerialNumber(CurrentOtherDevice.SerialNumber) == FTDI.FT_STATUS.FT_OK)
                            {

                                if (F.ReadFT232REEPROM(EE) == FTDI.FT_STATUS.FT_OK)
                                {
                                    EE.Description = Properties.Settings.Default.LedStripControllerDeviceDescriptionBase + Nr.ToString();

                                    if (F.WriteFT232REEPROM(EE) == FTDI.FT_STATUS.FT_OK)
                                    {
                                        OK = true;

                                    }
                                    else
                                    {
                                        //Write failed
                                        MessageBox.Show(this, "Writing data to device with serial " + CurrentOtherDevice.SerialNumber + " failed.\nCould not define Direct Strip Controller.", "Define Direct Strip controller failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    //Could not read eeprom
                                    MessageBox.Show(this, "Reading data from device with serial " + CurrentOtherDevice.SerialNumber + " failed.\nCould not define Direct Strip Controller.", "Define Direct Strip Controller failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }


                                if (F.CyclePort() != FTDI.FT_STATUS.FT_OK)
                                {
                                    //Close failed
                                    MessageBox.Show(this, "A error occured when closing device with serial " + CurrentOtherDevice.SerialNumber + " .\nPlease check if the definition process has been successfull.", "Define Direct Strip Controller error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                DateTime Start = DateTime.Now;

                                uint NewDeviceCount = 0;
                                FTDI.FT_DEVICE_INFO_NODE[] N = new FTDI.FT_DEVICE_INFO_NODE[0];
                                do
                                {
                                    F.GetNumberOfDevices(ref NewDeviceCount);
                                    if (NewDeviceCount == OrgDevCount)
                                    {
                                        N = new FTDI.FT_DEVICE_INFO_NODE[NewDeviceCount];
                                        F.GetDeviceList(N);
                                    }

                                } while (NewDeviceCount != OrgDevCount || !N.All(Dev => Dev != null && Dev.SerialNumber != null && Dev.SerialNumber.Length > 0) || (DateTime.Now - Start).Seconds > 15);

                                F = null;

                                System.Threading.Thread.Sleep(200);
                                PopulateDeviceLists();

                            }
                            else
                            {
                                //Could not open device
                                MessageBox.Show(this, "Opening device with serial " + CurrentOtherDevice.SerialNumber + " failed.\nCould not define Direct Strip Controller.", "Define Direct Strip Controller failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            W.Close();

                            if (OK)
                            {
                                MessageBox.Show(this, "Device successfully defined as " + EE.Description, "Direct Strip Controller defined", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            //no valid number
                        }
                    }
                    else
                    {
                        //no number selected
                    }
                }
            }
        }


        private List<string> GetValidNumbers(uint? CurrentNumber = null)
        {
            List<uint> E = new List<uint>();
            for (int i = 0; i < StripControllerList.Rows.Count; i++)
            {
                E.Add(Convert.ToUInt32(StripControllerList.Rows[i].Cells[StripControllerNumber.Name].Value));
            }

            uint Max = 10;
            if (E.Count > 0)
            {
                Max = E.Max() + 10;
            }
            List<string> N = new List<string>();

            for (uint i = 1; i <= Max; i++)
            {
                if (!E.Contains(i))
                {
                    N.Add(i.ToString());
                }
                else if (CurrentNumber.HasValue && i == CurrentNumber.Value)
                {
                    N.Add(i.ToString() + " (Current)");
                };

            }

            return N;
        }


        FTDI.FT_DEVICE_INFO_NODE CurrentOtherDevice = null;
        private void OtherDeviceList_SelectionChanged(object sender, EventArgs e)
        {
            UpdateSelectionDependencies();
        }


        FTDI.FT_DEVICE_INFO_NODE CurrentStripController = null;
        private void StripControllerList_SelectionChanged(object sender, EventArgs e)
        {
            UpdateSelectionDependencies();
        }


        private void UpdateSelectionDependencies()
        {
            if (StripControllerList.SelectedRows.Count > 0)
            {
                CurrentStripController = (FTDI.FT_DEVICE_INFO_NODE)StripControllerList.SelectedRows[0].Tag;
                ChangeControllerNumber.Enabled = true;
                InstallFirmwareButton.Enabled = true;
            }
            else
            {
                CurrentStripController = null;
                ChangeControllerNumber.Enabled = false;
                InstallFirmwareButton.Enabled = false;
            }
            if (OtherDeviceList.SelectedRows.Count > 0)
            {
                CurrentOtherDevice = (FTDI.FT_DEVICE_INFO_NODE)OtherDeviceList.SelectedRows[0].Tag;
                DefineAsLedStripController.Enabled = true;
            }
            else
            {
                CurrentOtherDevice = null;
                DefineAsLedStripController.Enabled = false;
            }
        }


        private void ChangeControllerNumber_Click(object sender, EventArgs e)
        {
            bool OK = false;

            if (CurrentStripController != null)
            {

                uint CurrentNumber = Convert.ToUInt32(CurrentStripController.Description.Substring(Properties.Settings.Default.LedStripControllerDeviceDescriptionBase.Length));

                ControllerNumberChange D = new ControllerNumberChange(CurrentStripController, CurrentNumber, GetValidNumbers(CurrentNumber));

                if (D.ShowDialog(this) == DialogResult.OK)
                {

                    if (D.ControllerNumber.SelectedIndex >= 0 && D.ControllerNumber.SelectedItem != null)
                    {

                        int Nr = -1;
                        int.TryParse(D.ControllerNumber.SelectedItem.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0], out Nr);

                        if (Nr > 0)
                        {

                            PleaseWait W = new PleaseWait();
                            W.Show(this);
                            W.Refresh();

                            FTDI.FT232R_EEPROM_STRUCTURE EE = new FTDI.FT232R_EEPROM_STRUCTURE();

                            FTDI F = new FTDI();

                            uint OrgDevCount = 0;
                            F.GetNumberOfDevices(ref OrgDevCount);


                            if (F.OpenBySerialNumber(CurrentStripController.SerialNumber) == FTDI.FT_STATUS.FT_OK)
                            {

                                if (F.ReadFT232REEPROM(EE) == FTDI.FT_STATUS.FT_OK)
                                {
                                    EE.Description = Properties.Settings.Default.LedStripControllerDeviceDescriptionBase + Nr.ToString();

                                    if (F.WriteFT232REEPROM(EE) == FTDI.FT_STATUS.FT_OK)
                                    {
                                        OK = true;

                                    }
                                    else
                                    {
                                        //Write failed
                                        MessageBox.Show(this, "Writing data to device with serial " + CurrentStripController.SerialNumber + " failed.\nCould not change controller number.", "Change controller number failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    //Could not read eeprom
                                    MessageBox.Show(this, "Reading data from device with serial " + CurrentStripController.SerialNumber + " failed.\nCould not change controller number.", "Change controller number failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }


                                if (F.CyclePort() != FTDI.FT_STATUS.FT_OK)
                                {
                                    //Close failed
                                    MessageBox.Show(this, "A error occured when closing device with serial " + CurrentStripController.SerialNumber + " .\nPlease check if the definition process has been successfull.", "Change controller number error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                DateTime Start = DateTime.Now;

                                uint NewDeviceCount = 0;
                                FTDI.FT_DEVICE_INFO_NODE[] N = new FTDI.FT_DEVICE_INFO_NODE[0];
                                do
                                {
                                    F.GetNumberOfDevices(ref NewDeviceCount);
                                    if (NewDeviceCount == OrgDevCount)
                                    {
                                        N = new FTDI.FT_DEVICE_INFO_NODE[NewDeviceCount];
                                        F.GetDeviceList(N);
                                    }

                                } while (NewDeviceCount != OrgDevCount || !N.All(Dev => Dev != null && Dev.SerialNumber != null && Dev.SerialNumber.Length > 0) || (DateTime.Now - Start).Seconds > 15);

                                F = null;

                                System.Threading.Thread.Sleep(200);
                                PopulateDeviceLists();

                            }
                            else
                            {
                                //Could not open device
                                MessageBox.Show(this, "Opening device with serial " + CurrentStripController.SerialNumber + " failed.\nCould not change controller number.", "Change controller number failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            W.Close();

                            if (OK)
                            {
                                MessageBox.Show(this, "Controller number successfully changed from " + CurrentNumber + " to " + Nr, "Controller number changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            //no valid number
                        }
                    }
                    else
                    {
                        //no number selected
                    }
                }
            }
        }



        private void RefreshLists_Click(object sender, EventArgs e)
        {
            PleaseWait W = new PleaseWait();

            W.Show(this);
            W.Refresh();

            // FTDI F = new FTDI();
            //Thread.Sleep(1000);
            //  F.Rescan();
            //  F.CyclePort();

            //   F = null;

            PopulateDeviceLists();
            W.Close();
            W = null;
        }

        private void InstallFirmwareButton_Click(object sender, EventArgs e)
        {
            InstallFirmware I = new InstallFirmware(CurrentStripController);

            string FirmwareFilename = "";
            if (I.ShowDialog() == DialogResult.OK)
            {
        
            }
            I.Close();
            I.Dispose();

            RefreshLists_Click(sender, e);



        }



    }
}
