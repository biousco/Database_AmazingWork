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
    public partial class Main : Form
    {
        LMSBLL.Book bll = new LMSBLL.Book();
        public Main()
        {
            InitializeComponent();
            Fill();
        }

        public void Fill()
        {
            string sqlStr = "";

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
    }
}
