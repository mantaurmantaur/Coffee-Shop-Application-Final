using COFFEE_SHOP_APPLICATION.Properties;
using HarfBuzzSharp;
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
using DrawingFont = System.Drawing.Font;
using System.Xml.Linq;

namespace COFFEE_SHOP_APPLICATION.CUSTOMER
{
    public partial class Menu : Form
    {
        private bool isFromReorder;
        //private Dictionary<string, (int quantity, decimal subtotal)> orderDetails = new();
        public Menu(bool fromReorder = false)
        {
            InitializeComponent();
            isFromReorder = fromReorder;
            this.DoubleBuffered = true;
        }

        private void UpdateOrderDetails()
        {
            StringBuilder details = new StringBuilder();
            decimal grandTotal = 0;
            int totalItems = 0;

            foreach (var item in generalClass.orderDetails)
            {
                details.AppendLine($"{item.Key} x {item.Value.quantity} = ₱{item.Value.subtotal:F2}");
                grandTotal += item.Value.subtotal;
                totalItems += item.Value.quantity;
            }

            details.AppendLine($"\nTotal Items: {totalItems}");
            details.AppendLine($"Grand Total: ₱{grandTotal:F2}");

            orderDetailstbx.Text = details.ToString();
        }

        private async void Menu_Load(object sender, EventArgs e)
        {
            if (generalClass.orderDetails.Count == 0)
            {
                orderDetailstbx.Text = "No items selected.";
            }
            else
            {
                PopulateOrderDetailsTextbox();
            } 
            menuflp.Controls.Clear();
            categoriesLayOutPanel.Controls.Clear();
            Menus gen = new Menus();
            var menuItems = gen.ShowMenu("All Menu");
            var categories = gen.ShowCategories();
            
            if (menuItems.Count == 0)
            {
                MessageBox.Show("No menu items found!");
            }

            if(categories.Count == 0)
            {
                MessageBox.Show("None");
            }

            foreach (var item in categories)
            {
                string title = item.Value.Title;
                string imgPath = item.Value.ImagePath;

                await CreateCategoryPanel(title, imgPath);
            }

            foreach (var item in menuItems)
            {
                string name = item.Key;
                decimal price = item.Value.Price;
                string imgPath = item.Value.ImagePath;
                int stock = item.Value.stocks;

                await CreateMenuItemPanel(name, price, imgPath, stock);
            }
        }

        public void PopulateOrderDetailsTextbox()
        {
            orderDetailstbx.Clear();

            foreach (var item in generalClass.orderDetails)
            {
                string name = item.Key;
                int quantity = item.Value.quantity;
                decimal subtotal = item.Value.subtotal;

                orderDetailstbx.AppendText($"{name} x {quantity} - ₱{subtotal:F2}\r\n");
            }
        }

