using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using COMM;
using DAL;
using MDL;
using DataGather;


namespace CBIReportPanal
{
    public class CBILineDataAcq
    {

        #region 

        private object checkLock = new object();

      //  private BarCodeScanL1 scanL1 = null;

       // private BarCodeScanL2 scanL2 = null;


        public EventHandler StartDataAcqEvent;

        public EventHandler EndDataAcqEvent;

        public EventHandler ErrorAcqEvent;
        
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
                if (BaseVariable.LineID == "L1")
                {
                    PublicVariable.plcL1.OPCServer_Disconnnect();

                    return true;
                }
                else if (BaseVariable.LineID == "L2")
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
    }
}
