using IDAL;
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
