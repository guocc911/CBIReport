using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COMM;

namespace MDL
{
    public class ExtTimeMDL
    {

        private string plineid;

        private string name;

        private DateTime lunchDate;

        private int  lunchTime;

        private DateTime dinnerDate;

        private int dinnerTime;

       // private TimeRange lunchRange;

       // private TimeRange dinnerRange;

        private string remark;



        public ExtTimeMDL()
        {
            dinnerTime = 0;
            dinnerTime = 0;

        }


        /// <summary>
        /// 产线ID
        /// </summary>
        public string PLINEID
        {
            get { return plineid; }
            set { plineid = value; }
        }


        public string NAME
        {
            get { return name; }
            set { name = value; }
        }

 


        public DateTime LUNCH
        {
            get { return lunchDate; }
            set { lunchDate = value; }
        }

        public int L_TIME
        {
            get { return lunchTime; }
            set { lunchTime = value; }
        }



        public DateTime DINNER
        {
            get { return dinnerDate; }
            set { dinnerDate = value; }
        }

        public int D_TIME
        {
            get { return dinnerTime; }
            set { dinnerTime = value; }
        }

        public string REMARK
        {
            get { return remark; }
            set { remark = value; }
        }


        /// <summary>
        /// 晚餐时间范围
        /// </summary>
        public TimeRange DINNER_RANGE
        {
            get 
            {
                try
                {
                    if (dinnerDate == null || dinnerTime <= 0)
                        return null;

                    TimeRange range = new TimeRange();

                    DateTime startTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd ") + dinnerDate.ToString("HH:mm:ss"));
                    range.StartTime = startTime;
                    range.EndTime = startTime.AddMinutes(dinnerTime);

                    return range;
                }
                catch 
                {
                    throw;
                }

            
            }
        }


        /// <summary>
        /// 午餐时间范围
        /// </summary>
        public TimeRange LUNCH_RANGE
        {
            get
            {
                try
                {
                    if (lunchDate == null || lunchTime <= 0)
                        return null;

                    TimeRange range = new TimeRange();

                    DateTime startTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd ") + lunchDate.ToString("HH:mm:ss"));
                    range.StartTime = startTime;
                    range.EndTime = startTime.AddMinutes(lunchTime);

                    return range;
                }
                catch
                {
                    throw;
                }


            }
        }

        /// <summary>
        /// 获取排除计算时间信息
        /// </summary>
        /// <param name="row"></param>
        public void Prase(DataRow row)
        {
            plineid = Convert.ToString(row["PLINEID"]);
            name = Convert.ToString(row["NAME"]);
            lunchDate = Convert.ToDateTime(row["LUNCH"]);
            dinnerDate = Convert.ToDateTime(row["DINNER"]);
            lunchTime = Convert.ToInt32(row["L_TIME"]);
            dinnerTime = Convert.ToInt32(row["D_TIME"]);
            remark = Convert.ToString(row["REMARK"]);
       
        }

        public static ExtTimeMDL PraseDataRow(DataRow row)
        {
            try
            {

                ExtTimeMDL mdl=new ExtTimeMDL();

                mdl.PLINEID = Convert.ToString(row["PLINEID"]);
                mdl.NAME = Convert.ToString(row["NAME"]);
                mdl.LUNCH = Convert.ToDateTime(row["LUNCH"]);
                mdl.L_TIME = Convert.ToInt32(row["L_TIME"]);
                mdl.DINNER= Convert.ToDateTime(row["DINNER"]);
                mdl.D_TIME = Convert.ToInt32(row["D_TIME"]);
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
