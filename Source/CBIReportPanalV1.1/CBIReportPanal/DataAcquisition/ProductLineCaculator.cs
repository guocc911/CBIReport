using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COMM;
//using SQLiteDAL;
using DAL;
using MDL;

namespace DataGather
{
    public enum GroupType
    {
        MorningShift=0,
        nightShirt=1
    }


    /// <summary>
    /// 产线数量单元
    /// </summary>
    public class PDNumberUnit
    {
        /// <summary>
        /// 产出的数量
        /// </summary>
        public int dataCount;


        /// <summary>
        /// 计算单元的序号
        /// </summary>
        public string TagName;


        /// <summary>
        /// 生产产量
        /// </summary>
        public GroupType groupType;

        /// <summary>
        /// 开始时间
        /// </summary>
        public TimeRange rang;






        /// <summary>
        /// 
        /// </summary>
        public PDNumberUnit()
        {
            dataCount = 0;
            groupType = GroupType.MorningShift;
            rang = new TimeRange();
        }


        public string GetTagIDAddRange(string strLineID, int range)
        {
            try
            {
                string strid = string.Empty;

                string tag = string.Format("{0:D2}", Convert.ToInt32(this.TagName) + range);

                strid = String.Format("{0}{1}{2:D2}", this.rang.StartTime.ToString("yyyyMMdd"), strLineID, tag);

                return strid;
            }
            catch
            {
                throw;
            }
        }

        public string GetTagID(string strLineID)
        {

            try
            {
                string strid = string.Empty;

                strid = String.Format("{0}{1}{2:D2}", this.rang.StartTime.ToString("yyyyMMdd"), strLineID, this.TagName);

                return strid;
            }
            catch 
            {
                throw;
            }
        }


        //public static string GetTagID(string strLineID,string tag)
        //{
        //    try
        //    {
        //        string strid = string.Empty;

        //        strid = String.Format("{0}{1}{2:D2}", this.rang.StartTime.ToString("yyyyMMdd"), strLineID, this.TagName);

        //        return strid;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
    }



    /// <summary>
    /// PLC采集单元
    /// </summary>
    public class EMSUnit
    {
        private int ems;

        private DateTime setTime;

        public int EMS
        {
            get { return ems; }
            set { ems = value; }
        }

        public DateTime SetTime
        {
            get { return setTime; }
            set { setTime = value; }
        }

        public EMSUnit(int nEMS, DateTime tSetTime)
        {
            this.ems = nEMS;
            this.setTime = tSetTime;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public bool Equals(EMSUnit unit)
        {
            try
            {
                if (unit == null)
                    return false;

                if (unit.EMS == this.ems)
                    return true;

                return false;
            }
            catch 
            {
                throw;
            }
        }
    }
    /// <summary>
    /// 产线计算器
    /// </summary>
    public class ProductLineCaculator
    {

        //起始时间
        public DateTime startTime;

        public int Hour;

        public int Minute;

        public int Second;

        public int Range;

        /// <summary>
        /// 当前的EMC地址
        /// </summary>
        public EMSUnit ems;

        //起始时间的数量
        public int startCount=0;

        //当前采集的数量  wancheng
        public int curCount;

        /// <summary>
        /// 当前的计划
        /// </summary>
        public PlinePlanMDL curPlan=null; 

        //产出的数量
        private  List<PDNumberUnit> lists = null;

        public List<PDNumberUnit> PDActualNumberList
        {
            get
            {
                return lists;
            }
        }



