namespace mainSample
{
    partial class Main
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
            this.showLogo = new System.Windows.Forms.PictureBox();
            this.RestartPB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.showLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RestartPB)).BeginInit();
            this.SuspendLayout();
            // 
            // showLogo
            // 
            this.showLogo.BackColor = System.Drawing.Color.Blue;
            this.showLogo.Image = global::mainSample.Properties.Resources.Time_Trade_Logo;
            this.showLogo.Location = new System.Drawing.Point(0, 25);
            this.showLogo.Name = "showLogo";
            this.showLogo.Size = new System.Drawing.Size(150, 100);
            this.showLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.showLogo.TabIndex = 0;
            this.showLogo.TabStop = false;
            this.showLogo.Click += new System.EventHandler(this.ShowForm);
            // 
            // RestartPB
            // 
            this.RestartPB.BackColor = System.Drawing.Color.Red;
            this.RestartPB.Location = new System.Drawing.Point(1050, 25);
            this.RestartPB.Name = "RestartPB";
            this.RestartPB.Size = new System.Drawing.Size(150, 100);
            this.RestartPB.TabIndex = 1;
            this.RestartPB.TabStop = false;
            this.RestartPB.Tag = "DeleteSaveData";
            this.RestartPB.Click += new System.EventHandler(this.ShowForm);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 125);
            this.Controls.Add(this.RestartPB);
            this.Controls.Add(this.showLogo);
            this.Location = new System.Drawing.Point(500, 200);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Time Trade";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.showLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RestartPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox RestartPB;
        public System.Windows.Forms.PictureBox showLogo;
    }
}

