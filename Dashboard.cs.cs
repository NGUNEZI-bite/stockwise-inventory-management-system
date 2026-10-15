using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StockWiseInventorySystem
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();

            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 1. Check that all fields are filled in
            if (string.IsNullOrWhiteSpace(txtProductID.Text) ||
                string.IsNullOrWhiteSpace(txtProductName.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show(
                    "Please fill in all product fields.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // 2. Check that quantity is a whole number
            if (!int.TryParse(txtQuantity.Text, out int quantity))
            {
                MessageBox.Show("Quantity must be a whole number.");
                return;
            }

            // 3. Prevent negative quantities
            if (quantity < 0)
            {
                MessageBox.Show("Quantity cannot be negative.");
                return;
            }

            // 4. Check that price is a valid number
            string priceText = txtPrice.Text
                .Replace("R", "")
                .Trim();

            if (!double.TryParse(
                priceText,
                System.Globalization.NumberStyles.Number,
                System.Globalization.CultureInfo.GetCultureInfo("en-ZA"),
                out double price))
            {
                MessageBox.Show("Please enter a valid price, for example 150 or 150.50.");
                return;
            }

            // 5. Prevent negative prices
            if (price < 0)
            {
                MessageBox.Show("Price cannot be negative.");
                return;
            }

            // 6. Save the product to SQLite
            try
            {
                DatabaseHelper db = new DatabaseHelper();

                db.AddProduct(
                    txtProductID.Text.Trim(),
                    txtProductName.Text.Trim(),
                    quantity,
                    price
                );

                // 7. Refresh the grid from the database
                LoadProducts();
                LoadStockMovements();

                // 8. Clear the fields
                txtProductID.Clear();
                txtProductName.Clear();
                txtQuantity.Clear();
                txtPrice.Clear();

                MessageBox.Show("Product added successfully!");
            }
            catch (System.Data.SQLite.SQLiteException ex)
            {
                if (ex.Message.Contains("UNIQUE constraint failed"))
                {
                    MessageBox.Show(
                        "That Product ID already exists. Please use a different ID.",
                        "Duplicate Product",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
                else
                {
                    MessageBox.Show("Database error: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message);
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null ||
                dgvProducts.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Please select a product to delete.");
                return;
            }

            string productID = Convert.ToString(
                dgvProducts.CurrentRow.Cells["ProductID"].Value
            );

            if (string.IsNullOrWhiteSpace(productID))
            {
                MessageBox.Show("Invalid product selected.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this product?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
                return;

            DatabaseHelper db = new DatabaseHelper();
            db.DeleteProduct(productID);

            LoadProducts();
            LoadStockMovements();

            txtProductID.Clear();
            txtProductName.Clear();
            txtQuantity.Clear();
            txtPrice.Clear();

            MessageBox.Show("Product deleted successfully.");
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // 1. Make sure a product row is selected
            if (dgvProducts.CurrentRow == null ||
                dgvProducts.CurrentRow.IsNewRow)
            {
                MessageBox.Show(
                    "Please select a product to update.",
                    "No Product Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // 2. Check that all fields are filled in
            if (string.IsNullOrWhiteSpace(txtProductID.Text) ||
                string.IsNullOrWhiteSpace(txtProductName.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show(
                    "Please fill in all product fields.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // 3. Get the ID of the selected product
            string selectedProductID =
                dgvProducts.CurrentRow.Cells[0].Value?.ToString() ?? "";

            // 4. Prevent changing the Product ID during an update
            if (txtProductID.Text.Trim() != selectedProductID)
            {
                MessageBox.Show(
                    "The Product ID cannot be changed during an update. " +
                    "Please keep the selected product's original ID.",
                    "Product ID Mismatch",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // 5. Validate quantity
            if (!int.TryParse(txtQuantity.Text, out int quantity))
            {
                MessageBox.Show("Quantity must be a whole number.");
                return;
            }

            if (quantity < 0)
            {
                MessageBox.Show("Quantity cannot be negative.");
                return;
            }

            // 6. Validate price using South African number formatting
            string priceText = txtPrice.Text
                .Replace("R", "")
                .Trim();

            if (!double.TryParse(
                priceText,
                System.Globalization.NumberStyles.Number,
                System.Globalization.CultureInfo.GetCultureInfo("en-ZA"),
                out double price))
            {
                MessageBox.Show(
                    "Please enter a valid price, for example 150 or 150.50."
                );
                return;
            }

            if (price < 0)
            {
                MessageBox.Show("Price cannot be negative.");
                return;
            }

            // 7. Update the selected product in the database
            try
            {
                DatabaseHelper db = new DatabaseHelper();

                db.UpdateProduct(
                    selectedProductID,
                    txtProductName.Text.Trim(),
                    quantity,
                    price
                );

                // 8. Refresh the product list
                LoadProducts();
                LoadStockMovements();

                MessageBox.Show(
                    "Product updated successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occurred while updating the product: " + ex.Message
                );
            }
        }



        private void Dashboard_Load(object sender, EventArgs e)
        {
            DatabaseHelper db = new DatabaseHelper();
            db.CreateDatabase();

            LoadProducts();
            LoadStockMovements();
        }

        private void txtProductID_TextChanged(object sender, EventArgs e)
        {

        }
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtProductID.Text = dgvProducts.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtProductName.Text = dgvProducts.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtQuantity.Text = dgvProducts.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPrice.Text = dgvProducts.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }


        private void LoadProducts()
        {
            DatabaseHelper db = new DatabaseHelper();

            dgvProducts.DataSource = db.GetProducts();

            LoadStatistics();
            UpdateLowStockAlert();
        }



        private void LoadStockMovements()
        {
            DatabaseHelper db = new DatabaseHelper();

            dgvStockMovements.DataSource = db.GetStockMovements();

            dgvStockMovements.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvStockMovements.ReadOnly = true;
            dgvStockMovements.AllowUserToAddRows = false;
            dgvStockMovements.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            // Display the full date and time.
            if (dgvStockMovements.Columns.Contains("MovementDate"))
            {
                dgvStockMovements.Columns["MovementDate"].DefaultCellStyle.Format =
                    "yyyy-MM-dd HH:mm:ss";

                dgvStockMovements.Columns["MovementDate"].MinimumWidth = 150;
            }
        }





        private void SearchProducts()
        {
            DatabaseHelper db = new DatabaseHelper();

            // Get the products from the database
            System.Data.DataTable products = db.GetProducts();

            // Prepare the search text
            string searchText = txtSearch.Text.Trim()
                .Replace("'", "''");

            // Filter by Product ID or Product Name
            System.Data.DataView view = products.DefaultView;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                view.RowFilter = "";
            }
            else
            {
                view.RowFilter =
                    $"ProductID LIKE '%{searchText}%' OR " +
                    $"ProductName LIKE '%{searchText}%'";
            }


            // Display the matching results
            dgvProducts.DataSource = view;
            UpdateLowStockAlert();
        }

        private void LoadStatistics()
        {
            DatabaseHelper db = new DatabaseHelper();

            System.Data.DataTable stats =
                db.GetInventoryStatistics();

            if (stats.Rows.Count > 0)
            {
                lblTotalProducts.Text =
                    "Total Products: " +
                    stats.Rows[0]["TotalProducts"].ToString();

                lblTotalStock.Text =
                    "Total Stock Quantity: " +
                    stats.Rows[0]["TotalStock"].ToString();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchProducts();
        }

        private void UpdateLowStockAlert()
        {
            DatabaseHelper db = new DatabaseHelper();

            // Get all products, regardless of the current search
            System.Data.DataTable products = db.GetProducts();

            int lowStockCount = 0;

            // Count products with 5 or fewer items
            foreach (System.Data.DataRow product in products.Rows)
            {
                int quantity = System.Convert.ToInt32(
                    product["Quantity"]);

                if (quantity <= 5)
                {
                    lowStockCount++;
                }
            }

            // Update the alert label
            lblLowStockAlert.Text =
                "Low-stock items: " + lowStockCount;

            // Highlight low-stock products currently shown in the grid
            foreach (System.Windows.Forms.DataGridViewRow row
                     in dgvProducts.Rows)
            {
                if (row.IsNewRow || row.Cells["Quantity"].Value == null)
                {
                    continue;
                }

                int quantity = System.Convert.ToInt32(
                    row.Cells["Quantity"].Value);

                if (quantity <= 5)
                {
                    row.DefaultCellStyle.BackColor =
                        System.Drawing.Color.LightSalmon;

                    row.DefaultCellStyle.ForeColor =
                        System.Drawing.Color.Black;
                }
                else
                {
                    // Restore the normal row appearance
                    row.DefaultCellStyle.BackColor =
                        dgvProducts.DefaultCellStyle.BackColor;

                    row.DefaultCellStyle.ForeColor =
                        dgvProducts.DefaultCellStyle.ForeColor;
                }
            }
        }

        private void btnLowStock_Click(object sender, EventArgs e)
        {
            DatabaseHelper db = new DatabaseHelper();

            System.Data.DataTable products = db.GetProducts();
            System.Data.DataView view = products.DefaultView;

            view.RowFilter = "Quantity <= 5";

            dgvProducts.DataSource = view;
            UpdateLowStockAlert();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadProducts();
            LoadStockMovements();
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            DatabaseHelper db = new DatabaseHelper();
            System.Data.DataTable products = db.GetProducts();

            if (products.Rows.Count == 0)
            {
                MessageBox.Show("There are no products to export.");
                return;
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Title = "Export StockWise Inventory";
                saveDialog.Filter = "CSV files (*.csv)|*.csv";
                saveDialog.FileName = "StockWiseInventory.csv";
                saveDialog.DefaultExt = "csv";
                saveDialog.AddExtension = true;

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (System.IO.StreamWriter writer =
                               new System.IO.StreamWriter(saveDialog.FileName, false,
                                   System.Text.Encoding.UTF8))
                        {
                            writer.WriteLine("sep=,");
                            // Write column headings
                            for (int column = 0;
                                 column < products.Columns.Count;
                                 column++)
                            {
                                if (column > 0)
                                    writer.Write(",");

                                writer.Write(EscapeCSV(
                                    products.Columns[column].ColumnName));
                            }

                            writer.WriteLine();

                            // Write each product
                            foreach (System.Data.DataRow row in products.Rows)
                            {
                                for (int column = 0;
                                     column < products.Columns.Count;
                                     column++)
                                {
                                    if (column > 0)
                                        writer.Write(",");

                                    writer.Write(EscapeCSV(
                                        row[column]?.ToString() ?? ""));
                                }

                                writer.WriteLine();
                            }
                        }

                        MessageBox.Show(
                            "Inventory exported successfully!",
                            "Export Complete",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "Could not export inventory: " + ex.Message,
                            "Export Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private string EscapeCSV(string value)
        {
            if (value.Contains(",") ||
                value.Contains("\"") ||
                value.Contains("\r") ||
                value.Contains("\n"))
            {
                value = "\"" + value.Replace("\"", "\"\"") + "\"";
            }

            return value;
        }

        private void btnExportLowStock_Click(object sender, EventArgs e)
        {

            DatabaseHelper db = new DatabaseHelper();
            System.Data.DataTable products = db.GetProducts();

            // Keep only products with quantity 5 or less.
            System.Data.DataView view = new System.Data.DataView(products);
            view.RowFilter = "Quantity <= 5";

            System.Data.DataTable lowStockProducts = view.ToTable();

            if (lowStockProducts.Rows.Count == 0)
            {
                MessageBox.Show(
                    "There are no low-stock products to export.",
                    "Low-Stock Report",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Title = "Export Low-Stock Report";
                saveDialog.Filter = "CSV files (*.csv)|*.csv";
                saveDialog.FileName = "StockWiseLowStockReport.csv";
                saveDialog.DefaultExt = "csv";
                saveDialog.AddExtension = true;

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (System.IO.StreamWriter writer =
                            new System.IO.StreamWriter(
                                saveDialog.FileName,
                                false,
                                new System.Text.UTF8Encoding(true)))
                        {
                            // Help Excel recognise the comma separator.
                            writer.WriteLine("sep=,");


                            writer.WriteLine("StockWise Inventory System - Low-Stock Report");
                            writer.WriteLine("Report Date," + DateTime.Now.ToString("dd MMMM yyyy HH:mm"));
                            writer.WriteLine("Low-Stock Product Count," + lowStockProducts.Rows.Count);
                            writer.WriteLine();



                            // Write column headings.
                            for (int column = 0;
                                 column < lowStockProducts.Columns.Count;
                                 column++)
                            {
                                if (column > 0)
                                    writer.Write(",");

                                writer.Write(EscapeCSV(
                                    lowStockProducts.Columns[column].ColumnName));
                            }

                            writer.WriteLine();

                            // Write low-stock products.
                            foreach (System.Data.DataRow row in lowStockProducts.Rows)
                            {
                                for (int column = 0;
                                     column < lowStockProducts.Columns.Count;
                                     column++)
                                {
                                    if (column > 0)
                                        writer.Write(",");

                                    writer.Write(EscapeCSV(
                                        row[column]?.ToString() ?? ""));
                                }

                                writer.WriteLine();
                            }
                        }

                        MessageBox.Show(
                            "Low-stock report exported successfully!",
                            "Export Complete",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "Could not export the report: " + ex.Message,
                            "Export Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }

        }
    }
}
