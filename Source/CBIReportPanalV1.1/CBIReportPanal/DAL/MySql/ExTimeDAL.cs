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
    public class ExTimeDAL
    {
        /// <summary>
        /// 添加采集数据单元
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int AddExTimeItem(ExtTimeMDL mdl)
        {


            int ret = 0;

            string strSql = string.Empty;


            try
            {
                strSql = "insert into  tlb_ext_time ( PLINEID,NAME,LUNCH,L_TIME,DINNER,D_TIME,REMARK)" +
                                    "values('{0}','{1}','{2}',{3},'{4}',{5},'{6}')";

                strSql = string.Format(strSql, mdl.PLINEID, mdl.NAME, mdl.LUNCH.ToString("yyyy-MM-dd HH:mm:ss"),
                                        mdl.L_TIME, mdl.DINNER.ToString("yyyy-MM-dd HH:mm:ss"),
                                       mdl.D_TIME, mdl.REMARK);

                ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);

                return ret;

            }
            catch
            {
                throw;
            }
        }



        public int UpdateDateExTime(ExtTimeMDL mdl)
        {

            int ret = 0;

            string strSql = string.Empty;

            try
            {

                strSql = "UPDATE tlb_ext_time SET NAME='{0}',LUNCH='{1}',L_TIME={2},DINNER='{3}',D_TIME={4} WHERE PLINEID='{5}'";

                strSql = string.Format(strSql, mdl.NAME, mdl.LUNCH.ToString("yyyy-MM-dd HH:mm:ss"),
                                               mdl.L_TIME, mdl.DINNER.ToString("yyyy-MM-dd HH:mm:ss"), mdl.D_TIME, mdl.PLINEID);

                ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);

                return ret;

            }
            catch
            {
                throw;
            }
        }



        public List<ExtTimeMDL> GetExtimes()
        {

            List<ExtTimeMDL> list = null;

            try
            {
                DataSet dataSet = null;

                string strSql = "SELECT * FROM tlb_ext_time ";


                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet == null || dataSet.Tables[0].Rows.Count <= 0)
                    return null;


                list = new List<ExtTimeMDL>();

                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    list.Add(ExtTimeMDL.PraseDataRow(row));
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
