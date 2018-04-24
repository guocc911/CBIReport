using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDL
{


    /// <summary>
    /// 采集数据的单元
    /// </summary>
    public class AcqLineItemMDL
    {
       
        private string tid;

        private string plid;

        private string unitid;

        private string  pn;

        private int op;

        private int ems;

        private int  pr_count;

        private int time_length;

        private string tgname;

        private DateTime startTime;

        private DateTime endTime;

        private DateTime updateTime;

        private string error;

        private string remark;



        #region  property

        public string TID
        {
            get { return tid; }
            set { tid = value; }
        }


        public string PLID
        {
            get { return plid; }
            set { plid = value; }
        }


        public string UNITID
        {
            get { return unitid; }
            set { unitid = value; }
        }


        public string PN 
        {
            get { return pn; }
            set { pn = value; }
        }


        public int OP
        {
            get { return op; }
            set { op = value; }
        }

        public int EMS
        {
            get { return ems; }
            set { ems = value; }
        }


        public int PR_COUNT
        {
            get { return pr_count; }
            set { pr_count = value; }
        }


        public int TIME_LENGTH
        {
            get { return time_length; }
            set { time_length = value; }
        }


        public string TGNAME
        {
            get { return tgname; }
            set { tgname = value; }
        }


        public DateTime START_TIME
        {
            get { return startTime; }
            set { startTime = value; }
        }


        public DateTime END_TIME
        {
            get { return endTime; }
            set { endTime = value; }
        }


        public DateTime UPDATE_TIME
        {
            get { return updateTime; }
            set { updateTime = value; }
        }


        public string ERROR
        {
            get { return error; }
            set { error = value; }
        }

        public string REMARK
        {
            get { return remark; }
            set { remark = value; }
        }

        #endregion



        public bool SetTID(DateTime date, string line, string tag, string seq)
        {
            try
            {

                if (date == null)
                    return false;

                if (line == null)
                    return false;

                if (tag == null)
                    return false;

                if (seq == null)
                    return false;


                this.tid = date.ToString("yyyyMMdd") + line + tag + seq;

                this.unitid = date.ToString("yyyyMMdd") + line + tag;

                return true;

            }
            catch
            {
                throw;
            }

        }


        public void Prase(DataRow row)
        {

            try
            {

                AcqLineItemMDL mdl = PraseDataRow(row);
                this.tid = mdl.TID;
                this.plid = mdl.PLID;
                this.pn = mdl.PN;
                this.op = mdl.OP;
                this.ems = mdl.EMS;
                this.pr_count = mdl.PR_COUNT;
                this.time_length = mdl.TIME_LENGTH;
                this.tgname = mdl.TGNAME;
                this.startTime = mdl.START_TIME;
                this.endTime = mdl.END_TIME;
                this.updateTime = mdl.UPDATE_TIME;
                this.error = mdl.ERROR;
                this.remark = mdl.REMARK;
            }
            catch 
            {
                throw;
            	
            }
        }
        /// <summary>
        /// 解析数据
        /// </summary>
        /// <param name="row"></param>
        public static  AcqLineItemMDL  PraseDataRow(DataRow row)
        {

            AcqLineItemMDL mdl = new AcqLineItemMDL();

            try
            {
                mdl.TID = Convert.ToString(row["TID"]);
                mdl.PLID = Convert.ToString(row["PLID"]);
                mdl.PN = Convert.ToString(row["PN"]);
                mdl.OP = Convert.ToInt32(row["OP"]);
                mdl.EMS = Convert.ToInt32(row["EMS"]);
                mdl.UNITID = Convert.ToString(row["UNITID"]);
                mdl.PR_COUNT = Convert.ToInt32(row["PR_COUNT"]);
                mdl.TIME_LENGTH = Convert.ToInt32(row["TIME_LENGTH"]);
                mdl.TGNAME = Convert.ToString(row["TGNMAE"]);
                mdl.START_TIME = Convert.ToDateTime(row["START_TIME"]);
                mdl.END_TIME = Convert.ToDateTime(row["END_TIME"]);
                mdl.UPDATE_TIME = Convert.ToDateTime(row["UPDATE_TIME"]);
                mdl.ERROR = Convert.ToString(row["ERROR"]);
                mdl.REMARK = Convert.ToString(row["REMARK"]);

                return mdl;
            }
            catch 
            {
                throw;	
            }
           

        }


    }
}
