using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using COMM;
using MDL;

namespace DAL
{
    public class ChangeTimeDAL
    {

        /// <summary>
        /// 添加采集数据单元
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int AddChangeUnitItem(ChangeTimeMDL mdl)
        {


            int ret = 0;

            string strSql = string.Empty;


            try
            {
                strSql = "insert into  tlb_line_change ( SEQID,PLID,UNITID,PER_PN,CUR_PN,CUR_TIME,TIME_MIG,PER_TIME)" +
                                    "values('{0}','{1}','{2}','{3}','{4}','{5}',{6},'{7}')";

                strSql = string.Format(strSql, mdl.SEQID, mdl.PLID,mdl.UNITID, mdl.PER_PN, mdl.CUR_PN, mdl.CUR_TIME.ToString("yyyy-MM-dd HH:mm:ss"), 
                                       mdl.TIME_MIG, mdl.PER_TIME.ToString("yyyy-MM-dd HH:mm:ss"));

                ret =MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);

                return ret;

            }
            catch
            {
                throw;
            }
        }



       
        public int UpdateChangeUnitItem(ChangeTimeMDL mdl)
        {
            int ret = 0;

            string strSql = string.Empty;


            try
            {

                strSql = "UPDATE  tlb_line_change SET PLID='{0}' ,UNITID='{1}',PER_PN='{2}',CUR_PN='{3}',CUR_TIME='{4}',TIME_MIG={5},PER_TIME='{6}' WHERE SEQID='{7}'";

                strSql = string.Format(strSql, mdl.PLID, mdl.UNITID, mdl.PER_PN, mdl.CUR_PN, mdl.CUR_TIME.ToString("yyyy-MM-dd HH:mm:ss"),
                                       mdl.TIME_MIG, mdl.PER_TIME.ToString("yyyy-MM-dd HH:mm:ss"),mdl.SEQID);

                ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);

                return ret;

            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 删除改变计数值
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public int DeleteChangeTimeItem(string tid)
        {

            int ret=0;

            string strSql = string.Empty;

            try
            {
                strSql = "DELETE FROM  tlb_line_change WHERE TID='{0}'";

                strSql = string.Format(strSql, tid);

                ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);
                
                return ret;

            }
            catch 
            {
            	throw;
            }
        }


        /// <summary>
        /// 是否是唯一的采集单元
        /// </summary>
        /// <param name="unitID"></param>
        /// <returns></returns>
        public int IsUionCOUint(string unitID,string plineid)
        {

            int ret = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "select count(*) from tlb_line_change where UNITID='{0}' and PLID='{1}'";

                strSql = string.Format(strSql, unitID, plineid);

                ret = Convert.ToInt32(MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, strSql, null));

                return ret;

            }
            catch
            {
                throw;
            }
        }

        //public int 



        public List<ChangeTimeMDL> GetChangeTimeItems(string lineID, TimeRange range)
        {


            List<ChangeTimeMDL> ret = new List<ChangeTimeMDL>();

            try
            {
                DataSet dataSet = null;

                string strSql = "SELECT * FROM tlb_line_change WHERE PLID='{0}' AND CUR_TIME BETWEEN  '{1}' AND  '{2}'";

                strSql = string.Format(strSql, lineID, range.StartTime, range.EndTime);


                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet == null || dataSet.Tables[0].Rows.Count <= 0)
                    return null;




                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    ChangeTimeMDL dml = ChangeTimeMDL.ParseDataRow(row);

                    ret.Add(dml);
                }



                return ret;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 获取换型时间
        /// </summary>
        /// <param name="lineID"></param>
        /// <param name="range"></param>
        /// <returns>minutes</returns>
        public int GetChangeTime(string lineID, TimeRange range,ref string ems)
        {

            int ct = 0;

            try
            {
                DataSet dataSet = null;

                string strSql = "SELECT * FROM tlb_line_change WHERE PLID='{0}' AND CUR_TIME BETWEEN  '{1}' AND  '{2}'";

                strSql = string.Format(strSql,lineID, range.StartTime, range.EndTime);


                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet == null || dataSet.Tables[0].Rows.Count <= 0)
                    return 0;


                

                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    ChangeTimeMDL  dml= ChangeTimeMDL.ParseDataRow(row);
                    ct += dml.TIME_MIG;
                    ems += dml.CUR_PN + ",";
                }



                return ct;
            }
            catch
            {
                throw;
            }
        }




        public int GetChangeTimeByUnitID(string unitid)
        {
            int ct = 0;

            try
            {
                DataSet dataSet = null;

                string strSql = "SELECT * FROM tlb_line_change WHERE  UNITID='{0}' ";

                strSql = string.Format(strSql,unitid);


                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet == null || dataSet.Tables[0].Rows.Count <= 0)
                    return 0;

                ///获取换型时间秒为单位
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    ct += ChangeTimeMDL.ParseDataRow(row).TIME_MIG;
                }

                return ct;
            }
            catch
            {
                throw;
            }
        }

        public int GetChangeTimeByUnit(string lineID, string unitid)
        {
            int ct = 0;

            try
            {
                DataSet dataSet = null;

                string strSql = "SELECT * FROM tlb_line_change WHERE PLID='{0}' AND UNITID='{1}' ";

                strSql = string.Format(strSql, lineID, unitid);


                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet == null || dataSet.Tables[0].Rows.Count <= 0)
                    return 0;

                ///获取换型时间秒为单位
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    ct += ChangeTimeMDL.ParseDataRow(row).TIME_MIG;
                }

                return ct;
            }
            catch
            {
                throw;
            }
        }




    }
}
