using COFFEE_SHOP_APPLICATION.GUEST;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using COFFEE_SHOP_APPLICATION.ADMIN;

namespace COFFEE_SHOP_APPLICATION.STAFFS
{
    public partial class Kitchen : Form
    {
        private Dictionary<string, (string username, string orderCode, List<(string productName, int quantity, decimal totalAmount)>)> orderGroups
            = new Dictionary<string, (string, string, List<(string, int, decimal)>)>();
        private Button currentSelectedButton = null; // Track currently selected order button

        public Kitchen()
        {
            InitializeComponent();
        }   

        generalClass gen = new generalClass();

        private void form_Close(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void kitchen_Load(object sender, EventArgs e)
        {
            if (generalClass.Position == "Administrator" || generalClass.Position == "Manager")
            {
                backbtn.Visible = true;
            }
            else
            {
                backbtn.Visible = false;
            }
            LoadAllOrders();
            ResetOrderDetails();
        }

        private void ResetOrderDetails()
        {
            orderDetailstbx.Text = "Select an order to view details";
            statustbx.Text = "No order selected";
            ordNuminput.Text = "";
            totaltbx.Text = "";
            modetbx.Text = "";
            statustbx.ReadOnly = true;
        }

        public void LoadAllOrders()
        {
            orderNumbersflp.Controls.Clear();
            orderGroups.Clear();

            using (var myConn = generalClass.GetConnection())
            {
                myConn.Open();
                string query = "SELECT * FROM tobeServed";
                using (OleDbCommand cmd = new OleDbCommand(query, myConn))
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProcessOrderRecord(reader);
                    }
                }
            }

            CreateOrderButtons();
        }

        private void ProcessOrderRecord(OleDbDataReader reader)
        {
            string orderId = reader["OrderId"].ToString();
            string orderCode = reader["OrderCode"].ToString();
            string username = reader["Username"].ToString();
            string productName = reader["ProductName"].ToString();
            int quantity = int.TryParse(reader["Quantity"].ToString(), out var parsedQuantity) ? parsedQuantity : 0;
            decimal totalAmount = Convert.ToDecimal(reader["Total"]);

            if (!orderGroups.ContainsKey(orderId))
            {
                orderGroups[orderId] = (username, orderCode, new List<(string, int, decimal)>());
            }

            orderGroups[orderId].Item3.Add((productName, quantity, totalAmount));
        }

