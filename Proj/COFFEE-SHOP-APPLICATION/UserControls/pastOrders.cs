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
    public partial class pastOrders : UserControl
    {
        public pastOrders()
        {
            InitializeComponent();
        }
        public string OrderCode
        {
            get => OrderCodelbl.Text;
            set => OrderCodelbl.Text = value;
        }

        public string OrderDate
        {
            get => date.Text;
            set => date.Text = value;
        }

        public string OrderItems
        {
            get => itemstbx.Text;
            set => itemstbx.Text = value;
        }

        public string TotalAmount
        {
            get => totallbl.Text;
            set => totallbl.Text = value;
        }

        public event EventHandler ReorderClicked;

        private void btnReorder_Click(object sender, EventArgs e)
        {
            ReorderClicked?.Invoke(this, EventArgs.Empty);
        }

        private void pastOrders_Load(object sender, EventArgs e)
        {

        }
    }
}
