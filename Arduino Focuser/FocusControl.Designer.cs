namespace ASCOM.Arduino
{
    partial class FocusControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboSelectPreset = new System.Windows.Forms.ComboBox();
            this.tooltipLoadPreset = new System.Windows.Forms.ToolTip(this.components);
            this.buttonLoadPreset = new System.Windows.Forms.Button();
            this.tooltipSavePreset = new System.Windows.Forms.ToolTip(this.components);
            this.groupboxSelectedPreset = new System.Windows.Forms.GroupBox();
            this.buttonDeletePreset = new System.Windows.Forms.Button();
            this.presetPosition = new System.Windows.Forms.Label();
            this.labelPresetPosition = new System.Windows.Forms.Label();
            this.buttonSavePreset = new System.Windows.Forms.Button();
            this.groupboxSelectedPreset.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboSelectPreset
            // 
            this.comboSelectPreset.FormattingEnabled = true;
            this.comboSelectPreset.Location = new System.Drawing.Point(46, 13);
            this.comboSelectPreset.Name = "comboSelectPreset";
            this.comboSelectPreset.Size = new System.Drawing.Size(101, 21);
            this.comboSelectPreset.TabIndex = 0;
            this.comboSelectPreset.SelectedIndexChanged += new System.EventHandler(this.comboSelectPreset_SelectedIndexChanged);
            // 
            // buttonLoadPreset
            // 
            this.buttonLoadPreset.Image = global::ASCOM.Arduino.Properties.Resources.open;
            this.buttonLoadPreset.Location = new System.Drawing.Point(153, 8);
            this.buttonLoadPreset.Name = "buttonLoadPreset";
            this.buttonLoadPreset.Size = new System.Drawing.Size(28, 28);
            this.buttonLoadPreset.TabIndex = 1;
            this.tooltipLoadPreset.SetToolTip(this.buttonLoadPreset, "Load preset");
            this.buttonLoadPreset.UseVisualStyleBackColor = true;
            this.buttonLoadPreset.Click += new System.EventHandler(this.buttonLoadPreset_Click);
            // 
            // groupboxSelectedPreset
            // 
            this.groupboxSelectedPreset.Controls.Add(this.buttonDeletePreset);
            this.groupboxSelectedPreset.Controls.Add(this.presetPosition);
            this.groupboxSelectedPreset.Controls.Add(this.labelPresetPosition);
            this.groupboxSelectedPreset.Location = new System.Drawing.Point(12, 52);
            this.groupboxSelectedPreset.Name = "groupboxSelectedPreset";
            this.groupboxSelectedPreset.Size = new System.Drawing.Size(169, 40);
            this.groupboxSelectedPreset.TabIndex = 5;
            this.groupboxSelectedPreset.TabStop = false;
            this.groupboxSelectedPreset.Text = "(None)";
            // 
            // buttonDeletePreset
            // 
            this.buttonDeletePreset.Image = global::ASCOM.Arduino.Properties.Resources.delete;
            this.buttonDeletePreset.Location = new System.Drawing.Point(135, 9);
            this.buttonDeletePreset.Name = "buttonDeletePreset";
            this.buttonDeletePreset.Size = new System.Drawing.Size(28, 28);
            this.buttonDeletePreset.TabIndex = 2;
            this.buttonDeletePreset.UseVisualStyleBackColor = true;
            this.buttonDeletePreset.Click += new System.EventHandler(this.buttonDeletePreset_Click);
            // 
            // presetPosition
            // 
            this.presetPosition.AutoSize = true;
            this.presetPosition.Location = new System.Drawing.Point(94, 20);
            this.presetPosition.Name = "presetPosition";
            this.presetPosition.Size = new System.Drawing.Size(0, 13);
            this.presetPosition.TabIndex = 1;
            // 
            // labelPresetPosition
            // 
            this.labelPresetPosition.AutoSize = true;
            this.labelPresetPosition.Location = new System.Drawing.Point(7, 19);
            this.labelPresetPosition.Name = "labelPresetPosition";
            this.labelPresetPosition.Size = new System.Drawing.Size(80, 13);
            this.labelPresetPosition.TabIndex = 0;
            this.labelPresetPosition.Text = "Preset Position:";
            // 
            // buttonSavePreset
            // 
            this.buttonSavePreset.Image = global::ASCOM.Arduino.Properties.Resources.save;
            this.buttonSavePreset.Location = new System.Drawing.Point(12, 8);
            this.buttonSavePreset.Name = "buttonSavePreset";
            this.buttonSavePreset.Size = new System.Drawing.Size(28, 28);
            this.buttonSavePreset.TabIndex = 1;
            this.buttonSavePreset.UseVisualStyleBackColor = true;
            this.buttonSavePreset.Click += new System.EventHandler(this.buttonSavePreset_Click);
            // 
            // FocusControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(193, 104);
            this.Controls.Add(this.groupboxSelectedPreset);
            this.Controls.Add(this.buttonSavePreset);
            this.Controls.Add(this.buttonLoadPreset);
            this.Controls.Add(this.comboSelectPreset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FocusControl";
            this.Text = "Focuser Toolbox";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FocusControl_FormClosing);
            this.groupboxSelectedPreset.ResumeLayout(false);
            this.groupboxSelectedPreset.PerformLayout();
            this.ResumeLayout(false);

        }

        void FocusControl_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        #endregion

        private ASCOM.Arduino.Focuser focuser;
        private ASCOM.Utilities.Profile profile;
        private string subkey = "Presets";
        private System.Windows.Forms.ComboBox comboSelectPreset;
        private System.Windows.Forms.Button buttonLoadPreset;
        private System.Windows.Forms.Button buttonSavePreset;
        private System.Windows.Forms.ToolTip tooltipLoadPreset;
        private System.Windows.Forms.ToolTip tooltipSavePreset;
        private System.Windows.Forms.GroupBox groupboxSelectedPreset;
        private System.Windows.Forms.Label presetPosition;
        private System.Windows.Forms.Label labelPresetPosition;
        private System.Windows.Forms.Button buttonDeletePreset;
    }
}