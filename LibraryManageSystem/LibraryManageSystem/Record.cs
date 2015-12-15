﻿using System;
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
    public partial class Record : Form
    {
        LMSBLL.Record record_bll = new LMSBLL.Record();
        public Record()
        {
            InitializeComponent();
            RenderData();
        }

        private void RenderData ()
        {
            Model.Viewer viewer = new Model.Viewer();
            string sql = "";
            //学生
            if(UserHelper.IDENTITY == 0)
            {

                viewer.Id = UserHelper.userId;
                dataGridView1.DataSource = record_bll.GetUserRecord(viewer, sql);
                String[] ColName = { "书籍编号", "书籍名称", "书籍作者", "出版社", "借阅日期","状态" };
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].HeaderText = ColName[i];
                }

            } else if (UserHelper.IDENTITY == 1)
            {
                viewer.Id = UserHelper._userId;
            }
            if(comboBox1.Text == "逾期记录")
            {
                sql = "";
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}