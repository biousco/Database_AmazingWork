﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace SQLDAL
{

    ///<summary>
    ///针对SQL SERVER 数据库操作的通用类
    ///</summary>
    public class SqlDbHelper
    {
        private static string connString =
            ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        ///<summary>
        ///设置数据库连接字符串；
        ///</summary>

        public static string ConnectionString
        {
            get { return connString; }
            set { connString = value; }
        }

        //对数据库进行非连接的查询操作方法，获得多条查询记录 
        public static DataTable ExecuteDataTable(string commandText, CommandType commandType, SqlParameter[] parameters)
        {
            DataTable data = new DataTable();//实例化DataTable，用于装载查询结果集
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = commandType;//设置command的CommandType为指定的CommandType
                    //如果同时传入了参数，则添加这些参数
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    //通过包含查询SQL的SqlCommand实例来实例化SqlDataAdapter
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);//填充DataTable
                }
            }
            return data;
        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string commandText)
        {
            return ExecuteDataTable(commandText, CommandType.Text, null);
        }
        public static DataTable ExecuteDataTable(string commandText, CommandType commandType)
        {
            return ExecuteDataTable(commandText, commandType, null);
        }

        //编写ExecuteReader方法对数据库连接式操作，获取多条记录
        public static SqlDataReader ExecuteReader(string commandText,
               CommandType commandType, SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(connString);
            SqlCommand command = new SqlCommand(commandText, connection);
            command.CommandType = commandType;
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public static SqlDataReader ExecuteReader(string commandText)
        {
            return ExecuteReader(commandText,
               CommandType.Text, null);
        }
        public static SqlDataReader ExecuteReader(string commandText, CommandType commandType)
        {
            return ExecuteReader(commandText, commandType, null);
        }

        /////编写ExecuteScalar

        public static Object ExecuteScalar(string commandText,
                    CommandType commandType, SqlParameter[] parameters)
        {
            Object result = null;
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    //设置command的CommandType为指定的CommandType
                    command.CommandType = commandType;
                    //如果同时传入了参数，则添加这些参数
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    connection.Open();

                    result = command.ExecuteScalar();
                }
            }
            return result;
        }


        public static object ExecuteScalar(string commandText)
        {
            return ExecuteScalar(commandText,
               CommandType.Text, null);
        }
        public static Object ExecuteScalar(string commandText, CommandType commandType)
        {
            return ExecuteScalar(commandText, commandType, null);
        }

        ///////////////////编写ExecuteNonQuery

        public static int ExecuteNonQuery(string commandText,
                        CommandType commandType, SqlParameter[] parameters)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    //设置command的CommandType为指定的CommandType
                    command.CommandType = commandType;
                    //如果同时传入了参数，则添加这些参数
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    connection.Open();
                    count = command.ExecuteNonQuery();
                }
            }
            return count;
        }


        public static int ExecuteNonQuery(string commandText)
        {
            return ExecuteNonQuery(commandText,
               CommandType.Text, null);
        }
        public static int ExecuteNonQuery(string commandText, CommandType commandType)
        {
            return ExecuteNonQuery(commandText, commandType, null);
        }
    }
}