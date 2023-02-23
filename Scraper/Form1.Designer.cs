namespace Scraper
{
    partial class frmScraper
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbTicker = new System.Windows.Forms.Label();
            this.btnGetData = new System.Windows.Forms.Button();
            this.txtTicker = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lbDate = new System.Windows.Forms.Label();
            this.dgCompanies = new System.Windows.Forms.DataGridView();
            this.dgItems = new System.Windows.Forms.DataGridView();
            this.lbCompanies = new System.Windows.Forms.Label();
            this.lbItems = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.CompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ticker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarketCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgCompanies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTicker
            // 
            this.lbTicker.AutoSize = true;
            this.lbTicker.Location = new System.Drawing.Point(12, 9);
            this.lbTicker.Name = "lbTicker";
            this.lbTicker.Size = new System.Drawing.Size(38, 15);
            this.lbTicker.TabIndex = 0;
            this.lbTicker.Text = "Ticker";
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(276, 34);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(85, 23);
            this.btnGetData.TabIndex = 1;
            this.btnGetData.Text = "Get data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // txtTicker
            // 
            this.txtTicker.Location = new System.Drawing.Point(56, 5);
            this.txtTicker.Name = "txtTicker";
            this.txtTicker.Size = new System.Drawing.Size(100, 23);
            this.txtTicker.TabIndex = 2;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(56, 34);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(205, 23);
            this.dtpDate.TabIndex = 3;
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.Location = new System.Drawing.Point(19, 38);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(31, 15);
            this.lbDate.TabIndex = 4;
            this.lbDate.Text = "Date";
            // 
            // dgCompanies
            // 
            this.dgCompanies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCompanies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CompanyName,
            this.Ticker,
            this.Employees,
            this.Adress,
            this.MarketCap});
            this.dgCompanies.Location = new System.Drawing.Point(1, 85);
            this.dgCompanies.Name = "dgCompanies";
            this.dgCompanies.RowTemplate.Height = 25;
            this.dgCompanies.Size = new System.Drawing.Size(860, 152);
            this.dgCompanies.TabIndex = 5;
            this.dgCompanies.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCompanies_CellClick);
            // 
            // dgItems
            // 
            this.dgItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItems.Location = new System.Drawing.Point(1, 259);
            this.dgItems.Name = "dgItems";
            this.dgItems.RowTemplate.Height = 25;
            this.dgItems.Size = new System.Drawing.Size(860, 183);
            this.dgItems.TabIndex = 6;
            // 
            // lbCompanies
            // 
            this.lbCompanies.AutoSize = true;
            this.lbCompanies.Location = new System.Drawing.Point(390, 65);
            this.lbCompanies.Name = "lbCompanies";
            this.lbCompanies.Size = new System.Drawing.Size(67, 15);
            this.lbCompanies.TabIndex = 7;
            this.lbCompanies.Text = "Companies";
            // 
            // lbItems
            // 
            this.lbItems.AutoSize = true;
            this.lbItems.Location = new System.Drawing.Point(408, 240);
            this.lbItems.Name = "lbItems";
            this.lbItems.Size = new System.Drawing.Size(36, 15);
            this.lbItems.TabIndex = 8;
            this.lbItems.Text = "Items";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(743, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Get companies";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CompanyName
            // 
            this.CompanyName.DataPropertyName = "CompanyName";
            this.CompanyName.HeaderText = "Company name";
            this.CompanyName.Name = "CompanyName";
            this.CompanyName.ReadOnly = true;
            this.CompanyName.Width = 230;
            // 
            // Ticker
            // 
            this.Ticker.DataPropertyName = "Ticker";
            this.Ticker.HeaderText = "Ticker";
            this.Ticker.Name = "Ticker";
            this.Ticker.ReadOnly = true;
            this.Ticker.Width = 50;
            // 
            // Employees
            // 
            this.Employees.DataPropertyName = "Employees";
            this.Employees.HeaderText = "Employees";
            this.Employees.Name = "Employees";
            this.Employees.ReadOnly = true;
            this.Employees.Width = 70;
            // 
            // Adress
            // 
            this.Adress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Adress.DataPropertyName = "Adress";
            this.Adress.HeaderText = "Adress";
            this.Adress.Name = "Adress";
            this.Adress.ReadOnly = true;
            // 
            // MarketCap
            // 
            this.MarketCap.DataPropertyName = "MarketCap";
            this.MarketCap.HeaderText = "Market Cap";
            this.MarketCap.Name = "MarketCap";
            this.MarketCap.ReadOnly = true;
            // 
            // frmScraper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 442);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbItems);
            this.Controls.Add(this.lbCompanies);
            this.Controls.Add(this.dgItems);
            this.Controls.Add(this.dgCompanies);
            this.Controls.Add(this.lbDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.txtTicker);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.lbTicker);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmScraper";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scraper";
            this.Load += new System.EventHandler(this.frmScraper_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCompanies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbTicker;
        private Button btnGetData;
        private TextBox txtTicker;
        private DateTimePicker dtpDate;
        private Label lbDate;
        private DataGridView dgCompanies;
        private DataGridView dgItems;
        private Label lbCompanies;
        private Label lbItems;
        private Button button1;
        private DataGridViewTextBoxColumn CompanyName;
        private DataGridViewTextBoxColumn Ticker;
        private DataGridViewTextBoxColumn Employees;
        private DataGridViewTextBoxColumn Adress;
        private DataGridViewTextBoxColumn MarketCap;
    }
}