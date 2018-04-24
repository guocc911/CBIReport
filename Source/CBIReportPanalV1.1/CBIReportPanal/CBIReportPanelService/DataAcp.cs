using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using COMM;
//using DAL;
using MDL;
using DataGather;


namespace CBIReportPanelService
{
    public class CBILineDataAcq
    {

        #region 

        private object checkLock = new object();

       // private BarCodeScanL1 scanL1 = null;

      //  private BarCodeScanL2 scanL2 = null;


        public EventHandler StartDataAcqEvent;

        public EventHandler EndDataAcqEvent;

        public EventHandler ErrorAcqEvent;

        public System.Timers.Timer testTimer = null;
        
        #endregion


/// <summary>
        /// 
        /// </summary>
        public CBILineDataAcq()
        {
 
        }

        /// <summary>
        /// 开启采集
        /// </summary>
        public bool StartAcq()
        {
            try
            {
                string lineID = string.Empty;
                //  this.LoadAppParam();
                if (BaseVariable.LineID == "1")
                {
                    lineID = "1";
                    //this.scanL1 = new BarCodeScanL1(BaseVariable.ScannerListL1);
                    PublicVariable.plcL1 = new PLCResultL1(BaseVariable.MxOPCServer.OPCName, BaseVariable.MxOPCServer.OPCIP, BaseVariable.MxOPCServer.GroupName, BaseVariable.PLCDataListL1);
                   // PublicVariable.plcL1.ShowLogEvent += new EventHandler(ShowInfo_EventHandler);
                    CLog.WriteSysLog(BaseVariable.MxOPCServer.OPCName + BaseVariable.MxOPCServer.OPCIP.ToString());
                    PublicVariable.plcL1.OPCServer_Connect(BaseVariable.PLCDataListL1.Count);
                    //PublicVariable.rexL1 = new RexrothPLCL1(BaseVariable.RexOPCServer.OPCName, BaseVariable.RexOPCServer.OPCIP, BaseVariable.RexOPCServer.GroupName, BaseVariable.RexrothDataListL1);
                    //PublicVariable.rexL1.OPCServer_Connect(BaseVariable.RexrothDataListL1.Count);
                    if (StartDataAcqEvent != null)
                        StartDataAcqEvent("连接PLC成功",EventArgs.Empty);
                    return true;
                }
                else if (BaseVariable.LineID == "2")
                {
                    lineID = "2";
                    //this.scanL2 = new BarCodeScanL2(BaseVariable.ScannerListL2);
                    PublicVariable.plcL2 = new PLCResultL2(BaseVariable.MxOPCServer.OPCName, BaseVariable.MxOPCServer.OPCIP, BaseVariable.MxOPCServer.GroupName, BaseVariable.PLCDataListL2);
                    PublicVariable.plcL2.ShowLogEvent += new EventHandler(ShowInfo_EventHandler);
                    CLog.WriteSysLog(BaseVariable.MxOPCServer.OPCName + BaseVariable.MxOPCServer.OPCIP.ToString());
                    PublicVariable.plcL2.OPCServer_Connect(BaseVariable.PLCDataListL2.Count);
                   
                    
                    if (StartDataAcqEvent != null)
                        StartDataAcqEvent("连接PLC成功", EventArgs.Empty);
                    //PublicVariable.rexL2 = new RexrothPLCL2(BaseVariable.RexOPCServer.OPCName, BaseVariable.RexOPCServer.OPCIP, BaseVariable.RexOPCServer.GroupName, BaseVariable.RexrothDataListL2);
                    //PublicVariable.rexL2.OPCServer_Connect(BaseVariable.RexrothDataListL2.Count);

                    return true;
                }

              
            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message.ToString());

                if(ErrorAcqEvent!=null)
                   ErrorAcqEvent(ex.Message,EventArgs.Empty);
            }

              return false;
        }

        #region Test Process

        public void StartTestProcessData()
        {
            try
            {
                CLog.WriteSysLog("加载数据库成功！");

                PublicVariable.plcL1 = new PLCResultL1(BaseVariable.MxOPCServer.OPCName, BaseVariable.MxOPCServer.OPCIP, BaseVariable.MxOPCServer.GroupName, BaseVariable.PLCDataListL1);
               
                CLog.WriteSysLog(BaseVariable.MxOPCServer.OPCName + BaseVariable.MxOPCServer.OPCIP.ToString());

                testTimer=new System.Timers.Timer();
                testTimer.Enabled = true;
                testTimer.Interval = 4000;//执行间隔时间,单位为毫秒  
                testTimer.Start();
                testTimer.Elapsed += new System.Timers.ElapsedEventHandler(Timer1_Elapsed);  

            }
            catch 
            {
                throw;
            }
        }


        private int count = 0;
        private int[] emsArray = {107,105,106,89,90,10};
        private string lineid = "01";
        private int emsaddr = 107;

        private DateTime collectTime = DateTime.Now;


        private void Timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {


          try
          {

              CLog.WriteSysLog("开始采集数据处理");

              if (TimeRange.ExecDateDiffSecond(collectTime, DateTime.Now) > 5)
              {
                  collectTime = DateTime.Now;

                  CLog.WriteSysLog(DateTime.Now.ToLongTimeString());

                  Random r = new Random();
                  emsaddr = emsArray[r.Next(emsArray.Length)];

                  count += 1;

                  CLog.WriteSysLog(emsaddr.ToString());

                  PublicVariable.plcL1.TestChangeThreadFun(String.Format("{0:D2}",Convert.ToInt32(BaseVariable.LineID)), count, emsaddr);

              }

          }
          catch (System.Exception ex)
          {
              CLog.WriteSysLog(ex.Message.ToString());
          }

   
      


        }

        public void StopTestProcessData()
        {

            if (testTimer != null)
            {
                testTimer.Enabled = false;
                testTimer.Stop();
            }
        }

        #endregion


        private void ShowInfo_EventHandler(object obj ,EventArgs args)
        {
            PublicVariable.plcL2.ShowLogEvent -= new EventHandler(ShowInfo_EventHandler);

            if (StartDataAcqEvent != null)
                StartDataAcqEvent(obj, EventArgs.Empty);

            PublicVariable.plcL2.ShowLogEvent += new EventHandler(ShowInfo_EventHandler);
        }

        /// <summary>
        /// 结束采集
        /// </summary>
        public bool EndAcq()
        {
            try
            {
                if (BaseVariable.LineID == "1")
                {
                    PublicVariable.plcL1.OPCServer_Disconnnect();

                    return true;
                }
                else if (BaseVariable.LineID == "2")
                {
                    PublicVariable.plcL2.OPCServer_Disconnnect();
                    return true;
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message.ToString());

                if(ErrorAcqEvent!=null)
                   ErrorAcqEvent(ex.Message,EventArgs.Empty);
            }

            return false;
        }


        public void Dispose()
        {
            try
            {
                if (PublicVariable.plcL1 != null)
                    PublicVariable.plcL1.OPCServer_Disconnnect();
                if (PublicVariable.plcL2 != null)
                    PublicVariable.plcL2.OPCServer_Disconnnect();

            }
            catch (Exception ex)
            {
                CLog.WriteErrLog("停止采集服务："+ex.Message.ToString());
            }
 
        }


    }
}
