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
    public partial class BorrowDialog : Form
    {
        LMSBLL.Book Book = new LMSBLL.Book();
        LMSBLL.Viewer viewer = new LMSBLL.Viewer();
        public BorrowDialog()
        {
            InitializeComponent();
        }

        public BorrowDialog(string book_id)
        {
            InitializeComponent();
            renderData(book_id);
        }

        public void renderData(string book_id)
        {
            Model.Book model = Book.GetSingleBook(book_id);
            BookNameLabel.Text = model.Name;
            BookIdLabel.Text = model.Id;
            BookHelper.book_id = model.Id;
            BookHelper.book_name = model.Name;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="form"></param>
        public void UpdateData(Form form)
        {
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Model.Viewer v = new Model.Viewer();
            v.Id = borrowUserNoLabel.Text;
            if (!ValidateHelper.validateViewer(v))
            {
                MessageBox.Show("用户不存在！");
                return;
            }

            string borrowUserNo = borrowUserNoLabel.Text;
            string userName = viewer.GetViewerName(borrowUserNo);
            UserHelper._userName = userName;
            UserHelper._userId = borrowUserNo;
            Borrow form = new Borrow();
            UpdateData(form);
        }

        private void BorrowDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
