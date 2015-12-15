using IDAL;
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


        public DataTable getAllRecord(string sql)
        {

            throw new NotImplementedException();
        }

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
    }
}
