using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using COFFEE_SHOP_APPLICATION.UserControls;
using static COFFEE_SHOP_APPLICATION.payment;
using COFFEE_SHOP_APPLICATION.ADMIN;
using Microsoft.VisualBasic.ApplicationServices;
using COFFEE_SHOP_APPLICATION.Properties;
using System.Reflection.Emit;
using System.Net.Mail;
using System.Net;

namespace COFFEE_SHOP_APPLICATION.STAFFS
{
    public partial class Cashier : Form
    {
            
        public Cashier()
        {
            InitializeComponent();
        }
        private string currentAction = "";
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
            public List<OrderItem> Items { get; set; } = new();
        }

        public static class OrderManager
        {
            public static Dictionary<string, (string username, string orderCode, List<(string productName, int quantity, decimal totalAmount)>)> OrderGroups
            = new();

            public static Dictionary<string, (string username, string orderCode, string referenceNumber, List<(string productName, int quantity, decimal totalAmount)>)> RemoteOrderGroups
        = new();
        }

        private void form_Close(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pay_Load(object sender, EventArgs e)
        {
            if (generalClass.Position == "Administrator" || generalClass.Position == "Manager")
            {
                pictureBox7.Visible = true;
            }
            else
            {
                pictureBox7.Visible = false;
            }
            changePanel.Hide();
            backbtn.Hide();
            confirmationPanel.Hide();
            refundPanel.Hide();
            paymentflp.Controls.Clear();
            paymentflp.Location = new Point(456, 83);
            paymentflp.Size = new Size(844, 627);
            OrderManager.OrderGroups.Clear();

            Dictionary<int, OrderDetails> orders = new();

            using (var conn = generalClass.GetConnection())
            {
                conn.Open();

                string query = @"
                SELECT Orders.OrderId, Users.Username, Users.UserId, Orders.OrderDate, Orders.Total, 
                   Orders.Method, Orders.OrderCode, Products.ProductName, OrderItems.Quantity
                FROM (Users 
                    INNER JOIN Orders ON Users.UserId = Orders.UserId) 
                    INNER JOIN (OrderItems 
                    INNER JOIN Products ON OrderItems.ProductId = Products.ProductId) 
                    ON Orders.OrderId = OrderItems.OrderId 
                WHERE Orders.Status = 'tobePaid'
                ORDER BY Orders.OrderDate;";

                using (var cmd = new OleDbCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int orderId = Convert.ToInt32(reader["OrderId"]);
                        if (!orders.ContainsKey(orderId))
                        {
                            orders[orderId] = new OrderDetails
                            {
                                Username = reader["Username"].ToString(),
                                OrderDate = Convert.ToDateTime(reader["OrderDate"]),
                                Total = Convert.ToDecimal(reader["Total"]),
                                Method = reader["Method"].ToString(),
                                OrderCode = reader["OrderCode"].ToString()
                            };
                        }

                        orders[orderId].Items.Add(new OrderItem
                        {
                            ProductName = reader["ProductName"].ToString(),
                            Quantity = Convert.ToInt32(reader["Quantity"])
                        });
                    }
                }
            }

            foreach (var order in orders.Values)
            {
                var groupedItems = order.Items
                    .GroupBy(i => i.ProductName)
                    .Select(g => (ProductName: g.Key, Quantity: g.Sum(x => x.Quantity), TotalAmount: order.Total)) // You can replace `order.Total` with a per-item subtotal if you have it
                    .ToList();

                OrderManager.OrderGroups[order.OrderCode] = (order.Username, order.OrderCode, groupedItems);
            }
            foreach (var (orderCode, orderData) in OrderManager.OrderGroups)
            {
                Button orderButton = new Button
                {
                    Size = new Size(180, 60),
                    BackColor = Color.FromArgb(213, 193, 176),
                    Margin = new Padding(10),
                    Tag = orderData,
                    Cursor = Cursors.Hand,
                    Text = $"ORDER #{orderCode}",
                    Font = new Font("Tahoma", 12, FontStyle.Bold),
                    ForeColor = Color.FromArgb(73, 54, 40),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                orderButton.Click += (s, e) =>
                {
                    Button clicked = (Button)s;
                    clicked.BackColor = Color.LightGray;
                    ShowOrderDetails(clicked);
                };

                paymentflp.Controls.Add(orderButton);
            }
        }


        private void ShowOrderDetails(Button clickedButton)
        {
            if (clickedButton.Tag is not (string username, string orderCode, List<(string productName, int quantity, decimal totalAmount)> items))
            {
                MessageBox.Show("Order data not found for this button.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StringBuilder details = new();
            foreach (var item in items)
            {
                details.AppendLine($"{item.productName} x {item.quantity}");
            }

            orderDetailstbx.Text = details.ToString();
            statustbx.Text = "Paying";
            totaltbx.Text = $"₱{items[0].totalAmount:F2}";
            ordNuminput.Text = orderCode;

            foreach (Control ctrl in paymentflp.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = btn == clickedButton
                        ? Color.FromArgb(180, 160, 140)
                        : Color.FromArgb(213, 193, 176);
                }
            }

            using (var conn = generalClass.GetConnection())
            {
                conn.Open();
                string query = "SELECT Method, EatMode FROM Orders WHERE OrderCode = ?";
                using var cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("?", orderCode);

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    paymethodtbx.Text = reader["Method"].ToString();
                    modetbx.Text = reader["EatMode"].ToString();
                }
                else
                {
                    paymethodtbx.Text = "Unknown";
                    modetbx.Text = "Unknown";
                }
            }
        }

        public void sendEmailReceipt()
        {
            string orderCode = ordNuminput.Text.Trim();
            if (string.IsNullOrEmpty(orderCode))
            {
                MessageBox.Show("Please select an order first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string customerEmail = "";
            string customerName = "";
            List<(string productName, int quantity)> items = new();
            decimal totalAmount = 0;

            using (var conn = generalClass.GetConnection())
            {
                conn.Open();
                string getUserIdQuery = "SELECT UserId FROM Orders WHERE OrderCode = ?";
                string customerUserId = "";

                using (var getUserCmd = new OleDbCommand(getUserIdQuery, conn))
                {
                    getUserCmd.Parameters.AddWithValue("?", orderCode);
                    var result = getUserCmd.ExecuteScalar();
                    if (result != null)
                    {
                        customerUserId = result.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Customer for this order not found.");
                        return;
                    }
                }

                string getEmailAndNameQuery = "SELECT Contact, Username FROM Users WHERE UserId = ?";
                using (var emailCmd = new OleDbCommand(getEmailAndNameQuery, conn))
                {
                    emailCmd.Parameters.AddWithValue("?", customerUserId);
                    using (var reader = emailCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customerEmail = reader["Contact"].ToString();
                            customerName = reader["Username"].ToString();
                        }
                    }
                }

                string getItemsQuery = "SELECT P.ProductName, OI.Quantity, OI.Subtotal " +
                                       "FROM OrderItems OI INNER JOIN Products P ON OI.ProductId = P.ProductId " +
                                       "WHERE OI.OrderId = (SELECT OrderId FROM Orders WHERE OrderCode = ?)";
                using (var itemCmd = new OleDbCommand(getItemsQuery, conn))
                {
                    itemCmd.Parameters.AddWithValue("?", orderCode);
                    using (var reader = itemCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader["ProductName"].ToString();
                            int qty = Convert.ToInt32(reader["Quantity"]);
                            decimal subtotal = Convert.ToDecimal(reader["Subtotal"]);
                            items.Add((name, qty));
                            totalAmount += subtotal;
                        }
                    }
                }
            }

            if (string.IsNullOrEmpty(customerEmail))
            {
                MessageBox.Show("Customer email not found.");
                return;
            }

            StringBuilder emailBody = new StringBuilder();
            emailBody.AppendLine($"Dear {customerName},");
            emailBody.AppendLine();
            emailBody.AppendLine($"Thank you for your order #{orderCode}.");
            emailBody.AppendLine("Here are your order details:");
            emailBody.AppendLine();

            foreach (var item in items)
            {
                emailBody.AppendLine($"{item.productName} x {item.quantity}");
            }

            emailBody.AppendLine();
            emailBody.AppendLine($"Total: ₱{totalAmount:F2}");
            emailBody.AppendLine();
            emailBody.AppendLine("We hope to serve you again soon!");

            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress("coffeeshopapplication3@gmail.com", "Your Coffee Shop");
                message.To.Add(customerEmail);
                message.Subject = $"Your Receipt for Order #{orderCode}";
                message.Body = emailBody.ToString();

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587); 
                smtp.Credentials = new NetworkCredential("coffeeshopapplication3@gmail.com", "hyxmatvjiykjheze"); 
                smtp.EnableSsl = true;

                smtp.Send(message);
                MessageBox.Show("Receipt sent to customer's email.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send email: " + ex.Message);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)//logOut
        {
            generalClass gen = new generalClass();
            gen.logOut();

            this.Hide();
        }

