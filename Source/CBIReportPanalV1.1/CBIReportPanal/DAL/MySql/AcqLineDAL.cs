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
    public class AcqLineDAL
    {


        public AcqLineDAL()
        {
        }



        /// <summary>
        /// 获取分项采集条数
        /// </summary>
        /// <returns></returns>
        public int GetRowCount()
        {

            int ret = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "select count(*) from tlb_acq_line;";

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
        /// 判断当前时间内的数据是否加载过
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public int TagExist(string strTID)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "select * from tlb_acq_line TID='{0}'";

                strSql = string.Format(strSql, strTID);

                ret = Convert.ToInt32(MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, strSql, null));

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
        public int IsUionAcqUint(string unitID,string lineid) 
        {

            int ret = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "select count(*) from tlb_acq_line where UNITID='{0}' and PLID='{1}'";

                strSql = string.Format(strSql, unitID, lineid);

                ret = Convert.ToInt32(MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, strSql, null));

                return ret;

            }
            catch
            {
                throw;
            }
        }



        public int AcqUintExist2(string lineid,int ems, string unitid)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "select count(*) from tlb_acq_line where PLID='{0}' AND UNITID='{1}' and  EMS={2} ";

                strSql = string.Format(strSql, lineid, unitid, ems);

                ret = Convert.ToInt32(MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, strSql, null));

                return ret;

            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 查找采集单元是否存在
        /// </summary>
        /// <param name="pn"></param>
        /// <param name="tid"></param>
        /// <returns></returns>
        public int AcqUintExist(string lineid,string pn, string unitid)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "select count(*) from tlb_acq_line where PLID='{0}' AND UNITID='{1}' and  PN='{2}' ";

                strSql = string.Format(strSql, lineid, unitid, pn);

                ret = Convert.ToInt32(MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, strSql, null));

                return ret;

            }
            catch
            {
                throw;
            }
        }




        /// <summary>
        /// 添加采集数据单元
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        //public int AddAcqLine(AcqLineCountMDL mdl)
        //{


        //    int ret = 0;

        //    string strSql = string.Empty;

        //    try
        //    {
        //        strSql = "insert into  tlb_acq_line ( TID,PLID,UNITID,PN,EMS,OP,TGNMAE,START_TIME,END_TIME ,CUR_COUNT,START_COUNT,BEGIN_TIME,UPDATE_TIME,ERROR,REMARK)" +
        //                            "values('{0}','{1}','{2}','{3}',{4},{5},'{6}','{7}','{8}',{9},{10},'{11}','{12}','{13}','{14}')";

        //        strSql = string.Format(strSql, mdl.TID, mdl.PLID, mdl.UNITID, mdl.PN, mdl.EMS, mdl.OP, mdl.TGNMAE, mdl.START_TIME.ToString("yyyy-MM-dd HH:mm:ss"),
        //                               mdl.END_TIME.ToString("yyyy-MM-dd HH:mm:ss"), mdl.CUR_COUNT, mdl.START_COUNT, mdl.BEGIN_TIME.ToString("yyyy-MM-dd HH:mm:ss"), mdl.UPDATE_TIME.ToString("yyyy-MM-dd HH:mm:ss"), mdl.ERROR, mdl.REMARK);

        //        ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);

        //        return ret;

        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}


        /// <summary>
        /// 添加采集数据单元
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int AddAcqLine1(AcqLineItemMDL mdl)
        {


            int ret = 0;

            string strSql = string.Empty;

            try
            {

                //strSql = "insert into  tlb_acq_line ( TID,PLID,UNITID,PN,EMS,OP,TGNMAE,START_TIME,END_TIME ,CUR_COUNT,START_COUNT,BEGIN_TIME,UPDATE_TIME,ERROR,REMARK)" +
                //                    "values('{0}','{1}','{2}','{3}',{4},{5},'{6}','{7}','{8}',{9},{10},'{11}','{12}','{13}','{14}')";

                strSql = "insert into  tlb_acq_line ( TID,PLID,UNITID,PN,EMS,OP,TGNMAE,START_TIME,END_TIME ,PR_COUNT,UPDATE_TIME,ERROR,REMARK)" +
                                    "values('{0}','{1}','{2}','{3}',{4},{5},'{6}','{7}','{8}',{9},'{10}','{11}','{12}')";

                strSql = string.Format(strSql, mdl.TID, mdl.PLID, mdl.UNITID, mdl.PN, mdl.EMS, mdl.OP, mdl.TGNAME, mdl.START_TIME.ToString("yyyy-MM-dd HH:mm:ss"),
                                       mdl.END_TIME.ToString("yyyy-MM-dd HH:mm:ss"), mdl.PR_COUNT, mdl.UPDATE_TIME.ToString("yyyy-MM-dd HH:mm:ss"), mdl.ERROR, mdl.REMARK);

                ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);

                return ret;

            }
            catch
            {
                throw;
            }
        }


        //public int GetRangeCont(string lineid,string uid)
        //{

        //}

        /// <summary>
        /// 获取采集单元的当前采集数量
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public int GetAcqUnitCount(string lineid,string unitid,string ems)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "select PR_COUNT from tlb_acq_line where PLID='{0}' and UNITID='{1}' and EMS='{2}'";

                strSql = string.Format(strSql, lineid, unitid, ems);

                ret = Convert.ToInt32(MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, strSql, null));

                return ret;
            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return 0;
            }
        }


        public AcqLineItemMDL GetAcqUnit(string lineid, string unitid, string ems)
        {
            AcqLineItemMDL mdl = null;

            string strSql = string.Empty;

            try
            {
                strSql = "select *  from tlb_acq_line where PLID='{0}' and UNITID='{1}' and EMS='{2}'";

                strSql = string.Format(strSql, lineid, unitid, ems);

                DataSet dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet == null || dataSet.Tables[0].Rows.Count <= 0)
                    return null;

                mdl = AcqLineItemMDL.PraseDataRow(dataSet.Tables[0].Rows[0]);

                return mdl;

                return mdl;
            }
            catch
            {
                throw;
            }
        }


        public int UpdateAclineUnitByLastUnit(DateTime datetime,String lineID)
        {
            int ret = 0;

            string strSql = string.Empty;


            try
            {

                strSql = "UPDATE  tlb_acq_line tal set tal.END_TIME='{0}' WHERE tal.PLID='{1}'  ORDER BY tal.UPDATE_TIME DESC LIMIT 1;";

                strSql = string.Format(strSql, datetime.ToString("yyyy-MM-dd HH:mm:ss"), lineID);

                ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);

                return ret;

            }
            catch
            {
                throw;
            }
        }

        //public int GetAcqLineMDLPerCount(string lineid, string unitid, string pn)
        //{
        //    int ret = 0;

        //    string strSql = string.Empty;
        //    try
        //    {
        //        strSql = "select START_COUNT from tlb_acq_line where PLID='{0}' and UNITID='{1}' and PN='{2}'";

        //        strSql = string.Format(strSql, lineid, unitid, pn);

        //        ret = Convert.ToInt32(MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, strSql, null));

        //        return ret;
        //    }
        //    catch (Exception ex)
        //    {
        //        CLog.WriteErrLogInTrace(ex.Message);
        //        return 0;
        //    }
        //}

        /// <summary>
        /// 获取最后线路采集的数量
        /// </summary>
        /// <param name="plineid"></param>
        /// <returns></returns>
        //public int GetAcqLineLastConut(string plineid)
        //{

     
        //    string strSql = string.Empty;


        //    try
        //    {
        //        strSql = "select START_COUNT from tlb_acq_line where PLID='{0}'ORDER BY UPDATE_TIME DESC LIMIT 1 ;";

        //        strSql = string.Format(strSql, plineid);

        //        DataSet dataSet = null;

        //        dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

        //        if (dataSet == null || dataSet.Tables[0].Rows.Count <= 0)
        //            return 0;

        //        int startCount = Convert.ToInt32(dataSet.Tables[0].Rows[0]["START_COUNT"]);


        //        return startCount;
        //    }
        //    catch(Exception ex)
        //    {
        //        CLog.WriteErrLogInTrace(ex.Message);
        //        return 0;
        //    }
        //}


        public int GetAcqTotalCount(string plineid,DateTime now)
        {
            int ret = 0;

            string strSql = string.Empty;


            try
            {
               // strSql = "select CUR_COUNT from tlb_acq_line where PLID='{0}' and UNITID like '{1}%'";

                strSql = "select PR_COUNT from tlb_acq_line where PLID='{0}' and UNITID like '{1}%'";

                strSql = string.Format(strSql, plineid, now.ToString("yyyyMMdd") + plineid);

                DataSet dataSet = null;

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet == null || dataSet.Tables[0].Rows.Count <= 0)
                    return 0;



                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    //ret += Convert.ToInt32(row["CUR_COUNT"]);
                    ret += Convert.ToInt32(row["PR_COUNT"]);
                }


                return ret;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public AssemblyLineMDL GetAssemblyInfo(string lineID)
        {

            try
            {

               AssemblyLineMDL ret = null;

               string strSql = "select * from tlb_assemblyline where PLID='{0}'";

               strSql = string.Format(strSql, Convert.ToInt32(lineID).ToString());



               DataSet dataSet = null;

               dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

               if (dataSet == null || dataSet.Tables[0].Rows.Count <= 0)
                    return null;

               ret=AssemblyLineMDL.ParseDataRow(dataSet.Tables[0].Rows[0]);

                return ret;

            }
            catch 
            {
                throw;
            }
           

         
        }

        public int GetAssemblyLineDTTime(string lineID)
        {
            int ret = 0;

            string strSql = string.Empty;


            try
            {

                strSql = "select DT_POINT from tlb_assemblyline where PLID='{0}' ";

                strSql = string.Format(strSql, lineID);

               

                object pt = MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (pt == null)
                    return 0;

                ret = Convert.ToInt32(pt);

                return ret;
            }
            catch 
            {
                throw;
            }
        }


        

        public int UpdateAssemblyLine(AssemblyLineMDL mdl)
        {

            int ret = 0;

            string strSql = string.Empty;


            try
            {

                strSql = "UPDATE tlb_assemblyline SET PL_NAME='{0}',DT_POINT={1},TG_OEE={2},TG_OP={3},CT_THRESHOLD={4},ENABLE_TH={5} WHERE PLID={6}";

                strSql = string.Format(strSql, mdl.PL_NAME, mdl.DT_POS, mdl.TG_OEE, mdl.TG_OP,mdl.CT_THRESHOLD,mdl.ENABLE_TH,mdl.PLID);

                ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);

                return ret;

            }
            catch 
            {
                throw;
            }
        }

        /// <summary>
        /// 获取产线列表
        /// </summary>
        /// <returns></returns>
        public List<AssemblyLineMDL> GetAssemblyLines()
        {

            List<AssemblyLineMDL> ret = null;

            string strSql = string.Empty;


            try
            {
                strSql = "select * from tlb_assemblyline";


                DataSet dataSet = null;

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet == null || dataSet.Tables[0].Rows.Count <= 0)
                    return null;

                ret = new List<AssemblyLineMDL>();

                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    ret.Add(AssemblyLineMDL.ParseDataRow(row));
                }


                return ret;
            }
            catch 
            {
                throw;
            }

        }

        /// <summary>
        /// 更新采集单元的计数
        /// </summary>
        /// <param name="tid"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int UpAcqUnitCount(string tid, int count)
        {

            int ret = 0;

            string strSql = string.Empty;

            try
            {

               // strSql = "UPDATE tlb_acq_line SET CUR_COUNT={0} WHERE TID={1}";

                strSql = "UPDATE tlb_acq_line SET PR_COUNT={0} WHERE TID={1}";

                strSql = string.Format(strSql, count, tid);

                ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);

                return ret;

            }
            catch 
            {
                throw;
            }
        }


        /// <summary>
        /// 更新采集单元的计数
        /// </summary>
        /// <param name="tid"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int UpAcqUnitCount(int count,string lineid, string  unitid,string pn)
        {

            int ret = 0;

            string strSql = string.Empty;

            try
            {

               // strSql = "UPDATE tlb_acq_line SET CUR_COUNT={0},UPDATE_TIME='{1}' WHERE PLID='{2}' AND UNITID='{3}' AND PN='{4}'";

                strSql = "UPDATE tlb_acq_line SET PR_COUNT={0},UPDATE_TIME='{1}' WHERE PLID='{2}' AND UNITID='{3}' AND PN='{4}'";

                strSql = string.Format(strSql, count,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), lineid, unitid, pn);

                ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);

                return ret;

            }
            catch
            {
                throw;
            }
        }


        //public int UpAcqUnitCount2(int count,int startCount, string lineid,int op, string unitid, int ems)
        //{

        //    int ret = 0;

        //    string strSql = string.Empty;

        //    try
        //    {

        //        strSql = "UPDATE tlb_acq_line SET CUR_COUNT={0},START_COUNT={1},OP={2},UPDATE_TIME='{3}' WHERE PLID='{4}' AND UNITID='{5}' AND EMS={6}";

        //        strSql = string.Format(strSql, count, startCount, op, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), lineid, unitid, ems);

        //        ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);

        //        return ret;

        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}



        //public int UpAcqUnitCountAndOP(int count, int startCount, string lineid, string unitid, int ems)
        //{
        //    int ret = 0;

        //    string strSql = string.Empty;

        //    try
        //    {

        //        strSql = "UPDATE tlb_acq_line SET CUR_COUNT={0},START_COUNT={1},UPDATE_TIME='{2}' WHERE PLID='{3}' AND UNITID='{4}' AND EMS={5}";

        //        strSql = string.Format(strSql, count, startCount, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), lineid, unitid, ems);

        //        ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);

        //        return ret;

        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}


        /// <summary>
        /// 更新采集单元
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
      //  public int UpdateAcqLineUint(AcqLineCountMDL mdl)
         public int UpdateAcqLineUint(AcqLineItemMDL mdl)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "UPDATE tlb_acq_line  SET PN='{0}',OP={1},EMS ={2},PR_COUNT ={3},TIME_LENGTH={4},TGNMAE={5},START_TIME='{6}',"
                          +" END_TIME='{7}',UPDATE_TIME='{8}',ERROR='{9}',REMARK='{10}' WHERE TID='{11}' ";


                strSql = string.Format(strSql, mdl.PN, mdl.OP, mdl.EMS, mdl.PR_COUNT, mdl.TIME_LENGTH, mdl.TGNAME,mdl.START_TIME.ToString("yyyy-MM-dd HH:mm:ss"),
                                       mdl.END_TIME.ToString("yyyy-MM-dd HH:mm:ss"), mdl.UPDATE_TIME.ToString("yyyy-MM-dd HH:mm:ss"),
                                       mdl.ERROR, mdl.REMARK, mdl.TID);

                ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);

                return ret;

            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// 通过TID获取采集单元
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public AcqLineCountMDL GetAcqLineUnit(string tid)
        {

            AcqLineCountMDL mdl = null;

            try
            {
                DataSet dataSet = null;

                string strSql = "SELECT * FROM tlb_acq_line WHERE TID={0}";

                strSql = string.Format(strSql, tid);


                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if(dataSet==null||dataSet.Tables[0].Rows.Count<=0)
                    return  null;

                 mdl = AcqLineCountMDL.PraseDataRow(dataSet.Tables[0].Rows[0]);

                 return mdl;
               
            }
            catch
            {
                throw;
            }
        }



        ///public  List<AcqLineCountMDL> GetAcqLineUnitByTimeRange(TimeRange range,string plineID)
        ///
        public List<AcqLineItemMDL> GetAcqLineUnitByTimeRange(TimeRange range, string plineID)
        {


            List<AcqLineItemMDL> list = null;

            try
            {
                DataSet dataSet = null;

                string strSql = "SELECT * FROM tlb_acq_line  tal WHERE tal.START_TIME>='{0}' AND tal.END_TIME<='{1}' AND tal.PLID='{2}' ORDER BY tal.START_TIME ASC";

                strSql = string.Format(strSql, range.StartTime.ToString("yyyy-MM-dd HH:mm:ss"), range.EndTime.ToString("yyyy-MM-dd HH:mm:ss"), plineID);


                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet == null || dataSet.Tables[0].Rows.Count <= 0)
                    return null;


                 list = new List<AcqLineItemMDL>();

                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                //    list.Add(AcqLineCountMDL.PraseDataRow(row));
                    list.Add(AcqLineItemMDL.PraseDataRow(row));
                    
                }

                return list;
            }
            catch
            {
                throw;
            }
    
         }



        /// <summary>
        /// 通过时间段获取采集分项采集信息
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
       // public List<AcqLineCountMDL> GetAcqLineUnitByTimeRange(TimeRange range)
        public List<AcqLineItemMDL> GetAcqLineUnitByTimeRange(TimeRange range)
        {

            List<AcqLineItemMDL> list = null;

            try
            {
                DataSet dataSet = null;

                string strSql = "SELECT * FROM tlb_acq_line WHERE START_TIME>=UNIX_TIMESTAMP({0}) AND  UNIX_TIMESTAMP({1})<END_TIME";

                strSql = string.Format(strSql, range.StartTime,range.EndTime);


                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet == null || dataSet.Tables[0].Rows.Count <= 0)
                    return null;


                list = new List<AcqLineItemMDL>();

                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    list.Add(AcqLineItemMDL.PraseDataRow(row));
                }

                return list;
            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// 获取产品生产信息通过采集编号区间
        /// </summary>
        /// <param name="planid"></param>
        /// <returns></returns>
        public AcqUnitMDL GetPlanItemByUnitID(string plineid,string unitid,int nOP)
        {
            try
            {

                AcqUnitMDL acqUnit = null;

            
                string strSql = "SELECT * FROM tlb_acq_line  WHERE PLID='{0}' AND UNITID='{1}' ";

                strSql = string.Format(strSql, plineid,unitid);


                DataSet dataSet = null;

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet != null)
                {
                    acqUnit = new AcqUnitMDL();
                    acqUnit.PNCODE=string.Empty;

                   

                    int seq = 0;
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                       ///产线采集单元
                    AcqLineCountMDL lineUnit= AcqLineCountMDL.PraseDataRow(row);

                       //获取序列号
                       seq = Convert.ToInt32(lineUnit.TGNMAE);

                       //添加产品信息
                       acqUnit.AddProductItem(seq, lineUnit.UNITID, lineUnit.PN,lineUnit.CUR_COUNT, nOP);
                       acqUnit.StartTime = lineUnit.START_TIME;
                       acqUnit.EndTime = lineUnit.END_TIME;

                    }


                    //if()

                }

                return acqUnit;

            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return null;
            }
        }

        //private double GetOEE(AcqUnitMDL unit, Hashtable ctTable, string pncode)
        //{
        //    try
        //    {

        //        double oee = 0.0;

                

        //        if (!ctTable.Contains(pncode))
        //            return oee;

        //        CTUnitMDL ct = (CTUnitMDL)ctTable[pncode];

        //        if (ct != null)
        //        {
        //            oee = unit.GetOEE(ct.CT);
        //        }

        //        return oee;

        //    }
        //    catch
        //    {
        //        return 0.0;
        //    }
        //}




        private double GetOEE(AcqUnitMDL unit, Hashtable ctTable)
        {
            try
            {

                double oee = 0.0;

                string key = unit.CODE.Split(',')[0];

                if (!ctTable.Contains(key))
                    return oee;

               // CTUnitMDL ct = (CTUnitMDL)ctTable[unit.CODE];
                CTUnitMDL ct = (CTUnitMDL)ctTable[key];

                if (ct != null)
                {
                    oee = unit.GetOEE(ct.CT);
                }

                return oee;

            }
            catch
            {
                return 0.0;
            }
        }


        private double GetPT(AcqUnitMDL unit,int op)
        {
            try
            {

                double pt = 0.0;

                    pt = unit.GetProductivty(op);
            

                return pt;

            }
            catch
            {
                return 0.0;
            }

        }

        public double[] GetPlanDayOOEuPT(DateTime date,string lineID,List<int> ops,Hashtable ctTable,string passID)
        {
            try
            {

               double[] oeeop=new double[2];

               oeeop[0] = 0;

               oeeop[1] = 0;
                string queryID = date.ToString("yyyyMMdd") + lineID;

                string strSql = "SELECT * FROM tlb_acq_line  WHERE  UNITID LIKE '{0}%' ";

                strSql = string.Format(strSql, queryID);


                DataSet dataSet = null;

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet != null)
                {
                    AcqUnitMDL item = null;

                    int count=0;

                    double oee = 0.0;

                    double pt  = 0.0;


                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                         item= new AcqUnitMDL();
                        
                        ///产线采集单元
                        AcqLineCountMDL lineUnit = AcqLineCountMDL.PraseDataRow(row);


                         ////是当天不是当前采集单元内的
                        if (passID == lineUnit.UNITID)
                        {

                            continue;
                        }

                        int tag=0;

                        Int32.TryParse(lineUnit.TGNMAE, out tag);

                        
                        //获取序列号
                       // seq = Convert.ToInt32(lineUnit.TGNMAE);

                        if (tag >= ops.Count)
                            tag = 0;

                        //添加产品信息
                        item.AddProductItem(tag, lineUnit.UNITID, lineUnit.PN, lineUnit.CUR_COUNT, ops[tag]);
                        //item.
                        item.StartTime = lineUnit.START_TIME;
                        item.EndTime = lineUnit.END_TIME;

                        //oee += GetOEE(item, ctTable, lineUnit.PN);
                        oee += GetOEE(item, ctTable);
                        pt += GetPT(item,ops[tag]);


                        if(oee>0&&pt>0)
                           count += 1;
                    }

                 
                   oeeop[0] = Math.Round(oee/count,2);
                   oeeop[1] = Math.Round(pt / count, 2);


                }

                return oeeop;

            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return null;
            }
        }




        public double[] GetPlanDayOOEuPT(DateTime date, string lineID, List<OPMDL> ops, Hashtable ctTable, string passID)
        {
            try
            {

                double[] oeeop = new double[2];

                oeeop[0] = 0;

                oeeop[1] = 0;
                string queryID = date.ToString("yyyyMMdd") + lineID;

                string strSql = "SELECT * FROM tlb_acq_line  WHERE  UNITID LIKE '{0}%' ";

                strSql = string.Format(strSql, queryID);


                DataSet dataSet = null;

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet != null)
                {
                    AcqUnitMDL item = null;

                    int count = 0;

                    double oee = 0.0;

                    double pt = 0.0;


                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        item = new AcqUnitMDL();

                        ///产线采集单元
                        AcqLineCountMDL lineUnit = AcqLineCountMDL.PraseDataRow(row);


                        ////是当天不是当前采集单元内的
                        if (passID == lineUnit.UNITID)
                        {

                            continue;
                        }

                        int tag = 0;

                        Int32.TryParse(lineUnit.TGNMAE, out tag);


                        //获取序列号
                        // seq = Convert.ToInt32(lineUnit.TGNMAE);

                        if (tag >= ops.Count)
                            tag = 0;

                        //添加产品信息
                        //item.AddProductItem(tag, lineUnit.UNITID, lineUnit.PN, lineUnit.CUR_COUNT, ops[tag].OP);
                        item.AddProductItem(tag, lineUnit.UNITID, lineUnit.PN, lineUnit.GetEMSCode(), lineUnit.CUR_COUNT, ops[tag].OP);

                        //item.
                        item.StartTime = lineUnit.START_TIME;
                        item.EndTime = lineUnit.END_TIME;

                        //oee += GetOEE(item, ctTable, lineUnit.PN);
                        oee += GetOEE(item, ctTable);
                        pt += GetPT(item, ops[tag].OP);


                        if (oee > 0 && pt > 0)
                            count += 1;
                    }


                    oeeop[0] = Math.Round(oee / count, 2);

                    if (oeeop[0] < 0 || Double.IsNaN(oeeop[0]))
                        oeeop[0] = 0.0;
                    oeeop[1] = Math.Round(pt / count, 2);

                    if (oeeop[1] < 0 || Double.IsNaN(oeeop[1]))
                        oeeop[1] = 0.0;


                }

                return oeeop;

            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return null;
            }
        }




        public double[] GetPlanDayOOEuPT(DateTime date, string lineID, List<OPMDL> ops, Hashtable ctTable, string passID,TimeRange timeRange)
        {
            try
            {

                double[] oeeop = new double[2];

                oeeop[0] = 0;

                oeeop[1] = 0;
                string queryID = date.ToString("yyyyMMdd") + lineID;

                string strSql = "SELECT * FROM tlb_acq_line  WHERE  UNITID LIKE '{0}%' ";

                strSql = string.Format(strSql, queryID);


                DataSet dataSet = null;

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet != null)
                {
                    AcqUnitMDL item = null;

                    int count = 0;

                    double oee = 0.0;

                    double pt = 0.0;


                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        item = new AcqUnitMDL();

                        ///产线采集单元
                        AcqLineCountMDL lineUnit = AcqLineCountMDL.PraseDataRow(row);



                        //if (!timeRange.IsInRange2(lineUnit.END_TIME))
                        //    continue;
                        if (!timeRange.IsInRange2(lineUnit.START_TIME))
                            continue;

                        ////是当天不是当前采集单元内的
                        if (passID == lineUnit.UNITID)
                        {

                            continue;
                        }

                        int tag = 0;

                        Int32.TryParse(lineUnit.TGNMAE, out tag);


                        //获取序列号
                        // seq = Convert.ToInt32(lineUnit.TGNMAE);

                        if (tag >= ops.Count)
                            tag = 0;

                        //添加产品信息
                        //item.AddProductItem(tag, lineUnit.UNITID, lineUnit.PN, lineUnit.CUR_COUNT, ops[tag].OP);
                        item.AddProductItem(tag, lineUnit.UNITID, lineUnit.PN, lineUnit.GetEMSCode(), lineUnit.CUR_COUNT, ops[tag].OP);
                        //item.
                        item.StartTime = lineUnit.START_TIME;
                        ///
                        ///item.EndTime = lineUnit.END_TIME;
                        item.EndTime = lineUnit.UPDATE_TIME;

                        //GetEMSCode

                        //oee += GetOEE(item, ctTable, lineUnit.PN);
                       // oee += GetOEE(item, ctTable, lineUnit.GetEMSCode());
                        oee += GetOEE(item, ctTable);
                        pt += GetPT(item, ops[tag].OP);


                        if (oee > 0 && pt > 0)
                            count += 1;
                    }


                    oeeop[0] = Math.Round(oee / count, 2);

                    if (oeeop[0] < 0 || Double.IsNaN(oeeop[0]) || Double.IsInfinity(oeeop[1]))
                        oeeop[0] = 0.0;

                    oeeop[1] = Math.Round(pt / count, 2);

                    if (oeeop[1] < 0 || Double.IsNaN(oeeop[1]) || Double.IsInfinity(oeeop[1]))
                        oeeop[1] = 0.0;


                }

                return oeeop;

            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return null;
            }
        }

        public List<ProductReportMDL> GetPlanItemByPlineID(string unitid, List<OPMDL> ops, Hashtable ctTable,int range,TimeRange timeRange)
        {

            List<ProductReportMDL> list = new List<ProductReportMDL>();

            try
            {

                string strSql = "SELECT * FROM tlb_acq_line  WHERE  UNITID LIKE '{0}%' ";

                strSql = string.Format(strSql, unitid);


                DataSet dataSet = null;

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet != null)
                {

                    Hashtable  hashProducts=new Hashtable();
                        
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        ///产线采集单元
                        AcqLineCountMDL lineUnit = AcqLineCountMDL.PraseDataRow(row);

                       // AcqUnitMDL acqUnit = null;

                        ProductReportMDL pdUnit = null;


                        int op = 0;
                        int seq = 0;
                        double pt = 0.0;
                        double oee = 0.0;


                        

                        ///超出时间统计范围时间
                        if (!timeRange.IsInRange2(lineUnit.UPDATE_TIME))
                            continue;

                       // if (!hashProducts.Contains(lineUnit.PN.Trim()))

                        if (!hashProducts.Contains(lineUnit.GetEMSCode()))
                        {

                            AcqUnitMDL acqUnit = new AcqUnitMDL();

                            //获取序列号
                            seq = Convert.ToInt32(lineUnit.TGNMAE)-range;

                            if (ops.Count <= seq)
                                continue;

                            op = ops[seq].OP;

                            acqUnit.PNCODE = lineUnit.PN.Trim();
                            acqUnit.StartTime = lineUnit.START_TIME;
                            acqUnit.EndTime = lineUnit.UPDATE_TIME;
                         //   acqUnit.ACUTAL = lineUnit.CUR_COUNT;


                            //添加产品信息
                           // acqUnit.AddProductItem(seq, lineUnit.UNITID, lineUnit.PN, lineUnit.CUR_COUNT, op);
                            acqUnit.AddProductItem(seq, lineUnit.UNITID, lineUnit.PN, lineUnit.GetEMSCode(),lineUnit.CUR_COUNT, op);
                            //acqUnit.PLD.OEE = GetOEE(acqUnit, ctTable, lineUnit.PN.Trim());
                            //acqUnit.PLD.PT = GetPT(acqUnit, op);

                            pdUnit = new ProductReportMDL();


                            ProductDal pDal = new ProductDal();

                           // CTUnitMDL mdl = pDal.GetCTUnit(lineUnit.GetEMSCode());

                            CTUnitMDL mdl = pDal.GetCTUnit(acqUnit.PLINEID, acqUnit.EMS);

                            if (mdl == null)
                            {
                                pdUnit.NAME = lineUnit.GetEMSCode();
                                pdUnit.OEE = 0.0;
                                pdUnit.CODE = lineUnit.GetEMSCode();
                                //pdUnit.OEE += GetOEE(acqUnit, ctTable);
                                //pdUnit.OEE = GetOEE(acqUnit, ctTable, lineUnit.PN.Trim());
                                pdUnit.OP = 0.0;
                                pdUnit.CO = 0.0;
                            }
                            else
                            {
                                pdUnit.NAME = mdl.PN;
                                pdUnit.OEE += acqUnit.GetOEE(mdl.CT);
                                   // GetOEE(acqUnit, ctTable);
                                //pdUnit.OEE = GetOEE(acqUnit, ctTable, lineUnit.PN.Trim());
                                pdUnit.OP = acqUnit.GetProductivty(op);
                                   // GetPT(acqUnit, op);
                                pdUnit.CO = 0.0;

                            }
                            hashProducts.Add(lineUnit.GetEMSCode(), pdUnit);

                        }
                        else
                        {

                            AcqUnitMDL acqUnit = new AcqUnitMDL();

                            //获取序列号
                            seq = Convert.ToInt32(lineUnit.TGNMAE) - range;


                            if (ops.Count <= seq)
                                continue;

                            op = ops[seq].OP;

                            acqUnit.PNCODE = lineUnit.PN.Trim();
                            acqUnit.StartTime = lineUnit.START_TIME;
                            acqUnit.EndTime = lineUnit.END_TIME;

                            ProductDal pDal = new ProductDal();

                            //CTUnitMDL mdl = pDal.GetCTUnit(lineUnit.GetEMSCode());

                            CTUnitMDL mdl = pDal.GetCTUnit(acqUnit.PLINEID, acqUnit.EMS);

                            
                            //   acqUnit.ACUTAL = lineUnit.CUR_COUNT;


                            //添加产品信息
                            //acqUnit.AddProductItem(seq, lineUnit.UNITID, lineUnit.PN, lineUnit.CUR_COUNT, op);
                            acqUnit.AddProductItem(seq, lineUnit.UNITID, lineUnit.PN,lineUnit.GetEMSCode(), lineUnit.CUR_COUNT, op);

                            if (mdl == null)
                                continue;



                            ((ProductReportMDL)hashProducts[lineUnit.GetEMSCode()]).OEE = (acqUnit.GetOEE(mdl.CT) + ((ProductReportMDL)hashProducts[lineUnit.GetEMSCode()]).OEE) / 2;
                            ((ProductReportMDL)hashProducts[lineUnit.GetEMSCode()]).OP = (acqUnit.GetProductivty(op) + ((ProductReportMDL)hashProducts[lineUnit.GetEMSCode()]).OP) / 2;

                           // pdUnit.NAME = lineUnit.PN.Trim();
                            //pdUnit.OEE = GetOEE(acqUnit, ctTable, lineUnit.PN.Trim());
                          //  pdUnit.OP = GetPT(acqUnit, op);
                          ///  pdUnit.CO = 0.3;

                            ////((ProductReportMDL)hashProducts[lineUnit.PN]).OEE =(GetOEE(acqUnit, ctTable, lineUnit.PN.Trim()) + ((ProductReportMDL)hashProducts[lineUnit.PN]).OEE)/2;
                            //((ProductReportMDL)hashProducts[lineUnit.PN]).OEE = (GetOEE(acqUnit, ctTable) + ((ProductReportMDL)hashProducts[lineUnit.PN]).OEE) / 2;
                            //((ProductReportMDL)hashProducts[lineUnit.PN]).OP = (GetPT(acqUnit, op)+((ProductReportMDL)hashProducts[lineUnit.PN]).OP)/2;
                          




                        }

                    }



      

                    foreach (DictionaryEntry de in hashProducts)
                    {

                        //AcqUnitMDL unit = (ProductReportMDL)de.Value;

                        list.Add((ProductReportMDL)de.Value);

                    }

                    return list;
                }

                return null;
            }
            catch 
            {
                throw;
            }
        }






        public ProductsMDL GetPlanItemByDateTime(DateTime dateTime, List<OPMDL> ops)
        {
            try
            {
                ProductsMDL productsTable= new ProductsMDL();


                string strSql = "SELECT * FROM tlb_acq_line  WHERE  UNITID LIKE '{0}%' ";

                strSql = string.Format(strSql, dateTime.ToString("yyyyMMdd"));


                DataSet dataSet = null;

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet != null)
                {

                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        ///产线采集单元
                        AcqLineCountMDL lineUnit = AcqLineCountMDL.PraseDataRow(row);

                        AcqUnitMDL acqUnit = null;

                        int op = 0;
                        int seq = 0;

                        switch(lineUnit.PLID)
                        {
                            case "01":
                    

                                if (!productsTable.Line1Products.Contains(lineUnit.PN))
                                {

                                    acqUnit = new AcqUnitMDL();

                                    //获取序列号
                                    seq = Convert.ToInt32(lineUnit.TGNMAE);

                                    op = ops[seq].OP;

                                    //添加产品信息
                                    acqUnit.AddProductItem(seq, lineUnit.UNITID, lineUnit.PN, lineUnit.CUR_COUNT, op);

                                    productsTable.Line1Products.Add(acqUnit.PNCODE, acqUnit);

                                }
                                else
                                {

                                    ((AcqUnitMDL)productsTable.Line1Products[lineUnit.PN]).AddProductItem(seq, lineUnit.UNITID,
                                                                                                           lineUnit.PN, lineUnit.CUR_COUNT, 
                                                                                                           op);
                                  
                                }

                                break;
                            case "02":

                                if (!productsTable.Line2Products.Contains(lineUnit.PN))
                                {

                                    acqUnit = new AcqUnitMDL();

                                    //获取序列号
                                    seq = Convert.ToInt32(lineUnit.TGNMAE);

                                    op = ops[seq].OP;

                                    //添加产品信息
                                    acqUnit.AddProductItem(seq, lineUnit.UNITID, lineUnit.PN, lineUnit.CUR_COUNT, op);

                                    productsTable.Line2Products.Add(acqUnit.PNCODE, acqUnit);

                                }
                                else
                                {

                                    ((AcqUnitMDL)productsTable.Line2Products[lineUnit.PN]).AddProductItem(seq, lineUnit.UNITID,
                                                                                                           lineUnit.PN, lineUnit.CUR_COUNT,
                                                                                                           op);

                                }
                                break;
                            case "03":

                                if (!productsTable.Line3Products.Contains(lineUnit.PN))
                                {

                                    acqUnit = new AcqUnitMDL();

                                    //获取序列号
                                    seq = Convert.ToInt32(lineUnit.TGNMAE);

                                    op = ops[seq].OP;

                                    //添加产品信息
                                    acqUnit.AddProductItem(seq, lineUnit.UNITID, lineUnit.PN, lineUnit.CUR_COUNT, op);

                                    productsTable.Line3Products.Add(acqUnit.PNCODE, acqUnit);

                                }
                                else
                                {

                                    ((AcqUnitMDL)productsTable.Line3Products[lineUnit.PN]).AddProductItem(seq, lineUnit.UNITID,
                                                                                                           lineUnit.PN, lineUnit.CUR_COUNT,
                                                                                                           op);

                                }
                                break;
                            case "04":

                                if (!productsTable.MGUProducts.Contains(lineUnit.PN))
                                {

                                    acqUnit = new AcqUnitMDL();

                                    //获取序列号
                                    seq = Convert.ToInt32(lineUnit.TGNMAE);

                                    op = ops[seq].OP;

                                    //添加产品信息
                                    acqUnit.AddProductItem(seq, lineUnit.UNITID, lineUnit.PN, lineUnit.CUR_COUNT, op);

                                    productsTable.MGUProducts.Add(acqUnit.PNCODE, acqUnit);

                                }
                                else
                                {

                                    ((AcqUnitMDL)productsTable.MGUProducts[lineUnit.PN]).AddProductItem(seq, lineUnit.UNITID,
                                                                                                        lineUnit.PN, lineUnit.CUR_COUNT,
                                                                                                        op);

                                }
                                break;
                            default:
                              break;
                        }


                    }

       

                }

                return productsTable;
            }
            catch 
            {
              throw;
            }
        }



        public AcqUnitMDL GetPlanItemByUnitItems(string unitid, List<OPMDL> ops,TimeRange timeRange)
        {
            try
            {

                AcqUnitMDL acqUnit = null;


                string strSql = "SELECT * FROM tlb_acq_line  WHERE  UNITID='{0}' ";

                strSql = string.Format(strSql, unitid);


                DataSet dataSet = null;

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet != null)
                {
                    acqUnit = new AcqUnitMDL();

                    int seq = 0;

                    int opIndex = 0;
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        ///产线采集单元
                        AcqLineCountMDL lineUnit = AcqLineCountMDL.PraseDataRow(row);


                        if (!timeRange.IsInRange2(lineUnit.END_TIME))
                            continue;

                        //获取序列号
                        seq = Convert.ToInt32(lineUnit.TGNMAE);

                        //添加产品信息
                        acqUnit.AddProductItem(seq, lineUnit.UNITID, lineUnit.PN, lineUnit.CUR_COUNT, ops[opIndex].OP);

                    }

                }

                return acqUnit;

            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace("导出错误" + ex.Message);
                return null;
            }
        }



        public AcqUnitMDL GetPlanItemByUnitItems(string unitid, List<OPMDL>  ops)
        {
            try
            {

                AcqUnitMDL acqUnit = null;


                string strSql = "SELECT * FROM tlb_acq_line  WHERE  UNITID='{0}' ";

                strSql = string.Format(strSql, unitid);


                DataSet dataSet = null;

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet != null)
                {
                    acqUnit = new AcqUnitMDL();

                    int seq = 0;

                    int opIndex = 0;
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        ///产线采集单元
                        AcqLineCountMDL lineUnit = AcqLineCountMDL.PraseDataRow(row);

                        //获取序列号
                        seq = Convert.ToInt32(lineUnit.TGNMAE);

                        //添加产品信息
                       // acqUnit.AddProductItem(seq, lineUnit.UNITID, lineUnit.PN, lineUnit.CUR_COUNT, ops[opIndex].OP);
                        acqUnit.AddProductItem(seq, lineUnit.UNITID,lineUnit.PN, lineUnit.GetEMSCode(), lineUnit.CUR_COUNT, ops[opIndex].OP);

                        ChangeTimeDAL coDal = new ChangeTimeDAL();

                        int cocount = coDal.GetChangeTimeByUnitID(unitid);

                        acqUnit.AddCO(cocount);
                    }

                }

                return acqUnit;

            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace("导出错误" + ex.Message);
                return null;
            }
        }


        public AcqUnitMDL GetPlanItemByUnit(string unitid, int nOP)
        {
             try
            {

                AcqUnitMDL acqUnit = null;

            
                string strSql = "SELECT * FROM tlb_acq_line  WHERE  UNITID='{0}' ";

                strSql = string.Format(strSql, unitid);


                DataSet dataSet = null;

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet != null)
                {
                    acqUnit = new AcqUnitMDL();

                    int seq = 0;
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                       ///产线采集单元
                       AcqLineCountMDL lineUnit= AcqLineCountMDL.PraseDataRow(row);

                       //获取序列号
                       seq = Convert.ToInt32(lineUnit.TGNMAE);

                       //添加产品信息
                      // acqUnit.AddProductItem(seq, lineUnit.UNITID, lineUnit.PN,lineUnit.CUR_COUNT, nOP);
                       acqUnit.AddProductItem(seq, lineUnit.UNITID, lineUnit.PN, lineUnit.GetEMSCode(), lineUnit.CUR_COUNT, nOP);
                    }

                }

                return acqUnit;

            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace("导出错误"+ex.Message);
                return null;
            }
        }
        


    }
}
