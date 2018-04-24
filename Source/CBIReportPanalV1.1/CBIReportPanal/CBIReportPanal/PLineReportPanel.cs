using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using COMM;
using MDL;
//using DAL;
using SQLiteDAL;
using ZYReportControl;

namespace CBIReportPanal
{
    public partial class PLineReportPanel : Form
    {

      // private int tickSpan = 1000*60*60;
        private int tickSpan = 1000;

        private int secondSpan = 60;





        private delegate void CloseWindowDelegate();

        private delegate void ReportUpdateDelegate();


        public event EventHandler CloseReportPanelEvent;

        private Timer timer = null;




        public PLineReportPanel()
        {
            InitializeComponent();

            //this.DesktopLocation = Screen.AllScreens[1].Bounds.Location;
            //this.DesktopBounds = Screen.AllScreens[1].Bounds;
            //this.WindowState = FormWindowState.Maximized; 
            //this.FormBorderStyle = FormBorderStyle.None;
            this.pLineinfoCtrl1.PlineID = BaseVariable.LineID;
            this.pLineinfoCtrl1.DoChangeShowStatus += new EventHandler(lineinfoCtrl1_DoChangeShowStatus);
        }

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


        private void ReportPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            StopTimerUpdate();

            if (this.CloseReportPanelEvent != null)
                this.CloseReportPanelEvent(null, EventArgs.Empty);
           
         }




        private void ReportPanel_Load(object sender, EventArgs e)
        {
            LoadTimerUpdate();
            LoadNoticeInfo();
            LoadReportGrid();
        }


        private void LoadReportGrid()
        {

            //List<string> columnFirstValues = new List<string>();
            //columnFirstValues.Add("产线编号");
            //columnFirstValues.Add("计划生产量");
            //columnFirstValues.Add("实际生产量");
            //columnFirstValues.Add("当前小时OEE");
            //this.lineinfoCtrl1.ColumnFist = columnFirstValues;

            this.pLineinfoCtrl1.DoDatGridUpdate();
           
            if (this.pLineinfoCtrl1.RefreshReport)
              this.pLineinfoCtrl1.Invalidate();

        }


        #region 刷新计时器
        private void LoadTimerUpdate()
        {
            timer = new Timer();
          //  timer.Interval = tickSpan;
            timer.Interval = BaseVariable.UpdateTime * 1000;
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
           
            NoticeUpdate();
            LoadReportGrid();
        }
        #endregion



        #region  公告信息处理



             private int reportInfoOffsetX = 0;

             private string reportInfoString = string.Empty;

             //private NoticeDal noticDal = null;
             private NoticeSQLiteDal noticDal = null;


             /// <summary>
             /// 跟新公告栏
             /// </summary>
             private void NoticeUpdate()
             {
                 try
                 {
                     if (this.InvokeRequired)
                     {

                         this.Invoke(new ReportUpdateDelegate(NoticeUpdate));
                         //this.Close();
                     }
                     else
                     {
                         reportInfoString=noticDal.GetNoticeInfo();
                         //panel1.Invalidate();
                     }
                 }
                 catch (Exception ex)
                 {
                     CLog.WriteErrLogInTrace(ex.Message);
                 }

             }


             /// <summary>
             /// 初始化公告信息
             /// </summary>
             private void LoadNoticeInfo()
             {
                 //便宜像素起始位置
                 reportInfoOffsetX = 10;
                // noticDal = new NoticeSQLiteDal();
                // reportInfoString = noticDal.GetNoticeInfo();
                 //reportInfoString = "欢迎参观泛博制动有限公司";
             }

            ///// <summary>
            ///// 绘制公告信息
            ///// </summary>
            ///// <param name="graph"></param>
            // private void DrawNoticeInfo(Graphics graph)
            // {
            //     //绘制星期
            //     // Create font and brush.
            //     try
            //     {
            //         int offsetX = 0;

            //         int txtWidth = 0;

            //         float fontSize = (float)(panel1.Height * 0.3);
            //         Font drawFont = new Font("黑体", fontSize);
            //         SolidBrush drawBrush = new SolidBrush(Color.White);


            //         if (reportInfoString == string.Empty)
            //             reportInfoString = "★★★★★";
            //         // Measure string.
            //         SizeF lockSize = new SizeF();
            //         lockSize = graph.MeasureString(reportInfoString.Substring(0, 1), drawFont);
            //         SizeF stringSize = new SizeF();
            //         stringSize = graph.MeasureString(reportInfoString, drawFont);
            //         txtWidth = (int)(stringSize.Width);

            //         reportInfoOffsetX += 150;

            //         offsetX = panel1.Width - reportInfoOffsetX;

            //         if (reportInfoOffsetX >= txtWidth + panel1.Width)
            //         {
            //             reportInfoOffsetX = 10;
            //             offsetX = panel1.Width - reportInfoOffsetX;
            //         }

            //         PointF location = new PointF();
            //         location.X = offsetX;
            //         location.Y = (panel1.Height - stringSize.Height) / 2;

            //         // Draw string to screen.
            //         graph.DrawString(reportInfoString, drawFont, Brushes.White, location);

            //     }
            //     catch (Exception ex)
            //     {
            //         CLog.WriteErrLogInTrace(ex.Message);
            //     }

            // }

             //private void panel1_Paint(object sender, PaintEventArgs e)
             //{

             //    DrawNoticeInfo(e.Graphics);

             //}
        #endregion

        private void lineinfoCtrl1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void ReportPanel_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized; 
            this.FormBorderStyle = FormBorderStyle.None;
        }


        private void SetWindowsStatus(bool status)
        {
            if (status)
            {

                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
            }

        }


        private void lineinfoCtrl1_DoChangeShowStatus(object sender, EventArgs e)
        {
                    try
                    {
                        bool ret = Convert.ToBoolean(sender);
                        SetWindowsStatus(ret);

                    }
                    catch(Exception ex)
                    {
                       MessageBox.Show(ex.Message);
                    }
 
        }

        private void pLineinfoCtrl1_KeyDown(object sender, KeyEventArgs e)
        {

        }

      
    }
  
}
