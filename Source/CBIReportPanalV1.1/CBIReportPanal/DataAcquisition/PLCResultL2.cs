namespace DataGather
{
    using COMM;
    //using DAL;
    using MDL;
    using OPCAutomation;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Net;
    using DAL;
    //using SQLiteDAL;

    public class PLCResultL2
    {
        private Array AccessPaths;
        private Array ClientHandles;
        private Array CurClientHandles;
        private Array CurItemValues;
        private int CurNumItems;
        private PLCDataMDL curProcessComData;
        private PLCDataMDL curProcessStationAllData;
        private int DataItemNum;
        public List<PLCDataMDL> DataList;
        private Array ErrorsIn;
        public string GroupName;
        private OPCGroups MyOPCGroupColl;
        public OPCGroup MyOPCGroupIn;
        private OPCItems MyOPCItemCollIn;
        private OPCServer MyOPCServer;
        public string OPCIP;
        public string OPCName;
        private Array RequestedDataTypes;
        public Array ServerHandlesIn;
        private Array WatchDataReadItem;

        public EventHandler ShowLogEvent;



        public ProductLineCaculator plineCaculator;

        public PLCResultL2()
        {
            this.DataItemNum = 0;
            this.OPCName = string.Empty;
            this.OPCIP = string.Empty;
            this.GroupName = string.Empty;
            this.DataList = null;
            this.curProcessStationAllData = null;
            this.curProcessComData = null;
            this.CurNumItems = 0;
            this.CurClientHandles = null;
            this.CurItemValues = null;
            plineCaculator = null;
        }

        public PLCResultL2(string opcName, string opcIP, string groupName, List<PLCDataMDL> dataList)
        {
            this.DataItemNum = 0;
            this.OPCName = string.Empty;
            this.OPCIP = string.Empty;
            this.GroupName = string.Empty;
            this.DataList = null;
            this.curProcessStationAllData = null;
            this.curProcessComData = null;
            this.CurNumItems = 0;
            this.CurClientHandles = null;
            this.CurItemValues = null;
            this.OPCName = opcName;
            this.OPCIP = opcIP;
            this.GroupName = groupName;
            this.DataList = dataList;
            plineCaculator = new ProductLineCaculator();


        }


        /// <summary>
        /// 重新加载计数器
        /// </summary>
        public void ReloadCaculator()
        {
            plineCaculator.ReLoad();
        }

        ///
        public List<PDNumberUnit> getPDNumberUnit()
        {
            if (plineCaculator == null)
                return null;

            return plineCaculator.PDActualNumberList;
        }


        public void AsycnWriter(List<PLCDataMDL> list)
        {
            try
            {
                List<object> list2 = new List<object>();
                Array serverHandles = Array.CreateInstance(typeof(int), (int) (list.Count + 1));
                list2.Add(0);
                for (int i = 0; i < list.Count; i++)
                {
                    PLCDataMDL data = list[i];
                    list2.Add(data.DataValue);
                    PLCDataMDL amdl = this.DataList.Find(p => p.ItemID == data.ItemID);
                    object obj2 = this.ServerHandlesIn.GetValue(amdl.UniqueID);
                    serverHandles.SetValue(this.ServerHandlesIn.GetValue(this.DataList.Find(p => p.ItemID == data.ItemID).UniqueID), (int) (i + 1));
                }
                Array values = list2.ToArray();
                if (serverHandles.GetValue(1).ToString() != "0")
                {
                    Array array3;
                    int num2;
                    this.MyOPCGroupIn.AsyncWrite(list.Count, ref serverHandles, ref values, out array3, 1, out num2);
                }
            }
            catch (Exception exception)
            {
                CLog.WriteErrLogInTrace(string.Format("在往OPC写数据时出错，{0}，{1}", exception.Message, list[0].ItemID));
            }
        }

        //public void CheckLastStationData(PLCDataMDL keyItemData, string barCode, PLCDataMDL data)
        //{
        //    string str = string.Empty;
        //    string stationID = string.Empty;
        //    string[] strArray = null;
        //    string[] strArray2 = null;
        //    Random random = new Random();
        //    ResultL2DAL tldal = new ResultL2DAL();
        //    ProcessParameterDAL rdal = new ProcessParameterDAL();
        //    try
        //    {
        //        string[] strArray3;
        //        double num3;
        //        if (data.StationID == "ST150")
        //        {
        //            stationID = "ST124";
        //            strArray = new string[] { "st124_fd", "st124_po", "st124_fo" };
        //            strArray3 = new string[3];
        //            num3 = Convert.ToDouble(random.Next(0x3444, 0x344e)) / 100.0;
        //            strArray3[0] = num3.ToString();
        //            num3 = Convert.ToDouble(random.Next(0x4538, 0x457e)) / 100.0;
        //            strArray3[1] = num3.ToString();
        //            num3 = Convert.ToDouble(random.Next(0x4711c, 0x493e0)) / 1000.0;
        //            strArray3[2] = num3.ToString();
        //            strArray2 = strArray3;
        //        }
        //        else if ((data.StationID == "ST160A") || (data.StationID == "ST160B"))
        //        {
        //            stationID = "ST150";
        //            strArray = new string[] { "st150_t", "st150_a" };
        //            strArray3 = new string[2];
        //            num3 = Convert.ToDouble(random.Next(600, 700)) / 100.0;
        //            strArray3[0] = num3.ToString();
        //            num3 = Convert.ToDouble(random.Next(0x8fc, 0x9c4)) / 100.0;
        //            strArray3[1] = num3.ToString();
        //            strArray2 = strArray3;
        //        }
        //        else if ((data.StationID == "ST170A") || (data.StationID == "ST170B"))
        //        {
        //            stationID = "ST160";
        //            strArray  = new string[] { "st160" };
        //            strArray2 = new string[] { random.Next(5, 9).ToString() };
        //        }
        //        else if (data.StationID == "ST176")
        //        {
        //            stationID = "ST170";
        //            strArray  = new string[] { "st170" };
        //            strArray2 = new string[] { random.Next(100, 110).ToString() };
        //        }
        //        else if (data.StationID == "ST177")
        //        {
        //            stationID = "ST176";
        //            strArray = new string[] { "st170", "st176_pf" };
        //            strArray3 = new string[2];
        //            strArray3[0] = random.Next(100, 110).ToString();
        //            num3 = Convert.ToDouble(random.Next(50, 0x91)) / 10.0;
        //            strArray3[1] = num3.ToString();
        //            strArray2 = strArray3;
        //        }
        //        else if (data.StationID == "ST180")
        //        {
        //            stationID = "ST177";
        //            strArray = new string[] { "st177" };
        //            strArray2 = new string[] { random.Next(120, 130).ToString() };
        //        }
        //        else if (data.StationID == "ST360")
        //        {
        //            stationID = "ST340";
        //            strArray = new string[] { "st340_t1", "st340_a1", "st340_t2", "st340_a2", "st360_xminx1", "st360_xminy1", "st360_xmaxx1", "st360_xmaxy1", "st360_yminx1", "st360_yminy1", "st360_ymaxx1", "st360_ymaxy1" };
        //            strArray3 = new string[12];
        //            num3 = Convert.ToDouble(random.Next(0xc1c, 0xc80)) / 100.0;
        //            strArray3[0] = num3.ToString();
        //            strArray3[1] = Convert.ToDouble((int) (random.Next(0xa28, 0xa8c) / 100)).ToString();
        //            num3 = Convert.ToDouble(random.Next(0xc1c, 0xc80)) / 100.0;
        //            strArray3[2] = num3.ToString();
        //            num3 = Convert.ToDouble(random.Next(0xa8c, 0xaf0)) / 100.0;
        //            strArray3[3] = num3.ToString();
        //            num3 = Convert.ToDouble(random.Next(-4550, -4550)) / 1000.0;
        //            strArray3[4] = num3.ToString();
        //            num3 = Convert.ToDouble(random.Next(0x1b58, 0x1bbc)) / 1000.0;
        //            strArray3[5] = num3.ToString();
        //            strArray3[6] = "0";
        //            num3 = Convert.ToDouble(random.Next(0x44c, 0x4b0)) / 10.0;
        //            strArray3[7] = num3.ToString();
        //            num3 = Convert.ToDouble(random.Next(-3500, -3000)) / 1000.0;
        //            strArray3[8] = num3.ToString();
        //            num3 = Convert.ToDouble(random.Next(0xe10, 0xe74)) / 1000.0;
        //            strArray3[9] = num3.ToString();
        //            strArray3[10] = "0";
        //            num3 = Convert.ToDouble(random.Next(0x44c, 0x4b0)) / 10.0;
        //            strArray3[11] = num3.ToString();
        //            strArray2 = strArray3;
        //        }
        //        else if ((data.StationID == "ST363A") || (data.StationID == "ST400"))
        //        {
        //            stationID = "ST363";
        //            strArray = new string[] { "st363_c", "st363_d", "st363_intime", "st363_outtime" };
        //            strArray3 = new string[4];
        //            num3 = Convert.ToDouble(random.Next(750, 850)) / 1000.0;
        //            strArray3[0] = num3.ToString();
        //            num3 = Convert.ToDouble(random.Next(0x910, 0x9c4)) / 1000.0;
        //            strArray3[1] = num3.ToString();
        //            num3 = Convert.ToDouble(random.Next(0x578, 0x5dc)) / 1000.0;
        //            strArray3[2] = num3.ToString();
        //            strArray3[3] = (Convert.ToDouble(random.Next(0xec4, 0xed8)) / 1000.0).ToString();
        //            strArray2 = strArray3;
        //        }
        //        if ((!rdal.ExistParam("2", PublicVariable.globalProductID, stationID) && (data.StationID != "ST360")) && (data.StationID != "ST400"))
        //        {
        //            CLog.WriteStationLog(string.Format(@"Com\{0}", data.StationID), string.Format("{0}在{1}无工艺参数", barCode, stationID));
        //        }
        //        else
        //        {
        //            for (int i = 0; i < strArray.Length; i++)
        //            {
        //                str = tldal.GetFieldValueByKeyCode(strArray[i], keyItemData.DBFieldName, barCode);
        //                if ((((str == string.Empty) || (str == "0")) && (barCode != string.Empty)) && (tldal.UpdateByField(strArray[i], strArray2[i], 1, keyItemData.DBFieldName, barCode) > 0))
        //                {
        //                    CLog.WriteStationLog("Check", string.Format("{0}.{1}={2}", barCode, strArray[i], strArray2[i]));
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        CLog.WriteStationLog(data.StationID, exception.Message);
        //    }
        //}

        private void DataChangeThreadFun(object param)
        {


            //采集的子单元
            AcqLineItemMDL acqlineMDL = new AcqLineItemMDL();
            acqlineMDL.PLID = "02";

            try
            {
                OPCDataChangeMDL emdl = (OPCDataChangeMDL)param;
                int opcNumItems = emdl.OpcNumItems;
                Array opcClientHandles = emdl.OpcClientHandles;
                Array opcItemValues = emdl.OpcItemValues;


                // 当前采集数量
                int curCount = 0;
                //产品设置EMC地址
                int ems = 0;




                //获取当前采集的数据内容
                for (int i = 1; i <= opcNumItems; i++)
                {

                    PLCDataMDL data = null;

                    ///采集的量
                   // CLog.WriteStationLog(data.StationID, string.Format("{0}={1}", data.ItemID, opcClientHandles.GetValue(i).ToString()));

                    int uniqueID = int.Parse(opcClientHandles.GetValue(i).ToString());

                    data = this.DataList.Find(p => p.UniqueID == uniqueID);

                    ///数据为空
                    if (data == null)
                        continue;



                    if (opcItemValues.GetValue(i) != null)
                    {
                       data.DataValue = opcItemValues.GetValue(i).ToString().Replace("\r", "").Replace("\n", "");
                          //data.DataValue = opcItemValues.GetValue(i).ToString();
                    }
                    else
                    {
                        data.DataValue = string.Empty;
                    }

                    CLog.WriteStationLog(data.StationID, string.Format("{0}={1}", data.ItemID, data.DataValue));

                    if (data.StationID == "ST400")
                    {
                        switch (data.ItemID)
                        {
                            //  //产线计数
                            //case "ST400.PLCCOUNT":
                            //    Int32.TryParse(string.Format("{0}", data.DataValue), out curCount);
                            //    CLog.WriteStationLog(data.StationID, string.Format("{0}={1}", data.ItemID, data.DataValue));
                            //    break;
                            case "ST400.TICKUNIT":

                                bool tickChange = false;

                                Boolean.TryParse(data.DataValue, out tickChange);

                                if (tickChange)
                                    curCount = 1;
                                else
                                    curCount = 0;

                                     
                                CLog.WriteStationLog(data.StationID, string.Format("{0}={1}", data.ItemID, data.DataValue));
                                break;
                            case "ST400.TICKUNIT2":
                                bool tickChange2 = false;

                                Boolean.TryParse(data.DataValue, out tickChange2);

                                if (tickChange2)
                                    curCount = 1;
                                else
                                    curCount = 0;

                                     
                                CLog.WriteStationLog(data.StationID, string.Format("{0}={1}", data.ItemID, data.DataValue));
                                break;
                                //break;
                             //产品类型
                            //case "ST400.ProductType":
                            //    Int32.TryParse(string.Format("{0}", data.DataValue), out ems);

                            //    CLog.WriteStationLog(data.StationID, string.Format("{0}={1}", data.ItemID, data.DataValue));
                            //    break;
                            //case "ST400.PN":
                            //    Int32.TryParse(string.Format("{0}", data.DataValue), out ems);
                            //    CLog.WriteStationLog(data.StationID, string.Format("{0}={1}", data.ItemID, data.DataValue));
                            //    break;
                            default:
                                continue;
                        }

                    }
                    else
                    {
                        continue;
                    }


                }


                if (curCount == 0)
                    return;

                EMSUnit unit = null;

                ems = ReadEMS();

                acqlineMDL.EMS = ems;
                ///插入追溯记录  工位是默认的
                AddTraceInfo(acqlineMDL, "ST400", curCount);

                //判断计算器时间
                if (plineCaculator == null)
                {
                    plineCaculator = new ProductLineCaculator();
                    plineCaculator.ReloadPlanUnits();
                    ///初始化EMS编号
                   // ems = ReadEMS();

                    unit = new EMSUnit(ems, DateTime.Now);

                    plineCaculator.ems = unit;
                }

               // //异步读产品类型
               // Array arrayType = this.SyncRead("ST400.ProductType");

               //// string productType = "0";

               // if (arrayType != null)
               // {
               //     //productType = arrayType.GetValue(1).ToString();

               //     foreach(object item in arrayType )
               //     {
               //         Int32.TryParse(string.Format("{0}", item), out ems);
               //     }
               //    // Int32.TryParse(string.Format("{0}", productType), out ems);
               // }
               // ems = ReadEMS();

                unit = new EMSUnit(ems, DateTime.Now);
                //////////////////////////////////////////////////////////////////////////

               CLog.WriteStationLog("ST400", string.Format("EMS：{0}={1}", unit.EMS, unit.SetTime.ToLongDateString()));

                //检查是否需要重新加载计算区间
                plineCaculator.CheckReload(DateTime.Now, unit);

                DateTime acqTime = DateTime.Now;

                //获取当前数据输入的采集区间
                TimeRange range = plineCaculator.GetTimeRangByAcqTime(DateTime.Now);

                ///采集数据创建并设置唯一编号
                acqlineMDL.TGNAME = range.SEQ;
                acqlineMDL.SetTID(DateTime.Now, acqlineMDL.PLID, range.SEQ, "01");
                acqlineMDL.PR_COUNT = 1;
                acqlineMDL.EMS = ems;
                acqlineMDL.UPDATE_TIME = DateTime.Now;
           
                //////////////////////////////////////////////////////////////////////////
                //Test
                CLog.WriteStationLog("ST400", string.Format("EMS：{0}={1}", unit.EMS, unit.SetTime.ToLongDateString()));



      

                //更新采集数据
               // plineCaculator.UpdateAcqData(ref acqlineMDL, index, curCount);
                plineCaculator.UpdateAcqUnitData(ref acqlineMDL);

                CLog.WriteStationLog("ST400", string.Format("BEGIN CHANGE:{0}---{1}", plineCaculator.ems.EMS, acqlineMDL.EMS));


                ///判断是否换型
                //if (plineCaculator.IsChangeProduct(unit))
                if (plineCaculator.IsChangedEMS(acqlineMDL.EMS))
                {

                    CLog.WriteStationLog("ST400", string.Format("BEGIN CHANGE:{0}---{1}", plineCaculator.ems.EMS, acqlineMDL.EMS));
                    unit.EMS = acqlineMDL.EMS;
                    //处理换型记录
                    if (plineCaculator.ProcessAcqLineData(acqlineMDL.PLID, acqlineMDL.UNITID, unit)>0)
                    {
                        CLog.WriteStationLog("ST400", string.Format("换型成功:{0}---{1}", plineCaculator.ems.EMS, acqlineMDL.EMS));
                    }
                    else
                    {
                        CLog.WriteStationLog("ST400", string.Format("换型失败:{0}---{1}", plineCaculator.ems.EMS, acqlineMDL.EMS));
                    }
                    ////更改换型时间
                    //AcqLineDAL updateDal = new AcqLineDAL();
                    //updateDal.UpdateAclineUnitByLastUnit(DateTime.Now, acqlineMDL.PLID);
                }
                else
                {
                    //plineCaculator.LoadEMSTime(unit.SetTime);
                    plineCaculator.LoadEMSTime(DateTime.Now);
                }

                //////////////////////////////////////////////////////////////////////////
                //  CLog.WriteStationLog("ST400", string.Format("{0}的计算数量{1}已提交", curCount, DateTime.Now.ToLongDateString()));

       
                

            }
            catch (System.Exception ex)
            {
                CLog.WriteStationLog(acqlineMDL.PLID, ex.Message.ToString());
            }


        }



        private int ReadEMS()
        {
            try
            {          //异步读产品类型
                Array arrayType = this.SyncRead("ST400.ProductType");

                int ems = 0;

                if (arrayType != null)
                {
                    foreach (object item in arrayType)
                    {
                        Int32.TryParse(string.Format("{0}", item), out ems);
                    }
                }

                return ems;

            }
            catch (System.Exception ex)
            {
                CLog.WriteErrLog(ex.Message.ToString());
            }

            return 0;
  
        }

        private void AddTraceInfo(AcqLineItemMDL linfInfo, string station_id, int pre_count)
        {
            try
            {

                AcqLineTraceMDL traceInfo = new AcqLineTraceMDL();

                //EMS+产线编号
                traceInfo.ACQID = COMM.CodeComm.GetRandomSeqNum(DateTime.Now,linfInfo.EMS + linfInfo.PLID);
                traceInfo.BEG_COUNT = pre_count;
                traceInfo.ACQ_DATE = DateTime.Now;
                traceInfo.EMS = linfInfo.EMS;
                traceInfo.PLID = linfInfo.PLID;
                traceInfo.SEQID = linfInfo.UNITID;
                traceInfo.STATIONID = station_id;

                AcqTraceDAL traceDal = new AcqTraceDAL();

                int ret = traceDal.AddAcqTrace(traceInfo);

                if (ret <= 1)
                    CLog.WriteStationLog("TRACE_ADD_ERROR", station_id);

            }
            catch (System.Exception ex)
            {
                CLog.WriteStationLog(linfInfo.PLID + "TRACE_ADD_ERROR", ex.Message.ToString());
            }

        }

        //private void DataChangeThreadFun(object param)
        //{
        //    //OPCDataChangeMDL emdl = (OPCDataChangeMDL)param;
        //    //int opcNumItems = emdl.OpcNumItems;
        //    //Array opcClientHandles = emdl.OpcClientHandles;
        //    //Array opcItemValues = emdl.OpcItemValues;

        //    //for (int i = 1; i <= opcNumItems; i++)
        //    //{
        //    //    //List<PLCDataMDL> list2;
        //    //    //PLCDataMDL amdl2;
        //    //    //PLCDataMDL amdl3;
        //    //    //List<PLCDataMDL> list3;
        //    //    //ResultL2DAL tldal;
        //    //    //CodeLine2DAL linedal;
        //    //    //int num3;
        //    //    //PLCDataMDL amdl6;
        //    //    //Predicate<PLCDataMDL> match = null;

        //    //    PLCDataMDL data = null;

        //    //    int uniqueID = int.Parse(opcClientHandles.GetValue(i).ToString());

        //    //    data = this.DataList.Find(p => p.UniqueID == uniqueID);

        //    //    if (opcItemValues.GetValue(i) != null)
        //    //    {
        //    //        data.DataValue = opcItemValues.GetValue(i).ToString().Replace("\r", "").Replace("\n", "");
        //    //    }
        //    //    else
        //    //    {
        //    //        data.DataValue = string.Empty;
        //    //    }

        //    //  //  if (ShowLogEvent != null)
        //    //   //     ShowLogEvent(data.StationID.ToString()+"开始接收"+DateTime.Now.ToShortTimeString(), EventArgs.Empty);

        //    //    CLog.WriteStationLog(data.StationID, string.Format("{0}={1}", data.ItemID, data.DataValue));
        //    //    //try
        //    //    //{
        //    //    //    if (data.ItemID.Contains("Complete") && (data.DataValue.ToLower() == "true"))
        //    //    //    {
        //    //    //        this.ProcessStationAllData(data);
        //    //    //    }
        //    //    //}
        //    //    //catch (Exception exception1)
        //    //    //{
        //    //    //  //  exception = exception1;
        //    //    //   // CLog.WriteErrLogInTrace(string.Format("在处理工位的Complete数据时出错，{0}", exception.Message));
        //    //    //}

        //    //    CLog.WriteStationLog(data.StationID,"数据返回成功");

        //    //    if ((data.StationID == "ST400") && (data.ItemID == "ST400.PLCCOUNT"))
        //    //    {

        //    //        CLog.WriteStationLog(data.StationID, "进入检查阶段");

        //    //        int curCount=0;


        //    //        CLog.WriteStationLog(data.StationID, data.DataValue);

        //    //        Int32.TryParse(string.Format("{0}",data.DataValue),out curCount);


        //    //        CLog.WriteStationLog(data.StationID, "转换成功");

        //    //        if (curCount <= 0)
        //    //        {
        //    //            CLog.WriteStationLog(data.StationID, string.Format("错误{0}={1}", data.ItemID, curCount.ToString()));
        //    //            continue;
                        
        //    //        }

        //    //            //= Convert.ToInt32(data.DataValue.Trim());

        //    //        //if (ShowLogEvent != null)
        //    //        //    ShowLogEvent(data.StationID.ToString() + "采集开关数量" + DateTime.Now.ToShortTimeString(), EventArgs.Empty);
                   


        //    //        ///获取当前计数值
        //    //        ///

        //    //        AcqCountMDL unitMDL = null;


        //    //        if (plineCaculator != null)
        //    //        { 
        //    //            unitMDL = plineCaculator.GetAcqCount(curCount, DateTime.Now);
        //    //            CLog.WriteStationLog(data.StationID, "获取采集时间！");
        //    //        }
        //    //        else
        //    //        {
        //    //            CLog.WriteStationLog(data.StationID,"换算器未加载！");
        //    //            plineCaculator = new ProductLineCaculator();
        //    //            unitMDL = plineCaculator.GetAcqCount(curCount, DateTime.Now); 
        //    //           // continue;
        //    //        }

        //    //        if (unitMDL != null)
        //    //        {

        //    //           // AcqCountListDAL acqCountListdal = new AcqCountListDAL();

        //    //            AcqCountListSQLiteDAL acqCountListdal = new AcqCountListSQLiteDAL();

        //    //            CLog.WriteStationLog(data.StationID, "COUNT==" + unitMDL.CurrentCount.ToString());
        //    //            ///更新采集列表数量
        //    //            acqCountListdal.UpdateAcqCountValue(unitMDL);

        //    //            string planID = DateTime.Now.ToString("yyyyMMdd");

        //    //            planID = string.Format("{0}_{1}", planID, BaseVariable.PLineID);

        //    //            CLog.WriteStationLog(data.StationID, "PLANID==" + planID);

        //    //           // ProductionPlanDal plandal = new ProductionPlanDal();

        //    //            ProductionPlanSQLiteDal plandal = new ProductionPlanSQLiteDal();

        //    //            //if (ShowLogEvent != null)
        //    //            //    ShowLogEvent(data.StationID.ToString() + planID + DateTime.Now.ToShortTimeString(), EventArgs.Empty);

        //    //            string tid = plandal.GetTIDByDataTime(planID, unitMDL.StartTime, unitMDL.EndTime);
        //    //            //    CLog.WriteStationLog(data.StationID, string.Format("{0}未找到TID{1}已提交", curCount, DateTime.Now.ToLongDateString()));

        //    //            CLog.WriteStationLog(data.StationID, "tid==" + tid);

        //    //            if (tid != string.Empty)
        //    //                plandal.UpdateActualPlan(tid, unitMDL.CurrentCount);

        //    //            CLog.WriteStationLog(data.StationID, string.Format("{0}的计算数量{1}已提交", curCount, DateTime.Now.ToLongDateString()));

        //    //            return;
        //    //        }
        //    //    }
        //    //    else
        //    //    {
        //    //        CLog.WriteStationLog(data.StationID, string.Format("未找到输入量{0}={1}", data.ItemID, data.DataValue));
        //    //    }

        //    //}

        //}


        //private int GetPLCBracketCutValue(string value)
        //{
        //    int count = 0;

        //    if(value!=null&&value!=string.Empty)
        //    count=


        //}
        ////private void DataChangeThreadFun(object param)
        //{
        //    Exception exception;
        //    try
        //    {
        //        DateTime now = DateTime.Now;
        //        OPCDataChangeMDL emdl = (OPCDataChangeMDL) param;
        //        int opcNumItems = emdl.OpcNumItems;
        //        Array opcClientHandles = emdl.OpcClientHandles;
        //        Array opcItemValues = emdl.OpcItemValues;
        //        for (int i = 1; i <= opcNumItems; i++)
        //        {
        //            try
        //            {
        //                List<ReportEntity> list;
        //                PrinterMDL rmdl;
        //                bool flag;
        //                PrintCountMDL tmdl;
        //                PrintCountDAL tdal;
        //                List<PLCDataMDL> list2;
        //                PLCDataMDL amdl2;
        //                PLCDataMDL amdl3;
        //                List<PLCDataMDL> list3;
        //                ResultL2DAL tldal;
        //                CodeLine2DAL linedal;
        //                int num3;
        //                PLCDataMDL amdl6;
        //                Predicate<PLCDataMDL> match = null;
        //                PLCDataMDL data = null;
        //                int uniqueID = int.Parse(opcClientHandles.GetValue(i).ToString());
        //                data = this.DataList.Find(p => p.UniqueID == uniqueID);
        //                if (opcItemValues.GetValue(i) != null)
        //                {
        //                    data.DataValue = opcItemValues.GetValue(i).ToString().Replace("\r", "").Replace("\n", "");
        //                }
        //                else
        //                {
        //                    data.DataValue = string.Empty;
        //                }
        //                CLog.WriteStationLog(data.StationID, string.Format("{0}={1}", data.ItemID, data.DataValue));
        //                try
        //                {
        //                    if (data.ItemID.Contains("Complete") && (data.DataValue.ToLower() == "true"))
        //                    {
        //                        this.ProcessStationAllData(data);
        //                    }
        //                }
        //                catch (Exception exception1)
        //                {
        //                    exception = exception1;
        //                    CLog.WriteErrLogInTrace(string.Format("在处理工位的Complete数据时出错，{0}", exception.Message));
        //                }
        //                if (data.StationID == "ST100")
        //                {
        //                    //if ((data.ItemID == "ST100.PrintIO") && (data.DataValue.ToLower() == "true"))
        //                    //{
        //                    //    list = new List<ReportEntity>();
        //                    //    rmdl = BaseVariable.PrinterList.Find(p => (p.LineID == "L2") && (p.Type == 1));
        //                    //    list.Add(PrinterMan.GetReportEntity(rmdl.CountKey, rmdl.CodeType));
        //                    //    PrinterMan man = new PrinterMan(rmdl.Name, rmdl.CodeType);
        //                    //    flag = man.PrinterBarCode(list);
        //                    //    tmdl = new PrintCountMDL();
        //                    //    tdal = new PrintCountDAL();
        //                    //    if (tdal.GetDataByKeyName(rmdl.CountKey) == null)
        //                    //    {
        //                    //        flag = false;
        //                    //    }
        //                    //    if (!flag)
        //                    //    {
        //                    //        CLog.WriteStationLog(data.StationID, string.Format("条码{0}打印失败！", list[0].ProductCode));
        //                    //        list2 = new List<PLCDataMDL>();
        //                    //        PLCDataMDL item = new PLCDataMDL {
        //                    //            ItemID = "ST100.AlarmPrintErr",
        //                    //            DataValue = "1"
        //                    //        };
        //                    //        list2.Add(item);
        //                    //        if (list2.Count > 0)
        //                    //        {
        //                    //            this.AsycnWriter(list2);
        //                    //        }
        //                    //    }
        //                    //}
        //                    //else if (((data.ItemID == "ST100.DeviceIn") && (data.DataValue.ToLower() == "true")) && (BaseVariable.SysDebug == "1"))
        //                    //{
        //                    //    amdl2 = new PLCDataMDL();
        //                    //    amdl3 = new PLCDataMDL();
        //                    //    list3 = new List<PLCDataMDL>();
        //                    //    amdl2.ItemID = "ST100.ST110_BarCode";
        //                    //   // amdl2.DataValue = PrinterMan.GetBarCode("C2");
        //                    //    list3.Add(amdl2);
        //                    //    amdl3.ItemID = "ST100.ST110_WriteCode";
        //                    //    amdl3.DataValue = "1";
        //                    //    list3.Add(amdl3);
        //                    //    if (list3.Count > 0)
        //                    //    {
        //                    //        PublicVariable.plcL2.AsycnWriter(list3);
        //                    //    }
        //                    //}
        //                    //goto Label_0E4C;
        //                }
        //                if (data.StationID == "ST230")
        //                {
        //                    if ((data.ItemID == "ST230.PrintIO") && (data.DataValue.ToLower() == "true"))
        //                    {
        //                        //list = new List<ReportEntity>();
        //                        rmdl = BaseVariable.PrinterList.Find(p => (p.LineID == "L2") && (p.Type == 2));
        //                       // list.Add(PrinterMan.GetReportEntity(rmdl.CountKey, rmdl.CodeType));
        //                      //  flag = new PrinterMan(rmdl.Name, rmdl.CodeType).PrinterBarCode(list);
        //                        tmdl = new PrintCountMDL();
        //                        tdal = new PrintCountDAL();
        //                        if (tdal.GetDataByKeyName(rmdl.CountKey) == null)
        //                        {
        //                            flag = false;
        //                        }
        //                        if (!flag)
        //                        {
        //                            CLog.WriteStationLog(data.StationID, string.Format("条码{0}打印失败！", list[0].ProductCode));
        //                            list2 = new List<PLCDataMDL>();
        //                            PLCDataMDL amdl4 = new PLCDataMDL {
        //                                ItemID = "ST230.AlarmPrintErr",
        //                                DataValue = "1"
        //                            };
        //                            list2.Add(amdl4);
        //                            if (list2.Count > 0)
        //                            {
        //                                this.AsycnWriter(list2);
        //                            }
        //                        }
        //                    }
        //                    else if (((data.ItemID == "ST230.DeviceIn") && (data.DataValue.ToLower() == "true")) && (BaseVariable.SysDebug == "1"))
        //                    {
        //                        amdl2 = new PLCDataMDL();
        //                        amdl3 = new PLCDataMDL();
        //                        list3 = new List<PLCDataMDL>();
        //                        amdl2.ItemID = "ST230.BarCode";
        //                       // amdl2.DataValue = PrinterMan.GetBarCode("B2");
        //                        list3.Add(amdl2);
        //                        amdl3.ItemID = "ST230.WriteCode";
        //                        amdl3.DataValue = "1";
        //                        list3.Add(amdl3);
        //                        if (list3.Count > 0)
        //                        {
        //                            PublicVariable.plcL2.AsycnWriter(list3);
        //                        }
        //                    }
        //                    goto Label_0E4C;
        //                }
        //                if (data.StationID == "ST330")
        //                {
        //                    if (data.ItemID == "ST340.ST330_BarCode")
        //                    {
        //                        if (data.DataValue.Trim() == string.Empty)
        //                        {
        //                            continue;
        //                        }
        //                        string code = string.Empty;
        //                        tldal = new ResultL2DAL();
        //                        linedal = new CodeLine2DAL();
        //                        PLCDataMDL amdl5 = new PLCDataMDL();
        //                        CodeLineMDL newlyUnWriteCodeByStation = linedal.GetNewlyUnWriteCodeByStation("ST330");
        //                        if ((newlyUnWriteCodeByStation != null) && (newlyUnWriteCodeByStation.Code != null))
        //                        {
        //                            code = newlyUnWriteCodeByStation.Code;
        //                            linedal.UpdateUnWriteCodeByStation("ST330", code);
        //                        }
        //                        if (code.Trim() == string.Empty)
        //                        {
        //                            CLog.WriteStationLog(data.StationID, "ST330对应的卡钳号为空");
        //                            continue;
        //                        }
        //                        if (!tldal.Exist("calipercode", code))
        //                        {
        //                            tldal.InsertCode("calipercode", code);
        //                            CLog.WriteStationLog("ST330", string.Format("支架点新增{0}", code));
        //                        }
        //                        if (tldal.GetBrakeByCaliperCode(code) != string.Empty)
        //                        {
        //                            CLog.WriteStationLog(data.StationID, string.Format("{0}和{1}在ST330已绑定，不与放行", data.DataValue, code));
        //                            continue;
        //                        }
        //                        string caliperByBrakeCode = tldal.GetCaliperByBrakeCode(data.DataValue);
        //                        if (caliperByBrakeCode != string.Empty)
        //                        {
        //                            CLog.WriteStationLog(data.StationID, string.Format("{0}和{1}在ST330已绑定，不与放行", caliperByBrakeCode, data.DataValue));
        //                            continue;
        //                        }
        //                        num3 = tldal.UpdateByField("brakecode", data.DataValue, "calipercode", code);
        //                        amdl5.ItemID = "ST340.ST330_ControlPass";
        //                        if (num3 > 0)
        //                        {
        //                            amdl5.DataValue = "1";
        //                        }
        //                        else
        //                        {
        //                            amdl5.DataValue = "0";
        //                        }
        //                        CLog.WriteStationLog(data.StationID, string.Format("将支架数据{0}整合至卡钳{1}，绑定结果{2}", data.DataValue, code, amdl5.DataValue));
        //                        if (amdl5.ItemID != string.Empty)
        //                        {
        //                            this.AsycnWriter(new List<PLCDataMDL> { amdl5 });
        //                        }
        //                    }
        //                    goto Label_0E4C;
        //                }
        //                if (data.StationID == "ST360")
        //                {
        //                    data.DataValue = data.DataValue.Replace(",", "");
        //                    data.DataValue = Regex.Replace(data.DataValue, "[^0-9^a-z^A-Z^.^-]", "");
        //                    goto Label_0E4C;
        //                }
        //                if (!(data.StationID == "ST400"))
        //                {
        //                    goto Label_0DCA;
        //                }
        //                if (!(data.ItemID == "ST400.Complete") || !(data.DataValue.ToLower() == "true"))
        //                {
        //                    goto Label_0E4C;
        //                }
        //                bool flag2 = true;
        //                string str3 = string.Empty;
        //                string str4 = string.Empty;
        //                string brakeCode = string.Empty;
        //                string productType = string.Empty;
        //                Array array3 = null;
        //                linedal = new CodeLine2DAL();
        //                tldal = new ResultL2DAL();
        //                str3 = linedal.GetLastBarCodeOfST400();
        //                CLog.WriteStationLog(data.StationID, string.Format("ST400扫描条码为{0}", str3));
        //                if (tldal.GetFieldValueByKeyCode("repaired", "calipercode", str3) != "1")
        //                {
        //                    array3 = this.SyncRead("ST400.BarCode");
        //                    if (array3 != null)
        //                    {
        //                        brakeCode = array3.GetValue(1).ToString();
        //                    }
        //                    else
        //                    {
        //                        CLog.WriteStationLog(data.StationID, string.Format("{0}为空", "ST400.BarCode"));
        //                    }
        //                    str4 = tldal.GetCaliperByBrakeCode(brakeCode);
        //                    CLog.WriteStationLog(data.StationID, string.Format("支架对应卡钳为 {0}，支架号{1}", str4, brakeCode));
        //                    if (!(str3 != str4))
        //                    {
        //                        goto Label_0BCD;
        //                    }
        //                    string logDesc = string.Format("{0}对应的扫描卡钳号{1}与绑定卡钳号{2}不一致", brakeCode, str3, str4);
        //                    CLog.WriteStationLog(data.StationID, logDesc);
        //                    if (BaseVariable.DataCheckOut == "0")
        //                    {
        //                        goto Label_0BCD;
        //                    }
        //                    list2 = new List<PLCDataMDL>();
        //                    amdl6 = new PLCDataMDL {
        //                        ItemID = "ST400.AlarmBarCodeCheckErr",
        //                        DataValue = "1"
        //                    };
        //                    list2.Add(amdl6);
        //                    if (list2.Count > 0)
        //                    {
        //                        this.AsycnWriter(list2);
        //                    }
        //                    continue;
        //                }
        //                CLog.WriteStationLog(data.StationID, string.Format("{0}为返工件", str3));
        //            Label_0BCD:
        //                array3 = this.SyncRead("ST400.ProductType");
        //                if (array3 != null)
        //                {
        //                    productType = array3.GetValue(1).ToString();
        //                }
        //                else
        //                {
        //                    CLog.WriteStationLog(data.StationID, string.Format("{0}为空", "ST400.ProductType"));
        //                }
        //                if (!tldal.UpdateProductNameByKeyCode("calipercode", str3, productType))
        //                {
        //                    CLog.WriteStationLog(data.StationID, string.Format("更新{0}产品名为{1}失败", str3, productType));
        //                }
        //                flag2 = tldal.CheckAllResult("calipercode", str4, productType);
        //                if (BaseVariable.DataCheckOut == "0")
        //                {
        //                    flag2 = true;
        //                }
        //                if (flag2)
        //                {
        //                    List<PLCDataMDL> list5 = new List<PLCDataMDL>();
        //                    PLCDataMDL amdl7 = new PLCDataMDL();
        //                    PLCDataMDL amdl8 = new PLCDataMDL();
        //                    string bracketByCaliperCode = tldal.GetBracketByCaliperCode(str3);
        //                    if (bracketByCaliperCode == string.Empty)
        //                    {
        //                       // bracketByCaliperCode = PrinterMan.GetBracketCode("214");
        //                    }
        //                    else
        //                    {
        //                        CLog.WriteStationLog(data.StationID, string.Format("卡钳{0}已刻蚀{1}", str3, bracketByCaliperCode));
        //                        bracketByCaliperCode = bracketByCaliperCode.Substring(3);
        //                    }
        //                    amdl7.ItemID = "ST400.BracketCode";
        //                    amdl7.DataValue = bracketByCaliperCode;
        //                    list5.Add(amdl7);
        //                    amdl8.ItemID = "ST400.Marking";
        //                    amdl8.DataValue = "1";
        //                    list5.Add(amdl8);
        //                    this.AsycnWriter(list5);
        //                }
        //                else
        //                {
        //                    list2 = new List<PLCDataMDL>();
        //                    amdl6 = new PLCDataMDL {
        //                        ItemID = "ST400.AlarmResultNOK",
        //                        DataValue = "1"
        //                    };
        //                    list2.Add(amdl6);
        //                    if (list2.Count > 0)
        //                    {
        //                        this.AsycnWriter(list2);
        //                    }
        //                    CLog.WriteStationLog(data.StationID, string.Format("{0}的检测结果不合格", str3));
        //                }
        //                goto Label_0E4C;
        //            Label_0DCA:
        //                if ((data.StationID == "ST290") && ((data.ItemID == "ST290.Alarm") && (data.DataValue.ToLower() == "true")))
        //                {
        //                    CLog.WriteStationLog("ST290_In", "C_ST290_In扫描8846");
        //                    CLog.WriteStationLog("ST290_Out", "C_ST290_Out扫描8842");
        //                }
        //            Label_0E4C:
        //                if ((data.DataValue.Trim() != string.Empty) && ((data.DBFieldName != string.Empty) && !data.IsKey))
        //                {
        //                    string[] strArray = data.DBFieldName.Split(new char[] { ',' });
        //                    PLCDataMDL keyItemData = null;
        //                    if (match == null)
        //                    {
        //                        match = p => (p.StationID == data.StationID) && p.IsKey;
        //                    }
        //                    keyItemData = this.DataList.Find(match);
        //                    if (keyItemData != null)
        //                    {
        //                        num3 = 0;
        //                        string str9 = string.Empty;
        //                        string dBFieldName = keyItemData.DBFieldName;
        //                        string itemID = keyItemData.ItemID;
        //                        ResultL2DAL tldal2 = new ResultL2DAL();
        //                        array3 = this.SyncRead(itemID);
        //                        if (array3 != null)
        //                        {
        //                            str9 = Regex.Replace(array3.GetValue(1).ToString(), "[^0-9^a-z^A-Z]", "");
        //                        }
        //                        else
        //                        {
        //                            CLog.WriteStationLog(data.StationID, string.Format("{0}为空", itemID));
        //                        }
        //                        if (str9.Trim() != string.Empty)
        //                        {
        //                            string[] strArray2;
        //                            int num6;
        //                            CLog.WriteStationLog(data.StationID, string.Format("=>{0}.Update {1}={2}", str9, data.DBFieldName, data.DataValue));
        //                            try
        //                            {
        //                                if ((data.ItemID == "ST160.ALeakage") || (data.ItemID == "ST160.BLeakage"))
        //                                {
        //                                    if (data.DataValue.Length <= 15)
        //                                    {
        //                                        continue;
        //                                    }
        //                                    data.DataValue = data.DataValue.Replace("\t", "");
        //                                    strArray2 = data.DataValue.Split(new char[] { ':' });
        //                                    data.DataValue = Regex.Replace(strArray2[4], "[^-^.^0-9]", "");
        //                                }
        //                                else if ((data.ItemID == "ST170.ALeakage") || (data.ItemID == "ST170.BLeakage"))
        //                                {
        //                                    if (data.DataValue.Length <= 7)
        //                                    {
        //                                        continue;
        //                                    }
        //                                    data.DataValue = data.DataValue.Replace("\t", "");
        //                                    strArray2 = data.DataValue.Split(new char[] { ':' });
        //                                    data.DataValue = Regex.Replace(strArray2[4], "[^-^.^0-9]", "");
        //                                }
        //                                else if (data.ItemID == "ST177.Leakage")
        //                                {
        //                                    if (data.DataValue.Length <= 7)
        //                                    {
        //                                        continue;
        //                                    }
        //                                    data.DataValue = data.DataValue.Replace("\t", "");
        //                                    strArray2 = data.DataValue.Split(new char[] { ':' });
        //                                    data.DataValue = Regex.Replace(strArray2[4], "[^-^.^0-9]", "");
        //                                }
        //                            }
        //                            catch (Exception exception3)
        //                            {
        //                                exception = exception3;
        //                                CLog.WriteErrLogInTrace(string.Format("在处理泄露值时出错：{0}，{1}.{2}={3}", new object[] { exception.StackTrace, str9, data.DBFieldName, data.DataValue }));
        //                                continue;
        //                            }
        //                            if ((data.StationID == "ST180") || (data.StationID == "ST400"))
        //                            {
        //                                if (data.ItemID.Contains("_PF") && (tldal2.GetFieldValueByKeyCode(data.DBFieldName, dBFieldName, str9) == "1"))
        //                                {
        //                                    continue;
        //                                }
        //                                if ((data.StationID == "ST400") && (data.ItemID == "ST400.BracketCode"))
        //                                {
        //                                    data.DataValue = "214" + data.DataValue.PadLeft(8, '0');
        //                                    string str12 = tldal2.GetFieldValueByKeyCode(data.DBFieldName, dBFieldName, str9);
        //                                    if (str12 != string.Empty)
        //                                    {
        //                                        CLog.WriteStationLog(data.StationID, string.Format("{0}的总成号{1}已刻蚀", str9, str12));
        //                                        continue;
        //                                    }
        //                                }
        //                            }
        //                            else if (data.StationID == "ST340")
        //                            {
        //                                double result = 0.0;
        //                                if (double.TryParse(data.DataValue, out result) && ((((result == 0.0) || (result > 33185000.0)) || (result < 300.0)) || (data.ItemID.Contains("Angle") && ((result > 3300000.0) || (result < 300.0)))))
        //                                {
        //                                    continue;
        //                                }
        //                            }
        //                            else if ((data.StationID == "ST150") && (data.DataValue == "0"))
        //                            {
        //                                continue;
        //                            }
        //                            try
        //                            {
        //                                double num5 = 0.0;
        //                                strArray2 = data.DataValue.Split(new char[] { ',' });
        //                                DetailResultMDL mdl = null;
        //                                DetailResult2DAL resultdal = new DetailResult2DAL();
        //                                num6 = 0;
        //                                while (num6 < strArray2.Length)
        //                                {
        //                                    mdl = new DetailResultMDL {
        //                                        Code = str9,
        //                                        StationID = data.StationID,
        //                                        TestItem = data.DBFieldName.Split(new char[] { ',' })[num6].ToUpper()
        //                                    };
        //                                    if (((data.DBFieldType == 1) && (data.DecPoint > 0)) && double.TryParse(data.DataValue, out num5))
        //                                    {
        //                                        strArray2[num6] = (double.Parse(strArray2[num6]) / Math.Pow(10.0, (double) data.DecPoint)).ToString();
        //                                        if (strArray2.Length == 1)
        //                                        {
        //                                            data.DataValue = strArray2[num6];
        //                                        }
        //                                    }
        //                                    mdl.Result = strArray2[num6];
        //                                    if (resultdal.InsertData(mdl) < 0)
        //                                    {
        //                                        CLog.WriteStationLog(data.StationID, string.Format("新增{0}的详细数据{1}失败", str9, strArray2[num6]));
        //                                    }
        //                                    num6++;
        //                                }
        //                            }
        //                            catch (Exception exception4)
        //                            {
        //                                exception = exception4;
        //                                CLog.WriteErrLogInTrace(exception.Message);
        //                            }
        //                            if ((data.DBFieldType == 1) || (data.DBFieldType == 2))
        //                            {
        //                                if (tldal2.Exist(dBFieldName, str9))
        //                                {
        //                                    num6 = 0;
        //                                    while (num6 < strArray.Length)
        //                                    {
        //                                        if (tldal2.UpdateByField(strArray[num6], data.DataValue.Split(new char[] { ',' })[num6], data.DBFieldType, dBFieldName, str9) <= 0)
        //                                        {
        //                                            CLog.WriteStationLog(data.StationID, string.Format("{0}的{1}更新为{2}失败", str9, strArray[num6], data.DataValue));
        //                                        }
        //                                        num6++;
        //                                    }
        //                                }
        //                                else if (tldal2.InsertCode(dBFieldName, str9) <= 0)
        //                                {
        //                                    CLog.WriteStationLog(data.StationID, string.Format("新增{0}的{1}更新为{2}失败", str9, data.DBFieldName, data.DataValue));
        //                                }
        //                                else
        //                                {
        //                                    for (num6 = 0; num6 < strArray.Length; num6++)
        //                                    {
        //                                        if (tldal2.UpdateByField(strArray[num6], data.DataValue.Split(new char[] { ',' })[num6], data.DBFieldType, dBFieldName, str9) <= 0)
        //                                        {
        //                                            CLog.WriteStationLog(data.StationID, string.Format("{0}的{1}更新为{2}失败", str9, strArray[num6], data.DataValue));
        //                                        }
        //                                    }
        //                                }
        //                                if ((data.StationID == "ST400") && (data.ItemID == "ST400.BracketCode"))
        //                                {
        //                                    tldal2.CheckResultState();
        //                                }
        //                                this.CheckLastStationData(keyItemData, str9, data);
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        CLog.WriteStationLog(data.StationID, string.Format("找不到{0}的KeyField", data.ItemID));
        //                    }
        //                }
        //            }
        //            catch (Exception exception5)
        //            {
        //                exception = exception5;
        //                Predicate<PLCDataMDL> predicate2 = null;
        //                CLog.WriteErrLog(string.Format("在处理OPC数据时出错，{0}", exception.Message));
        //                string str13 = string.Empty;
        //                PLCDataMDL amdl10 = null;
        //                int uniqueID = 0;
        //                if (opcItemValues.GetValue(i) != null)
        //                {
        //                    try
        //                    {
        //                        uniqueID = int.Parse(opcClientHandles.GetValue(i).ToString());
        //                        if (predicate2 == null)
        //                        {
        //                            predicate2 = p => p.UniqueID == uniqueID;
        //                        }
        //                        amdl10 = this.DataList.Find(predicate2);
        //                        str13 = opcItemValues.GetValue(i).ToString().Replace("\r", "").Replace("\n", "");
        //                    }
        //                    catch (Exception)
        //                    {
        //                    }
        //                }
        //                CLog.WriteErrLogInTrace(string.Format("在处理OPC数据时出错，{0}，{1}={2}", exception.StackTrace, amdl10.DBFieldName, str13));
        //            }
        //        }
        //    }
        //    catch (Exception exception7)
        //    {
        //        exception = exception7;
        //    }
        //}

        private void MyOPCGroupIn_AsyncWriteComplete(int TransactionID, int NumItems, ref Array ClientHandles, ref Array Errors)
        {
        }

        public virtual void MyOPCGroupIn_DataChange(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {
            OPCDataChangeMDL parameter = new OPCDataChangeMDL(NumItems, ClientHandles, ItemValues);

   
            ParameterizedThreadStart start = new ParameterizedThreadStart(this.DataChangeThreadFun);
                      //CLog.WriteStationLog("开始进行接收",DateTime.Now.ToString());
            new Thread(start) { IsBackground = true }.Start(parameter);

            CLog.WriteSysLog("开启接收线程！");
            //if (ShowLogEvent != null)
            //  ShowLogEvent("开启接收线程！", EventArgs.Empty);
            //}
        }

        public bool OPCServer_Connect(int itemNum)
        {
            try
            {

                this.DataItemNum = itemNum;
                CLog.WriteStationLog("", "设备数量" + itemNum.ToString());

                this.MyOPCServer = new OPCServer();
                    //(OPCServer) Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("28E68F9A-8D75-11D1-8DC3-3C302A000000")));
               
                CLog.WriteSysLog("OPCServer注册成功！");
                CLog.WriteSysLog(this.OPCName + ":" + this.OPCIP.ToString());
                this.MyOPCServer.Connect(this.OPCName,  this.OPCIP);
                CLog.WriteSysLog("OPCServer连接成功！");
                this.MyOPCGroupColl = this.MyOPCServer.OPCGroups;
                CLog.WriteSysLog("OPCGroups");
                this.MyOPCGroupIn = this.MyOPCGroupColl.Add(this.GroupName);
                this.MyOPCServer.OPCGroups.DefaultGroupIsActive = true;
                this.MyOPCServer.OPCGroups.DefaultGroupDeadband = 0f;
                this.MyOPCServer.OPCGroups.DefaultGroupUpdateRate = 100;
                this.MyOPCGroupIn.UpdateRate = 100;
                this.MyOPCGroupIn.IsSubscribed = true;
                this.MyOPCItemCollIn = this.MyOPCGroupIn.OPCItems;
                int length = this.DataItemNum + 1;

                CLog.WriteSysLog("OPCGroups " + length.ToString());
                this.WatchDataReadItem = Array.CreateInstance(typeof(string), length);
                this.ServerHandlesIn = Array.CreateInstance(typeof(int), length);
                this.ErrorsIn = Array.CreateInstance(typeof(int), length);
                this.ClientHandles = Array.CreateInstance(typeof(int), length);
                this.RequestedDataTypes = Array.CreateInstance(typeof(short), length);
                this.AccessPaths = Array.CreateInstance(typeof(string), length);


                foreach (PLCDataMDL amdl in this.DataList)
                {
                    this.WatchDataReadItem.SetValue(amdl.ItemID, amdl.UniqueID);
     
                    this.ClientHandles.SetValue(amdl.UniqueID, amdl.UniqueID);

                    CLog.WriteSysLog(amdl.ItemID + "" + amdl.UniqueID.ToString());

                   // if (ShowLogEvent != null)
                    //    ShowLogEvent("设备编号" + string.Format("{0}--{1}", amdl.ItemID, amdl.UniqueID)+"已经加载", EventArgs.Empty);
                // CLog.WriteStationLog(string.Format("{0}--{1}", amdl.ItemID, amdl.UniqueID), "设备编号");
                }
                if (this.DataItemNum > 0)
                {
                    this.MyOPCItemCollIn.AddItems(this.DataItemNum, ref this.WatchDataReadItem, ref this.ClientHandles, out this.ServerHandlesIn, out this.ErrorsIn, this.RequestedDataTypes, this.AccessPaths);
                    this.MyOPCGroupIn.IsSubscribed = true;
                }

             
                // this.MyOPCServer

                this.MyOPCGroupIn.DataChange += new DIOPCGroupEvent_DataChangeEventHandler(MyOPCGroupIn_DataChange);
               // new ComAwareEventInfo(typeof(DIOPCGroupEvent_Event), "DataChange").AddEventHandler(this.MyOPCGroupIn, new DIOPCGroupEvent_DataChangeEventHandler(this.MyOPCGroupIn_DataChange));
                //new ComAwareEventInfo(typeof(DIOPCGroupEvent_Event), "AsyncWriteComplete").AddEventHandler(this.MyOPCGroupIn, new DIOPCGroupEvent_AsyncWriteCompleteEventHandler(this.MyOPCGroupIn_AsyncWriteComplete));

                if (ShowLogEvent != null)
                    ShowLogEvent("设备编号2消息通知已注册！", EventArgs.Empty);
                
                return true;
            }
            catch (Exception exception)
            {
                CLog.WriteErrLogInTrace(string.Format("在连接OPC服务器时出错，{0}", exception.Message));
                return false;
            }
        }

        public void OPCServer_Disconnnect()
        {
            this.MyOPCGroupColl.RemoveAll();
            this.MyOPCServer.Disconnect();
            this.MyOPCItemCollIn = null;
            this.MyOPCGroupIn = null;
            this.MyOPCGroupColl = null;
            this.MyOPCServer = null;
            GC.Collect();
        }

        //private void ProcessStationAllData(PLCDataMDL data)
        //{
        //    Exception exception;
        //    Predicate<PLCDataMDL> match = null;
        //    Predicate<PLCDataMDL> predicate2 = null;
        //    Predicate<PLCDataMDL> predicate3 = null;
        //    try
        //    {
        //        string stationID = string.Format(@"Com\{0}", data.StationID);
        //        string productType = string.Empty;
        //        PLCDataMDL item = null;
        //        List<PLCDataMDL> list = new List<PLCDataMDL>();
        //        if (match == null)
        //        {
        //            match = p => (p.StationID == data.StationID) && p.IsKey;
        //        }
        //        item = this.DataList.Find(match);
        //        if (predicate2 == null)
        //        {
        //            predicate2 = p => ((p.StationID == data.StationID) && !p.IsKey) && (p.DBFieldName != string.Empty);
        //        }
        //        list = this.DataList.FindAll(predicate2);
        //        CLog.WriteStationLog(stationID, string.Format("----{0} Begin----", data.ItemID));
        //        if (data.StationID == "ST290")
        //        {
        //        }
        //        if (item != null)
        //        {
        //            string str3 = string.Empty;
        //            string dBFieldName = item.DBFieldName;
        //            string itemID = item.ItemID;
        //            ResultL2DAL tldal = new ResultL2DAL();
        //            Array array = null;
        //            if (data.StationID == "ST360")
        //            {
        //                list.RemoveAll(p => !p.IsKey);
        //            }
        //            list.Add(item);
        //            array = null;
        //            array = this.SyncRead(list);
        //            if (array == null)
        //            {
        //                array = this.SyncRead(list);
        //                CLog.WriteStationLog(stationID, "第二次读数据");
        //            }
        //            if (array != null)
        //            {
        //                str3 = Regex.Replace(array.GetValue(array.Length).ToString(), "[^0-9^a-z^A-Z]", "");
        //                if (str3.Trim() == string.Empty)
        //                {
        //                    CLog.WriteStationLog(stationID, string.Format("{0}为空", itemID));
        //                }
        //                CLog.WriteStationLog(stationID, string.Format("=>{0}", str3));
        //                for (int i = 1; i < array.Length; i++)
        //                {
        //                    PLCDataMDL amdl2 = list[i - 1];
        //                    amdl2.DataValue = array.GetValue(i).ToString().Trim();
        //                    CLog.WriteStationLog(stationID, string.Format("=>{0}={1}", amdl2.DBFieldName, amdl2.DataValue));
        //                    if ((str3.Trim() != string.Empty) && (amdl2.ItemID != "ST400.BracketCode"))
        //                    {
        //                        if (amdl2.StationID == "ST360")
        //                        {
        //                            amdl2.DataValue = amdl2.DataValue.Replace(",", "");
        //                            amdl2.DataValue = Regex.Replace(amdl2.DataValue, "[^0-9^a-z^A-Z^.^-]", "");
        //                        }
        //                        if (amdl2.DataValue != string.Empty)
        //                        {
        //                            double num3;
        //                            try
        //                            {
        //                                string[] strArray;
        //                                if ((amdl2.ItemID == "ST160.ALeakage") || (amdl2.ItemID == "ST160.BLeakage"))
        //                                {
        //                                    if (amdl2.DataValue.Length <= 15)
        //                                    {
        //                                        goto Label_0816;
        //                                    }
        //                                    amdl2.DataValue = amdl2.DataValue.Replace("\t", "");
        //                                    strArray = amdl2.DataValue.Split(new char[] { ':' });
        //                                    amdl2.DataValue = Regex.Replace(strArray[4], "[^-^.^0-9]", "");
        //                                }
        //                                else if ((amdl2.ItemID == "ST170.ALeakage") || (amdl2.ItemID == "ST170.BLeakage"))
        //                                {
        //                                    if (amdl2.DataValue.Length <= 7)
        //                                    {
        //                                        goto Label_0816;
        //                                    }
        //                                    amdl2.DataValue = amdl2.DataValue.Replace("\t", "");
        //                                    strArray = amdl2.DataValue.Split(new char[] { ':' });
        //                                    amdl2.DataValue = Regex.Replace(strArray[4], "[^-^.^0-9]", "");
        //                                }
        //                                else if (amdl2.ItemID == "ST177.Leakage")
        //                                {
        //                                    if (amdl2.DataValue.Length <= 7)
        //                                    {
        //                                        goto Label_0816;
        //                                    }
        //                                    amdl2.DataValue = amdl2.DataValue.Replace("\t", "");
        //                                    strArray = amdl2.DataValue.Split(new char[] { ':' });
        //                                    amdl2.DataValue = Regex.Replace(strArray[4], "[^-^.^0-9]", "");
        //                                }
        //                            }
        //                            catch (Exception exception1)
        //                            {
        //                                exception = exception1;
        //                                CLog.WriteErrLogInTrace(string.Format("在处理泄露值时出错：{0}，{1}.{2}={3}", new object[] { exception.StackTrace, str3, amdl2.DBFieldName, amdl2.DataValue }));
        //                                goto Label_0816;
        //                            }
        //                            if ((amdl2.StationID == "ST180") || (amdl2.StationID == "ST400"))
        //                            {
        //                                if (amdl2.ItemID.Contains("_PF") && (tldal.GetFieldValueByKeyCode(amdl2.DBFieldName, dBFieldName, str3) == "1"))
        //                                {
        //                                    goto Label_0816;
        //                                }
        //                            }
        //                            else if (amdl2.StationID == "ST340")
        //                            {
        //                                double result = 0.0;
        //                                if (double.TryParse(amdl2.DataValue, out result) && ((((result == 0.0) || (result > 33185000.0)) || (result < 300.0)) || (amdl2.ItemID.Contains("Angle") && ((result > 3300000.0) || (result < 300.0)))))
        //                                {
        //                                    goto Label_0816;
        //                                }
        //                            }
        //                            else if ((amdl2.StationID == "ST150") && (amdl2.DataValue == "0"))
        //                            {
        //                                goto Label_0816;
        //                            }
        //                            if (((amdl2.DBFieldType == 1) && (amdl2.DecPoint > 0)) && double.TryParse(amdl2.DataValue, out num3))
        //                            {
        //                                amdl2.DataValue = (double.Parse(amdl2.DataValue) / Math.Pow(10.0, (double) amdl2.DecPoint)).ToString();
        //                            }
        //                            if ((amdl2.DBFieldType == 1) || (amdl2.DBFieldType == 2))
        //                            {
        //                                if (tldal.Exist(dBFieldName, str3))
        //                                {
        //                                    if (tldal.UpdateByField(amdl2.DBFieldName, amdl2.DataValue, amdl2.DBFieldType, dBFieldName, str3) <= 0)
        //                                    {
        //                                        CLog.WriteStationLog(stationID, string.Format("P.{0}的{1}更新为{2}失败", str3, amdl2.DBFieldName, amdl2.DataValue));
        //                                    }
        //                                }
        //                                else if (tldal.InsertCode(dBFieldName, str3) <= 0)
        //                                {
        //                                    CLog.WriteStationLog(stationID, string.Format("P.新增{0}的{1}更新为{2}失败", str3, amdl2.DBFieldName, amdl2.DataValue));
        //                                }
        //                                else if (tldal.UpdateByField(amdl2.DBFieldName, amdl2.DataValue, amdl2.DBFieldType, dBFieldName, str3) <= 0)
        //                                {
        //                                    CLog.WriteStationLog(stationID, string.Format("P.{0}的{1}更新为{2}失败", str3, amdl2.DBFieldName, amdl2.DataValue));
        //                                }
        //                            }
        //                        Label_0816:;
        //                        }
        //                    }
        //                }
        //                if (data.StationID == "ST360")
        //                {
        //                    try
        //                    {
        //                        array = null;
        //                        array = this.SyncRead("ST360.ProductType");
        //                        if ((array != null) && (array.GetValue(1) != null))
        //                        {
        //                            productType = array.GetValue(1).ToString();
        //                            new ResultL2DAL().UpdateProductNameByKeyCode("brakecode", str3, productType);
        //                        }
        //                        DigiForce9130 force = new DigiForce9130("10.176.65.231", 0x20ac);
        //                        DigiForceMDL mdl = null;
        //                        if (force.Connect())
        //                        {
        //                            for (int j = 0; j < 10; j++)
        //                            {
        //                                if (mdl == null)
        //                                {
        //                                    Thread.Sleep(100);
        //                                    mdl = force.GetGeneralCurveData();
        //                                }
        //                                else
        //                                {
        //                                    break;
        //                                }
        //                            }
        //                            if (mdl != null)
        //                            {
        //                                if (tldal.UpdateDigiForceByKeyCode(dBFieldName, str3, mdl) <= 0)
        //                                {
        //                                    CLog.WriteStationLog(data.StationID, string.Format("{0}的DigiForce数据更新失败", str3));
        //                                }
        //                            }
        //                            else
        //                            {
        //                                CLog.WriteStationLog(data.StationID, string.Format("{0}的DigiForce数据获取失败", str3));
        //                            }
        //                            force.DisConnect();
        //                        }
        //                    }
        //                    catch (Exception exception2)
        //                    {
        //                        exception = exception2;
        //                        CLog.WriteErrLogInTrace(exception.Message);
        //                    }
        //                }
        //                this.CheckLastStationData(item, str3, data);
        //                List<PLCDataMDL> list2 = new List<PLCDataMDL>();
        //                PLCDataMDL amdl3 = new PLCDataMDL {
        //                    ItemID = string.Format("{0}.ControlPass", data.StationID)
        //                };
        //                if (data.StationID == "ST360")
        //                {
        //                    if (predicate3 == null)
        //                    {
        //                        predicate3 = p => ((p.StationID == data.StationID) && !p.IsKey) && (p.DBFieldName != string.Empty);
        //                    }
        //                    list.AddRange(this.DataList.FindAll(predicate3));
        //                }
        //                else if (data.StationID == "ST400")
        //                {
        //                    list.Remove(list.Find(p => p.ItemID == "ST400.BracketCode"));
        //                }
        //                if (tldal.CheckStationResult(dBFieldName, str3, "", data.StationID, list))
        //                {
        //                    amdl3.DataValue = "1";
        //                }
        //                else
        //                {
        //                    amdl3.DataValue = "0";
        //                    CLog.WriteStationLog(stationID, string.Format("{0}在{1}工位的数据不完整，不与放行", str3, data.StationID));
        //                }
        //                list2.Add(amdl3);
        //                if ((((data.StationID == "ST150") || (data.StationID == "ST180")) || ((data.StationID == "ST290") || (data.StationID == "ST340"))) || (data.StationID == "ST360"))
        //                {
        //                    this.AsycnWriter(list2);
        //                }
        //            }
        //            else
        //            {
        //                CLog.WriteStationLog(stationID, string.Format("获取{0}的所有检测项的值为null", str3));
        //            }
        //        }
        //        else
        //        {
        //            CLog.WriteStationLog(stationID, string.Format("找不到{0}的KeyField", data.ItemID));
        //        }
        //        CLog.WriteStationLog(stationID, string.Format("----{0} End----", data.ItemID));
        //    }
        //    catch (Exception exception3)
        //    {
        //        exception = exception3;
        //        CLog.WriteErrLogInTrace(string.Format("在处理{0}的Complete数据时出错，{1}", data.StationID, exception.Message));
        //    }
        //}

        public void SyncRead()
        {
            Array array2;
            Array array3;
            object obj2;
            object obj3;
            short source = 2;
            int length = this.ServerHandlesIn.Length + 1;
            Array serverHandles = Array.CreateInstance(typeof(int), length);
            serverHandles.SetValue(Convert.ToInt32(this.ServerHandlesIn.GetValue(1)), 1);
            serverHandles.SetValue(Convert.ToInt32(this.ServerHandlesIn.GetValue(2)), 2);
            serverHandles.SetValue(Convert.ToInt32(this.ServerHandlesIn.GetValue(3)), 3);
            serverHandles.SetValue(Convert.ToInt32(this.ServerHandlesIn.GetValue(4)), 4);
            this.MyOPCGroupIn.SyncRead(source, this.ServerHandlesIn.Length, ref serverHandles, out array2, out array3, out obj2, out obj3);
        }

        public Array SyncRead(List<PLCDataMDL> list)
        {
            try
            {
                Array array2;
                Array array3;
                object obj2;
                object obj3;
                short source = 2;
                int length = 1 + list.Count;
                Array serverHandles = Array.CreateInstance(typeof(int), length);
                for (int i = 0; i < list.Count; i++)
                {
                    PLCDataMDL data = list[i];
                    serverHandles.SetValue(Convert.ToInt32(this.ServerHandlesIn.GetValue(this.DataList.Find(p => p.ItemID == data.ItemID).UniqueID)), (int) (i + 1));
                }
                this.MyOPCGroupIn.SyncRead(source, length - 1, ref serverHandles, out array2, out array3, out obj2, out obj3);
                return array2;
            }
            catch (Exception exception)
            {
                CLog.WriteErrLogInTrace(exception.Message);
                return null;
            }
        }

        public Array SyncRead(string itemID)
        {
            Predicate<PLCDataMDL> match = null;
            try
            {
                Array array2;
                Array array3;
                object obj2;
                object obj3;
                short source = 2;
                int length = 2;
                Array serverHandles = Array.CreateInstance(typeof(int), length);
                if (match == null)
                {
                    match = p => p.ItemID == itemID;
                }
                serverHandles.SetValue(Convert.ToInt32(this.ServerHandlesIn.GetValue(this.DataList.Find(match).UniqueID)), 1);
                this.MyOPCGroupIn.SyncRead(source, length - 1, ref serverHandles, out array2, out array3, out obj2, out obj3);
                return array2;
            }
            catch (Exception exception)
            {
                CLog.WriteErrLogInTrace(exception.Message);
                return null;
            }
        }
    }
}

