using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using COMM;

namespace MDL
{


    public class PlinePlanMDL
    {

        private string planid;

        private string lineid;

        private string name;

        private int op1;

        private int op1_t;

        private DateTime op1_begin;

        private int op1_range;

        private List<OPMDL> op1_item;

        private int op2;

        private int op2_t;

        private DateTime op2_begin;

        private int op2_range;

        private List<OPMDL> op2_item;

        private DateTime createtime;

        private string remark;

        public string PLANID
        {
            get { return planid; }
            set { planid = value; }
        }


        public string PLINE
        {
            get { return lineid; }
            set { lineid = value; }
        }


        public string NAME
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// op 人数
        /// </summary>
        public int OP1
        {
            get { return op1; }
            set { op1 = value; }
        }

        /// <summary>
        /// op 类型
        /// </summary>
        public int OP1_T
        {
            get { return op1_t; }
            set { op1_t = value; }
        }

        /// <summary>
        /// op 开始时间
        /// </summary>
        public DateTime OP1_BEGIN
        {
            get { return op1_begin; }
            set { op1_begin = value; }
        }

        /// <summary>
        /// 生产时间段 一般8小时
        /// </summary>
        public int OP1_RANGE
        {
            get { return op1_range; }
            set { op1_range = value; }
        }

        /// <summary>
        /// 设置的OP数据
        /// </summary>
        public List<OPMDL> OP1_ITEMS
        {
            get { return this.op1_item; }
            set { this.op1_item = value; }
        }

        /// <summary>
        /// op 结束时间
        /// </summary>
        public int OP2
        {
            get { return op2; }
            set { op2 = value; }
        }

        public int OP2_T
        {
            get { return op2_t; }
            set { op2_t = value; }
        }

        /// <summary>
        /// op 开始时间
        /// </summary>
        public DateTime OP2_BEGIN
        {
            get { return op2_begin; }
            set { op2_begin = value; }
        }

        /// <summary>
        /// 生产时间段 一般8小时
        /// </summary>
        public int OP2_RANGE
        {
            get { return op2_range; }
            set { op2_range = value; }
        }


