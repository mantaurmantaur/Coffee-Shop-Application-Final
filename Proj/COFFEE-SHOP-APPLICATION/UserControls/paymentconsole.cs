using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COFFEE_SHOP_APPLICATION.UserControls
{
    public partial class paymentconsole : UserControl
    {
        float Total = 0;
        public paymentconsole(float total)
        {
            InitializeComponent();
            Total = total;
        }

        private void cashInput(object sender, EventArgs e)
        {
            float cashinput = 0;

            if (float.TryParse(cashbox.Text.Trim(), out cashinput))
            {
                if (cashinput < Total)
                {
                    MessageBox.Show("Insufficient amount.");
                }
                else
                {
                    float change = cashinput - Total;
                    changebox.Text = change.ToString("0.00");
                }
            }
            else
            {
                MessageBox.Show("Invalid amount.");
            }
        }

        private void button1_Click(object sender, EventArgs e)//done button
        {
            this.Hide();
        }
    }
}
