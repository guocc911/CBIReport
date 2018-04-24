using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using COM;
using DAL;

namespace CBIReportPanal
{
    public partial class ReportMangerFrom : Form
    {
        public ReportMangerFrom()
        {
            InitializeComponent();
        }

        private void 计划PToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadParam();
        }

        /// <summary>
        /// 加载参数
        /// </summary>
        public void loadParam()
        {
            try
            {
                XmlHelper helper = new XmlHelper("App.xml");
                BaseVariable.DBConnStr = helper.SelectValue("/Root/APP/DBConnstr");
                BaseVariable.DataCheckOut = helper.SelectValue("/Root/APP/DataCheckOut");
                BaseVariable.SysDebug = helper.SelectValue("/Root/APP/SysDebug");
                MySqlDBHelper.Conn = BaseVariable.DBConnStr;
                BaseVariable.LineID = helper.SelectValue("/Root/APP/LineID");
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


        /// <summary>
        /// 公告设置按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 公告设置PToolStripMenuItem_Click(object sender, EventArgs e)
        {

            NoticeConfigForm form = new NoticeConfigForm();
            form.ShowDialog();
        }

        private void 用户设置UToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserCfgForm form = new UserCfgForm();
            form.ShowDialog();

        }

        private void 产品设置DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductionCfgForm form = new ProductionCfgForm();
            form.ShowDialog();
        }

        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 新建NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PLinePlanForm planForm = new PLinePlanForm();
            planForm.ShowDialog();
        }
    }
}
