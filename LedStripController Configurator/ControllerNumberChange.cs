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
    public partial class ControllerNumberChange : Form
    {
        public ControllerNumberChange(FTDI.FT_DEVICE_INFO_NODE Device, uint CurrentNumber, List<string> ValidNumbers)
        {
            InitializeComponent();

            DeviceDescription.Text = Device.Description;
            DeviceSerial.Text = Device.SerialNumber;
            ControllerNumberCurrent.Text = CurrentNumber.ToString();

            ControllerNumber.Items.Clear();
            ControllerNumber.Items.AddRange(ValidNumbers.ToArray<object>());

            int I = ValidNumbers.FindIndex(N => N.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0] == CurrentNumber.ToString());
            if (I >= 0 && I < ControllerNumber.Items.Count)
            {
                ControllerNumber.SelectedIndex = I;
            }
        }

        private void ControllerNumberChange_Load(object sender, EventArgs e)
        {

        }

  

        private void OKButtonControl()
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

        private void ControllerNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            OKButtonControl();
        }

    }
}