        private void paybtn_Click(object sender, EventArgs e)
        {
            if(currentAction =="remoteOrder")
            {
                string orderCode = ordNuminput.Text.Trim();
                if (string.IsNullOrEmpty(orderCode))
                {
                    MessageBox.Show("Please select an order first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                sendEmailReceipt();
                ProcessOrder(orderCode, "paid");
                return;
            }
            if (string.IsNullOrEmpty(ordNuminput.Text.Trim()))
            {
                MessageBox.Show("Please select an order first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!float.TryParse(totaltbx.Text.Replace("₱", "").Trim(), out float total))
            {
                MessageBox.Show("Invalid total amount.");
                return;
            }

            backbtn.Show();
            paymentflp.Location = new Point(1052, 46);
            paymentflp.Size = new Size(253, 664);
            changePanel.Show();
            changePanel.Location = new Point(487, 191);

            cashbox.Text = "";
            changebox.Text = "";

            cashbox.TextChanged -= Cashbox_TextChanged;
            cashbox.TextChanged += Cashbox_TextChanged;

            changebox.Tag = total;


        }

        private void Cashbox_TextChanged(object sender, EventArgs e)
        {
            if (!(changebox.Tag is float total)) return;

            if (float.TryParse(cashbox.Text, out float cash))
            {
                float change = cash - total;
                changebox.Text = change >= 0 ? $"₱{change:F2}" : "Insufficient amount";
            }
            else
            {
                changebox.Text = "Invalid input";
            }
        }


        private void PrintReceipt(string orderCode, decimal cash, decimal change)
        {
            orderCode = orderCode.Trim();

            if (!OrderManager.OrderGroups.ContainsKey(orderCode))
            {
                MessageBox.Show("Order not found.");
                return;
            }

            var order = OrderManager.OrderGroups[orderCode];
            var items = order.Item3;
            decimal total = items.FirstOrDefault().totalAmount; // Use stored total amount once

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += (s, e) =>
            {
                float yPos = 10;
                int leftMargin = 10;
                Font printFont = new Font("Courier New", 10);

                e.Graphics.DrawString("COFFEE SHOP RECEIPT", new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, leftMargin, yPos);
                yPos += 30;

                e.Graphics.DrawString($"Order #: {order.orderCode}", printFont, Brushes.Black, leftMargin, yPos);
                yPos += 20;

                e.Graphics.DrawString($"Customer: {order.username}", printFont, Brushes.Black, leftMargin, yPos);
                yPos += 30;

                foreach (var item in items)
                {
                    string line = $"{item.productName} x{item.quantity}";
                    e.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos);
                    yPos += 20;
                }

                yPos += 10;
                e.Graphics.DrawString($"Total: ₱{total:F2}", printFont, Brushes.Black, leftMargin, yPos);
                yPos += 20;

                e.Graphics.DrawString($"Cash: ₱{cash:F2}", printFont, Brushes.Black, leftMargin, yPos);
                yPos += 20;

                e.Graphics.DrawString($"Change: ₱{change:F2}", printFont, Brushes.Black, leftMargin, yPos);
                yPos += 30;

                e.Graphics.DrawString("Thank you!", printFont, Brushes.Black, leftMargin, yPos);
            };

            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = printDoc;
            preview.ShowDialog();
            printDoc.Print();
        }



        private void ProcessOrder(string orderCode, string status)
        {
            using (var conn = generalClass.GetConnection())
            {
                conn.Open();

                string query = "UPDATE Orders SET Status = ? WHERE OrderCode = ?";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", status);
                    cmd.Parameters.AddWithValue("?", orderCode);

                    cmd.ExecuteNonQuery();
                }
            }
            if (currentAction == "paid")
            {
                return;
            }
            else
            {
                pay_Load(sender: null, e: null);
            }
            
        }

        private void donebtn_Click(object sender, EventArgs e)
        {
            currentAction = "paid";
            string orderCode = ordNuminput.Text.Trim();

            if (!OrderManager.OrderGroups.ContainsKey(orderCode))
            {
                MessageBox.Show("Order not found.");
                return;
            }

            // Get total from order
            var order = OrderManager.OrderGroups[orderCode];
            decimal totalAmount = order.Item3.FirstOrDefault().totalAmount;

            // Parse inputted cash
            if (!decimal.TryParse(cashbox.Text.Trim(), out decimal cash))
            {
                MessageBox.Show("Please enter a valid amount of cash.");
                return;
            }

            if (cash < totalAmount)
            {
                MessageBox.Show("Insufficient payment. Please enter enough cash.");
                return;
            }

            // Calculate change and display it
            decimal change = cash - totalAmount;
            changebox.Text = $"₱{change:F2}";

            // Get Method and EatMode from DB
            string method = string.Empty;
            string eatmode = string.Empty;

            using (var connection = generalClass.GetConnection())
            {
                connection.Open();

                string query = "SELECT Method, EatMode FROM Orders WHERE OrderCode = ?";

                using (var cmd = new OleDbCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("?", orderCode);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            method = reader["Method"].ToString();
                            eatmode = reader["EatMode"].ToString();
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(method) && !string.IsNullOrEmpty(eatmode))
            {
                ProcessOrder(orderCode, "paid");
                payment pay = new payment();
                pay.MinusStocksByOrderCode(orderCode);
                paymentflp.Location = new Point(461, 46);
                paymentflp.Size = new Size(844, 627);
                pay_Load(sender: null, e: null);
            }
            else
            {
                MessageBox.Show("Order details not found!");
            }
        }


        private void receiptbtn_Click(object sender, EventArgs e)
        {
            string orderCode = ordNuminput.Text.Trim();

            if (string.IsNullOrEmpty(orderCode))
            {
                MessageBox.Show("Please select an order first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(cashbox.Text, out decimal cash))
            {
                MessageBox.Show("Invalid cash input.");
                return;
            }

            var order = OrderManager.OrderGroups[orderCode];
            decimal total = order.Item3.FirstOrDefault().totalAmount;
            decimal change = cash - total;

            if (change < 0)
            {
                MessageBox.Show("Insufficient payment.");
                return;
            }

            PrintReceipt(orderCode, cash, change);
        }


        private void button1_Click(object sender, EventArgs e)//cancel button
        {
            backbtn.Show();

            confirmationPanel.Show();
            confirmationPanel.Location = new Point(574, 191);
            confirmationPanel.BringToFront();

            
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            paymentflp.Location = new Point(461, 46);
            paymentflp.Size = new Size(844, 627);
            pay_Load(sender: null, e: null);
        }

        private void confirmrc_Click(object sender, EventArgs e)
        {
            backbtn.Show();
            changePanel.Hide();
            refundPanel.Hide();
            confirmationPanel.Show();
            confirmationPanel.Location = new Point(574, 191);
        }

        private void donebutton_Click(object sender, EventArgs e)
        {
            3string firstName = adminName.Text.Trim();
            string Code = code.Text.Trim();

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(Code))
            {
                MessageBox.Show("Please enter both name and code.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsCancellationAuthorized(firstName, Code))
            {
                MessageBox.Show("Authorization failed. Name or code is invalid.",
                                "Not Authorized", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (currentAction == "awaitingPayments")
            {
                ProcessOrder(ordNuminput.Text.Trim(), "cancelled");
            }
            else if (currentAction == "pendingCancellation")
            {
                cancelOrder();
            }
            else if (currentAction == "pendingRefund")
            {
                int orderCode = Convert.ToInt32(ordNuminput.Text.Trim());

                using (var conn = generalClass.GetConnection())
                {
                    conn.Open();
                    string updateQuery = "UPDATE CancelledOrders " +
                          "SET Status = ? " +
                          "WHERE OrderCode = ?";

                    using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("?", "Cancelled");
                        updateCmd.Parameters.AddWithValue("?", orderCode);

                        updateCmd.ExecuteNonQuery();
                    }
                }
                ProcessOrder(ordNuminput.Text.Trim(), "cancelled");
                refundbutton_Click(sender, e);
            }

            code.Text = "";
            adminName.Text = "";
            backbtn_Click(sender, e);
        }

        private bool IsCancellationAuthorized(string firstName, string code)
        {
            using (var conn = generalClass.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT COUNT(*) 
                       FROM Staffs 
                       WHERE FirstName = ? 
                         AND [Code] = ? ";

                using (var cmd = new OleDbCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("?", firstName);
                    cmd.Parameters.AddWithValue("?", code);

                    int matches = Convert.ToInt32(cmd.ExecuteScalar());
                    return matches > 0;
                }
            }
        }

        private void cancelOrder()
        {
            string orderCode = ordNuminput.Text.Trim();
            if (string.IsNullOrEmpty(orderCode))
            {
                MessageBox.Show("No order selected to cancel.");
                return;
            }

            if (!OrderManager.OrderGroups.ContainsKey(orderCode))
            {
                MessageBox.Show("Order not found in memory.");
                return;
            }

            var order = OrderManager.OrderGroups[orderCode];
            var items = order.Item3;
            string username = order.username;
            int userId;

            decimal totalAmount = items.Sum(item => item.totalAmount); // Sum of all item totals in the order

            using (var conn = generalClass.GetConnection())
            {
                conn.Open();
                string getUserIdQuery = "SELECT UserId FROM Users WHERE Username = ?";
                using (OleDbCommand getUserCmd = new OleDbCommand(getUserIdQuery, conn))
                {
                    getUserCmd.Parameters.AddWithValue("?", username);
                    using (OleDbDataReader reader = getUserCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userId = Convert.ToInt32(reader["UserId"]);
                        }
                        else
                        {
                            MessageBox.Show("User ID not found.");
                            return;
                        }
                    }
                }

                string insertQuery = "INSERT INTO CancelledOrders (OrderCode, UserId, StaffID, Total, CancelDate, Status) " +
                                     "VALUES (?, ?, ?, ?, ?, ?)";

                using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, conn))
                {
                    insertCmd.Parameters.AddWithValue("?", orderCode);
                    insertCmd.Parameters.AddWithValue("?", userId);
                    insertCmd.Parameters.AddWithValue("?", generalClass.UserID); 
                    insertCmd.Parameters.AddWithValue("?", totalAmount);
                    insertCmd.Parameters.AddWithValue("?", DateTime.Now);
                    insertCmd.Parameters.AddWithValue("?", "Pending Refund"); 

                    insertCmd.ExecuteNonQuery();
                }

            }

            MessageBox.Show($"Order #{orderCode} cancelled and recorded.");
            AddStock(orderCode);
            SendRefundEmail(orderCode, totalAmount, username);

            ProcessOrder(ordNuminput.Text.Trim(), "Refund");
            pay_Load(null, null);
        }
        private void AddStock(string orderCode)
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

                    string getItemsQuery = "SELECT ProductId, Quantity FROM OrderItems WHERE OrderId = ?";
                    using (var cmd = new OleDbCommand(getItemsQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("?", orderId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int productId = Convert.ToInt32(reader["ProductId"]);
                                int quantity = Convert.ToInt32(reader["Quantity"]);

                                string restoreStockQuery = "UPDATE Products SET Stocks = Stocks + ? WHERE ProductId = ?";
                                using (var restoreCmd = new OleDbCommand(restoreStockQuery, connection))
                                {
                                    restoreCmd.Parameters.AddWithValue("?", quantity);
                                    restoreCmd.Parameters.AddWithValue("?", productId);
                                    restoreCmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during cancellation: " + ex.Message);
            }
        }

        private void SendRefundEmail(string orderCode, decimal amount, string username)
        {
            string userEmail = "";

            using (var conn = generalClass.GetConnection())
            {
                conn.Open();
                string getEmailQuery = "SELECT Contact FROM Users WHERE Username = ?";
                using (OleDbCommand cmd = new OleDbCommand(getEmailQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", username);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userEmail = reader["Contact"].ToString();
                        }
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(userEmail))
            {
                MessageBox.Show("Email address not found for the user.");
                return;
            }

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("coffeeshopapplication3@gmail.com");
                mail.To.Add(userEmail);
                mail.Subject = $"Refund Notification - Order #{orderCode}";
                mail.Body = $"Dear {username},\n\nYour order #{orderCode} has been cancelled.\nRefund Amount: ₱{amount:F2}\n\nPlease go to the store for refund.\n\nWe apologize for the inconvenience. If you have any questions, feel free to contact us.\n\n- Coffee Shop Team";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587; 
                smtp.Credentials = new NetworkCredential("coffeeshopapplication3@gmail.com", "hyxmatvjiykjheze");
                smtp.EnableSsl = true;

                smtp.Send(mail);
                MessageBox.Show("Refund notification email sent.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send email: " + ex.Message);
            }
        }


        private void pendingCancellation_Click(object sender, EventArgs e)
        {
            panel7.Size = new Size(432, 421);
            panel7.Location = new Point(3, 173);
            panel7.BringToFront();
            paymentflp.Location = new Point(456, 83);
            paymentflp.Size = new Size(844, 627);
            currentAction = "pendingCancellation";
            button1.Enabled = true;
            paybtn.Enabled = false;
            changePanel.Hide();
            backbtn.Hide();
            confirmationPanel.Hide();
            paymentflp.Controls.Clear();
            refundPanel.Hide();
            OrderManager.OrderGroups.Clear();

            using (var myConn = generalClass.GetConnection())
            {
                myConn.Open();
                string query = "SELECT * FROM toBeCancelled";
                using (OleDbCommand cmd = new OleDbCommand(query, myConn))
                {
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string orderId = reader["OrderId"].ToString();
                            string orderCode = reader["OrderCode"].ToString();
                            string username = reader["Username"].ToString();
                            string productName = reader["ProductName"].ToString();
                            int quantity = int.TryParse(reader["Quantity"].ToString(), out var parsedQuantity) ? parsedQuantity : 0;
                            decimal totalAmount = decimal.TryParse(reader["Total"].ToString(), out var parsedTotal) ? parsedTotal : 0;

                            if (!OrderManager.OrderGroups.ContainsKey(orderCode))
                            {
                                OrderManager.OrderGroups[orderCode] = (username, orderCode, new List<(string, int, decimal)>());
                            }
                            OrderManager.OrderGroups[orderCode].Item3.Add((productName, quantity, totalAmount));
                        }
                    }
                }
            }

            foreach (var order in OrderManager.OrderGroups)
            {
                string orderId = order.Key;
                var orderData = order.Value;
                string username = orderData.username;
                string orderCode = orderData.orderCode;
                var items = orderData.Item3;

                Button cancelledOrders = new Button();
                cancelledOrders.Size = new Size(180, 60);
                cancelledOrders.BackColor = Color.FromArgb(213, 193, 176);
                cancelledOrders.Margin = new Padding(10);
                cancelledOrders.Tag = order;
                cancelledOrders.Cursor = Cursors.Hand;
                cancelledOrders.Text = $"ORDER #{orderCode}";
                cancelledOrders.Font = new Font("Tahoma", 12, FontStyle.Bold);
                cancelledOrders.ForeColor = Color.FromArgb(73, 54, 40);
                cancelledOrders.TextAlign = ContentAlignment.MiddleCenter;

                cancelledOrders.Click += (s, e) =>
                {
                    Button clicked = (Button)s;
                    clicked.BackColor = Color.LightGray;
                    ShowCancelledOrderDetails(clicked);
                };

                paymentflp.Controls.Add(cancelledOrders);
            }
        }

        private void awaitingpaymentsbtn_Click(object sender, EventArgs e)
        {
            panel7.Size = new Size(432, 421);
            panel7.Location = new Point(3, 173);
            panel7.BringToFront();
            paybtn.Text = "Pay";
            currentAction = "awaitingPayments";
            button1.Enabled = true;
            paybtn.Enabled = true;
            pay_Load(sender: null, e: null);
        }

        private void changePass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            changePassStaff changePass = new changePassStaff();
            changePass.Show();
            this.Hide();
        }

        private void ShowCancelledOrderDetails(Button clickedButton)
        {
            if (clickedButton.Tag is not KeyValuePair<string, (string username, string orderCode, List<(string productName, int quantity, decimal totalAmount)>)> taggedData)
            {
                MessageBox.Show("Order data not found for this button.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var (orderCode, orderData) = taggedData;
            var items = orderData.Item3;

            StringBuilder details = new();
            foreach (var item in items)
            {
                details.AppendLine($"{item.productName} x {item.quantity}");
            }

            orderDetailstbx.Text = details.ToString();
            statustbx.Text = "Cancelling";
            totaltbx.Text = $"₱{items[0].totalAmount:F2}";
            ordNuminput.Text = orderCode;

            foreach (Control ctrl in paymentflp.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = btn == clickedButton
                        ? Color.FromArgb(180, 160, 140)
                        : Color.FromArgb(213, 193, 176);
                }
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)//back to dashboard
        {
            MainMenu dashboard = new MainMenu(generalClass.Position);
            dashboard.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = ((TextBox)sender).Text.Trim().ToLower();

            foreach (Control control in paymentflp.Controls)
            {
                if (control is Button orderButton)
                {
                    string username = "";
                    string orderCode = "";

                    if (orderButton.Tag is ValueTuple<string, string, List<(string, int, decimal)>> tupleTag)
                    {
                        username = tupleTag.Item1;
                        orderCode = tupleTag.Item2;
                    }
                    else if (orderButton.Tag is KeyValuePair<string, (string username, string orderCode, List<(string, int, decimal)> items)> kvpTag)
                    {
                        username = kvpTag.Value.username;
                        orderCode = kvpTag.Value.orderCode;
                    }
                    else
                    {
                        continue;
                    }

                    bool matches = username.ToLower().Contains(searchTerm) ||
                                   orderCode.ToLower().Contains(searchTerm);

                    orderButton.Visible = matches;
                }
            }
        }

        private void refundbutton_Click(object sender, EventArgs e)
        {
            panel7.Size = new Size(432, 421);
            panel7.Location = new Point(3, 173);
            panel7.BringToFront();
            adminName.Text = "";
            code.Text = "";
            currentAction = "pendingRefund";
            paymentflp.Location = new Point(456, 83);
            paymentflp.Size = new Size(844, 627);
            button1.Enabled = false;
            paybtn.Enabled = false;
            changePanel.Hide();
            backbtn.Hide();
            confirmationPanel.Hide();
            paymentflp.Controls.Clear();
            refundPanel.Hide();
            OrderManager.OrderGroups.Clear();

            using (var myConn = generalClass.GetConnection())
            {
                myConn.Open();
                string query = "SELECT * FROM RefundQuery";
                using (OleDbCommand cmd = new OleDbCommand(query, myConn))
                {
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string userId = reader["UserId"].ToString();
                            string orderCode = reader["OrderCode"].ToString();
                            string username = reader["Username"].ToString();
                            string productName = reader["ProductName"].ToString();
                            int quantity = int.TryParse(reader["Quantity"].ToString(), out var parsedQuantity) ? parsedQuantity : 0;
                            decimal totalAmount = decimal.TryParse(reader["Total"].ToString(), out var parsedTotal) ? parsedTotal : 0;

                            if (!OrderManager.OrderGroups.ContainsKey(orderCode))
                            {
                                OrderManager.OrderGroups[orderCode] = (username, orderCode, new List<(string, int, decimal)>());
                            }
                            OrderManager.OrderGroups[orderCode].Item3.Add((productName, quantity, totalAmount));
                        }
                    }
                }
            }

            foreach (var order in OrderManager.OrderGroups)
            {
                string orderId = order.Key;
                var orderData = order.Value;
                string username = orderData.username;
                string orderCode = orderData.orderCode;
                var items = orderData.Item3;

                Button cancelledOrders = new Button();
                cancelledOrders.Size = new Size(180, 60);
                cancelledOrders.BackColor = Color.FromArgb(213, 193, 176);
                cancelledOrders.Margin = new Padding(10);
                cancelledOrders.Tag = order;
                cancelledOrders.Cursor = Cursors.Hand;
                cancelledOrders.Text = $"ORDER #{orderCode}";
                cancelledOrders.Font = new Font("Tahoma", 12, FontStyle.Bold);
                cancelledOrders.ForeColor = Color.FromArgb(73, 54, 40);
                cancelledOrders.TextAlign = ContentAlignment.MiddleCenter;

                cancelledOrders.Click += (s, e) =>
                {
                    Button clicked = (Button)s;
                    clicked.BackColor = Color.LightGray;
                    paymentflp.Location = new Point(1052, 46);
                    paymentflp.Size = new Size(290, 664);
                    refundPanel.Show();
                    amountbox.Text = $"₱{items[0].totalAmount:F2}";
                    ShowCancelledOrderDetails(clicked);
                };

                paymentflp.Controls.Add(cancelledOrders);
            }
        }
        private void remoteOrderbtn_Click(object sender, EventArgs e)
        {
            currentAction = "remoteOrder";
            button1.Enabled = false;
            paybtn.Text = "Accept";
            paybtn.Enabled = true;

            Panel referencepanel = new Panel();
            referencepanel.BackColor = Color.FromArgb(238, 230, 223);
            referencepanel.ForeColor = Color.Black;
            referencepanel.Location = new Point(3, 173);
            referencepanel.Name = "referencepanel";
            referencepanel.Size = new Size(432, 43);
            referencepanel.TabIndex = 5;

            System.Windows.Forms.Label label4 = new System.Windows.Forms.Label();
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            label4.Location = new Point(42, 10);
            label4.Name = "label4";
            label4.Size = new Size(167, 24);
            label4.TabIndex = 4;
            label4.Text = "Reference Num";

            TextBox refNumtbx = new TextBox();
            refNumtbx.BackColor = Color.FromArgb(238, 230, 223);
            refNumtbx.BorderStyle = BorderStyle.None;
            refNumtbx.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            refNumtbx.Location = new Point(238, 12);
            refNumtbx.Name = "refNumtbx";
            refNumtbx.Size = new Size(191, 25);
            refNumtbx.TabIndex = 4;
            refNumtbx.TextAlign = HorizontalAlignment.Right;

            PictureBox pictureBox8 = new PictureBox();
            pictureBox8.Image = Image.FromFile("C:\\Users\\ann\\Downloads\\credit-card.png");
            pictureBox8.Location = new Point(11, 16);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(25, 18);
            pictureBox8.TabIndex = 2;
            pictureBox8.TabStop = false;

            kitchenPanel.Controls.Add(referencepanel);
            referencepanel.Controls.Add(label4);
            referencepanel.Controls.Add(refNumtbx);
            referencepanel.Controls.Add(pictureBox8);

            panel7.Location = new Point(3, 219);
            panel7.Size = new Size(432, 375);

            OrderManager.RemoteOrderGroups.Clear();

            using (var myConn = generalClass.GetConnection())
            {
                myConn.Open();
                string query = "SELECT * FROM RemoteOrders";
                using (OleDbCommand cmd = new OleDbCommand(query, myConn))
                {
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string orderCode = reader["OrderCode"].ToString();
                            string username = reader["Username"].ToString();
                            string productName = reader["ProductName"].ToString();
                            int quantity = int.TryParse(reader["Quantity"].ToString(), out var parsedQuantity) ? parsedQuantity : 0;
                            string reference = reader["ReferenceNumber"].ToString();
                            decimal totalAmount = decimal.TryParse(reader["Total"].ToString(), out var parsedTotal) ? parsedTotal : 0;

                            if (!OrderManager.RemoteOrderGroups.ContainsKey(orderCode))
                            {
                                OrderManager.RemoteOrderGroups[orderCode] = (username, orderCode, reference, new List<(string, int, decimal)>());
                            }
                            OrderManager.RemoteOrderGroups[orderCode].Item4.Add((productName, quantity, totalAmount));
                        }
                    }
                }
            }

            paymentflp.Controls.Clear();  // Clear previous buttons

            foreach (var order in OrderManager.RemoteOrderGroups)
            {
                string orderCode = order.Key;
                var orderData = order.Value;
                string username = orderData.username;
                string reference = orderData.referenceNumber;
                var items = orderData.Item4;

                Button approvedOrder = new Button();
                approvedOrder.Size = new Size(180, 60);
                approvedOrder.BackColor = Color.FromArgb(213, 193, 176);
                approvedOrder.Margin = new Padding(10);
                approvedOrder.Tag = new Tuple<KeyValuePair<string, (string username, string orderCode, string referenceNumber, List<(string productName, int quantity, decimal totalAmount)>)>, TextBox>(order, refNumtbx);  // Store the order data and refNumtbx in Tag
                approvedOrder.Cursor = Cursors.Hand;
                approvedOrder.Text = $"ORDER #{orderCode}";
                approvedOrder.Font = new Font("Tahoma", 12, FontStyle.Bold);
                approvedOrder.ForeColor = Color.FromArgb(73, 54, 40);
                approvedOrder.TextAlign = ContentAlignment.MiddleCenter;

                approvedOrder.Click += (s, e) =>
                {
                    Button clicked = (Button)s;
                    clicked.BackColor = Color.LightGray;
                    ShowApprovalOrderDetails(clicked);  // Pass the clicked button to the handler
                };

                paymentflp.Controls.Add(approvedOrder);
            }
        }

        private void ShowApprovalOrderDetails(Button clickedButton)
        {
            if (clickedButton.Tag is not Tuple<KeyValuePair<string, (string username, string orderCode, string referenceNumber, List<(string productName, int quantity, decimal totalAmount)>)>, TextBox> taggedData)
            {
                MessageBox.Show("Order data not found for this button.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var (order, refNumtbx) = taggedData;
            var orderCode = order.Key;
            var orderData = order.Value;
            var items = orderData.Item4;

            StringBuilder details = new();
            foreach (var item in items)
            {
                details.AppendLine($"{item.productName} x {item.quantity} ");
            }

            orderDetailstbx.Text = details.ToString();
            statustbx.Text = "To Accept";
            totaltbx.Text = $"₱{items.First().totalAmount:F2}";
            paymethodtbx.Text = "";
            ordNuminput.Text = orderCode;
            statustbx.Text = "Accepting";
            refNumtbx.Text = orderData.referenceNumber; 

            foreach (Control ctrl in paymentflp.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = btn == clickedButton
                        ? Color.FromArgb(180, 160, 140)
                        : Color.FromArgb(213, 193, 176);
                }
            }
        }

    }
}
