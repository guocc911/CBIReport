using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using COMM;
using DAL;
using MDL;
using DataGather;
using CBIReportPanal.Config;

namespace CBIReportPanal
{
    public partial class ReportClientForm : Form
    {

        #region

        public static string ApplicationPath = Path.GetFullPath(Application.ExecutablePath);

       // public static Hashtable ctHash = null;

        private bool bShowVector=false;

       // private ReportPanel panelForm = null;

        private PLineReportPanel panelForm = null;

         private CBILineDataAcq dataAcq = null;

        private static  string OPEN_REPORT_PANEL="开启产线看板";

        private static  string CLOSE_REPORT_PANEL="关闭产线看板";


        private ConfigForm configForm = null;

        private delegate void UpdateInfoDelegate(string info);

        
        #endregion

        public List<String> columnFirstValues = new List<string>();

        public List<String> columnSecondValues = new List<string>();


        ProductLineCaculator plineCaculator1 = null;
        /// <summary>
        /// 构造函数
        /// </summary>
        public ReportClientForm()
        {


            try
            {


                if (!InitialServiceMonitor())
                {
                    this.Dispose();
                    return;
                }

            if (!loadParam())
            {
                MessageBox.Show("加载配置文件失败！");
                return;
            }


            if (!LoadDB())
            {

                MessageBox.Show("初始化数据库失败，请连接管理员！");
                this.Dispose();
                return;
            }



         
            //////////////////////////////////////////////////////////////////////////
            ///Test Code
            //////////////////////////////////////////////////////////////////////////
            //AcqLineDAL testdal = new AcqLineDAL();

            //AcqLineCountMDL mdl = new AcqLineCountMDL();
            //mdl.TID = "20161108010103";
            //mdl.PLID = "01";
            //mdl.UNITID = "201611080101";
            //mdl.PN = "1716";
            //mdl.EMS = 34;
            //mdl.OP = 0;
            //mdl.TGNMAE = "01";
            //mdl.START_TIME = Convert.ToDateTime("2016-11-8 8:30:00");
            //mdl.END_TIME = Convert.ToDateTime("2016-11-8 9:30:00");
            //mdl.CUR_COUNT = 100;
            //mdl.START_COUNT = 180;
            //mdl.BEGIN_TIME = Convert.ToDateTime("2016-11-8 9:16:06");
            //mdl.UPDATE_TIME = Convert.ToDateTime("2016-11-8 9:16:06");
            //mdl.ERROR = "CUR";
            //mdl.REMARK = "TT";
            //testdal.AddAcqLine(mdl);
            //ProductLineCaculator  plineCaculator = new ProductLineCaculator();
            //plineCaculator.ReloadPlanUnits();
           // AcqLineDAL dalt = new AcqLineDAL();

           // AcqLineCountMDL acqlineMDL = new AcqLineCountMDL();
           // acqlineMDL.PLID = "02";
           // acqlineMDL.TGNMAE = "02";
           // acqlineMDL.START_TIME = DateTime.Now;
           // acqlineMDL.END_TIME =DateTime.Now;
           // acqlineMDL.SetTID(DateTime.Now, acqlineMDL.PLID,"02","01");
           // acqlineMDL.CUR_COUNT = 100;
           // acqlineMDL.EMS = 103;
           // acqlineMDL.UPDATE_TIME = DateTime.Now;
           //dalt.AddAcqLine(acqlineMDL);

           //dalt.UpAcqUnitCount2(123, 0, acqlineMDL.PLID, 0, acqlineMDL.UNITID, acqlineMDL.EMS);
           // PlinePlanMDL mdl=PlinePlanMDL.BuildDefualtPlan(2, DateTime.Now);
            /*


            if (plineCaculator1 == null)
                plineCaculator1 = new ProductLineCaculator();

            plineCaculator1.ReLoad();

            //PublicVariable.plcL1 = new PLCResultL1();

            //PublicVariable.plcL1.TestChangeThreadFun("01", 1, 10);
        

           // bool ret = MySqlDBHelper.ModifyConnectionInfo(BaseVariable.DBConnStr);
             */


            //ProductLineCaculator plineC = new ProductLineCaculator();
            //plineC.ReLoad();


            //TimeSpan ts1 = new TimeSpan(Convert.ToDateTime("2016-07-09 00:00:01").Ticks);

            //TimeSpan ts2 = new TimeSpan(Convert.ToDateTime("2016-07-08 00:30:00").Ticks);

            //TimeSpan ts = ts1.Subtract(ts2).Duration();


            //if (ts.Hours >= 24)
            //{
            //   // this.ReLoad();
            //   // this.ems = unit;
            //}

            //ProductDal dal1 = new ProductDal();
          //  string test1 = dal1.GetPNCodeByLineEMS("1", 64);

                //ProductLineCaculator plineC = new ProductLineCaculator();

                //DateTime time1=Convert.ToDateTime("2016-09-11 00:30:11");
                //DateTime ems1 = Convert.ToDateTime("2016-09-11 00:30:11");

                //EMSUnit unit = new EMSUnit(63, ems1);


                //plineC.CheckReload(time1, unit);
                  //  public void CheckReload(DateTime curTime,EMSUnit unit )








            //////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////



            //AcqLineItemMDL acqlineMDL = new AcqLineItemMDL();

            //acqlineMDL.PLID = "01";
            ////  TimeRange range = plineCaculator.GetTimeRangByAcqTime(DateTime.Now);

            /////采集数据创建并设置唯一编号


            //acqlineMDL.TGNAME = "01";
            //acqlineMDL.SetTID(DateTime.Now, acqlineMDL.PLID, "01", "01");
            //acqlineMDL.PR_COUNT = 1;
            //acqlineMDL.EMS = 33;
            //acqlineMDL.UPDATE_TIME = DateTime.Now;
            ////AddTraceInfo(acqlineMDL, "ST440", 11);

            //EMSUnit unit = null;

            //int ems = 33;

            //if (plineCaculator == null)
            //{
            //    plineCaculator = new ProductLineCaculator();
            //    ///初始化EMS编号

            //    //ems = ReadEMS();
            //    unit = new EMSUnit(ems, DateTime.Now);

            //    plineCaculator.ems = unit;
            //}




            //for (int i = 0; i < 11; i++)
            //{

            //    //检查是否需要重新加载计算区间
            //    plineCaculator.CheckReload(DateTime.Now, unit);

            //    //DateTime acqTime = DateTime.Now;

            //    //获取当前数据输入的采集区间
            //    TimeRange range = plineCaculator.GetTimeRangByAcqTime(DateTime.Now);

            //    ///采集数据创建并设置唯一编号


            //    acqlineMDL.TGNAME = range.SEQ;
            //    acqlineMDL.SetTID(DateTime.Now, acqlineMDL.PLID, range.SEQ, "01");
            //    acqlineMDL.PR_COUNT = 1;
            //    acqlineMDL.EMS = ems;
            //    acqlineMDL.UPDATE_TIME = DateTime.Now;

            //    plineCaculator.UpdateAcqUnitData(ref acqlineMDL);
            //}


            //EMSUnit newunit = new EMSUnit(67, DateTime.Now);


            /////判断是否换型
            //if (plineCaculator.IsChangeProduct(newunit))
            //{
            //    //处理换型记录
            //    plineCaculator.ProcessAcqLineData(acqlineMDL.PLID, acqlineMDL.UNITID, newunit);
            //    //更改换型时间
            //}
            //else
            //{
            //    plineCaculator.LoadEMSTime(DateTime.Now);
            //}
 
//////////////////////////////////////////////////////////////////////////

                InitializeComponent();

            ProductDal dal = new ProductDal();
            BaseVariable.COHash = dal.GetProductCTTable();

            ShowLogInfo("数据库加载成功...." + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            InitialServiceStatus();

            this.设置ToolStripMenuItem.Text = OPEN_REPORT_PANEL;

            }
            catch (System.Exception ex)
            {
                CLog.WriteErrLog(ex.Message.ToString());
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.开启看板ToolStripMenuItem1.Text == OPEN_REPORT_PANEL)
                {
                    Thread thread = new Thread(new ThreadStart(EnableReportPanelDialog));
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Priority = ThreadPriority.Normal;
                    thread.Start();
                    
                }
                else
                {
                    DisableReportPanelDialog();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败,请联系统管理员！");
                CLog.WriteErrLogInTrace(ex.Message);
            }
        }


        #region 面板操作
        /// <summary>
        /// 开启面板
        /// </summary>
        private void EnableReportPanelDialog()
        {
            this.开启看板ToolStripMenuItem1.Text = CLOSE_REPORT_PANEL;

            bShowVector = true;

            //panelForm = new ReportPanel();
            panelForm = new PLineReportPanel();

            panelForm.CloseReportPanelEvent+=new EventHandler(panelForm_CloseReportPanelEvent);

            panelForm.ShowDialog();

            ShowLogInfo(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "打开展板成功！" + DateTime.Now.ToShortDateString());

        }


        private void panelForm_CloseReportPanelEvent(object obj,EventArgs args)
        {

        }

        /// <summary>
        /// 关闭面板
        /// </summary>
        private void DisableReportPanelDialog()
        {
            try
            {
                if (panelForm != null && bShowVector == true)
                {
                    panelForm.DisableReportPanel();
                    this.开启看板ToolStripMenuItem1.Text = OPEN_REPORT_PANEL;
                }
                else
                {
                    this.开启看板ToolStripMenuItem1.Text = OPEN_REPORT_PANEL;
                }
                // panelForm.Close();
                //  panelForm = null;

                ShowLogInfo(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "关闭展板成功！" + DateTime.Now.ToShortDateString());
            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
            }
        }

        #endregion


        private void DataAcq_EndDataAcqEvent(object obj, EventArgs args)
        {
            ShowLogInfo("PLC采集设备连接关闭！" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }


        private void 系统设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DisableReportPanelDialog();
            this.Close();
        }


        /// <summary>
        /// 显示系统报告信息
        /// </summary>
        /// <param name="info"></param>
        private void ShowLogInfo(string info)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new UpdateInfoDelegate(ShowLogInfo), new object[] { info });
                }
                else
                {
                    //if (this.txtLogInfo.Text.Length > 300)
                    //    this.txtLogInfo.Text = "";
                    this.txtLogInfo.AppendText(info + "\r\n ");
                    this.txtLogInfo.SelectionStart = this.txtLogInfo.Text.Length;
                    this.txtLogInfo.ScrollToCaret();
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message.ToString());
            }
        }

    

        /// <summary>
        /// 加载配置文件
        /// </summary>
        /// <returns></returns>
        public bool  loadParam()
        {
            try
            {
                XmlHelper helper = new XmlHelper("App.xml");
                BaseVariable.DBConnStr = helper.SelectValue("/Root/APP/DBConnstr");
                BaseVariable.DataCheckOut = helper.SelectValue("/Root/APP/DataCheckOut");
                BaseVariable.SysDebug = helper.SelectValue("/Root/APP/SysDebug");
                MySqlDBHelper.Conn = BaseVariable.DBConnStr;

                BaseVariable.PLineID = Convert.ToInt32(helper.SelectValue("/Root/APP/LineID"));


                string line=helper.SelectValue("/Root/APP/LineID");

                //String.Format("{0:D2}",Convert.ToInt32(line));

                BaseVariable.LineID = String.Format("{0:D2}", Convert.ToInt32(line));
                BaseVariable.UpdateTime = Convert.ToInt32(helper.SelectValue("/Root/APP/UpdateTime"));

                string lienstrs = helper.SelectValue("/Root/APP/LineNames");

                if (lienstrs == null || lienstrs == string.Empty)
                    BaseVariable.LineNames = new string[] { "1", "2", "3", "MGU" };

                BaseVariable.LineNames = lienstrs.Trim().Split(',');
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
                
                return true;
            }
            catch (Exception exception)
            {
                CLog.WriteErrLogInTrace(string.Format("在加载XML参数时出错，{0}", exception.Message));
                return false;
            }
        }

        ProductLineCaculator plineCaculator;


        //private void testCollection(int count)
        //{ 
        
 
        //            AcqCountMDL unitMDL = null;

        //            ///是否加载换算器对象
        //            if (plineCaculator != null)
        //            {
        //                unitMDL = plineCaculator.GetAcqCount(count, DateTime.Now);
        //                CLog.WriteStationLog("ST400", "获取采集时间！");
        //            }
        //            else
        //            {
        //                CLog.WriteStationLog("ST400","换算器未加载！");
        //                plineCaculator = new ProductLineCaculator();
        //                unitMDL = plineCaculator.GetAcqCount(count, DateTime.Now); 
                    
        //            }

        //            if (unitMDL != null)
        //            {

        //                AcqCountListDAL acqCountListdal = new AcqCountListDAL();

        //                ///更新采集列表数量
        //                acqCountListdal.UpdateAcqCountValue(unitMDL);

        //                string planID = DateTime.Now.ToString("yyyyMMdd");

        //                //planID = string.Format("{0}_{1}_{2}", planID, BaseVariable.PLineID, unitMDL.CurrentCount);
        //                planID = string.Format("{0}_{1}", planID, BaseVariable.PLineID);
        //                CLog.WriteStationLog("ST400", "PLANID==" + planID);

        //                ProductionPlanDal plandal = new ProductionPlanDal();

        //                //if (ShowLogEvent != null)
        //                //    ShowLogEvent(data.StationID.ToString() + planID + DateTime.Now.ToShortTimeString(), EventArgs.Empty);

        //                string tid = plandal.GetTIDByDataTime(planID, unitMDL.StartTime, unitMDL.EndTime);

        //                //    CLog.WriteStationLog(data.StationID, string.Format("{0}未找到TID{1}已提交", curCount, DateTime.Now.ToLongDateString()));

        //                CLog.WriteStationLog("ST400", "tid==" + tid);

        //                if (tid != string.Empty)
        //                    plandal.UpdateActualPlan(tid, unitMDL.CurrentCount);
        //            }
        //}



        private void ReportClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("是否关闭看板界面", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            this.DisableReportPanelDialog();
            //if (this.dataAcq != null)
            //{
            //    this.dataAcq.EndAcq();
            //}
        }

        private void PlanStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 产线计划ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PLinePlanForm plineForm = new PLinePlanForm();

            if (plineForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("已更新产线计划！");
            }
        }

        private void 设置公告内容ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoticeConfigForm cfgForm = new NoticeConfigForm();

            if (cfgForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("已更新产品设置！");
            }
        }

        private void 产品设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductionCfgForm productCfgForm = new ProductionCfgForm();

            if (productCfgForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("已更新产品设置！");
            }

        }

        private void 说明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.ShowDialog();
        }

        private void 开启服务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeServiceStauts(true);
        }

        private void 关闭服务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeServiceStauts(false);
        }

        private void ReportClientForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Visible = true;

            this.WindowState = FormWindowState.Normal;

            this.notifyIcon1.Visible = false;
        }

        private void ReportClientForm_Shown(object sender, EventArgs e)
        {

        }

        private void PLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoAssemblyPlan();
        }


        private void DoAssemblyPlan()
        {
            try
            {
                PlanInfoForm dialog = new PlanInfoForm();

                PlinePlanDAL dal = new PlinePlanDAL();

                string plineid = DateTime.Now.ToString("yyyyMMdd") + BaseVariable.LineID;

                if (dal.PlanExists(plineid) <= 0)
                {

                    if (dal.AddPlinePlan(PlinePlanMDL.BuildedPlan(Convert.ToInt32(BaseVariable.LineID)
                                                              , DateTime.Now)) <= 0)
                    {
                        MessageBox.Show("加载产线配置失败，请检查配置文件信息！", "提示", MessageBoxButtons.OK);

                        return;
                    }

                }

                PlinePlanMDL mdl = dal.GetPlanInfo(plineid);

                if (mdl == null)
                {
                    MessageBox.Show("加载产线配置失败，请检查配置文件信息！", "提示", MessageBoxButtons.OK);
                    return;
                }

                dialog.PLAN = mdl;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (dal.UpdatePlinePlan(dialog.PLAN) > 0)
                    {
                        MessageBox.Show("修改产线配置信息成功！", "提示", MessageBoxButtons.OK);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("修改产线配置信息失败！", "提示", MessageBoxButtons.OK);
                        return;
                    }
                }

            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), "提示", MessageBoxButtons.OK);
            }
        }

        private void PlantoolStripButton_Click(object sender, EventArgs e)
        {
            DoAssemblyPlan();
        }




     

  


  
    }
}
