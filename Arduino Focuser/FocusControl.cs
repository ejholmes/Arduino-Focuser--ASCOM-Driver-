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
        public FocusControl(ASCOM.Arduino.Focuser f, ASCOM.Utilities.Profile p)
        {
            this.focuser = f;
            this.profile = p;
            InitializeComponent();

            this.populatePresets();
            this.updateCurrentPosition();
        }

        public void updateCurrentPosition(string text)
        {
            this.currentPosition.Text = text + "\r";
        }

        public void updateCurrentPosition()
        {
            this.currentPosition.Text = this.focuser.Position.ToString() + "\r";
        }

        private void populatePresets()
        {
            try
            {
                this.comboSelectPreset.Items.Clear();
                System.Collections.ArrayList list = this.profile.Values(ASCOM.Arduino.Focuser.s_csDriverID, this.subkey);

                foreach (ASCOM.Utilities.KeyValuePair kv in list)
                {
                    this.comboSelectPreset.Items.Add(kv.Key);
                }
            }
            catch
            {
            }
        }

        private void buttonSavePreset_Click(object sender, EventArgs e)
        {
            int position = this.focuser.Position;
            string title = this.comboSelectPreset.Text;

            if (title != "")
            {
                this.profile.WriteValue(ASCOM.Arduino.Focuser.s_csDriverID, title, position.ToString(), this.subkey);

                this.populatePresets();
                this.openPreset(title);
            }
        }

        private void openPreset(string key)
        {
            this.presetPosition.Text = this.profile.GetValue(ASCOM.Arduino.Focuser.s_csDriverID, key, this.subkey);
        }

        private void buttonLoadPreset_Click(object sender, EventArgs e)
        {
            if (this.comboSelectPreset.SelectedItem != null)
            {
                string selected = this.comboSelectPreset.SelectedItem.ToString();
                int position = Int32.Parse(this.profile.GetValue(ASCOM.Arduino.Focuser.s_csDriverID, selected, this.subkey));
                this.focuser.Move(position);
            }
        }

        private void comboSelectPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.openPreset(this.comboSelectPreset.SelectedItem.ToString());
        }

        private void buttonDeletePreset_Click(object sender, EventArgs e)
        {
            string selected = this.comboSelectPreset.SelectedItem.ToString();

            if (MessageBox.Show("Are you sure you want to delete " + selected +"?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.profile.DeleteValue(ASCOM.Arduino.Focuser.s_csDriverID, selected, this.subkey);
                this.populatePresets();
            }
        }
    }
}
