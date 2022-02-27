
namespace UFO_Atack
{
    partial class Form1
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
            this.Key_detector = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Key_detector
            // 
            this.Key_detector.BackColor = System.Drawing.Color.Black;
            this.Key_detector.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Key_detector.ForeColor = System.Drawing.Color.Black;
            this.Key_detector.Location = new System.Drawing.Point(1146, 832);
            this.Key_detector.Name = "Key_detector";
            this.Key_detector.Size = new System.Drawing.Size(10, 15);
            this.Key_detector.TabIndex = 0;
            this.Key_detector.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Key_detector_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(1200, 850);
            this.Controls.Add(this.Key_detector);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(60, 0);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Key_detector;
    }
}

