using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FTD2XX;

namespace LedStripController_Configurator
{
    public partial class InstallFirmware : Form
    {
        public InstallFirmware(FTDI.FT_DEVICE_INFO_NODE CurrentStripController)
        {
            InitializeComponent();
            this.CurrentStripController = CurrentStripController;

            PopulateControllerTab();
            PopulateHexFileData();
            PopulateInstallationData(0, new List<string>(), BootLoaderInstallResult.WaitStart);

            UpdateWizard();
        }

        private void PopulateControllerTab()
        {
            DescriptionText.Text = CurrentStripController.Description;
            NumberText.Text = CurrentStripController.Description.Substring(Properties.Settings.Default.LedStripControllerDeviceDescriptionBase.Trim().Length);
            SerialText.Text = CurrentStripController.SerialNumber;
            ControllerMessage.Text = "";
            BootLoader B = new BootLoader();
            try
            {
                B.Open(CurrentStripController);
                B.StartBootLoader();



                CPUText.Text = B.GetControllerCPU();
                int S = B.GetBufferSize();
                BufferSizeText.Text = S.ToString() + " / 0x" + S.ToString("X");
                S = B.GetUserFlashSize();
                UserFlashText.Text = S.ToString() + " / 0x" + S.ToString("X");

                BootloaderVersionText.Text = B.GetBootloaderVersion();
                HardwareRevisionText.Text = B.GetHardwareRevision();

                try
                {
                    CurrentFirmwareVersionText.Text = B.GetFirmwareVersion();
                }
                catch
                {
                    CurrentFirmwareVersionText.Text = "";
                }

                Version BLVersion = new Version(BootloaderVersionText.Text);
                Version V = new Version(Properties.Settings.Default.MaxBootloaderVersion);
                if (V >= BLVersion)
                {

                    ControllerConfirm.Enabled = true;
                    ControllerConfirm.Visible = true;
                    ControllerMessage.Text = "Controller accessible. Please confirm that you want to install the firmware on this controller.";
                }
                else
                {
                    ControllerConfirm.Enabled = false;
                    ControllerConfirm.Checked = false;
                    ControllerConfirm.Visible = false;

                    ControllerMessage.Text = string.Format("This tool does only allow updates on controllers having a bootloader version of {0} or below, but your controller uses bootloader version {1}.\nPlease check for a updated version of this tool.",Properties.Settings.Default.MaxBootloaderVersion,BootloaderVersionText.Text);
                }

            }
            catch
            {
                ControllerConfirm.Enabled = false;
                ControllerConfirm.Checked = false;
                ControllerConfirm.Visible = false;
                ControllerMessage.Text = "Controller not accessible. Cant install firmware.\nTo try again, close this window, make sure no other applications are accessing the controller, unplug and plugin the controller again and finnaly click the refresh button in the main window.";

            }
            B.Close();

        }

        FTDI.FT_DEVICE_INFO_NODE CurrentStripController = null;

        private void SelectFirmwareFileButton_Click(object sender, EventArgs e)
        {
            if (SelectFirmwareFileDialog.ShowDialog(this.Owner) == DialogResult.OK)
            {
                FirmwareFilename.Text = SelectFirmwareFileDialog.FileName;
            }
        }


        private int WizardStep = 0;
        private void UpdateWizard()
        {
            if (Wizard.SelectedIndex != WizardStep)
            {
                Wizard.SelectedIndex = WizardStep;
                this.Text = "Install Firmware - " + Wizard.SelectedTab.Text;
            }

            bool BackEnabled = false;
            bool NextEnabled = false;
            bool FinishEnabled = false;
            switch (WizardStep)
            {
                case 0:
                    NextEnabled = ControllerConfirm.Checked;
                    break;
                case 1:
                    NextEnabled = HexFileOK.Checked && HexFileConfirm.Checked;

                    BackEnabled = true;
                    break;
                case 2:
                    NextEnabled = false;
                    BackEnabled = !InstallComplete;
                    FinishEnabled = InstallComplete;
                    break;
            }


            BackButton.Enabled = BackEnabled;
            NextButton.Enabled = NextEnabled;
            FinishButton.Enabled = FinishEnabled;
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            WizardStep++;
            UpdateWizard();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            WizardStep--;
            UpdateWizard();
        }



