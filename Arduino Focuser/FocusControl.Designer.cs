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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.presetPosition = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.currentPosition = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.presetPosition);
            this.groupBox2.Location = new System.Drawing.Point(126, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(110, 45);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preset Position";
            // 
            // presetPosition
            // 
            this.presetPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.presetPosition.AutoSize = true;
            this.presetPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.presetPosition.Location = new System.Drawing.Point(39, 16);
            this.presetPosition.Name = "presetPosition";
            this.presetPosition.Size = new System.Drawing.Size(0, 18);
            this.presetPosition.TabIndex = 0;
            this.presetPosition.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.currentPosition);
            this.groupBox3.Location = new System.Drawing.Point(9, 59);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(110, 45);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Current Position";
            // 
            // currentPosition
            // 
            this.currentPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.currentPosition.AutoSize = true;
            this.currentPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPosition.Location = new System.Drawing.Point(37, 16);
            this.currentPosition.Name = "currentPosition";
            this.currentPosition.Size = new System.Drawing.Size(0, 18);
            this.currentPosition.TabIndex = 0;
            this.currentPosition.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FocusControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 112);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FocusControl";
            this.Text = "Focuser Toolbox";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FocusControl_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonSavePreset;
        private System.Windows.Forms.Label presetPosition;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label currentPosition;
    }
}