using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ASCOM.Arduino
{
    public partial class FocusControl : Form
    {
        public FocusControl(ASCOM.Arduino.Focuser f)
        {
            this.focuser = f;
            InitializeComponent();
        }
    }
}
