using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace COFFEE_SHOP_APPLICATION
{
    internal class staff:generalClass
    {
        public string StaffID { get; set; }
        public string StaffLastName { get; set; }
        public string StaffFirstName { get; set; }
        public string StaffEmail { get; set; }
        public string StaffPassword { get; set; }
        public string StaffAddress { get; set; }
        public string StaffPosition { get; set; }
        public string StaffStatus { get; set; }

        public staff(string staffID, string firstName, string lastName, string staffEmail, string staffPassword, string staffAddress, string staffPosition, string staffStatus)
        {
            StaffID = staffID;
            StaffLastName = firstName;
            StaffFirstName = lastName;
            StaffEmail = staffEmail;
            StaffPassword = staffPassword;
            StaffPosition = staffPosition;
            StaffStatus = staffStatus;
        }

        public static void addStaffs(string FirstName, string LastName, string Position, string Status, string email)
        {
            try
            {
                using (var myConn = GetConnection())
                {
                    myConn.Open();
                    string checkQuery = "SELECT COUNT(*) FROM Staffs WHERE FirstName = @FName AND LastName = @LName";
                    using (OleDbCommand checkCmd = new OleDbCommand(checkQuery, myConn))
                    {
                        checkCmd.Parameters.AddWithValue("@FName", FirstName);
                        checkCmd.Parameters.AddWithValue("@LName", LastName);

                        int existingCount = Convert.ToInt32(checkCmd.ExecuteScalar() ?? 0);
                        if (existingCount > 0)
                        {
                            MessageBox.Show("Staff member already exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string insertQuery = "INSERT INTO Staffs (FirstName, LastName, [Position], [Status], Email) VALUES (@FName, @LName, @Pos, @Stat, @email)";
                    using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, myConn))
                    {
                        insertCmd.Parameters.AddWithValue("@FName", FirstName);
                        insertCmd.Parameters.AddWithValue("@LName", LastName);
                        insertCmd.Parameters.AddWithValue("@Pos", Position);
                        insertCmd.Parameters.AddWithValue("@Stat", Status);
                        insertCmd.Parameters.AddWithValue("@email", email);

                        insertCmd.ExecuteNonQuery();
                    }

                    string getIdQuery = "SELECT @@IDENTITY";
                    using (OleDbCommand idCmd = new OleDbCommand(getIdQuery, myConn))
                    {
                        int newId = Convert.ToInt32(idCmd.ExecuteScalar() ?? 0);

                        addstaffsCredentials(newId, LastName, email);
                    }

                    MessageBox.Show("New staff member added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void updateStaffs(string FirstName, string LastName, string Position, string Status, string email, int id)
        {
            try
            {
                using (var myConn = GetConnection())
                {
                    string query = "UPDATE Staffs SET FirstName = @FName, LastName = @LName, [Position] = @Pos, [Status] = @Stat, Email = @Email WHERE StaffId = @id";

                    using (OleDbCommand cmd = new OleDbCommand(query, myConn))
                    {
                        cmd.Parameters.AddWithValue("@FName", FirstName);
                        cmd.Parameters.AddWithValue("@LName", LastName);
                        cmd.Parameters.AddWithValue("@Pos", Position);
                        cmd.Parameters.AddWithValue("@Stat", Status);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@id", id);

                        myConn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Update successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No records updated. Please check the StaffId.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        public static void addstaffsCredentials(int userId, string LastName, string email)
        {
            string password = GenerateTemporaryPassword();

            try
            {
                using (var myConn = GetConnection())
                {
                    myConn.Open();

                    string insertQuery = "INSERT INTO StaffCredentials (StaffId, Username, [Password]) VALUES (@ID, @Un, @Pass)";

                    using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, myConn))
                    {
                        insertCmd.Parameters.AddWithValue("@ID", userId);
                        insertCmd.Parameters.AddWithValue("@Un", LastName);
                        insertCmd.Parameters.AddWithValue("@Pass", password);
                        insertCmd.ExecuteNonQuery();
                    }
                }

                SendEmail(LastName, password, email);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void SendEmail(string lastName, string pass, string email)
        {
            try
            {
                Random rand = new Random();

                string toEmail = email;

                var fromAddress = new MailAddress("coffeeshopapplication3@gmail.com");
                var toAddress = new MailAddress(toEmail.ToString());
                const string Apass = "hyxmatvjiykjheze"; // App password
                const string subject = "Your Credentials";
                string body = "Good day!\r\n\r\nCongratulations and welcome to The Coffee Shop family! We're thrilled to have you on board as part of our growing team. Your presence is a valuable addition, and we’re looking forward to working with you to create a cozy and delightful experience for our customers.\r\n\r\nPlease find your login credentials below to access the staff system:" + "\n\nYour username is: " + lastName +"\nYour temporary password: " + pass + "\nYou can change your password through the forget password mode in the log in form";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, Apass),
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
                MessageBox.Show("Credentials sent! Please check your email.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send email. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void deleteStaff(int staffId)
        {
            try
            {
                using (var myConn = GetConnection())
                {
                    string query = "DELETE FROM Staffs WHERE StaffId = @id";

                    using (OleDbCommand cmd = new OleDbCommand(query, myConn))
                    {
                        cmd.Parameters.AddWithValue("@id", staffId);

                        myConn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Staff successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No matching staff found to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting staff: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
