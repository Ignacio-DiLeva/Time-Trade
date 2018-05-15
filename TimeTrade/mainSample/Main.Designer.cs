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
            this.temporal_min = new System.Windows.Forms.Label();
            this.temporal_close = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.showLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RestartPB)).BeginInit();
            this.SuspendLayout();
            // 
            // showLogo
            // 
            this.showLogo.BackColor = System.Drawing.Color.Blue;
            this.showLogo.Image = global::mainSample.Properties.Resources.Time_Trade_Logo;
            this.showLogo.Location = new System.Drawing.Point(0, 0);
            this.showLogo.Name = "showLogo";
            this.showLogo.Size = new System.Drawing.Size(150, 70);
            this.showLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.showLogo.TabIndex = 0;
            this.showLogo.TabStop = false;
            this.showLogo.Click += new System.EventHandler(this.ShowForm);
            // 
            // RestartPB
            // 
            this.RestartPB.BackColor = System.Drawing.Color.Red;
            this.RestartPB.Location = new System.Drawing.Point(1050, 0);
            this.RestartPB.Name = "RestartPB";
            this.RestartPB.Size = new System.Drawing.Size(150, 70);
            this.RestartPB.TabIndex = 1;
            this.RestartPB.TabStop = false;
            this.RestartPB.Tag = "DeleteSaveData";
            this.RestartPB.Click += new System.EventHandler(this.ShowForm);
            // 
            // temporal_min
            // 
            this.temporal_min.BackColor = System.Drawing.Color.Red;
            this.temporal_min.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.temporal_min.Location = new System.Drawing.Point(1050, 0);
            this.temporal_min.Name = "temporal_min";
            this.temporal_min.Size = new System.Drawing.Size(79, 70);
            this.temporal_min.TabIndex = 2;
            this.temporal_min.Text = "-";
            this.temporal_min.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.temporal_min.Click += new System.EventHandler(this.TemporalMin);
            // 
            // temporal_close
            // 
            this.temporal_close.BackColor = System.Drawing.Color.Red;
            this.temporal_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.temporal_close.Location = new System.Drawing.Point(1121, 0);
            this.temporal_close.Name = "temporal_close";
            this.temporal_close.Size = new System.Drawing.Size(79, 70);
            this.temporal_close.TabIndex = 3;
            this.temporal_close.Text = "X";
            this.temporal_close.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.temporal_close.Click += new System.EventHandler(this.TemporalClose);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 661);
            this.Controls.Add(this.temporal_close);
            this.Controls.Add(this.temporal_min);
            this.Controls.Add(this.RestartPB);
            this.Controls.Add(this.showLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(500, 200);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Time Trade";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.Load += new System.EventHandler(this.OnLoad);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AllowMove);
            ((System.ComponentModel.ISupportInitialize)(this.showLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RestartPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox RestartPB;
        public System.Windows.Forms.PictureBox showLogo;
        private System.Windows.Forms.Label temporal_min;
        private System.Windows.Forms.Label temporal_close;
    }
}

