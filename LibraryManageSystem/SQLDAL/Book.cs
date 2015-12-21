using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Model;
using System.Data.SqlClient;
using System.Xml;
using System.Collections;

namespace SQLDAL
{
    public class Book : IBook
    {
        public Book() { }

        /// <summary>
        /// 借阅书籍
        /// </summary>
        /// <param name="book"></param>
        /// <param name="viewer"></param>
        /// <returns></returns>
        public Hashtable Borrow(Model.Book book, Model.Viewer viewer, Model.Manager manager)
        {
            string procedureName = "BorrowBook";
            SqlParameter[] parameters =
            {
                new SqlParameter ("@b_id",SqlDbType.VarChar,20),
                new SqlParameter ("@r_id",SqlDbType.VarChar,20),
                new SqlParameter ("@amount",SqlDbType.Int),
                new SqlParameter ("@borrow_date",SqlDbType.DateTime),
                new SqlParameter ("@m_id",SqlDbType.VarChar,20),
                new SqlParameter ("@c",SqlDbType.Int),

            };
            parameters[0].Value = book.Id;
            parameters[1].Value = viewer.Id;
            parameters[2].Value = 1;//?
            parameters[3].Value = DateTime.Now;
            parameters[4].Value = manager.Id;
            parameters[5].Value = 1;

            int i;
            i = SqlDbHelper.ExecuteNonQueryBySP(procedureName, CommandType.StoredProcedure, parameters);

            Hashtable result = new Hashtable();

            if (i == 1)
            {
                result.Add("result", 1);
                result.Add("msg", "添加成功!");
                return result;
            } else if (i == 0)
            {
                result.Add("result", 0);
                result.Add("msg", "书籍已无库存");
                return result;
            } else if (i == -1)
            {
                result.Add("result", -1);
                result.Add("msg", "您已借过此书！");
                return result;
            } else
            {
                result.Add("result", -2);
                result.Add("msg", "系统出错！");
                return result;
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

        /// <summary>
        /// 归还书籍
        /// </summary>
        /// <param name="viewer"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool ReturnBook(Model.Viewer viewer, Model.Book book, Model.Manager manager)
        {
            SQLDAL.Record dal = new Record();
            DateTime borrow_t = dal.getRecordBorrowTime(book, viewer);
            DateTime now_t = DateTime.Now;

            string procedureName = "ReturnBook";
            SqlParameter[] parameters =
            {
                new SqlParameter ("@b_id",SqlDbType.VarChar,20),
                new SqlParameter ("@r_id",SqlDbType.VarChar,20),
                new SqlParameter ("@amount",SqlDbType.Int),
                new SqlParameter ("@return_date",SqlDbType.DateTime),
                new SqlParameter ("@delaytime",SqlDbType.Int),
                new SqlParameter ("@m_id",SqlDbType.VarChar,20),
                new SqlParameter ("@c",SqlDbType.Int),

            };
            parameters[0].Value = book.Id;
            parameters[1].Value = viewer.Id;
            parameters[2].Value = 1;//?
            parameters[3].Value = now_t;
            parameters[4].Value = (now_t-borrow_t).Days;
            parameters[5].Value = manager.Id;
            parameters[6].Value = 1;//?

            int i;
            i = SqlDbHelper.ExecuteNonQueryBySP(procedureName, CommandType.StoredProcedure, parameters);

            if (i == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
