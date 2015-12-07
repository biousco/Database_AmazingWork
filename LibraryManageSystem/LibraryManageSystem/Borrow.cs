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
        }

        public Borrow (string book_id)
        {
            InitializeComponent();
            renderData(book_id);
        }

        public void renderData (string book_id)
        {
            Model.Book model = Book.GetSingleBook(book_id);
            userNameLabel.Text = UserHelper.userName;
            userIdLabel.Text = UserHelper.userId;
            BookNameLabel.Text = model.Name;
            BookIdLabel.Text = model.Id;
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
    }
}
