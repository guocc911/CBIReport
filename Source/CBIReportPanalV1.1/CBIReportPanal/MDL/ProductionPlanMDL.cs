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
    public class ProductionPlanMDL
    {
        private int tid;

        private string plan_id;

        private int pline_id;

        private string station_id;

        private DateTime start_time;

        private DateTime end_time;

        private string brakeid;

        private int plan_num;

        private int actual_num;

        private int shift;

        private DateTime create_time;

        private string remark=string.Empty;

        private List<int> oplist;


        public int TID
        {
            get { return tid; }

            set { tid = value; }
        }

        public string PlanID
        {
            get { return plan_id; }

            set { plan_id = value; }
        }

        public int Pline_ID
        {
            get { return pline_id; }

            set { pline_id = value; }
        }

        public string  Station_ID
        {
            get { return station_id; }

            set { station_id = value; }
        }


        public DateTime StartTime
        {
            get { return start_time; }

            set { start_time = value; }
        }

        public DateTime EndTime
        {
            get { return end_time; }

            set { end_time = value; }
        }

        public string BreakeID
        {
            get { return brakeid; }

            set { brakeid = value; }
        }

        public int PlanNum
        {
            get { return plan_num; }

            set { plan_num = value; }
        }


        public int Actual_num
        {
            get { return actual_num; }

            set { actual_num = value; }
        }


        public int Shift
        {
            get { return shift; }

            set { shift = value; }
        }


        public DateTime CreateTime
        {
            get { return create_time; }

            set { create_time = value; }
        }


        public string Remark
        {

            get { return remark; }

            set { remark = value; }
        }


        public void Prase(DataRow row)
        {
            tid = Convert.ToInt32(row["tid"]);
            plan_id = Convert.ToString(row["plan_id"]);
            pline_id = Convert.ToInt32(row["pline_id"]);
            station_id = Convert.ToString(row["station_id"]);
            start_time = Convert.ToDateTime(row["start_time"]);
            end_time = Convert.ToDateTime(row["end_time"]);
            brakeid = Convert.ToString(row["brakeid"]);
            plan_num = Convert.ToInt32(row["plan_num"]);
            actual_num = Convert.ToInt32(row["actual_num"]);
            shift = Convert.ToInt32(row["shift"]);
            //_remark = Convert.ToString(row["production_id"]);
            create_time = Convert.ToDateTime(row["create_time"]);
            remark = Convert.ToString(row["remark"]);
        }
    }
}

