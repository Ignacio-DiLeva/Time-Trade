namespace mainSample
{
    partial class Stock
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
            this.companyData = new MaterialSkin.Controls.MaterialLabel();
            this.Searcher = new System.Windows.Forms.ComboBox();
            this.stockInfoDisplayer = new System.Windows.Forms.Label();
            this.companyCompleteName = new System.Windows.Forms.Label();
            this.DisplayedLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayedLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // companyData
            // 
            this.companyData.BackColor = System.Drawing.Color.Transparent;
            this.companyData.Depth = 0;
            this.companyData.Font = new System.Drawing.Font("Roboto", 11F);
            this.companyData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.companyData.Location = new System.Drawing.Point(277, 21);
            this.companyData.MouseState = MaterialSkin.MouseState.HOVER;
            this.companyData.Name = "companyData";
            this.companyData.Size = new System.Drawing.Size(341, 39);
            this.companyData.TabIndex = 7;
            this.companyData.Tag = "0";
            this.companyData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.companyData.DoubleClick += new System.EventHandler(this.RedirectToTrade);
            // 
            // Searcher
            // 
            this.Searcher.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Searcher.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Searcher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Searcher.FormattingEnabled = true;
            this.Searcher.Location = new System.Drawing.Point(25, 33);
            this.Searcher.Name = "Searcher";
            this.Searcher.Size = new System.Drawing.Size(236, 21);
            this.Searcher.TabIndex = 8;
            this.Searcher.Text = "AAPL (Apple, Inc.)";
            this.Searcher.SelectedIndexChanged += new System.EventHandler(this.ExternalRefreshCompanyData);
            this.Searcher.SelectedValueChanged += new System.EventHandler(this.ExternalRefreshCompanyData);
            // 
            // stockInfoDisplayer
            // 
            this.stockInfoDisplayer.BackColor = System.Drawing.Color.Transparent;
            this.stockInfoDisplayer.Font = new System.Drawing.Font("Arial", 12F);
            this.stockInfoDisplayer.Location = new System.Drawing.Point(22, 125);
            this.stockInfoDisplayer.Name = "stockInfoDisplayer";
            this.stockInfoDisplayer.Size = new System.Drawing.Size(535, 451);
            this.stockInfoDisplayer.TabIndex = 9;
            this.stockInfoDisplayer.DoubleClick += new System.EventHandler(this.RedirectToTrade);
            // 
            // companyCompleteName
            // 
            this.companyCompleteName.BackColor = System.Drawing.Color.Transparent;
            this.companyCompleteName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.companyCompleteName.Location = new System.Drawing.Point(22, 78);
            this.companyCompleteName.Name = "companyCompleteName";
            this.companyCompleteName.Size = new System.Drawing.Size(346, 37);
            this.companyCompleteName.TabIndex = 10;
            this.companyCompleteName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.companyCompleteName.DoubleClick += new System.EventHandler(this.RedirectToTrade);
            // 
            // DisplayedLogo
            // 
            this.DisplayedLogo.BackColor = System.Drawing.Color.Transparent;
            this.DisplayedLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.DisplayedLogo.Cursor = System.Windows.Forms.Cursors.Default;
            this.DisplayedLogo.Location = new System.Drawing.Point(579, 125);
            this.DisplayedLogo.Name = "DisplayedLogo";
            this.DisplayedLogo.Size = new System.Drawing.Size(350, 350);
            this.DisplayedLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DisplayedLogo.TabIndex = 11;
            this.DisplayedLogo.TabStop = false;
            // 
            // Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 585);
            this.Controls.Add(this.DisplayedLogo);
            this.Controls.Add(this.companyCompleteName);
            this.Controls.Add(this.stockInfoDisplayer);
            this.Controls.Add(this.Searcher);
            this.Controls.Add(this.companyData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Stock";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Stock";
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.DisplayedLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel companyData;
        private System.Windows.Forms.ComboBox Searcher;
        private System.Windows.Forms.Label stockInfoDisplayer;
        private System.Windows.Forms.Label companyCompleteName;
        private System.Windows.Forms.PictureBox DisplayedLogo;
    }
}