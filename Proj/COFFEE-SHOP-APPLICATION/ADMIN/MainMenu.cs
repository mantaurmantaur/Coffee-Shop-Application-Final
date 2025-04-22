using COFFEE_SHOP_APPLICATION.FRONTPAGES;
using COFFEE_SHOP_APPLICATION.STAFFS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COFFEE_SHOP_APPLICATION.ADMIN
{
    public partial class MainMenu : Form
    {
        private string Pos = "";

        public MainMenu(string position)
        {
            InitializeComponent();
            Pos = position;
        }
        Form currentForm = null;
        int fadeStep = 0;
        public void loadForm(object Form)
        {

            if (this.mainPanel.Controls.Count > 0)
                this.mainPanel.Controls.RemoveAt(0);

            currentForm = Form as Form;
            currentForm.TopLevel = false;
            currentForm.FormBorderStyle = FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;
            currentForm.Opacity = 0; // start invisible

            this.mainPanel.Controls.Add(currentForm);
            this.mainPanel.Tag = currentForm;
            currentForm.Show();

            fadeStep = 0;
            fadeTimer.Interval = 30;
            fadeTimer.Tick += FadeInForm;
            fadeTimer.Start();
        }
        private void FadeInForm(object sender, EventArgs e)
        {
            if (currentForm != null)
            {
                fadeStep++;
                currentForm.Opacity = fadeStep * 0.1;

                if (fadeStep >= 10)
                {
                    fadeTimer.Stop();
                    fadeTimer.Tick -= FadeInForm;
                }
            }
        }


        private void dashboardbtn_Click(object sender, EventArgs e)
        {
            loadForm(new Dashboard());
        }

        private void productsbtn_Click(object sender, EventArgs e)
        {
            loadForm(new Products());
        }

        private void customersbtn_Click(object sender, EventArgs e)
        {
            loadForm(new Customers());
        }

        private void staffsbtn_Click(object sender, EventArgs e)
        {
            loadForm(new Staffs());
        }

        private void MainMenu_Close(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            dashboardbtn_Click(sender, e);
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            logupo logupo = new logupo();
            logupo.Show();
            this.Hide();
        }

        private void backbtn_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString() == "Cashier")
            {
                Cashier cashier = new Cashier();
                cashier.Show();
                this.Hide();
            }
            else
            {
                Kitchen kitch = new Kitchen();
                kitch.Show();
                this.Hide();
            }
        }
    }
}
