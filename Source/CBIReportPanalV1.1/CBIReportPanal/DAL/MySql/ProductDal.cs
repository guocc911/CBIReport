using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql;
using COMM;
using MDL;

namespace DAL
{
    /// <summary>
    /// 消息面板的数据库操作类
    /// </summary>
    public class ProductDal
    {

        public ProductDal()
        {
 
        }

        /// <summary>
        /// 获取产品个数
        /// </summary>
        /// <returns></returns>
        public int GeProductCount()
        {

            int ret = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "select count(PN) from tlb_product;";

                ret = Convert.ToInt32(MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, strSql, null));
          
                return ret;
            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return 0;
            }


        }

        /// <summary>
        /// 获取产线数量
        /// </summary>
        /// <param name="linekey"></param>
        /// <returns></returns>
        public int GetProductCount(string linekey)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "select count(*) from tlb_product where PLID='{0}';";

                strSql = string.Format(strSql, linekey);

                ret = Convert.ToInt32(MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, strSql, null));

                return ret;
            }
            catch 
            {
                throw;
            }

        }


        public ProductionMDL GetProductInfo(string lineID, int ems)
        {
            ProductionMDL mdl = null;

            try
            {

                string strSql = string.Empty;

                int nline = 0;
                Int32.TryParse(lineID,out nline);

                if (nline <= 0)
                    return null;


                strSql = "select * from tlb_product where PLID='{0}' and EMS='{1}'";

                strSql = string.Format(strSql, nline.ToString(), ems);


               DataSet dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet == null||dataSet.Tables.Count<=0)
                    return null;

                //解析数据
                mdl = ProductionMDL.ParseDataRow(dataSet.Tables[0].Rows[0]);

                return mdl;
            }
            catch 
            {
                throw;
            }
        }

        /// <summary>
        /// 当前产品是否存在
        /// </summary>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public int IsExist(string strKey)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "select * from tlb_product where PN={0}";

                strSql = string.Format(strSql, strKey);

                ret = Convert.ToInt32(MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, strSql, null));

                return ret;
            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return 0;
            }

        }


        public int ProductIsExist(string lineID, string ems)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "select count(*) from tlb_product where PLID='{0}' and EMS='{1}'";

                strSql = string.Format(strSql, lineID, ems);

                ret = Convert.ToInt32(MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, strSql, null));

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

                //DateTime theDate = DateTime.Now;
                //theDate.ToString("yyyy-MM-dd HH:mm:ss");

                strSql = "insert into  tlb_product (PN,PLID,NAME ,EMS,CREATE_TIME,CODE,TYPE,FACTORY,CT,OP,REMARK)" +
                      "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')";

                strSql = string.Format(strSql, mdl.PN, mdl.PLID, mdl.Name, mdl.EMS, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                                       , mdl.Code, mdl.CodeType, mdl.Factory,mdl.CT, mdl.OP, mdl.Remark);

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
        /// 更新产品信息
        /// </summary>
        /// <param name="info"></param>
        public int UpdateProduction(ProductionMDL mdl)
        {

            int ret = 0;

            string strSql=string.Empty;

            try
            {

                strSql = "UPDATE tlb_product SET NAME='{0}',PN='{1}',CODE='{2}',TYPE={3},FACTORY='{4}',CT={5},OP={6},REMARK='{7}' WHERE EMS={8} AND PLID={9}";

                strSql = string.Format(strSql, mdl.Name, mdl.PN, mdl.Code, mdl.CodeType, mdl.Factory, mdl.CT, mdl.OP, mdl.Remark, mdl.EMS, mdl.PLID);

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
        /// 获取产品编码
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetPNbyEMSCode(string code)
        {
            string ret = string.Empty;

            string strSql = string.Empty;

            try
            {
                strSql = "select PN from tlb_product where NAME='{0}'";

                strSql = string.Format(strSql, code);

                ret = Convert.ToString(MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, strSql, null));

                return ret;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 获取产线编码
        /// </summary>
        /// <param name="ems"></param>
        /// <returns></returns>
        public string GetPNCodebyEMS(int ems)
        {
            string  ret = string.Empty;

            string strSql = string.Empty;

            try
            {
                strSql = "select PN from tlb_product where EMS={0}";

                strSql = string.Format(strSql, ems);

                ret = Convert.ToString(MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, strSql, null));

                return ret;
            }
            catch
            {
                throw;
            }
        }

        public string GetPNCodeByLineEMS(string lineID,int ems)
        {
            string ret = string.Empty;

            string strSql = string.Empty;

            try
            {
                strSql = "select PN from tlb_product where PLID='{0}' and EMS={1}";

                strSql = string.Format(strSql,lineID, ems);

                ret = Convert.ToString(MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, strSql, null));

                return ret;
            }
            catch
            {
                throw;
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

                string strSql = "SELECT * FROM tlb_product ORDER BY CREATE_TIME ASC";

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

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


        public DataTable GetProductTable(string lineID)
        {
            try
            {
                DataSet dataSet = null;

                string strSql = "SELECT * FROM tlb_product WHERE PLID='{0}' ORDER BY CREATE_TIME ASC";
                strSql = string.Format(strSql, lineID);


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


        public DataTable GetProductPage(int startOffset, int endOffset, string lineID)
        {
            try
            {
                DataSet dataSet = null;


                //string strSql = "SELECT tp.PLID,tp.CODE,tp.PN,tp.EMS,tp.CT,tp.OP FROM tlb_product tp  WHERE tp.PLID='{0}' ORDER BY CREATE_TIME ASC  LIMIT {1},{2};";
                string strSql = "SELECT tp.PLID,tp.CODE,tp.PN,tp.EMS,tp.CT,tp.OP FROM tlb_product tp  WHERE tp.PLID='{0}' ORDER BY EMS ASC  LIMIT {1},{2};";

                strSql = string.Format(strSql, lineID, startOffset, endOffset);

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet == null)
                    return null;

                return dataSet.Tables[0];
            }
            catch (Exception ex)
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
        //public int DeleteProduction(int pn)
        //{
        //    int ret = 0;

        //    string strSql = string.Empty;

        //    try
        //    {
        //        strSql = "DELETE FROM tlb_product WHERE PN=" + pn.ToString();
            
        //        ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);

        //        return ret;

        //    }
        //    catch (Exception ex)
        //    {
        //        CLog.WriteErrLogInTrace(ex.Message);
        //        return 0;
        //    }
        //}


        public int DeleteProduction(int ems)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "DELETE FROM tlb_product WHERE EMS=" + ems.ToString();

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
        /// 查询过去CTUNIT
        /// </summary>
        /// <param name="LineID"></param>
        /// <param name="ems"></param>
        /// <returns></returns>
        public CTUnitMDL GetCTUnit(string lineid, int ems)
        {
            CTUnitMDL unit = null;

            try
            {
                int id = 0;

                Int32.TryParse(lineid, out id);

                if (id <= 0)
                    return null;


                string strSql = "SELECT * FROM tlb_product WHERE  PLID='{0}' AND EMS={1}";

                strSql = string.Format(strSql, id.ToString(), ems);

                DataSet dataSet = null;

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
                {
                    ProductionMDL mdl = ProductionMDL.ParseDataRow(dataSet.Tables[0].Rows[0]);
                    unit = new CTUnitMDL();
                    unit.PN = mdl.PN;
                    unit.CT = mdl.CT;
                    unit.EMS = mdl.EMS;
                    unit.OP = mdl.OP;

                    return unit;
                }
                else
                {
                    return null;
                }

            }
            catch
            {
                return null;
            }
        }

        //}

        public Hashtable GetProductCTTable2()
        {
            Hashtable ctTable = new Hashtable();

            try
            {
                DataSet dataSet = null;

                //string strSql = "SELECT * FROM tlb_product ORDER BY CREATE_TIME ASC";

                string strSql = "SELECT * FROM tlb_product ";

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet != null)
                {

                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        ProductionMDL mdl = ProductionMDL.ParseDataRow(row);
                        CTUnitMDL unit = new CTUnitMDL();
                        unit.PN = mdl.PN;
                        unit.CT = mdl.CT;
                        unit.EMS = mdl.EMS;
                        unit.OP = mdl.OP;
                        ctTable.Add(mdl.PN, unit);
                    }

                }

                return ctTable;
            }
            catch
            {
                throw;
            }

        }

        /// <summary>
        /// 获取生产效率周期表
        /// </summary>
        /// <returns></returns>
        public Hashtable GetProductCTTable()
        {

            Hashtable ctTable = new Hashtable();

            try
            {
                DataSet dataSet = null;

                //string strSql = "SELECT * FROM tlb_product ORDER BY CREATE_TIME ASC";

                string strSql = "SELECT * FROM tlb_product ";

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet != null)
                {

                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        ProductionMDL mdl= ProductionMDL.ParseDataRow(row);
                        CTUnitMDL unit=new CTUnitMDL();
                        unit.PN=mdl.PN;
                        unit.CT=mdl.CT;
                        unit.EMS=mdl.EMS;
                        unit.OP=mdl.OP;
                        unit.Key = mdl.Key;

                        ctTable.Add(unit.Key, unit);
                        //ctTable.Add(mdl.PN, unit);
                    }

                }

                return ctTable;
            }
            catch 
            {
                throw;
            }
        }



    }
}
