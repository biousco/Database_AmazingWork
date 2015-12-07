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
    public partial class Borrow : Form
    {
        LMSBLL.Book Book = new LMSBLL.Book();
        public Borrow()
        {
            InitializeComponent();
            renderData();
        }

        public void renderData ()
        {
            userNameLabel.Text = UserHelper._userName;
            userIdLabel.Text = UserHelper._userId;
            BookNameLabel.Text = BookHelper.book_name;
            BookIdLabel.Text = BookHelper.book_id;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Borrow_Load(object sender, EventArgs e)
        {

        }

        private void borrowUserNoINput_TextChanged(object sender, EventArgs e)
        {

        }

        private void borrowUserNoINput_lostFucus(object sender, EventArgs e)
        {
            MessageBox.Show("用户名或密码错误，请重新输入！", "错误");
        }
    }
}
