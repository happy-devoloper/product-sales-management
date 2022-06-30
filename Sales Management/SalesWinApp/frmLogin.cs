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
    public partial class frmLogin : Form
    {

        IMemberRepository memberRepository = new MemberRepository();

        public frmLogin()
        {
            InitializeComponent();
            memberRepository.GetMemberList();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var member = new Member
                {
                    Email = txtEmail.Text,
                    Password = txtPassword.Text
                };

                Boolean checkLogin = memberRepository.CheckLogin(member.Email, member.Password);
                if (checkLogin)
                {
                    frmMain frmMain = new frmMain
                    {
                        Text = "Admin Management"
                    };
                    this.Hide();

                    if (frmMain.ShowDialog() == DialogResult.Yes)
                    {
                        this.Show();
                    }
                }
                else
                {
                    frmUser frmuser = new frmUser
                    {
                        Text = "User Detail",
                        MemberRepository = memberRepository,
                        InsertOrUpdate = true,
                        MemberInfo = memberRepository.GetMemberByEmail(member.Email)
                    };
                    this.Hide();
                    if (frmuser.ShowDialog() == DialogResult.Yes)
                    {
                        this.Show();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login");
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
