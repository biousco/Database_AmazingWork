﻿using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Model;
using System.Data.SqlClient;

namespace SQLDAL
{
    class Book : IBook
    {
        public Book() { }

        /// <summary>
        /// 借阅书籍
        /// </summary>
        /// <param name="book"></param>
        /// <param name="viewer"></param>
        /// <returns></returns>
        public bool Borrow(Model.Book book, Model.Viewer viewer, Model.Manager manager)
        {
            string procedureName = "BorrowBook";
            SqlParameter[] parameters =
            {
                new SqlParameter ("@b_id",SqlDbType.VarChar,20),
                new SqlParameter ("@r_id",SqlDbType.VarChar,20),
                new SqlParameter ("@amount",SqlDbType.Int),
                new SqlParameter ("@borrow_date",SqlDbType.Date),
                new SqlParameter ("@m_id",SqlDbType.VarChar,20),
            };
            parameters[0].Value = book.Id;
            parameters[1].Value = viewer.Id;
            parameters[2].Value = 1;
            parameters[3].Value = new DateTime();
            parameters[4].Value = manager.Id;
            int i;
            i = SqlDbHelper.ExecuteNonQueryBySP(procedureName, CommandType.StoredProcedure, parameters);

            if (i == 1)
            {
                return true;
            } else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到书籍列表
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <returns></returns>
        public DataTable GetList(string sqlStr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select b_id,b_name,author,publisher,amount ");
            strSql.Append("from Book");


            if (sqlStr.Trim() != "")
                strSql.Append(" where " + sqlStr);
            strSql.Append(" order by b_id desc");

            return SqlDbHelper.ExecuteDataTable(strSql.ToString());
        }

        /// <summary>
        /// 根据书籍id号得到书籍结果
        /// </summary>
        /// <param name="book_id"></param>
        /// <returns></returns>
        public Model.Book GetSingleBook(string book_id)
        {
            string strSql = "select * from [Book] where b_id=@book_id";
            SqlParameter[] parameters ={
                           new SqlParameter ("@book_id",SqlDbType .VarChar,50),
                                      };
            parameters[0].Value = book_id;

            Model.Book model = new Model.Book();
            DataTable dt = SqlDbHelper.ExecuteDataTable(strSql.ToString(),
                             CommandType.Text, parameters);
            if (dt.Rows.Count > 0)
            {
                model.Id = dt.Rows[0].ItemArray[0].ToString();
                model.Name = dt.Rows[0].ItemArray[1].ToString();
                model.Author = dt.Rows[0].ItemArray[2].ToString();
                model.Publisher = dt.Rows[0].ItemArray[3].ToString();
                model.Amount = dt.Rows[0].ItemArray[4].ToString();
            }
            return model;
        }
    }
}
