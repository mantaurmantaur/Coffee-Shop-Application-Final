using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COFFEE_SHOP_APPLICATION
{
    internal class profile:generalClass
    {
        public class Reward
        {
            public int ID { get; set; }
            public int Points { get; set; }
            public string Description { get; set; }
        }

        public void getProfilePic()
        {
            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT [Contact], [username], [ProfilePic], [Points] FROM Users WHERE [Username] = ?";
                    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("?", Username);

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (!reader.IsDBNull(reader.GetOrdinal("Contact")))
                                {
                                    string email = reader["Contact"].ToString();
                                    getEmail(email);
                                }

                                if (!reader.IsDBNull(reader.GetOrdinal("Points")))
                                {
                                    string points = reader["Points"].ToString();
                                    getPoints(points);
                                }

                                if (!reader.IsDBNull(reader.GetOrdinal("ProfilePic")))
                                {
                                    string ProfilePicture = reader["ProfilePic"].ToString();
                                    getProfilePic(ProfilePicture);
                                }
                            }
                            else
                            {
                                MessageBox.Show("No user data found.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        public static string PointLoad()
        {
            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Points FROM Users WHERE Username = ?";
                    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("?", generalClass.Username);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                            return result.ToString();
                        else
                            throw new Exception("Points not found for username: " + Username);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching points: " + ex.Message);
                    return null;
                }
            }
        }

        public static string ChangeProfile()
        {
            generalClass general = new generalClass();
            string imagePath = "";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return null;
                }

                string selectedImagePath = openFileDialog.FileName;

                if (string.IsNullOrWhiteSpace(selectedImagePath))
                {
                    return "";
                }

                string targetDirectory = Path.Combine(Application.StartupPath, "ProfilePics");
                Directory.CreateDirectory(targetDirectory);

                string fileName = Path.GetFileName(selectedImagePath);
                string newImagePath = Path.Combine(targetDirectory, fileName);

                try
                {
                    File.Copy(selectedImagePath, newImagePath, true);
                    imagePath = newImagePath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error copying image: " + ex.Message);
                    return "";
                }

                // Rest of your existing code...
                if (string.IsNullOrWhiteSpace(generalClass.Username))
                {
                    MessageBox.Show("User is not logged in.");
                    return "";
                }

                try
                {
                    using (var connection = generalClass.GetConnection())
                    {
                        connection.Open();
                        string query = "UPDATE Users SET ProfilePic = ? WHERE Username = ?";

                        using (OleDbCommand cmd = new OleDbCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("?", imagePath);
                            cmd.Parameters.AddWithValue("?", generalClass.Username);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Profile Picture Updated Successfully!");
                            }
                            else
                            {
                                MessageBox.Show("User not found.");
                                return "";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                    return "";
                }
            }

            return imagePath;
        }

        public static List<Reward> LoadRewardsFromDatabase()
        {
            List<Reward> rewards = new List<Reward>();
            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new OleDbCommand("SELECT ID, Points, Description FROM PointsTable", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rewards.Add(new Reward
                    {
                        ID = reader.GetInt32(0),
                        Points = reader.GetInt32(1),
                        Description = reader.GetString(2)
                    });
                }
            }
            return rewards;
        }

        public static List<string> RedeemedDescriptions(int userId)
        {
            List<string> descriptions = new List<string>();

            using (var conn = GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT r.Description
                    FROM RedeemedTable rt
                    INNER JOIN PointsTable r ON rt.RewardId = r.ID
                    WHERE rt.UserId = ? AND rt.Status = 'Redeemed'";

                using (var cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", userId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            descriptions.Add(reader.GetString(0));
                        }
                    }
                }
            }

            return descriptions;
        }

    }

}
