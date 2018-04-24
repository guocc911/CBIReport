using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace MDL
{
    public class AcqCountMDL
    {


        private int tid;

        private string tagName;

        private DateTime startTime;

        private DateTime endTime;

        private int currentCount;

        private int startCount;

        private string brakeid;

        private string remark;


        public int TID
        {
            get { return tid; }

            set { tid = value; }
        }

        public string TagName
        {
            get { return tagName; }

            set { tagName = value; }
        }

        public DateTime StartTime
        {
            get { return startTime; }

            set { startTime = value; }
        }

        public DateTime EndTime
        {
            get { return endTime; }

            set { endTime = value; }
        }

        public int  CurrentCount
        {
            get { return currentCount; }

            set { currentCount = value; }
        }

        public int StartCount
        {
            get { return startCount; }

            set { startCount = value; }
        }

        public string Remark
        {
            get { return remark; }

            set { remark = value; }
        }

        public void Prase(DataRow row)
        {
            tid = Convert.ToInt32(row["tid"]);
            tagName = Convert.ToString(row["tagName"]);
            startTime = Convert.ToDateTime(row["StartTime"]);
            endTime = Convert.ToDateTime(row["EndTime"]);
            currentCount = Convert.ToInt32(row["CurrentCount"]);
            startCount = Convert.ToInt32(row["StartCount"]);
            remark = Convert.ToString(row["Remark"]);
        }
    }
}
