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
            this.buttonFocusIn = new System.Windows.Forms.Button();
            this.buttonFocusOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonFocusIn
            // 
            this.buttonFocusIn.Location = new System.Drawing.Point(13, 13);
            this.buttonFocusIn.Name = "buttonFocusIn";
            this.buttonFocusIn.Size = new System.Drawing.Size(75, 23);
            this.buttonFocusIn.TabIndex = 0;
            this.buttonFocusIn.Text = "<<";
            this.buttonFocusIn.UseVisualStyleBackColor = true;
            // 
            // buttonFocusOut
            // 
            this.buttonFocusOut.Location = new System.Drawing.Point(103, 13);
            this.buttonFocusOut.Name = "buttonFocusOut";
            this.buttonFocusOut.Size = new System.Drawing.Size(75, 23);
            this.buttonFocusOut.TabIndex = 0;
            this.buttonFocusOut.Text = ">>";
            this.buttonFocusOut.UseVisualStyleBackColor = true;
            // 
            // FocusControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(193, 342);
            this.Controls.Add(this.buttonFocusOut);
            this.Controls.Add(this.buttonFocusIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FocusControl";
            this.Text = "FocusControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonFocusIn;
        private System.Windows.Forms.Button buttonFocusOut;
        private ASCOM.Arduino.Focuser focuser;
    }
}