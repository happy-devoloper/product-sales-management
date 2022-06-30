using DataAccess.Repository;
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
    public partial class frmStatistics : Form
    {
        IOrderRepository orderRepository = new OrderRepository();
        IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();
        public frmStatistics()
        {
            InitializeComponent();
        }

        private void frmStatistics_Load(object sender, EventArgs e)
        {
            lsvStatistic.Columns.Clear();
            lsvStatistic.Items.Clear();

            lsvStatistic.Columns.Add("Order ID");
            lsvStatistic.Columns.Add("Member ID");
            lsvStatistic.Columns.Add("Required Date");
            lsvStatistic.Columns.Add("Total Product");
            lsvStatistic.Columns.Add("Total Price");

            lsvStatistic.Columns[0].Width = 100;
            lsvStatistic.Columns[1].Width = 100;
            lsvStatistic.Columns[2].Width = 100;
            lsvStatistic.Columns[3].Width = 100;
            lsvStatistic.Columns[4].Width = 100;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            var startDate = dateTimePicker1.Value;
            var endDate = dateTimePicker2.Value;
            if(endDate < startDate)
            {
                MessageBox.Show("End Date must after the Start Date", "Statistics", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                var orders = orderRepository.GetOrdersList().Where(ord => (startDate < ord.RequiredDate && endDate > ord.RequiredDate)).ToList();

                txtAmount.Text = orders.Count.ToString();

                int totalProduct = 0;
                decimal totalPrice = 0;
                foreach(var order in orders)
                {
                    decimal totalOrderPrice = 0;
                    int totalOrderProduct = 0;

                    ListViewItem items = new ListViewItem();
                    items.Text = "#" + order.OrderId.ToString();
                    items.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = order.MemberId.ToString() });
                    items.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = order.RequiredDate.ToString() });

                    var orderDetails = orderDetailRepository.GetOderDetailByOrderID(order.OrderId);
                    foreach(var orderDetail in orderDetails)
                    {
                        totalOrderPrice += (orderDetail.UnitPrice * orderDetail.Quantity * (1 - (decimal)(orderDetail.Discount / 100)));
                        totalOrderProduct += orderDetail.Quantity;
                    }
                    totalOrderPrice += (decimal)order.Freight;
                    items.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = totalOrderProduct.ToString() });
                    items.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = Math.Round(totalOrderPrice ,2).ToString() });
                    lsvStatistic.Items.Add(items);

                    totalProduct += totalOrderProduct;
                    totalPrice += totalOrderPrice;
                }
                txtProductSold.Text = totalProduct.ToString();
                txtTotalSales.Text = Math.Round(totalPrice ,2).ToString();

            }
        }

        private void btnExit_Click(object sender, EventArgs e) => Close();

    }
}
