using System.Data.OleDb;

namespace COFFEE_SHOP_APPLICATION
{
    internal class Menus : generalClass
    {
        public Dictionary<string, (decimal Price, string ImagePath, int stocks)> ShowMenu(string category)
        {
            var menuItems = new Dictionary<string, (decimal Price, string ImagePath, int stocks)>();

            if (category == "All Menu")
            {
                try
                {
                    using (var connection = GetConnection())
                    {
                        connection.Open();

                        string updateQuery = "UPDATE Products SET Status = IIF(Stocks = 0, 'Unavailable', 'Available')";
                        using (var updateCmd = new OleDbCommand(updateQuery, connection))
                        {
                            updateCmd.ExecuteNonQuery();
                        }

                        string query = "SELECT ProductName, Price, ImagePath, Stocks FROM Products WHERE Status = 'Available'";


                        using (var cmd = new OleDbCommand(query, connection))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string name = reader["ProductName"].ToString();
                                    decimal price = Convert.ToDecimal(reader["Price"]);
                                    string imgPath = reader["ImagePath"].ToString();
                                    int stocks = Convert.ToInt32(reader["Stocks"]);

                                    menuItems[name] = (price, imgPath, stocks);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading menu: " + ex.Message);
                }
            }
            else
            {
                using (var connection = GetConnection())
                {
                    try
                    {
                        connection.Open();

                        string updateQuery = "UPDATE Products SET Status = IIF(Stocks = 0, 'Unavailable', 'Available')";
                        using (var updateCmd = new OleDbCommand(updateQuery, connection))
                        {
                            updateCmd.ExecuteNonQuery();
                        }

                        string query = string.IsNullOrEmpty(category)
                        ? "SELECT ProductName, Price, ImagePath, Stocks FROM Products WHERE Status = 'available'"
                        : "SELECT ProductName, Price, ImagePath, Stocks FROM Products WHERE Category = ? AND Status = 'available'";


                        using (var cmd = new OleDbCommand(query, connection))
                        {
                            if (!string.IsNullOrEmpty(category))
                                cmd.Parameters.AddWithValue("?", category);

                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string name = reader["ProductName"].ToString();
                                    decimal price = Convert.ToDecimal(reader["Price"]);
                                    string imgPath = reader["ImagePath"].ToString();
                                    int stocks = Convert.ToInt32(reader["Stocks"]);

                                    menuItems[name] = (price, imgPath, stocks);
                                }
                            }
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading menu: " + ex.Message);
                    }
                    finally
                    {
                        if (connection.State == System.Data.ConnectionState.Open)
                        {
                            connection.Close();
                        }
                    }
                }
            }
            return menuItems;
        }

        public Dictionary<string, (string Title, string ImagePath)> ShowCategories()
        {
            var categories = new Dictionary<string, (string Title, string ImagePath)>();

            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();

                    string query = "SELECT Title, ImagePath FROM categories";

                    using (var cmd = new OleDbCommand(query, connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string title = reader["Title"].ToString();
                                string imgPath = reader["ImagePath"].ToString();

                                categories[title] = (title, imgPath);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message);
            }

            return categories;
        }

    }
}