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
            this.SuspendLayout();
            // 
            // companyData
            // 
            this.companyData.BackColor = System.Drawing.Color.Transparent;
            this.companyData.Depth = 0;
            this.companyData.Font = new System.Drawing.Font("Roboto", 11F);
            this.companyData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.companyData.Location = new System.Drawing.Point(0, 105);
            this.companyData.MouseState = MaterialSkin.MouseState.HOVER;
            this.companyData.Name = "companyData";
            this.companyData.Size = new System.Drawing.Size(975, 19);
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
            this.Searcher.Location = new System.Drawing.Point(383, 78);
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
            this.stockInfoDisplayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.stockInfoDisplayer.Location = new System.Drawing.Point(237, 164);
            this.stockInfoDisplayer.Name = "stockInfoDisplayer";
            this.stockInfoDisplayer.Size = new System.Drawing.Size(500, 500);
            this.stockInfoDisplayer.TabIndex = 9;
            this.stockInfoDisplayer.DoubleClick += new System.EventHandler(this.RedirectToTrade);
            // 
            // companyCompleteName
            // 
            this.companyCompleteName.BackColor = System.Drawing.Color.Transparent;
            this.companyCompleteName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.companyCompleteName.Location = new System.Drawing.Point(237, 133);
            this.companyCompleteName.Name = "companyCompleteName";
            this.companyCompleteName.Size = new System.Drawing.Size(500, 25);
            this.companyCompleteName.TabIndex = 10;
            this.companyCompleteName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.companyCompleteName.DoubleClick += new System.EventHandler(this.RedirectToTrade);
            // 
            // Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 664);
            this.Controls.Add(this.companyCompleteName);
            this.Controls.Add(this.stockInfoDisplayer);
            this.Controls.Add(this.Searcher);
            this.Controls.Add(this.companyData);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Stock";
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Stock";
            this.Load += new System.EventHandler(this.OnLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel companyData;
        private System.Windows.Forms.ComboBox Searcher;
        private System.Windows.Forms.Label stockInfoDisplayer;
        private System.Windows.Forms.Label companyCompleteName;
    }
}