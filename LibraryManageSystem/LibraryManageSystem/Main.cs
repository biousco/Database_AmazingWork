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
            Fill();
            InitColName();
        }

        public void InitColName ()
        {
            String [] ColName = { "书籍编号", "书籍名称", "书籍作者", "出版社", "现存数" };
            for(int i = 0; i < dgvBookList.Columns.Count; i++)
            {
                dgvBookList.Columns[i].HeaderText = ColName[i];
            }
            

        }

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

        private void Main_Load(object sender, EventArgs e)
        {
            Fill();
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
    }
}