        private void CreateOrderButtons()
        {
            foreach (var order in orderGroups)
            {
                string orderCode = order.Value.orderCode;

                Button orderButton = new Button
                {
                    Size = new Size(180, 60),
                    BackColor = Color.FromArgb(213, 193, 176),
                    Margin = new Padding(10),
                    Tag = order,
                    Cursor = Cursors.Hand,
                    Text = $"ORDER #{orderCode}",
                    Font = new Font("Tahoma", 12, FontStyle.Bold),
                    ForeColor = Color.FromArgb(73, 54, 40),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                orderButton.Click += OrderButton_Click;
                orderNumbersflp.Controls.Add(orderButton);
            }
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            // Deselect previous button
            if (currentSelectedButton != null)
            {
                currentSelectedButton.BackColor = Color.FromArgb(213, 193, 176);
            }

            // Select new button
            clickedButton.BackColor = Color.FromArgb(180, 160, 140);
            currentSelectedButton = clickedButton;

            ShowOrderDetails(clickedButton);
        }

        private void ShowOrderDetails(Button clickedButton)
        {
            if (clickedButton.Tag == null)
            {
                MessageBox.Show("Order data not found for this button.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var order = (KeyValuePair<string, (string username, string orderCode, List<(string productName, int quantity, decimal totalAmount)>)>)clickedButton.Tag;

            string orderId = order.Key;
            string username = order.Value.username;
            string orderCode = order.Value.orderCode;
            var items = order.Value.Item3;

            StringBuilder details = new StringBuilder();
            decimal grandTotal = 0;

            foreach (var item in items)
            {
                details.AppendLine($"{item.productName} x {item.quantity}");
            }

            orderDetailstbx.Text = details.ToString();
            statustbx.Text = "Preparing";
            totaltbx.Text = $"₱{items[0].totalAmount:F2}";
            ordNuminput.Text = orderCode;

            LoadPaymentAndModeDetails(orderCode);
        }

        private void LoadPaymentAndModeDetails(string orderCode)
        {
            using (var conn = generalClass.GetConnection())
            {
                conn.Open();
                string query = "SELECT EatMode, EatMode FROM Orders WHERE OrderCode = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", orderCode);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            modetbx.Text = reader["EatMode"].ToString();
                        }
                        else
                        {
                            modetbx.Text = "Unknown";
                        }
                    }
                }
            }
        }

        private void ProcessOrder(string orderCode)
        {
            using (var conn = generalClass.GetConnection())
            {
                conn.Open();

                string query = "UPDATE Orders SET Status = ? WHERE OrderCode = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", "served");
                    cmd.Parameters.AddWithValue("?", orderCode);
                    cmd.ExecuteNonQuery();
                }
            }

            LoadAllOrders();
            ResetOrderDetails();
        }

        private decimal GetGrandTotal()
        {
            string totalText = totaltbx.Text.Replace("₱", "").Trim();
            if (decimal.TryParse(totalText, out decimal grandTotal))
            {
                return grandTotal;
            }
            MessageBox.Show("Invalid total amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return 0;
        }

        private void servebutton_Click(object sender, EventArgs e)
        {
            string orderCode = ordNuminput.Text.Trim();

            if (string.IsNullOrEmpty(orderCode))
            {
                MessageBox.Show("Please select an order first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = GetUsernameFromOrder(orderCode);
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Unable to find the user for this order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal grandTotal = GetGrandTotal();
            if (grandTotal == 0) return;

            try
            {
                ProcessOrder(orderCode);
                UpdateUserPoints(grandTotal, username);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetUsernameFromOrder(string orderCode)
        {
            try
            {
                using (var connection = generalClass.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT [Username] FROM [tobeServed] WHERE [OrderCode] = @orderCode";
                    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@orderCode", orderCode);
                        object result = cmd.ExecuteScalar();
                        return result?.ToString() ?? string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving username: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        private void UpdateUserPoints(decimal grandTotal, string userName)
        {
            decimal pointsToAdd = (grandTotal / 50);

            if (pointsToAdd == 0) return;

            try
            {
                using (var connection = generalClass.GetConnection())
                {
                    connection.Open();
                    string updateQuery = "UPDATE [Users] SET [Points] = [Points] + @points WHERE [Username] = @uId";
                    using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, connection))
                    {
                        updateCmd.Parameters.AddWithValue("@points", pointsToAdd);
                        updateCmd.Parameters.AddWithValue("@uId", userName);
                        updateCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating points: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            gen.logOut();
            this.Hide();
        }
        private void LoadOrdersFromTable(string tableName)
        {
            orderNumbersflp.Controls.Clear();
            orderGroups.Clear();

            using (var myConn = generalClass.GetConnection())
            {
                myConn.Open();
                string query = $"SELECT * FROM {tableName}";
                using (OleDbCommand cmd = new OleDbCommand(query, myConn))
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProcessOrderRecord(reader);
                    }
                }
            }
            CreateOrderButtons();
        }

        private void dineInbtn_Click(object sender, EventArgs e)
        {
            LoadOrdersFromTable("DineIn");
        }

        private void takeoutbtn_Click(object sender, EventArgs e)
        {
            LoadOrdersFromTable("TakeOut");
        }

        private void showallorders_Click(object sender, EventArgs e)
        {
            LoadAllOrders();
        }

        private void changePass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            changePassStaff changePass = new changePassStaff();
            changePass.Show();
            this.Hide();
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            MainMenu dashboard = new MainMenu(generalClass.Position);
            dashboard.Show();
            this.Hide();
        }
    }
}