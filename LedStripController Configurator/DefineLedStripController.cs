using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FTD2XX;
namespace LedStripController_Configurator
{
    public partial class DefineLedStripController : Form
    {
        public DefineLedStripController(FTDI.FT_DEVICE_INFO_NODE Device , List<string> ValidNumbers)
        {
            InitializeComponent();

            DeviceDescription.Text = Device.Description;
            DeviceSerial.Text = Device.SerialNumber;

            ControllerNumber.Items.Clear();
            ControllerNumber.Items.AddRange(ValidNumbers.ToArray<object>());
            ControllerNumber.SelectedIndex = 0;
        
        }

        private void DefineLedStripController_Load(object sender, EventArgs e)
        {

        }

        private void Confirm_SelectedIndexChanged(object sender, EventArgs e)
        {
            OKButtonControl();
        }

        private void OKButtonControl()
        {
            if (Confirm.SelectedIndex < 1)
            {
                OK.Enabled = false;

            }
            else
            {
                if (ControllerNumber.SelectedIndex >= 0)
                {
                    OK.Enabled = true;
                }
                else
                {
                    OK.Enabled = false;
                }

            }
        }

        private void ControllerNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            OKButtonControl();
        }
    
    }
}
