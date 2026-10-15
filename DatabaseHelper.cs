using System.Data;
using System.Data.SQLite;

namespace StockWiseInventorySystem
{
    public class DatabaseHelper
    {
        private string connectionString =
            "Data Source=stockwise.db;Version=3;";


        public void CreateDatabase()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                // Create the existing Products table.
                string sql = @"
            CREATE TABLE IF NOT EXISTS Products
            (
                ProductID TEXT PRIMARY KEY,
                ProductName TEXT,
                Quantity INTEGER,
                Price REAL
            );";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // Create the new StockMovements table.
                string createMovementsTable = @"
            CREATE TABLE IF NOT EXISTS StockMovements
            (
                MovementID INTEGER PRIMARY KEY AUTOINCREMENT,
                ProductID TEXT NOT NULL,
                ProductName TEXT NOT NULL,
                MovementType TEXT NOT NULL,
                QuantityChanged INTEGER NOT NULL,
                PreviousQuantity INTEGER NOT NULL,
                NewQuantity INTEGER NOT NULL,
                MovementDate TEXT NOT NULL
            );";

                using (SQLiteCommand command =
                    new SQLiteCommand(createMovementsTable, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        //found the problem it was here
        public void AddProduct(
    string productID,
    string productName,
    int quantity,
    double price)
        {
            using (SQLiteConnection conn =
                   new SQLiteConnection(connectionString))
            {
                conn.Open();

                string sql =
                @"INSERT INTO Products
        (ProductID, ProductName, Quantity, Price)
        VALUES
        (@id, @name, @qty, @price)";

                SQLiteCommand cmd =
                    new SQLiteCommand(sql, conn);

                cmd.Parameters.AddWithValue("@id", productID);
                cmd.Parameters.AddWithValue("@name", productName);
                cmd.Parameters.AddWithValue("@qty", quantity);
                cmd.Parameters.AddWithValue("@price", price);

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetProducts()
        {
            using (SQLiteConnection conn =
                   new SQLiteConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT * FROM Products";

                SQLiteDataAdapter adapter =
                    new SQLiteDataAdapter(sql, conn);

                DataTable table = new DataTable();

                adapter.Fill(table);


                return table;

            }

        }


        public void UpdateProduct(string productID, string productName, int quantity, double price)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int previousQuantity;
                        string previousName;

                        // Get the current product details before updating.
                        string selectSql = @"
                    SELECT ProductName, Quantity
                    FROM Products
                    WHERE ProductID = @ProductID;";

                        using (SQLiteCommand selectCommand =
                            new SQLiteCommand(selectSql, connection, transaction))
                        {
                            selectCommand.Parameters.AddWithValue("@ProductID", productID);

                            using (SQLiteDataReader reader = selectCommand.ExecuteReader())
                            {
                                if (!reader.Read())
                                {
                                    throw new Exception("Product not found.");
                                }

                                previousName = reader["ProductName"].ToString() ?? "";
                                previousQuantity = Convert.ToInt32(reader["Quantity"]);
                            }
                        }

                        // Update the product.
                        string updateSql = @"
                    UPDATE Products
                    SET ProductName = @ProductName,
                        Quantity = @Quantity,
                        Price = @Price
                    WHERE ProductID = @ProductID;";

                        using (SQLiteCommand updateCommand =
                            new SQLiteCommand(updateSql, connection, transaction))
                        {
                            updateCommand.Parameters.AddWithValue("@ProductID", productID);
                            updateCommand.Parameters.AddWithValue("@ProductName", productName);
                            updateCommand.Parameters.AddWithValue("@Quantity", quantity);
                            updateCommand.Parameters.AddWithValue("@Price", price);
                            updateCommand.ExecuteNonQuery();
                        }

                        // Record a stock movement only when the quantity changes.
                        if (previousQuantity != quantity)
                        {
                            string movementType =
                                quantity > previousQuantity ? "Stock Increased" : "Stock Reduced";

                            int quantityChanged = Math.Abs(quantity - previousQuantity);

                            RecordStockMovement(
                                connection,
                                transaction,
                                productID,
                                productName,
                                movementType,
                                quantityChanged,
                                previousQuantity,
                                quantity);
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }



        public void DeleteProduct(string productID)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string sql = "DELETE FROM Products WHERE ProductID = @ProductID";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public System.Data.DataTable GetInventoryStatistics()
        {
            using (SQLiteConnection connection =
                   new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = @"
            SELECT
                COUNT(*) AS TotalProducts,
                COALESCE(SUM(Quantity), 0) AS TotalStock
            FROM Products;";

                using (SQLiteCommand command =
                       new SQLiteCommand(query, connection))
                using (SQLiteDataAdapter adapter =
                       new SQLiteDataAdapter(command))
                {
                    System.Data.DataTable table =
                        new System.Data.DataTable();

                    adapter.Fill(table);
                    return table;
                }
            }
        }



        public void RecordStockMovement(
            SQLiteConnection connection,
            SQLiteTransaction transaction,
            string productID,
            string productName,
            string movementType,
            int quantityChanged,
            int previousQuantity,
            int newQuantity)
        {
            string sql = @"
        INSERT INTO StockMovements
        (
            ProductID,
            ProductName,
            MovementType,
            QuantityChanged,
            PreviousQuantity,
            NewQuantity,
            MovementDate
        )
        VALUES
        (
            @ProductID,
            @ProductName,
            @MovementType,
            @QuantityChanged,
            @PreviousQuantity,
            @NewQuantity,
            @MovementDate
        );";

            using (SQLiteCommand command =
                new SQLiteCommand(sql, connection, transaction))
            {
                command.Parameters.AddWithValue("@ProductID", productID);
                command.Parameters.AddWithValue("@ProductName", productName);
                command.Parameters.AddWithValue("@MovementType", movementType);
                command.Parameters.AddWithValue("@QuantityChanged", quantityChanged);
                command.Parameters.AddWithValue("@PreviousQuantity", previousQuantity);
                command.Parameters.AddWithValue("@NewQuantity", newQuantity);
                command.Parameters.AddWithValue(
                    "@MovementDate",
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                command.ExecuteNonQuery();
            }
        }


        public DataTable GetStockMovements()
        {
            using (SQLiteConnection connection =
                new SQLiteConnection(connectionString))
            {
                connection.Open();

                string sql = @"
            SELECT MovementID, ProductID, ProductName,
                   MovementType, QuantityChanged,
                   PreviousQuantity, NewQuantity, MovementDate
            FROM StockMovements
            ORDER BY MovementID DESC";

                using (SQLiteDataAdapter adapter =
                    new SQLiteDataAdapter(sql, connection))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }

    }
}

