using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDL
{
    public class ChangeTimeMDL
    {

        private string seqid;

        private string plid;

        private string unitid;

        private string per_pn;

        private string cur_pn;

        /// <summary>
        /// 当前的时间
        /// </summary>
        private DateTime cur_time;

        /// <summary>
        /// 前一条记录最后的插入的时间
        /// </summary>
        private DateTime pre_time;

        /// <summary>
        /// 换型时间  分钟
        /// </summary>
        private int time_mig;



        public string SEQID
        {
            get { return seqid; }

            set { seqid = value; }
        }

        public string PLID
        {
            get { return plid; }

            set { plid = value; }
        }


        public string PER_PN
        {
            get { return per_pn; }

            set { per_pn = value; }
        }


        public string CUR_PN
        {
            get { return cur_pn; }

            set { cur_pn = value; }
        }


        public DateTime CUR_TIME
        {
            get { return cur_time; }

            set { cur_time = value; }
        }


        public DateTime PER_TIME
        {
            get { return pre_time; }

            set { pre_time = value; }
        }



        public int TIME_MIG
        {
            get { return time_mig; }

            set { time_mig = value; }
        }



        public string UNITID
        {
            get { return unitid; }

            set { unitid = value; }
        }


        /// <summary>
        /// 返回时间间隔
        /// </summary>
        public int Interval
        {

            get 
            {
                if (cur_time != null && pre_time != null)
                {

                    TimeSpan ts1 = new TimeSpan(pre_time.Ticks);
                    TimeSpan ts2 = new TimeSpan(cur_time.Ticks);
                    TimeSpan ts = ts1.Subtract(ts2).Duration();

                    return ts.Minutes;
                }

                return 0;
            }
        }


 

        /// <summary>
        /// 设置ID
        /// </summary>
        /// <param name="date"></param>
        /// <param name="line"></param>
        /// <param name="tag"></param>
        /// <param name="seq"></param>
        /// <returns></returns>
        public bool SetTID(DateTime date,string line,int ems,int seq)
        {
            try
            {

                if (date == null)
                    return false;

                if (line == null)
                    return false;

                if (seq == null)
                    return false;

                this.seqid = date.ToString("yyyyMMddHHmmss") + line + String.Format("{0:D3}", ems) + String.Format("{0:D2}", seq);


                return true;

            }
            catch 
            {
            	throw;
            }
        
        }



        /// <summary>
        /// 解析行数据
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static ChangeTimeMDL ParseDataRow(DataRow row)
        {
            ChangeTimeMDL mdl = new ChangeTimeMDL();

            try
            {

                mdl.SEQID = Convert.ToString(row["SEQID"]);
                mdl.PLID = Convert.ToString(row["PLID"]);
                mdl.UNITID = Convert.ToString(row["UNITID"]);
                mdl.PER_PN = Convert.ToString(row["PER_PN"]);
                mdl.CUR_PN = Convert.ToString(row["CUR_PN"]);
                mdl.CUR_TIME = Convert.ToDateTime(row["CUR_TIME"]);
                mdl.PER_TIME = Convert.ToDateTime(row["PER_TIME"]);
                mdl.TIME_MIG = Convert.ToInt32(row["TIME_MIG"]);
                return mdl;

            }
            catch
            {

                throw;
            }
  
        }

    }
}
