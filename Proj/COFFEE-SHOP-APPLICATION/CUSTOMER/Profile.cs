using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static COFFEE_SHOP_APPLICATION.profile;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace COFFEE_SHOP_APPLICATION.CUSTOMER
{
    public partial class Profile : Form
    {
        private Reward selectedReward;
        public Profile()
        {
            InitializeComponent();
            generalClass.getUn(generalClass.Username);
        }
        private void paymenttab_Click(object sender, EventArgs e)
        {
            PaymentGuest pay = new PaymentGuest();
            pay.Show();
            this.Hide();
        }

        private void profile_Load(object sender, EventArgs e)
        {
            redeemPanel.Visible = false;
            profile profile = new profile();
            profile.getProfilePic();

            string username = generalClass.Username;
            string pic = generalClass.ProfilePicture;
            string email = generalClass.Email;
            unlbl.Text = username;
            if (string.IsNullOrEmpty(pic))
            {
                string defaultImagePath = Path.Combine("C:", "Users", "ann", "Downloads", "user (2).png");
                profilePicbox.Image = Image.FromFile(defaultImagePath);
            }
            else
            {
                profilePicbox.Image = Image.FromFile(pic);
            }

            profilePicbox.SizeMode = PictureBoxSizeMode.StretchImage;
            profemail.Text = email;
            values.Text = profile.PointLoad();
            DisplayRewards(profile.LoadRewardsFromDatabase());
            DisplayRedeemedRewards(profile.RedeemedDescriptions(generalClass.UserID));
        }

        private void changeProfbtn_Click(object sender, EventArgs e)
        {
            string newImagePath = profile.ChangeProfile();

            // Only update if we got a valid path
            if (!string.IsNullOrEmpty(newImagePath))
            {
                profilePicbox.Image = Image.FromFile(newImagePath);
                profilePicbox.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void DisplayRewards(List<Reward> rewards)
        {
            foreach (var reward in rewards)
            {
                RadioButton rb = new RadioButton();
                rb.ForeColor = Color.Black;
                rb.Font = new Font("Arial", 12, FontStyle.Regular);
                rb.Text = $"{reward.Description}";
                rb.Tag = reward; // store the object
                rb.AutoSize = true;
                rb.CheckedChanged += RewardSelected;
                rewardsList.Controls.Add(rb);
            }
        }
        private void RewardSelected(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null && rb.Checked)
            {
                redeemPanel.Visible = true;
                redeemPanel.Location = new Point(193, 149); // adjust as needed
                redeemPanel.BringToFront();
                panel1.SendToBack();
                profilePanel.SendToBack();

                selectedReward = rb.Tag as Reward;
                if (selectedReward != null)
                {
                    desc.Text = selectedReward.Description;
                     pointstbx.Text= $"{selectedReward.Points} points required";
                }

                redeemPanel.Visible = true;
            }
        }

        private void redeembtn_Click(object sender, EventArgs e)
        {
            decimal points = Convert.ToDecimal(values.Text);
            int requiredPoints = selectedReward.Points;

            // Assume currentUserPoints is a decimal or int from your user table
            if (points >= requiredPoints)
            {
                points -= requiredPoints;
                int userId = generalClass.UserID;
                UpdateUserPoints(userId, points);

                SaveRedeemedReward(userId, selectedReward.ID);
            }
            else
            {
                MessageBox.Show("You don't have enough points to redeem this reward.");
            }
        }

        private void button2_Click(object sender, EventArgs e)//back btn
        {
            redeemPanel.Visible = false;
        }

        private void SaveRedeemedReward(int userId, int rewardId)
        {
            using (var connection = generalClass.GetConnection())
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO RedeemedTable (UserId, RewardId, Redeemed, Status) VALUES (?, ?, ?, ?)";

                    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("?", userId);
                        cmd.Parameters.AddWithValue("?", rewardId);
                        cmd.Parameters.AddWithValue("?", DateTime.Now);
                        cmd.Parameters.AddWithValue("?", "Redeemed"); 

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Reward redeemed successfully!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving redemption: " + ex.Message);
                }
            }
        }

        private void UpdateUserPoints(int userId, decimal newPoints)
        {
            using (var connection = generalClass.GetConnection())
            {
                try
                {
                    connection.Open();

                    string query = "UPDATE Users SET Points = ? WHERE UserId = ?";

                    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("?", newPoints);
                        cmd.Parameters.AddWithValue("?", userId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("User points updated.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to update user points.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating points: " + ex.Message);
                }
            }
        }

        private void DisplayRedeemedRewards(List<string> descriptions)
        {
            redeemedflp.Controls.Clear();

            foreach (var desc in descriptions)
            {
                Label lbl = new Label();
                lbl.Text = $"• {desc}";
                lbl.AutoSize = true;
                lbl.Font = new Font("Arial", 12);
                lbl.ForeColor = Color.Black;
                redeemedflp.Controls.Add(lbl);
            }
        }


    }
}
