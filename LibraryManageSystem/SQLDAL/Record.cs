﻿using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace SQLDAL
{
    public class Record : IRecord
    {
        public Record() { }

        /// <summary>
        /// 得到所有借阅记录
        /// </summary>
        /// <returns></returns>
        public DataTable getAllRecord()
        {
            string strSql = "select Book.b_id,b_name,Viewer.r_id,Viewer.r_name,author,publisher,borrow_date,state from [BorrowInfo],[Book],[Viewer] where BorrowInfo.b_id = Book.b_id and BorrowInfo.r_id = Viewer.r_id";
            DataTable dt = SqlDbHelper.ExecuteDataTable(strSql.ToString());
            return dt;
        }

        /// <summary>
        /// 根据个人用户得到借阅记录
        /// </summary>
        /// <param name="viewer"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable getUserRecord(Model.Viewer viewer, string sql)
        {
            string strSql = "select Book.b_id,b_name,author,publisher,borrow_date,state  from [BorrowInfo],[Book] where r_id=@r_id and BorrowInfo.b_id = Book.b_id";
            SqlParameter[] parameters ={
                           new SqlParameter ("@r_id",SqlDbType .VarChar,50),
                                      };
            parameters[0].Value = viewer.Id;

            DataTable dt = SqlDbHelper.ExecuteDataTable(strSql.ToString(),
                             CommandType.Text, parameters);
            return dt;
        }

        /// <summary>
        /// 根据书籍编号和借阅人编号得到借阅时间
        /// </summary>
        /// <param name="book"></param>
        /// <param name="viewer"></param>
        /// <returns></returns>
        public DateTime getRecordBorrowTime(Model.Book book, Model.Viewer viewer)
        {
            string strSql = "select borrow_date from [BorrowInfo] where r_id=@r_id and b_id=@b_id";
            SqlParameter[] parameters ={
                           new SqlParameter ("@r_id",SqlDbType .VarChar,50),
                           new SqlParameter ("@b_id",SqlDbType.VarChar,50)
                                      };
            parameters[0].Value = viewer.Id;
            parameters[1].Value = book.Id;

            DataTable dt = SqlDbHelper.ExecuteDataTable(strSql.ToString(),
                 CommandType.Text, parameters);
            string result ="";
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["borrow_date"] != null && dt.Rows[0]["borrow_date"].ToString() != "")
                {
                    result = dt.Rows[0]["borrow_date"].ToString();
                }
            }
            result = result.Split(' ')[0];
            DateTime dateresult = new DateTime();
            try
            {
                dateresult = DateTime.Parse(result);
            } catch (FormatException e)
            {
                
            }
            return dateresult;
        }
    }
}
