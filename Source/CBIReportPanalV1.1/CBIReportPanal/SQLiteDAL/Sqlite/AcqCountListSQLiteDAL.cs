using System;
using System.Collections.Generic;
using System.Linq;
using COMM;
using MDL;
using System.Data;

namespace SQLiteDAL
{
    public class AcqCountListSQLiteDAL
    {


        public AcqCountListSQLiteDAL()
        {
 

        }


        /// <summary>
        /// 获取产品个数
        /// </summary>
        /// <returns></returns>
         public int GetRowCount()
         {

             int ret = 0;

             string strSql = string.Empty;

             try
             {
                 strSql = "select count(tid) from acq_count_list;";
                 //ret = Convert.ToInt32(MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, strSql, null));
                 ret = Convert.ToInt32(SQLiteDBHelper.ExecuteScalar(strSql));
                 //return Convert.ToInt32(MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null));
                 return ret;
             }
             catch (Exception ex)
             {
                 CLog.WriteErrLogInTrace(ex.Message);
                 return 0;
             }

         }




         public int GetRangeUnitCount(string tagName)
         {
             try
             {
                 object ret = null;

                 string strSql = "select CurrentCount from acq_count_list where tagName=" + tagName;

                // ret = MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, strSql, null);

                 ret = SQLiteDBHelper.ExecuteScalar(strSql);
                 if (ret != null)
                 {
                     int itemCount = -1;

                     Int32.TryParse(ret.ToString(), out itemCount);


                     if (itemCount < 0)
                         itemCount = 0;

                     return itemCount;

                 }
                 else
                     return 0;


             }
             catch (Exception ex)
             {
                 CLog.WriteErrLogInTrace(ex.Message);
                 return 0;
             }
         }

         /// <summary>
         /// 获取一个范围内的数量总和
         /// </summary>
         /// <returns></returns>
         public int GetRangeItemCount(string tagName)
         {
             
             try
             {
                 object ret=null;

                 string strSql = "select StartCount from acq_count_list where tagName="+tagName;

                 //ret = MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, strSql, null);
                 ret = SQLiteDBHelper.ExecuteScalar(strSql);
                 if (ret != null)
                 {
                     int itemCount = -1;

                     Int32.TryParse(ret.ToString(),out itemCount);


                     if (itemCount < 0)
                         itemCount = 0;

                     return itemCount;

                 }
                 else
                     return  0;


             }
             catch (Exception ex)
             {
                 CLog.WriteErrLogInTrace(ex.Message);
                 return 0;
             }
 
         }

         /// <summary>
         /// 获取采集记录列表的当前采集时间
         /// </summary>
         /// <returns></returns>
         public DateTime GetCurrentTime()
         {
             try
             {
                 DateTime curTime;

                 object ret = null;

                 string strSql = "select StartTime from acq_count_list where tagName=0";

                 //ret = MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, strSql, null);
                 ret = SQLiteDBHelper.ExecuteScalar(strSql);
                 DateTime.TryParse(ret.ToString(), out curTime);
                 if (curTime != null)
                     return curTime;
                 else
                     return DateTime.Now;

             }
             catch (Exception ex)
             {
                 CLog.WriteErrLogInTrace(ex.Message);

                 return DateTime.Now;
             }


         }

         /// <summary>
         /// 插入单项产品计划
         /// </summary>
         /// <param name="mdl"></param>
         /// <returns></returns>
         public int InsertAcqCountItem(AcqCountMDL mdl)
         {
             int ret = 0;

             string strSql = string.Empty;

             try
             {


                 strSql = "insert into  acq_count_list (tagName,StartTime,EndTime,CurrentCount,Remark)" +
                          "values('{0}','{1}','{2}','{3}','{4}')";
                 //2015-05-11 08:30:00
                 string startTime = String.Format("{0:yyyy-MM-dd HH:mm:ss}", mdl.StartTime); //4-10-2010 17:16:50\
                 string endTime = String.Format("{0:yyyy-MM-dd HH:mm:ss}", mdl.EndTime);
                 strSql = string.Format(strSql, mdl.TagName, startTime, endTime, mdl.CurrentCount, mdl.Remark);

                 //ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);
                 ret = SQLiteDBHelper.ExecuteNonQuery(strSql);
                 return ret;

             }
             catch (Exception ex)
             {
                 CLog.WriteErrLogInTrace(ex.Message);
                 return 0;
             }
         }


