using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

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
                strSql.Append(" and " + sqlStr);
            strSql.Append(" order by b_id desc");

            return SqlDbHelper.ExecuteDataTable(strSql.ToString());
        }
    }
}
