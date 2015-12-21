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
    public partial class Main : Form
    {
        LMSBLL.Book bll = new LMSBLL.Book();
        public Main()
        {
            InitializeComponent();
            HelloUser();
            Fill();
            InitColName();
            Authorized();
        }

        /// <summary>
        /// 渲染表列名
        /// </summary>
        public void InitColName ()
        {
            String [] ColName = { "书籍编号", "书籍名称", "书籍作者", "出版社", "现存数" };
            for(int i = 0; i < dgvBookList.Columns.Count; i++)
            {
                dgvBookList.Columns[i].HeaderText = ColName[i];
            }
        }

        /// <summary>
        /// 填充书籍列表数据
        /// </summary>
        public void Fill()
        {
            string sqlStr = "";
            Hashtable type_str = new Hashtable();
            type_str.Add("书籍编号", "b_id");
            type_str.Add("书籍名称", "b_name");
            type_str.Add("书籍作者", "author");
            if (searchType.Text != "")
            {
                sqlStr = (string)type_str[searchType.Text] + " like '%" + searchStr.Text.Trim() + "%'";
            }
            
            dgvBookList.DataSource = bll.GetList(sqlStr);
        }

        /// <summary>
        /// 根据游客和管理员展示不同按钮
        /// </summary>
        public void Authorized()
        {
            int prior = UserHelper.IDENTITY;
            if(prior == 0)
            {
                this.Controls.Remove(borrowBtn);
                this.Controls.Remove(returnBtn);
            }
        }

        public void HelloUser()
        {
            string name_p = "";
            if(UserHelper.IDENTITY == 1)
            {
                name_p = "管理员";
            } else
            {
                name_p = "同学";
            }
            WelcomeLabel.Text = "欢迎你！" + UserHelper.userName + name_p;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void search_btn_click(object sender, EventArgs e)
        {
            Fill();
        }

        /// <summary>
        /// 弹出借阅详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            
            int index = dgvBookList.CurrentRow.Index;
            string book_id = dgvBookList.Rows[index].Cells["b_id"].Value.ToString();
            BorrowDialog form = new BorrowDialog(book_id);
            form.ShowDialog();
            this.Close();
        }

        private void returnBtn_Click(object sender, EventArgs e)
        {
            int index = dgvBookList.CurrentRow.Index;
            string book_id = dgvBookList.Rows[index].Cells["b_id"].Value.ToString();
            Return form = new Return(book_id);
            form.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Record form = new Record();
            form.ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
