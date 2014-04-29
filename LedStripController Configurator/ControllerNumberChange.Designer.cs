namespace LedStripController_Configurator
{
    partial class ControllerNumberChange
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControllerNumberChange));
            this.label1 = new System.Windows.Forms.Label();
            this.ControllerNumber = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DeviceDescription = new System.Windows.Forms.Label();
            this.DeviceSerial = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ControllerNumberCurrent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "New Number:";
            // 
            // ControllerNumber
            // 
            this.ControllerNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ControllerNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ControllerNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ControllerNumber.FormattingEnabled = true;
            this.ControllerNumber.Location = new System.Drawing.Point(126, 125);
            this.ControllerNumber.Name = "ControllerNumber";
            this.ControllerNumber.Size = new System.Drawing.Size(121, 21);
            this.ControllerNumber.TabIndex = 6;
            this.ControllerNumber.SelectedIndexChanged += new System.EventHandler(this.ControllerNumber_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Description:";
            // 
            // DeviceDescription
            // 
            this.DeviceDescription.AutoSize = true;
            this.DeviceDescription.Location = new System.Drawing.Point(123, 31);
            this.DeviceDescription.Name = "DeviceDescription";
            this.DeviceDescription.Size = new System.Drawing.Size(35, 13);
            this.DeviceDescription.TabIndex = 8;
            this.DeviceDescription.Text = "label6";
            // 
            // DeviceSerial
            // 
            this.DeviceSerial.AutoSize = true;
            this.DeviceSerial.Location = new System.Drawing.Point(123, 58);
            this.DeviceSerial.Name = "DeviceSerial";
            this.DeviceSerial.Size = new System.Drawing.Size(35, 13);
            this.DeviceSerial.TabIndex = 9;
            this.DeviceSerial.Text = "label6";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Serial";
            // 
            // OK
            // 
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Enabled = false;
            this.OK.Location = new System.Drawing.Point(126, 169);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(157, 35);
            this.OK.TabIndex = 11;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(399, 170);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(150, 35);
            this.Cancel.TabIndex = 12;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Current Number:";
            // 
            // ControllerNumberCurrent
            // 
            this.ControllerNumberCurrent.AutoSize = true;
            this.ControllerNumberCurrent.Location = new System.Drawing.Point(123, 85);
            this.ControllerNumberCurrent.Name = "ControllerNumberCurrent";
            this.ControllerNumberCurrent.Size = new System.Drawing.Size(35, 13);
            this.ControllerNumberCurrent.TabIndex = 13;
            this.ControllerNumberCurrent.Text = "label6";
            // 
            // ControllerNumberChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 217);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ControllerNumberCurrent);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DeviceSerial);
            this.Controls.Add(this.DeviceDescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ControllerNumber);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ControllerNumberChange";
            this.RightToLeftLayout = true;
            this.Text = "Change controller number";
            this.Load += new System.EventHandler(this.ControllerNumberChange_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label DeviceDescription;
        private System.Windows.Forms.Label DeviceSerial;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        public System.Windows.Forms.ComboBox ControllerNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ControllerNumberCurrent;
    }
}