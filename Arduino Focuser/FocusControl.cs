using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ASCOM.Arduino
{
    public partial class FocusControl : Form
    {
        private ManualResetEvent reset = new ManualResetEvent(false);
        private string currentPositionText = "Current Position: ";
        Presets P = new Presets();

        public FocusControl(ASCOM.Arduino.Focuser f, ASCOM.Utilities.Profile p)
        {
            this.focuser = f;
            this.IProfile = p;
            InitializeComponent();
        }

        private void PollPosition(object o)
        {
            while (true)
            {
                this.buttonMoveTo.Enabled = true;
                this.buttonIMIn.Enabled = true;
                this.buttonIMOut.Enabled = true;
                this.buttonPark.Enabled = true;

                this.currentPosition.Text = this.currentPositionText + this.focuser.Position.ToString();
                while (this.focuser.IsMoving)
                {
                    this.buttonMoveTo.Enabled = false;
                    this.buttonIMIn.Enabled = false;
                    this.buttonIMOut.Enabled = false;
                    this.buttonPark.Enabled = false;


                    this.currentPosition.Text = this.currentPositionText + "Moving";
                }
            }
        }

        private void PopulatePresets()
        {
            try
            {
                P = Presets.LoadFromXml();

                this.comboSelectPreset.DataSource = P;
                this.comboSelectPreset.DisplayMember = "Name";
                this.comboSelectPreset.ValueMember = "Position";
            }
            catch
            {
            }
        }

        private void buttonSavePreset_Click(object sender, EventArgs e)
        {
            try
            {
                int position = this.focuser.Position;
                string title = this.comboSelectPreset.Text;

                P.AddPreset(new Preset(title, position));

                PopulatePresets();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonLoadPreset_Click(object sender, EventArgs e)
        {
            try
            {
                int position = Int32.Parse(this.comboSelectPreset.SelectedValue.ToString());
                bool BC;
                int BCSteps;
                bool BCDirection;

                try { BC = (Int32.Parse(IProfile.GetValue(ASCOM.Arduino.Focuser.s_csDriverID, "BC")) == 0) ? false : true; }
                catch { BC = false; }

                try { BCSteps = Int32.Parse(IProfile.GetValue(ASCOM.Arduino.Focuser.s_csDriverID, "BCSteps")); }
                catch { BCSteps = 100; }

                try { BCDirection = (Int32.Parse(IProfile.GetValue(ASCOM.Arduino.Focuser.s_csDriverID, "BCDirection")) == 0) ? false : true; }
                catch { BCDirection = false; }


                if (BC && !BCDirection && (position - this.focuser.Position < 0) && (position - BCSteps >= 0)) // If BC enabled and inward compensation and inward move and we're not going negative
                {
                    this.focuser.Move(position - BCSteps);
                    this.focuser.Move(position);
                }
                else if (BC && BCDirection && (position - this.focuser.Position > 0) && (position + BCSteps <= this.focuser.MaxStep)) // If BC enabled and outward compensation and outward move
                {
                    this.focuser.Move(position + BCSteps);
                    this.focuser.Move(position);
                }
                else
                {
                    this.focuser.Move(position);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void comboSelectPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void buttonDeletePreset_Click(object sender, EventArgs e)
        {
            string selected = this.comboSelectPreset.SelectedItem.ToString();

            if (MessageBox.Show("Are you sure you want to delete " + selected +"?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.IProfile.DeleteValue(ASCOM.Arduino.Focuser.s_csDriverID, selected, this.subkey);
                this.PopulatePresets();
            }
        }

        private void buttonSetPosition_Click(object sender, EventArgs e)
        {
            if (this.textboxCustomPosition.Text != "")
            {
                int newPosition = Int32.Parse(this.textboxCustomPosition.Text);

                if (newPosition < this.focuser.MaxStep)
                    this.focuser.SetPositionOnFocuser(newPosition);
            }
        }

        private void checkboxReverse_CheckedChanged(object sender, EventArgs e)
        {
            switch (this.checkboxReverse.Checked)
            {
                case true:
                    this.focuser.ReverseMotorDirection(true);
                    break;
                case false:
                    this.focuser.ReverseMotorDirection(false);
                    break;
            }
        }

        private void doBackgroundMove(object o)
        {
            this.focuser.Move((int)this.updownAbsolutePosition.Value);
        }

        private void buttonMoveTo_Click(object sender, EventArgs e)
        {
            if (this.updownAbsolutePosition.Value >= 0)
                ThreadPool.QueueUserWorkItem(doBackgroundMove);
        }

        private void Park(object sender, EventArgs e)
        {
            try
            {
                int park = Int32.Parse(this.IProfile.GetValue(ASCOM.Arduino.Focuser.s_csDriverID, "Park", this.subkey));
                this.focuser.Move(park);
            }
            catch
            {
                MessageBox.Show("You have not defined a Park position in presets");
            }
        }

        private void Halt(object sender, EventArgs e)
        {
            this.focuser.Halt();
        }

        void buttonSlewOut_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.focuser.Move(this.focuser.MaxStep);
        }

        void buttonSlewOut_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.focuser.Halt();
        }

        void buttonSlewIn_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.focuser.Move(0);
        }

        void buttonSlewIn_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.focuser.Halt();
        }

        private void buttonManualReset_Click(object sender, EventArgs e)
        {
            this.focuser.Reset();
        }

        private void updownBCSteps_ValueChanged(object sender, EventArgs e)
        {
            this.IProfile.WriteValue(ASCOM.Arduino.Focuser.s_csDriverID, "BCSteps", this.updownBCSteps.Value.ToString());
        }

        private void checkboxBacklashCompensation_CheckedChanged(object sender, EventArgs e)
        {
            this.IProfile.WriteValue(ASCOM.Arduino.Focuser.s_csDriverID, "BC", (this.checkboxBC.Checked == true)?"1":"0");
        }

        private void checkboxBCDirection_CheckedChanged(object sender, EventArgs e)
        {
            this.IProfile.WriteValue(ASCOM.Arduino.Focuser.s_csDriverID, "BCDirection", (this.checkboxBCDirection.Checked == true) ? "1" : "0");
        }

        private void buttonIMIn_Click(object sender, EventArgs e)
        {
            this.focuser.Move(this.focuser.Position - (int)this.updownIncrementalMove.Value);
        }

        private void buttonIMOut_Click(object sender, EventArgs e)
        {
            this.focuser.Move(this.focuser.Position + (int)this.updownIncrementalMove.Value);
        }
    }
}
