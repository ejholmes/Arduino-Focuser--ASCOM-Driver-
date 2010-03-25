namespace ASCOM.Arduino
{
    partial class PresetEditor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboboxSelectPreset = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textboxPresetName = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textboxPresetPosition = new System.Windows.Forms.TextBox();
            this.buttonDeletePreset = new System.Windows.Forms.Button();
            this.presetsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.presetsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboboxSelectPreset);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select";
            // 
            // comboboxSelectPreset
            // 
            this.comboboxSelectPreset.FormattingEnabled = true;
            this.comboboxSelectPreset.Location = new System.Drawing.Point(6, 19);
            this.comboboxSelectPreset.Name = "comboboxSelectPreset";
            this.comboboxSelectPreset.Size = new System.Drawing.Size(208, 21);
            this.comboboxSelectPreset.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textboxPresetName);
            this.groupBox2.Location = new System.Drawing.Point(12, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 50);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Name";
            // 
            // textboxPresetName
            // 
            this.textboxPresetName.Location = new System.Drawing.Point(6, 19);
            this.textboxPresetName.Name = "textboxPresetName";
            this.textboxPresetName.Size = new System.Drawing.Size(208, 20);
            this.textboxPresetName.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textboxPresetPosition);
            this.groupBox3.Location = new System.Drawing.Point(12, 130);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(220, 50);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Position";
            // 
            // textboxPresetPosition
            // 
            this.textboxPresetPosition.Location = new System.Drawing.Point(6, 19);
            this.textboxPresetPosition.Name = "textboxPresetPosition";
            this.textboxPresetPosition.Size = new System.Drawing.Size(208, 20);
            this.textboxPresetPosition.TabIndex = 0;
            // 
            // buttonDeletePreset
            // 
            this.buttonDeletePreset.Location = new System.Drawing.Point(12, 186);
            this.buttonDeletePreset.Name = "buttonDeletePreset";
            this.buttonDeletePreset.Size = new System.Drawing.Size(75, 23);
            this.buttonDeletePreset.TabIndex = 2;
            this.buttonDeletePreset.Text = "Delete";
            this.buttonDeletePreset.UseVisualStyleBackColor = true;
            this.buttonDeletePreset.Click += new System.EventHandler(this.buttonDeletePreset_Click);
            // 
            // presetsBindingSource
            // 
            this.presetsBindingSource.DataSource = typeof(ASCOM.Arduino.Presets);
            // 
            // PresetEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 220);
            this.Controls.Add(this.buttonDeletePreset);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PresetEditor";
            this.Text = "Preset Editor";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.presetsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource presetsBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboboxSelectPreset;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textboxPresetName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textboxPresetPosition;
        private System.Windows.Forms.Button buttonDeletePreset;
    }
}