using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.CodeDom;

namespace COFFEE_SHOP_APPLICATION
{
    internal class products : generalClass
    {
        public products()
        {
            // Constructor logic here
        }
        public DataTable showProducts()
        {
            DataTable dt = new DataTable();
            using (var myConn = GetConnection())
            {
                try
                {

                    myConn.Open();
                    string query = "SELECT * FROM ShowProducts";
                    OleDbDataAdapter da = new OleDbDataAdapter(query, myConn);
                    da.Fill(dt);
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dt = null; 
                }
                finally
                {
                    if (myConn.State == System.Data.ConnectionState.Open)
                    {
                        myConn.Close();
                    }
                }
                return dt;
            }
        }

        public void addProduct(string name, string price, string description, string imagePath)
        {
            using (var myConn = GetConnection())
            {
                try
                {
                    myConn.Open();
                    string query = "INSERT INTO Products (ProductName, ProductPrice, ProductDescription, ProductImage) VALUES (?, ?, ?, ?)";
                    using (OleDbCommand cmd = new OleDbCommand(query, myConn))
                    {
                        cmd.Parameters.AddWithValue("@ProductName", name);
                        cmd.Parameters.AddWithValue("@ProductPrice", price);
                        cmd.Parameters.AddWithValue("@ProductDescription", description);
                        cmd.Parameters.AddWithValue("@ProductImage", imagePath);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
