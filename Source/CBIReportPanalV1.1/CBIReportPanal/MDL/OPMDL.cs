using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COMM;
namespace MDL
{

    /// <summary>
    /// OP Model
    /// </summary>
    public class OPMDL
    {
        private string lineid;

        private int seq;

        private int op;

        private TimeRange range;

        /// <summary>
        /// 产线ID
        /// </summary>
        public string LINEID
        {
            get { return lineid; }

            set { lineid = value; }
        }

        /// <summary>
        /// 序列号
        /// </summary>
        public int SEQ
        {
            get { return seq; }

            set { seq = value; }
        }

        /// <summary>
        /// 产线人数
        /// </summary>
        public int OP
        {
            get { return op; }

            set { op = value; }

        }
        

        /// <summary>
        /// 时间范围
        /// </summary>
        public TimeRange IIME_RANGE
        {
             get { return range; }
     
            set { range = value; }
        }


        public OPMDL()
        {
            this.lineid = String.Empty;
            this.seq = 0;
            this.range = null;
        
        }




        public static List<OPMDL> AddOPInfo(List<OPMDL> oldOPS,OPMDL mdl)
        {
            try
            {

                List<OPMDL> opList =new List<OPMDL>();


                foreach(OPMDL item in oldOPS)
                {
                    opList.Add(item);
                }

                opList.Add(mdl);

                return opList;

            }
            catch
            {
                throw;
            }

        }


  
        //}

        /// <summary>
        /// 创建分割信息
        /// </summary>
        /// <param name="line"></param>
        /// <param name="startTime"></param>
        /// <param name="range"></param>
        /// <param name="opArray"></param>
        /// <returns></returns>
        public  static List<OPMDL>  BuildOPInfo(string line, DateTime startTime,
                                                    int range, string opArray)
        {
            try
            {
                List<OPMDL> opList = null;

                if (opArray == null)
                    return null;

                string[] opStrs=opArray.Split('-');

                if (opStrs==null || opStrs.Length<=0 )
                    return null;

                int[] items = new int[opStrs.Length];

                int op = 0;

                int seq = 0;

                DateTime beginTime = startTime;

                opList = new List<OPMDL>();
               
                foreach(string opItem in opStrs)
                {

                   Int32.TryParse(opItem, out op);

                   OPMDL mdl = new OPMDL();

                   TimeRange tRange = new TimeRange();
                   tRange.StartTime = beginTime;
                   //beginTime.AddHours(1);
                   tRange.EndTime = tRange.StartTime.AddHours(1);
                   beginTime = tRange.EndTime;

                   //build line  info
                   mdl.LINEID = line;
                   mdl.IIME_RANGE = tRange;
                   mdl.OP = op;
                   mdl.SEQ = seq;
                   ++seq ;

                   opList.Add(mdl);
                }


                return opList;
 
            }
            catch
            {
                throw;
            }

        }


        /// <summary>
        /// 创建OP列表字符串
        /// </summary>
        /// <param name="ops"></param>
        /// <returns></returns>
        public static string BuildOPString(List<OPMDL> ops)
        {
            try
            {
                string ret=String.Empty;

                if (ops == null || ops.Count <= 0)
                    return ret;


                for(int i=0; i<ops.Count; i++)
                {
                    if (i ==(ops.Count-1))
                       ret += ops[i].OP.ToString();
                    else
                        ret += ops[i].OP.ToString() + "-";
                }


                return ret;
            }
            catch
            {
                throw;
            }
        }



    }
}
