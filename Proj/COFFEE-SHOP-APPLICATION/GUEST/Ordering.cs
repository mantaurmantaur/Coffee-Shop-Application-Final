using COFFEE_SHOP_APPLICATION.CUSTOMER;
using COFFEE_SHOP_APPLICATION.FRONTPAGES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COFFEE_SHOP_APPLICATION.GUEST
{
    public partial class Ordering : Form
    {
        generalClass gen = new generalClass();
        public Ordering()
        {
            InitializeComponent();
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
            OrderingGuest_Load(sender, e);
        }

        private void menutab_Click(object sender, EventArgs e)
        {
            loadForm(new Menu());
        }

        private void Ordering_Close(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void paymenttab_Click(object sender, EventArgs e)
        {
            //insert the ordered into the database
            ordering saveOrders = new ordering();
            saveOrders.storeOrders();
            loadForm(new PaymentGuest());
        }


        private void LogOut_Click(object sender, EventArgs e)
        {
            generalClass.getUn("");
            generalClass.UserID = 0;  
            generalClass.OrderID = 0;

            logupo loginForm = new logupo();
            loginForm.Show();

            this.Hide();
        }

        private void OrderingGuest_Load(object sender, EventArgs e)
        {
            menutab_Click(sender, e);
        }

        private void close_Form(object sender, FormClosingEventArgs e)
        {
            gen.closeForm();
        }
    }
}
