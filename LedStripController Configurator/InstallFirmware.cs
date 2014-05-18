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
            NumberText.Text = CurrentStripController.Description.Substring(Properties.Settings.Default.LedStripControllerDeviceDescriptionBase.Length);
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
                ControllerConfirm.Enabled = true;
                ControllerMessage.Text = "Controller accessible. Please confirm that you want to install the firmware on this controller.";


            }
            catch
            {
                ControllerConfirm.Enabled = false;
                ControllerConfirm.Checked = false;

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
                    Confirm.SelectedIndex = -1;
                    break;
                case 1:
                    NextEnabled = HexFileOK.Checked;
                    Confirm.SelectedIndex = -1;

                    BackEnabled = true;
                    break;
                case 2:
                    NextEnabled = (Confirm.SelectedIndex == 1);
                    BackEnabled = true;
                    break;
                case 3:
                    FinishEnabled = InstallationCompleteText.Visible || InstallationFailedText.Visible;

                    break;
            }

            ConfirmText.Text = "Please confirm that you want to update the controller '" + DescriptionText.Text + "' with the hex file '" + FirmwareFilename.Text + "'.\n\nAre you sure you want to continue?";

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

            string Filename = ("" + FirmwareFilename.Text).Trim();
            int L = -1;
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
                        L = H.GetBinaryData().Length;
                        HexFileOK.Checked = true;
                        BinarySizeText.Text = L.ToString() + " / 0x" + L.ToString("X") + " bytes";
                        FileStateText.Text = "File is OK.";

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


        List<string> InstallLog = new List<string>();
        private void Install()
        {
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
                InstallLog.Add("Bootloader installation successful.");
                RefreshInstallationData(100, InstallLog, BootLoaderInstallResult.Success);

            }
            catch (Exception E)
            {
                InstallLog.Add("");
                InstallLog.Add("Bootloader installation failed.");
                InstallLog.Add(E.Message);
                if (E.InnerException != null)
                {
                    InstallLog.Add(E.InnerException.Message);
                }
                RefreshInstallationData(0, InstallLog, BootLoaderInstallResult.Failed);
            }
            B.Close();
            B = null;

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

    }
}
