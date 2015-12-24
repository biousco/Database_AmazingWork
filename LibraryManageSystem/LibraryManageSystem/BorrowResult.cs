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
    public partial class BorrowResult : Form
    {
        LMSBLL.Book Book = new LMSBLL.Book();
        LMSBLL.Viewer Viewer = new LMSBLL.Viewer();

        Model.Viewer viewer = new Model.Viewer();
        Model.Book book = new Model.Book();
        Model.Manager manager = new Model.Manager();

        public BorrowResult()
        {
            InitializeComponent();
        }

        public BorrowResult(Model.Viewer _viewer, Model.Book _book, Model.Manager _manager)
        {
            InitializeComponent();
            viewer = _viewer;
            book = _book;
            manager = _manager;
            RenderData(viewer, book, manager);
        }

        public void RenderData(Model.Viewer viewer, Model.Book book, Model.Manager manager)
        {
            UserNoLabel.Text = viewer.Id;
            NameLabel.Text = Viewer.GetViewerName(viewer.Id);
            Model.Book _book = Book.GetSingleBook(book.Id);
            BookNumLabel.Text = book.Id;
            BookNameLabel.Text = _book.Name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool result = Book.ReturnBook(viewer, book, manager);
            if(result == true)
            {
                MessageBox.Show("归还成功！");
                this.DialogResult = DialogResult.OK;
            } else
            {
                MessageBox.Show("归还失败！");
            }
        }

        private void BorrowResult_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
