using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using System.Collections;
using COMM;

namespace ProductLine
{
    public partial class AssemblyReportForm : Form
    {

        public static int tickSpan = 5000;

        private bool listVerticalSort = false;

        private Timer timer = null;

        private int lastoffset = 0;

        private int offset = 0;

        private int rows = 0;

        private int pageindex = 0;

        //private List<ShippingPlan> plans = null;



        private delegate void CloseWindowDelegate();


        public void DisableReportPanel()
        {

            if (this.InvokeRequired)
            {

                this.BeginInvoke(new CloseWindowDelegate(DisableReportPanel));
                //this.Close();
            }
            else
            {
                this.StopTimerUpdate();
                this.Close();
                this.Dispose();
            }

        }

        #region 刷新计时器
        private void LoadTimerUpdate()
        {
            timer = new Timer();
            timer.Interval = tickSpan;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

        }



        private void StopTimerUpdate()
        {
            try
            {
                if (timer != null)
                {
                    timer.Stop();
                    timer.Enabled = false;
                    timer = null;
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.StackTrace);
            }

        }

        void timer_Tick(object sender, EventArgs e)
        {
            //  this.lineinfoCtrl1.InfoUpdate();
            //ReloadDelivertViewSize(DateTime.Now);
            //UpdateGridHeaderConfig();
            //UpdateAllGrid();
            UpdateAllGrid();

        }

        private void Initialize()
        {
            this.SuspendLayout();
            // 
            // AssemblyReportForm
            // 
            this.ClientSize = new System.Drawing.Size(402, 391);
            this.Name = "AssemblyReportForm";
            this.ResumeLayout(false);

        }



//        private void UpdateGridHeaderConfig()
//        {
//            //ReloadRowSize();
//            //orderClass.ReloadConfig();
//            //LoadCodeInfo();
//            //InitialTitelInfo();
//            //GridDataRange range = orderClass.getDateRange(DateTime.Now);
//            //InitlalDateInfoHeaderView(range);
//            //LoadCustomerHeaderView();
//        }


//        private bool UpdateAllGrid()
//        {
//            //LoadConnectData();

//            //if (LoadDeliveryData(DateTime.Now))
//            //{



//            LoadDeliveryData(DateTime.Now);
//            ////初始化用户信息
//            //InitialCustomerGrid();
//            ////初始化码头信息
//            //InitialDockInfoGrid();

//            //GridDataRange range = orderClass.getDateRange(DateTime.Now);
//            /////初始化发货信息
//            //InitialDeliverGrid(range);
//            /////初始化统计信息
//            //InitialDeliveyInfo();
//            return true;
//            //}

//            // return false;
//        }


//        private void ReloadDelivertViewSize(DateTime curDate)
//        {
////            int planCount = ShippingPlanDal.GetRangePlansCount(curDate);

//            if (planCount > rows)
//            {
//                //获取数据
//                offset = rows;

//                if (lastoffset < planCount)
//                {
//                    lastoffset += 1;
//                }
//                else
//                {
//                    if (lastoffset >= rows)
//                        lastoffset = 0;
//                }
//            }
//            else
//            {
//                lastoffset = 0;
//                offset = rows;
//            }


//        }


//        /// <summary>
//        /// 加载出库数据
//        /// </summary>
//        /// <param name="curDate"></param>
//        /// <returns></returns>
//        private bool LoadDeliveryData(DateTime curDate)
//        {

//            try
//            {

//                ShippingPlanDal dal = new ShippingPlanDal();
//                DateTime startTime = DateTime.Parse(curDate.ToString("yyyy-MM-dd") + " 01:00:00");
//                DateTime endTime = DateTime.Parse(curDate.ToString("yyyy-MM-dd") + " 23:59:00");


//                int planCount = ShippingPlanDal.GetRangePlansCount(curDate);

//                this.m_plans = dal.GetShippingPlansByDateRange(startTime, endTime, offset, lastoffset);


//                if (this.m_plans == null)
//                    return false;



//                return true;
//            }
//            catch
//            {
//                throw;
//            }

//        }
        #endregion

    }
}
