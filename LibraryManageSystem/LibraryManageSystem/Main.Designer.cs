namespace LibraryManageSystem
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.searchType = new System.Windows.Forms.ComboBox();
            this.searchStr = new System.Windows.Forms.TextBox();
            this.search_btn = new System.Windows.Forms.Button();
            this.dgvBookList = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(21, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择查询条件";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // searchType
            // 
            this.searchType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.searchType.FormattingEnabled = true;
            this.searchType.ItemHeight = 14;
            this.searchType.Items.AddRange(new object[] {
            "书籍编号",
            "书籍名称",
            "书籍作者"});
            this.searchType.Location = new System.Drawing.Point(133, 23);
            this.searchType.Name = "searchType";
            this.searchType.Size = new System.Drawing.Size(130, 22);
            this.searchType.TabIndex = 1;
            this.searchType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // searchStr
            // 
            this.searchStr.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.searchStr.Location = new System.Drawing.Point(289, 22);
            this.searchStr.Name = "searchStr";
            this.searchStr.Size = new System.Drawing.Size(165, 26);
            this.searchStr.TabIndex = 2;
            // 
            // search_btn
            // 
            this.search_btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.search_btn.Location = new System.Drawing.Point(484, 20);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(105, 28);
            this.search_btn.TabIndex = 3;
            this.search_btn.Text = "搜索";
            this.search_btn.UseVisualStyleBackColor = true;
            this.search_btn.Click += new System.EventHandler(this.search_btn_click);
            // 
            // dgvBookList
            // 
            this.dgvBookList.AllowUserToAddRows = false;
            this.dgvBookList.AllowUserToDeleteRows = false;
            this.dgvBookList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookList.Location = new System.Drawing.Point(25, 72);
            this.dgvBookList.Name = "dgvBookList";
            this.dgvBookList.ReadOnly = true;
            this.dgvBookList.RowTemplate.Height = 23;
            this.dgvBookList.Size = new System.Drawing.Size(564, 268);
            this.dgvBookList.TabIndex = 4;
            this.dgvBookList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(77, 361);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 39);
            this.button2.TabIndex = 5;
            this.button2.Text = "借阅";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.Location = new System.Drawing.Point(402, 361);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 39);
            this.button4.TabIndex = 7;
            this.button4.Text = "归还";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 439);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dgvBookList);
            this.Controls.Add(this.search_btn);
            this.Controls.Add(this.searchStr);
            this.Controls.Add(this.searchType);
            this.Controls.Add(this.label1);
            this.Name = "Main";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox searchType;
        private System.Windows.Forms.TextBox searchStr;
        private System.Windows.Forms.Button search_btn;
        private System.Windows.Forms.DataGridView dgvBookList;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
    }
}