using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COMM;

namespace MDL
{
    public class CTUnitMDL
    {

        private int ems;

        private string key;

        private string pn;

        private int count;

        private int seconds;

        private int op;

        private int ct;


        /// <summary>
        /// 关键字
        /// </summary>
        public string Key
        {

            get { return key; }
            set { key = value; }
        }

        /// <summary>
        /// 采集设备寄存器地址
        /// </summary>
        public int EMS
        {
            get { return ems; }
            set { ems = value; }
        }

        /// <summary>
        /// 产品编号
        /// </summary>
        public string PN
        {
            get { return pn; }
            set { pn = value; }
        }

        /// <summary>
        /// 产品生产生产人数
        /// </summary>
        public int OP
        {
            get { return op; }
            set { op = value; }
        }

        /// <summary>
        /// 单品生产时间
        /// </summary>
        public int CT
        {
            get { return ct; }
            set { ct = value; }
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



        public string GetOEE(int count,  DateTime startTime, DateTime endTime)
        {

            return CTUnitMDL.MathOEEToString(count, this.ct, startTime, endTime);

        }

        public string GetOEE(int count,int seconds)
        {

            return CTUnitMDL.MathOEEToString(count, this.ct, seconds);
        }

        public static double MathOEE(int count, int ct, DateTime startTime, DateTime endTime)
        {
            try
            {

              
                if (count <= 0)
                    return 0.0;

                double oee = 0.0;

                int second = TimeRange.ExecDateDiffSecond(startTime, endTime);

                oee = Math.Round((double)(count * ct) / (double)second, 2);

                if (oee < 0 || double.IsNaN(oee) || Double.IsInfinity(oee))
                    oee = 0.0;
               // oee = oee * 100;

                return oee;
       
            }
            catch
            {
                throw;

            }
        }


        public static string MathOEEToString(int count, int ct, int seconds)
        {
            try
            {

                if (count <= 0)
                    return "0%";

                double oee = 0.0;


                oee = Math.Round((double)(count * ct) / (double)seconds, 2);

                oee = oee * 100;

                if (oee < 0 || double.IsNaN(oee) || Double.IsInfinity(oee))
                    oee = 0.0;

                string ret = String.Format("{0:D2}%", (int)oee);

                return ret;

            }
            catch
            {
                throw;

            }
        }


        public static string MathTotalCount(List<CTUnitMDL> units)
        {
            if (units == null || units.Count <= 0)
                return "0";

  
            int count = 0;

            for (int i = 0; i < units.Count; i++)
            {
                count += units[i].COUNT ;
            }

            return count.ToString();
        }

        public static string MathTotalOEE(List<CTUnitMDL> units)
        {
            try
            {

                if (units==null||units.Count <= 0)
                    return "0%";

                int seconds=0;
                int count = 0;

                for (int i = 0; i < units.Count; i++)
                {
                    count += units[i].COUNT * units[i].CT;

                    seconds += units[i].SECONDS;

                }

                double oee = 0.0;



                oee = Math.Round((double)count/ (double)seconds, 2);

                
                oee = oee * 100;

                if (oee < 0 )
                    oee = 0;

                string ret = String.Format("{0:D2}%", (int)oee);

                return ret;

            }
            catch
            {
                throw;

            }
        }


        public static string MathTotalProductivity(List<CTUnitMDL> units)
        {
            try
            {

                if (units.Count <= 0)
                    return "0";

                double pt = 0.0;




                double hours = 0;
                int count = 0;

                for (int i = 0; i < units.Count; i++)
                {
                    count += units[i].COUNT;
                    double hour = Math.Round((double) units[i].SECONDS / (double)3600, 2);
                    hours += hour * units[i].OP;


                }


                pt = Math.Round((double)count / (double)hours, 1);


                if (pt < 0 || double.IsNaN(pt) || Double.IsInfinity(pt))
                    pt=0;
                // string ret = String.Format("{0:D2}", (int)pt);

                string ret = String.Format("{0:F1}", pt);
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
        /// <param name="count"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static string  MathOEEToString(int count,int ct,DateTime startTime,DateTime endTime)
        {
            try
            {

                if(count<=0)
                    return "0%";

                double oee = 0.0;

                int second = TimeRange.ExecDateDiffSecond(startTime, endTime);

                oee = Math.Round((double)(count * ct) / (double)second, 2);

                oee = oee * 100;

                if (oee < 0 || double.IsNaN(oee) || Double.IsInfinity(oee))
                    oee = 0;


                string ret = String.Format("{0:D2}%", (int)oee);


                return ret;

            }
            catch
            {
                throw;
            	
            }
        }


        public static string FormatOEE(double oee)
        {
            try
            {


                oee = oee * 100;

                string ret = String.Format("{0:D2}%", (int)oee);

                return ret;

            }
            catch
            {
                throw;

            }
        }



        /// <summary>
        /// 生产效率   //减去吃饭时间，不减去休息时间
        /// </summary>
        /// <param name="count"></param>
        /// <param name="op"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static string MathProductivityToString(int count, int op, DateTime startTime, DateTime endTime)
        {
            
               try
               {

                   if (count <= 0)
                       return "0";

                   double pt = 0.0;

                   //偏移时间
                   int second = TimeRange.ExecDateDiffSecond(startTime, endTime);

                   ///换算成小时
                   double hour = Math.Round((double)second / (double)3600,2);


                   pt = Math.Round((double)count  / (double)(hour*op), 1);

                 //  pt = pt * 100;

                  // string ret = String.Format("{0:D2}", (int)pt);
                   if (pt < 0 || double.IsNaN(pt) || Double.IsInfinity(pt))
                       pt = 0;

                   string ret = String.Format("{0:F1}", pt);
                   return ret;

               }
               catch
               {
                   throw;

               }
        }

        public static string MathProductivityToString(int count, int op, int seconds)
        {
            try
            {

                if (count <= 0)
                    return "0";

                double pt = 0.0;

                ///换算成小时
                double hour = Math.Round((double)seconds / (double)3600, 2);


                pt = Math.Round((double)count / (double)(hour * op), 1);

                //  pt = pt * 100;

                // string ret = String.Format("{0:D2}", (int)pt);
                if (pt < 0 || double.IsNaN(pt) || Double.IsInfinity(pt))
                    pt = 0;

                string ret = String.Format("{0:F1}", pt);
                return ret;

            }
            catch
            {
                throw;

            }
        }




        public static double MathProductivity(int count, int op, DateTime startTime, DateTime endTime)
        {

            try
            {

                if (count <= 0)
                    return 0.0;

                double pt = 0.0;

                //偏移时间
                int second = TimeRange.ExecDateDiffSecond(startTime, endTime);

                ///换算成小时
                double hour = Math.Round((double)second / (double)3600, 2);


                pt = Math.Round((double)count / (double)(hour * op), 2);

                if (pt < 0 || double.IsNaN(pt) || Double.IsInfinity(pt))
                    pt = 0;

                return pt;
            }
            catch
            {
                throw;

            }
        }




        public CTUnitMDL()
        {
             ems=0;
             pn="0";
             op = 0;
             ct=0;
        }
 
    }
}
