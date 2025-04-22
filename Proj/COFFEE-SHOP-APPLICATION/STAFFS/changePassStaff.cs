using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COFFEE_SHOP_APPLICATION.STAFFS
{
    public partial class changePassStaff : Form
    {
        string verificationCode;
        public changePassStaff()
        {
            InitializeComponent();
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            Kitchen kitchen = new Kitchen();
            kitchen.Show();
            this.Hide();
        }

        private void sendCodebtn_Click(object sender, EventArgs e)
        {
            generalClass generalClass = new generalClass();

            string adminQuery = "SELECT COUNT(*) FROM Staffs WHERE Email = ? AND LastName = ?";
            var myConn = generalClass.GetConnection();
            try
            {
                using (OleDbCommand cmd = new OleDbCommand(adminQuery, myConn))
                {
                    myConn.Open();

                    cmd.Parameters.AddWithValue("?", cemailtbx.Text);
                    cmd.Parameters.AddWithValue("?", generalClass.Username);

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
                            verificationPanel.Location = new Point(317, 214);
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

        private void changePassStaff_Load(object sender, EventArgs e)
        {
            verificationPanel.Hide();
        }

        private void verificationbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(vercodetbx.Text))
            {
                MessageBox.Show("Please enter the verification code.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string inputCode = vercodetbx.Text;

            if (inputCode == verificationCode)
            {
                verificationPanel.Hide();
                changepassbtn.Enabled = true;

                MessageBox.Show("Verification successful. You may now reset your password.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Incorrect verification code. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string updateQuery = "UPDATE StaffCredentials SET [Password] = @Password WHERE Username = @un";
                try
                {
                    using (OleDbCommand cmd = new OleDbCommand(updateQuery, myConn))
                    {
                        myConn.Open();
                        cmd.Parameters.AddWithValue("@Password", cpasstbx.Text);
                        cmd.Parameters.AddWithValue("@un", generalClass.Username);
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
        }

        private void changePassStaff_Close(object sender, FormClosingEventArgs e)
        {
            generalClass gen = new generalClass();
            gen.closeForm();
            this.Hide();
        }
    }
}