        /// <summary>
        /// 设置数据
        /// </summary>
        public List<OPMDL> OP2_ITEMS
        {
            get { return this.op2_item; }
            set { this.op2_item = value; }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CREATE_TIME
        {
            get { return createtime; }
            set { createtime = value; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string REMARK
        {
            get { return remark; }
            set { remark = value; }
        }


        public TimeRange GetTimeRange(int type,DateTime curTime)
        {
            TimeRange range=new TimeRange();

            try
            {
                switch (type)
                {
                    case 1:
                      
                        range.StartTime = this.OP1_BEGIN;

                        foreach (OPMDL item in this.op1_item)
                        {
                            if (item.IIME_RANGE.IsInRange2(curTime))
                            {
                                range.EndTime = item.IIME_RANGE.EndTime;
                            }
                        }

                        break;
                    case 2:
                        range.StartTime = this.OP2_BEGIN;

                        foreach (OPMDL item in this.op2_item)
                        {
                            if (item.IIME_RANGE.IsInRange2(curTime))
                            {
                                range.EndTime = item.IIME_RANGE.EndTime;
                            }
                        }

                        break;
                    default:
                        break;

                }

                return range;

            }
            catch 
            {
            	throw;
            }

        }





        public TimeRange GetTimeRange(int type)
        {
            TimeRange range = new TimeRange();

            try
            {
                switch (type)
                {
                    case 1:

                        range.StartTime = this.OP1_BEGIN;
                        range.EndTime = range.StartTime.AddHours(this.OP1_RANGE);
                        break;
                    case 2:
                        range.StartTime = this.OP2_BEGIN;
                        range.EndTime = range.StartTime.AddHours(this.OP2_RANGE);
                        break;
                    default:
                        break;

                }

                return range;

            }
            catch
            {
                throw;
            }

        }



        public string GetOPItem()
        {
            string opStr = String.Empty;
            opStr += this.OP1.ToString() + "," + this.OP2.ToString();
            return opStr;
        }

        /// <summary>
        /// 检查结束时间大于起始时间
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="rang"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static bool CheckOPSet(DateTime startTime, int rang, DateTime endTime)
        {
            try
            {
                   DateTime t1 = startTime.AddHours(rang);
                   DateTime t2 = endTime;

                   if(DateTime.Compare(t1,t2)>=0)
                   {
                       return true;
                   }
                
                   return false;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 获取产线生产序号
        /// </summary>
        /// <param name="date"></param>
        /// <param name="line"></param>
        /// <param name="tag"></param>
        /// <param name="seq"></param>
        public bool SetPLANID(DateTime date, int line)
        {
            try
            {

                if (date == null)
                    return false;

                if (line<=0)
                    return false;


                this.PLANID = date.ToString("yyyyMMdd") + string.Format("{0:D2}", line);

                return true;

            }
            catch
            {
                throw;
            }

        }


        public void ReloadOPMDL(ref List<OPMDL> items, int startHour)
        {
          

            int curHour=items[0].IIME_RANGE.StartTime.Hour;

            int offset=curHour-startHour;

            if(offset>0)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    items[0].SEQ += offset;
                }
            }

    
        }


        public static PlinePlanMDL PraseDataRow(DataRow row)
        {
            PlinePlanMDL mdl = new PlinePlanMDL();

            try
            {

                mdl.PLANID = Convert.ToString(row["PLANID"]);
                mdl.PLINE = Convert.ToString(row["PLINE"]);
                mdl.NAME = Convert.ToString(row["NAME"]);
                mdl.OP1 = Convert.ToInt32(row["OP1"]);
                mdl.OP1_T = Convert.ToInt32(row["OP1_T"]);
                mdl.OP1_BEGIN = Convert.ToDateTime(row["OP1_BEGIN"]);
                mdl.OP1_RANGE = Convert.ToInt32(row["OP1_RANGE"]);
                
                ///初始化早班OP
                List<OPMDL>  op1Items=OPMDL.BuildOPInfo(mdl.PLANID, mdl.OP1_BEGIN, 
                                                        mdl.OP1_RANGE,Convert.ToString(row["OP1_ITEMS"]));
                mdl.OP1_ITEMS = op1Items;

                mdl.OP2 = Convert.ToInt32(row["OP2"]);
                mdl.OP2_T = Convert.ToInt32(row["OP2_T"]);
                mdl.OP2_BEGIN = Convert.ToDateTime(row["OP2_BEGIN"]);
                mdl.OP2_RANGE = Convert.ToInt32(row["OP2_RANGE"]);

                ///初始化晚班OP
                List<OPMDL> op2Items = OPMDL.BuildOPInfo(mdl.PLANID, mdl.OP2_BEGIN,
                                                         mdl.OP2_RANGE, Convert.ToString(row["OP2_ITEMS"]));
                mdl.OP2_ITEMS = op2Items;

                mdl.CREATE_TIME = Convert.ToDateTime(row["CREATE_TIME"]);
                mdl.REMARK = Convert.ToString(row["REMARK"]);
                return mdl;
            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// 初始化默认计划
        /// </summary>
        /// <param name="names"></param>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static List<PlinePlanMDL> InitialPlans(string[]  names,DateTime datetime)
        {
            List<PlinePlanMDL> list = new List<PlinePlanMDL>();
            
            try
            {
                DateTime startTime=new DateTime();

                
                for (int i = 0; i < names.Length; i++)
                {
                    PlinePlanMDL mdl = new PlinePlanMDL();
                    mdl.SetPLANID(datetime, i+1);
                    
                    mdl.name =  "LINE "+names[i];
                    mdl.PLINE = (i + 1).ToString();
                    mdl.OP1 = 10;
                    startTime = new DateTime(DateTime.Now.Year,
                                             DateTime.Now.Month,
                                             DateTime.Now.Day, 8, 30, 0);

                    mdl.OP1_BEGIN = startTime;
                    mdl.OP1_RANGE = 12;
                    mdl.OP1_T = 1;
                    mdl.OP2 = 10;
                    mdl.OP2_BEGIN = startTime.AddHours(8);
                    mdl.OP2_RANGE = 12;
                    mdl.OP2_T = 2;
                    mdl.CREATE_TIME = DateTime.Now;
                    mdl.REMARK = string.Empty;

                    list.Add(mdl);

                    System.Threading.Thread.Sleep(100);
                }

                    return list;
            }
            catch 
            {
                throw;
            }
              
        }



        /// <summary>
        /// 初始化默认的产线计划
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static PlinePlanMDL BuildDefualtPlan(int id,DateTime time)
        {
            try
            {

                XmlHelper helper = new XmlHelper("App.xml");
                string opsStr=helper.SelectValue("/Root/APP/OP");
                string rangeStr = helper.SelectValue("/Root/APP/TempRange");
                string beginTimeStr = helper.SelectValue("/Root/APP/TempDateTime");

                PlinePlanMDL mdl = new PlinePlanMDL();
                mdl.SetPLANID(time, id);

                mdl.name = "LINE" + id.ToString();
                mdl.PLINE = id.ToString();

                string[] opItems = opsStr.Split(',');
                string[] beginDate=beginTimeStr.Split(':');


                int op = 21;
                int startHour = 8;
                int startMinute = 30;
                int range = 10;

                Int32.TryParse(opItems[0], out op);
                Int32.TryParse(beginDate[0], out startHour);
                Int32.TryParse(beginDate[1], out startMinute);

                //早班OP
                mdl.OP1 = op;


                time = new DateTime(DateTime.Now.Year,
                                    DateTime.Now.Month,
                                    DateTime.Now.Day, startHour, startMinute, 0);

                mdl.OP1_BEGIN = time;
                mdl.OP1_RANGE = range;
                mdl.OP1_T = 1;

                string arrayOP = string.Empty;

                for (int i = 0; i < mdl.OP1_RANGE; i++)
                {
                    if (i == (mdl.OP1_RANGE - 1))
                        arrayOP += mdl.OP1.ToString();
                    else
                        arrayOP += mdl.OP1.ToString() + "-";
                }

                mdl.OP1_ITEMS = OPMDL.BuildOPInfo(mdl.PLINE, time, mdl.OP1_RANGE, arrayOP);



                Int32.TryParse(opItems[1], out op);
                //Int32.TryParse(beginDate[1], out startHour);
                //Int32.TryParse(beginDate[2], out startMinute);

                //晚班OP
                mdl.OP2 = op;
                mdl.OP2_BEGIN = time.AddHours(range);
                mdl.OP2_RANGE = 5;
                mdl.OP2_T = 2;

                arrayOP = string.Empty;

                for (int i = 0; i < mdl.OP2_RANGE; i++)
                {
                    if (i == (mdl.OP2_RANGE - 1))
                        arrayOP += mdl.OP2.ToString();
                    else
                        arrayOP += mdl.OP2.ToString() + "-";
                }

                mdl.OP2_ITEMS = OPMDL.BuildOPInfo(mdl.PLINE, time, mdl.OP2_RANGE, arrayOP);

                mdl.CREATE_TIME = DateTime.Now;
                mdl.REMARK = string.Empty;

                return mdl;


            }
            catch
            {
                throw;
            }

        }


        /// <summary>
        /// 重新加载计划
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public static PlinePlanMDL ReLoadPlanMDL(PlinePlanMDL mdl)
        {
            try
            {



                PlinePlanMDL newPline = new PlinePlanMDL();
                //mdl.SetPLANID(time, id);

                newPline.name = mdl.NAME;
                newPline.PLINE = mdl.PLINE;

                //早班OP
                newPline.OP1 = mdl.OP1;
                newPline.OP1_BEGIN = mdl.OP1_BEGIN;
                newPline.OP1_RANGE = mdl.OP1_RANGE;
                newPline.OP1_T = mdl.OP1_T;

                string arrayOP = string.Empty;

                for (int i = 0; i < mdl.OP1_RANGE; i++)
                {
                    if (i == (mdl.OP1_RANGE - 1))
                    { 
                        arrayOP += mdl.OP1.ToString(); 
                    }
                    else
                    {
                        arrayOP += mdl.OP1.ToString() + "-";
                    }
                }

                mdl.OP1_ITEMS = OPMDL.BuildOPInfo(mdl.PLINE, newPline.OP1_BEGIN, mdl.OP1_RANGE, arrayOP);



                newPline.OP2 = mdl.OP2;
                newPline.OP2_BEGIN = mdl.OP2_BEGIN;
                newPline.OP2_RANGE = mdl.OP2_RANGE;
                newPline.OP2_T = mdl.OP2_T;

                arrayOP = string.Empty;

                for (int i = 0; i < mdl.OP2_RANGE; i++)
                {
                    if (i == (mdl.OP2_RANGE - 1))
                        arrayOP += mdl.OP2.ToString();
                    else
                        arrayOP += mdl.OP2.ToString() + "-";
                }

                mdl.OP2_ITEMS = OPMDL.BuildOPInfo(mdl.PLINE, newPline.OP2_BEGIN, mdl.OP2_RANGE, arrayOP);

                mdl.CREATE_TIME = DateTime.Now;
                mdl.REMARK = string.Empty;

                return mdl;


            }
            catch
            {
                throw;
            }

        }


        /// <summary>
        /// 构造计划
        /// </summary>
        /// <param name="id"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static PlinePlanMDL BuildedPlan(int id,DateTime time)
        {
            try
            {

                PlinePlanMDL mdl = new PlinePlanMDL();
                mdl.SetPLANID(time, id);

                mdl.name = "LINE" +id.ToString();
                mdl.PLINE = id.ToString();
                //早班OP
                mdl.OP1 = 10;
                time = new DateTime(DateTime.Now.Year,
                                    DateTime.Now.Month,
                                    DateTime.Now.Day, 8, 30, 0);

                mdl.OP1_BEGIN = time;
                mdl.OP1_RANGE = 10;
                mdl.OP1_T = 1;

                string arrayOP=string.Empty;

                for(int i=0;i<mdl.OP1_RANGE;i++)
                {
                    if(i==(mdl.OP1_RANGE-1))
                      arrayOP+= mdl.OP1.ToString();
                    else
                      arrayOP+= mdl.OP1.ToString()+"-";
                }

                mdl.OP1_ITEMS = OPMDL.BuildOPInfo(mdl.PLINE, time, mdl.OP1_RANGE, arrayOP);

                //晚班OP
                mdl.OP2 = 10;
                mdl.OP2_BEGIN = time.AddHours(8);
                mdl.OP2_RANGE = 5;
                mdl.OP2_T = 2;

                arrayOP = string.Empty;

                for (int i = 0; i < mdl.OP2_RANGE; i++)
                {
                    if (i == (mdl.OP2_RANGE - 1))
                        arrayOP += mdl.OP2.ToString();
                    else
                        arrayOP += mdl.OP2.ToString() + "-";
                }

                mdl.OP2_ITEMS = OPMDL.BuildOPInfo(mdl.PLINE, time, mdl.OP2_RANGE, arrayOP);

                mdl.CREATE_TIME = DateTime.Now;
                mdl.REMARK = string.Empty;

                return mdl;


            }
            catch 
            {
                throw;
            }

        }
    }
}