        private void SelectFirmwareFileButton_Click_1(object sender, EventArgs e)
        {
            if (SelectFirmwareFileDialog.ShowDialog(this.Owner) == DialogResult.OK)
            {
                FirmwareFilename.Text = SelectFirmwareFileDialog.FileName;
                PopulateHexFileData();
                UpdateWizard();
            }
        }

        private void FirmwareFilename_TextChanged(object sender, EventArgs e)
        {
            PopulateHexFileData();
            UpdateWizard();
        }

        private void FirmwareFilename_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void FirmwareFilename_ModifiedChanged(object sender, EventArgs e)
        {
            PopulateHexFileData();
            UpdateWizard();
        }

        private void ControllerConfirm_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWizard();
        }

        private void PopulateHexFileData()
        {
            BinarySizeText.Text = "";
            HexFileOK.Checked = false;
            FileStateText.Text = "";
            FileDate.Text = "";
            HexFileConfirm.Checked = false;
            HexFileConfirm.Visible = false;
            NewFirmwareVersionText.Text = "";
            NewHardwareRevisionText.Text = "";

            string Filename = ("" + FirmwareFilename.Text).Trim();
            int L = -1;
            byte[] B;
            if (!string.IsNullOrWhiteSpace(Filename))
            {
                FileInfo FI = new FileInfo(Filename);
                if (FI.Exists)
                {

                    FileDate.Text = FI.CreationTime.ToString();
                    try
                    {
                        HexFile H = new HexFile();
                        H.LoadFile(Filename);
                        B = H.GetBinaryData();
                        L = B.Length;


                        BinarySizeText.Text = L.ToString() + " / 0x" + L.ToString("X") + " bytes";


                        byte CheckSum = 0x55;
                        for (int i = 0; i < 31; i++)
                        {
                            CheckSum ^= B[0x70 * 2 + i];
                        }
                        if (CheckSum == 0)
                        {

                            string HWRevision = System.Text.Encoding.UTF8.GetString(B.Where((C, I) => I > (0x70 * 2 + 16) && I <= (0x70 * 2 + 16) + B[(0x70 * 2 + 16)]).ToArray());
                            string Version = System.Text.Encoding.UTF8.GetString(B.Where((C, I) => I > (0x70 * 2) && I <= (0x70 * 2) + B[(0x70 * 2)]).ToArray());

                            NewFirmwareVersionText.Text = Version;
                            NewHardwareRevisionText.Text = HWRevision;

                            if (HWRevision == HardwareRevisionText.Text)
                            {
                                if (!string.IsNullOrWhiteSpace(CurrentFirmwareVersionText.Text))
                                {
                                    Version V = new System.Version(Version);
                                    Version O = new System.Version(CurrentFirmwareVersionText.Text);

                                    if (V == O)
                                    {
                                        //Same firmware
                                        HexFileConfirm.Visible = true;
                                        FileStateText.Text = "WARNING! " + System.Environment.NewLine + "The firmware version with the same number is currently installed on your controller. " + System.Environment.NewLine + "Please confirm that you want to install this firmware.";
                                    }
                                    else if (V < O)
                                    {
                                        //old firmware
                                        FileStateText.Text = "WARNING! " + System.Environment.NewLine + "A firmware version with a higher number is currently installed on your controller. " + System.Environment.NewLine + "Please confirm that you want to install this firmware.";
                                        HexFileConfirm.Visible = true;

                                    }
                                    else
                                    {
                                        //new firmware
                                        FileStateText.Text="Firmware ready for installation.";
                                        HexFileConfirm.Checked = true;
                                    }

                                }
                                else
                                {
                                    //no existing firmware
                                    FileStateText.Text = "Firmware ready for installation.";
                                    HexFileConfirm.Checked = true;
                                }
                               
                                HexFileOK.Checked = true;

                            }
                            else
                            {
                                //Wrong Hardware
                                FileStateText.Text = "ERROR! " + System.Environment.NewLine + "The firmware in file " + Filename + " has been designed for another hardware revision." + System.Environment.NewLine + "Your controller has hardware revision " + HardwareRevisionText.Text + ". " + System.Environment.NewLine + "Please use a matching firmware file.";
                            }
                        }
                        else
                        {
                            //Invalid file
                            FileStateText.Text = "ERROR! The file " + Filename + " is not a valid firmware file." + System.Environment.NewLine + "Firmware version and supported hardware revision not found.";
                        }

                    }
                    catch (Exception E)
                    {
                        FileStateText.Text = "Error parsing file: " + E.Message;
                    }
                }
                else
                {
                    // File does not exist
                    FileStateText.Text = "File does not exist.";
                }
            }
            else
            {
                //no file specified.

            }


        }


