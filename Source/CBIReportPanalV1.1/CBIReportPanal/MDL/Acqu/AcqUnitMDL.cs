using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COMM;

namespace MDL
{

    /// <summary>
    /// 子采集项目
    /// </summary>
    public class SubUnit
    {

        private int seq;

        private string unitid;

        private string pn;

        private string code;

        private int count;

        private int seconds;

        private int op;


        public int Seq
        {
            get { return seq; }
            set { seq = value; }
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

        public string CODE
        {
            get { return code; }
            set { code = value; }
        }

        public int COUNT
        {
            get { return count; }
            set { count = value; }
        }


        public int SECONDS
        {
            get { return seconds; }
            set { seconds = value; }
        }


        public int OP
        {
            get { return op; }
            set { op = value; }
        }

    }


    public class PLDUnit
    {

        private double oee;

        private double pt;

        private double co;

        public double OEE
        {
            get { return oee; }
            set { oee = value; }
        }


        public double PT
        {
            get { return pt; }
            set { pt = value; }
        }

        public double CO
        {
            get { return co; }
            set { co = value; }
        }
    }

    /// <summary>
    ///  一个型号的数据集合或总的数据的采集集合
    /// </summary>
    public class AcqUnitMDL
    {


        private List<SubUnit> units;

        private string plindid;

        private string pncode;

        private int ems;

        private int actual;

        private string code;

        private string oee;

        private string pt;

        private string op;

        private int seconds;

        private string error;

        private string co;

        private string remark;

        private PLDUnit unit;

        private DateTime startTime;

        private DateTime endTime;

        private DateTime updateTime;



        public PLDUnit PLD
        {
            get { return unit; }

            set { unit = value; }
        }

        /// <summary>
        /// 产线ID
        /// </summary>
        public string PLINEID 
        {
            get { return plindid; }

            set { plindid = value; }
        }


        /// <summary>
        /// EMS地址
        /// </summary>
        public int EMS
        {
            get { return ems; }

            set { ems = value; }
        }

        /// <summary>
        /// 产品编号
        /// </summary>
        public string PNCODE
        {
            get { return pncode; }

            set { pncode = value; }
        }



        public string CODE
        {
            get { return code; }

            set { code = value; }
        }
        /// <summary>
        /// 换型时间
        /// </summary>
        public string C0
        {
            get { return co; }

            set { co = value; }
        }


        /// <summary>
        /// 实际生产数量
        /// </summary>
        public int ACUTAL
        {
            get {
               
                int count = 0;

                if (this.units != null)
                {


                    //计算生产数量
                    foreach (SubUnit unit in this.units)
                    {
                        count += unit.COUNT;
                    }

                    return count;
                }
                else
                    return count;
            }

            set
            {
                actual = value;
            }
        }

        public string ERROR
        {
            get { return error; }

            set { error = value; }
        }


