using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using COMM;
using ProductLine.Utils;
using ProductLine.Config;


namespace ProductLine
{
    public partial class AssemblyCtrlForm : Form
    {

        private bool bShowVector = false;

        private AssemblyReportForm reportForm = null;

        private static string OPEN_REPORT_PANEL = "开启产线看板";

        private static string CLOSE_REPORT_PANEL = "关闭产线看板";

        public static WorkSpace _workSpace = null;


        private static bool openDB = false;



        private delegate void UpdateInfoDelegate(string info);


        public AssemblyCtrlForm()
        {
            InitializeComponent();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
              this.Visible = true;

            this.WindowState = FormWindowState.Normal;

            this.notifyIcon1.Visible = false; 
        }

        private void AssemblyCtrlForm_SizeChanged(object sender, EventArgs e)
        {

            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.notifyIcon1.Visible = true;
            }
        }

        private void EnableReportPanelDialog()
        {
            this.开启看板ToolStripMenuItem1.Text = CLOSE_REPORT_PANEL;

            bShowVector = true;

            //panelForm = new ReportPanel();
            reportForm = new AssemblyReportForm();

            reportForm.CloseReportPanelEvent += new EventHandler(panelForm_CloseReportPanelEvent);

            reportForm.ShowDialog();

            ShowLogInfo(DateTime.Now.ToString("yyyy-MM-dd H:mm:ss") + "打开展板成功！" + DateTime.Now.ToShortDateString());

        }



        /// <summary>
        /// 关闭面板
        /// </summary>
        private void DisableReportPanelDialog()
        {
            try
            {
                if (reportForm != null && bShowVector == true)
                {
                    reportForm.DisableReportPanel();
                    this.开启看板ToolStripMenuItem1.Text = OPEN_REPORT_PANEL;
                }
                else
                {
                    this.开启看板ToolStripMenuItem1.Text = OPEN_REPORT_PANEL;
                }
            

                ShowLogInfo(DateTime.Now.ToString("yyyy-MM-dd H:mm:ss") + "关闭展板成功！" + DateTime.Now.ToShortDateString());
            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
            }
        }

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

        private void panelForm_CloseReportPanelEvent(object obj, EventArgs args)
        {

        }

        private void 开启看板ToolStripMenuItem1_Click(object sender, EventArgs e)
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

        private void AssemblyCtrlForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("是否关闭看板界面", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            this.DisableReportPanelDialog();
        }

        private void 退出ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.DisableReportPanelDialog();
            this.Close();
        }

        private void 数据库配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintConfig dlg = new PrintConfig();

            dlg.DBinfo = _workSpace.DBInfo;

            if (dlg.ShowDialog() == DialogResult.Yes)
            {

                SavaDBConfig(dlg.DBinfo);

                MessageBox.Show("保存配置成功！");
            }
        }

        #region config

        private void LoadConfig()
        {
            try
            {
                _workSpace = new WorkSpace(SystemUtils.ApplicationPath);
                _workSpace.Load();

                openDB = COMM.MySqlDBHelper.ModifyConnectionInfo(_workSpace.DBInfo.Server,
                                                                       _workSpace.DBInfo.DBName,
                                                                       _workSpace.DBInfo.User,
                                                                       _workSpace.DBInfo.PWD);
                //OpenPLDlg();

                if (openDB)
                {
                    ShowStatusInfo("状态：连接数据库成功！", Color.Blue);
                }
                else
                {
                    // MessageBox.Show("连接数据库失败，请检查数据库配置！", "追溯系统", MessageBoxButtons.OK);
                    ShowStatusInfo("状态：连接数据库失败！", Color.Red);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }

        }




        private void SavaDBConfig(DBInfo info)
        {
            try
            {
                _workSpace = new WorkSpace(SystemUtils.ApplicationPath);
                _workSpace.Load();
                _workSpace.DBInfo = info;

                if (_workSpace.Save())
                {
                    COMM.MySqlDBHelper.ModifyConnectionInfo(_workSpace.DBInfo.Server,
                                                            _workSpace.DBInfo.DBName,
                                                            _workSpace.DBInfo.User,
                                                            _workSpace.DBInfo.PWD);

                    ShowStatusInfo("状态：连接数据库成功！", Color.Blue);
                }
                else
                {
                    // MessageBox.Show("连接数据库失败，请检查数据库配置！", "追溯系统", MessageBoxButtons.OK);
                    ShowStatusInfo("状态：连接数据库失败！", Color.Red);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }


        public void ShowStatusInfo(string info, Color color)
        {
            this.StaustoolStripStatusLabel.Text = info.Trim();
            this.StaustoolStripStatusLabel.ForeColor = color;
        }



        public bool TestConnection()
        {
            bool result = COMM.MySqlDBHelper.ModifyConnectionInfo(_workSpace.DBInfo.DBName,
                                                                   _workSpace.DBInfo.Server,
                                                                   _workSpace.DBInfo.User,
                                                                   _workSpace.DBInfo.PWD);
            return result;
        }
        #endregion

        private void AssemblyCtrlForm_Load(object sender, EventArgs e)
        {
            LoadConfig();
        
        }

        private void 产线型号配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CSVImportForm dlg = new CSVImportForm();

            if (dlg.ShowDialog() == DialogResult.Yes)
            {
            
            }
        }

        private void AssemblyCtrlForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {

              


            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Z)
            {



            }
            base.OnKeyDown(e);
        }
    }
}
