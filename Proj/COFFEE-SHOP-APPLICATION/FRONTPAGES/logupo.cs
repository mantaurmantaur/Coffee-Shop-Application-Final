using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Net.Mail;
using System.Net;
using COFFEE_SHOP_APPLICATION.CUSTOMER;
using COFFEE_SHOP_APPLICATION.ADMIN;
using COFFEE_SHOP_APPLICATION.STAFFS;
using COFFEE_SHOP_APPLICATION.GUEST;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace COFFEE_SHOP_APPLICATION.FRONTPAGES
{
    public partial class logupo : Form
    {
        string verificationCode;
        public logupo()
        {
            InitializeComponent();
        }


        private void createAccountlbl_Click(object sender, EventArgs e)
        {
            loginPanel.Hide();
            signUppanel.Show();

            verificationPanel.Hide();
        }

        private void loginlbl_Click(object sender, EventArgs e)
        {
            signUppanel.Hide();
            loginPanel.Show();

            verificationPanel.Hide();
        }

        private void forgotPasslbl_Click(object sender, EventArgs e)
        {
            cusernametbx.Text = usernametbx.Text;
            signUppanel.Hide();
            verificationPanel.Hide();
            loginPanel.Hide();
            changepassbtn.Enabled = false;
            changePasspanel.Location = new Point(288, 65);
            changePasspanel.Show();
        }

        private void front_Load(object sender, EventArgs e)
        {
            signUppanel.Hide();
            changePasspanel.Hide();
            verificationPanel.Hide();
            loginPanel.Show();
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            signUppanel.Hide();
            changePasspanel.Hide();
            verificationPanel.Hide();
            loginPanel.Show();
        }

        private void sendCodebtn_Click(object sender, EventArgs e)
        {

            signUppanel.Hide();
            changepassbtn.Enabled = false;
            changePasspanel.Controls.Add(verificationPanel);
            verificationPanel.Location = new Point(19, 168);
            changePasspanel.Show();
            loginPanel.Hide();

            string adminQuery = "SELECT COUNT(*) FROM Users WHERE Contact = ? AND username = ?";
            generalClass generalClass = new generalClass();
            var myConn = generalClass.GetConnection();
            try
            {
                using (OleDbCommand cmd = new OleDbCommand(adminQuery, myConn))
                {
                    myConn.Open();

                    cmd.Parameters.AddWithValue("?", cemailtbx.Text);
                    cmd.Parameters.AddWithValue("?", cusernametbx.Text);

                    int Count = Convert.ToInt32(cmd.ExecuteScalar() ?? 0);

                    if (Count > 0)
                    {
                        if (string.IsNullOrEmpty(cemailtbx.Text))
                        {
                            MessageBox.Show("Please enter both your email and username.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        try
                        {
                            Random rand = new Random();
                            verificationCode = rand.Next(100000, 999999).ToString();

                            string toEmail = cemailtbx.Text;

                            var fromAddress = new MailAddress("coffeeshopapplication3@gmail.com");
                            var toAddress = new MailAddress(toEmail.ToString());
                            const string pass = "hyxmatvjiykjheze"; // App password
                            const string subject = "Your Verification Code";
                            string body = "Your verification code is: " + verificationCode;

                            var smtp = new SmtpClient
                            {
                                Host = "smtp.gmail.com",
                                Port = 587,
                                EnableSsl = true,
                                DeliveryMethod = SmtpDeliveryMethod.Network,
                                UseDefaultCredentials = false,
                                Credentials = new NetworkCredential(fromAddress.Address, pass),
                                Timeout = 20000
                            };

                            using (var message = new MailMessage(fromAddress, toAddress)
                            {
                                Subject = subject,
                                Body = body
                            })
                            {
                                smtp.Send(message);
                            }
                            MessageBox.Show("Verification code sent! Please check your email.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            verificationPanel.Show();
                            verificationPanel.BringToFront();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed to send email. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid email or email not registered.");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void verifiybtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(vercodetbx.Text))
            {
                MessageBox.Show("Please enter the verification code.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string inputCode = vercodetbx.Text;

            if (inputCode == verificationCode)
            {
                signUppanel.Hide();
                verificationPanel.Hide();
                changePasspanel.Show();
                loginPanel.Hide();
                changepassbtn.Enabled = true;

                MessageBox.Show("Verification successful. You may now reset your password.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Incorrect verification code. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void logInbtn_Click(object sender, EventArgs e)
        {
            generalClass generalClass = new generalClass();
            try
            {
                using (var myConn = generalClass.GetConnection())
                {
                    myConn.Open();
                    string username = usernametbx.Text.Trim();
                    string customerQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                    using (OleDbCommand cmd = new OleDbCommand(customerQuery, myConn))
                    {
                        cmd.Parameters.AddWithValue("@Username", usernametbx.Text);
                        cmd.Parameters.AddWithValue("@Password", passwordtbx.Text);

                        int userCount = Convert.ToInt32(cmd.ExecuteScalar() ?? 0);

                        if (userCount > 0)
                        {
                            generalClass.getUn(username);
                            OrderingGuest customer = new OrderingGuest();
                            customer.Show();
                            this.Hide();
                            return;
                        }
                    }

                    string adminQuery = "SELECT [Position] FROM [workersQuery] WHERE [Username] = ? AND [Password] = ?";

                    using (OleDbCommand cmd = new OleDbCommand(adminQuery, myConn))
                    {
                        cmd.Parameters.AddWithValue("?", usernametbx.Text);
                        cmd.Parameters.AddWithValue("?", passwordtbx.Text);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string position = result.ToString();

                            if (position == "Administrator" || position =="Manager")
                            {
                                generalClass.getUnStaffs(username);
                                generalClass.getPosition(position);
                                MainMenu admin = new MainMenu(position);
                                admin.Show();
                                this.Hide();
                            }
                            else
                            {
                                if (position == "Cashier")
                                {
                                    generalClass.getUnStaffs(username);
                                    Cashier cashier = new Cashier();
                                    cashier.Show();
                                    this.Hide();
                                }
                                else if(position == "Kitchen")
                                {
                                    generalClass.getUnStaffs(username);
                                    Kitchen kitchen = new Kitchen();
                                    kitchen.Show();
                                    this.Hide();
                                }
                            }
                            return;
                        }
                    }
                    MessageBox.Show("Incorrect username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Signuptbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(suntbx.Text) || string.IsNullOrWhiteSpace(passtbx.Text) || string.IsNullOrWhiteSpace(confirmtbx.Text) || string.IsNullOrEmpty(emailtbx.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (passtbx.Text != confirmtbx.Text)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (passtbx.Text.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long.", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            generalClass generalClass = new generalClass();

            using (var myConn = generalClass.GetConnection())
            {
                myConn.Open();

                string checkUserQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                using (OleDbCommand checkCmd = new OleDbCommand(checkUserQuery, myConn))
                {
                    checkCmd.Parameters.AddWithValue("@Username", suntbx.Text);
                    int existingUsers = Convert.ToInt32(checkCmd.ExecuteScalar() ?? 0);

                    if (existingUsers > 0)
                    {
                        MessageBox.Show("Username already exists. Choose a different one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                string checkEmailQuery = "SELECT COUNT(*) FROM Users WHERE Contact = @Contact";
                using (OleDbCommand checkEmailCmd = new OleDbCommand(checkEmailQuery, myConn))
                {
                    checkEmailCmd.Parameters.AddWithValue("@Contact", emailtbx.Text);
                    int existingEmail = Convert.ToInt32(checkEmailCmd.ExecuteScalar() ?? 0);

                    if (existingEmail > 0)
                    {
                        MessageBox.Show("Email is already registered. Please use a different email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                string insertQuery = "INSERT INTO Users (username, [password], [Contact]) VALUES (@Username, @Password, @con)";
                using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, myConn))
                {
                    insertCmd.Parameters.AddWithValue("@Username", suntbx.Text);
                    insertCmd.Parameters.AddWithValue("@Password", passtbx.Text);
                    insertCmd.Parameters.AddWithValue("@con", emailtbx.Text);

                    int rowsAffected = insertCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Registration failed. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }



        private void changepassbtn_Click(object sender, EventArgs e)
        {
            generalClass generalClass = new generalClass();
            var myConn = generalClass.GetConnection();
            if (cpasstbx.Text != confirmPassTBX.Text)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string updateQuery = "UPDATE Users SET [Password] = @Password WHERE Contact = @contact";
                try
                {
                    using (OleDbCommand cmd = new OleDbCommand(updateQuery, myConn))
                    {
                        myConn.Open();
                        cmd.Parameters.AddWithValue("@Password", cpasstbx.Text);
                        cmd.Parameters.AddWithValue("@contact", cemailtbx.Text);
                        int Count = cmd.ExecuteNonQuery();
                        if (Count > 0)
                        {
                            MessageBox.Show("Password reset successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Password reset failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            loginlbl_Click(sender, e);
        }

        private void logupo_Close(object sender, FormClosingEventArgs e)
        {
            generalClass gen = new generalClass();
            gen.closeForm();
        }

        private void login(object sender, EventArgs e)//buttonguest
        {
            generalClass.getUn("Guest");
            Ordering GuestOrder = new Ordering();
            GuestOrder.Show();
            this.Hide();
        }


        private void showPassbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (passwordtbx.UseSystemPasswordChar)
            {
                passwordtbx.UseSystemPasswordChar = false;
            }
            else
            {
                passwordtbx.UseSystemPasswordChar = true;
            }
        }
    }
}
