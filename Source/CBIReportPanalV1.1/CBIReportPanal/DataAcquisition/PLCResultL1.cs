using DAL;
namespace DataGather
{
    using COMM;
    //using DAL;
   // using SQLiteDAL;
    using MDL;
    using OPCAutomation;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;
    using System.Threading;

    public class PLCResultL1
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

        public ProductLineCaculator plineCaculator;

        public PLCResultL1()
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

        public PLCResultL1(string opcName, string opcIP, string groupName, List<PLCDataMDL> dataList)
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

        public void AsycnWriter()
        {
            try
            {
                Array array3;
                int num2;
                List<object> list = new List<object> { 0, "5", "6" };
                int length = 3;
                Array serverHandles = Array.CreateInstance(typeof(int), length);
                Array values = list.ToArray();
                serverHandles.SetValue(Convert.ToInt32(this.ServerHandlesIn.GetValue(1)), 1);
                serverHandles.SetValue(Convert.ToInt32(this.ServerHandlesIn.GetValue(2)), 2);
                this.MyOPCGroupIn.AsyncWrite(length - 1, ref serverHandles, ref values, out array3, 1, out num2);
            }
            catch (Exception exception)
            {
                CLog.WriteErrLogInTrace(string.Format("在往OPC写数据时出错，{0}", exception.Message));
            }
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
        //    string[] strArray = null;
        //    string[] strArray2 = null;
        //    Random random = new Random();
        //    ResultL1DAL tldal = new ResultL1DAL();
        //    try
        //    {
        //        if (data.StationID == "ST160")
        //        {
        //            strArray = new string[] { "st150_pf" };
        //            strArray2 = new string[] { "1" };
        //        }
        //        else
        //        {
        //            string[] strArray3;
        //            double num3;
        //            if ((data.StationID == "ST180A") || (data.StationID == "ST180B"))
        //            {
        //                strArray = new string[] { "st160_t", "st160_a", "st170" };
        //                strArray3 = new string[3];
        //                num3 = Convert.ToDouble(random.Next(100, 110)) / 10.0;
        //                strArray3[0] = num3.ToString();
        //                num3 = Convert.ToDouble(random.Next(900, 0x44c)) / 10.0;
        //                strArray3[1] = num3.ToString();
        //                strArray3[2] = random.Next(5, 14).ToString();
        //                strArray2 = strArray3;
        //            }
        //            else if (data.StationID == "ST210")
        //            {
        //                strArray = new string[] { "st180" };
        //                strArray2 = new string[] { random.Next(80, 120).ToString() };
        //            }
        //            else if ((data.StationID == "ST250A") || (data.StationID == "ST250B"))
        //            {
        //                strArray = new string[] { "st210", "st210_a" };
        //                strArray3 = new string[2];
        //                num3 = Convert.ToDouble(random.Next(100, 120)) / 10.0;
        //                strArray3[0] = num3.ToString();
        //                strArray3[1] = random.Next(0x19, 0x23).ToString();
        //                strArray2 = strArray3;
        //            }
        //            else if (data.StationID == "ST270")
        //            {
        //                strArray = new string[] { "st250_b", "st250_l", "st250_p", "st240_b", "st240_d", "st240_o", "st250_r" };
        //                strArray3 = new string[7];
        //                num3 = Convert.ToDouble(random.Next(0x157c, 0x1770)) / 10000.0;
        //                strArray3[0] = num3.ToString();
        //                strArray3[1] = random.Next(10, 12).ToString();
        //                num3 = Convert.ToDouble(random.Next(100, 110)) / 10.0;
        //                strArray3[2] = num3.ToString();
        //                num3 = Convert.ToDouble(random.Next(280, 310)) / 1000.0;
        //                strArray3[3] = num3.ToString();
        //                num3 = Convert.ToDouble(random.Next(500, 600)) / 1000.0;
        //                strArray3[4] = num3.ToString();
        //                num3 = Convert.ToDouble(random.Next(800, 900)) / 1000.0;
        //                strArray3[5] = num3.ToString();
        //                num3 = Convert.ToDouble(random.Next(0x5dc, 0x640)) / 10000.0;
        //                strArray3[6] = num3.ToString();
        //                strArray2 = strArray3;
        //            }
        //            else if (data.StationID == "ST420")
        //            {
        //                strArray = new string[] { "st390_t1", "st390_a1", "st390_t2", "st390_a2" };
        //                strArray3 = new string[4];
        //                num3 = Convert.ToDouble(random.Next(0xc1c, 0xc80)) / 100.0;
        //                strArray3[0] = num3.ToString();
        //                strArray3[1] = Convert.ToDouble((int) (random.Next(0xa28, 0xa8c) / 100)).ToString();
        //                num3 = Convert.ToDouble(random.Next(0xc1c, 0xc80)) / 100.0;
        //                strArray3[2] = num3.ToString();
        //                num3 = Convert.ToDouble(random.Next(0xa8c, 0xaf0)) / 100.0;
        //                strArray3[3] = num3.ToString();
        //                strArray2 = strArray3;
        //            }
        //            else if (data.StationID == "ST440")
        //            {
        //                strArray = new string[] { "st420_xminx1", "st420_xminy1", "st420_xmaxx1", "st420_xmaxy1", "st420_yminx1", "st420_yminy1", "st420_ymaxx1", "st420_ymaxy1", "st420_xminx2", "st420_xminy2", "st420_xmaxx2", "st420_xmaxy2", "st420_yminx2", "st420_yminy2", "st420_ymaxx2", "st420_ymaxy2" };
        //                strArray3 = new string[0x10];
        //                num3 = Convert.ToDouble(random.Next(-4550, -4550)) / 1000.0;
        //                strArray3[0] = num3.ToString();
        //                num3 = Convert.ToDouble(random.Next(0x1b58, 0x1bbc)) / 1000.0;
        //                strArray3[1] = num3.ToString();
        //                strArray3[2] = "0";
        //                num3 = Convert.ToDouble(random.Next(0x44c, 0x4b0)) / 10.0;
        //                strArray3[3] = num3.ToString();
        //                num3 = Convert.ToDouble(random.Next(-3500, -3000)) / 1000.0;
        //                strArray3[4] = num3.ToString();
        //                num3 = Convert.ToDouble(random.Next(0xe10, 0xe74)) / 1000.0;
        //                strArray3[5] = num3.ToString();
        //                strArray3[6] = "0";
        //                num3 = Convert.ToDouble(random.Next(0x44c, 0x4b0)) / 10.0;
        //                strArray3[7] = num3.ToString();
        //                num3 = Convert.ToDouble(random.Next(-1100, -1000)) / 100.0;
        //                strArray3[8] = num3.ToString();
        //                num3 = Convert.ToDouble(random.Next(800, 900)) / 1000.0;
        //                strArray3[9] = num3.ToString();
        //                strArray3[10] = "0";
        //                num3 = Convert.ToDouble(random.Next(0x206c, 0x20d0)) / 100.0;
        //                strArray3[11] = num3.ToString();
        //                num3 = Convert.ToDouble(random.Next(-1152, -1000)) / 100.0;
        //                strArray3[12] = num3.ToString();
        //                num3 = Convert.ToDouble(random.Next(800, 900)) / 1000.0;
        //                strArray3[13] = num3.ToString();
        //                strArray3[14] = "0";
        //                strArray3[15] = (Convert.ToDouble(random.Next(800, 900)) / 1000.0).ToString();
        //                strArray2 = strArray3;
        //            }
        //        }
        //        for (int i = 0; i < strArray.Length; i++)
        //        {
        //            str = tldal.GetFieldValueByKeyCode(strArray[i], keyItemData.DBFieldName, barCode);
        //            if (((str == string.Empty) || (str == "0")) && (tldal.UpdateByField(strArray[i], strArray2[i], 1, keyItemData.DBFieldName, barCode) > 0))
        //            {
        //                CLog.WriteStationLog(data.StationID, string.Format("更新{0}.{1}={2}", barCode, strArray[i], strArray2[i]));
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        CLog.WriteStationLog(data.StationID, exception.Message);
        //    }
        //}


        //private void DataChangeThreadFun(object param)
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
        //                ResultL1DAL tldal;
        //                CodeLine1DAL linedal;
        //                int num3;
        //                PLCDataMDL amdl6;
        //                Predicate<PLCDataMDL> match = null;
        //                Predicate<PLCDataMDL> predicate2 = null;
        //                Predicate<PLCDataMDL> predicate3 = null;
        //                PLCDataMDL data = null;
        //                int uniqueID = int.Parse(opcClientHandles.GetValue(i).ToString());
        //                if (BaseVariable.LineID == "L1")
        //                {
        //                    if (match == null)
        //                    {
        //                        match = p => p.UniqueID == uniqueID;
        //                    }
        //                    data = this.DataList.Find(match);
        //                }
        //                else if (BaseVariable.LineID == "L2")
        //                {
        //                    if (predicate2 == null)
        //                    {
        //                        predicate2 = mdl => mdl.UniqueID == uniqueID;
        //                    }
        //                    data = this.DataList.Find(predicate2);
        //                }
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
        //                    if (data.StationID == "ST160A")
        //                    {
        //                        if ((data.ItemID == "ST160.AComplete") && (data.DataValue.ToLower() == "true"))
        //                        {
        //                            this.ProcessStationAllData(data);
        //                        }
        //                    }
        //                    else if (data.StationID == "ST160B")
        //                    {
        //                        if ((data.ItemID == "ST160.BComplete") && (data.DataValue.ToLower() == "true"))
        //                        {
        //                            this.ProcessStationAllData(data);
        //                        }
        //                    }
        //                    else if (data.StationID == "ST180A")
        //                    {
        //                        if ((data.ItemID == "ST180.AComplete") && (data.DataValue.ToLower() == "true"))
        //                        {
        //                            this.ProcessStationAllData(data);
        //                        }
        //                    }
        //                    else if (data.StationID == "ST180B")
        //                    {
        //                        if ((data.ItemID == "ST180.BComplete") && (data.DataValue.ToLower() == "true"))
        //                        {
        //                            this.ProcessStationAllData(data);
        //                        }
        //                    }
        //                    else if (data.StationID == "ST210")
        //                    {
        //                        if ((data.ItemID == "ST210.Complete") && (data.DataValue.ToLower() == "true"))
        //                        {
        //                            this.ProcessStationAllData(data);
        //                        }
        //                    }
        //                    else if (data.StationID == "ST250A")
        //                    {
        //                        if ((data.ItemID == "ST250.AComplete") && (data.DataValue.ToLower() == "true"))
        //                        {
        //                            this.ProcessStationAllData(data);
        //                        }
        //                    }
        //                    else if (data.StationID == "ST250B")
        //                    {
        //                        if ((data.ItemID == "ST250.BComplete") && (data.DataValue.ToLower() == "true"))
        //                        {
        //                            this.ProcessStationAllData(data);
        //                        }
        //                    }
        //                    else if (data.StationID == "ST270")
        //                    {
        //                        if ((data.ItemID == "ST270.Complete") && (data.DataValue.ToLower() == "true"))
        //                        {
        //                            this.ProcessStationAllData(data);
        //                        }
        //                    }
        //                    else if (data.StationID == "ST390")
        //                    {
        //                        if ((data.ItemID == "ST390.Complete") && (data.DataValue.ToLower() == "true"))
        //                        {
        //                            this.ProcessStationAllData(data);
        //                        }
        //                    }
        //                    else if (data.StationID == "ST420")
        //                    {
        //                        if ((data.ItemID == "ST420.Complete") && (data.DataValue.ToLower() == "true"))
        //                        {
        //                            this.ProcessStationAllData(data);
        //                        }
        //                    }
        //                    else if ((data.StationID == "ST440") && ((data.ItemID == "ST440.Complete") && (data.DataValue.ToLower() == "true")))
        //                    {
        //                        this.ProcessStationAllData(data);
        //                    }
        //                }
        //                catch (Exception exception1)
        //                {
        //                    exception = exception1;
        //                    CLog.WriteErrLogInTrace(string.Format("在处理ST270、ST440的Complete数据时出错，{0}", exception.Message));
        //                }
        //                if (data.StationID == "ST100")
        //                {
        //                    if ((data.ItemID == "ST100.PrintIO") && (data.DataValue.ToLower() == "true"))
        //                    {
        //                        list = new List<ReportEntity>();
        //                        rmdl = BaseVariable.PrinterList.Find(p => (p.LineID == "L1") && (p.Type == 1));
        //                        list.Add(PrinterMan.GetReportEntity(rmdl.CountKey, rmdl.CodeType));
        //                        PrinterMan man = new PrinterMan(rmdl.Name, rmdl.CodeType);
        //                        flag = man.PrinterBarCode(list);
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
        //                            PLCDataMDL item = new PLCDataMDL {
        //                                ItemID = "ST100.AlarmPrintErr",
        //                                DataValue = "1"
        //                            };
        //                            list2.Add(item);
        //                            if (list2.Count > 0)
        //                            {
        //                                this.AsycnWriter(list2);
        //                            }
        //                        }
        //                    }
        //                    else if (((data.ItemID == "ST100.DeviceIn") && (data.DataValue.ToLower() == "true")) && (BaseVariable.SysDebug == "1"))
        //                    {
        //                        amdl2 = new PLCDataMDL();
        //                        amdl3 = new PLCDataMDL();
        //                        list3 = new List<PLCDataMDL>();
        //                        amdl2.ItemID = "ST100.ST110_BarCode";
        //                        amdl2.DataValue = PrinterMan.GetBarCode("C1");
        //                        list3.Add(amdl2);
        //                        amdl3.ItemID = "ST100.ST110_WriteCode";
        //                        amdl3.DataValue = "1";
        //                        list3.Add(amdl3);
        //                        if (list3.Count > 0)
        //                        {
        //                            PublicVariable.plcL1.AsycnWriter(list3);
        //                        }
        //                    }
        //                    goto Label_12EE;
        //                }
        //                if (data.StationID == "ST300")
        //                {
        //                    if ((data.ItemID == "ST300.PrintIO") && (data.DataValue.ToLower() == "true"))
        //                    {
        //                        list = new List<ReportEntity>();
        //                        rmdl = BaseVariable.PrinterList.Find(p => (p.LineID == "L1") && (p.Type == 2));
        //                        list.Add(PrinterMan.GetReportEntity(rmdl.CountKey, rmdl.CodeType));
        //                        flag = new PrinterMan(rmdl.Name, rmdl.CodeType).PrinterBarCode(list);
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
        //                                ItemID = "ST300.AlarmPrintErr",
        //                                DataValue = "1"
        //                            };
        //                            list2.Add(amdl4);
        //                            if (list2.Count > 0)
        //                            {
        //                                this.AsycnWriter(list2);
        //                            }
        //                        }
        //                    }
        //                    else if (((data.ItemID == "ST300.DeviceIn") && (data.DataValue.ToLower() == "true")) && (BaseVariable.SysDebug == "1"))
        //                    {
        //                        amdl2 = new PLCDataMDL();
        //                        amdl3 = new PLCDataMDL();
        //                        list3 = new List<PLCDataMDL>();
        //                        amdl2.ItemID = "ST300.BarCode";
        //                        amdl2.DataValue = PrinterMan.GetBarCode("B1");
        //                        list3.Add(amdl2);
        //                        amdl3.ItemID = "ST300.WriteCode";
        //                        amdl3.DataValue = "1";
        //                        list3.Add(amdl3);
        //                        if (list3.Count > 0)
        //                        {
        //                            PublicVariable.plcL1.AsycnWriter(list3);
        //                        }
        //                    }
        //                    goto Label_12EE;
        //                }
        //                if (data.StationID == "ST370")
        //                {
        //                    if (data.ItemID == "ST390.ST370_BarCode")
        //                    {
        //                        if (data.DataValue.Trim() == string.Empty)
        //                        {
        //                            continue;
        //                        }
        //                        string code = string.Empty;
        //                        tldal = new ResultL1DAL();
        //                        linedal = new CodeLine1DAL();
        //                        PLCDataMDL amdl5 = new PLCDataMDL();
        //                        CodeLineMDL newlyUnWriteCodeByStation = linedal.GetNewlyUnWriteCodeByStation("ST370");
        //                        if ((newlyUnWriteCodeByStation != null) && (newlyUnWriteCodeByStation.Code != null))
        //                        {
        //                            code = newlyUnWriteCodeByStation.Code;
        //                            linedal.UpdateUnWriteCodeByStation("ST370", code);
        //                        }
        //                        if (code.Trim() == string.Empty)
        //                        {
        //                            CLog.WriteStationLog(data.StationID, "ST370对应的卡钳号为空");
        //                            continue;
        //                        }
        //                        if (!tldal.Exist("calipercode", code))
        //                        {
        //                            tldal.InsertCode("calipercode", code);
        //                            CLog.WriteStationLog("ST370", string.Format("支架点新增{0}", code));
        //                        }
        //                        if (tldal.GetBrakeByCaliperCode(code) != string.Empty)
        //                        {
        //                            CLog.WriteStationLog(data.StationID, string.Format("{0}和{1}在ST370已绑定，不与放行", data.DataValue, code));
        //                            continue;
        //                        }
        //                        string caliperByBrakeCode = tldal.GetCaliperByBrakeCode(data.DataValue);
        //                        if (caliperByBrakeCode != string.Empty)
        //                        {
        //                            CLog.WriteStationLog(data.StationID, string.Format("{0}和{1}在ST370已绑定，不与放行", caliperByBrakeCode, data.DataValue));
        //                            continue;
        //                        }
        //                        num3 = tldal.UpdateByField("brakecode", data.DataValue, "calipercode", code);
        //                        amdl5.ItemID = "ST390.ST370_ControlPass";
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
        //                    goto Label_12EE;
        //                }
        //                if (data.StationID == "ST420")
        //                {
        //                    data.DataValue = data.DataValue.Replace(",", "");
        //                    data.DataValue = Regex.Replace(data.DataValue, "[^0-9^a-z^A-Z^.^-]", "");
        //                    goto Label_12EE;
        //                }
        //                if (!(data.StationID == "ST440") || (!(data.ItemID == "ST440.Complete") || !(data.DataValue.ToLower() == "true")))
        //                {
        //                    goto Label_12EE;
        //                }
        //                bool flag2 = true;
        //                string str3 = string.Empty;
        //                string str4 = string.Empty;
        //                string brakeCode = string.Empty;
        //                string productType = string.Empty;
        //                Array array3 = null;
        //                linedal = new CodeLine1DAL();
        //                tldal = new ResultL1DAL();
        //                str3 = linedal.GetLastBarCodeOfST440();
        //                CLog.WriteStationLog(data.StationID, string.Format("ST430扫描条码为{0}", str3));
        //                if (tldal.GetFieldValueByKeyCode("repaired", "calipercode", str3) != "1")
        //                {
        //                    array3 = this.SyncRead("ST440.BarCode");
        //                    if (array3 != null)
        //                    {
        //                        brakeCode = array3.GetValue(1).ToString();
        //                    }
        //                    else
        //                    {
        //                        CLog.WriteStationLog(data.StationID, string.Format("{0}为空", "ST440.BarCode"));
        //                    }
        //                    str4 = tldal.GetCaliperByBrakeCode(brakeCode);
        //                    CLog.WriteStationLog(data.StationID, string.Format("支架对应卡钳为 {0}，支架号{1}", str4, brakeCode));
        //                    if (!(str3 != str4))
        //                    {
        //                        goto Label_10F6;
        //                    }
        //                    CLog.WriteStationLog(data.StationID, string.Format("{0}对应的扫描卡钳号{1}与绑定卡钳号{2}不一致", brakeCode, str3, str4));
        //                    if (BaseVariable.DataCheckOut == "0")
        //                    {
        //                        goto Label_10F6;
        //                    }
        //                    list2 = new List<PLCDataMDL>();
        //                    amdl6 = new PLCDataMDL {
        //                        ItemID = "ST440.AlarmBarCodeCheckErr",
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
        //            Label_10F6:
        //                array3 = this.SyncRead("ST440.ProductType");
        //                if (array3 != null)
        //                {
        //                    productType = array3.GetValue(1).ToString();
        //                }
        //                else
        //                {
        //                    CLog.WriteStationLog(data.StationID, string.Format("{0}为空", "ST440.ProductType"));
        //                }
        //                if (!tldal.UpdateProductNameByKeyCode("calipercode", str3, productType))
        //                {
        //                    CLog.WriteStationLog(data.StationID, string.Format("更新{0}产品名为{1}失败", str3, productType));
        //                }
        //                flag2 = tldal.CheckAllResult("calipercode", str3, productType);
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
        //                        bracketByCaliperCode = PrinterMan.GetBracketCode("215");
        //                    }
        //                    else
        //                    {
        //                        CLog.WriteStationLog(data.StationID, string.Format("卡钳{0}已刻蚀{1}", str3, bracketByCaliperCode));
        //                        bracketByCaliperCode = bracketByCaliperCode.Substring(3);
        //                    }
        //                    amdl7.ItemID = "ST440.BracketCode";
        //                    amdl7.DataValue = bracketByCaliperCode;
        //                    list5.Add(amdl7);
        //                    amdl8.ItemID = "ST440.Marking";
        //                    amdl8.DataValue = "1";
        //                    list5.Add(amdl8);
        //                    this.AsycnWriter(list5);
        //                }
        //                else
        //                {
        //                    list2 = new List<PLCDataMDL>();
        //                    amdl6 = new PLCDataMDL {
        //                        ItemID = "ST440.AlarmResultNOK",
        //                        DataValue = "1"
        //                    };
        //                    list2.Add(amdl6);
        //                    if (list2.Count > 0)
        //                    {
        //                        this.AsycnWriter(list2);
        //                    }
        //                    CLog.WriteStationLog(data.StationID, string.Format("{0}的检测结果不合格", str3));
        //                }
        //            Label_12EE:
        //                if (((data.DataValue.Trim() != string.Empty) && ((data.DBFieldName != string.Empty) && !data.IsKey)) && (data.StationID != "ST420"))
        //                {
        //                    string[] strArray = data.DBFieldName.Split(new char[] { ',' });
        //                    PLCDataMDL keyItemData = null;
        //                    if (predicate3 == null)
        //                    {
        //                        predicate3 = p => (p.StationID == data.StationID) && p.IsKey;
        //                    }
        //                    keyItemData = this.DataList.Find(predicate3);
        //                    if (keyItemData != null)
        //                    {
        //                        num3 = 0;
        //                        string str8 = string.Empty;
        //                        string dBFieldName = keyItemData.DBFieldName;
        //                        string itemID = keyItemData.ItemID;
        //                        ResultL1DAL tldal2 = new ResultL1DAL();
        //                        array3 = this.SyncRead(itemID);
        //                        if (array3 != null)
        //                        {
        //                            str8 = Regex.Replace(array3.GetValue(1).ToString(), "[^0-9^a-z^A-Z]", "");
        //                        }
        //                        else
        //                        {
        //                            CLog.WriteStationLog(data.StationID, string.Format("{0}为空", itemID));
        //                        }
        //                        if (str8.Trim() != string.Empty)
        //                        {
        //                            string[] strArray2;
        //                            int num4;
        //                            CLog.WriteStationLog(data.StationID, string.Format("=>{0}.Update {1}={2}", str8, data.DBFieldName, data.DataValue));
        //                            try
        //                            {
        //                                string str11;
        //                                if (data.ItemID == "ST160.ALeakage")
        //                                {
        //                                    if (data.DataValue.Length <= 20)
        //                                    {
        //                                        continue;
        //                                    }
        //                                    data.DataValue = data.DataValue.Replace("\t", "");
        //                                    strArray2 = data.DataValue.Split(new char[] { ' ' });
        //                                    str11 = string.Empty;
        //                                    num4 = 0;
        //                                    while (num4 < strArray2.Length)
        //                                    {
        //                                        if (strArray2[num4] != "")
        //                                        {
        //                                            str11 = str11 + strArray2[num4] + ":";
        //                                        }
        //                                        num4++;
        //                                    }
        //                                    strArray2 = str11.Split(new char[] { ':' });
        //                                    data.DataValue = strArray2[1].ToUpper().Replace("K", "").Replace("PA/S", "");
        //                                }
        //                                else if (data.ItemID == "ST160.BLeakage")
        //                                {
        //                                    if (data.DataValue.Length <= 20)
        //                                    {
        //                                        continue;
        //                                    }
        //                                    strArray2 = data.DataValue.Split(new char[] { ':' });
        //                                    data.DataValue = strArray2[3].Replace(" ", "").ToUpper().Replace("K", "").Replace("PA/S", "");
        //                                }
        //                                else if (data.ItemID == "ST180.ALeakage")
        //                                {
        //                                    if (data.DataValue.Length <= 20)
        //                                    {
        //                                        continue;
        //                                    }
        //                                    strArray2 = data.DataValue.Split(new char[] { ':' });
        //                                    data.DataValue = strArray2[strArray2.Length - 1].Replace(" ", "").ToUpper().Replace("K", "").Replace("PA", "");
        //                                }
        //                                else if (data.ItemID == "ST180.BLeakage")
        //                                {
        //                                    if (data.DataValue.Length <= 20)
        //                                    {
        //                                        continue;
        //                                    }
        //                                    strArray2 = data.DataValue.Split(new char[] { ':' });
        //                                    data.DataValue = strArray2[strArray2.Length - 1].Replace(" ", "").ToUpper().Replace("K", "").Replace("PA", "");
        //                                }
        //                                else if (data.ItemID == "ST210.Result")
        //                                {
        //                                    if (data.DataValue.Length <= 20)
        //                                    {
        //                                        continue;
        //                                    }
        //                                    strArray2 = data.DataValue.Replace("\r", "").Replace("\n", "").Split(new char[] { ' ' });
        //                                    str11 = string.Empty;
        //                                    num4 = 0;
        //                                    while (num4 < strArray2.Length)
        //                                    {
        //                                        if (strArray2[num4] != "")
        //                                        {
        //                                            str11 = str11 + strArray2[num4] + ":";
        //                                        }
        //                                        num4++;
        //                                    }
        //                                    strArray2 = str11.Split(new char[] { ':' });
        //                                    data.DataValue = strArray2[3] + "," + strArray2[8];
        //                                    CLog.WriteStationLog(data.StationID, "伺服机检测结果：" + data.DataValue);
        //                                }
        //                                else if (data.ItemID == "ST250.ALeakage")
        //                                {
        //                                    if (data.DataValue.Length <= 20)
        //                                    {
        //                                        continue;
        //                                    }
        //                                    strArray2 = data.DataValue.Split(new char[] { ':' });
        //                                    strArray2[3] = strArray2[3].ToUpper();
        //                                    data.DataValue = strArray2[3].Replace(" ", "").Replace("BAR", "").Replace("K", "").Replace("PA", "").Replace("/S", "").Replace("\r", "").Replace("\n", "");
        //                                }
        //                                else if (data.ItemID == "ST250.APressure")
        //                                {
        //                                    if (data.DataValue.Length <= 20)
        //                                    {
        //                                        continue;
        //                                    }
        //                                    strArray2 = data.DataValue.Split(new char[] { ':' });
        //                                    strArray2[3] = strArray2[3].ToUpper();
        //                                    data.DataValue = strArray2[3].Replace(" ", "").Replace("BAR", "").Replace("K", "").Replace("PA", "").Replace("/S", "").Replace("\r", "").Replace("\n", "");
        //                                }
        //                                else if (data.ItemID == "ST250.BLeakage")
        //                                {
        //                                    if (data.DataValue.Length <= 20)
        //                                    {
        //                                        continue;
        //                                    }
        //                                    strArray2 = data.DataValue.Split(new char[] { ':' });
        //                                    strArray2[3] = strArray2[3].ToUpper();
        //                                    data.DataValue = strArray2[3].Replace(" ", "").Replace("BAR", "").Replace("K", "").Replace("PA", "").Replace("/S", "").Replace("\r", "").Replace("\n", "");
        //                                }
        //                                else if (data.ItemID == "ST250.BPressure")
        //                                {
        //                                    if (data.DataValue.Length <= 20)
        //                                    {
        //                                        continue;
        //                                    }
        //                                    strArray2 = data.DataValue.Split(new char[] { ':' });
        //                                    strArray2[3] = strArray2[3].ToUpper();
        //                                    data.DataValue = strArray2[3].Replace(" ", "").Replace("BAR", "").Replace("K", "").Replace("PA", "").Replace("/S", "").Replace("\r", "").Replace("\n", "");
        //                                }
        //                            }
        //                            catch (Exception exception3)
        //                            {
        //                                exception = exception3;
        //                                CLog.WriteErrLogInTrace(string.Format("在处理泄露值时出错：{0}，{1}.{2}={3}", new object[] { exception.StackTrace, str8, data.DBFieldName, data.DataValue }));
        //                                continue;
        //                            }
        //                            if ((data.StationID == "ST270") || (data.StationID == "ST440"))
        //                            {
        //                                if (tldal2.GetFieldValueByKeyCode(data.DBFieldName, dBFieldName, str8) == "1")
        //                                {
        //                                    continue;
        //                                }
        //                                if ((data.StationID == "ST440") && (data.ItemID == "ST440.BracketCode"))
        //                                {
        //                                    data.DataValue = "215" + data.DataValue.PadLeft(8, '0');
        //                                    string str12 = tldal2.GetFieldValueByKeyCode(data.DBFieldName, dBFieldName, str8);
        //                                    if (str12 != string.Empty)
        //                                    {
        //                                        CLog.WriteStationLog(data.StationID, string.Format("{0}的总成号{1}已刻蚀", str8, str12));
        //                                        continue;
        //                                    }
        //                                }
        //                            }
        //                            else if ((data.StationID == "ST160") || (data.StationID == "ST390"))
        //                            {
        //                                double result = 0.0;
        //                                if (double.TryParse(data.DataValue, out result) && ((((result == 0.0) || (result > 33185000.0)) || (result < -33185000.0)) || (data.ItemID.Contains("Angle") && ((result > 3300000.0) || (result < -3300000.0)))))
        //                                {
        //                                    continue;
        //                                }
        //                            }
        //                            else if (((data.StationID == "ST250A") || (data.StationID == "ST250B")) && (data.DataValue == "0"))
        //                            {
        //                                continue;
        //                            }
        //                            try
        //                            {
        //                                double num6 = 0.0;
        //                                strArray2 = data.DataValue.Split(new char[] { ',' });
        //                                DetailResultMDL tmdl2 = null;
        //                                DetailResult1DAL resultdal = new DetailResult1DAL();
        //                                num4 = 0;
        //                                while (num4 < strArray2.Length)
        //                                {
        //                                    tmdl2 = new DetailResultMDL {
        //                                        Code = str8,
        //                                        StationID = data.StationID,
        //                                        TestItem = data.DBFieldName.Split(new char[] { ',' })[num4].ToUpper()
        //                                    };
        //                                    if (((data.DBFieldType == 1) && (data.DecPoint > 0)) && double.TryParse(data.DataValue, out num6))
        //                                    {
        //                                        if ((((!(data.DBFieldName == "st240_o") && !(data.DBFieldName == "st240_b")) && ((!(data.DBFieldName == "st240_d") && !(data.DBFieldName == "st250_b")) && !(data.DBFieldName == "st250_r"))) || (num6 >= 2.0)) && (((!(data.DBFieldName == "st390_t1") && !(data.DBFieldName == "st390_t2")) && (!(data.DBFieldName == "st390_a1") && !(data.DBFieldName == "st390_a2"))) || (num6 >= 100.0)))
        //                                        {
        //                                            strArray2[num4] = (double.Parse(strArray2[num4]) / Math.Pow(10.0, (double) data.DecPoint)).ToString();
        //                                        }
        //                                        if (strArray2.Length == 1)
        //                                        {
        //                                            data.DataValue = strArray2[num4];
        //                                        }
        //                                    }
        //                                    tmdl2.Result = strArray2[num4];
        //                                    if (resultdal.InsertData(tmdl2) < 0)
        //                                    {
        //                                        CLog.WriteStationLog(data.StationID, string.Format("新增{0}的详细数据{1}失败", str8, strArray2[num4]));
        //                                    }
        //                                    num4++;
        //                                }
        //                            }
        //                            catch (Exception exception4)
        //                            {
        //                                exception = exception4;
        //                                CLog.WriteErrLogInTrace(exception.Message);
        //                            }
        //                            if ((data.DBFieldType == 1) || (data.DBFieldType == 2))
        //                            {
        //                                if (tldal2.Exist(dBFieldName, str8))
        //                                {
        //                                    num4 = 0;
        //                                    while (num4 < strArray.Length)
        //                                    {
        //                                        if (tldal2.UpdateByField(strArray[num4], data.DataValue.Split(new char[] { ',' })[num4], data.DBFieldType, dBFieldName, str8) <= 0)
        //                                        {
        //                                            CLog.WriteStationLog(data.StationID, string.Format("{0}的{1}更新为{2}失败", str8, strArray[num4], data.DataValue));
        //                                        }
        //                                        num4++;
        //                                    }
        //                                }
        //                                else if (tldal2.InsertCode(dBFieldName, str8) <= 0)
        //                                {
        //                                    CLog.WriteStationLog(data.StationID, string.Format("新增{0}的{1}更新为{2}失败", str8, data.DBFieldName, data.DataValue));
        //                                }
        //                                else
        //                                {
        //                                    for (num4 = 0; num4 < strArray.Length; num4++)
        //                                    {
        //                                        if (tldal2.UpdateByField(strArray[num4], data.DataValue.Split(new char[] { ',' })[num4], data.DBFieldType, dBFieldName, str8) <= 0)
        //                                        {
        //                                            CLog.WriteStationLog(data.StationID, string.Format("{0}的{1}更新为{2}失败", str8, strArray[num4], data.DataValue));
        //                                        }
        //                                    }
        //                                }
        //                                if (((data.DBFieldName == "st250_b") || (data.DBFieldName == "st250_r")) && (tldal2.GetFieldValueByKeyCode("st250_p", "calipercode", str8) == string.Empty))
        //                                {
        //                                    if (tldal2.UpdateByField("st250_p", "10.5", 1, "calipercode", str8) <= 0)
        //                                    {
        //                                        CLog.WriteStationLog(data.StationID, string.Format("{0}的st250_p更新为10.5失败", str8));
        //                                    }
        //                                    else
        //                                    {
        //                                        CLog.WriteStationLog(data.StationID, string.Format("{0}的st250_p更新为10.5成功", str8));
        //                                    }
        //                                }
        //                                if ((data.StationID == "ST440") && (data.ItemID == "ST440.BracketCode"))
        //                                {
        //                                    tldal2.CheckResultState();
        //                                }
        //                                this.CheckLastStationData(keyItemData, str8, data);
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
        //                Predicate<PLCDataMDL> predicate4 = null;
        //                CLog.WriteErrLog(string.Format("在处理OPC数据时出错，{0}", exception.Message));
        //                string str13 = string.Empty;
        //                PLCDataMDL amdl10 = null;
        //                int uniqueID = 0;
        //                if (opcItemValues.GetValue(i) != null)
        //                {
        //                    try
        //                    {
        //                        uniqueID = int.Parse(opcClientHandles.GetValue(i).ToString());
        //                        if (predicate4 == null)
        //                        {
        //                            predicate4 = p => p.UniqueID == uniqueID;
        //                        }
        //                        amdl10 = this.DataList.Find(predicate4);
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

        //private void GetST420Data(PLCDataMDL data, string barCode, string productType, string digiForceData1)
        //{
        //    try
        //    {
        //        string str2 = string.Empty;
        //        DigiForceMDL generalCurveData = null;
        //        DigiForce9130 force = new DigiForce9130("10.176.65.210", 0x20ac);
        //        if (force.Connect())
        //        {
        //            for (int i = 0; i < 2; i++)
        //            {
        //                if (generalCurveData == null)
        //                {
        //                    Thread.Sleep(100);
        //                    generalCurveData = force.GetGeneralCurveData();
        //                }
        //                else
        //                {
        //                    break;
        //                }
        //            }
        //            if (generalCurveData == null)
        //            {
        //                Random random = new Random();
        //                string[] strArray = new string[11];
        //                double num2 = Convert.ToDouble(random.Next(-4550, -4550)) / 1000.0;
        //                strArray[0] = num2.ToString();
        //                strArray[1] = ",";
        //                num2 = Convert.ToDouble(random.Next(0x1b58, 0x1bbc)) / 1000.0;
        //                strArray[2] = num2.ToString();
        //                strArray[3] = ",0,";
        //                num2 = Convert.ToDouble(random.Next(0x44c, 0x4b0)) / 10.0;
        //                strArray[4] = num2.ToString();
        //                strArray[5] = ",";
        //                num2 = Convert.ToDouble(random.Next(-3500, -3000)) / 1000.0;
        //                strArray[6] = num2.ToString();
        //                strArray[7] = ",";
        //                num2 = Convert.ToDouble(random.Next(0xe10, 0xe74)) / 1000.0;
        //                strArray[8] = num2.ToString();
        //                strArray[9] = ",0,";
        //                strArray[10] = (Convert.ToDouble(random.Next(0x44c, 0x4b0)) / 10.0).ToString();
        //                str2 = string.Concat(strArray);
        //            }
        //            else
        //            {
        //                str2 = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}", new object[] { generalCurveData.Xmaxx, generalCurveData.Xmaxy, generalCurveData.Xminx, generalCurveData.Xminy, generalCurveData.Ymaxx, generalCurveData.Ymaxy, generalCurveData.Yminx, generalCurveData.Yminy });
        //            }
        //            CLog.WriteDigiForceLog(string.Format("{0},{1},{2},{3}{4}", new object[] { barCode, productType, str2, digiForceData1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") }));
        //            force.DisConnect();
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        CLog.WriteErrLogInTrace(exception.Message);
        //    }
        //}

        private void MyOPCGroupIn_AsyncWriteComplete(int TransactionID, int NumItems, ref Array ClientHandles, ref Array Errors)
        {
        }

        public virtual void MyOPCGroupIn_DataChange(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {
            OPCDataChangeMDL parameter = new OPCDataChangeMDL(NumItems, ClientHandles, ItemValues);
            ParameterizedThreadStart start = new ParameterizedThreadStart(this.DataChangeThreadFun);
            new Thread(start) { IsBackground = true }.Start(parameter);
        }

        private int ReadEMS()
        {
            try
            {          //异步读产品类型
                Array arrayType = this.SyncRead("ST440.ProductType");

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


        private void DataChangeThreadFun(object param)
        {

           // AcqLineCountMDL acqlineMDL = new AcqLineCountMDL();

            //采集的子单元
            AcqLineItemMDL acqlineMDL = new AcqLineItemMDL();

            acqlineMDL.PLID = "01";

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

                    if (data.StationID == "ST440")
                    {
                        switch (data.ItemID)
                        {
                            //产线计数
                            //case "ST440.PLCCOUNT":
                            //    Int32.TryParse(string.Format("{0}", data.DataValue), out curCount);
                            //    CLog.WriteStationLog(data.StationID, string.Format("{0}={1}", data.ItemID, data.DataValue));
                            //    break;
                            //产品类型
                            case "ST440.TICKUNIT":

                                bool tick1Change = false;

                                Boolean.TryParse(data.DataValue, out tick1Change);

                                if (tick1Change)
                                    curCount = 1;
                                else
                                    curCount = 0;

                                CLog.WriteStationLog(data.StationID, string.Format("{0}={1}", data.ItemID, data.DataValue));

                                break;
                            case "ST440.TICKUNIT2":

                                 bool  tick2Change = false;

                                 Boolean.TryParse(data.DataValue, out tick2Change);

                                 if (tick2Change)
                                    curCount = 1;
                                else
                                    curCount = 0;

                                CLog.WriteStationLog(data.StationID, string.Format("{0}={1}", data.ItemID, data.DataValue));

                                break;

                            //case "ST440.ProductType":
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
                    ;
                ///插入追溯记录  工位是默认的
                AddTraceInfo(acqlineMDL, "ST440", curCount);

                //判断计算器时间
                if (plineCaculator == null)
                {
                    plineCaculator = new ProductLineCaculator();
                    ///初始化EMS编号

                    //ems = ReadEMS();
                    unit = new EMSUnit(ems, DateTime.Now);

                    plineCaculator.ems = unit;

                }



                unit = new EMSUnit(ems, DateTime.Now);
                //////////////////////////////////////////////////////////////////////////

                CLog.WriteStationLog("ST400", string.Format("EMS：{0}={1}", unit.EMS, unit.SetTime.ToLongDateString()));

                //检查是否需要重新加载计算区间
                plineCaculator.CheckReload(DateTime.Now, unit);

                //DateTime acqTime = DateTime.Now;

                //获取当前数据输入的采集区间
                TimeRange range = plineCaculator.GetTimeRangByAcqTime(DateTime.Now);

                ///采集数据创建并设置唯一编号


                acqlineMDL.TGNAME = range.SEQ;
                acqlineMDL.SetTID(DateTime.Now, acqlineMDL.PLID, range.SEQ, "01");
                acqlineMDL.PR_COUNT = 1;
                acqlineMDL.EMS = ems;
                acqlineMDL.START_TIME=
                acqlineMDL.UPDATE_TIME = DateTime.Now;

               // int index = Convert.ToInt32(range.SEQ);
                //////////////////////////////////////////////////////////////////////////
                //Test
                //CLog.WriteStationLog("ST400", string.Format("EMS：{0}={1}", unit.EMS, unit.SetTime.ToLongDateString()));

                //更新采集数据
               // plineCaculator.UpdateAcqData(ref acqlineMDL, index, curCount);




                plineCaculator.UpdateAcqUnitData(ref acqlineMDL);



                CLog.WriteStationLog("ST440", string.Format("BEGIN CHANGE:{0}---{1}", plineCaculator.ems.EMS, acqlineMDL.EMS));

                ///判断是否换型
                if (plineCaculator.IsChangedEMS(acqlineMDL.EMS))
                {
                    //处理换型记录
                    unit.EMS = acqlineMDL.EMS;
                    CLog.WriteStationLog("ST440", string.Format("BEGIN CHANGE:{0}---{1}", plineCaculator.ems.EMS, acqlineMDL.EMS));

                    if (plineCaculator.ProcessAcqLineData(acqlineMDL.PLID, acqlineMDL.UNITID, unit) > 0)
                    {
                        CLog.WriteStationLog("ST440", string.Format("换型成功:{0}---{1}", plineCaculator.ems.EMS, acqlineMDL.EMS));
                    }
                    else
                    {
                        CLog.WriteStationLog("ST440", string.Format("换型失败:{0}---{1}", plineCaculator.ems.EMS, acqlineMDL.EMS));
                    }
                    //更改换型时间

                }
                else
                {
                    //plineCaculator.LoadEMSTime(DateTime.Now);
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



        private void TestAcq()
        {
            int ems = 29;


            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(100);

                if (i == 10)
                {
                    ems += 1;
                    Thread.Sleep(500);
                }

                if (i == 15)
                {
                    ems += 1;
                    Thread.Sleep(500);

                }

                AcqLineItemMDL acqlineMDL = new AcqLineItemMDL();

                EMSUnit unit = null;

                acqlineMDL.PLID = "01";
                //  TimeRange range = plineCaculator.GetTimeRangByAcqTime(DateTime.Now);

                ///采集数据创建并设置唯一编号


                acqlineMDL.TGNAME = "01";
                acqlineMDL.SetTID(DateTime.Now, acqlineMDL.PLID, "01", "01");
                acqlineMDL.PR_COUNT = 1;
                acqlineMDL.EMS = ems;
                acqlineMDL.UPDATE_TIME = DateTime.Now;
                //AddTraceInfo(acqlineMDL, "ST440", 11);

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



                unit = new EMSUnit(ems, DateTime.Now);



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






                //更新采集数据
                // plineCaculator.UpdateAcqData(ref acqlineMDL, index, curCount);
                plineCaculator.UpdateAcqUnitData(ref acqlineMDL);

                CLog.WriteStationLog("ST400", string.Format("更新数据完成：{0}的计算数量已提交", acqlineMDL.PR_COUNT));


                if (plineCaculator.IsChangedEMS(ems))
                {
                    //处理换型记录
                    plineCaculator.ProcessAcqLineData(acqlineMDL.PLID, acqlineMDL.UNITID, unit);

                    CLog.WriteStationLog("ST400", string.Format("换型：{0}", acqlineMDL.PLID));
                    ////更改换型时间
                    //AcqLineDAL updateDal = new AcqLineDAL();
                    //updateDal.UpdateAclineUnitByLastUnit(DateTime.Now, acqlineMDL.PLID);
                }
                else
                {
                    //plineCaculator.LoadEMSTime(unit.SetTime);
                    plineCaculator.LoadEMSTime(DateTime.Now);
                }
            }
        }

        /// <summary>
        /// 添加追溯信息
        /// </summary>
        /// <param name="linfInfo"></param>
        /// <param name="station_id"></param>
        /// <param name="pre_count"></param>
        private void AddTraceInfo(AcqLineItemMDL linfInfo,string station_id, int pre_count)
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
                
                int ret=traceDal.AddAcqTrace(traceInfo);

                if(ret<=1)
                    CLog.WriteStationLog("TRACE_ADD_ERROR", station_id);

            }
            catch (System.Exception ex)
            {
                CLog.WriteStationLog(linfInfo.PLID + "TRACE_ADD_ERROR", ex.Message.ToString());
            }

        }


        public void TestChangeThreadFun(string lineID,int count,int ems)
        {

            CLog.WriteSysLog(lineID);

            AcqLineCountMDL acqlineMDL = new AcqLineCountMDL();

            acqlineMDL.PLID = lineID;

           // CLog.WriteSysLog(acqlineMDL.PLID);

            try
            {

                // 当前采集数量
                int curCount = count;

                //判断计算器时间
                if (plineCaculator == null)
                {
                    plineCaculator = new ProductLineCaculator();
                    plineCaculator.ems = new EMSUnit(ems,DateTime.Now);
                }

                CLog.WriteSysLog("plineCaculator！");

                EMSUnit unit = new EMSUnit(ems, DateTime.Now);

                //检查是否需要重新加载计算区间
                plineCaculator.CheckReload(DateTime.Now, unit);

                DateTime acqTime = DateTime.Now;

                //获取当前数据输入的采集区间
                TimeRange range = plineCaculator.GetTimeRangByAcqTime(acqTime);

                ///采集数据创建并设置唯一编号
                acqlineMDL.TGNMAE = range.SEQ;
                acqlineMDL.START_TIME = range.StartTime;
                acqlineMDL.END_TIME = range.EndTime;
                acqlineMDL.SetTID(DateTime.Now, acqlineMDL.PLID, range.SEQ, "01");
                acqlineMDL.CUR_COUNT = curCount;
                acqlineMDL.EMS = ems;
                int index = Convert.ToInt32(range.SEQ);


                //更新采集数据
                plineCaculator.UpdateAcqData(ref acqlineMDL, index, curCount);

                EMSUnit nuit = new EMSUnit(ems, DateTime.Now);

                if (plineCaculator.IsChangeProduct(nuit))
                {
                    //处理换型记录
                    plineCaculator.ProcessAcqLineData(acqlineMDL.PLID,acqlineMDL.UNITID, nuit);
                    plineCaculator.LoadEMS(nuit);
                }


                CLog.WriteStationLog(acqlineMDL.PLID, string.Format("{0}的计算数量{1}已提交", curCount, DateTime.Now.ToLongDateString()));

            }
            catch (System.Exception ex)
            {
                CLog.WriteStationLog(acqlineMDL.PLID, ex.Message.ToString());
            }
        }



        public bool OPCServer_Connect(int itemNum)
        {
            try
            {
                this.DataItemNum = itemNum;
                //this.MyOPCServer = (OPCServer) Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("28E68F9A-8D75-11D1-8DC3-3C302A000000")));

                this.MyOPCServer = new OPCServer();
                this.MyOPCServer.Connect(this.OPCName, this.OPCIP);
                this.MyOPCGroupColl = this.MyOPCServer.OPCGroups;
                this.MyOPCGroupIn = this.MyOPCGroupColl.Add(this.GroupName);
                this.MyOPCServer.OPCGroups.DefaultGroupIsActive = true;
                this.MyOPCServer.OPCGroups.DefaultGroupDeadband = 0f;
                this.MyOPCServer.OPCGroups.DefaultGroupUpdateRate = 100;
                this.MyOPCGroupIn.UpdateRate = 100;
                this.MyOPCGroupIn.IsSubscribed = true;
                this.MyOPCItemCollIn = this.MyOPCGroupIn.OPCItems;
                int length = this.DataItemNum + 1;
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
                }
                if (this.DataItemNum > 0)
                {
                    this.MyOPCItemCollIn.AddItems(this.DataItemNum, ref this.WatchDataReadItem, ref this.ClientHandles, out this.ServerHandlesIn, out this.ErrorsIn, this.RequestedDataTypes, this.AccessPaths);
                    this.MyOPCGroupIn.IsSubscribed = true;
                }
                this.MyOPCGroupIn.DataChange += new DIOPCGroupEvent_DataChangeEventHandler(MyOPCGroupIn_DataChange);
                //
                //new ComAwareEventInfo(typeof(DIOPCGroupEvent_Event), "DataChange").AddEventHandler(this.MyOPCGroupIn, new DIOPCGroupEvent_DataChangeEventHandler(this.MyOPCGroupIn_DataChange));
                // new ComAwareEventInfo(typeof(DIOPCGroupEvent_Event), "AsyncWriteComplete").AddEventHandler(this.MyOPCGroupIn, new DIOPCGroupEvent_AsyncWriteCompleteEventHandler(this.MyOPCGroupIn_AsyncWriteComplete));
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
            if (this.MyOPCGroupColl!=null)
                this.MyOPCGroupColl.RemoveAll();
            if (this.MyOPCServer != null)
                this.MyOPCServer.Disconnect();
            this.MyOPCItemCollIn = null;
            this.MyOPCGroupIn = null;
            this.MyOPCGroupColl = null;
            this.MyOPCServer = null;
            GC.Collect();
        }

        private void ProcessComDataThreadFun()
        {
            try
            {
                for (int i = 0; i < 1; i++)
                {
                    PLCDataMDL curProcessComData = this.curProcessComData;
                }
            }
            catch (Exception exception)
            {
                CLog.WriteErrLog(string.Format("在处理OPC数据线程时出错，{0}", exception.Message));
            }
        }


        public void ProcessData()
        {
        
        }

        //private void ProcessStationAllData(PLCDataMDL data)
        //{
        //    Exception exception;
        //    Predicate<PLCDataMDL> match = null;
        //    Predicate<PLCDataMDL> predicate2 = null;
        //    try
        //    {
        //        string stationID = string.Format(@"Com\{0}", data.StationID);
        //        string str2 = string.Empty;
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

        //        if (item != null)
        //        {
        //            string str4 = string.Empty;
        //            string dBFieldName = item.DBFieldName;
        //            string itemID = item.ItemID;
        //            ResultL1DAL tldal = new ResultL1DAL();
        //            Array array = null;
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
        //                str4 = Regex.Replace(array.GetValue(array.Length).ToString(), "[^0-9^a-z^A-Z]", "");
        //                if (str4.Trim() == string.Empty)
        //                {
        //                    CLog.WriteStationLog(stationID, string.Format("{0}为空", itemID));
        //                }
        //                CLog.WriteStationLog(stationID, string.Format("=>{0}", str4));
        //                for (int i = 1; i < array.Length; i++)
        //                {
        //                    PLCDataMDL amdl2 = list[i - 1];
        //                    amdl2.DataValue = array.GetValue(i).ToString().Trim();
        //                    CLog.WriteStationLog(stationID, string.Format("=>{0}={1}", amdl2.DBFieldName, amdl2.DataValue));
        //                    if ((str4.Trim() != string.Empty) && (amdl2.ItemID != "ST440.BracketCode"))
        //                    {
        //                        if (amdl2.StationID == "ST420")
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
        //                                string str7;
        //                                int num4;
        //                                if (amdl2.ItemID == "ST160.ALeakage")
        //                                {
        //                                    if (amdl2.DataValue.Length <= 20)
        //                                    {
        //                                        goto Label_0E5A;
        //                                    }
        //                                    amdl2.DataValue = amdl2.DataValue.Replace("\t", "");
        //                                    strArray = amdl2.DataValue.Split(new char[] { ' ' });
        //                                    str7 = string.Empty;
        //                                    num4 = 0;
        //                                    while (num4 < strArray.Length)
        //                                    {
        //                                        if (strArray[num4] != "")
        //                                        {
        //                                            str7 = str7 + strArray[num4] + ":";
        //                                        }
        //                                        num4++;
        //                                    }
        //                                    strArray = str7.Split(new char[] { ':' });
        //                                    amdl2.DataValue = strArray[1].ToUpper().Replace("K", "").Replace("PA/S", "");
        //                                }
        //                                else if (amdl2.ItemID == "ST160.BLeakage")
        //                                {
        //                                    if (amdl2.DataValue.Length <= 20)
        //                                    {
        //                                        goto Label_0E5A;
        //                                    }
        //                                    strArray = amdl2.DataValue.Split(new char[] { ':' });
        //                                    amdl2.DataValue = strArray[3].Replace(" ", "").ToUpper().Replace("K", "").Replace("PA/S", "");
        //                                }
        //                                else if (amdl2.ItemID == "ST180.ALeakage")
        //                                {
        //                                    if (amdl2.DataValue.Length <= 20)
        //                                    {
        //                                        goto Label_0E5A;
        //                                    }
        //                                    strArray = amdl2.DataValue.Split(new char[] { ':' });
        //                                    amdl2.DataValue = strArray[strArray.Length - 1].Replace(" ", "").ToUpper().Replace("K", "").Replace("PA", "");
        //                                }
        //                                else if (amdl2.ItemID == "ST180.BLeakage")
        //                                {
        //                                    if (amdl2.DataValue.Length <= 20)
        //                                    {
        //                                        goto Label_0E5A;
        //                                    }
        //                                    strArray = amdl2.DataValue.Split(new char[] { ':' });
        //                                    amdl2.DataValue = strArray[strArray.Length - 1].Replace(" ", "").ToUpper().Replace("K", "").Replace("PA", "");
        //                                }
        //                                else
        //                                {
        //                                    if (amdl2.ItemID == "ST210.Result")
        //                                    {
        //                                        if (amdl2.DataValue.Length > 20)
        //                                        {
        //                                            string[] strArray2 = amdl2.DBFieldName.Split(new char[] { ',' });
        //                                            strArray = amdl2.DataValue.Replace("\r", "").Replace("\n", "").Split(new char[] { ' ' });
        //                                            str7 = string.Empty;
        //                                            num4 = 0;
        //                                            while (num4 < strArray.Length)
        //                                            {
        //                                                if (strArray[num4] != "")
        //                                                {
        //                                                    str7 = str7 + strArray[num4] + ":";
        //                                                }
        //                                                num4++;
        //                                            }
        //                                            strArray = str7.Split(new char[] { ':' });
        //                                            amdl2.DataValue = strArray[3] + "," + strArray[8];
        //                                            strArray = amdl2.DataValue.Split(new char[] { ',' });
        //                                            for (num4 = 0; num4 < strArray.Length; num4++)
        //                                            {
        //                                                if (tldal.UpdateByField(strArray2[num4], strArray[num4], amdl2.DBFieldType, dBFieldName, str4) <= 0)
        //                                                {
        //                                                    CLog.WriteStationLog(amdl2.StationID, string.Format("Com.{0}的{1}更新为{2}失败", str4, strArray2[num4], strArray[num4]));
        //                                                }
        //                                            }
        //                                        }
        //                                        goto Label_0E5A;
        //                                    }
        //                                    if (amdl2.ItemID == "ST250.ALeakage")
        //                                    {
        //                                        if (amdl2.DataValue.Length <= 20)
        //                                        {
        //                                            goto Label_0E5A;
        //                                        }
        //                                        strArray = amdl2.DataValue.Split(new char[] { ':' });
        //                                        strArray[3] = strArray[3].ToUpper();
        //                                        amdl2.DataValue = strArray[3].Replace(" ", "").Replace("BAR", "").Replace("K", "").Replace("PA", "").Replace("/S", "").Replace("\r", "").Replace("\n", "");
        //                                    }
        //                                    else if (amdl2.ItemID == "ST250.APressure")
        //                                    {
        //                                        if (amdl2.DataValue.Length <= 20)
        //                                        {
        //                                            goto Label_0E5A;
        //                                        }
        //                                        strArray = amdl2.DataValue.Split(new char[] { ':' });
        //                                        strArray[3] = strArray[3].ToUpper();
        //                                        amdl2.DataValue = strArray[3].Replace(" ", "").Replace("BAR", "").Replace("K", "").Replace("PA", "").Replace("/S", "").Replace("\r", "").Replace("\n", "");
        //                                    }
        //                                    else if (amdl2.ItemID == "ST250.BLeakage")
        //                                    {
        //                                        if (amdl2.DataValue.Length <= 20)
        //                                        {
        //                                            goto Label_0E5A;
        //                                        }
        //                                        strArray = amdl2.DataValue.Split(new char[] { ':' });
        //                                        strArray[3] = strArray[3].ToUpper();
        //                                        amdl2.DataValue = strArray[3].Replace(" ", "").Replace("BAR", "").Replace("K", "").Replace("PA", "").Replace("/S", "").Replace("\r", "").Replace("\n", "");
        //                                    }
        //                                    else if (amdl2.ItemID == "ST250.BPressure")
        //                                    {
        //                                        if (amdl2.DataValue.Length <= 20)
        //                                        {
        //                                            goto Label_0E5A;
        //                                        }
        //                                        strArray = amdl2.DataValue.Split(new char[] { ':' });
        //                                        strArray[3] = strArray[3].ToUpper();
        //                                        amdl2.DataValue = strArray[3].Replace(" ", "").Replace("BAR", "").Replace("K", "").Replace("PA", "").Replace("/S", "").Replace("\r", "").Replace("\n", "");
        //                                    }
        //                                }
        //                            }
        //                            catch (Exception exception1)
        //                            {
        //                                exception = exception1;
        //                                CLog.WriteErrLogInTrace(string.Format("在处理泄露值时出错：{0}，{1}.{2}={3}", new object[] { exception.StackTrace, str4, amdl2.DBFieldName, amdl2.DataValue }));
        //                                goto Label_0E5A;
        //                            }
        //                            if ((amdl2.StationID == "ST270") || (amdl2.StationID == "ST440"))
        //                            {
        //                                if (tldal.GetFieldValueByKeyCode(amdl2.DBFieldName, dBFieldName, str4) == "1")
        //                                {
        //                                    goto Label_0E5A;
        //                                }
        //                            }
        //                            else if ((amdl2.StationID == "ST160") || (amdl2.StationID == "ST390"))
        //                            {
        //                                double result = 0.0;
        //                                if (double.TryParse(amdl2.DataValue, out result) && ((((result == 0.0) || (result > 33185000.0)) || (result < -33185000.0)) || (amdl2.ItemID.Contains("Angle") && ((result > 3300000.0) || (result < -3300000.0)))))
        //                                {
        //                                    goto Label_0E5A;
        //                                }
        //                            }
        //                            else if (((amdl2.StationID == "ST250A") || (amdl2.StationID == "ST250B")) && (amdl2.DataValue == "0"))
        //                            {
        //                                goto Label_0E5A;
        //                            }
        //                            if (((amdl2.DBFieldType == 1) && (amdl2.DecPoint > 0)) && double.TryParse(amdl2.DataValue, out num3))
        //                            {
        //                                amdl2.DataValue = (double.Parse(amdl2.DataValue) / Math.Pow(10.0, (double) amdl2.DecPoint)).ToString();
        //                            }
        //                            if ((amdl2.DBFieldType == 1) || (amdl2.DBFieldType == 2))
        //                            {
        //                                if (tldal.Exist(dBFieldName, str4))
        //                                {
        //                                    if (tldal.UpdateByField(amdl2.DBFieldName, amdl2.DataValue, amdl2.DBFieldType, dBFieldName, str4) <= 0)
        //                                    {
        //                                        CLog.WriteStationLog(stationID, string.Format("P.{0}的{1}更新为{2}失败", str4, amdl2.DBFieldName, amdl2.DataValue));
        //                                    }
        //                                }
        //                                else if (tldal.InsertCode(dBFieldName, str4) <= 0)
        //                                {
        //                                    CLog.WriteStationLog(stationID, string.Format("P.新增{0}的{1}更新为{2}失败", str4, amdl2.DBFieldName, amdl2.DataValue));
        //                                }
        //                                else if (tldal.UpdateByField(amdl2.DBFieldName, amdl2.DataValue, amdl2.DBFieldType, dBFieldName, str4) <= 0)
        //                                {
        //                                    CLog.WriteStationLog(stationID, string.Format("P.{0}的{1}更新为{2}失败", str4, amdl2.DBFieldName, amdl2.DataValue));
        //                                }
        //                                if ((amdl2.StationID == "ST420") && (amdl2.ItemID.Contains("X2") || amdl2.ItemID.Contains("Y2")))
        //                                {
        //                                    str2 = str2 + string.Format("{0},", amdl2.DataValue);
        //                                }
        //                            }
        //                        Label_0E5A:;
        //                        }
        //                    }
        //                }
        //                if (data.StationID == "ST420")
        //                {
        //                    array = null;
        //                    array = this.SyncRead("ST420.ProductType");
        //                    if ((array != null) && (array.GetValue(1) != null))
        //                    {
        //                        productType = array.GetValue(1).ToString();
        //                    }
        //                    new ResultL1DAL().UpdateProductNameByKeyCode("brakecode", str4, productType);
        //                    this.GetST420Data(data, str4, productType, str2);
        //                }
        //                this.CheckLastStationData(item, str4, data);
        //                List<PLCDataMDL> list2 = new List<PLCDataMDL>();
        //                PLCDataMDL amdl3 = new PLCDataMDL();
        //                if (data.StationID == "ST250A")
        //                {
        //                    amdl3.ItemID = "ST250.AControlPass";
        //                }
        //                else if (data.StationID == "ST250B")
        //                {
        //                    amdl3.ItemID = "ST250.BControlPass";
        //                }
        //                else
        //                {
        //                    amdl3.ItemID = string.Format("{0}.ControlPass", data.StationID);
        //                }
        //                if (data.StationID == "ST440")
        //                {
        //                    list.Remove(list.Find(p => p.ItemID == "ST440.BracketCode"));
        //                }
        //                if (tldal.CheckStationResult(dBFieldName, str4, "", data.StationID, list))
        //                {
        //                    amdl3.DataValue = "1";
        //                }
        //                else
        //                {
        //                    amdl3.DataValue = "0";
        //                    CLog.WriteStationLog(stationID, string.Format("{0}在{1}工位的数据不完整，不与放行", str4, data.StationID));
        //                }
        //                list2.Add(amdl3);
        //                this.AsycnWriter(list2);
        //            }
        //            else
        //            {
        //                CLog.WriteStationLog(stationID, string.Format("获取{0}的所有检测项的值为null", str4));
        //            }
        //        }
        //        else
        //        {
        //            CLog.WriteStationLog(stationID, string.Format("找不到{0}的KeyField", data.ItemID));
        //        }
        //        CLog.WriteStationLog(stationID, string.Format("----{0} End----", data.ItemID));
        //    }
        //    catch (Exception exception2)
        //    {
        //        exception = exception2;
        //        CLog.WriteErrLogInTrace(string.Format("在处理{0}的Complete数据时出错，{1}", data.StationID, exception.Message));
        //    }
        //}

        private void ProcessStationAllDataThreadFun()
        {
            PLCDataMDL curProcessStationAllData = this.curProcessStationAllData;
            try
            {
            }
            catch (Exception exception)
            {
                CLog.WriteErrLogInTrace(string.Format("在处理{0}的Complete数据时出错，{1}", curProcessStationAllData.StationID, exception.Message));
            }
        }

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

