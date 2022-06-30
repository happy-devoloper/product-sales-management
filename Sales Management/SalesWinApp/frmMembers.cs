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
    public partial class frmMembers : Form
    {
        IMemberRepository memberRepository = new MemberRepository();
        BindingSource source;

        public frmMembers()
        {
            InitializeComponent();
        }

        private void frmMembers_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            cboSearch.SelectedIndex = 0;
            //   dgvMemberList.CellDoubleClick += DgvMemberList_CellDoubleClick;
        }

        //private void DgvMemberList_CellDoubleClick(object sender, EventArgs e)
        //{
        //    frmUser frmUser = new frmUser
        //    {
        //        Text = "Update Member",
        //        InsertOrUpdate = true,
        //        MemberInfo = GetMemberObject(),
        //        MemberRepository = memberRepository
        //    };
        //    if (frmUser.ShowDialog() == DialogResult.Yes)
        //    {
        //        LoadMemberList();
        //        source.Position = source.Count - 1;
        //    }
        //}

        private void dgvMemberList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmUser frmUser = new frmUser
            {
                Text = "Update Member",
                InsertOrUpdate = true,
                MemberInfo = GetMemberObject(),
                MemberRepository = memberRepository
            };
            if (frmUser.ShowDialog() == DialogResult.Yes)
            {
                LoadMemberList();
                source.Position = source.Count - 1;
            }
        }

        private void ClearText()
        {
            txtMemberID.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtCountry.Text = string.Empty;
        }

        private Member GetMemberObject()
        {
            Member member = null;
            try
            {
                member = new Member
                {
                    MemberId = int.Parse(txtMemberID.Text),
                    CompanyName = txtCompanyName.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Member");
            }
            return member;
        }

        public void LoadMemberList()
        {
            var members = memberRepository.GetMemberList();

            try
            {

                source = new BindingSource();
                source.DataSource = members;

                txtMemberID.DataBindings.Clear();
                txtCompanyName.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                txtPassword.DataBindings.Clear();
                txtCity.DataBindings.Clear();
                txtCountry.DataBindings.Clear();


                txtMemberID.DataBindings.Add("Text", source, "MemberID");
                txtCompanyName.DataBindings.Add("Text", source, "CompanyName");
                txtPassword.DataBindings.Add("Text", source, "Password");
                txtEmail.DataBindings.Add("Text", source, "Email");
                txtCity.DataBindings.Add("Text", source, "City");
                txtCountry.DataBindings.Add("Text", source, "Country");


                dgvMemberList.DataSource = null;
                dgvMemberList.DataSource = source;

                if (members.Count() == 0)
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
                MessageBox.Show(ex.Message, "Load Member List", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadMemberList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Are you sure want to Delete?", "Member Information Management - Delete Member"
               , MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            try
            {
                if (d == DialogResult.OK)

                {
                    var member = GetMemberObject();
                    memberRepository.DeleteMember(member);
                }

                LoadMemberList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete a member", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmUser frmUser = new frmUser
            {
                InsertOrUpdate = false,
                MemberRepository = memberRepository,
                Text = "Create New Member"
            };
            frmUser.ShowDialog();
            LoadMemberList();
            source.Position = source.Count - 1;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var type = cboSearch.Text.Trim();
            dynamic member = null;
            dynamic search = null;
            try
            {
                switch (type)
                {
                    case "Member ID":
                        search = txtSearch.Text;
                        member = memberRepository.GetMemberList().Where(p => p.MemberId.ToString().Contains(search)).ToList();
                        break;

                    case "Company Name":
                        search = txtSearch.Text;
                        member = memberRepository.GetMemberList().Where(p => p.CompanyName.ToLower().Contains(search.ToLower())).ToList();
                        break;
                }


                dgvMemberList.DataSource = null;
                dgvMemberList.DataSource = member;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wrong input Type Data", "Search Members", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboCity_SelectedValueChanged(object sender, EventArgs e)
        {
            var filter = cboCity.Text;
            try
            {
                var listMember = memberRepository.GetMemberList().Where(p => p.City.Equals(filter)).ToList();
                if (listMember.Count > 0)
                {
                    source = new BindingSource();
                    source.DataSource = listMember;

                    txtMemberID.DataBindings.Clear();
                    txtCompanyName.DataBindings.Clear();
                    txtEmail.DataBindings.Clear();
                    txtPassword.DataBindings.Clear();
                    txtCity.DataBindings.Clear();
                    txtCountry.DataBindings.Clear();


                    txtMemberID.DataBindings.Add("Text", source, "MemberID");
                    txtCompanyName.DataBindings.Add("Text", source, "CompanyName");
                    txtPassword.DataBindings.Add("Text", source, "Password");
                    txtEmail.DataBindings.Add("Text", source, "Email");
                    txtCity.DataBindings.Add("Text", source, "City");
                    txtCountry.DataBindings.Add("Text", source, "Country");

                    dgvMemberList.DataSource = null;
                    dgvMemberList.DataSource = source;

                    if (listMember.Count() == 0)
                    {
                        ClearText();
                        btnDelete.Enabled = false;
                    }
                    else
                    {
                        btnDelete.Enabled = true;
                    }

                }
                else
                {
                    MessageBox.Show("Nobody in this City!!", "Filter City");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filter city!!", "Filter City");
            }
        }

        private void cboCountry_SelectedValueChanged(object sender, EventArgs e)
        {
            var filter = cboCountry.Text;
            try
            {
                var listMember = memberRepository.GetMemberList().Where(p => p.Country.Equals(filter)).ToList();
                if (listMember.Count > 0)
                {
                    
                    dgvMemberList.DataSource = null;
                    dgvMemberList.DataSource = listMember;
                }
                else
                {
                    MessageBox.Show("Nobody in this Country!!", "Filter Country");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filter Country!!", "Filter Country");
            }
        }
    }
}