        /// <summary>
        /// 更新插入单项的起始采集总数
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
         public int UpdateItemStartCountValue(int startCount,string tagName)
         {
             int ret = 0;

             string strSql = string.Empty;

             try
             {


                 strSql = "update acq_count_list set StartCount='{0}' "
                          + " where tagName='{1}'";
                 strSql = string.Format(strSql, startCount, tagName);

                 //ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);
                 ret = SQLiteDBHelper.ExecuteNonQuery(strSql);
                 return ret;

             }
             catch (Exception ex)
             {
                 CLog.WriteErrLogInTrace(ex.Message);
                 return 0;
             }
         }




         public int UpdateAcqCountValue(AcqCountMDL mdl)
         {

             int ret = 0;

             string strSql = string.Empty;

             try
             {

                 //(plan_id,pline_id,station_id,start_time,end_time,brakeid,plan_num,actual_num,shift,create_time,remark)
                 strSql = "update acq_count_list set CurrentCount='{0}' "
                          + " where tagName='{1}'";
                 strSql = string.Format(strSql,mdl.CurrentCount, mdl.TagName);

                 //ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);
                 ret = SQLiteDBHelper.ExecuteNonQuery(strSql);
                 return ret;

             }
             catch (Exception ex)
             {
                 CLog.WriteErrLogInTrace(ex.Message);
                 return 0;
             }
         
         }



         public int RemoveAllAcqCountItem()
         {

             try
             {
                 int ret = 0;

                 string strSql = "delete from acq_count_list;";

                 //ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);
                 ret = SQLiteDBHelper.ExecuteNonQuery(strSql);
                 return ret;

             }
             catch (Exception ex)
             {
                 CLog.WriteErrLogInTrace(ex.Message);
                 return 0;
             }
         }

         /// <summary>
         /// 更新产品计划信息
         /// </summary>
         /// <param name="info"></param>
         public int UpdateAcqCountItem(AcqCountMDL mdl)
         {

             int ret = 0;

             string strSql = string.Empty;

             try
             {

                 string startTime = String.Format("{0:yyyy-MM-dd HH:mm:ss}", mdl.StartTime); //4-10-2010 17:16:50\
                 string endTime = String.Format("{0:yyyy-MM-dd HH:mm:ss}", mdl.EndTime);

                 //(plan_id,pline_id,station_id,start_time,end_time,brakeid,plan_num,actual_num,shift,create_time,remark)
                 strSql = "update acq_count_list set tagName='{0}',StartTime='{1}',EndTime='{2}',CurrentCount='{3}',Remark='{4}' "
                          + " where tid='{5}'";
                 strSql = string.Format(strSql, mdl.TagName, startTime, endTime, mdl.StartTime,
                                        mdl.CurrentCount, mdl.Remark);

                // ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);
                 ret = SQLiteDBHelper.ExecuteNonQuery(strSql);
                 return ret;

             }
             catch (Exception ex)
             {
                 CLog.WriteErrLogInTrace(ex.Message);
                 return 0;
             }
         }



         /// <summary>
         /// 获取产品计划通过计划ID
         /// </summary>
         /// <param name="planid"></param>
         /// <returns></returns>
         public DataTable GetAcqCountUnits()
         {
             try
             {
                 DataSet dataSet = null;

                 string strSql = "select CurrentCount from acq_count_list ";

                // strSql = string.Format(strSql, tid);


                 //dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);
                 dataSet = SQLiteDBHelper.ExecuteDataset(strSql);
                 if (dataSet != null)
                     return dataSet.Tables[0];

                 return null;
             }
             catch (Exception ex)
             {
                 CLog.WriteErrLogInTrace(ex.Message);
                 return null;
             }
         }
        



    }
}
