namespace LedStripController_Configurator
{
    partial class DefineLedStripController
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DefineLedStripController));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Confirm = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ControllerNumber = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DeviceDescription = new System.Windows.Forms.Label();
            this.DeviceSerial = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Controller Number:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(562, 50);
            this.label2.TabIndex = 2;
            this.label2.Text = "Defining a USB device as a Direct Strip Controller can render your USB device unusabl" +
    "e if it is not a FT245R based Direct Strip Controller.\r\nUse this function only if yo" +
    "u know what you are doing!";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(12, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Attention!";
            // 
            // Confirm
            // 
            this.Confirm.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.Confirm.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Confirm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Confirm.FormattingEnabled = true;
            this.Confirm.Items.AddRange(new object[] {
            "Do not redefine this device",
            "Define the device as a LedStripController"});
            this.Confirm.Location = new System.Drawing.Point(126, 193);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(423, 21);
            this.Confirm.TabIndex = 4;
            this.Confirm.SelectedIndexChanged += new System.EventHandler(this.Confirm_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Confirm:";
            // 
            // ControllerNumber
            // 
            this.ControllerNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ControllerNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ControllerNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ControllerNumber.FormattingEnabled = true;
            this.ControllerNumber.Location = new System.Drawing.Point(126, 152);
            this.ControllerNumber.Name = "ControllerNumber";
            this.ControllerNumber.Size = new System.Drawing.Size(121, 21);
            this.ControllerNumber.TabIndex = 6;
            this.ControllerNumber.SelectedIndexChanged += new System.EventHandler(this.ControllerNumber_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Description:";
            // 
            // DeviceDescription
            // 
            this.DeviceDescription.AutoSize = true;
            this.DeviceDescription.Location = new System.Drawing.Point(123, 100);
            this.DeviceDescription.Name = "DeviceDescription";
            this.DeviceDescription.Size = new System.Drawing.Size(35, 13);
            this.DeviceDescription.TabIndex = 8;
            this.DeviceDescription.Text = "label6";
            // 
            // DeviceSerial
            // 
            this.DeviceSerial.AutoSize = true;
            this.DeviceSerial.Location = new System.Drawing.Point(123, 127);
            this.DeviceSerial.Name = "DeviceSerial";
            this.DeviceSerial.Size = new System.Drawing.Size(35, 13);
            this.DeviceSerial.TabIndex = 9;
            this.DeviceSerial.Text = "label6";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Serial";
            // 
            // OK
            // 
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Enabled = false;
            this.OK.Location = new System.Drawing.Point(126, 245);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(157, 35);
            this.OK.TabIndex = 11;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(399, 246);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(150, 35);
            this.Cancel.TabIndex = 12;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // DefineLedStripController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 293);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DeviceSerial);
            this.Controls.Add(this.DeviceDescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ControllerNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DefineLedStripController";
            this.RightToLeftLayout = true;
            this.Text = "Define as Led Strip Controller";
            this.Load += new System.EventHandler(this.DefineLedStripController_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Confirm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label DeviceDescription;
        private System.Windows.Forms.Label DeviceSerial;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        public System.Windows.Forms.ComboBox ControllerNumber;
    }
}