using COFFEE_SHOP_APPLICATION.FRONTPAGES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COFFEE_SHOP_APPLICATION.CUSTOMER
{
    public partial class OrderingGuest : Form
    {
        public OrderingGuest()
        {
            InitializeComponent();
        }

        private void Ordering_Load(object sender, EventArgs e)//same code sa menu so?
        {
            menutab_Click(sender, e);

        }


        public void loadForm(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            Form fh = Form as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(fh);
            this.mainpanel.Tag = fh;
            fh.Show();

        }

        private void allmenu_Click(object sender, EventArgs e)
        {
            Ordering_Load(sender, e);
        }

        private void historytab_Click(object sender, EventArgs e)
        {
            loadForm(new History());
        }

        private void menutab_Click(object sender, EventArgs e)
        {
            loadForm(new Menu());
        }

        private void Ordering_Close(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public void paymenttab_Click(object sender, EventArgs e)
        {
            //insert the ordered into the database
            ordering saveOrders = new ordering();
            saveOrders.storeOrders();
            loadForm(new PaymentGuest());
        }

        private void profiletab_Click(object sender, EventArgs e)
        {
            loadForm(new Profile());
        }

        private void LogOut_Click(object sender, EventArgs e)
        {

            generalClass.getUn("");
            generalClass.UserID = 0;  // Also clear the UserID if your class has it
            generalClass.OrderID = 0; // Clear any order references
            generalClass.orderDetails.Clear(); // Clear the order details

            // Open login form
            logupo loginForm = new logupo();
            loginForm.Show();

            // Close current form
            this.Hide();
        }
    }
}

