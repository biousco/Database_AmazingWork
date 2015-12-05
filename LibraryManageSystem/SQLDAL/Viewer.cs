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

            string connstr = "Data Source=.;Initial Catalog=LibraryManage;Integrated Security=True";
                string strSql = "select count(1) from [Viewer] where r_id=@r_id and r_pwd=@r_pwd ";
                SqlParameter[] parameters ={
                           new SqlParameter ("@r_id",SqlDbType .VarChar,50),
                           new SqlParameter ("@r_pwd",SqlDbType .VarChar ,50)
                                      };
                parameters[0].Value = user_id;
                parameters[1].Value = user_pwd;

                int n = Convert.ToInt32(SqlDbHelper.ExecuteScalar(strSql, CommandType.Text, parameters));
                if (n == 1)
                    return true;
                else
                    return false;




            //return true;


        }
    }
}
