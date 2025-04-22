using COFFEE_SHOP_APPLICATION.UserControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace COFFEE_SHOP_APPLICATION.CUSTOMER
{
    public partial class History : Form
    {
        string Username = generalClass.Username;

        public History()
        {
            InitializeComponent();
        }

        private void menutab_Click(object sender, EventArgs e)
        {
            OrderingGuest ordering = new OrderingGuest();
            ordering.Show();
            this.Hide();
        }

        private void History_Close(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void History_Load(object sender, EventArgs e)
        {
            label3.Hide();
            tobeCancelled.Hide();
            LoadOrderHistory("served", pastordersflp, "his");
            LoadOrderHistory("paid", ongoingflp, "ongo");
            if(!CheckIfToBeCancelledExists())
            {
                tobeCancelled.Visible = false;
            }
            else
            {
                label3.Show();
                ongoingflp.Size = new Size(392, 420);
                tobeCancelled.Visible = true;

                LoadOrderHistory("ToBeCancelled", tobeCancelled, "canc");
            }
        }

        public bool CheckIfToBeCancelledExists()
        {
            try
            {
                using (var connection = generalClass.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM [Orders] WHERE [UserId] = ? AND [Status] = ?";
                    using (var cmd = new OleDbCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("?", generalClass.UserID);
                        cmd.Parameters.AddWithValue("?", "ToBeCancelled");

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking for ToBeCancelled orders: " + ex.Message);
                return false;
            }
        }

        private void LoadOrderHistory(string status, FlowLayoutPanel targetPanel, string what)
        {
            try
            {
                using (var connection = generalClass.GetConnection())
                {
                    connection.Open();

                    var orderGroups = new Dictionary<string,
                        (string date, string method, List<(string productName, int quantity, decimal price)>)>();

                    string query = @"SELECT [OrderId], [OrderDate], [Method], [ProductName], [Quantity], [Price], [OrderCode]
                             FROM [History] 
                             WHERE [Username] = ? AND [Status] = ? 
                             ORDER BY [OrderId], [OrderDate]";

                    using (var cmd = new OleDbCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("?", Username);
                        cmd.Parameters.AddWithValue("?", status);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string orderId = reader["OrderId"].ToString();
                                string orderCode = reader["OrderCode"].ToString();
                                string date = reader["OrderDate"].ToString();
                                string method = reader["Method"].ToString();
                                string product = reader["ProductName"].ToString();
                                int quantity = Convert.ToInt32(reader["Quantity"]);
                                decimal price = Convert.ToDecimal(reader["Price"]);

                                // If the orderCode doesn't exist in the dictionary, create a new entry
                                if (!orderGroups.ContainsKey(orderCode))
                                {
                                    orderGroups[orderCode] = (
                                        date,
                                        method,
                                        new List<(string, int, decimal)>()
                                    );
                                }

                                // Add product info to the respective order group
                                orderGroups[orderCode].Item3.Add((product, quantity, price));
                            }
                        }
                    }

                    targetPanel.Controls.Clear(); // Clear old controls

                    foreach (var order in orderGroups)
                    {
                        var orderCode = order.Key;
                        var date = order.Value.date;
                        var method = order.Value.method;

                        var itemList = order.Value.Item3
                            .Select(item => (item.productName, item.quantity, item.price, date, method))
                            .ToList();

                        var orderControl = CreateOrderControl(orderCode, itemList, what);
                        targetPanel.Controls.Add(orderControl);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading order history: " + ex.Message);
            }
        }
        Control CreateOrderControl(string orderCode, List<(string productName, int quantity, decimal price, string date, string method)> items, string what)
        {
            StringBuilder itemList = new StringBuilder();
            decimal orderTotal = 0;
            string date = items[0].date;
            string method = items[0].method;

            // Build item list with proper calculations
            foreach (var item in items)
            {
                decimal lineTotal = item.price;
                itemList.AppendLine($"{item.productName} x {item.quantity} - ₱{lineTotal:F2}");
                orderTotal += lineTotal;
            }

            Control control;

            if (what == "his") // History
            {
                var pastControl = new pastOrders();
                pastControl.BackColor = Color.White;
                pastControl.OrderCode = $"Order #{orderCode}";
                pastControl.OrderItems = itemList.ToString();
                pastControl.TotalAmount = $"₱{orderTotal:F2}";
                pastControl.OrderDate = Convert.ToDateTime(date).ToShortDateString();
                pastControl.ReorderClicked += (s, e) => HandleReorder(orderCode);
                control = pastControl;
            }
            else if (what == "ongo") // Ongoing
            {
                var ongoingControl = new ongoingorders();
                ongoingControl.BackColor = Color.White;
                ongoingControl.OrderCode = $"Order #{orderCode}";
                ongoingControl.OrderItems = itemList.ToString();
                ongoingControl.TotalAmount = $"₱{orderTotal:F2}";
                ongoingControl.OrderDate = Convert.ToDateTime(date).ToShortDateString();
                ongoingControl.ReorderClicked += (s, e) => CancelOrder(orderCode);
                control = ongoingControl;
            }
            else // ToBeCancelled
            {
                var cancelledControl = new canceOrder();
                cancelledControl.BackColor = Color.LightGray;
                cancelledControl.OrderCode = $"Order #{orderCode}";
                cancelledControl.OrderItems = itemList.ToString();
                cancelledControl.OrderDate = Convert.ToDateTime(date).ToShortDateString();
                control = cancelledControl;
            }

            return control;
        }
        private void HandleReorder(string orderId)
        {
            try
            {
                using (var connection = generalClass.GetConnection())
                {
                    connection.Open();

                    // Corrected query: use OrderId, not OrderCode
                    string query = "SELECT [ProductName], [Quantity], [Price] FROM [History] WHERE [OrderCode] = ?";
                    using (var cmd = new OleDbCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("?", orderId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            generalClass.orderDetails.Clear();
                            List<string> unavailableProducts = new List<string>();

                            while (reader.Read())
                            {
                                string productName = reader["ProductName"].ToString();
                                int quantity = Convert.ToInt32(reader["Quantity"]);
                                decimal unitPrice = Convert.ToDecimal(reader["Price"]); // Using 'price' instead of 'Total'

                                // Calculate the subtotal by multiplying unit price with quantity
                                decimal subtotal = unitPrice * quantity;

                                // Check if product is still available
                                if (IsProductAvailable(connection, productName))
                                {
                                    generalClass.orderDetails[productName] = (quantity, subtotal);
                                }
                                else
                                {
                                    unavailableProducts.Add(productName);
                                }
                            }

                            // Handle unavailable items
                            if (unavailableProducts.Count > 0)
                            {
                                string message = "The following items are no longer available and won't be added to your order:\n";
                                message += string.Join("\n", unavailableProducts);
                                message += "\n\nContinue with the remaining items?";

                                var result = MessageBox.Show(message, "Some Items Unavailable",
                                                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                                if (result == DialogResult.No)
                                {
                                    generalClass.orderDetails.Clear();
                                    return;
                                }
                            }
                        }
                    }
                }

                // Proceed if there are valid items to reorder
                if (generalClass.orderDetails.Count > 0)
                {
                    
                }
                else
                {
                    MessageBox.Show("None of the items in this order are currently available.", "No Items Available",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading order history: " + ex.Message);
            }
        }


        private bool IsProductAvailable(OleDbConnection connection, string productName)
        {
            string query = "SELECT Status FROM Products WHERE ProductName = ?";

            using (var cmd = new OleDbCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("?", productName);
                object result = cmd.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                    return false;

                string status = result.ToString();
                return status.Equals("Available", StringComparison.OrdinalIgnoreCase);
            }
        }

        private void CancelOrder(string orderCode)
        {
            try
            {
                using (var connection = generalClass.GetConnection())
                {
                    connection.Open();

                    string getOrderIdQuery = "SELECT OrderId FROM Orders WHERE OrderCode = ?";
                    int orderId = -1;

                    using (var cmd = new OleDbCommand(getOrderIdQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("?", orderCode);
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            orderId = Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show("Order not found.");
                            return;
                        }
                    }

                    string updateStatusQuery = "UPDATE Orders SET Status = ? WHERE OrderCode = ?";
                    using (var updateCmd = new OleDbCommand(updateStatusQuery, connection))
                    {
                        updateCmd.Parameters.AddWithValue("?", "ToBeCancelled");
                        updateCmd.Parameters.AddWithValue("?", orderCode);
                        updateCmd.ExecuteNonQuery();
                    }
                }

                ongoingflp.Controls.Clear();
                History_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during cancellation: " + ex.Message);
            }
        }

    }
}
