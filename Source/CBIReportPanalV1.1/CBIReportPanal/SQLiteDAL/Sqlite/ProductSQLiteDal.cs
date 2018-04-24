using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using COMM;
using MDL;


namespace SQLiteDAL
{
    /// <summary>
    /// 消息面板的数据库操作类
    /// </summary>
    public class ProductSQLiteDal
    {

        public ProductSQLiteDal()
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
                strSql = "select count(tid) from production;";
                //ret = Convert.ToInt32(SQLiteDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, strSql, null));

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


        /// <summary>
        /// 插入产品信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public  int InsertProduction(ProductionMDL mdl)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {

                ///DateTime theDate = DateTime.Now;
               // theDate.ToString("yyyy-MM-dd HH:mm:ss");
                string dateTime= DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                strSql = "insert into  production (lineid,brakename,brakeid,brakecode,createtime,factory,remark)"+
                         "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')";

               // strSql = string.Format(strSql, mdl.LineNum, mdl.ProductName, mdl.ProductID, mdl.ProductCode, dateTime, mdl.Factory, mdl.Remark);

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
        /// 更新产品信息
        /// </summary>
        /// <param name="info"></param>
        public int UpdateProduction(ProductionMDL mdl)
        {

            int ret = 0;

            string strSql=string.Empty;

            try
            {

             //DateTime theDate = DateTime.Now;
             //theDate.ToString("yyyy-MM-dd HH:mm:ss");
                string dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
             strSql = "update production set lineid='{0}',brakename='{1}',brakeid='{2}',brakecode='{3}',factory='{4}',remark='{5}' where tid='{6}'";
          //   strSql = string.Format(strSql, mdl.LineNum, mdl.ProductName, mdl.ProductID, mdl.ProductCode, mdl.Factory, mdl.Remark, mdl.TID);

           //  ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql,null);
             ret = SQLiteDBHelper.ExecuteNonQuery(strSql);
             return ret;

            }
            catch(Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return 0;
            }
        }


        /// <summary>
        /// 获取产品名称
        /// </summary>
        /// <returns></returns>
        public ArrayList GetProductionNames()
        {

            try
            {

                ArrayList list = new ArrayList();

                DataSet dataSet = null;

                string strSql = "select * from production order by createtime asc";

               // dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                dataSet = SQLiteDBHelper.ExecuteDataset(strSql);

                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    list.Add(Convert.ToString(dr["brakename"]));
                }

                if (list.Count <= 0)
                    return null;

                return list;
            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return null;
            }
        }

        /// <summary>
        ///获取生产线信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetProductionInfos()
        {

            try
            {
                DataSet dataSet = null;

                string strSql = "select * from production order by createtime asc";

                //dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                dataSet = SQLiteDBHelper.ExecuteDataset(strSql);

                if (dataSet != null)
                    return dataSet.Tables[0];
             
                return null;
            }
            catch(Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return null;
            }
        }


        /// <summary>
        /// 删除产品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteProduction(int id)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "delete from production where tid=" + id.ToString();
            
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

    }
}
