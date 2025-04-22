using System;
using System.Security.Cryptography;
using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.Linq;  
    using System.Text;
    using System.Threading.Tasks;
using COFFEE_SHOP_APPLICATION.FRONTPAGES;

namespace COFFEE_SHOP_APPLICATION
    {
        internal class generalClass
        {
            public static string Username { get; private set; }
            protected OleDbConnection? Connection { get; private set; }
            protected const string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\ann\\OneDrive\\Desktop\\Project\\Proj\\COFFEE-SHOP-APPLICATION\\CoffeeShopFinals.accdb";
            public static string Email { get; set; }
            public static string Points { get; set; }
            public static string ProfilePicture { get; set; }

            public static Dictionary<string, (int quantity, decimal subtotal)> orderDetails = new();
            public static int UserID { get; set; }
            public static string Position { get; set; } 
        public string imagePath { get; set; }
            public static int OrderID  { get; set; }
            public static string OrderCode = "0";
            public static Dictionary<string, string> categories = new();

            public generalClass()
            {
            
            }

            public static string GenerateTempOrderId()
            {
                Random rnd = new Random();
                int randomPart = rnd.Next(1000, 9999); // 4-digit random
                return randomPart.ToString();
            }

            public class OrderData
            {
                public int UserId { get; set; }
                public decimal Total { get; set; }
                public string PaymentMethod { get; set; }
                public List<OrderItem> Items { get; set; }
            }

            public class OrderItem
            {
                public string ProductName { get; set; }
                public int quantity { get; set; }
                public decimal UnitPrice { get; set; }
                public decimal Subtotal => quantity * UnitPrice;
            }

            public static OleDbConnection GetConnection()
            {
                return new OleDbConnection(connectionString);
            }

            public async Task FadeInPanel(Panel panel)
            {
                for (int alpha = 0; alpha <= 255; alpha += 15)
                {
                    await Task.Delay(3);
                }
            }
            public static void getUn(string name)
            {
                Username = name;
                using (var connection = GetConnection())
                {
                    string query = "SELECT UserId FROM Users WHERE Username = ?";

                    using (var cmd = new OleDbCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("?", name);

                        connection.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                UserID = Convert.ToInt32(reader["UserId"]);
                            }
                        }
                    }
                }
            }

        public static void getPosition(string position)
        {
            Position = position;
        }

        public static void getUnStaffs(string name)
        {
            Username = name;
            using (var connection = GetConnection())
            {
                string query = "SELECT StaffId FROM StaffCredentials WHERE Username = ?";

                using (var cmd = new OleDbCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("?", name);

                    connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            UserID = Convert.ToInt32(reader["StaffId"]);
                        }
                    }
                }
            }
        }

        public static void getEmail(string email)
            {
                Email = email;
            }

            public static void getPoints(string points)
            {
                Points = points;
            }

            public static void getProfilePic(string profilepic)
            {

                ProfilePicture = profilepic;
            
            }

            public void closeForm()
            { 
                Application.Exit();
            }

        public static int GetUserId(string username)
        {
            try
            {
                using (var connection = generalClass.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT UserId FROM Users WHERE Username = ?";
                    using (var cmd = new OleDbCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("?", username);
                        object result = cmd.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int userId))
                            return userId;
                        else
                            throw new Exception("User ID not found for username: " + username);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching UserId: " + ex.Message);
                return -1; // Indicate an error
            }
        }

        public void logOut()
        {
            logupo loginForm = new logupo();
            loginForm.Show();
        }

        public static string GenerateTemporaryPassword(int length = 8)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                                        .Select(s => s[random.Next(s.Length)])
                                        .ToArray());
        }
        public static void HashColumnInDataTable(DataTable table, string columnName)
        {
            foreach (DataRow row in table.Rows)
            {
                if (row[columnName] != DBNull.Value)
                {
                    string plainText = row[columnName].ToString();
                    string hashedText = ComputeSHA256Hash(plainText);
                    row[columnName] = hashedText;
                }
            }
        }

        public static string ComputeSHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
}
}
