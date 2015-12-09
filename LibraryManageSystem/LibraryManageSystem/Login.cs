using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManageSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userid = txtUserName.Text.Trim();
            string  password = txtPassword.Text.Trim();
            
            if (userid == "" || password == "")
            {
                MessageBox.Show("用户名或密码不能为空！");
                txtUserName.Focus();
                return;
            }
            else
            {
                //先判断是不是游客登陆
                LMSBLL.Viewer viewer = new LMSBLL.Viewer();
                if (viewer.Login(userid, password))
                {
                    string userName = viewer.GetViewerName(userid);
                    UserHelper.userName = userName;
                    UserHelper.userId = userid;
                    UserHelper.IDENTITY = 0;
                    this.Hide();
                    Main f = new Main();
                    f.ShowDialog();
                }
                else
                {
                    LMSBLL.Manager manager = new LMSBLL.Manager();
                    if(manager.Login(userid,password))
                    {
                        string userName = manager.GetViewerName(userid);
                        UserHelper.userName = userName;
                        UserHelper.userId = userid;
                        UserHelper.IDENTITY = 1;
                        this.Hide();
                        Main f = new Main();
                        f.ShowDialog();
                    } else
                    {
                        MessageBox.Show("用户名或密码错误，请重新输入！", "错误");
                        txtUserName.Text = "";
                        txtPassword.Text = "";
                        txtUserName.Focus();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkLabel1.Text == "管理员入口")
            {
                label1.Text = "管理员登陆";
                label1.Location = new Point((this.Width - label1.Width) / 2, 27);
                label2.Text = "账号";
                linkLabel1.Text = "返回";
            }
            else
            {
                label1.Text = "欢迎来到图书管理系统";
                label1.Location = new Point((this.Width - label1.Width) / 2, 27);
                label2.Text = "学号";
                linkLabel1.Text = "管理员入口";
            }
         
            
        }
    }
}