        bool InstallComplete = false;
        List<string> InstallLog = new List<string>();
        private void Install()
        {
            InstallComplete = false;
            InstallLog = new List<string>();
            BootLoader B = new BootLoader();
            try
            {

                B.Open(CurrentStripController);
                B.StartBootLoader();
                B.InstallProgress += new EventHandler<BootLoader.ProgressEventArgs>(Bootloader_InstallProgress);
                B.InstallFirmware(FirmwareFilename.Text);
                B.InstallProgress -= new EventHandler<BootLoader.ProgressEventArgs>(Bootloader_InstallProgress);

                InstallLog.Add("");
                InstallLog.Add("Firmware installation successful.");
                RefreshInstallationData(100, InstallLog, BootLoaderInstallResult.Success);

            }
            catch (Exception E)
            {
                InstallLog.Add("");
                InstallLog.Add("Firmware installation failed.");
                InstallLog.Add(E.Message);
                if (E.InnerException != null)
                {
                    InstallLog.Add(E.InnerException.Message);
                }
                RefreshInstallationData(0, InstallLog, BootLoaderInstallResult.Failed);
            }
            B.Close();
            B = null;

            InstallComplete = true;
            UpdateWizard();
        }


        void Bootloader_InstallProgress(object sender, BootLoader.ProgressEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.Text))
            {
                InstallLog.Add(e.Text);
            }
            RefreshInstallationData(e.Percentage, InstallLog, BootLoaderInstallResult.PleaseWait);

        }

        private enum BootLoaderInstallResult
        {
            WaitStart,
            PleaseWait,
            Success,
            Failed
        }


        private void RefreshInstallationData(int Progress, List<string> InstallLog, BootLoaderInstallResult Result)
        {
            PopulateInstallationData(Progress, InstallLog, Result);
            InstallationProgress.Refresh();
            InstallationStatusText.Refresh();
            InstallationFailedText.Refresh();
            InstallationCompleteText.Refresh();
            InstallationPleaseWaitText.Refresh();
            InstallationStartButton.Refresh();
        }

        private void PopulateInstallationData(int Progress, List<string> InstallLog, BootLoaderInstallResult Result)
        {

            InstallationProgress.Value = Progress;
            InstallationStatusText.Lines = InstallLog.ToArray();
            InstallationFailedText.Visible = false;
            InstallationCompleteText.Visible = false;
            InstallationPleaseWaitText.Visible = false;
            InstallationStartButton.Visible = false;

            switch (Result)
            {
                case BootLoaderInstallResult.Success:
                    InstallationCompleteText.Visible = true;
                    break;
                case BootLoaderInstallResult.Failed:
                    InstallationFailedText.Visible = true;
                    break;
                case BootLoaderInstallResult.PleaseWait:
                    InstallationPleaseWaitText.Visible = true;
                    break;
                case BootLoaderInstallResult.WaitStart:
                default:
                    InstallationStartButton.Visible = true;
                    break;
            }
        }


        private void Confirm_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateWizard();
        }


        public string SelectedFilename
        {
            get
            {
                return FirmwareFilename.Text;
            }
        }

        private void InstallationStartButton_Click(object sender, EventArgs e)
        {
            Install();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FinishButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HexFileConfirm_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWizard();
        }


    }
}
