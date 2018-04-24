using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql;
using COMM;

namespace DAL
{
    /// <summary>
    /// 消息面板的数据库操作类
    /// </summary>
    public class NoticeDal
    {

        public NoticeDal()
        {
 
        }

        /// <summary>
        /// 判断文档是否存在
        /// </summary>
        /// <returns></returns>
        public int ContentIsExsit()
        {

            int ret = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "select count(tid) from notice;";
                ret = Convert.ToInt32(MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, strSql, null));
                //return Convert.ToInt32(MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null));
                return ret;
            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return 0;
            }


        }


        /// <summary>
        /// 插入文本文本内容
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private  int InsertNoticeInfo(string info)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {


                DateTime theDate = DateTime.Now;
                theDate.ToString("yyyy-MM-dd HH:mm:ss");

                strSql = "insert into  notice (tid,content,update_time) values(1,'{0}','{1}')";

                strSql = string.Format(strSql, info, theDate);

                ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);

                return ret;

            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return 0;
            }
        }



        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public int UpdateNotice(string content)
        {

            try
            {

                if (ContentIsExsit()>0)
                {
                    if (UpdateNoticeInfo(content) > 0)
                        return 1;
                }
                else
                {
                    if (InsertNoticeInfo(content) > 0)
                        return 1;
                }

                return 0;
            }
            catch(Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return 0;
            }
        }


        /// <summary>
        /// 更新面板消息
        /// </summary>
        /// <param name="info"></param>
        private  int UpdateNoticeInfo(string info)
        {

            int ret = 0;

            string strSql=string.Empty;

            try
            {

             DateTime theDate = DateTime.Now;
             theDate.ToString("yyyy-MM-dd HH:mm:ss");
             strSql = "update notice set content='{0}', update_time='{1}' where tid=1";
             strSql = string.Format(strSql,info,theDate);

             ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql,null);

             return ret;

            }
            catch(Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return 0;
            }
        }


        /// <summary>
        /// 
        /// 获取广报版信息
        /// </summary>
        /// <returns></returns>
        public  string GetNoticeInfo()
        {

            string ret = string.Empty;

            object obj = null;


            try
            {
                string strSql = "select content from notice order by update_time";

                obj = MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (obj != null)
                    ret = Convert.ToString(obj);
             
                return ret;
            }
            catch(Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return string.Empty;
            }
        }

    }
}
