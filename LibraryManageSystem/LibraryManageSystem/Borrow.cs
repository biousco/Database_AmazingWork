using System;
using System.Collections;
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
        Model.Viewer viewer = new Model.Viewer();
        Model.Manager manager = new Model.Manager();
        Model.Book book = new Model.Book();
        public Borrow()
        {
            InitializeComponent();
            renderData();
        }

        public void renderData ()
        {
            userNameLabel.Text = viewer.Name = UserHelper._userName;
            userIdLabel.Text = viewer.Id = UserHelper._userId;
            BookNameLabel.Text = book.Name = BookHelper.book_name;
            BookIdLabel.Text = book.Id = BookHelper.book_id;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            manager.Name = UserHelper.userName;
            manager.Id = UserHelper.userId;
            Hashtable result = Book.Borrow(book, viewer, manager);
            MessageBox.Show(result["msg"].ToString());
            this.Close();
        }

        private void Borrow_Load(object sender, EventArgs e)
        {

        }

        private void borrowUserNoINput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
