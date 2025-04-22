    using Microsoft.VisualBasic.ApplicationServices;
    using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
    using System.Text;
    using System.Windows.Forms;
using static COFFEE_SHOP_APPLICATION.generalClass;

    namespace COFFEE_SHOP_APPLICATION
    {
        internal class payment : generalClass
        {
        public class OrderItem
        {
            public string ProductName { get; set; }
            public int Quantity { get; set; }
        }

        public class OrderDetails
        {
            public string Username { get; set; }
            public DateTime OrderDate { get; set; }
            public decimal Total { get; set; }
            public string Method { get; set; }
            public string OrderCode { get; set; }
            public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        }

        public void Pay(string method, string orderCode, string eatmode)
            {
            if (orderDetails.Count == 0)
            {
                MessageBox.Show("No items in the order!");
                return;
            }

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string getUserQuery = "SELECT UserId FROM Users WHERE Username = ?";
                        using (var userCmd = new OleDbCommand(getUserQuery, connection, transaction))
                        {
                            userCmd.Parameters.AddWithValue("?", Username);
                            var result = userCmd.ExecuteScalar();

                            if (result == null || result == DBNull.Value)
                            {
                                MessageBox.Show("User not found!");
                                return;
                            }

                            UserID = Convert.ToInt32(result);
                        }

                        decimal total = orderDetails.Sum(item => item.Value.subtotal);
                        string status = "tobePaid";

                        string orderQuery = "INSERT INTO Orders (UserId, OrderDate, Total, Status, OrderCode, Method, EatMode) VALUES ( ?, ?, ?, ?, ?, ?, ?)";
                        using (var orderCmd = new OleDbCommand(orderQuery, connection, transaction))
                        {
                            orderCmd.Parameters.Add("UserId", OleDbType.Integer).Value = UserID;
                            orderCmd.Parameters.Add("OrderDate", OleDbType.Date).Value = DateTime.Now;
                            orderCmd.Parameters.Add("Total", OleDbType.Currency).Value = total;
                            orderCmd.Parameters.Add("Status", OleDbType.VarChar).Value = status;
                            orderCmd.Parameters.Add("OrderCode", OleDbType.VarChar).Value = orderCode;
                            orderCmd.Parameters.Add("Method", OleDbType.VarChar).Value = method;
                            orderCmd.Parameters.Add("EatMode", OleDbType.VarChar).Value = eatmode;
                            orderCmd.ExecuteNonQuery();
                        }

                        using (var idCmd = new OleDbCommand("SELECT @@IDENTITY", connection, transaction))
                        {
                            OrderID = Convert.ToInt32(idCmd.ExecuteScalar());
                        }

                        string itemQuery = "INSERT INTO OrderItems (OrderId, ProductId, Quantity, Subtotal) VALUES (?, ?, ?, ?)";
                        foreach (var item in orderDetails)
                        {
                            int productId = GetProductIdByName(item.Key);
                            if (productId <= 0)
                            {
                                throw new Exception($"Product '{item.Key}' not found in database");
                            }

                            using (var itemCmd = new OleDbCommand(itemQuery, connection, transaction))
                            {
                                itemCmd.Parameters.Add("OrderId", OleDbType.Integer).Value = OrderID;
                                itemCmd.Parameters.Add("ProductId", OleDbType.Integer).Value = productId;
                                itemCmd.Parameters.Add("Quantity", OleDbType.Integer).Value = item.Value.quantity;
                                itemCmd.Parameters.Add("Subtotal", OleDbType.Currency).Value = item.Value.subtotal;
                                itemCmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    MessageBox.Show("Order placed, please proceed to the counter.");
                        MessageBox.Show($"Your order number: {orderCode}");
                    orderDetails.Clear();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error processing order: " + ex.Message);
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
        }


        public void counterPayGuest(string method, string orderCode, string eatmode)
        {
            if (orderDetails.Count == 0)
            {
                MessageBox.Show("No items in the order!");
                return;
            }

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        UserID = 8; 

                        decimal total = orderDetails.Sum(item => item.Value.subtotal);
                        string status = "tobePaid";

                        string orderQuery = "INSERT INTO Orders (UserId, OrderDate, Total, Status, OrderCode, Method, EatMode) VALUES (?,?, ?, ?, ?, ?, ?)";
                        using (var orderCmd = new OleDbCommand(orderQuery, connection, transaction))
                        {
                            orderCmd.Parameters.Add("UserId", OleDbType.Integer).Value = UserID;
                            orderCmd.Parameters.Add("OrderDate", OleDbType.Date).Value = DateTime.Now;
                            orderCmd.Parameters.Add("Total", OleDbType.Currency).Value = total;
                            orderCmd.Parameters.Add("Status", OleDbType.VarChar).Value = status;
                            orderCmd.Parameters.Add("OrderCode", OleDbType.VarChar).Value = orderCode;
                            orderCmd.Parameters.Add("Method", OleDbType.VarChar).Value = method;
                            orderCmd.Parameters.Add("EatMode", OleDbType.VarChar).Value = eatmode;
                            orderCmd.ExecuteNonQuery();
                        }

                        using (var idCmd = new OleDbCommand("SELECT @@IDENTITY", connection, transaction))
                        {
                            OrderID = Convert.ToInt32(idCmd.ExecuteScalar());
                        }

                        string itemQuery = "INSERT INTO OrderItems (OrderId, ProductId, Quantity, Subtotal) VALUES (?, ?, ?, ?)";
                        foreach (var item in orderDetails)
                        {
                            int productId = GetProductIdByName(item.Key);
                            if (productId <= 0)
                            {
                                throw new Exception($"Product '{item.Key}' not found in database");
                            }

                            using (var itemCmd = new OleDbCommand(itemQuery, connection, transaction))
                            {
                                itemCmd.Parameters.Add("OrderId", OleDbType.Integer).Value = OrderID;
                                itemCmd.Parameters.Add("ProductId", OleDbType.Integer).Value = productId;
                                itemCmd.Parameters.Add("Quantity", OleDbType.Integer).Value = item.Value.quantity;
                                itemCmd.Parameters.Add("Subtotal", OleDbType.Currency).Value = item.Value.subtotal;
                                itemCmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        MessageBox.Show("Order placed, please proceed to the counter.");
                        orderDetails.Clear();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error processing order: " + ex.Message);
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
        }

        private int GetProductIdByName(string productName)
            {
                using (var connection = GetConnection())
                {
                    string query = "SELECT ProductId FROM Products WHERE ProductName = ?";
                    using (var cmd = new OleDbCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("?", productName);
                        connection.Open();
                        var result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : -1;
                    }
                }
            }

        public void onlinePay(string method, string orderCode, string referenceNum, string eatmode, string totalDIsc)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string getUserQuery = "SELECT UserId FROM Users WHERE Username = ?";
                        using (var userCmd = new OleDbCommand(getUserQuery, connection, transaction))
                        {
                            userCmd.Parameters.AddWithValue("?", Username);
                            var result = userCmd.ExecuteScalar();

                            if (result == null || result == DBNull.Value)
                            {
                                MessageBox.Show("User not found!");
                                return;
                            }

                            UserID = Convert.ToInt32(result);
                        }

                        decimal total;
                        if (decimal.TryParse(totalDIsc.Replace("₱", "").Trim(), out total))
                        {
                            
                        }
                        string status = "tobeApproved";

                        string orderQuery = "INSERT INTO Orders (UserId, OrderDate,Total, Status, OrderCode, Method, ReferenceNumber, EatMode) VALUES (?, ?, ?, ?, ?, ?, ?, ?)";
                        using (var orderCmd = new OleDbCommand(orderQuery, connection, transaction))
                        {
                            orderCmd.Parameters.Add("UserId", OleDbType.Integer).Value = UserID;
                            orderCmd.Parameters.Add("OrderDate", OleDbType.Date).Value = DateTime.Now;
                            orderCmd.Parameters.Add("Total", OleDbType.Currency).Value = total;
                            orderCmd.Parameters.Add("Status", OleDbType.VarChar).Value = status;
                            orderCmd.Parameters.Add("OrderCode", OleDbType.VarChar).Value = orderCode;
                            orderCmd.Parameters.Add("Method", OleDbType.VarChar).Value = method;
                            orderCmd.Parameters.Add("ReferenceNumber", OleDbType.VarChar).Value = referenceNum;
                            orderCmd.Parameters.Add("EatMode", OleDbType.VarChar).Value = eatmode;
                            orderCmd.ExecuteNonQuery();
                        }

                        using (var idCmd = new OleDbCommand("SELECT @@IDENTITY", connection, transaction))
                        {
                            OrderID = Convert.ToInt32(idCmd.ExecuteScalar());
                        }

                        string itemQuery = "INSERT INTO OrderItems (OrderId, ProductId, Quantity, Subtotal) VALUES (?, ?, ?, ?)";
                        string stockUpdateQuery = "UPDATE Products SET Stocks = Stocks - ? WHERE ProductId = ?";

                        foreach (var item in orderDetails)
                        {
                            int productId = GetProductIdByName(item.Key);
                            if (productId <= 0)
                            {
                                throw new Exception($"Product '{item.Key}' not found in database");
                            }

                            // Insert order item
                            using (var itemCmd = new OleDbCommand(itemQuery, connection, transaction))
                            {
                                itemCmd.Parameters.Add("OrderId", OleDbType.Integer).Value = OrderID;
                                itemCmd.Parameters.Add("ProductId", OleDbType.Integer).Value = productId;
                                itemCmd.Parameters.Add("Quantity", OleDbType.Integer).Value = item.Value.quantity;
                                itemCmd.Parameters.Add("Subtotal", OleDbType.Currency).Value = item.Value.subtotal;
                                itemCmd.ExecuteNonQuery();
                            }

                            using (var stockCmd = new OleDbCommand(stockUpdateQuery, connection, transaction))
                            {
                                stockCmd.Parameters.Add("Quantity", OleDbType.Integer).Value = item.Value.quantity;
                                stockCmd.Parameters.Add("ProductId", OleDbType.Integer).Value = productId;
                                stockCmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        orderDetails.Clear();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error processing payment: " + ex.Message);
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
        }

        public void MinusStocksByOrderCode(string orderCode)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string selectOrderItemsQuery = "SELECT ProductId, Quantity FROM OrderItems WHERE OrderId = (SELECT OrderId FROM Orders WHERE OrderCode = ?)";

                        using (var selectCmd = new OleDbCommand(selectOrderItemsQuery, connection, transaction))
                        {
                            selectCmd.Parameters.Add("OrderCode", OleDbType.VarWChar).Value = orderCode;

                            using (var reader = selectCmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int productId = reader.GetInt32(0);
                                    int quantity = reader.GetInt32(1);

                                    // Update stock for the product
                                    string stockUpdateQuery = "UPDATE Products SET Stocks = Stocks - ? WHERE ProductId = ?";
                                    using (var stockCmd = new OleDbCommand(stockUpdateQuery, connection, transaction))
                                    {
                                        stockCmd.Parameters.Add("Quantity", OleDbType.Integer).Value = quantity;
                                        stockCmd.Parameters.Add("ProductId", OleDbType.Integer).Value = productId;
                                        stockCmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error updating stocks: " + ex.Message);
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
        }

    }
}