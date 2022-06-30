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
    public partial class frmProducts : Form
    {
        IProductRepository productRepository = new ProductRepository();
        BindingSource source;

        public frmProducts()
        {
            InitializeComponent();
        }

        private void ClearText()
        {
            txtProductID.Text = string.Empty;
            txtCategoryID.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtUnitPrice.Text = string.Empty;
            txtWeight.Text = string.Empty;
            txtUnitInStock.Text = string.Empty;
        }

        private void LoadProductsList()
        {
            try
            {
                var products = productRepository.GetListProducts();
                source = new BindingSource();
                source.DataSource = products;

                txtProductID.DataBindings.Clear();
                txtCategoryID.DataBindings.Clear();
                txtProductName.DataBindings.Clear();
                txtUnitPrice.DataBindings.Clear();
                txtWeight.DataBindings.Clear();
                txtUnitInStock.DataBindings.Clear();

                txtProductID.DataBindings.Add("Text", source, "ProductId");
                txtCategoryID.DataBindings.Add("Text", source, "CategoryId");
                txtProductName.DataBindings.Add("Text", source, "ProductName");
                txtUnitPrice.DataBindings.Add("Text", source, "UnitPrice");
                txtWeight.DataBindings.Add("Text", source, "Weight");
                txtUnitInStock.DataBindings.Add("Text", source, "UnitsInStock");

                dgvProductsList.DataSource = null;
                dgvProductsList.DataSource = source;


                if (products.Count() == 0)
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
                MessageBox.Show(ex.Message, "Load Products list");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadProductsList();
        }

        private Product GetProductObject()
        {
            Product product = null;
            try
            {
                product = new Product
                {
                    ProductId = int.Parse(txtProductID.Text),
                    CategoryId = int.Parse(txtCategoryID.Text),
                    ProductName = txtProductName.Text,
                    UnitPrice = decimal.Parse(txtUnitPrice.Text),
                    Weight = txtWeight.Text,
                    UnitsInStock = int.Parse(txtUnitInStock.Text)
                };

            }
            catch (Exception ex)
            {
                MessageBox.Show("Get Product Object Failed!!", "Get Product Object", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return product;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Are you sure want to Delete?", "Products Information Management - Delete Product"
               , MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            try
            {
                if (d == DialogResult.OK)
                {
                    var product = GetProductObject();
                    productRepository.RemoveProduct(product);
                }
                LoadProductsList();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Failed!", "Delete Products", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            cboSearch.SelectedIndex = 0;
            dgvProductsList.CellDoubleClick += DgvProductList_CellDoubleClick;
        }

        private void DgvProductList_CellDoubleClick(object sender, EventArgs e)
        {
            frmProductDetail frmProductDetail = new frmProductDetail
            {
                Text = "Update Product",
                InsertOrUpdate = true,
                productRepository = productRepository,
                ProductInfo = GetProductObject()
            };
            if (frmProductDetail.ShowDialog() == DialogResult.Yes)
            {
                LoadProductsList();
                source.Position = source.Count - 1;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmProductDetail frmProductDetail = new frmProductDetail
            {
                InsertOrUpdate = false,
                productRepository = productRepository
            };
            frmProductDetail.ShowDialog();
            LoadProductsList();
            source.Position = source.Count - 1;

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var type = cboSearch.Text.Trim();
            List<Product> product = new List<Product>();
            string search;
            try
            {
                switch (type)
                {
                    case "Product ID":
                        search = txtSearch.Text;
                        product = productRepository.GetListProducts().Where(p => p.ProductId.ToString().Contains(search)).ToList();
                        break;

                    case "Product Name":
                        search = txtSearch.Text;
                        product = productRepository.GetListProducts().Where(p => p.ProductName.ToLower().Contains(search.ToLower())).ToList();
                        break;

                    case "Unit Price":
                        search = txtSearch.Text;
                        product = productRepository.GetListProducts().Where(p => p.UnitPrice.ToString().Contains(search)).ToList();
                        break;

                    case "Unit in Stock":
                        search = txtSearch.Text;
                        product = productRepository.GetListProducts().Where(p => p.UnitsInStock.ToString().Contains(search)).ToList();
                        break;
                }


                source = new BindingSource();
                source.DataSource = product;

                txtProductID.DataBindings.Clear();
                txtCategoryID.DataBindings.Clear();
                txtProductName.DataBindings.Clear();
                txtUnitPrice.DataBindings.Clear();
                txtWeight.DataBindings.Clear();
                txtUnitInStock.DataBindings.Clear();

                txtProductID.DataBindings.Add("Text", source, "ProductId");
                txtCategoryID.DataBindings.Add("Text", source, "CategoryId");
                txtProductName.DataBindings.Add("Text", source, "ProductName");
                txtUnitPrice.DataBindings.Add("Text", source, "UnitPrice");
                txtWeight.DataBindings.Add("Text", source, "Weight");
                txtUnitInStock.DataBindings.Add("Text", source, "UnitsInStock");

                dgvProductsList.DataSource = null;
                dgvProductsList.DataSource = source;
   
                if (product.Count == 0)
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
                MessageBox.Show(ex.Message, "Search Products", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
