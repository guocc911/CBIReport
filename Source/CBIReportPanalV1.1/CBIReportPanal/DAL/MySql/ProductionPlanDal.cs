using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql;
using COMM;
using MDL;


namespace DAL
{
    public class ProductionPlanDal
    {


        public ProductionPlanDal()
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
                strSql = "select count(tid) from production_plan;";
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
        /// 插入单项产品计划
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int InsertProductionPlanItem(ProductionPlanMDL mdl)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {


                strSql = "insert into  production_plan (plan_id,pline_id,station_id,start_time,end_time,brakeid,plan_num,actual_num,shift,create_time,remark)" +
                         "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')";

                strSql = string.Format(strSql, mdl.PlanID, mdl.Pline_ID, mdl.Station_ID, mdl.StartTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                      mdl.EndTime.ToString("yyyy-MM-dd HH:mm:ss"), mdl.BreakeID, mdl.PlanNum,
                                      mdl.Actual_num, mdl.Shift, mdl.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"), mdl.Remark);

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
        /// 更新产品计划信息
        /// </summary>
        /// <param name="info"></param>
        public int UpdateProductionPlanItem(ProductionPlanMDL mdl)
        {

            int ret = 0;

            string strSql = string.Empty;

            try
            {

                //(plan_id,pline_id,station_id,start_time,end_time,brakeid,plan_num,actual_num,shift,create_time,remark)
                strSql = "update production_plan set plan_id='{0}',pline_id='{1}',station_id='{2}',start_time='{3}',end_time='{4}',brakeid='{5}',plan_num='{6}',"
                       + "actual_num='{7}',shift='{8}',create_time='{9}',remark='{10}' where tid='{11}'";
                strSql = string.Format(strSql, mdl.PlanID, mdl.Pline_ID, mdl.Station_ID, mdl.StartTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                       mdl.EndTime.ToString("yyyy-MM-dd HH:mm:ss"), mdl.BreakeID, mdl.PlanNum, mdl.Actual_num, mdl.Shift, mdl.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"), mdl.Remark, mdl.TID);

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
        /// 获取产品计划通过计划ID
        /// </summary>
        /// <param name="planid"></param>
        /// <returns></returns>
        public DataTable GetProductionPalnByPlanID(string planid)
        {
            try
            {
                DataSet dataSet = null;

                string strSql = "select * from production_plan where plan_id='{0}'  order by create_time asc";

                strSql = string.Format(strSql, planid);


                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

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


        /// <summary>
        /// 获取产品计划通过序号ID
        /// </summary>
        /// <param name="planid"></param>
        /// <returns></returns>
        public ProductionPlanMDL GetProductionPalnByID(int tid)
        {
            try
            {

                ProductionPlanMDL mdl = new ProductionPlanMDL();


                DataSet dataSet = null;

                string strSql = "select * from production_plan where tid='{0}' ";

                strSql = string.Format(strSql, tid);


                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

             
                if(dataSet!=null)
                {
                    DataRow row = dataSet.Tables[0].Rows[0];

                    mdl.Prase(row);
                    
                    return mdl;
                }
                return null;
            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 通过计划ID获取产线计划
        /// </summary>
        /// <param name="planid"></param>
        /// <returns></returns>
        public DataTable GetProductionPalnByPlanID2(string planid)
        {

            try
            {
                DataSet dataSet = null;

                string strSql = "select * from production_plan where planid='{0}' ";

                strSql = string.Format(strSql, planid);


                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

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
        /// <summary>
        /// 获取产品计划通过产品ID和时间
        /// </summary>
        /// <param name="planid"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public DataTable GetProductionPalnByDateTime(string planid,DateTime startTime,DateTime endTime)
        {

            try
            {
                DataSet dataSet = null;

                string strSql = "select * from production_plan where plan_id='{0}' and create_time between '{1}' and '{2}'  order by start_time desc";

                strSql = string.Format(strSql, planid, startTime.ToString("yyyy-MM-dd HH:mm:ss"), endTime.ToString("yyyy-MM-dd HH:mm:ss"));


                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

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


        public string GetTIDByDataTime(string planid,DateTime startTime, DateTime endTime)
        {
            try
            {
                object nvalue = null;

                string ret=string.Empty;

                string strSql = "select tid from production_plan where plan_id='{0}' and start_time = '{1}' and end_time ='{2}'";
                string sDate = String.Format("{0:yyyy-MM-dd HH:mm:ss}", startTime); //4-10-2010 17:16:50\
                string eDate = String.Format("{0:yyyy-MM-dd HH:mm:ss}", endTime);
                strSql = string.Format(strSql, planid, sDate, eDate);


                nvalue = MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (nvalue == null)
                    return string.Empty;

                ret = Convert.ToInt32(nvalue).ToString();

                return ret;
            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return string.Empty;
            }
 
        }



        public int UpdateActualPlan(string tid,int actualNum)
        {
            try
            {
                int ret = 0;

                string strSql = "update production_plan set actual_num='{0}' where tid='{1}'";

                strSql = string.Format(strSql, actualNum, tid);

                ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);

                return ret;
            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
            }

            return 0;

        }


        /// <summary>
        /// 删除产线计划
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public int DeleteProudctionPlanItem(int tid)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "delete from production_plan where tid=" + tid.ToString();

                ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);

                return ret;

            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return 0;
            }
        }
        
    }
}
