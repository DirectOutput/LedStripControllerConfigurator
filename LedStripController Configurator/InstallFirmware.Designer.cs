namespace LedStripController_Configurator
{
    partial class InstallFirmware
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstallFirmware));
            this.SelectFirmwareFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.NextButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.Wizard = new System.Windows.Forms.TablessTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.HardwareRevisionText = new System.Windows.Forms.Label();
            this.BootloaderVersionText = new System.Windows.Forms.Label();
            this.CurrentFirmwareVersionText = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.ControllerMessage = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.UserFlashText = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.BufferSizeText = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CPUText = new System.Windows.Forms.Label();
            this.ControllerConfirm = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SerialText = new System.Windows.Forms.Label();
            this.NumberText = new System.Windows.Forms.Label();
            this.DescriptionText = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.HexFileConfirm = new System.Windows.Forms.CheckBox();
            this.NewHardwareRevisionText = new System.Windows.Forms.Label();
            this.NewFirmwareVersionText = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.FileDate = new System.Windows.Forms.Label();
            this.FileStateText = new System.Windows.Forms.Label();
            this.BinarySizeText = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.HexFileOK = new System.Windows.Forms.CheckBox();
            this.SelectFirmwareFileButton = new System.Windows.Forms.Button();
            this.FirmwareFilename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.InstallationStatusText = new System.Windows.Forms.TextBox();
            this.InstallationStartButton = new System.Windows.Forms.Button();
            this.InstallationPleaseWaitText = new System.Windows.Forms.Label();
            this.InstallationFailedText = new System.Windows.Forms.Label();
            this.InstallationCompleteText = new System.Windows.Forms.Label();
            this.InstallationProgress = new System.Windows.Forms.ProgressBar();
            this.FinishButton = new System.Windows.Forms.Button();
            this.Wizard.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectFirmwareFileDialog
            // 
            this.SelectFirmwareFileDialog.DefaultExt = "hex";
            this.SelectFirmwareFileDialog.Filter = "Hex-File|*.hex|All files|*.*";
            // 
            // NextButton
            // 
            this.NextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NextButton.Location = new System.Drawing.Point(462, 315);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(132, 23);
            this.NextButton.TabIndex = 2;
            this.NextButton.Text = "Next >";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BackButton.Location = new System.Drawing.Point(324, 315);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(132, 23);
            this.BackButton.TabIndex = 3;
            this.BackButton.Text = "< Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(11, 315);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // Wizard
            // 
            this.Wizard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Wizard.Controls.Add(this.tabPage1);
            this.Wizard.Controls.Add(this.tabPage2);
            this.Wizard.Controls.Add(this.tabPage4);
            this.Wizard.Location = new System.Drawing.Point(0, 0);
            this.Wizard.Name = "Wizard";
            this.Wizard.SelectedIndex = 0;
            this.Wizard.Size = new System.Drawing.Size(736, 309);
            this.Wizard.TabIndex = 1;
            this.Wizard.TabsVisible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.HardwareRevisionText);
            this.tabPage1.Controls.Add(this.BootloaderVersionText);
            this.tabPage1.Controls.Add(this.CurrentFirmwareVersionText);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.ControllerMessage);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.UserFlashText);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.BufferSizeText);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.CPUText);
            this.tabPage1.Controls.Add(this.ControllerConfirm);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.SerialText);
            this.tabPage1.Controls.Add(this.NumberText);
            this.tabPage1.Controls.Add(this.DescriptionText);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(728, 283);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Confirm Controller";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // HardwareRevisionText
            // 
            this.HardwareRevisionText.AutoSize = true;
            this.HardwareRevisionText.Location = new System.Drawing.Point(423, 103);
            this.HardwareRevisionText.Name = "HardwareRevisionText";
            this.HardwareRevisionText.Size = new System.Drawing.Size(41, 13);
            this.HardwareRevisionText.TabIndex = 20;
            this.HardwareRevisionText.Text = "label16";
            // 
            // BootloaderVersionText
            // 
            this.BootloaderVersionText.AutoSize = true;
            this.BootloaderVersionText.Location = new System.Drawing.Point(423, 34);
            this.BootloaderVersionText.Name = "BootloaderVersionText";
            this.BootloaderVersionText.Size = new System.Drawing.Size(41, 13);
            this.BootloaderVersionText.TabIndex = 19;
            this.BootloaderVersionText.Text = "label16";
            // 
            // CurrentFirmwareVersionText
            // 
            this.CurrentFirmwareVersionText.AutoSize = true;
            this.CurrentFirmwareVersionText.Location = new System.Drawing.Point(423, 57);
            this.CurrentFirmwareVersionText.Name = "CurrentFirmwareVersionText";
            this.CurrentFirmwareVersionText.Size = new System.Drawing.Size(41, 13);
            this.CurrentFirmwareVersionText.TabIndex = 18;
            this.CurrentFirmwareVersionText.Text = "label16";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(290, 57);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(97, 13);
            this.label15.TabIndex = 17;
            this.label15.Text = "Hardware Revision";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(290, 34);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "Bootloader Version:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(290, 103);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(127, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "Current Firmware Version;";
            // 
            // ControllerMessage
            // 
            this.ControllerMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ControllerMessage.Location = new System.Drawing.Point(8, 171);
            this.ControllerMessage.Name = "ControllerMessage";
            this.ControllerMessage.Size = new System.Drawing.Size(712, 70);
            this.ControllerMessage.TabIndex = 14;
            this.ControllerMessage.Text = "ControllerMessage";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 149);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "User Flash:";
            // 
            // UserFlashText
            // 
            this.UserFlashText.AutoSize = true;
            this.UserFlashText.Location = new System.Drawing.Point(77, 149);
            this.UserFlashText.Name = "UserFlashText";
            this.UserFlashText.Size = new System.Drawing.Size(35, 13);
            this.UserFlashText.TabIndex = 12;
            this.UserFlashText.Text = "label5";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Buffer Size:";
            // 
            // BufferSizeText
            // 
            this.BufferSizeText.AutoSize = true;
            this.BufferSizeText.Location = new System.Drawing.Point(77, 126);
            this.BufferSizeText.Name = "BufferSizeText";
            this.BufferSizeText.Size = new System.Drawing.Size(35, 13);
            this.BufferSizeText.TabIndex = 10;
            this.BufferSizeText.Text = "label5";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "CPU:";
            // 
            // CPUText
            // 
            this.CPUText.AutoSize = true;
            this.CPUText.Location = new System.Drawing.Point(77, 103);
            this.CPUText.Name = "CPUText";
            this.CPUText.Size = new System.Drawing.Size(35, 13);
            this.CPUText.TabIndex = 8;
            this.CPUText.Text = "label5";
            // 
            // ControllerConfirm
            // 
            this.ControllerConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ControllerConfirm.AutoSize = true;
            this.ControllerConfirm.Location = new System.Drawing.Point(11, 260);
            this.ControllerConfirm.Name = "ControllerConfirm";
            this.ControllerConfirm.Size = new System.Drawing.Size(192, 17);
            this.ControllerConfirm.TabIndex = 7;
            this.ControllerConfirm.Text = "Yes, I want to update this controller";
            this.ControllerConfirm.UseVisualStyleBackColor = true;
            this.ControllerConfirm.CheckedChanged += new System.EventHandler(this.ControllerConfirm_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(418, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Please confirm that you want to install or update the firmware on the following c" +
    "ontroller:";
            // 
            // SerialText
            // 
            this.SerialText.AutoSize = true;
            this.SerialText.Location = new System.Drawing.Point(77, 80);
            this.SerialText.Name = "SerialText";
            this.SerialText.Size = new System.Drawing.Size(35, 13);
            this.SerialText.TabIndex = 5;
            this.SerialText.Text = "label5";
            // 
            // NumberText
            // 
            this.NumberText.AutoSize = true;
            this.NumberText.Location = new System.Drawing.Point(77, 57);
            this.NumberText.Name = "NumberText";
            this.NumberText.Size = new System.Drawing.Size(35, 13);
            this.NumberText.TabIndex = 4;
            this.NumberText.Text = "label5";
            // 
            // DescriptionText
            // 
            this.DescriptionText.AutoSize = true;
            this.DescriptionText.Location = new System.Drawing.Point(77, 34);
            this.DescriptionText.Name = "DescriptionText";
            this.DescriptionText.Size = new System.Drawing.Size(35, 13);
            this.DescriptionText.TabIndex = 3;
            this.DescriptionText.Text = "label5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Serial:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Description:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.HexFileConfirm);
            this.tabPage2.Controls.Add(this.NewHardwareRevisionText);
            this.tabPage2.Controls.Add(this.NewFirmwareVersionText);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.FileDate);
            this.tabPage2.Controls.Add(this.FileStateText);
            this.tabPage2.Controls.Add(this.BinarySizeText);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.HexFileOK);
            this.tabPage2.Controls.Add(this.SelectFirmwareFileButton);
            this.tabPage2.Controls.Add(this.FirmwareFilename);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(728, 283);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Select firmware file";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // HexFileConfirm
            // 
            this.HexFileConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.HexFileConfirm.AutoSize = true;
            this.HexFileConfirm.Location = new System.Drawing.Point(11, 260);
            this.HexFileConfirm.Name = "HexFileConfirm";
            this.HexFileConfirm.Size = new System.Drawing.Size(248, 17);
            this.HexFileConfirm.TabIndex = 18;
            this.HexFileConfirm.Text = "Yes, I really want to install this firmware version.";
            this.HexFileConfirm.UseVisualStyleBackColor = true;
            this.HexFileConfirm.CheckedChanged += new System.EventHandler(this.HexFileConfirm_CheckedChanged);
            // 
            // NewHardwareRevisionText
            // 
            this.NewHardwareRevisionText.AutoSize = true;
            this.NewHardwareRevisionText.Location = new System.Drawing.Point(174, 119);
            this.NewHardwareRevisionText.Name = "NewHardwareRevisionText";
            this.NewHardwareRevisionText.Size = new System.Drawing.Size(41, 13);
            this.NewHardwareRevisionText.TabIndex = 17;
            this.NewHardwareRevisionText.Text = "label18";
            // 
            // NewFirmwareVersionText
            // 
            this.NewFirmwareVersionText.AutoSize = true;
            this.NewFirmwareVersionText.Location = new System.Drawing.Point(174, 92);
            this.NewFirmwareVersionText.Name = "NewFirmwareVersionText";
            this.NewFirmwareVersionText.Size = new System.Drawing.Size(41, 13);
            this.NewFirmwareVersionText.TabIndex = 16;
            this.NewFirmwareVersionText.Text = "label18";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 119);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(160, 13);
            this.label17.TabIndex = 15;
            this.label17.Text = "Firmware for Hardware Revision:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 92);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 13);
            this.label16.TabIndex = 14;
            this.label16.Text = "Firmware version:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 67);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "FileDate:";
            // 
            // FileDate
            // 
            this.FileDate.AutoSize = true;
            this.FileDate.Location = new System.Drawing.Point(174, 67);
            this.FileDate.Name = "FileDate";
            this.FileDate.Size = new System.Drawing.Size(41, 13);
            this.FileDate.TabIndex = 12;
            this.FileDate.Text = "label14";
            // 
            // FileStateText
            // 
            this.FileStateText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileStateText.Location = new System.Drawing.Point(8, 157);
            this.FileStateText.Name = "FileStateText";
            this.FileStateText.Size = new System.Drawing.Size(714, 91);
            this.FileStateText.TabIndex = 11;
            this.FileStateText.Text = "label12";
            // 
            // BinarySizeText
            // 
            this.BinarySizeText.AutoSize = true;
            this.BinarySizeText.Location = new System.Drawing.Point(174, 43);
            this.BinarySizeText.Name = "BinarySizeText";
            this.BinarySizeText.Size = new System.Drawing.Size(77, 13);
            this.BinarySizeText.TabIndex = 9;
            this.BinarySizeText.Text = "BinarySizeText";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(98, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 13);
            this.label9.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Binary data size:";
            // 
            // HexFileOK
            // 
            this.HexFileOK.AutoSize = true;
            this.HexFileOK.Enabled = false;
            this.HexFileOK.Location = new System.Drawing.Point(599, 119);
            this.HexFileOK.Name = "HexFileOK";
            this.HexFileOK.Size = new System.Drawing.Size(109, 17);
            this.HexFileOK.TabIndex = 6;
            this.HexFileOK.Text = "Firmware file is ok";
            this.HexFileOK.UseVisualStyleBackColor = true;
            this.HexFileOK.Visible = false;
            // 
            // SelectFirmwareFileButton
            // 
            this.SelectFirmwareFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectFirmwareFileButton.Location = new System.Drawing.Point(697, 4);
            this.SelectFirmwareFileButton.Name = "SelectFirmwareFileButton";
            this.SelectFirmwareFileButton.Size = new System.Drawing.Size(28, 23);
            this.SelectFirmwareFileButton.TabIndex = 5;
            this.SelectFirmwareFileButton.Text = "...";
            this.SelectFirmwareFileButton.UseVisualStyleBackColor = true;
            this.SelectFirmwareFileButton.Click += new System.EventHandler(this.SelectFirmwareFileButton_Click_1);
            // 
            // FirmwareFilename
            // 
            this.FirmwareFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FirmwareFilename.Location = new System.Drawing.Point(85, 6);
            this.FirmwareFilename.Name = "FirmwareFilename";
            this.FirmwareFilename.ReadOnly = true;
            this.FirmwareFilename.Size = new System.Drawing.Size(609, 20);
            this.FirmwareFilename.TabIndex = 4;
            this.FirmwareFilename.ModifiedChanged += new System.EventHandler(this.FirmwareFilename_ModifiedChanged);
            this.FirmwareFilename.TextChanged += new System.EventHandler(this.FirmwareFilename_TextChanged);
            this.FirmwareFilename.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FirmwareFilename_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Firmware File:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.InstallationStatusText);
            this.tabPage4.Controls.Add(this.InstallationStartButton);
            this.tabPage4.Controls.Add(this.InstallationPleaseWaitText);
            this.tabPage4.Controls.Add(this.InstallationFailedText);
            this.tabPage4.Controls.Add(this.InstallationCompleteText);
            this.tabPage4.Controls.Add(this.InstallationProgress);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(728, 283);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Installation";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // InstallationStatusText
            // 
            this.InstallationStatusText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InstallationStatusText.Enabled = false;
            this.InstallationStatusText.Location = new System.Drawing.Point(8, 112);
            this.InstallationStatusText.Multiline = true;
            this.InstallationStatusText.Name = "InstallationStatusText";
            this.InstallationStatusText.ReadOnly = true;
            this.InstallationStatusText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.InstallationStatusText.Size = new System.Drawing.Size(712, 165);
            this.InstallationStatusText.TabIndex = 6;
            // 
            // InstallationStartButton
            // 
            this.InstallationStartButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InstallationStartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstallationStartButton.Location = new System.Drawing.Point(8, 6);
            this.InstallationStartButton.Name = "InstallationStartButton";
            this.InstallationStartButton.Size = new System.Drawing.Size(714, 90);
            this.InstallationStartButton.TabIndex = 5;
            this.InstallationStartButton.Text = "Start installation";
            this.InstallationStartButton.UseVisualStyleBackColor = true;
            this.InstallationStartButton.Click += new System.EventHandler(this.InstallationStartButton_Click);
            // 
            // InstallationPleaseWaitText
            // 
            this.InstallationPleaseWaitText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InstallationPleaseWaitText.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstallationPleaseWaitText.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.InstallationPleaseWaitText.Location = new System.Drawing.Point(13, 49);
            this.InstallationPleaseWaitText.Name = "InstallationPleaseWaitText";
            this.InstallationPleaseWaitText.Size = new System.Drawing.Size(707, 60);
            this.InstallationPleaseWaitText.TabIndex = 3;
            this.InstallationPleaseWaitText.Text = "Please wait....";
            this.InstallationPleaseWaitText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // InstallationFailedText
            // 
            this.InstallationFailedText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InstallationFailedText.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstallationFailedText.ForeColor = System.Drawing.Color.Red;
            this.InstallationFailedText.Location = new System.Drawing.Point(13, 49);
            this.InstallationFailedText.Name = "InstallationFailedText";
            this.InstallationFailedText.Size = new System.Drawing.Size(707, 60);
            this.InstallationFailedText.TabIndex = 2;
            this.InstallationFailedText.Text = "Firmware installation failed";
            this.InstallationFailedText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // InstallationCompleteText
            // 
            this.InstallationCompleteText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InstallationCompleteText.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstallationCompleteText.ForeColor = System.Drawing.Color.Lime;
            this.InstallationCompleteText.Location = new System.Drawing.Point(8, 46);
            this.InstallationCompleteText.Name = "InstallationCompleteText";
            this.InstallationCompleteText.Size = new System.Drawing.Size(712, 60);
            this.InstallationCompleteText.TabIndex = 1;
            this.InstallationCompleteText.Text = "Firmware installation complete";
            this.InstallationCompleteText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // InstallationProgress
            // 
            this.InstallationProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InstallationProgress.Location = new System.Drawing.Point(13, 7);
            this.InstallationProgress.MarqueeAnimationSpeed = 50;
            this.InstallationProgress.Name = "InstallationProgress";
            this.InstallationProgress.Size = new System.Drawing.Size(707, 36);
            this.InstallationProgress.TabIndex = 0;
            this.InstallationProgress.Value = 50;
            // 
            // FinishButton
            // 
            this.FinishButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FinishButton.Location = new System.Drawing.Point(600, 315);
            this.FinishButton.Name = "FinishButton";
            this.FinishButton.Size = new System.Drawing.Size(132, 23);
            this.FinishButton.TabIndex = 5;
            this.FinishButton.Text = "Finish";
            this.FinishButton.UseVisualStyleBackColor = true;
            this.FinishButton.Click += new System.EventHandler(this.FinishButton_Click);
            // 
            // InstallFirmware
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 341);
            this.Controls.Add(this.FinishButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.Wizard);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(752, 379);
            this.Name = "InstallFirmware";
            this.Text = "Install Firmware";
            this.Wizard.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TablessTabControl Wizard;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.OpenFileDialog SelectFirmwareFileDialog;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SelectFirmwareFileButton;
        private System.Windows.Forms.TextBox FirmwareFilename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label SerialText;
        private System.Windows.Forms.Label NumberText;
        private System.Windows.Forms.Label DescriptionText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ControllerConfirm;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label UserFlashText;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label BufferSizeText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label CPUText;
        private System.Windows.Forms.CheckBox HexFileOK;
        private System.Windows.Forms.Label BinarySizeText;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label FileStateText;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label InstallationFailedText;
        private System.Windows.Forms.Label InstallationCompleteText;
        private System.Windows.Forms.ProgressBar InstallationProgress;
        private System.Windows.Forms.Label InstallationPleaseWaitText;
        private System.Windows.Forms.Button InstallationStartButton;
        private System.Windows.Forms.TextBox InstallationStatusText;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label FileDate;
        private System.Windows.Forms.Label ControllerMessage;
        private System.Windows.Forms.Label HardwareRevisionText;
        private System.Windows.Forms.Label BootloaderVersionText;
        private System.Windows.Forms.Label CurrentFirmwareVersionText;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label NewHardwareRevisionText;
        private System.Windows.Forms.Label NewFirmwareVersionText;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox HexFileConfirm;
        private System.Windows.Forms.Button FinishButton;
    }
}