        public ProductLineCaculator(string lineID)
        {
            //this.Hour = 7;
            //this.Minute = 30;
            //this.Second = 0;
            this.Hour = 0;
            this.Minute = 30;
            this.Second = 0;
            //
            // this.Range = 12;
            //  this.Range = 17;
            this.Range = 24;
            ///加载当天默认计划
            LoadSystemDefualtPlan(lineID);

            InitailPlineUnits();
            // Initial();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public ProductLineCaculator()
        {
            //this.Hour = 7;
            //this.Minute = 30;
            //this.Second = 0;
            this.Hour = 0;
            this.Minute = 30;
            this.Second = 0;
            //
           // this.Range = 12;
          //  this.Range = 17;
            this.Range = 24;
            ///加载当天默认计划
            LoadSystemDefualtPlan();

            InitailPlineUnits();
           // Initial();
         
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="nHour"></param>
        /// <param name="nMinute"></param>
        /// <param name="nSecond"></param>
        public ProductLineCaculator(int nHour, int nMinute, int nSecond,int range)
        {
            ///小时分钟
            this.Hour = nHour;
            this.Minute = nMinute;
            this.Second = nSecond;
            this.Range = range;
            //初始化配置数据
            //Initial();

            //if (LoadSystemDefualtPlan())
            //{
            //    InitailPlineUnits();
            //}
   

        }

        private void ReloadPlan()
        {
            if (LoadSystemDefualtPlan())
            {
                InitailPlineUnits();
            }
        }




        public void ReloadPlanUnits()
        {
            try
            {
           
                startTime = new DateTime(DateTime.Now.Year,
                                         DateTime.Now.Month,
                                         DateTime.Now.Day, Hour, Minute, Second);

                CLog.WriteSysLog(startTime.ToLongTimeString());

                DateTime timeEnd = startTime;
                int hoursToAdd = 1;
                int minuteToAdd = 60;

                lists = new List<PDNumberUnit>();

                //添加采集计算单元和范围 共计24个小时
                for (int i = 0; i < this.Range; i++)
                {
                   

                    timeEnd = startTime.AddMinutes(minuteToAdd);

                    PDNumberUnit unit = new PDNumberUnit();
                    unit.dataCount = 0;
                    unit.TagName = String.Format("{0:D2}", i);
                    unit.rang.StartTime = startTime;
                    unit.rang.EndTime = timeEnd;
                    //  unit.rang.SEQ = i;
                    lists.Add(unit);

                    startTime = startTime.AddHours(hoursToAdd);

                }

        
            }
            catch 
            {
                throw;
            }

    
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool InitailPlineUnits()
        {
            try
            {

                if (curPlan == null)
                       return false;

                
                if (curPlan.CREATE_TIME!=null)
                {
                       
                       //string strDataTime=String.Format("{0}-{1}-{2} 23:59:59",curPlan.CREATE_TIME.Year,
                       //                                                        curPlan.CREATE_TIME.Month,
                       //                                                        curPlan.CREATE_TIME.Day);

                       //DateTime loadDate=Convert.ToDateTime(strDataTime);

                       /////超过加载时间后
                       //if (DateTime.Compare(DateTime.Now, loadDate)>0)
                       //{

                           startTime = new DateTime(DateTime.Now.Year,
                                                    DateTime.Now.Month,
                                                    DateTime.Now.Day, Hour, Minute, Second);

                           CLog.WriteSysLog(startTime.ToLongTimeString());

                           DateTime timeEnd = startTime;
                           int hoursToAdd = 1;
                           int minuteToAdd = 60;

                           lists = new List<PDNumberUnit>();

                           //添加采集计算单元和范围 共计24个小时
                           for (int i = 0; i < this.Range; i++)
                           {
                             // startTime = startTime.AddHours(hoursToAdd);

                               timeEnd = startTime.AddMinutes(minuteToAdd);

                               PDNumberUnit unit = new PDNumberUnit();
                               unit.dataCount = 0;
                               unit.TagName = String.Format("{0:D2}", i);
                               unit.rang.StartTime = startTime;
                               unit.rang.EndTime = timeEnd;
                               //  unit.rang.SEQ = i;
                               lists.Add(unit);
                               startTime = startTime.AddHours(hoursToAdd);

                           }

                           return true;

                    //   }

                    

                }

 
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message.ToString());
            }

            return false;
        }

        /// <summary>
        /// 重新加载新的产线单元的计数区间
        /// </summary>
        /// <returns></returns>
        public bool Initial()
        {
            try
            {
                startTime = new DateTime(DateTime.Now.Year,
                                         DateTime.Now.Month,
                                         DateTime.Now.Day, Hour, Minute, Second);

                CLog.WriteSysLog(startTime.ToLongTimeString());

                DateTime timeEnd = startTime;
                int hoursToAdd = 1;
                int minuteToAdd = 60;

                lists = new List<PDNumberUnit>();

                //添加采集计算单元和范围 共计12个小时
                for (int i = 0; i < Range; i++)
                {
                    startTime = startTime.AddHours(hoursToAdd);

                    timeEnd   = startTime.AddMinutes(minuteToAdd);

                    PDNumberUnit unit = new PDNumberUnit();
                    unit.dataCount=0;
                    unit.TagName = String.Format("{0:D2}", i);
                    unit.rang.StartTime = startTime;
                    unit.rang.EndTime = timeEnd;
                  //  unit.rang.SEQ = i;
                    lists.Add(unit);

                }

                return true;
            }
            catch(Exception ex)
            {
                  CLog.WriteErrLog(ex.Message.ToString());
            }

            return false;

        }


         public bool LoadSystemDefualtPlan(string lineID)
        {
            try
            {

                //  List<PlinePlanMDL> lists = PlinePlanMDL.InitialPlans(BaseVariable.LineNames, DateTime.Now);

                int linid = Convert.ToInt32(lineID);

                PlinePlanMDL mdl = PlinePlanMDL.BuildDefualtPlan(linid, DateTime.Now);

                PlinePlanDAL dal = new PlinePlanDAL();

                if (dal.PlanExists(mdl.PLANID) <= 0)
                {
                    if (dal.AddPlinePlan(mdl) > 0)
                    {

                        this.curPlan = mdl;
                        return true;
                    }
                }
                else
                {

                    curPlan = dal.GetPlanInfo(mdl.PLANID);

                    if (curPlan != null)
                    {

                        return true;
                    }

                }

                return false;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 加载默认计划
        /// </summary>
        /// <returns></returns>
        public bool  LoadSystemDefualtPlan()
        {
            try
            {

              //  List<PlinePlanMDL> lists = PlinePlanMDL.InitialPlans(BaseVariable.LineNames, DateTime.Now);

                int linid = Convert.ToInt32(BaseVariable.LineID);

                PlinePlanMDL mdl = PlinePlanMDL.BuildDefualtPlan(linid,DateTime.Now);

                PlinePlanDAL dal = new PlinePlanDAL();

                if (dal.PlanExists(mdl.PLANID) <= 0)
                {
                    if (dal.AddPlinePlan(mdl)>0)
                    {

                        this.curPlan = mdl;
                        return true;
                    }
                }
                else
                {

                    curPlan = dal.GetPlanInfo(mdl.PLANID);

                    if(curPlan!=null)
                    {

                        return true;
                    }

                }

                return false;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 加载模板计划
        /// </summary>
        public void LoadTempPlan()
        {
            try
            {

              List<PlinePlanMDL>  lists= PlinePlanMDL.InitialPlans(BaseVariable.LineNames,DateTime.Now);


              PlinePlanDAL dal = new PlinePlanDAL();

              foreach (PlinePlanMDL mdl in lists)
              {
                  if (dal.PlanExists(mdl.PLANID) <= 0)
                  {
                      dal.AddPlinePlan(mdl);
                  }
              }

            }
            catch 
            {
                throw;
            }
        }
       
        
        /// <summary>
        /// 重新加载数据
        /// </summary>
        public void ReLoad()
        {
            try
            {
    
                 startCount = 0;
                 curCount=0;

                if(lists!=null)
                   lists.Clear();

                // Initial();
                 InitailPlineUnits();
                /// LoadTempPlan();
                /// 
                //new system plan
                 LoadSystemDefualtPlan();
            }
            catch(Exception ex)
            {
                  CLog.WriteErrLog(ex.Message.ToString());
            }

        }

        public void ReLoad(string plineID)
        {
            try
            {

                startCount = 0;
                curCount = 0;

                if (lists != null)
                    lists.Clear();

                // Initial();
                InitailPlineUnits();
                /// LoadTempPlan();
                /// 
                //new system plan
                LoadSystemDefualtPlan(plineID);
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message.ToString());
            }
        }

      

        /// <summary>
        /// 获取当前产量 一般个时钟后期定义一次
        /// </summary>
        /// <param name="curUnit">当前数据量</param>
        /// <returns></returns>
        //public PDNumberUnit GetCurrentCount(int curUnit,DateTime acqTime)
        //{
        //    try
        //    {
                
        //        PDNumberUnit unit = new PDNumberUnit();

        //        CheckReload(acqTime);

        //        int currentcount = GetTimeRangCount(acqTime);

        //        //if (startCount != currentcount && startCount < currentcount)
        //        //    startCount = currentcount;

        //        ///当前采集数量的减去已采集的数量
        //        unit.dataCount = curUnit - startCount;

        //        int index = AddProductList(unit, acqTime);

        //        if (index > 0)
        //            return lists[index];
        //        else
        //            return null;
        //        //unit.StartDataTime = startTime;
        //        //unit.EndDataTime = endTime;

              
        //    }
        //    catch (Exception ex)
        //    {
        //        CLog.WriteErrLog(ex.Message.ToString());
        //    }

        //    return null;
        //}





        /// <summary>
        /// 获取在当前生产区间范围的采集信息
        /// </summary>
        /// <param name="PDUnit"></param>
        private AcqCountMDL GetAcqInfo(AcqCountMDL PDUnit, DateTime acqTime)
        {

            AcqCountMDL acqCount = new AcqCountMDL();

            try
            {


                CLog.WriteStationLog("ST400", lists.Count.ToString());

                for (int i = 0; i < lists.Count; i++)
                {
                    //判断在时间范围内
                    if (lists[i].rang.IsInRange(acqTime))
                    {

                        acqCount.TID = i;
                        acqCount.TagName = i.ToString();
                        acqCount.StartTime = lists[i].rang.StartTime;
                        acqCount.EndTime = lists[i].rang.EndTime;
                        acqCount.CurrentCount = PDUnit.CurrentCount;

                        CLog.WriteStationLog("ST400", acqCount.CurrentCount.ToString() + acqCount.StartTime.ToLongDateString());
                        return acqCount;
                    }
                }

                return null;

            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message.ToString());
            }
            return null;

        }
       

        /// <summary>
        /// 添加到产线实际生产列表
        /// </summary>
        /// <param name="PDUnit"></param>
        private int AddProductList(PDNumberUnit PDUnit,DateTime acqTime)
        {
            try
            {
                
                for (int i=0;i<lists.Count;i++ )
                {
                        //判断在时间范围内
                        if (lists[i].rang.IsInRange(acqTime))
                        {
                            lists[i].dataCount = PDUnit.dataCount;
                           
                            return i;
                        }
                }

                return -1;

            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message.ToString());
            }
            return -1;

        }



        /// <summary>
        /// 检查是否需要重新加载数据   每天检查一次
        /// </summary>
        public void CheckReload(DateTime curTime,EMSUnit unit )
        {

            if (this.lists == null || this.lists.Count<1)
                return;


            //采集时间是否大于计算列表的启动时间
            //int days = (curTime - this.lists[0].rang.StartTime).Days;//天数差


            TimeSpan ts1 = new TimeSpan(curTime.Ticks);

            TimeSpan ts2 = new TimeSpan(this.lists[0].rang.StartTime.Ticks);

            TimeSpan ts = ts1.Subtract(ts2).Duration();


            ///满足24小时时间
            if (ts.Days >= 1)
            {
                this.ReLoad();
                this.ems = unit;
            }

   

        }



        /// <summary>
        /// 获取当前范围计算总量
        /// </summary>
        /// <returns></returns>
        private int GetTimeRangCount(DateTime acqTime)
        {

            int count = 0;

            if (lists == null || lists.Count <= 0)
                return 0;

            for (int i = 0; i < lists.Count; i++)
            {
                //判断在时间范围内
                if (lists[i].rang.IsInRange(acqTime))
                {
                    count += lists[i].dataCount;
                }
            }

            return count;
            
        }






        private AcqLineItemMDL GetLastUnit(AcqLineItemMDL mdl)
        {
            AcqLineItemMDL retMdl = null;

            try
            {
                AcqLineDAL dal = new AcqLineDAL();

                retMdl = dal.GetAcqUnit(mdl.PLID, mdl.UNITID, mdl.EMS.ToString());

                return retMdl;
            }
            catch 
            {
                throw;
            }


        }

        /// <summary>
        /// 采集单元范围内的产线数据
        /// </summary>
        /// <param name="mdl"></param>
        /// <param name="count"></param>
        private int  GetLastRangCount(AcqLineCountMDL mdl)
        //private int GetLastRangCount(AcqLineItemMDL mdl)
        {

            int precount=0;

            try
            {
                
                //采集列表的索引号
                //int index = Convert.ToInt32(mdl.TGNMAE);
               
                AcqLineDAL dal=new AcqLineDAL();
                
                //获取产品编号的历史的计数
                precount = dal.GetAcqUnitCount(mdl.PLID,mdl.UNITID,mdl.PN);


                return precount;
            }
            catch
            {
                throw;
            }

        }



        private int GetStartCount(AcqLineCountMDL mdl)
        {

            int precount = 0;

            try
            {

                //采集列表的索引号
                //int index = Convert.ToInt32(mdl.TGNMAE);

                AcqLineDAL dal = new AcqLineDAL();

                //获取产品编号的历史的计数
              //  precount = dal.GetAcqLineMDLPerCount(mdl.PLID, mdl.UNITID, mdl.PN);


                return precount;
            }
            catch
            {
                throw;
            }

        }

         /// <summary>
         /// 插入当前采集数据
         /// </summary>
         /// <param name="acqTime"></param>
         /// <param name="count"></param>
        //private void GetTimeRangCount(DateTime acqTime, int count, out AcqLineCountMDL acqMDL)
        //{

        //    acqMDL=null;

        //    try
        //    {
        //        if (lists == null || lists.Count <= 0)
        //            return;
            

        //         for (int i = 0; i < lists.Count; i++)
        //        {
        //            //判断是否在排班范围内
        //            if (lists[i].rang.IsInRange(acqTime))
        //            {
        //                //设置采集总量
        //                lists[i].dataCount=count;

        //                AcqCountListSQLiteDAL countListDal = new AcqCountListSQLiteDAL();

        //                //获取当前范围的起始采集数量
        //                int startRangeCount= countListDal.GetRangeItemCount(i.ToString());

        //                if (startRangeCount <= 0)
        //                    countListDal.UpdateItemStartCountValue(lists[i].dataCount, i.ToString());
                  

        //                acqMDL = new AcqCountMDL();
        //                //当前采集总数减去

        //                acqMDL.CurrentCount = count - startRangeCount;
        //                acqMDL.TagName = i.ToString();
        //                acqMDL.StartTime = lists[i].rang.StartTime;
        //                acqMDL.EndTime = lists[i].rang.EndTime;

        //               // CLog.WriteStationLog("ST400", "设置总量" + count.ToString());


        //               // break;

        //            }
        //         }


        //    }
        //    catch(Exception ex)
        //    {
        //        CLog.WriteErrLog(ex.ToString());

        //    }

        //}


        /// <summary>
        /// 获取采集周期的时间范围
        /// </summary>
        /// <param name="acqTime"></param>
        /// <returns></returns>
        public TimeRange GetTimeRangByAcqTime(DateTime acqTime)
        {
            TimeRange range = null;

            try
            {
                if (lists == null || lists.Count <= 0)
                    return null;

                for (int i = 0; i < lists.Count; i++)
                {
                    //判断是否在排班范围内
                    if (lists[i].rang.IsInRange2(acqTime))
                    {
                        range = new TimeRange();
                        //时间和区间序号
                        range.StartTime = lists[i].rang.StartTime;
                        range.EndTime = lists[i].rang.EndTime;
                        //序列区间
                        range.SEQ = String.Format("{0:D2}",i);

                        break;
                    }
                }

                //if (range == null)
                //{
                //    range = new TimeRange();
                //    //时间和区间序号
                //    range.StartTime = lists[lists.Count-1].rang.StartTime;
                //    range.EndTime = lists[lists.Count - 1].rang.EndTime;
                //    //序列区间
                //    range.SEQ = String.Format("{0:D2}", lists.Count - 1);
                //}

                return range;

            }
            catch 
            {
                throw;
            }
        
        }


        public string GetUNITID(string lineid,DateTime acqTime)
        {
            try
            {
                
                if (lists == null || lists.Count <= 0)
                    return null;

                string unitid = lineid;

                for (int i = 0; i < lists.Count; i++)
                {
                    //判断是否在排班范围内
                    if (lists[i].rang.IsInRange2(acqTime))  
                    {
                        //ewd ||
                        //序列区间
                        unitid+=String.Format("{0:D2}", i);

                        break;
                    }
                }
                if (unitid == lineid)
                    unitid += String.Format("{0:D2}", lists.Count-1);

                return unitid;

            }
            catch
            {
                throw;
            }
        }


        public string GetUNITID(string lineid, int range,DateTime acqTime)
        {
            try
            {

                if (lists == null || lists.Count <= 0)
                    return null;

                string unitid = lineid;

                for (int i = 0; i < lists.Count; i++)
                {
                    //判断是否在排班范围内
                    if (lists[i].rang.IsInRange2(acqTime))
                    {
                        //ewd ||
                        //序列区间
                        unitid += String.Format("{0:D2}", i+range);

                        break;
                    }
                }


                if (unitid == lineid)
                    return string.Empty;

                return unitid;

            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 判断产品是否换型
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public bool IsChangeProduct(EMSUnit unit)
        {

            if (this.ems == null || this.ems.EMS == 0)
            {
                this.ems = unit;
                return false;
            }

            if (!this.ems.Equals(unit))
            {
                return true;
            }

            return false;
        }

        public bool IsChangedEMS(int eCode)
        {
            if (eCode != this.ems.EMS)
                return true;

            return false;

        }


        public void LoadEMS(EMSUnit unit)
        {
            this.ems = new EMSUnit(unit.EMS, unit.SetTime);
        }

        public void LoadEMSTime(DateTime updateTime)
        {
            this.ems.SetTime = updateTime;
        }


        /// <summary>
        /// 处理换型添加记录
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public int ProcessAcqLineData(string lineID,string unitid,EMSUnit unit)
        {
            int ret = 0;

            try
            {
                ChangeTimeDAL dal = new ChangeTimeDAL();
                ChangeTimeMDL mdl = new ChangeTimeMDL();

                unit.SetTime = DateTime.Now;

                mdl.SetTID(unit.SetTime, lineID, unit.EMS, 0);
                mdl.PLID = lineID;
                mdl.UNITID = unitid;
                mdl.PER_PN = this.ems.EMS.ToString();
                mdl.CUR_PN = unit.EMS.ToString();
                mdl.TIME_MIG = TimeRange.ExecDateDiffSecond(this.ems.SetTime, unit.SetTime);
                mdl.PER_TIME = this.ems.SetTime;
                mdl.CUR_TIME = DateTime.Now;
            

                int count = dal.IsUionCOUint(unitid, lineID);

                if (count <= 0)
                {
                    mdl.SetTID(unit.SetTime, lineID, unit.EMS,1);
                    ret = dal.AddChangeUnitItem(mdl);
                }
                else
                {
                    count += 1;
                    mdl.SetTID(unit.SetTime, lineID, unit.EMS, count);
                    ret = dal.AddChangeUnitItem(mdl);
                }


                LoadEMS(unit);

                return ret;

            }
            catch
            {
                throw;
            }

        }


        /// <summary>
        /// 更新采集单元数据
        /// </summary>
        /// <param name="mdl"></param>
        /// <param name="curUnit"></param>
        /// <returns></returns>
        public  int  UpdateAcqUnitData(ref AcqLineItemMDL mdl)
        {
            int ret = -1;

            try
            {
                AcqLineDAL acqDal = new AcqLineDAL();

                ProductDal pdal = new ProductDal();


                //获取PN编码
                //
                ProductionMDL productmdl = pdal.GetProductInfo(mdl.PLID, mdl.EMS);


                //存在产品编码
                if (mdl == null || mdl.PN == string.Empty)
                {
                    mdl.PN = "N/A";
                }

                mdl.PN = productmdl.PN;

                ////判断是存在有历史数据，有更新区间信息
                ////有历史数据
          
                if (acqDal.AcqUintExist2(mdl.PLID, mdl.EMS, mdl.UNITID) > 0)
                {
                        //获取当前区间的计数
                        //int percount = GetLastRangCount(mdl);

                        AcqLineItemMDL lastItem = GetLastUnit(mdl);
                        //加一个脉冲信号
                        lastItem.PR_COUNT += 1;
                        //加一个脉冲信号

                        CLog.WriteStationLog("PRE_COUNT", mdl.UNITID + "-" + lastItem.PR_COUNT.ToString());

                        //更新结束时间 和 当前开始时段的时间信息
                        mdl.TID = lastItem.TID;
                        mdl.TGNAME = lastItem.TGNAME;
                        mdl.PR_COUNT = lastItem.PR_COUNT;
                        mdl.START_TIME = lastItem.START_TIME;
                        mdl.END_TIME = DateTime.Now;

                        mdl.TIME_LENGTH = TimeRange.ExecDateDiffSecond(lastItem.START_TIME, mdl.END_TIME);

                        mdl.UPDATE_TIME = mdl.END_TIME;

                        ret = acqDal.UpdateAcqLineUint(mdl);
                }
                else///当前时段的新项目
                {
                    int uintSeq = acqDal.IsUionAcqUint(mdl.UNITID, mdl.PLID);

                    mdl.START_TIME = DateTime.Now;
                    mdl.END_TIME = mdl.START_TIME;

                    //型号发生变化重新计数 同时表示换型了
                    if (uintSeq > 0)
                    {
                        uintSeq += 1;

                        string strSeq = String.Format("{0:D2}", uintSeq);
                        mdl.SetTID(mdl.START_TIME, mdl.PLID, mdl.TGNAME, strSeq);

                    }

                  // mdl.UPDATE_TIME = DateTime.Now;


                    if(productmdl!=null||productmdl.OP!=0)
                    {
                        mdl.START_TIME=DateTime.Now.AddSeconds(-productmdl.OP);

                    }
                    else
                    {
                        mdl.START_TIME = DateTime.Now;
                    }

                    mdl.TIME_LENGTH = TimeRange.ExecDateDiffSecond(mdl.START_TIME, mdl.END_TIME);

                    //更新上一个区间产品的时间
                    AcqLineDAL updateDal = new AcqLineDAL();
                    updateDal.UpdateAclineUnitByLastUnit(DateTime.Now, mdl.PLID);


                    // modify by guozq  2018/3/26
                    //添加采集数据
                    ret = acqDal.AddAcqLine1(mdl);
                }


    

            }
            catch 
            {
                throw;

            }

            return ret;
        }


        /// <summary>
        /// 更新采集数据
        /// </summary>
        /// <param name="mdl"></param>
        /// <param name="index"></param>
        /// <param name="curUnit"></param>
        /// <returns></returns>
        public int  UpdateAcqData( ref AcqLineCountMDL mdl,int index,int curUnit)
        {

            int ret = -1;

            try
            {
                AcqLineDAL acqDal = new AcqLineDAL();


                ProductDal pdal = new ProductDal();


                string lineID = Convert.ToInt32(mdl.PLID).ToString();

                //获取PN编码
                string pn = pdal.GetPNCodeByLineEMS(lineID, mdl.EMS);

               // string pn = pdal.GetPNbyEMSCode(mdl.FormatEMSCode(mdl.EMS));

                ///产品编码获取错误编码设置为0000
                if (pn == null || pn == string.Empty)
                {
                    pn = "E" + mdl.EMS.ToString();
                }
                // pn = "0000";


                mdl.PN = pn;

                //判断是存在有历史数据，有 更新区间信息
                if (acqDal.AcqUintExist2(mdl.PLID, mdl.EMS, mdl.UNITID) > 0)
                {
                    //获取当前区间的计数
                    int percount = GetLastRangCount(mdl);

                   // int storeCont = GetAcqLineMDLPerCount(mdl);
                    CLog.WriteStationLog("L1 T440 PRECOUNT", mdl.UNITID+"-"+this.startCount.ToString());

                    if (curUnit <= 0)
                        this.startCount = 0;


                    if (curUnit == 1)
                        startCount = 0;

                    /////当前采集的数据等于起始采集的数据值
                    //if (curUnit == startCount || curUnit < 0)
                    //    return 0;

                    //if()

                   // if (curUnit<)


                    //开启采集的数据
                    if (startCount <=0)
                    {
                        ///当前采集数量的减去已采集的数量
                        mdl.CUR_COUNT = curUnit - startCount;

                        //CLog.WriteStationLog("ST400", "当前时间总量1" + mdl.CUR_COUNT.ToString());
                    }
                    else
                    {
                        int offset = curUnit - startCount;

                        ///采集变换的偏移量较大
                        if (offset > 1)
                        {
                            int storecount = GetStartCount(mdl);

                            if (storecount > 0)
                            {
                                offset = storecount - curUnit;
                            }

                            startCount = curUnit;
                        }

                        //可能重新计数了
                        if (offset < 0)
                        {
                            offset = 1;
                           // startCount = curUnit;
                        }

                        mdl.CUR_COUNT = offset + percount;
                        //CLog.WriteStationLog("ST400", "当前时间总量2" + mdl.CUR_COUNT.ToString());
                    }

                    ///设置采集的内存区间值
                   // setTimeRangCount(index, mdl.CUR_COUNT);

                    //ret = acqDal.UpAcqUnitCount(mdl.TID, mdl.CUR_COUNT);
                    //ret = acqDal.UpAcqUnitCount2(mdl.CUR_COUNT, mdl.PLID, mdl.UNITID, pn);

                    mdl.START_COUNT = startCount;


                   // ret = acqDal.UpAcqUnitCount2(mdl.CUR_COUNT,mdl.START_COUNT, mdl.PLID,0, mdl.UNITID, mdl.EMS);

                }
                else///当前时段的新项目
                {
                    
                    if (curUnit <= 0)
                        this.startCount = 0;

                    /////当前采集的数据等于起始采集的数据值
                    if (curUnit == startCount || curUnit < 0)
                        return 0;

                    //清零了计数器
                    if (curUnit == 1)
                        startCount = 0 ;

                    //获取当前所有的区间内的计数数据
                    if (startCount == 0)
                    {
                       //startCount = acqDal.GetAcqTotalCount(mdl.PLID,DateTime.Now);
                      
                        ///////startCount = acqDal.GetAcqLineLastConut(mdl.PLID);
                    }

                    //开启采集的数据
                    if (startCount <= 0)
                    {
                        ///当前采集数量的减去已采集的数量
                        mdl.CUR_COUNT = curUnit - startCount;
                    }
                    else
                    {
                        //计数的差值
                        int offset = curUnit - startCount;
                        mdl.CUR_COUNT = offset;

                        //计数未正常清零的情况下，重新开始计数
             
                    }



                    if (mdl.CUR_COUNT <= 0)
                    {
                        mdl.CUR_COUNT = 1;
                        mdl.START_COUNT = curUnit;
                    }

                    ///设置采集的内存区间值
                   // setTimeRangCount(index, mdl.CUR_COUNT);

                    //mdl.START_COUNT = startCount;

                    mdl.START_COUNT = curUnit;

                    int uintSeq = acqDal.IsUionAcqUint(mdl.UNITID, mdl.PLID);

                    //型号发生变化重新计数 同时表示换型了
                    if (uintSeq>0)
                    {
                        uintSeq += 1;

                        string strSeq = String.Format("{0:D2}", uintSeq);
                        mdl.SetTID(mdl.START_TIME, mdl.PLID, mdl.TGNMAE, strSeq);

                    }

                    mdl.UPDATE_TIME = DateTime.Now;
                    mdl.BEGIN_TIME = DateTime.Now;


                  // modify by guozq  2018/3/26
                  //添加采集数据
                  //  ret = acqDal.AddAcqLine(mdl);
                }

     
                return ret;
            }
            catch 
            {
                throw;
            }
            finally
            {
                //更新计数值
                this.startCount = curUnit;
                CLog.WriteStationLog("L1 T440", this.startCount.ToString());
                
            }
        }


        /// <summary>
        /// 插入当前采集数据
        /// </summary>
        /// <param name="acqTime"></param>
        /// <param name="count"></param>
        private void setTimeRangCount(DateTime acqTime, int count)
        {
            if (lists == null || lists.Count <= 0)
                return;

            for (int i = 0; i < lists.Count; i++)
            {
                //判断在时间范围内
                if (lists[i].rang.IsInRange(acqTime))
                {
                    lists[i].dataCount = count;
                    CLog.WriteStationLog("ST400", "设置总量" + count.ToString());
                    break;

                }
            }

        }


        /// <summary>
        /// 插入当前采集数据
        /// </summary>
        /// <param name="acqTime"></param>
        /// <param name="count"></param>
        private void setTimeRangCount(int index, int count)
        {
            if (lists == null || lists.Count <= 0)
                return;
            
            lists[index].dataCount = count;

        }


    }
}
