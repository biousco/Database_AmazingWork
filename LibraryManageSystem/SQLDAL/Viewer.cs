using IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDAL
{
    public class Viewer : IViewer
    {
        public Viewer() { }
        public bool Login(string user_id, string user_pwd)
        {
            //string strSql = "ViewerValid";
            //SqlParameter[] parameters = {
            //    new SqlParameter ("@r_id",System.Data.SqlDbType.VarChar,50),
            //    new SqlParameter ("@r_pwd", System.Data.SqlDbType.VarChar, 50)
            //};
            //parameters[0].Value = user_id;
            //parameters[1].Value = user_pwd;

            //SqlDataReader reader = SqlDbHelper.ExecuteReader(strSql, CommandType.StoredProcedure, parameters);

            string connstr = "Data Source=BIOUSCO\SQLEXPRESS;Initial Catalog=LibraryManage;Integrated Security=True";
            using (SqlConnection conn = connstr)
            {
                SqlCommand cmd = new SqlCommand(); //创建command对象
                cmd.Connection = "Data Source=BIOUSCO\SQLEXPRESS;Initial Catalog=LibraryManage;Integrated Security=True";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ViewerValid";
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
            }


            
            return true;


        }
    }
}
