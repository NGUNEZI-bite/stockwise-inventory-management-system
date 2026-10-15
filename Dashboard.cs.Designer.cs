namespace StockWiseInventorySystem
{
    partial class Dashboard
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            lblTitle = new Label();
            dgvProducts = new DataGridView();
            ProductID = new DataGridViewTextBoxColumn();
            ProductName = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnLogout = new Button();
            lblProductID = new Label();
            lblProductName = new Label();
            lblQuantity = new Label();
            lblPrice = new Label();
            txtProductID = new TextBox();
            txtProductName = new TextBox();
            txtQuantity = new TextBox();
            txtPrice = new TextBox();
            label1 = new Label();
            txtSearch = new TextBox();
            lblTotalProducts = new Label();
            lblTotalStock = new Label();
            lblLowStockAlert = new Label();
            btnLowStock = new Button();
            btnShowAll = new Button();
            btnExportCSV = new Button();
            btnExportLowStock = new Button();
            label2 = new Label();
            dgvStockMovements = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvStockMovements).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(162, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(390, 38);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "StockWise Inventory System";
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.BackgroundColor = Color.White;
            dgvProducts.BorderStyle = BorderStyle.None;
            dgvProducts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Teal;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Columns.AddRange(new DataGridViewColumn[] { ProductID, ProductName, Quantity, Price });
            dgvProducts.EnableHeadersVisualStyles = false;
            dgvProducts.GridColor = Color.Gainsboro;
            dgvProducts.Location = new Point(32, 195);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(764, 140);
            dgvProducts.TabIndex = 1;
            dgvProducts.CellClick += dgvProducts_CellClick;
            // 
            // ProductID
            // 
            ProductID.DataPropertyName = "ProductID";
            ProductID.HeaderText = "Product ID";
            ProductID.MinimumWidth = 6;
            ProductID.Name = "ProductID";
            ProductID.ReadOnly = true;
            // 
            // ProductName
            // 
            ProductName.DataPropertyName = "ProductName";
            ProductName.HeaderText = "Product Name";
            ProductName.MinimumWidth = 6;
            ProductName.Name = "ProductName";
            ProductName.ReadOnly = true;
            // 
            // Quantity
            // 
            Quantity.DataPropertyName = "Quantity";
            Quantity.HeaderText = "Quantity";
            Quantity.MinimumWidth = 6;
            Quantity.Name = "Quantity";
            Quantity.ReadOnly = true;
            // 
            // Price
            // 
            Price.DataPropertyName = "Price";
            Price.HeaderText = "Price";
            Price.MinimumWidth = 6;
            Price.Name = "Price";
            Price.ReadOnly = true;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(0, 192, 192);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(32, 567);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(125, 35);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add Product";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.SteelBlue;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(177, 567);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(125, 35);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "Update Product";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(327, 567);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(125, 35);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete Product";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.DimGray;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(489, 567);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(125, 35);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // lblProductID
            // 
            lblProductID.AutoSize = true;
            lblProductID.Location = new Point(32, 56);
            lblProductID.Name = "lblProductID";
            lblProductID.Size = new Size(79, 20);
            lblProductID.TabIndex = 6;
            lblProductID.Text = "Product ID";
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(32, 88);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(104, 20);
            lblProductName.TabIndex = 7;
            lblProductName.Text = "Product Name";
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(32, 123);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(65, 20);
            lblQuantity.TabIndex = 8;
            lblQuantity.Text = "Quantity";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(32, 160);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(41, 20);
            lblPrice.TabIndex = 9;
            lblPrice.Text = "Price";
            // 
            // txtProductID
            // 
            txtProductID.Location = new Point(146, 50);
            txtProductID.Name = "txtProductID";
            txtProductID.Size = new Size(125, 27);
            txtProductID.TabIndex = 10;
            txtProductID.TextChanged += txtProductID_TextChanged;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(146, 85);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(125, 27);
            txtProductName.TabIndex = 11;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(146, 120);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(125, 27);
            txtQuantity.TabIndex = 12;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(146, 157);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(125, 27);
            txtPrice.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(500, 154);
            label1.Name = "label1";
            label1.Size = new Size(114, 20);
            label1.TabIndex = 14;
            label1.Text = "Search Products";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(630, 151);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(125, 27);
            txtSearch.TabIndex = 15;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblTotalProducts
            // 
            lblTotalProducts.AutoSize = true;
            lblTotalProducts.Location = new Point(334, 56);
            lblTotalProducts.Name = "lblTotalProducts";
            lblTotalProducts.Size = new Size(118, 20);
            lblTotalProducts.TabIndex = 16;
            lblTotalProducts.Text = "Total Products: 0";
            // 
            // lblTotalStock
            // 
            lblTotalStock.AutoSize = true;
            lblTotalStock.Location = new Point(588, 57);
            lblTotalStock.Name = "lblTotalStock";
            lblTotalStock.Size = new Size(157, 20);
            lblTotalStock.TabIndex = 17;
            lblTotalStock.Text = "Total Stock Quantity: 0";
            // 
            // lblLowStockAlert
            // 
            lblLowStockAlert.AutoSize = true;
            lblLowStockAlert.Location = new Point(905, 53);
            lblLowStockAlert.Name = "lblLowStockAlert";
            lblLowStockAlert.Size = new Size(131, 20);
            lblLowStockAlert.TabIndex = 18;
            lblLowStockAlert.Text = "Low-stock items: 0";
            // 
            // btnLowStock
            // 
            btnLowStock.Location = new Point(905, 151);
            btnLowStock.Name = "btnLowStock";
            btnLowStock.Size = new Size(146, 29);
            btnLowStock.TabIndex = 19;
            btnLowStock.Text = "View Low-Stock Products";
            btnLowStock.UseVisualStyleBackColor = true;
            btnLowStock.Click += btnLowStock_Click;
            // 
            // btnShowAll
            // 
            btnShowAll.Location = new Point(905, 212);
            btnShowAll.Name = "btnShowAll";
            btnShowAll.Size = new Size(146, 29);
            btnShowAll.TabIndex = 20;
            btnShowAll.Text = "Show All Products";
            btnShowAll.UseVisualStyleBackColor = true;
            btnShowAll.Click += btnShowAll_Click;
            // 
            // btnExportCSV
            // 
            btnExportCSV.Location = new Point(905, 269);
            btnExportCSV.Name = "btnExportCSV";
            btnExportCSV.Size = new Size(146, 29);
            btnExportCSV.TabIndex = 21;
            btnExportCSV.Text = "Export to CSV";
            btnExportCSV.UseVisualStyleBackColor = true;
            btnExportCSV.Click += btnExportCSV_Click;
            // 
            // btnExportLowStock
            // 
            btnExportLowStock.Location = new Point(905, 329);
            btnExportLowStock.Name = "btnExportLowStock";
            btnExportLowStock.Size = new Size(146, 29);
            btnExportLowStock.TabIndex = 22;
            btnExportLowStock.Text = "Export Low-Stock Report";
            btnExportLowStock.UseVisualStyleBackColor = true;
            btnExportLowStock.Click += btnExportLowStock_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 338);
            label2.Name = "label2";
            label2.Size = new Size(171, 20);
            label2.TabIndex = 23;
            label2.Text = "Stock Movement History";
            // 
            // dgvStockMovements
            // 
            dgvStockMovements.AllowUserToAddRows = false;
            dgvStockMovements.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.Teal;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvStockMovements.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvStockMovements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStockMovements.Location = new Point(32, 379);
            dgvStockMovements.Name = "dgvStockMovements";
            dgvStockMovements.ReadOnly = true;
            dgvStockMovements.RowHeadersWidth = 51;
            dgvStockMovements.Size = new Size(1105, 182);
            dgvStockMovements.TabIndex = 24;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(1182, 753);
            Controls.Add(dgvStockMovements);
            Controls.Add(label2);
            Controls.Add(btnExportLowStock);
            Controls.Add(btnExportCSV);
            Controls.Add(btnShowAll);
            Controls.Add(btnLowStock);
            Controls.Add(lblLowStockAlert);
            Controls.Add(lblTotalStock);
            Controls.Add(lblTotalProducts);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Controls.Add(txtPrice);
            Controls.Add(txtQuantity);
            Controls.Add(txtProductName);
            Controls.Add(txtProductID);
            Controls.Add(lblPrice);
            Controls.Add(lblQuantity);
            Controls.Add(lblProductName);
            Controls.Add(lblProductID);
            Controls.Add(btnLogout);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(dgvProducts);
            Controls.Add(lblTitle);
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StockWise Inventory Dashboard";
            Load += Dashboard_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvStockMovements).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private DataGridView dgvProducts;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnLogout;
        private Label lblProductID;
        private Label lblProductName;
        private Label lblQuantity;
        private Label lblPrice;
        private TextBox txtProductID;
        private TextBox txtProductName;
        private TextBox txtQuantity;
        private TextBox txtPrice;
        private DataGridViewTextBoxColumn ProductID;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn Price;
        private Label label1;
        private TextBox txtSearch;
        private Label lblTotalProducts;
        private Label lblTotalStock;
        private Label lblLowStockAlert;
        private Button btnLowStock;
        private Button btnShowAll;
        private Button btnExportCSV;
        private Button btnExportLowStock;
        private Label label2;
        private DataGridView dgvStockMovements;
    }
}