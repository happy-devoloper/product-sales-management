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
    public partial class frmAdminProduct : Form
    {
        IProductRepository productRepository = new ProductRepository();
        public IOrderDetailRepository orderDetailRepository { get; set; }
        public int OrderID { get; set; }
        public Boolean InsertOrUpdate { get; set; }
        public frmAdminProduct()
        {
            InitializeComponent();
        }

        private void frmAdminProduct_Load(object sender, EventArgs e)
        {
            txtOrderID.Text = "#" + OrderID;

            foreach (var product in productRepository.GetListProducts())
            {
                cboProductName.Items.Add(product.ProductName);
            }

            LoadOrderDetail();
        }


        private void LoadOrderDetail()
        {
            lsvProduct.Columns.Clear();
            lsvProduct.Items.Clear();

            lsvProduct.Columns.Add("Order ID");
            lsvProduct.Columns.Add("Product ID");
            lsvProduct.Columns.Add("Unit Price");
            lsvProduct.Columns.Add("Quantity");
            lsvProduct.Columns.Add("Discount");
            lsvProduct.Columns[0].Width = 105;
            lsvProduct.Columns[1].Width = 105;
            lsvProduct.Columns[2].Width = 105;
            lsvProduct.Columns[3].Width = 105;
            lsvProduct.Columns[4].Width = 105;

            //Update
            if(InsertOrUpdate == true)
            {
                var orderDetail = orderDetailRepository.GetOderDetailByOrderID(OrderID);
                foreach (var item in orderDetail)
                {
                    ListViewItem items = new ListViewItem();
                    items.Text = "#" + item.OrderId.ToString();
                    items.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.ProductId.ToString() });
                    items.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.UnitPrice.ToString() });
                    items.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.Quantity.ToString() });
                    items.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.Discount.ToString() + "%" });
                    lsvProduct.Items.Add(items);
                }
            }
            else
            {
                var orderDetail = orderDetailRepository.GetAllOrdersDetailInList();
                foreach (var item in orderDetail)
                {
                    ListViewItem items = new ListViewItem();
                    items.Text = "#" + item.OrderId.ToString();
                    items.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.ProductId.ToString() });
                    items.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.UnitPrice.ToString() });
                    items.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.Quantity.ToString() });
                    items.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.Discount.ToString() + "%" });
                    lsvProduct.Items.Add(items);
                }
            }
            


        }

        private void cboProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = cboProductName.SelectedIndex;
            var products = (List<Product>)productRepository.GetListProducts();
            txtProductID.Text = products[index].ProductId.ToString();
            txtUnitPrice.Text = products[index].UnitPrice.ToString();
            txtUnitInStock.Text = products[index].UnitsInStock.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();


        void Reset()
        {
            txtProductID.Text = string.Empty;
            txtUnitPrice.Text = string.Empty;
            txtUnitInStock.Text = string.Empty;
            cboProductName.Text = string.Empty;
            cboProductName.Enabled = false;
            numQuantity.Enabled = false;
            numDiscount.Enabled = false;
            btnUpdate.Enabled = false;
            numQuantity.Value = 0;
            numDiscount.Value = 0;
        }

        private void lsvProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ko chon trong list view
            if (lsvProduct.SelectedItems.Count == 0)
            {
                Reset();
                return;
            }

            //check button New
            if("Cancel".Equals(btnNew.Text))
            {
                btnNew.Text = "New";
                btnUpdate.Text = "Update";
                btnUpdate.Enabled = false;
            }

            btnUpdate.Enabled = true;

            //can not update product
            cboProductName.Enabled = false;

            //Get product ID and Display List View
            ListViewItem item = lsvProduct.SelectedItems[0];
            var productID = int.Parse(item.SubItems[1].Text);


            var product = productRepository.GetListProducts().SingleOrDefault(pro => pro.ProductId == productID);
            txtProductID.Text = product.ProductId.ToString();
            cboProductName.Text = product.ProductName;          
            txtUnitPrice.Text = product.UnitPrice.ToString();
            txtUnitInStock.Text = product.UnitsInStock.ToString();

            OrderDetail detail = new OrderDetail();
            if(InsertOrUpdate == true)
            {
                detail = orderDetailRepository.GetOderDetailByOrderID(OrderID).SingleOrDefault(ord => ord.ProductId == product.ProductId);

            }
            else
            {
                detail = orderDetailRepository.GetAllOrdersDetailInList().SingleOrDefault(ord => ord.OrderId == OrderID && ord.ProductId == product.ProductId);

            }
            numQuantity.Value = detail.Quantity;
            numDiscount.Value = (decimal)detail.Discount;

            //Enable to Update
            numQuantity.Enabled = true;
            numDiscount.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Are you sure want to Delete?", "Product Management - Delete Product"
               , MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            try
            {
                if (d == DialogResult.OK)
                {
                    if(InsertOrUpdate == true)
                    {
                        var productID = int.Parse(txtProductID.Text);
                        var orderDetail = orderDetailRepository.GetOderDetailByOrderID(OrderID).SingleOrDefault(ord => ord.ProductId == productID);
                        if (orderDetailRepository.RemoveOrderDetail(orderDetail))
                        {
                            MessageBox.Show("Delete Successfull1y!!", "Delete Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadOrderDetail();
                            Reset();
                        }
                    }
                    else
                    {
                        var productID = int.Parse(txtProductID.Text);
                        var orderDetail = orderDetailRepository.GetAllOrdersDetailInList().SingleOrDefault(ord => (ord.ProductId == productID && ord.OrderId == OrderID));
                        if (orderDetailRepository.RemoveOrderDetailInList(orderDetail))
                        {
                            MessageBox.Show("Delete Successfull1y!!", "Delete Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadOrderDetail();
                            Reset();
                        }

                    }
                    

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Failed!", "Delete Products", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var orderDetail = new OrderDetail
                {
                    OrderId = OrderID,
                    ProductId = int.Parse(txtProductID.Text),
                    UnitPrice = decimal.Parse(txtUnitPrice.Text),
                    Quantity = (int)numQuantity.Value,
                    Discount = (double)numDiscount.Value
                };
                if ("Update".Equals(btnUpdate.Text))
                {
                    if (InsertOrUpdate == true)
                    {
                        if (orderDetailRepository.UpdateOrderDetail(orderDetail))
                        {
                            MessageBox.Show("Updated Successfully!!", "Update Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadOrderDetail();
                            Reset();
                        }
                    } else
                    {
                        if(orderDetailRepository.UpdateOrderDetailInList(orderDetail))
                        {
                            MessageBox.Show("Updated Successfully!!", "Update Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadOrderDetail();
                            Reset();
                        }
                    }
                }
                else if ("Create".Equals(btnUpdate.Text))
                {
                    btnCancel.Text = "New";
                    if (InsertOrUpdate == true)
                    {
                        if (orderDetailRepository.AddOrderDetail(orderDetail))
                        {
                            MessageBox.Show("Add Successfully!!", "Add Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Reset();
                            LoadOrderDetail();
                        }
                    }
                    else
                    {
                        if(orderDetailRepository.AddOrderDetailToList(orderDetail))
                        {
                            MessageBox.Show("Add Successfully!!", "Add Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Reset();
                            LoadOrderDetail();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Manage Products", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            if ("New".Equals(btnNew.Text))
            {
                btnNew.Text = "Cancel";
                btnUpdate.Text = "Create";

                lsvProduct.SelectedItems.Clear();
                //Enable to Create
                btnUpdate.Enabled = true;
                cboProductName.Enabled = true;
                numQuantity.Enabled = true;
                numDiscount.Enabled = true;
            }
            else if ("Cancel".Equals(btnNew.Text))
            {
                btnNew.Text = "New";
                btnUpdate.Text = "Update";

                btnUpdate.Enabled = false;
                Reset();
            }
        }
    }
}
