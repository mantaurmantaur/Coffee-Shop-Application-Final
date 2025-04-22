using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.Design.IUIService;
using static COFFEE_SHOP_APPLICATION.profile;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Diagnostics.Metrics;

namespace COFFEE_SHOP_APPLICATION.CUSTOMER
{
    public partial class PaymentGuest : Form
    {
        string paymentMethod = "";
        public PaymentGuest()
        {
            InitializeComponent();
        }
        private void payment_Load(object sender, EventArgs e)
        {
            gcashPanel.Hide();  
            if (generalClass.Username == "Guest")
            {
                discountcbx.Enabled = false;
                gcashbtn.Enabled = false;

                if (generalClass.orderDetails.Any())
                {
                    ordrnumtbx.Text = generalClass.OrderID > 0
                        ? generalClass.OrderID.ToString()
                        : generalClass.GenerateTempOrderId();

                    gcashPanel.Hide();

                    StringBuilder sb = new StringBuilder();
                    decimal grandTotal = 0;

                    foreach (var item in generalClass.orderDetails)
                    {
                        string productName = item.Key;
                        int quantity = item.Value.quantity;
                        decimal subtotal = item.Value.subtotal;

                        sb.AppendLine($"{productName} x {quantity}");
                        grandTotal += subtotal;
                    }

                    sb.AppendLine($"\r\n");
                    orderDetailstbx.Text = sb.ToString();
                    subtotaltbx.Text = "₱" + grandTotal.ToString("F2");
                    totalbox.Text = "₱" + grandTotal.ToString("F2");
                    PopulateComboBox(RedeemedDescriptions(generalClass.UserID));
                }
            }
            else
            {
                if (generalClass.orderDetails.Any())
                {
                    ordrnumtbx.Text = generalClass.OrderID > 0
                        ? generalClass.OrderID.ToString()
                        : generalClass.GenerateTempOrderId();

                    gcashPanel.Hide();

                    StringBuilder sb = new StringBuilder();
                    decimal grandTotal = 0;

                    foreach (var item in generalClass.orderDetails)
                    {
                        string productName = item.Key;
                        int quantity = item.Value.quantity;
                        decimal subtotal = item.Value.subtotal;

                        sb.AppendLine($"{productName} x {quantity}");
                        grandTotal += subtotal;
                    }

                    sb.AppendLine($"\r\n");
                    orderDetailstbx.Text = sb.ToString();
                    subtotaltbx.Text = "₱" + grandTotal.ToString("F2");
                    totalbox.Text = "₱" + grandTotal.ToString("F2");
                    PopulateComboBox(RedeemedDescriptions(generalClass.UserID));
                }
                else
                {
                    gcashPanel.Hide();
                    MessageBox.Show("No items in the process.");
                }

            }
        }

        private void PopulateComboBox(List<string> descriptions)
        {
            discountcbx.Items.Clear();

            foreach (var desc in descriptions)
            {
                discountcbx.Items.Add(desc);
            }
        }

