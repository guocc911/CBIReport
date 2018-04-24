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
    public class AcqTraceDAL
    {


        /// <summary>
        /// 添加采集数据
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int AddAcqTrace(AcqLineTraceMDL mdl)
        {

            int ret = 0;

            string strSql = string.Empty;

            try
            {

                strSql = "insert into  tlb_acq_trace (ACQID,ACQ_DATE,SEQID,PLID,EMS,STATIONID,BEG_COUNT,ERROR)" +
                                    "values('{0}','{1}','{2}','{3}',{4},'{5}',{6},'{7}')";

                strSql = string.Format(strSql, mdl.ACQID, mdl.ACQ_DATE.ToString("yyyy-MM-dd HH:mm:ss"), mdl.SEQID, mdl.PLID, mdl.EMS, mdl.STATIONID, mdl.BEG_COUNT, mdl.ERROR);


                ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);


                return ret;

            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 更新记录数据
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int UpdateAcqTrace(AcqLineTraceMDL mdl)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {

                strSql = "UPDATE tlb_acq_trace SET SEQID='{0}',PLID='{1}',EMS = {2},STATIONID='{3}'  WHERE ACQID='{4}'";

                strSql = string.Format(strSql, mdl.SEQID, mdl.PLID, mdl.EMS, mdl.STATIONID, mdl.ACQID);

                ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);

                return ret;

            }
            catch
            {
                throw;
            }
        }

    }
}
