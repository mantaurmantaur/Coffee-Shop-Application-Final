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
using System.Net.Http.Headers;
using System.Diagnostics;

namespace COFFEE_SHOP_APPLICATION.ADMIN
{
    public partial class Products : Form
    {
        generalClass gen = new generalClass();
        OleDbConnection? myConn;
        OleDbDataAdapter? da;
        OleDbCommand? cmd;
        DataSet? ds;
        int indexRow;
        Panel categpanel;

        public Products()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void ShowProductLoad(object sender, EventArgs e)
        {
            categView.Visible = false;
            products productsData = new products();
            DataTable productData = productsData.showProducts(); // Call the method to get product data

            if (productData != null) // Check if data was retrieved successfully
            {
                productView.DataSource = productData; // Set as DataSource
            }
            else
            {
                MessageBox.Show("Failed to load product data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void addbtn_Click(object sender, EventArgs e)
        {


            if (pnametbx.Text == "")
            {
                MessageBox.Show("Please enter the product name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                productView.Size = new Size(402, 651);
                productView.Location = new Point(774, 84);

                PictureBox pic = new PictureBox();
                pic.Location = new Point(34, 35);
                pic.BackgroundImageLayout = ImageLayout.Zoom;
                pic.Size = new Size(212, 174);

                Button save = new Button();
                save.Location = new Point(189, 254);
                save.Size = new Size(57, 31);
                save.Text = "Save";
                save.ForeColor = Color.White;

                Button add = new Button();
                add.Location = new Point(34, 254);
                add.Size = new Size(57, 31);
                add.Text = "Add";
                add.ForeColor = Color.White;

                Label lbl = new Label();
                lbl.Location = new Point(14, 13);
                lbl.Size = new Size(9, 21);
                lbl.Text = "Add an image";
                lbl.Font = new Font("Tahoma", 10, FontStyle.Regular);
                lbl.ForeColor = Color.White;

                Panel im = new Panel();
                im.Location = new Point(434, 266);
                im.Size = new Size(285, 300);
                im.BackColor = Color.FromArgb(73, 54, 40);
                im.Controls.Add(save);
                im.Controls.Add(add);
                im.Controls.Add(pic);
                im.Controls.Add(lbl);
                im.Visible = true;
                im.BringToFront();
                productView.SendToBack();

                panel1.Controls.Add(im);

                add.Click += (s, ev) =>
                {
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            gen.imagePath = openFileDialog.FileName;
                            pic.Image = Image.FromFile(gen.imagePath);
                            pic.SizeMode = PictureBoxSizeMode.Zoom;
                            MessageBox.Show("Image successfully added!");
                        }
                    }
                };

                save.Click += (s, ev) =>
                {
                    if (string.IsNullOrEmpty(gen.imagePath))
                    {
                        MessageBox.Show("Please select an image before saving.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!decimal.TryParse(pricetbx.Text, out decimal price))
                    {
                        MessageBox.Show("Please enter a valid numeric value for Price.");
                        return;
                    }
                    using (var connection = generalClass.GetConnection())
                    {
                        try
                        {
                            connection.Open();
                            string query = "INSERT INTO Products (ProductName, Category, Price, Status, Stocks, ImagePath) VALUES (@name, @category, @price, @status, @stock, @imagePath)";

                            using (OleDbCommand cmd = new OleDbCommand(query, connection))
                            {
                                cmd.Parameters.Add("@name", OleDbType.VarChar).Value = pnametbx.Text;
                                cmd.Parameters.Add("@category", OleDbType.VarChar).Value = categorytbx.Text;
                                cmd.Parameters.Add("@price", OleDbType.Decimal).Value = price;
                                cmd.Parameters.Add("@status", OleDbType.VarChar).Value = statustbx.Text;
                                cmd.Parameters.Add("@stocks", OleDbType.VarChar).Value = stockstbx.Text;
                                cmd.Parameters.Add("@imagePath", OleDbType.VarChar).Value = gen.imagePath;

                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Product Added Successfully!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                        finally
                        {
                            productView.Size = new Size(720, 651);
                            productView.Location = new Point(433, 84);
                            productView.BringToFront();

                            im.Visible = false;

                            if (pic.Image != null)
                            {
                                pic.Image.Dispose();
                                pic.Image = null;
                            }
                        }
                    }
                };
            }
        }

        private void addCategory_Click(object sender, EventArgs e)
        {
            pidtbx.Clear();
            pnametbx.Clear();
            categorytbx.Clear();
            pricetbx.Clear();
            stockstbx.Clear();
            idlbl.Text = "Category ID";
            categView.Show();
            productView.Hide();
            var myConn = generalClass.GetConnection();
            da = new OleDbDataAdapter("SELECT categoryId, Title, Status FROM CategoriesTable", myConn);
            ds = new DataSet();
            myConn.Open();
            da.Fill(ds, "CategoriesTable");
            categView.DataSource = ds.Tables["CategoriesTable"];
            myConn.Close();

            productView.Hide();

            categpanel = new Panel();
            categpanel.BackColor = Color.FromArgb(73, 54, 40);
            categpanel.Location = new Point(450, 279);
            categpanel.Name = "categpanel";
            categpanel.Size = new Size(312, 216);
            categpanel.TabIndex = 69;

            TextBox categtbx = new TextBox();
            categtbx.Location = new Point(152, 121);
            categtbx.Name = "categtbx";
            categtbx.PlaceholderText = "Category";
            categtbx.Size = new Size(131, 27);
            categtbx.TabIndex = 0;

            PictureBox categPic = new PictureBox();
            categPic.Location = new Point(35, 39);
            categPic.Name = "categPic";
            categPic.Size = new Size(92, 109);
            categPic.TabIndex = 1;
            categPic.TabStop = false;
            categPic.BringToFront();
            categPic.BackColor = Color.White;

            Button addpicbtn = new Button();
            addpicbtn.Location = new Point(35, 157);
            addpicbtn.Name = "addpicbtn";
            addpicbtn.Size = new Size(92, 29);
            addpicbtn.TabIndex = 3;
            addpicbtn.Text = "Add Pic";
            addpicbtn.UseVisualStyleBackColor = true;
            addpicbtn.BringToFront();

            Button savebutton = new Button();
            savebutton.Location = new Point(189, 165);
            savebutton.Name = "savebutton";
            savebutton.Size = new Size(94, 29);
            savebutton.TabIndex = 2;
            savebutton.Text = "Save";
            savebutton.UseVisualStyleBackColor = true;


            categpanel.Controls.Add(savebutton);
            categpanel.Controls.Add(categPic);
            categpanel.Controls.Add(addpicbtn);
            categpanel.Controls.Add(categtbx);
            Controls.Add(categpanel);
            categpanel.BringToFront();

            addpicbtn.Click += (s, ev) =>
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        gen.imagePath = openFileDialog.FileName;
                        categPic.Image = Image.FromFile(gen.imagePath);
                        categPic.SizeMode = PictureBoxSizeMode.Zoom;
                        MessageBox.Show("Image successfully added!");
                    }
                }
            };

            savebutton.Click += (s, ev) =>
            {
                if (string.IsNullOrEmpty(gen.imagePath))
                {
                    MessageBox.Show("Please select an image before saving.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                using (var connection = generalClass.GetConnection())
                {
                    try
                    {
                        connection.Open();
                        string query = "INSERT INTO CategoriesTable (Title, ImagePath, Status) VALUES (@name, @imagePath, @stat)";
                        using (OleDbCommand cmd = new OleDbCommand(query, connection))
                        {
                            cmd.Parameters.Add("@name", OleDbType.VarChar).Value = categtbx.Text;
                            cmd.Parameters.Add("@imagePath", OleDbType.VarChar).Value = gen.imagePath;
                            cmd.Parameters.Add("@stat", OleDbType.VarChar).Value = "Available";
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Category Added Successfully!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        productView.Size = new Size(720, 651);
                        productView.Location = new Point(415, 84);
                        productView.BringToFront();
                        categpanel.Visible = false;
                        if (categPic.Image != null)
                        {
                            categPic.Image.Dispose();
                            categPic.Image = null;
                        }
                    }
                }
            };

        }

        private void editProdPicbtn_Click(object sender, EventArgs e)
        {
            productView.Size = new Size(402, 651);
            productView.Location = new Point(774, 84);

            PictureBox pic = new PictureBox();
            pic.Location = new Point(34, 35);
            pic.BackgroundImageLayout = ImageLayout.Zoom;
            pic.Size = new Size(212, 174);

            Button save = new Button();
            save.Location = new Point(189, 254);
            save.Size = new Size(57, 31);
            save.Text = "Save";
            save.ForeColor = Color.White;

            Button add = new Button();
            add.Location = new Point(34, 254);
            add.Size = new Size(57, 31);
            add.Text = "Add";
            add.ForeColor = Color.White;

            Label lbl = new Label();
            lbl.Location = new Point(14, 13);
            lbl.Size = new Size(9, 21);
            lbl.Text = "Add an image";
            lbl.Font = new Font("Tahoma", 10, FontStyle.Regular);
            lbl.ForeColor = Color.White;

            Panel im = new Panel();
            im.Location = new Point(434, 266);
            im.Size = new Size(285, 300);
            im.BackColor = Color.FromArgb(73, 54, 40);
            im.Controls.Add(save);
            im.Controls.Add(add);
            im.Controls.Add(pic);
            im.Controls.Add(lbl);
            im.Visible = true;
            im.BringToFront();
            productView.SendToBack();

            panel1.Controls.Add(im);
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    gen.imagePath = openFileDialog.FileName;
                    pic.Image = Image.FromFile(gen.imagePath);
                    pic.SizeMode = PictureBoxSizeMode.Zoom;
                    MessageBox.Show("Image successfully added!");
                }
                using (var connection = generalClass.GetConnection())
                {
                    try
                    {
                        connection.Open();
                        string query = "UPDATE Products SET ImagePath = @imagePath WHERE ProductId = @productId";

                        using (OleDbCommand cmd = new OleDbCommand(query, connection))
                        {
                            cmd.Parameters.Add("@imagePath", OleDbType.VarChar).Value = gen.imagePath;
                            cmd.Parameters.Add("@productId", OleDbType.Integer).Value = int.Parse(pidtbx.Text);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Product picture changed successfully!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        productView.Size = new Size(720, 651);
                        productView.Location = new Point(433, 84);
                        productView.BringToFront();

                        im.Visible = false;

                        if (pic.Image != null)
                        {
                            pic.Image.Dispose();
                            pic.Image = null;
                        }
                    }
                }

            }
        }

        private void refreshbtn_Click(object sender, EventArgs e)
        {
            var myConn = generalClass.GetConnection();
            da = new OleDbDataAdapter("SELECT *FROM ShowProducts", myConn);
            ds = new DataSet();
            myConn.Open();
            da.Fill(ds, "Products");
            productView.DataSource = ds.Tables["Products"];
            myConn.Close();
        }


        private void updatebtn_Click(object sender, EventArgs e)
        {
            if (categView.Visible == true)
            {
                string updatequery = "UPDATE [CategoriesTable] SET [Title] = ?, [Status] = ? WHERE [categoryId] = ?";

                try
                {
                    using (var myConn = generalClass.GetConnection())
                    {
                        using (OleDbCommand cmd = new OleDbCommand(updatequery, myConn))
                        {
                            cmd.Parameters.AddWithValue("?", categorytbx.Text);
                            cmd.Parameters.AddWithValue("?", statustbx.Text);
                            cmd.Parameters.AddWithValue("?", pidtbx.Text);

                            myConn.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                                MessageBox.Show("Product Updated Successfully!");
                            else
                                MessageBox.Show("No product was updated. Check if the Product ID exists.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    idlbl.Text = "Product ID";
                    Controls.Remove(categpanel);
                    productView.Show();
                    productView.BringToFront();
                    categpanel.Visible = false;
                    ShowProductLoad(sender, e);
                }
            }
            else
            {
                if (pnametbx == null || categorytbx == null || pricetbx == null || statustbx == null || stockstbx == null)
                {
                    MessageBox.Show("Some fields are not properly initialized.");
                    return;
                }

                if (productView == null || productView.CurrentRow == null)
                {
                    MessageBox.Show("Please select a product to update.");
                    return;
                }

                if (!decimal.TryParse(pricetbx.Text, out decimal price))
                {
                    MessageBox.Show("Invalid price value!");
                    return;
                }

                if (!int.TryParse(stockstbx.Text, out int stocks))
                {
                    MessageBox.Show("Invalid stock value!");
                    return;
                }

                if (!int.TryParse(productView.CurrentRow.Cells[0].Value?.ToString(), out int productId))
                {
                    MessageBox.Show("Invalid Product ID!");
                    return;
                }

                string query = "UPDATE [Products] SET [ProductName] = ?, [Category] = ?, [Price] = ?, [Status] = ?, [Stocks] = ? WHERE [ProductId] = ?";

                try
                {
                    using (var myConn = generalClass.GetConnection())
                    {
                        using (OleDbCommand cmd = new OleDbCommand(query, myConn))
                        {
                            cmd.Parameters.AddWithValue("?", pnametbx.Text);
                            cmd.Parameters.AddWithValue("?", categorytbx.Text);
                            cmd.Parameters.AddWithValue("?", price);
                            cmd.Parameters.AddWithValue("?", statustbx.Text);
                            cmd.Parameters.AddWithValue("?", stocks);
                            cmd.Parameters.AddWithValue("?", productId);

                            myConn.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                                MessageBox.Show("Product Updated Successfully!");
                            else
                                MessageBox.Show("No product was updated. Check if the Product ID exists.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }


        }



        private void deletbtn_Click(object sender, EventArgs e)
        {
            if (productView.CurrentRow == null)
            {
                MessageBox.Show("Please select a row first.");
                return;
            }

            if (!int.TryParse(productView.CurrentRow.Cells[0].Value?.ToString(), out int productId))
            {
                MessageBox.Show("Invalid Product ID!");
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Deletion",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            try
            {
                using (var myConn = generalClass.GetConnection())
                {
                    string query = "DELETE FROM [Products] WHERE [ProductId] = ?";

                    using (OleDbCommand cmd = new OleDbCommand(query, myConn))
                    {
                        cmd.Parameters.AddWithValue("?", productId);

                        myConn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            MessageBox.Show("Product deleted successfully!");
                        else
                            MessageBox.Show("No product was deleted. Check if the Product ID exists.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void categView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow;
            indexRow = e.RowIndex;
            if (indexRow < 0) return;


            DataGridViewRow row = categView.Rows[indexRow];
            pidtbx.Text = row.Cells[0].Value?.ToString();
            categorytbx.Text = row.Cells[1].Value?.ToString();
            statustbx.Text = row.Cells[2].Value?.ToString();
        }

        private void productView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow;
            indexRow = e.RowIndex;
            if (indexRow < 0) return;


            DataGridViewRow row = productView.Rows[indexRow];
            pidtbx.Text = row.Cells[0].Value?.ToString();
            pnametbx.Text = row.Cells[1].Value?.ToString();
            categorytbx.Text = row.Cells[2].Value?.ToString();
            pricetbx.Text = row.Cells[3].Value?.ToString();
            statustbx.Text = row.Cells[4].Value?.ToString();
            stockstbx.Text = row.Cells[5].Value?.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