        private async Task CreateMenuItemPanel(string name, decimal price, string imgPath, int stock)
        {
            var itemPanel = new Panel
            {
                Size = new Size(200, 293),
                Padding = new Padding(5),
                Margin = new Padding(10),
                BackColor = Color.FromArgb(76, 100, 68),
                BorderStyle = BorderStyle.None
            };

            // Picture Box
            var picBox = new PictureBox
            {
                Size = new Size(180, 157),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(11, 18),
                Image = File.Exists(imgPath) ? Image.FromFile(imgPath) : Image.FromFile("C:\\Users\\ann\\Downloads\\coffeeLofo.gif")
            };

            // Product Label
            var productNamelbl = new System.Windows.Forms.Label
            {
                Font = new System.Drawing.Font("Tahoma", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0),
                ForeColor = Color.White,
                Location = new Point(11, 178),
                Size = new Size(186, 26),
                TabIndex = 1,
                Text = name,
                TextAlign = ContentAlignment.MiddleCenter
            };
            var pricelbl = new System.Windows.Forms.Label
            {
                Font = new System.Drawing.Font("Tahoma", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0),
                ForeColor = Color.White,
                Location = new Point(11, 204),
                Size = new Size(186, 26),
                TabIndex = 1,
                Text = $"₱{price:F2}",
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Quantity Controls
            var quantityLabel = new System.Windows.Forms.Label
            {
                Text = "0",
                Font = new System.Drawing.Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0),
                ForeColor = Color.White,
                Size = new Size(40, 26),
                TabIndex = 5,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var btnMinus = new Button
            {
                Text = "-",
                Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold),
                Size = new Size(30, 30),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(73, 54, 40),
                FlatStyle = FlatStyle.Flat
            };

            var btnPlus = new Button
            {
                Text = "+",
                Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White,
                Size = new Size(30, 30),
                BackColor = Color.FromArgb(73, 54, 40),
                FlatStyle = FlatStyle.Flat
            };

            // Button Panel
            var buttonPanel = new FlowLayoutPanel
            {
                Size = new Size(130, 40),
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                BackColor = Color.Transparent,
                Location = new Point(40, itemPanel.Height - 40)
            };

            // Event Handlers
            btnPlus.Click += (s, e) =>
            {
                int count = int.Parse(quantityLabel.Text);

                if (count >= stock)
                {
                    MessageBox.Show($"Only {stock} in stock for {name}.", "Stock Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                count++;
                quantityLabel.Text = count.ToString();
                generalClass.orderDetails[name] = (count, count * price);
                UpdateOrderDetails();
            };

            btnMinus.Click += (s, e) =>
            {
                int count = int.Parse(quantityLabel.Text);
                if (count > 0)
                {
                    count--;
                    quantityLabel.Text = count.ToString();
                    if (count == 0)
                        generalClass.orderDetails.Remove(name);
                    else
                        generalClass.orderDetails[name] = (count, count * price);
                    UpdateOrderDetails();
                }
            };
            //menuflp.SuspendLayout();

            // Add controls
            buttonPanel.Controls.AddRange(new Control[] { btnMinus, quantityLabel, btnPlus });
            itemPanel.Controls.AddRange(new Control[] { picBox, productNamelbl, pricelbl, buttonPanel });

            // Add to flow layout
            menuflp.Controls.Add(itemPanel);
            generalClass gen = new generalClass();
            await gen.FadeInPanel(itemPanel);
            //menuflp.ResumeLayout();
        }

        private async Task CreateCategoryPanel(string name, string imgPath)
        {
            try
            {
                Button categ = new Button();
                categ.AutoSize = false;
                categ.BackColor = Color.FromArgb(213, 193, 176);
                categ.FlatAppearance.BorderSize = 0;
                categ.FlatStyle = FlatStyle.Flat;
                categ.Font = new System.Drawing.Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
                categ.Image = Image.FromFile(imgPath);
                categ.ImageAlign = ContentAlignment.TopCenter;
                categ.Name = name;
                categ.Size = new Size(92, 100);
                categ.TabIndex = 65;
                categ.Text = name;
                categ.Padding = new Padding(1);
                categ.TextAlign = ContentAlignment.BottomCenter;
                categ.UseVisualStyleBackColor = false;
                categ.Cursor = Cursors.Hand;

                if (File.Exists(imgPath))
                {
                    categ.Image = Image.FromFile(imgPath);
                }
                else
                {
                    MessageBox.Show($"Image not found: {imgPath}", "Missing Image", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                categ.BringToFront();

                categ.Click += async (s, e) =>
                {
                    menuflp.Controls.Clear(); // Optional: clear previous items

                    Menus generalClass = new Menus();
                    var menuItems = generalClass.ShowMenu(categ.Text);
                    var categories = generalClass.ShowCategories();

                    if (menuItems.Count == 0)
                    {
                        MessageBox.Show("No menu items found!");
                    }

                    foreach (var item in menuItems)
                    {
                        string name = item.Key;
                        decimal price = item.Value.Price;
                        string imgPath = item.Value.ImagePath;
                        int stocks = item.Value.stocks;

                        await CreateMenuItemPanel(name, price, imgPath, stocks);
                    }
                };

                categoriesLayOutPanel.Controls.Add(categ);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to create category panel: " + ex.Message);
            }
        }

    }
}
