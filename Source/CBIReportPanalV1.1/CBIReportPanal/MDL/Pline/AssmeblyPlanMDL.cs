using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MDL
{

    /// <summary>
    /// 
    /// </summary>
    public class AssmeblyPlanMDL
    {

        private string plan_id;

        private string  plid;

        private string pn;

        private string station_id;

        private DateTime start_time;

        private DateTime end_time;

        private int plan_num;

        private int actual_num;

        private int ct;

        private int worknum;

        private int shift;

        private DateTime create_time;

        private string remark=string.Empty;


        public string PN
        {
            get { return pn; }

            set { pn = value; }
        }


        public string PLANID
        {
            get { return plan_id; }

            set { plan_id = value; }
        }

        public string PLID
        {
            get { return plid; }

            set { plid = value; }
        }

        public string STATIONID
        {
            get { return station_id; }

            set { station_id = value; }
        }


        public DateTime START_TIME
        {
            get { return start_time; }

            set { start_time = value; }
        }

        public DateTime END_TIME
        {
            get { return end_time; }

            set { end_time = value; }
        }


        public int PLAN_NUM
        {
            get { return plan_num; }

            set { plan_num = value; }
        }


        public int ACTUAL_NUM
        {
            get { return actual_num; }

            set { actual_num = value; }
        }


        public int SHIFT
        {
            get { return shift; }

            set { shift = value; }
        }


        public int CT
        {
            get { return ct; }

            set { ct = value; }
        }


        public DateTime CREATE_TIME
        {
            get { return create_time; }

            set { create_time = value; }
        }


        public int WORK_NUM
        {
            get { return worknum; }

            set { worknum = value; }
        }

        public string REMARK
        {

            get { return remark; }

            set { remark = value; }
        }


        public static AssmeblyPlanMDL PraseDataRow(DataRow row)
        {
            AssmeblyPlanMDL mdl = new AssmeblyPlanMDL();

            try
            {

                mdl.PLANID = Convert.ToString(row["PLANID"]);
                mdl.STATIONID = Convert.ToString(row["STATIONID"]);
                mdl.START_TIME = Convert.ToDateTime(row["START_TIME"]);
                mdl.END_TIME = Convert.ToDateTime(row["END_TIME"]);
                mdl.PLID = Convert.ToString(row["PLID"]);
                mdl.PN = Convert.ToString(row["PN"]);
                mdl.PLAN_NUM = Convert.ToInt32(row["PLAN_NUM"]);
                mdl.ACTUAL_NUM = Convert.ToInt32(row["ACTUAL_NUM"]);
                mdl.CT = Convert.ToInt32(row["CT"]);
                mdl.WORK_NUM = Convert.ToInt32(row["WORK_NUM"]);
                mdl.SHIFT = Convert.ToInt32(row["SHIFT"]);
                mdl.CREATE_TIME = Convert.ToDateTime(row["CREATE_TIME"]);
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

