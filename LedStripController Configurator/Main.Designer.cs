﻿namespace LedStripController_Configurator
{
    partial class Main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.StripControllerList = new System.Windows.Forms.DataGridView();
            this.StripControllerDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StripControllerNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StripControllerSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OtherDeviceList = new System.Windows.Forms.DataGridView();
            this.OtherDeviceDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OtherDeviceSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DefineAsLedStripController = new System.Windows.Forms.Button();
            this.ChangeControllerNumber = new System.Windows.Forms.Button();
            this.RefreshLists = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.StripControllerList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OtherDeviceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StripControllerList
            // 
            this.StripControllerList.AllowUserToAddRows = false;
            this.StripControllerList.AllowUserToDeleteRows = false;
            this.StripControllerList.AllowUserToOrderColumns = true;
            this.StripControllerList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StripControllerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StripControllerList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StripControllerDescription,
            this.StripControllerNumber,
            this.StripControllerSerial});
            this.StripControllerList.Location = new System.Drawing.Point(3, 3);
            this.StripControllerList.MultiSelect = false;
            this.StripControllerList.Name = "StripControllerList";
            this.StripControllerList.ReadOnly = true;
            this.StripControllerList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.StripControllerList.Size = new System.Drawing.Size(528, 198);
            this.StripControllerList.TabIndex = 0;
            this.StripControllerList.SelectionChanged += new System.EventHandler(this.StripControllerList_SelectionChanged);
            // 
            // StripControllerDescription
            // 
            this.StripControllerDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StripControllerDescription.HeaderText = "Description";
            this.StripControllerDescription.Name = "StripControllerDescription";
            this.StripControllerDescription.ReadOnly = true;
            this.StripControllerDescription.Width = 85;
            // 
            // StripControllerNumber
            // 
            this.StripControllerNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.StripControllerNumber.DefaultCellStyle = dataGridViewCellStyle1;
            this.StripControllerNumber.HeaderText = "Number";
            this.StripControllerNumber.Name = "StripControllerNumber";
            this.StripControllerNumber.ReadOnly = true;
            this.StripControllerNumber.Width = 69;
            // 
            // StripControllerSerial
            // 
            this.StripControllerSerial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StripControllerSerial.HeaderText = "Serial";
            this.StripControllerSerial.Name = "StripControllerSerial";
            this.StripControllerSerial.ReadOnly = true;
            this.StripControllerSerial.Width = 58;
            // 
            // OtherDeviceList
            // 
            this.OtherDeviceList.AllowUserToAddRows = false;
            this.OtherDeviceList.AllowUserToDeleteRows = false;
            this.OtherDeviceList.AllowUserToOrderColumns = true;
            this.OtherDeviceList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OtherDeviceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OtherDeviceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OtherDeviceDescription,
            this.OtherDeviceSerial});
            this.OtherDeviceList.Location = new System.Drawing.Point(3, 3);
            this.OtherDeviceList.MultiSelect = false;
            this.OtherDeviceList.Name = "OtherDeviceList";
            this.OtherDeviceList.ReadOnly = true;
            this.OtherDeviceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OtherDeviceList.Size = new System.Drawing.Size(528, 156);
            this.OtherDeviceList.TabIndex = 1;
            this.OtherDeviceList.SelectionChanged += new System.EventHandler(this.OtherDeviceList_SelectionChanged);
            // 
            // OtherDeviceDescription
            // 
            this.OtherDeviceDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.OtherDeviceDescription.HeaderText = "Description";
            this.OtherDeviceDescription.Name = "OtherDeviceDescription";
            this.OtherDeviceDescription.ReadOnly = true;
            this.OtherDeviceDescription.Width = 85;
            // 
            // OtherDeviceSerial
            // 
            this.OtherDeviceSerial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.OtherDeviceSerial.HeaderText = "Serial";
            this.OtherDeviceSerial.Name = "OtherDeviceSerial";
            this.OtherDeviceSerial.ReadOnly = true;
            this.OtherDeviceSerial.Width = 58;
            // 
            // DefineAsLedStripController
            // 
            this.DefineAsLedStripController.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DefineAsLedStripController.Location = new System.Drawing.Point(375, 165);
            this.DefineAsLedStripController.Name = "DefineAsLedStripController";
            this.DefineAsLedStripController.Size = new System.Drawing.Size(156, 23);
            this.DefineAsLedStripController.TabIndex = 2;
            this.DefineAsLedStripController.Text = "Define as Led Strip Controller";
            this.DefineAsLedStripController.UseVisualStyleBackColor = true;
            this.DefineAsLedStripController.Click += new System.EventHandler(this.DefineAsLedStripController_Click);
            // 
            // ChangeControllerNumber
            // 
            this.ChangeControllerNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangeControllerNumber.Location = new System.Drawing.Point(375, 207);
            this.ChangeControllerNumber.Name = "ChangeControllerNumber";
            this.ChangeControllerNumber.Size = new System.Drawing.Size(156, 23);
            this.ChangeControllerNumber.TabIndex = 3;
            this.ChangeControllerNumber.Text = "Change Controller Number";
            this.ChangeControllerNumber.UseVisualStyleBackColor = true;
            this.ChangeControllerNumber.Click += new System.EventHandler(this.ChangeControllerNumber_Click);
            // 
            // RefreshLists
            // 
            this.RefreshLists.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshLists.Location = new System.Drawing.Point(375, 203);
            this.RefreshLists.Name = "RefreshLists";
            this.RefreshLists.Size = new System.Drawing.Size(156, 23);
            this.RefreshLists.TabIndex = 4;
            this.RefreshLists.Text = "Refresh Lists";
            this.RefreshLists.UseVisualStyleBackColor = true;
            this.RefreshLists.Click += new System.EventHandler(this.RefreshLists_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.StripControllerList);
            this.splitContainer1.Panel1.Controls.Add(this.ChangeControllerNumber);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.OtherDeviceList);
            this.splitContainer1.Panel2.Controls.Add(this.RefreshLists);
            this.splitContainer1.Panel2.Controls.Add(this.DefineAsLedStripController);
            this.splitContainer1.Size = new System.Drawing.Size(534, 466);
            this.splitContainer1.SplitterDistance = 233;
            this.splitContainer1.TabIndex = 5;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 466);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "LedStripController Configurator";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StripControllerList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OtherDeviceList)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView StripControllerList;
        private System.Windows.Forms.DataGridView OtherDeviceList;
        private System.Windows.Forms.DataGridViewTextBoxColumn StripControllerDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn StripControllerNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn StripControllerSerial;
        private System.Windows.Forms.DataGridViewTextBoxColumn OtherDeviceDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn OtherDeviceSerial;
        private System.Windows.Forms.Button DefineAsLedStripController;
        private System.Windows.Forms.Button ChangeControllerNumber;
        private System.Windows.Forms.Button RefreshLists;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

