using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MDL;
using COMM;

namespace DAL
{
    public class PlinePlanDAL
    {

        /// <summary>
        /// 添加采集数据单元
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int AddPlinePlan(PlinePlanMDL mdl)
        {


            int ret = 0;

            string strSql = string.Empty;


            try
            {
                strSql = "INSERT INTO  tlb_product_plan ( PLANID,PLINE,NAME,OP1,OP1_T,OP1_BEGIN,OP1_RANGE,OP1_ITEMS,OP2,OP2_T,OP2_BEGIN,OP2_RANGE,OP2_ITEMS,CREATE_TIME,REMARK)" +
                                                   " VALUES ('{0}','{1}','{2}',{3},{4},'{5}',{6},'{7}',{8},{9},'{10}',{11},'{12}','{13}','{14}')";
                                    //"values('{0}','{1}','{2}',{3},{4},'{5}',{6},{7},{8},'{9}',{10},'{11}','{12}')";

                strSql = string.Format(strSql, mdl.PLANID, mdl.PLINE, mdl.NAME, mdl.OP1, mdl.OP1_T, mdl.OP1_BEGIN.ToString("yyyy-MM-dd HH:mm:ss"),
                                       mdl.OP1_RANGE, OPMDL.BuildOPString(mdl.OP1_ITEMS), mdl.OP2, mdl.OP2_T, mdl.OP2_BEGIN.ToString("yyyy-MM-dd HH:mm:ss"),
                                       mdl.OP2_RANGE, OPMDL.BuildOPString(mdl.OP2_ITEMS), mdl.CREATE_TIME.ToString("yyyy-MM-dd HH:mm:ss"), mdl.REMARK);

                ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);

                return ret;

            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// 更新产线计划
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int UpdatePlinePlan(PlinePlanMDL mdl)
        {
            int ret = 0;

            string strSql = string.Empty;


            try
            {

                strSql = "UPDATE  tlb_product_plan SET PLINE='{0}' ,NAME='{1}',OP1={2},OP1_T={3},OP1_BEGIN='{4}',OP1_RANGE={5},OP1_ITEMS='{6}',OP2={7},"
                         + "OP2_T={8},OP2_BEGIN='{9}',OP2_RANGE={10},OP2_ITEMS='{11}',REMARK='{12}' WHERE PLANID='{13}'";

                strSql = string.Format(strSql,  mdl.PLINE, mdl.NAME, mdl.OP1, mdl.OP1_T, mdl.OP1_BEGIN.ToString("yyyy-MM-dd HH:mm:ss"),
                                       mdl.OP1_RANGE, OPMDL.BuildOPString(mdl.OP1_ITEMS), mdl.OP2, mdl.OP2_T, mdl.OP2_BEGIN.ToString("yyyy-MM-dd HH:mm:ss"),
                                       mdl.OP2_RANGE, OPMDL.BuildOPString(mdl.OP2_ITEMS),mdl.REMARK, mdl.PLANID);

                ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);

                return ret;

            }
            catch
            {
                throw;
            }
        }



        /// <summary>
        /// 计划是否存在
        /// </summary>
        /// <param name="planid"></param>
        /// <returns></returns>
        public int PlanExists(string planid)
        {

            int ret=0;

            try
            {
                string strSql = "SELECT COUNT(*) FROM tlb_product_plan WHERE PLANID='{0}'";

                strSql = string.Format(strSql, planid);

                ret = Convert.ToInt32(MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, strSql, null));

                return ret;

            }
            catch
            {
                throw;
            }

        }
        /// <summary>
        /// 删除产线记录
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public int DeletePlinePlanm(string planID)
        {

            int ret = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "DELETE FROM  tlb_product_plan WHERE PLANID='{0}'";

                strSql = string.Format(strSql, planID);

                ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);

                return ret;

            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// 获取记录
        /// </summary>
        /// <param name="lineID"></param>
        /// <param name="range"></param>
        /// <returns>minutes</returns>
        public PlinePlanMDL GetPlanInfo(string lineID)
        {

            PlinePlanMDL mdl=null;
            try
            {
                DataSet dataSet = null;

                string strSql = "SELECT * FROM tlb_product_plan WHERE PLANID='{0}'";

                strSql = string.Format(strSql, lineID);


                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet == null || dataSet.Tables[0].Rows.Count <= 0)
                    return null;

                mdl = PlinePlanMDL.PraseDataRow(dataSet.Tables[0].Rows[0]);

                return mdl;
            }
            catch
            {
                throw;
            }
        }




       


        public List<PlinePlanMDL> GetPlanInfos(DateTime datetime)
        {

            List<PlinePlanMDL> list = null;
            try
            {
                DataSet dataSet = null;

                string strSql = "SELECT * FROM tlb_product_plan WHERE PLANID LIKE '{0}%'";

                strSql = string.Format(strSql, datetime.ToString("yyyyMMdd"));


                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet == null || dataSet.Tables[0].Rows.Count <= 0)
                    return null;

                list = new List<PlinePlanMDL>();

                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    list.Add(PlinePlanMDL.PraseDataRow(row));
                }


                return list;
            }
            catch
            {
                throw;
            }
        }
    }
}
