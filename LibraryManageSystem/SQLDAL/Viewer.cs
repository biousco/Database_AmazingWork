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

        }

        public Model.Viewer GetViewerName(string r_id)
        {
            string strSql = "select r_name from [Viewer] where r_id=@r_id";
            SqlParameter[] parameters ={
                           new SqlParameter ("@r_id",SqlDbType .VarChar,50),
                                      };
            parameters[0].Value = r_id;

            Model.Viewer model = new Model.Viewer();
            DataTable dt = SqlDbHelper.ExecuteDataTable(strSql.ToString(),
                             CommandType.Text, parameters);
            if(dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["r_name"] != null && dt.Rows[0]["r_name"].ToString() != "")
                {
                    model.Name = dt.Rows[0]["r_name"].ToString();
                }
            }
            return model;

        }
    }
}
