using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ASCOM.Arduino
{
    public partial class FocuserConsole : Form
    {
        public FocuserConsole()
        {
            InitializeComponent();
        }

        public void addLine(object info)
        {
            this.consoleText.Text += ">> " + info.ToString() + "\r\n";
            this.consoleText.SelectionStart = 99999;
            this.consoleText.ScrollToCaret();
        }
    }
}
