using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using COMM;
using MDL;

namespace DAL
{

    /// <summary>
    /// 停机时间数据库操作类
    /// </summary>
    public class LineDTDAL
    {

        /// <summary>
        /// 插入停机区间
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int AddLineDT(PlineDTMDL mdl)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {

                strSql = "insert into  tlb_line_dt (DTID,PLINEID,CLA_ORDER,START_TIME,END_TIME,DOWNTIME,RANGEID)" +
                                    "values('{0}','{1}',{2},'{3}','{4}',{5},'{6}')";

                strSql = string.Format(strSql, mdl.DTID, mdl.PLINEID, mdl.CLA_ORDER, mdl.START_TIME.ToString("yyyy-MM-dd HH:mm:ss"),
                                               mdl.END_TIME.ToString("yyyy-MM-dd HH:mm:ss"), mdl.DOWNTIME,mdl.RANGEID);

        
                ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);

                return ret;

            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// 更新停机区间
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int UpdateLineDT(PlineDTMDL mdl)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "UPDATE tlb_line_dt SET START_TIME='{0}',END_TIME='{1}',RANGEID='{2}',CLA_ORDER={3}, WHERE DTID='{3}";

                strSql = string.Format(strSql, mdl.START_TIME.ToString("yyyy-MM-dd HH:mm:ss"), mdl.END_TIME.ToString("yyyy-MM-dd HH:mm:ss"), mdl.RANGEID, mdl.CLA_ORDER, mdl.DTID);

                ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);

       
                return ret;

            }
            catch
            {
                throw;
            }

        }


       /// <summary>
       /// 删除数据
       /// </summary>
       /// <param name="plineID"></param>
       /// <returns></returns>
        public int DeleteLineDT(string dtid)
        {


            int ret = 0;

            try
            {
                string strSql = "DELETE  *  FROM  tlb_line_dt  WHERE  DTID='{0}'";

                strSql = string.Format(strSql, dtid);

                ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);

                return ret;

            }
            catch
            {
                throw;
            }
        }




        /// <summary>
        /// 获取时间段内暂停时间数据
        /// </summary>
        /// <param name="plineID"></param>
        /// <param name="rang"></param>
        /// <returns></returns>
        public int GetDownTimeDataByTimeRange(string plineID,TimeRange rang )
        {

            try
            {
                List<PlineDTMDL> dts = new List<PlineDTMDL>();


                DataSet dataSet = null;

                string strSql = "SELECT * FROM tlb_line_dt dt WHERE dt.START_TIME>='{0}' AND dt.END_TIME<='{1}' AND dt.PLINEID='{2}'";

                strSql = string.Format(strSql, rang.StartTime.ToString("yyyy-MM-dd HH:mm:ss"), rang.EndTime.ToString("yyyy-MM-dd HH:mm:ss"), plineID);

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet == null || dataSet.Tables[0].Rows.Count <= 0)
                    return 0;

                int count = 0;

                foreach (DataRow row in dataSet.Tables[0].Rows)
                {

                    PlineDTMDL mdl=PlineDTMDL.ParseDataRow(row);

                    count += mdl.DOWNTIME;
                }

                return count;

            }
            catch
            {
                throw;
            }
        }



        /// <summary>
        /// 获取产线设置的空闲时间
        /// </summary>
        /// <param name="pline"></param>
        /// <param name="claOrder"></param>
        /// <param name="rangid"></param>
        /// <param name="rang"></param>
        /// <returns></returns>
        public List<TimeRange> GetTimeRangeByRange(string pline,int claOrder,string rangid,TimeRange rang)
        {

            List<TimeRange> rets = new List<TimeRange>();

            try
            {
        

                DataSet dataSet = null;




                pline = Convert.ToInt32(pline).ToString();

               // string strSql = "SELECT * FROM tlb_line_dt dt WHERE dt.START_TIME>='{0}' AND dt.END_TIME<='{1}' AND dt.PLINEID='{2}' AND dt.CLA_ORDER={3} AND dt.RANGEID='{4}' ORDER BY dt.START_TIME ASC";

                string strSql = "SELECT * FROM tlb_line_dt dt WHERE  dt.PLINEID='{0}' AND dt.CLA_ORDER={1} AND dt.RANGEID='{2}' ORDER BY dt.START_TIME ASC";

                //strSql = string.Format(strSql, rang.StartTime.ToString("yyyy-MM-dd HH:mm:ss"), rang.EndTime.ToString("yyyy-MM-dd HH:mm:ss"), pline, claOrder, rangid);

                strSql = string.Format(strSql, pline, claOrder, rangid);

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet == null || dataSet.Tables[0].Rows.Count <= 0)
                    return null;

                int count = 0;

                foreach (DataRow row in dataSet.Tables[0].Rows)
                {

                    PlineDTMDL mdl = PlineDTMDL.ParseDataRow(row);

                    string tempDate = String.Format("{0}-{1:D2}-{2:D2} {3:D2}:{4:D2}:{5:D2}",
                                                   DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day
                                                   , mdl.START_TIME.Hour, mdl.START_TIME.Minute,mdl.START_TIME.Second);

                    DateTime StartTime = Convert.ToDateTime(tempDate);
                    tempDate = string.Empty;

                    tempDate = String.Format("{0}-{1:D2}-{2:D2} {3:D2}:{4:D2}:{5:D2}",
                                                   DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day
                                                   , mdl.END_TIME.Hour, mdl.END_TIME.Minute, mdl.END_TIME.Second);

                    DateTime EndTime = Convert.ToDateTime(tempDate);

                    TimeRange rangItem = new TimeRange(StartTime, EndTime);

                    rets.Add(rangItem);

                 
                }

                return rets;

            }
            catch
            {
                throw;
            }

        }
    }
}
