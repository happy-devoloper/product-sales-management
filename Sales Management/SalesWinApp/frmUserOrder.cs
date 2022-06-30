using BussinessObject.Models;
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
    public partial class frmUserOrder : Form
    {
        IOrderRepository orderRepository = new OrderRepository();
        public Member MemberInfo { get; set; }

        public frmUserOrder()
        {
            InitializeComponent();
        }

        private void frmUserOrder_Load(object sender, EventArgs e)
        {
            LoadOrdersList();
            // dgvOrdersList.CellDoubleClick += DgvOrdersList_CellDoubleClick;
        }

        private void LoadOrdersList()
        {
            try
            {
                if (MemberInfo != null)
                {
                    var orders = orderRepository.GetOrdersByMemberID(MemberInfo.MemberId);
                    dgvOrdersList.DataSource = null;
                    dgvOrdersList.DataSource = orders;
                }
                else
                {
                    MessageBox.Show("Error Load Order", "Load Order List", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Orders List");
            }
        }

        private void dgvOrdersList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var order = new Order
                {
                    OrderId = (int)dgvOrdersList.CurrentRow.Cells[0].Value,
                    MemberId = (int)dgvOrdersList.CurrentRow.Cells[1].Value,
                    OrderDate = (DateTime)dgvOrdersList.CurrentRow.Cells[2].Value,
                    RequiredDate = (DateTime)dgvOrdersList.CurrentRow.Cells[3].Value,
                    ShippedDate = (DateTime)dgvOrdersList.CurrentRow.Cells[4].Value,
                    Freight = (decimal)dgvOrdersList.CurrentRow.Cells[5].Value,
                };

                frmUserOrderDetail frmUserOrderDetail = new frmUserOrderDetail
                {
                    OrderInfo = order,
                    MemberInfo = MemberInfo,
                    InsertOrUpdate = true,
                    OrderRepository = orderRepository
                };
                frmUserOrderDetail.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", "Orders List", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
