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
    public partial class frmUserOrderDetail : Form
    {
        public Member MemberInfo { get; set; }
        public Order OrderInfo { get; set; }
        public IOrderRepository OrderRepository { get; set; }
        IOrderDetailRepository OrderDetailRepository = new OrderDetailRepository();
        IMemberRepository MemberRepository = new MemberRepository();
        public Boolean IsAdmin { get; set; }
        public Boolean InsertOrUpdate { get; set; }
        public frmUserOrderDetail()
        {
            InitializeComponent();
        }

        private void frmUserOrderDetail_Load(object sender, EventArgs e)
        {
            if (IsAdmin == true)
            {
                if (MemberRepository.GetMemberList().Count > 0)
                {
                    foreach (var member in MemberRepository.GetMemberList())
                    {
                        cboCompanyName.Items.Add(member.CompanyName);
                    }
                    cboCompanyName.SelectedIndex = 0;
                }
                cboCompanyName.Enabled = true;

                txtFreight.ReadOnly = false;
                btnSave.Visible = true;
                btnEdit.Visible = true;
            }


            if (InsertOrUpdate == true)
            {
                txtOrderID.Text = "#" + OrderInfo.OrderId.ToString();
                txtMemberID.Text = MemberInfo.MemberId.ToString();
                cboCompanyName.Text = MemberInfo.CompanyName;
                txtRequiredDate.Text = OrderInfo.RequiredDate.ToString();
                txtOrderDate.Text = OrderInfo.OrderDate.ToString();
                txtShippedDate.Text = OrderInfo.ShippedDate.ToString();
                txtFreight.Text = OrderInfo.Freight.ToString();

            } else
            {
                int orderID = 0;
                while(true)
                {
                    Random rnd = new Random();
                    orderID = rnd.Next(1000, 9999);
                    var order = OrderRepository.GetOrdersList().SingleOrDefault(ord => ord.OrderId == orderID);
                    if (order == null)                    
                        break;                    
                }
                txtOrderID.Text = "#" + orderID.ToString();
                DateTime now = DateTime.Now;
                txtRequiredDate.Text = now.ToString();
                txtOrderDate.Text = now.ToString();
                txtShippedDate.Text = now.ToString();
            }

           
            LoadOrderDetail();
        }


        private void LoadOrderDetail()
        {
            lsvOrderDetail.Columns.Clear();
            lsvOrderDetail.Items.Clear();

            lsvOrderDetail.Columns.Add("Order ID");
            lsvOrderDetail.Columns.Add("Product ID");
            lsvOrderDetail.Columns.Add("Unit Price");
            lsvOrderDetail.Columns.Add("Quantity");
            lsvOrderDetail.Columns.Add("Discount");
            lsvOrderDetail.Columns[0].Width = 120;
            lsvOrderDetail.Columns[1].Width = 120;
            lsvOrderDetail.Columns[2].Width = 120;
            lsvOrderDetail.Columns[3].Width = 120;
            lsvOrderDetail.Columns[4].Width = 120;

            if (InsertOrUpdate == true)
            {
                var orderDetail = OrderDetailRepository.GetOderDetailByOrderID(OrderInfo.OrderId);
                foreach (var item in orderDetail)
                {
                    ListViewItem items = new ListViewItem();
                    items.Text = "#" + item.OrderId.ToString();
                    items.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.ProductId.ToString() });
                    items.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.UnitPrice.ToString() });
                    items.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.Quantity.ToString() });
                    items.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.Discount.ToString() + "%" });
                    lsvOrderDetail.Items.Add(items);
                }
            }
            else
            {
                var orderDetail = OrderDetailRepository.GetAllOrdersDetailInList();
                foreach (var item in orderDetail)
                {
                    ListViewItem items = new ListViewItem();
                    items.Text = "#" + item.OrderId.ToString();
                    items.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.ProductId.ToString() });
                    items.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.UnitPrice.ToString() });
                    items.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.Quantity.ToString() });
                    items.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.Discount.ToString() + "%" });
                    lsvOrderDetail.Items.Add(items);
                }
            }


        }

        private void btnExit_Click(object sender, EventArgs e) => Close();


        private void cboCompanyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = cboCompanyName.SelectedIndex;
            var members = (List<Member>)MemberRepository.GetMemberList();
            if (members[index] != null)
            {
                txtMemberID.Text = members[index].MemberId.ToString();
            }
        }



        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (IsAdmin == true)
            {
                if(InsertOrUpdate == true)
                {
                    frmAdminProduct frmAdminProduct = new frmAdminProduct
                    {
                        orderDetailRepository = OrderDetailRepository,
                        OrderID = OrderInfo.OrderId,
                        InsertOrUpdate = true,
                    };
                    if (frmAdminProduct.ShowDialog() == DialogResult.Yes)
                    {
                        LoadOrderDetail();
                    }

                } else
                {
                    frmAdminProduct frmAdminProduct = new frmAdminProduct
                    {
                        orderDetailRepository = OrderDetailRepository,
                        OrderID = int.Parse(txtOrderID.Text.Substring(1)),
                        InsertOrUpdate = false
                    };
                    if (frmAdminProduct.ShowDialog() == DialogResult.Yes)
                    {
                        LoadOrderDetail();
                    }
                }
                
                
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var order = new Order
                {
                    MemberId = int.Parse(txtMemberID.Text),
                    RequiredDate = DateTime.Parse(txtRequiredDate.Text),
                    OrderDate = DateTime.Parse(txtOrderDate.Text),
                    ShippedDate = DateTime.Parse(txtShippedDate.Text),
                    Freight = decimal.Parse(txtFreight.Text)
                };
                if (InsertOrUpdate == true)
                {
                    if(OrderDetailRepository.GetOderDetailByOrderID(OrderInfo.OrderId).Count() > 0)
                    {
                        order.OrderId = OrderInfo.OrderId;
                        if (OrderRepository.UpdateOrder(order))
                        {
                            MessageBox.Show("Update Order Successfully!!", "Update Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Order must be have Product", "Orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                   
                }
                else
                {
                    order.OrderId = int.Parse(txtOrderID.Text.Substring(1));
                    if(OrderDetailRepository.GetAllOrdersDetailInList().Count() > 0)
                    {
                        if (OrderRepository.CreateOrder(order))
                        {
                            if (OrderDetailRepository.AddOrderDetailToDB(OrderDetailRepository.GetAllOrdersDetailInList()))
                                MessageBox.Show("Create New Order Successfully!!", "Create Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Order Detail can NOT be empty!!", "Orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Save Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

