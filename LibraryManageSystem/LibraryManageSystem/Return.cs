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
    public partial class Return : Form
    {
        Model.Viewer viewer = new Model.Viewer();
        Model.Book book = new Model.Book();
        Model.Manager manager = new Model.Manager();

        public Return()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            viewer.Id = returnUserNoForm.Text;
            book.Id = returnBookNoForm.Text;
            manager.Id = UserHelper.userId;
            BorrowResult form = new BorrowResult(viewer, book, manager);
            form.ShowDialog();
        }
    }
}