        public string OP
        {
            get { return op; }

            set { op = value; }
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


        public DateTime UpDateTime
        {
            get { return updateTime; }

            set { updateTime = value; }
        }


        public int Seconds
        {
            get {

                seconds = 0;

                if (this.units != null)
                {


                    //计算生产数量
                    foreach (SubUnit unit in this.units)
                    {
                        seconds += unit.SECONDS;
                    }

                    return seconds;
                }
                else
                    return seconds;
                }

            set { seconds = value; }
        }



        public string REMARK
        {
            get { return remark; }

            set { remark = value; }
        }



        public AcqUnitMDL()
        {
            this.units=new List<SubUnit>();
            pncode = string.Empty;

            unit = new PLDUnit();
        }


        public void Clear()
        {
            if (this.units != null)
                this.units.Clear();

            this.units = null;
            this.units = new List<SubUnit>();

        }



        public void AddCO(int second)
        {
            double cotime=Math.Round((double)second/(double)3600,2);

            this.co = string.Format("{0}H", cotime);

        }


        public TimeRange GetTimeRange()
        {
            return new TimeRange(this.startTime,this.endTime);
        }


        public bool IsInAcqRange(DateTime start, DateTime end)
        {
            TimeRange rang=new TimeRange(this.startTime,this.endTime);

            if (rang.IsInFullRange(start, end))
                return true;

            return false;
        }




        public void AddProductItem(int seq, string unitid, string pn, int count,int seconds, int op,TimeRange range,DateTime upTime)
        {
            SubUnit unit = new SubUnit();
            unit.COUNT = count;
            unit.Seq = seq;
            unit.PN = pn;
            unit.OP = op;
            unit.UNITID = unitid;
            
            unit.SECONDS = seconds;
            this.units.Add(unit);
            pncode = pn;
            this.code = pncode;

            if (this.EndTime != null)
            {
                TimeSpan span =range.EndTime -  this.EndTime;
               
                if(span.TotalMilliseconds>1)
                    this.EndTime = range.EndTime;
            }
            else
            {
                  this.EndTime = range.EndTime;
            }
             

            this.StartTime = range.StartTime;

            if (this.UpDateTime != null)
            {
                TimeSpan span1 = upTime - this.UpDateTime;

                if (span1.TotalMilliseconds > 1)
                    this.UpDateTime = upTime;
            }
            else
            {

                this.UpDateTime = upTime;
            }
           // pncode += pn + "\r\n";

            if (pncode.Length >= 16)
                pncode = pncode.Substring(0, 16);


        }
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="pn">编号</param>
        /// <param name="ct"></param>
        public void AddProductItem(int seq,string unitid, string pn,int count,int op)
        {
            try
            {
                SubUnit unit = new SubUnit();
                unit.COUNT=count;
                unit.Seq=seq;
                unit.PN=pn;
                unit.OP=op;
                unit.UNITID=unitid;
                this.units.Add(unit);

                pncode += pn+"\r\n";

                if (pncode.Length >= 16)
                    pncode = pncode.Substring(0,16);

            }
            catch
            {
                throw;
            }

        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="pn">编号</param>
        /// <param name="ct"></param>
        public void AddProductItem(int seq, string unitid, string pn,string code, int count, int op)
        {
            try
            {
                SubUnit unit = new SubUnit();
                unit.COUNT = count;
                unit.Seq = seq;
                unit.PN = pn;
                unit.OP = op;
                unit.CODE = code;
                unit.UNITID = unitid;

              
                this.units.Add(unit);

                this.CODE += code + ",";

                pncode += pn + "\r\n";

                if (pncode.Length >= 16)
                    pncode = pncode.Substring(0, 16);

            }
            catch
            {
                throw;
            }

        }




        


        /// <summary>
        /// 获取OEE
        /// </summary>
        /// <param name="ct">单位时间的平均CT</param>
        /// <returns></returns>
        public string GetFormatOEE(int nCT)
        {
            string ret = null;

            try
            {
                 if(this.units==null||this.units.Count<=0)
                     return "0%";

                 int count = 0;

                  //计算生产数量
                 foreach (SubUnit unit in this.units)
                 {
                     count += unit.COUNT;             
                 }

                 //通过平均数量计算生产时间
                 ret = CTUnitMDL.MathOEEToString(count, nCT, this.startTime, this.endTime);

                 return ret;

            }
            catch
            {
                throw;
            }
        }

        public string GetOEEToString(int nCT)
        {
            string ret = null;

            try
            {
                if (this.units == null || this.units.Count <= 0)
                    return "0%";

                int count = 0;
                int total = 0;

                //计算生产数量
                foreach (SubUnit unit in this.units)
                {
                    count += unit.COUNT;
                
                    total += unit.SECONDS;
                    //加一个时间
                    total += nCT;
                }

          
                //通过平均数量计算生产时间
                ret = CTUnitMDL.MathOEEToString(count, nCT, total);

                return ret;

            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nCT"></param>
        /// <returns></returns>
        public double GetOEE(int nCT)
        {
            double ret = 0.0;

            try
            {
                 if(this.units==null||this.units.Count<=0)
                     return ret;

                 int count = 0;

                  //计算生产数量
                 foreach (SubUnit unit in this.units)
                 {
                     count += unit.COUNT;             
                 }

                 //通过平均数量计算生产时间
                 ret = CTUnitMDL.MathOEE(count, nCT, this.startTime, this.endTime);

                 return ret;

            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// 获取当前时段的生产效率
        /// </summary>
        /// <param name="op">平均OP</param>
        /// <returns></returns>
        public string GetFormatProductivty(int nOP)
        {
            string ret = null;

            try
            {
                if (this.units == null || this.units.Count <= 0)
                    return "0";

                int count = 0;
                int seconds = 0;

                //计算生产数量
                foreach (SubUnit unit in this.units)
                {
                    count += unit.COUNT;
                    seconds += unit.SECONDS;
                }

                //通过平均数量计算生产时间
                ret = CTUnitMDL.MathProductivityToString(count, nOP, seconds);

                return ret;

            }
            catch
            {
                throw;
            }
        }


        public double GetProductivty(int nOP)
        {
            double ret = 0.0;

            try
            {
                if (this.units == null || this.units.Count <= 0)
                    return ret;

                int count = 0;

                //计算生产数量
                foreach (SubUnit unit in this.units)
                {
                    count += unit.COUNT;
                }

                //通过平均数量计算生产时间
                ret = CTUnitMDL.MathProductivity(count, nOP, this.startTime, this.endTime);

                return ret;

            }
            catch
            {
                throw;
            }
        }

        
   
 
    }
}
