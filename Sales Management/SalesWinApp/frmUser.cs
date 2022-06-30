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
    public partial class frmUser : Form
    {
        public Member MemberInfo { get; set; }
        public IMemberRepository MemberRepository { get; set; }
        public bool InsertOrUpdate { get; set; }


        public frmUser()
        {
            InitializeComponent();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            try
            {
                if (InsertOrUpdate == true)
                {
                    if(MemberInfo != null)
                    {
                        txtMemberID.Text = MemberInfo.MemberId.ToString();
                        txtCompanyName.Text = MemberInfo.CompanyName;
                        txtEmail.Text = MemberInfo.Email;
                        txtPassword.Text = MemberInfo.Password;
                        cboCity.Text = MemberInfo.City.Trim();
                        cboCountry.Text = MemberInfo.Country.Trim();
                    }
                    else
                    {
                        MessageBox.Show("Error", "Load Member", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
                else
                {
                    cboCity.SelectedIndex = 0;
                    cboCountry.SelectedIndex = 0;
                    txtMemberID.Enabled = !InsertOrUpdate;
                    txtCompanyName.Enabled = !InsertOrUpdate;
                    txtEmail.Enabled = !InsertOrUpdate;
                    txtPassword.Enabled = !InsertOrUpdate;
                    cboCity.Enabled = !InsertOrUpdate;
                    cboCountry.Enabled = !InsertOrUpdate;
                    btnUpdate.Text = "Reset";
                    btnSave.Enabled = !InsertOrUpdate;

                    btnViewOrders.Visible = InsertOrUpdate;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get User", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void ClearText()
        {
            txtMemberID.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            cboCity.SelectedIndex = 0;
            cboCountry.SelectedIndex = 0;
        }

        private void Reset()
        {
            txtMemberID.Text = MemberInfo.MemberId.ToString();
            txtCompanyName.Text = MemberInfo.CompanyName;
            txtEmail.Text = MemberInfo.Email;
            txtPassword.Text = MemberInfo.Password;
            cboCity.Text = MemberInfo.City;
            cboCountry.Text = MemberInfo.Country;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Text.Equals("Update"))
            {
                btnUpdate.Text = "Cancel";
                btnSave.Enabled = true;
                txtCompanyName.Enabled = true;
                txtPassword.Enabled = true;
                cboCity.Enabled = true;
                cboCountry.Enabled = true;
            }
            else if(btnUpdate.Text.Equals("Cancel"))
            {
                Reset();
                btnUpdate.Text = "Update";
                btnSave.Enabled = false;
                txtCompanyName.Enabled = false;
                txtPassword.Enabled = false;
                cboCity.Enabled = false;
                cboCountry.Enabled = false;
            } 
            else if(btnUpdate.Text.Equals("Reset"))
            {
                ClearText();
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var member = new Member
                {
                    MemberId = int.Parse(txtMemberID.Text),
                    CompanyName = txtCompanyName.Text.ToUpper(),
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    City = cboCity.Text,
                    Country = cboCountry.Text
                };

                if (InsertOrUpdate == false)
                {
                    if (MemberRepository.AddMember(member))
                    {
                        MessageBox.Show("Add New Member Successfully!!", "Add New Member", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();                       
                    }
                    else
                    {
                        MessageBox.Show("Your Email has existed!", "Add New Memberr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (MemberRepository.UpdateMember(member))
                    {
                        MessageBox.Show("Update Member Successfully!!", "Update Member", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MemberInfo = member;
                    }
                    else
                    {
                        MessageBox.Show("Update Member Failed!!", "Update Member", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }

                btnUpdate.Text = "Update";
                btnSave.Enabled = false;
                txtCompanyName.Enabled = false;
                txtPassword.Enabled = false;
                cboCity.Enabled = false;
                cboCountry.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e) => Close();

        private void btnViewOrders_Click(object sender, EventArgs e)
        {
            frmUserOrder frmUserOrder = new frmUserOrder
            {
                MemberInfo = MemberInfo
            };
            frmUserOrder.ShowDialog();
        }
    }
}
