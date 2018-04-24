
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
//using System.Data.SQLite.Generic;

namespace COMM
{

    public class SQLiteDBHelper
    {

        private static string DbName = "Data Source=";
        private static string _ConnString;
        /// <summary>
        /// SQLite Connection String. eg:"Data Source=C:/MySeo.s3db"
        /// @"F:\Fer.FileCollector\FileCollector\document\documents.dat"
        /// </summary>
        public static string ConnString
        {
            get { return _ConnString; }
            set { _ConnString = DbName + value; }
        }

        static SQLiteDBHelper()
        {
            //  _ConnString = DbName +Environment.CurrentDirectory+"/"+ ConfigurationManager.AppSettings["sqlConnection"];
        }

        /// <summary>
        /// 新建连接对象
        /// </summary>
        /// <param name="ConnString">"Data Source=C:/MySeo.s3db"</param>
        /// <returns></returns>
        public static SQLiteConnection GetSQLiteConnection(string ConnString)
        {
            return new SQLiteConnection(ConnString);
        }

        /// <summary>
        /// 获得当前连接对象
        /// </summary>
        /// <returns></returns>
        public static SQLiteConnection GetSQLiteConnection()
        {
            try
            {
                if (string.IsNullOrEmpty(_ConnString))
                {
                    //throw new Exception("this SQLLite Connection is null.");
                    return null;
                }
                return GetSQLiteConnection(_ConnString);
            }
            catch
            {
                throw;
            }
        }




        /// <summary>
        /// 添加参数到Command对象
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="conn"></param>
        /// <param name="cmdText"></param>
        /// <param name="p"></param>
        private static void PrepareCommand(SQLiteCommand cmd, SQLiteConnection conn, string cmdText, params SQLiteParameter[] p)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                cmd.Parameters.Clear();
                cmd.Connection = conn;
                cmd.CommandText = cmdText;

                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 30;

                if (p != null)
                {
                    foreach (SQLiteParameter parm in p)
                    {
                        cmd.Parameters.Add(parm);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 执行语句返回DateSet
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataset(string cmdText, params SQLiteParameter[] p)
        {
            try
            {
                DataSet ds = new DataSet();
                SQLiteCommand command = new SQLiteCommand();
                using (SQLiteConnection connection = GetSQLiteConnection())
                {
                    PrepareCommand(command, connection, cmdText, p);
                    SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                    da.Fill(ds);
                }
                return ds;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 执行语句返回DataRow
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static DataRow ExecuteDataRow(string cmdText, params SQLiteParameter[] p)
        {
            try
            {
                DataSet ds = ExecuteDataset(cmdText, p);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0];
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 执行非查询语句，返回受影响的行数
        /// </summary>
        /// <param name="cmdText">a</param>
        /// <param name="commandParameters">传入的参数</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string cmdText, params SQLiteParameter[] p)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand();

                using (SQLiteConnection connection = GetSQLiteConnection())
                {
                    PrepareCommand(command, connection, cmdText, p);
                    return command.ExecuteNonQuery();
                }
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 返回SqlDataReader对象
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters">传入的参数</param>
        /// <returns></returns>
        public static SQLiteDataReader ExecuteReader(string cmdText, params SQLiteParameter[] p)
        {
            SQLiteCommand command = new SQLiteCommand();
            SQLiteConnection connection = GetSQLiteConnection();
            try
            {
                PrepareCommand(command, connection, cmdText, p);
                SQLiteDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch
            {
                connection.Close();
                throw;
            }
        }

        /// <summary>
        /// 返回结果集中的第一行第一列，忽略其他行或列
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters">传入的参数</param>
        /// <returns></returns>
        public static object ExecuteScalar(string cmdText, params SQLiteParameter[] p)
        {
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                using (SQLiteConnection connection = GetSQLiteConnection())
                {
                    PrepareCommand(cmd, connection, cmdText, p);
                    return cmd.ExecuteScalar();
                }
            }
            catch
            {
                throw;
            }
        }

    }
}

