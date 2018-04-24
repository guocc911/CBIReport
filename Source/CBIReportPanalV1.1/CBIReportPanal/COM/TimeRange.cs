using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace COMM
{
    public class TimeRange
    {
        private DateTime _startTime;

        private DateTime _endTime;

        private string _seq;


        public TimeRange()
        {
            _seq = string.Empty;
        }


        public TimeRange(DateTime start,DateTime end)
        {
            this._startTime=start;
            this._endTime=end;
        }





        /// <summary>
        /// 设置序号
        /// </summary>
        public string SEQ
        {
            get { return _seq; }
            set { _seq = value; }
        }



        /// <summary>
        /// 
        /// </summary>
        public DateTime StartTime
        {
            get { return _startTime; }

            set { _startTime = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime EndTime
        {
            get { return _endTime; }

            set { _endTime = value; }
        }


        public bool IsInFullRange(DateTime ftime1,DateTime ftime2)
        {

            bool ret = false;

            if (ftime1 >= _startTime && ftime1 < _endTime && ftime2 > _startTime && ftime2 <= _endTime)
                ret= true;


            return ret;

        }


        public bool IsInRange1(DateTime ftime1,DateTime ftime2)
        {
            bool ret = false;

            if (ftime1 > _startTime && ftime1 < _endTime)
                ret = true;

            if (ftime2 > _startTime && ftime2 < _endTime)
                ret = true;

            return ret;

        }

        public bool IsInRange2(DateTime ftime1)
        {
            bool ret = false;

            if (ftime1 >=_startTime && ftime1 < _endTime)
                ret = true;

            return ret;
        }


        public bool IsInRange(DateTime ftime1)
        {
            bool ret = false;

            if (ftime1 >= _startTime && ftime1 <= _endTime)
                ret = true;

            return ret;
        }


        public bool IsLessThan(DateTime ftime1)
        {
            bool ret = false;

            //if (_endTime <= ftime1)
            //    ret = true;

            if (DateTime.Compare(ftime1, _endTime) > 0 || DateTime.Compare(_endTime, ftime1) == 0)
                ret = true;

            return ret;
        }


        /// <summary>
        /// 相差的分钟数量
        /// </summary>
        /// <param name="dateBegin"></param>
        /// <param name="dateEnd"></param>
        /// <returns></returns>
        public static int ExecDateDiff(DateTime dateBegin, DateTime dateEnd)
        {
            TimeSpan ts1 = new TimeSpan(dateBegin.Ticks);
            TimeSpan ts2 = new TimeSpan(dateEnd.Ticks);
            TimeSpan ts3 = ts1.Subtract(ts2).Duration();
            //你想转的格式

            int minute =(int)Math.Round(ts3.TotalSeconds /(double )60,2);

            return minute;
        }


        public static int ExecDateDiffSecond(DateTime dateBegin, DateTime dateEnd)
        {
            TimeSpan ts1 = new TimeSpan(dateBegin.Ticks);
            TimeSpan ts2 = new TimeSpan(dateEnd.Ticks);
            TimeSpan ts3 = ts1.Subtract(ts2).Duration();
            //你想转的格式

            int minute = (int)Math.Round(ts3.TotalSeconds, 2);

            return minute;
        }

    }
}
