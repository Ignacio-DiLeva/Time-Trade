namespace mainSample
{
    partial class PortfolioAccount
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
            this.portfolioPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // portfolioPanel
            // 
            this.portfolioPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(93)))), ((int)(((byte)(117)))));
            this.portfolioPanel.Location = new System.Drawing.Point(0, 0);
            this.portfolioPanel.Name = "portfolioPanel";
            this.portfolioPanel.Size = new System.Drawing.Size(865, 641);
            this.portfolioPanel.TabIndex = 0;
            // 
            // PortfolioAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(884, 410);
            this.Controls.Add(this.portfolioPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PortfolioAccount";
            this.Text = "portfolioAccount";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel portfolioPanel;
    }
}