using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ASCOM.Arduino
{
    public partial class PresetEditor : Form
    {
        private Presets P;

        public PresetEditor()
        {
            InitializeComponent();
        }

        public void SetPresets(ref Presets p)
        {
            P = p;
            this.comboboxSelectPreset.DataSource = P;
            this.comboboxSelectPreset.DisplayMember = "Name";
            this.comboboxSelectPreset.ValueMember = "Position";

            this.textboxPresetName.DataBindings.Add(new Binding("Text", P, "Name"));

            this.textboxPresetPosition.DataBindings.Add(new Binding("Text", P, "Position"));
        }

        private void buttonDeletePreset_Click(object sender, EventArgs e)
        {
            P.RemovePreset((Preset)this.comboboxSelectPreset.SelectedItem);

            this.comboboxSelectPreset.DataSource = P;
        }
    }
}
