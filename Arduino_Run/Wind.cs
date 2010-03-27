using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ASCOM;
using ASCOM.DriverAccess;
using ASCOM.Utilities;
using ASCOM.Helper;
using ASCOM.Helper2;
using ASCOM.Interface;

namespace Arduino_Run
{
    public partial class Wind : Form
    {
        public Wind()
        {
            InitializeComponent();

            ASCOM.Arduino.Focuser f = new ASCOM.Arduino.Focuser();

            //f.ComPort = "COM4";

            f.Link = true;
        }
    }
}
