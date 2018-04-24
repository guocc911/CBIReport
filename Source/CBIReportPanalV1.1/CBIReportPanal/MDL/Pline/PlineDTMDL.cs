using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDL
{


    /// <summary>
    /// 停机区间
    /// </summary>
    public class PlineDTMDL
    {

        private string dtID;

        private string lineID;

        private string rangeID;

        private int cla_order; 

        private DateTime startTime;

        private DateTime endTime;

        private int downTime;

        /// <summary>
        /// 停机ID 
        /// </summary>
        public string DTID
        {
            get { return dtID; }
            set { dtID = value; }
        }

        /// <summary>
        /// 产线ID
        /// </summary>
        public string PLINEID
        {
            get { return lineID; }
            set { lineID = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        public string RANGEID
        {
            get { return rangeID; }
            set { rangeID = value; }
        }

        /// <summary>
        /// 生产区间ID
        /// </summary>
        public int CLA_ORDER
        {
            get { return cla_order; }
            set { cla_order = value; }
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime START_TIME
        {
            get { return startTime; }
            set { startTime = value; }
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime END_TIME
        {
            get { return endTime; }
            set { endTime = value; }
        }

        /// <summary>
        /// 时长秒
        /// </summary>
        public int DOWNTIME
        {
            get { return downTime; }
            set { downTime = value; }
        }



        public void Parse(DataRow row)
        {

            PlineDTMDL  mdl= PlineDTMDL.ParseDataRow(row);

            this.DTID = mdl.DTID;
            this.PLINEID= mdl.PLINEID;
            this.RANGEID = mdl.RANGEID;
            this.START_TIME=mdl.START_TIME;
            this.END_TIME=mdl.END_TIME;
            this.DOWNTIME= mdl.DOWNTIME;
            this.CLA_ORDER = mdl.CLA_ORDER;
        }


       


        public static PlineDTMDL ParseDataRow(DataRow row)
        {
            PlineDTMDL mdl = new PlineDTMDL();

            try
            {

                mdl.DTID = Convert.ToString(row["DTID"]);
                mdl.PLINEID = Convert.ToString(row["PLINEID"]);
                mdl.RANGEID = Convert.ToString(row["RANGEID"]);
                mdl.START_TIME = Convert.ToDateTime(row["START_TIME"]);
                mdl.END_TIME = Convert.ToDateTime(row["END_TIME"]);
                mdl.DOWNTIME = Convert.ToInt32(row["DOWNTIME"]);
                mdl.CLA_ORDER = Convert.ToInt32(row["CLA_ORDER"]);
           

                return mdl;

            }
            catch
            {
                throw;
            }
        }
    }
}
