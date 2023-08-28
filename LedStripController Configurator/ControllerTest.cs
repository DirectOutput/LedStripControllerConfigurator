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
    public partial class ControllerTest : Form
    {
        public ControllerTest(FTDI.FT_DEVICE_INFO_NODE CurrentStripController)
        {
            InitializeComponent();
            this.CurrentStripController = CurrentStripController;
        }

        FTDI.FT_DEVICE_INFO_NODE CurrentStripController = null;


       
    }
}
