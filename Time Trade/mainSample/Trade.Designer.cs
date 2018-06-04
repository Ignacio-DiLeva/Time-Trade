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
            this.btnBuySelected = new System.Windows.Forms.Button();
            this.orderLimit = new System.Windows.Forms.NumericUpDown();
            this.orderCount = new System.Windows.Forms.NumericUpDown();
            this.WeeksToAdd = new System.Windows.Forms.NumericUpDown();
            this.btnMarketSelected = new System.Windows.Forms.Button();
            this.btnAdvanceInTime = new System.Windows.Forms.Button();
            this.btnPlaceOrder = new System.Windows.Forms.Button();
            this.btnLimitSelected = new System.Windows.Forms.Button();
            this.btnSellSelected = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.orderLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeeksToAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.canvas.Location = new System.Drawing.Point(0, 10);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(975, 400);
            this.canvas.TabIndex = 5;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.CanvasPaint);
            // 
            // btnBuySelected
            // 
            this.btnBuySelected.BackColor = System.Drawing.SystemColors.Control;
            this.btnBuySelected.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuySelected.BackgroundImage")));
            this.btnBuySelected.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuySelected.Enabled = false;
            this.btnBuySelected.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnBuySelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuySelected.Location = new System.Drawing.Point(65, 521);
            this.btnBuySelected.Name = "btnBuySelected";
            this.btnBuySelected.Size = new System.Drawing.Size(135, 23);
            this.btnBuySelected.TabIndex = 18;
            this.btnBuySelected.TabStop = false;
            this.btnBuySelected.Text = "BUY";
            this.btnBuySelected.UseVisualStyleBackColor = false;
            this.btnBuySelected.Click += new System.EventHandler(this.OrderSelection);
            // 
            // orderLimit
            // 
            this.orderLimit.Enabled = false;
            this.orderLimit.Location = new System.Drawing.Point(407, 495);
            this.orderLimit.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.orderLimit.Name = "orderLimit";
            this.orderLimit.Size = new System.Drawing.Size(276, 20);
            this.orderLimit.TabIndex = 54;
            this.orderLimit.TabStop = false;
            this.orderLimit.ThousandsSeparator = true;
            // 
            // orderCount
            // 
            this.orderCount.Location = new System.Drawing.Point(65, 493);
            this.orderCount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.orderCount.Name = "orderCount";
            this.orderCount.Size = new System.Drawing.Size(278, 20);
            this.orderCount.TabIndex = 51;
            this.orderCount.TabStop = false;
            this.orderCount.ThousandsSeparator = true;
            // 
            // WeeksToAdd
            // 
            this.WeeksToAdd.Location = new System.Drawing.Point(757, 528);
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
            this.btnMarketSelected.Location = new System.Drawing.Point(408, 521);
            this.btnMarketSelected.Name = "btnMarketSelected";
            this.btnMarketSelected.Size = new System.Drawing.Size(133, 23);
            this.btnMarketSelected.TabIndex = 53;
            this.btnMarketSelected.TabStop = false;
            this.btnMarketSelected.Text = "MARKET";
            this.btnMarketSelected.UseVisualStyleBackColor = false;
            this.btnMarketSelected.Click += new System.EventHandler(this.OrderSelection);
            // 
            // btnAdvanceInTime
            // 
            this.btnAdvanceInTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdvanceInTime.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.btnAdvanceInTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdvanceInTime.Location = new System.Drawing.Point(777, 500);
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
            this.btnPlaceOrder.Location = new System.Drawing.Point(709, 443);
            this.btnPlaceOrder.Name = "btnPlaceOrder";
            this.btnPlaceOrder.Size = new System.Drawing.Size(134, 117);
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
            this.btnLimitSelected.Location = new System.Drawing.Point(547, 521);
            this.btnLimitSelected.Name = "btnLimitSelected";
            this.btnLimitSelected.Size = new System.Drawing.Size(136, 23);
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
            this.btnSellSelected.Location = new System.Drawing.Point(208, 521);
            this.btnSellSelected.Name = "btnSellSelected";
            this.btnSellSelected.Size = new System.Drawing.Size(135, 23);
            this.btnSellSelected.TabIndex = 17;
            this.btnSellSelected.TabStop = false;
            this.btnSellSelected.Text = "SELL";
            this.btnSellSelected.UseVisualStyleBackColor = false;
            this.btnSellSelected.Click += new System.EventHandler(this.OrderSelection);
            // 
            // Trade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(131)))), ((int)(((byte)(84)))));
            this.ClientSize = new System.Drawing.Size(975, 585);
            this.Controls.Add(this.btnPlaceOrder);
            this.Controls.Add(this.btnAdvanceInTime);
            this.Controls.Add(this.WeeksToAdd);
            this.Controls.Add(this.orderLimit);
            this.Controls.Add(this.btnMarketSelected);
            this.Controls.Add(this.btnLimitSelected);
            this.Controls.Add(this.orderCount);
            this.Controls.Add(this.btnBuySelected);
            this.Controls.Add(this.btnSellSelected);
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

        }

        #endregion
        private System.Windows.Forms.Button btnBuySelected;
        private System.Windows.Forms.Button btnSellSelected;
        private System.Windows.Forms.Button btnPlaceOrder;
        private System.Windows.Forms.NumericUpDown orderLimit;
        private System.Windows.Forms.Button btnMarketSelected;
        private System.Windows.Forms.Button btnLimitSelected;
        private System.Windows.Forms.NumericUpDown orderCount;
        private System.Windows.Forms.NumericUpDown WeeksToAdd;
        private System.Windows.Forms.Button btnAdvanceInTime;
        public System.Windows.Forms.Panel canvas;
    }
}