using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesWinApp
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnViewMembers_Click(object sender, EventArgs e)
        {
            frmMembers frmMembers = new frmMembers
            {
                Text = "Member Mangement"
            };
            this.Hide();
            if(frmMembers.ShowDialog() == DialogResult.Yes)
            {
                this.Show();
            }
        }

        private void btnViewProducts_Click(object sender, EventArgs e)
        {
            frmProducts frmProducts = new frmProducts
            {
                Text = "Product Mangement"
            };
            this.Hide();
            if (frmProducts.ShowDialog() == DialogResult.Yes)
            {
                this.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmOrders frmOrders = new frmOrders
            {
                Text = "Orders Mangement"
            };
            this.Hide();
            if (frmOrders.ShowDialog() == DialogResult.Yes)
            {
                this.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmStatistics frmStatistics = new frmStatistics
            {
                Text = "Statistics"
            };
            this.Hide();
            if (frmStatistics.ShowDialog() == DialogResult.Yes)
            {
                this.Show();
            }
        }
    }
}
