using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COFFEE_SHOP_APPLICATION.FRONTPAGES
{
    public partial class floatScreen : Form
    {
        public floatScreen()
        {
            InitializeComponent();
        }
        private void FadeIn(Form form)
        {
            form.Opacity = 0.7;
            form.Show();

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 20;
            timer.Tick += (s, e) =>
            {
                if (form.Opacity < 1)
                    form.Opacity += 0.09;
                else
                    timer.Stop();
            };
            timer.Start();
        }
        
        private void floatScreen_Load(object sender, EventArgs e)
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 3000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            this.Hide();

            logupo front = new logupo();
            FadeIn(front);
            this.Hide();
        }
    }
}
