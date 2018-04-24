using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.ServiceProcess;
using System.IO;
using COMM;

//using DAL;
using MDL;


namespace CBIReportPanelService
{
    public partial class PanelService : ServiceBase
    {


        private CBILineDataAcq DataAcq = null;

        private Thread notifyThread = null;
        
       // private AcqCountListDAL acqCountDal = null;

       // private AcqCountListSQLiteDAL acqCountDal = null;

        //private ServiceStatus status = ServiceStatus.None;

        public static string ApplicationPath = Path.GetFullPath(Application.ExecutablePath);

        public PanelService()
        {
            InitializeComponent();
        }

        //public static string ProjectDBName = "cbireport.db";

        public static string ProjectDBName = "cbiassemly";


        /// <summary>
        /// 加载MysqlDB
        /// </summary>
        /// <returns></returns>
        private bool LoadDB()
        {
            bool ret = false;
            try
            {
                CLog.WriteSysLog(BaseVariable.DBConnStr);
                
                ret = MySqlDBHelper.ModifyConnectionInfo(BaseVariable.DBConnStr);

                CLog.WriteSysLog(ret.ToString());

                return ret;

            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message.ToString());

            }

            return false;
        }

        /// <summary>
        /// 开启采集
        /// </summary>
        private void StartAcq()
        {
            try
            {

                loadParam();

                if (!LoadDB())
                {
                    CLog.WriteSysLog(" 打开数据库失败！");
                }

                //if(acqCountDal.GetRowCount()<=0)
                //{
                //    CreateAcqTableRange();
                //    CLog.WriteSysLog(" 写入采集列表成功！");
                //}

                if (DataAcq != null)
                    DataAcq.Dispose();

                CLog.WriteSysLog("初始化采集事件！");


                DataAcq = new CBILineDataAcq();
                DataAcq.StartDataAcqEvent += new EventHandler(DataAcq_StartDataAcqEvent);
                DataAcq.EndDataAcqEvent += new EventHandler(DataAcq_EndDataAcqEvent);
                DataAcq.ErrorAcqEvent += new EventHandler(DataAcq_StartDataAcqEvent);


                //////////////////////////////////////////////////////////////////////////
                ///test
               // /*
                //CLog.WriteSysLog("测试数据处理！");
                //DataAcq.StartTestProcessData();

                //return;

                //*/
                //////////////////////////////////////////////////////////////////////////

                if (DataAcq.StartAcq())
                {
                    CLog.WriteSysLog("启动采集成功！");
                }
                else
                {
                    CLog.WriteErrLog("启动采集失败！");
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message.ToString());
            }
        }


        /// <summary>
        /// 创建采集数据列表范围
        /// </summary>
        //private void CreateAcqTableRange()
        //{
        //    try
        //    {

        //        DateTime timeStart = new DateTime(DateTime.Now.Year,
        //                                          DateTime.Now.Month,
        //                                          DateTime.Now.Day, 7, 30, 0);
        //        DateTime timeEnd = timeStart;

        //        int hoursToAdd = 1;
        //        int minuteToAdd = 60;


        //        //AcqCountListDAL acqCountDal = new AcqCountListDAL();


        //        AcqCountListSQLiteDAL acqCountDal = new AcqCountListSQLiteDAL();

        //        List<TimeRange> rangs = new List<TimeRange>();

        //        //获取小时
        //        for (int i = 0; i < 12; i++)
        //        {
        //            timeStart = timeStart.AddHours(hoursToAdd);

        //            timeEnd = timeStart.AddMinutes(minuteToAdd);

        //            TimeRange rang = new TimeRange();
        //            rang.StartTime = timeStart;
        //            rang.EndTime = timeEnd;
        //            rangs.Add(rang);

        //            AcqCountMDL pl = new AcqCountMDL();
        //            pl.TagName = i.ToString();
        //            pl.StartTime = timeStart;
        //            pl.EndTime = timeEnd;
        //            pl.CurrentCount = 0;
        //            pl.Remark = "";
        //            acqCountDal.InsertAcqCountItem(pl);
        //           // Plist.Add(pl);
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        CLog.WriteErrLog(ex.Message.ToString());
        //    }
 
        //}



        /// <summary>
        /// 结束采集
        /// </summary>
        private void StopAcq()
        {
            ///*
            //////////////////////////////////////////////////////////////////////////
            ///test
            /////
            //DataAcq.StopTestProcessData();

            //return;

            
            //////////////////////////////////////////////////////////////////////////

           // */

            if (DataAcq != null)
                DataAcq.EndAcq();
        }



        protected override void OnStart(string[] args)
        {

            try
            {

                StartAcq();

                //status = ServiceStatus.Start;
                
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog("启动采集失败:" + ex.Message.ToString());
            }
        }



        private void DataAcq_StartDataAcqEvent(object obj, EventArgs args)
        {

        }

        private void DataAcq_EndDataAcqEvent(object obj, EventArgs args)
        {

        }


        protected override void OnPause()
        {
            StopAcq();
            base.OnPause();
        }


        protected override void OnContinue()
        {
            StartAcq();

             base.OnContinue();
        }
        protected override void OnStop()
        {
            StopAcq();
        }

        public void loadParam()
        {
            try
            {
                XmlHelper helper = new XmlHelper("App.xml");
                BaseVariable.DBConnStr = helper.SelectValue("/Root/APP/DBConnstr");
                BaseVariable.DataCheckOut = helper.SelectValue("/Root/APP/DataCheckOut");
                BaseVariable.SysDebug = helper.SelectValue("/Root/APP/SysDebug");
                string lienstrs = helper.SelectValue("/Root/APP/LineNames");

                if (lienstrs == null || lienstrs == string.Empty)
                    BaseVariable.LineNames = new string[]{"1","2","3","MGU"};

                BaseVariable.LineNames = lienstrs.Trim().Split(',');

                //MySqlDBHelper.Conn = BaseVariable.DBConnStr;
                CLog.WriteSysLog(BaseVariable.DBConnStr);
                BaseVariable.PLineID = Convert.ToInt32(helper.SelectValue("/Root/APP/LineID"));
                BaseVariable.LineID = helper.SelectValue("/Root/APP/LineID");

                CLog.WriteSysLog(BaseVariable.LineID);
                BaseVariable.MxOPCServer = helper.SelectOPCServer("/Root/APP/MxOPCServer");
                BaseVariable.RexOPCServer = helper.SelectOPCServer("/Root/APP/RexOPCServer");
                BaseVariable.IOLogik = helper.SelectIOLogik("/Root/APP/IOLogik");
                BaseVariable.PrinterList = helper.SelectPrinterList("/Root");
                BaseVariable.ScannerListL1 = helper.SelectScannerList("/Root/L1/ScannerList");
                BaseVariable.PLCDataListL1 = helper.SelectPLCDataList("/Root/L1/PLCDataList");
                BaseVariable.RexrothDataListL1 = helper.SelectPLCDataList("/Root/L1/RexrothDataList");
                BaseVariable.ScannerListL2 = helper.SelectScannerList("/Root/L2/ScannerList");
                BaseVariable.PLCDataListL2 = helper.SelectPLCDataList("/Root/L2/PLCDataList");
                BaseVariable.RexrothDataListL2 = helper.SelectPLCDataList("/Root/L2/RexrothDataList");
            }
            catch (Exception exception)
            {
                CLog.WriteErrLogInTrace(string.Format("在加载XML参数时出错，{0}", exception.Message));
            }
        }


        private void NotifyThreadFun()
        {
          //  NotifyForm mainForm = new NotifyForm();
           // Application.Run(mainForm);
        }
    }
}
