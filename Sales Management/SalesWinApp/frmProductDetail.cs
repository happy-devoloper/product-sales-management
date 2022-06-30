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
    public partial class frmProductDetail : Form
    {

        public Boolean InsertOrUpdate { get; set; }
        public Product ProductInfo { get; set; }
        public IProductRepository productRepository { get; set; }

        public frmProductDetail()
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

        private void LoadProduct()
        {
            txtProductID.Text = ProductInfo.ProductId.ToString();
            txtCategoryID.Text = ProductInfo.CategoryId.ToString();
            txtProductName.Text = ProductInfo.ProductName;
            txtWeight.Text = ProductInfo.Weight;
            txtUnitPrice.Text = ProductInfo.UnitPrice.ToString();
            txtUnitInStock.Text = ProductInfo.UnitsInStock.ToString();
        }

        private void frmProductDetail_Load(object sender, EventArgs e)
        {
            if (InsertOrUpdate == true)
            {
                btnSave.Enabled = !InsertOrUpdate;
                LoadProduct();
            }
            else
            {
                btnUpdate.Text = "Reset";
                btnSave.Enabled = !InsertOrUpdate;
                txtProductID.Enabled = !InsertOrUpdate;
                txtCategoryID.Enabled = !InsertOrUpdate;
                txtProductName.Enabled = !InsertOrUpdate;
                txtWeight.Enabled = !InsertOrUpdate;
                txtUnitPrice.Enabled = !InsertOrUpdate;
                txtUnitInStock.Enabled = !InsertOrUpdate;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnUpdate.Text == "Update")
                {
                    btnUpdate.Text = "Cancel";
                    btnSave.Enabled = InsertOrUpdate;
                    txtCategoryID.Enabled = InsertOrUpdate;
                    txtProductName.Enabled = InsertOrUpdate;
                    txtWeight.Enabled = InsertOrUpdate;
                    txtUnitPrice.Enabled = InsertOrUpdate;
                    txtUnitInStock.Enabled = InsertOrUpdate;
                }
                else if (btnUpdate.Text == "Reset")
                {
                    ClearText();
                }
                else if (btnUpdate.Text == "Cancel")
                {
                    LoadProduct();
                    btnUpdate.Text = "Update";
                    btnSave.Enabled = false;
                    txtCategoryID.Enabled = false;
                    txtProductName.Enabled = false;
                    txtWeight.Enabled = false;
                    txtUnitPrice.Enabled = false;
                    txtUnitInStock.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var product = new Product
                {
                    ProductId = int.Parse(txtProductID.Text),
                    CategoryId = int.Parse(txtCategoryID.Text),
                    ProductName = txtProductName.Text,
                    UnitPrice = decimal.Parse(txtUnitPrice.Text),
                    Weight = txtWeight.Text,
                    UnitsInStock = int.Parse(txtUnitInStock.Text)
                };

                if (InsertOrUpdate == false)
                {
                    if (productRepository.AddProduct(product))
                    {
                        MessageBox.Show("Add new Product Successfully!!", "Add New Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                }
                else
                {
                    if(productRepository.UpdateProduct(product))
                    {
                        MessageBox.Show("Update Product Successfully!!", "Update Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ProductInfo = product;                    
                    } 
                    btnUpdate.Text = "Update";
                    btnSave.Enabled = false;
                    txtCategoryID.Enabled = false;
                    txtProductName.Enabled = false;
                    txtWeight.Enabled = false;
                    txtUnitPrice.Enabled = false;
                    txtUnitInStock.Enabled = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message ,"Add New Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e) => Close();
    }
}
