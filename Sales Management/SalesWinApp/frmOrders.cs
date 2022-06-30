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
    public partial class frmOrders : Form
    {
        IOrderRepository orderRepository = new OrderRepository();
        IOrderDetailRepository detailRepository = new OrderDetailRepository();
        IMemberRepository memberRepository = new MemberRepository();
        BindingSource source;
        public frmOrders()
        {
            InitializeComponent();
        }


        private void btnExit_Click(object sender, EventArgs e) => Close();

        void ClearText()
        {
            txtOrderID.Text = String.Empty;
            txtMemberID.Text = String.Empty;
            txtFreight.Text = String.Empty;
            txtRequiredDate.Text = String.Empty;
            txtOrderID.Text = String.Empty;
            txtShippedDate.Text = String.Empty;
        }

        private void LoadOrderList()
        {
            try
            {
                var orders = orderRepository.GetOrdersList();

                source = new BindingSource();
                source.DataSource = orders;

                txtOrderID.DataBindings.Clear();
                txtMemberID.DataBindings.Clear();
                txtFreight.DataBindings.Clear();
                txtRequiredDate.DataBindings.Clear();
                txtOrderDate.DataBindings.Clear();
                txtShippedDate.DataBindings.Clear();

                txtOrderID.DataBindings.Add("Text", source, "OrderId");
                txtMemberID.DataBindings.Add("Text", source, "MemberId");
                txtFreight.DataBindings.Add("Text", source, "Freight");
                txtRequiredDate.DataBindings.Add("Text", source, "RequiredDate");
                txtOrderDate.DataBindings.Add("Text", source, "OrderDate");
                txtShippedDate.DataBindings.Add("Text", source, "ShippedDate");

                dgvProductsList.DataSource = null;
                dgvProductsList.DataSource = source;


                if (orders.Count() == 0)
                {
                    ClearText();
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Order List");
            }
        }

        private Order GetOrderObject()
        {
            try
            {
                var order = new Order
                {
                    OrderId = int.Parse(txtOrderID.Text),
                    MemberId = int.Parse(txtMemberID.Text),
                    Freight = decimal.Parse(txtFreight.Text),
                    RequiredDate = DateTime.Parse(txtRequiredDate.Text),
                    OrderDate = DateTime.Parse(txtOrderDate.Text),
                    ShippedDate = DateTime.Parse(txtShippedDate.Text)
                };
                return order;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadOrderList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Are you sure want to Delete?", "Order Information Management - Delete Order"
               , MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            try
            {
                if (d == DialogResult.OK)
                {
                    var order = GetOrderObject();
                    if (orderRepository.RemoveOrder(order))
                    {
                        MessageBox.Show("Delete Successfully!!", "Delete Order", MessageBoxButtons.OK);
                        LoadOrderList();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProductsList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var orderInfo = GetOrderObject();
            if (orderInfo != null)
            {
                frmUserOrderDetail frmUserOrderDetail = new frmUserOrderDetail
                {
                    Text = "Member Order Detail",
                    IsAdmin = true,
                    MemberInfo = memberRepository.GetMemberByID(orderInfo.MemberId),
                    OrderInfo = orderInfo,
                    OrderRepository = orderRepository,
                    InsertOrUpdate = true
                };
                frmUserOrderDetail.ShowDialog();
                LoadOrderList();
            }


        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmUserOrderDetail frmUserOrderDetail = new frmUserOrderDetail
            {
                Text = "Member Order Detail",
                IsAdmin = true,
                OrderRepository = orderRepository,
                InsertOrUpdate = false
            };
            if (frmUserOrderDetail.ShowDialog() == DialogResult.OK)
            {
                LoadOrderList();
            }
        }
    }
}