        private void paybtn_Click(object sender, EventArgs e)
        {
            string paymentMethod = "";
            string method = "";
            string orderCode = ordrnumtbx.Text;
            string refCode = "";

            if (string.IsNullOrWhiteSpace(orderCode))
            {
                MessageBox.Show("Order code is missing.");
                return;
            }

            // Get dine-in or take-out method
            if (dineIn.Checked)
                method = "Dine In";
            else if (TakeOut.Checked)
                method = "Take Out";
            else
            {
                MessageBox.Show("Please select 'Dine In' or 'Take Out'.");
                return;
            }

            if (discountcbx.SelectedItem != null)
            {
                string selectedDescription = discountcbx.SelectedItem.ToString();

                using (var connection = generalClass.GetConnection())
                {
                    connection.Open();

                    string updateRedeemQuery = @"
                UPDATE RedeemedTable SET Status = 'Used' 
                WHERE UserID = ? AND RewardId IN 
                (SELECT ID FROM PointsTable WHERE Description = ?) AND Status = 'Redeemed'";

                    using (var cmd = new OleDbCommand(updateRedeemQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("?", generalClass.UserID);
                        cmd.Parameters.AddWithValue("?", selectedDescription);
                        cmd.ExecuteNonQuery();
                    }

                    if (decimal.TryParse(totalbox.Text.Replace("₱", "").Trim(), out decimal newTotal))
                    {
                        string updateOrderTotal = "UPDATE Orders SET Total = ? WHERE OrderCode = ?";
                        using (var updateCmd = new OleDbCommand(updateOrderTotal, connection))
                        {
                            updateCmd.Parameters.AddWithValue("?", newTotal);
                            updateCmd.Parameters.AddWithValue("?", orderCode);
                            updateCmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to parse total amount.");
                        return;
                    }
                }
            }
            if (generalClass.Username == "Guest")
            {
                if (counterbtn.Checked)
                {
                    paymentMethod = "Counter";


                    payment pay = new payment();
                    pay.counterPayGuest(paymentMethod, orderCode, method);

                    MessageBox.Show($"Your order number: {orderCode}");
                    ordrnumtbx.Clear();
                    orderDetailstbx.Clear();
                }
                else
                {
                    MessageBox.Show("Please select a payment method.");
                }
            }
            else
            {
                if (counterbtn.Checked)
                {
                    paymentMethod = "Counter";

                    payment pay = new payment();
                    pay.Pay(paymentMethod, orderCode, method);

                    ordrnumtbx.Clear();
                    orderDetailstbx.Clear();
                }
                else if (gcashbtn.Checked)
                {
                    paymentMethod = "GCash";

                    // Show GCash input screen
                    gcashPanel.Location = new Point(305, 52);
                    orderPanel.Hide();
                    gcashPanel.Show();
                }
                else
                {
                    MessageBox.Show("Please select a payment method.");
                }
            }
        }


        private void donebtn_Click(object sender, EventArgs e)
        {
            string method = "";
            gcashPanel.Hide();
            orderPanel.Show();
            string refCode = refbox.Text;
            paymentMethod = "Gcash";

            if (dineIn.Checked)
                method = "Dine In";
            else if (TakeOut.Checked)
                method = "Take Out";
            else
            {
                MessageBox.Show("Please select 'Dine In' or 'Take Out' for counter payment.");
                return;
            }

            try
            {
                payment pay = new payment();
                pay.onlinePay(paymentMethod, generalClass.GenerateTempOrderId(), refCode, method, totalbox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Payment failed: {ex.Message}");
            }

            ordrnumtbx.Clear();
            orderDetailstbx.Clear();
            subtotaltbx.Clear();
        }

        private void button2_Click(object sender, EventArgs e)//back button to payment
        {
            gcashPanel.Hide();
            orderPanel.Show();
        }

        private void discountcbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (discountcbx.SelectedItem != null && discountcbx.SelectedItem.ToString().Contains("%"))
            {
                string selectedDescription = discountcbx.SelectedItem.ToString();
                int percent = int.Parse(selectedDescription.Replace("% off", "").Replace("%", "").Trim());
                decimal discountRate = percent / 100m;

                // Calculate total order amount (without changing the order details)
                decimal originalTotal = generalClass.orderDetails.Sum(item => item.Value.subtotal);
                decimal discountedTotal = originalTotal - (originalTotal * discountRate);

                totalbox.Text = "₱" + discountedTotal.ToString("F2");

                // Proceed with updating the RedeemedTable status
                using (var connection = generalClass.GetConnection())
                {
                    connection.Open();

                    // First, get the RewardId for the selected description
                    string rewardIdQuery = "SELECT ID FROM PointsTable WHERE Description = ?";
                    int rewardId = 0;
                    using (var cmd = new OleDbCommand(rewardIdQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("?", selectedDescription);
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            rewardId = Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show("No matching reward found in the PointsTable.");
                            return; // Exit if the reward doesn't exist
                        }
                    }

                    // Update RedeemedTable where the RewardId matches and the status is 'Redeemed'
                    string updateQuery = "UPDATE RedeemedTable SET Status = 'Used' " +
                                         "WHERE UserID = ? AND RewardId = ? AND Status = 'Redeemed'";

                    using (var cmd = new OleDbCommand(updateQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("?", generalClass.UserID);
                        cmd.Parameters.AddWithValue("?", rewardId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Redeemed reward status updated to 'Used'.");
                        }
                        else
                        {
                            MessageBox.Show("No matching redeemed reward found to update.");
                        }
                    }
                }
            }
        }

    }
}

