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
    public partial class BookManage : Form
    {
        LMSBLL.Book bll = new LMSBLL.Book();

        public BookManage()
        {
            InitializeComponent();
            InitColName();
            Fill();
        }

        private void BookManage_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 渲染表列名
        /// </summary>
        public void InitColName()
        {
            String[] ColName = { "书籍编号", "书籍名称", "书籍作者", "出版社", "现存数" };
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].HeaderText = ColName[i];
            }
        }

        /// <summary>
        /// 填充书籍列表数据
        /// </summary>
        public void Fill()
        {
            dataGridView1.DataSource = bll.GetList("");
        }

        /// <summary>
        /// 添加书籍
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void borrowBtn_Click(object sender, EventArgs e)
        {
            BookDetail form = new BookDetail(1);
            form.ShowDialog();
        }

        /// <summary>
        /// 修改书籍
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editBtn_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;
            string book_id = dataGridView1.Rows[index].Cells["b_id"].Value.ToString();
            BookDetail form = new BookDetail(2,book_id);
            form.ShowDialog();
        }
    }
}
