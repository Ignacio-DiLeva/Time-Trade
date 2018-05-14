namespace mainSample
{
    partial class Trade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Trade));
            this.canvas = new System.Windows.Forms.Panel();
            this.Searcher = new System.Windows.Forms.ComboBox();
            this.displayedCompany = new MaterialSkin.Controls.MaterialLabel();
            this.companyPrices = new MaterialSkin.Controls.MaterialLabel();
            this.btnBuySelected = new System.Windows.Forms.Button();
            this.orderLimit = new System.Windows.Forms.NumericUpDown();
            this.orderCount = new System.Windows.Forms.NumericUpDown();
            this.label_balance = new System.Windows.Forms.Label();
            this.WeeksToAdd = new System.Windows.Forms.NumericUpDown();
            this.btnMarketSelected = new System.Windows.Forms.Button();
            this.btnAdvanceInTime = new System.Windows.Forms.Button();
            this.btnPlaceOrder = new System.Windows.Forms.Button();
            this.btnLimitSelected = new System.Windows.Forms.Button();
            this.btnSellSelected = new System.Windows.Forms.Button();
            this.btnRequestBest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.orderLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeeksToAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.canvas.Location = new System.Drawing.Point(0, 90);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(975, 400);
            this.canvas.TabIndex = 5;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.CanvasPaint);
            // 
            // Searcher
            // 
            this.Searcher.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Searcher.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Searcher.BackColor = System.Drawing.SystemColors.Window;
            this.Searcher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Searcher.FormattingEnabled = true;
            this.Searcher.Location = new System.Drawing.Point(712, 27);
            this.Searcher.Name = "Searcher";
            this.Searcher.Size = new System.Drawing.Size(235, 21);
            this.Searcher.TabIndex = 0;
            this.Searcher.TabStop = false;
            this.Searcher.Text = "AAPL (Apple, Inc.)";
            this.Searcher.SelectedIndexChanged += new System.EventHandler(this.CheckChangeOnSearcher);
            this.Searcher.SelectedValueChanged += new System.EventHandler(this.CheckChangeOnSearcher);
            // 
            // displayedCompany
            // 
            this.displayedCompany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.displayedCompany.Depth = 0;
            this.displayedCompany.Font = new System.Drawing.Font("Roboto", 11F);
            this.displayedCompany.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.displayedCompany.Location = new System.Drawing.Point(251, 26);
            this.displayedCompany.MouseState = MaterialSkin.MouseState.HOVER;
            this.displayedCompany.Name = "displayedCompany";
            this.displayedCompany.Size = new System.Drawing.Size(75, 19);
            this.displayedCompany.TabIndex = 6;
            this.displayedCompany.Tag = "0";
            this.displayedCompany.Text = "AAPL";
            this.displayedCompany.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.displayedCompany.TextChanged += new System.EventHandler(this.ExternalCanvasRefresh);
            // 
            // companyPrices
            // 
            this.companyPrices.AutoSize = true;
            this.companyPrices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.companyPrices.Depth = 0;
            this.companyPrices.Font = new System.Drawing.Font("Roboto", 11F);
            this.companyPrices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.companyPrices.Location = new System.Drawing.Point(330, 26);
            this.companyPrices.MouseState = MaterialSkin.MouseState.HOVER;
            this.companyPrices.Name = "companyPrices";
            this.companyPrices.Size = new System.Drawing.Size(133, 19);
            this.companyPrices.TabIndex = 8;
            this.companyPrices.Text = "$PRICE HIGH LOW";
            // 
            // btnBuySelected
            // 
            this.btnBuySelected.BackColor = System.Drawing.SystemColors.Control;
            this.btnBuySelected.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuySelected.BackgroundImage")));
            this.btnBuySelected.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuySelected.Enabled = false;
            this.btnBuySelected.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnBuySelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuySelected.Location = new System.Drawing.Point(156, 524);
            this.btnBuySelected.Name = "btnBuySelected";
            this.btnBuySelected.Size = new System.Drawing.Size(56, 23);
            this.btnBuySelected.TabIndex = 18;
            this.btnBuySelected.TabStop = false;
            this.btnBuySelected.Text = "BUY";
            this.btnBuySelected.UseVisualStyleBackColor = false;
            this.btnBuySelected.Click += new System.EventHandler(this.OrderSelection);
            // 
            // orderLimit
            // 
            this.orderLimit.Enabled = false;
            this.orderLimit.Location = new System.Drawing.Point(456, 538);
            this.orderLimit.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.orderLimit.Name = "orderLimit";
            this.orderLimit.Size = new System.Drawing.Size(97, 20);
            this.orderLimit.TabIndex = 54;
            this.orderLimit.TabStop = false;
            this.orderLimit.ThousandsSeparator = true;
            // 
            // orderCount
            // 
            this.orderCount.Location = new System.Drawing.Point(245, 538);
            this.orderCount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.orderCount.Name = "orderCount";
            this.orderCount.Size = new System.Drawing.Size(97, 20);
            this.orderCount.TabIndex = 51;
            this.orderCount.TabStop = false;
            this.orderCount.ThousandsSeparator = true;
            // 
            // label_balance
            // 
            this.label_balance.AutoSize = true;
            this.label_balance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.label_balance.Location = new System.Drawing.Point(58, 545);
            this.label_balance.Name = "label_balance";
            this.label_balance.Size = new System.Drawing.Size(37, 13);
            this.label_balance.TabIndex = 57;
            this.label_balance.Text = "10000";
            // 
            // WeeksToAdd
            // 
            this.WeeksToAdd.Location = new System.Drawing.Point(757, 613);
            this.WeeksToAdd.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.WeeksToAdd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WeeksToAdd.Name = "WeeksToAdd";
            this.WeeksToAdd.Size = new System.Drawing.Size(120, 20);
            this.WeeksToAdd.TabIndex = 58;
            this.WeeksToAdd.TabStop = false;
            this.WeeksToAdd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnMarketSelected
            // 
            this.btnMarketSelected.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMarketSelected.BackgroundImage")));
            this.btnMarketSelected.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMarketSelected.Enabled = false;
            this.btnMarketSelected.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnMarketSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarketSelected.Location = new System.Drawing.Point(349, 524);
            this.btnMarketSelected.Name = "btnMarketSelected";
            this.btnMarketSelected.Size = new System.Drawing.Size(68, 23);
            this.btnMarketSelected.TabIndex = 53;
            this.btnMarketSelected.TabStop = false;
            this.btnMarketSelected.Text = "MARKET";
            this.btnMarketSelected.UseVisualStyleBackColor = false;
            this.btnMarketSelected.Click += new System.EventHandler(this.OrderSelection);
            // 
            // btnAdvanceInTime
            // 
            this.btnAdvanceInTime.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdvanceInTime.BackgroundImage")));
            this.btnAdvanceInTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdvanceInTime.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnAdvanceInTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdvanceInTime.Location = new System.Drawing.Point(777, 536);
            this.btnAdvanceInTime.Name = "btnAdvanceInTime";
            this.btnAdvanceInTime.Size = new System.Drawing.Size(75, 23);
            this.btnAdvanceInTime.TabIndex = 59;
            this.btnAdvanceInTime.TabStop = false;
            this.btnAdvanceInTime.Text = "+ WEEKS";
            this.btnAdvanceInTime.UseVisualStyleBackColor = false;
            this.btnAdvanceInTime.Click += new System.EventHandler(this.RefreshCanvas);
            // 
            // btnPlaceOrder
            // 
            this.btnPlaceOrder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPlaceOrder.BackgroundImage")));
            this.btnPlaceOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPlaceOrder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnPlaceOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlaceOrder.Location = new System.Drawing.Point(559, 518);
            this.btnPlaceOrder.Name = "btnPlaceOrder";
            this.btnPlaceOrder.Size = new System.Drawing.Size(95, 58);
            this.btnPlaceOrder.TabIndex = 55;
            this.btnPlaceOrder.TabStop = false;
            this.btnPlaceOrder.Text = "PLACE";
            this.btnPlaceOrder.UseVisualStyleBackColor = false;
            this.btnPlaceOrder.Click += new System.EventHandler(this.PlaceOrder);
            // 
            // btnLimitSelected
            // 
            this.btnLimitSelected.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLimitSelected.BackgroundImage")));
            this.btnLimitSelected.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLimitSelected.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnLimitSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimitSelected.Location = new System.Drawing.Point(349, 546);
            this.btnLimitSelected.Name = "btnLimitSelected";
            this.btnLimitSelected.Size = new System.Drawing.Size(68, 23);
            this.btnLimitSelected.TabIndex = 52;
            this.btnLimitSelected.TabStop = false;
            this.btnLimitSelected.Text = "LIMIT";
            this.btnLimitSelected.UseVisualStyleBackColor = false;
            this.btnLimitSelected.Click += new System.EventHandler(this.OrderSelection);
            // 
            // btnSellSelected
            // 
            this.btnSellSelected.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSellSelected.BackgroundImage")));
            this.btnSellSelected.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSellSelected.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnSellSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSellSelected.Location = new System.Drawing.Point(156, 546);
            this.btnSellSelected.Name = "btnSellSelected";
            this.btnSellSelected.Size = new System.Drawing.Size(56, 23);
            this.btnSellSelected.TabIndex = 17;
            this.btnSellSelected.TabStop = false;
            this.btnSellSelected.Text = "SELL";
            this.btnSellSelected.UseVisualStyleBackColor = false;
            this.btnSellSelected.Click += new System.EventHandler(this.OrderSelection);
            // 
            // btnRequestBest
            // 
            this.btnRequestBest.Enabled = false;
            this.btnRequestBest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequestBest.Location = new System.Drawing.Point(12, 22);
            this.btnRequestBest.Name = "btnRequestBest";
            this.btnRequestBest.Size = new System.Drawing.Size(233, 23);
            this.btnRequestBest.TabIndex = 60;
            this.btnRequestBest.Text = "BEST 10";
            this.btnRequestBest.UseVisualStyleBackColor = true;
            this.btnRequestBest.Click += new System.EventHandler(this.RequestBestPlayers);
            // 
            // Trade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 600);
            this.Controls.Add(this.btnRequestBest);
            this.Controls.Add(this.btnAdvanceInTime);
            this.Controls.Add(this.WeeksToAdd);
            this.Controls.Add(this.label_balance);
            this.Controls.Add(this.btnPlaceOrder);
            this.Controls.Add(this.orderLimit);
            this.Controls.Add(this.btnMarketSelected);
            this.Controls.Add(this.btnLimitSelected);
            this.Controls.Add(this.orderCount);
            this.Controls.Add(this.btnBuySelected);
            this.Controls.Add(this.btnSellSelected);
            this.Controls.Add(this.companyPrices);
            this.Controls.Add(this.displayedCompany);
            this.Controls.Add(this.Searcher);
            this.Controls.Add(this.canvas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Trade";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Trade";
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.orderLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeeksToAdd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel canvas;
        private MaterialSkin.Controls.MaterialLabel companyPrices;
        private System.Windows.Forms.Button btnBuySelected;
        private System.Windows.Forms.Button btnSellSelected;
        private System.Windows.Forms.Button btnPlaceOrder;
        private System.Windows.Forms.NumericUpDown orderLimit;
        private System.Windows.Forms.Button btnMarketSelected;
        private System.Windows.Forms.Button btnLimitSelected;
        private System.Windows.Forms.NumericUpDown orderCount;
        private System.Windows.Forms.Label label_balance;
        public System.Windows.Forms.ComboBox Searcher;
        private System.Windows.Forms.NumericUpDown WeeksToAdd;
        private System.Windows.Forms.Button btnAdvanceInTime;
        private MaterialSkin.Controls.MaterialLabel displayedCompany;
        public System.Windows.Forms.Button btnRequestBest;
    }
}