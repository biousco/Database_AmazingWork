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
    public class Manager : IManager
    {
        public Manager() { }

        public bool Login(string user_id, string user_pwd)
        {
                string strSql = "select count(1) from [Manager] where m_id=@m_id and m_pwd=@m_pwd ";
                SqlParameter[] parameters ={
                           new SqlParameter ("@m_id",SqlDbType .VarChar,50),
                           new SqlParameter ("@m_pwd",SqlDbType .VarChar ,50)
                                      };
                parameters[0].Value = user_id;
                parameters[1].Value = user_pwd;

                int n = Convert.ToInt32(SqlDbHelper.ExecuteScalar(strSql, CommandType.Text, parameters));
                if (n == 1)
                    return true;
                else
                    return false;

        }

        public Model.Manager GetManagerName(string r_id)
        {
            string strSql = "select r_name from [Manager] where m_id=@r_id";
            SqlParameter[] parameters ={
                           new SqlParameter ("@r_id",SqlDbType .VarChar,50),
                                      };
            parameters[0].Value = r_id;

            Model.Manager model = new Model.Manager();
            DataTable dt = SqlDbHelper.ExecuteDataTable(strSql.ToString(),
                             CommandType.Text, parameters);
            if(dt.Rows.Count > 0)
            {
                model.Name = dt.Rows[0].ItemArray[0].ToString();
            }
            return model;

        }
    }
}
