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
    public partial class BookDetail : Form
    {
        LMSBLL.Book bll = new LMSBLL.Book();
        //标志当前的操作：1为添加，2为编辑
        int CURRENT_TYPE;

        public BookDetail()
        {
            InitializeComponent();
        }

        public BookDetail(int type, string book_id)
        {
            InitializeComponent();
            if(type == 2)
            {
                titleLabel.Text = "修改书籍";
            }
            Model.Book book =  bll.GetSingleBook(book_id);
            textBox1.Text = book.Name;
            textBox2.Text = book.Id;
            textBox3.Text = book.Author;
            textBox4.Text = book.Publisher;
            textBox5.Text = book.Amount;
        }

        public BookDetail(int type)
        {
            InitializeComponent();
            if (type == 1)
            {
                titleLabel.Text = "添加书籍";
                CURRENT_TYPE = 1;
            }

        }

        private void BookDetail_Load(object sender, EventArgs e)
        {
            
        }

        private void FillData()
        {

        }

        private Model.Book getBook()
        {
            Model.Book book = new Model.Book();
            book.Name = textBox1.Text;
            book.Id = textBox2.Text;
            book.Author = textBox3.Text;
            book.Publisher = textBox4.Text;
            book.Amount = textBox5.Text;
            return book;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Model.Book m_book = new Model.Book();
            m_book = getBook();
            if(CURRENT_TYPE == 1)
            {
                bool result = bll.AddBook(m_book);
                if(result)
                {
                    MessageBox.Show("书籍添加成功！");
                } else
                {
                    MessageBox.Show("书籍添加失败...");
                }
            }
        }
    }
}
