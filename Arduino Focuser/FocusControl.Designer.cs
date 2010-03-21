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
            this.comboSelectPreset = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSavePreset = new System.Windows.Forms.Button();
            this.buttonLoadPreset = new System.Windows.Forms.Button();
            this.groupboxPresetPosition = new System.Windows.Forms.GroupBox();
            this.presetPosition = new System.Windows.Forms.Label();
            this.groupboxCurrentPosition = new System.Windows.Forms.GroupBox();
            this.currentPosition = new System.Windows.Forms.Label();
            this.groupboxOptions = new System.Windows.Forms.GroupBox();
            this.buttonSetPosition = new System.Windows.Forms.Button();
            this.textboxCustomPosition = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupboxPresetPosition.SuspendLayout();
            this.groupboxCurrentPosition.SuspendLayout();
            this.groupboxOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboSelectPreset
            // 
            this.comboSelectPreset.FormattingEnabled = true;
            this.comboSelectPreset.Location = new System.Drawing.Point(6, 16);
            this.comboSelectPreset.Name = "comboSelectPreset";
            this.comboSelectPreset.Size = new System.Drawing.Size(101, 21);
            this.comboSelectPreset.TabIndex = 0;
            this.comboSelectPreset.SelectedIndexChanged += new System.EventHandler(this.comboSelectPreset_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSavePreset);
            this.groupBox1.Controls.Add(this.buttonLoadPreset);
            this.groupBox1.Controls.Add(this.comboSelectPreset);
            this.groupBox1.Location = new System.Drawing.Point(9, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 45);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Presets";
            // 
            // buttonSavePreset
            // 
            this.buttonSavePreset.Location = new System.Drawing.Point(170, 15);
            this.buttonSavePreset.Name = "buttonSavePreset";
            this.buttonSavePreset.Size = new System.Drawing.Size(51, 23);
            this.buttonSavePreset.TabIndex = 3;
            this.buttonSavePreset.Text = "Save";
            this.buttonSavePreset.UseVisualStyleBackColor = true;
            this.buttonSavePreset.Click += new System.EventHandler(this.buttonSavePreset_Click);
            // 
            // buttonLoadPreset
            // 
            this.buttonLoadPreset.Location = new System.Drawing.Point(113, 15);
            this.buttonLoadPreset.Name = "buttonLoadPreset";
            this.buttonLoadPreset.Size = new System.Drawing.Size(51, 23);
            this.buttonLoadPreset.TabIndex = 1;
            this.buttonLoadPreset.Text = "Load";
            this.buttonLoadPreset.UseVisualStyleBackColor = true;
            this.buttonLoadPreset.Click += new System.EventHandler(this.buttonLoadPreset_Click);
            // 
            // groupboxPresetPosition
            // 
            this.groupboxPresetPosition.Controls.Add(this.presetPosition);
            this.groupboxPresetPosition.Location = new System.Drawing.Point(126, 59);
            this.groupboxPresetPosition.Name = "groupboxPresetPosition";
            this.groupboxPresetPosition.Size = new System.Drawing.Size(110, 45);
            this.groupboxPresetPosition.TabIndex = 2;
            this.groupboxPresetPosition.TabStop = false;
            this.groupboxPresetPosition.Text = "Preset Position";
            // 
            // presetPosition
            // 
            this.presetPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.presetPosition.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.presetPosition.Location = new System.Drawing.Point(6, 18);
            this.presetPosition.Name = "presetPosition";
            this.presetPosition.Size = new System.Drawing.Size(98, 18);
            this.presetPosition.TabIndex = 0;
            this.presetPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupboxCurrentPosition
            // 
            this.groupboxCurrentPosition.Controls.Add(this.currentPosition);
            this.groupboxCurrentPosition.Location = new System.Drawing.Point(9, 59);
            this.groupboxCurrentPosition.Name = "groupboxCurrentPosition";
            this.groupboxCurrentPosition.Size = new System.Drawing.Size(110, 45);
            this.groupboxCurrentPosition.TabIndex = 3;
            this.groupboxCurrentPosition.TabStop = false;
            this.groupboxCurrentPosition.Text = "Current Position";
            // 
            // currentPosition
            // 
            this.currentPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.currentPosition.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPosition.Location = new System.Drawing.Point(6, 18);
            this.currentPosition.Name = "currentPosition";
            this.currentPosition.Size = new System.Drawing.Size(98, 18);
            this.currentPosition.TabIndex = 0;
            this.currentPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupboxOptions
            // 
            this.groupboxOptions.Controls.Add(this.buttonSetPosition);
            this.groupboxOptions.Controls.Add(this.textboxCustomPosition);
            this.groupboxOptions.Location = new System.Drawing.Point(9, 110);
            this.groupboxOptions.Name = "groupboxOptions";
            this.groupboxOptions.Size = new System.Drawing.Size(227, 48);
            this.groupboxOptions.TabIndex = 4;
            this.groupboxOptions.TabStop = false;
            this.groupboxOptions.Text = "Options";
            // 
            // buttonSetPosition
            // 
            this.buttonSetPosition.Location = new System.Drawing.Point(75, 18);
            this.buttonSetPosition.Name = "buttonSetPosition";
            this.buttonSetPosition.Size = new System.Drawing.Size(146, 23);
            this.buttonSetPosition.TabIndex = 1;
            this.buttonSetPosition.Text = "Set Custom Position";
            this.buttonSetPosition.UseVisualStyleBackColor = true;
            this.buttonSetPosition.Click += new System.EventHandler(this.buttonSetPosition_Click);
            // 
            // textboxCustomPosition
            // 
            this.textboxCustomPosition.Location = new System.Drawing.Point(9, 20);
            this.textboxCustomPosition.Name = "textboxCustomPosition";
            this.textboxCustomPosition.Size = new System.Drawing.Size(60, 20);
            this.textboxCustomPosition.TabIndex = 0;
            // 
            // FocusControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 165);
            this.Controls.Add(this.groupboxOptions);
            this.Controls.Add(this.groupboxCurrentPosition);
            this.Controls.Add(this.groupboxPresetPosition);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FocusControl";
            this.Text = "Focuser Toolbox";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FocusControl_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupboxPresetPosition.ResumeLayout(false);
            this.groupboxCurrentPosition.ResumeLayout(false);
            this.groupboxOptions.ResumeLayout(false);
            this.groupboxOptions.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonLoadPreset;
        private System.Windows.Forms.GroupBox groupboxPresetPosition;
        private System.Windows.Forms.Button buttonSavePreset;
        private System.Windows.Forms.Label presetPosition;
        private System.Windows.Forms.GroupBox groupboxCurrentPosition;
        private System.Windows.Forms.Label currentPosition;
        private System.Windows.Forms.GroupBox groupboxOptions;
        private System.Windows.Forms.Button buttonSetPosition;
        private System.Windows.Forms.TextBox textboxCustomPosition;
    }
}