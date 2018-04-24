using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using COMM;
using MDL;
//using DAL;
//using SQLiteDAL;
using DAL;
using DataGather;
using ZYReportControl;


namespace ZYReportControl
{
    public partial class PLineinfoCtrl : UserControl
    {
        #region Fields


        private int rowHeight = 0;

        private string titleImg = "log.png";


        private string titleInfo = "泛博制动部件(武汉)有限公司";
        private string engtileInfo = "Chassis Brakes International (Wuhan) Co., Ltd ";


        private List<string> list1 = new List<string>();
        private List<string> list2 = new List<string>();
        private Panel panel2;
        private SplitContainer splitContainer1;
        private Panel panel1;
        private Panel panel3;
        private DataGridView dataGridView1;
        private TableLayoutPanel tableLayoutPanel1;
        private CalendarView calendarView1;

        private DateTime curDateTime;

        private bool refreshReport = false;


        private PlinePlanMDL planMDL = null;

        #endregion


        private delegate void UpdateInfoDelegate();


        public  event EventHandler DoChangeShowStatus;

        #region properities

        public List<string> ColumnFist
        {
            get { return list1; }

            set { list1 = value; }
        }

        public List<string> ColumnSecond
        {
            get { return list2; }

            set { list2 = value; }
        }


        public DateTime DisplayDate
        {
            get { return curDateTime; }
            set { curDateTime = value; }
        }


        public bool RefreshReport
        {
            get { return refreshReport; }
           // set { curDateTime = value; }
        }
        #endregion



        #region
       
        /// <summary>
        /// 构造函数
        /// </summary>
        public PLineinfoCtrl()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
        }

        /// <summary>
        /// 公司标志和公司信息
        /// </summary>
        public void InfoUpdate()
        {

            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateInfoDelegate(DoInfoUpdate));
            }
            else
            {
                DoInfoUpdate();
            }

        }

        /// <summary>
        /// 跟新面板
        /// </summary>
        public void DoInfoUpdate()
        {
            panel1.Invalidate();
        }


        /// <summary>
        /// 数据列表显示
        /// </summary>
        public void DataGridUpdate()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateInfoDelegate(DoDatGridUpdate));
            }
            else
            {
                DoDatGridUpdate();
            }

        }


        public void DoDatGridUpdate()
        {
            this.LoadDataGrid();

        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.calendarView1 = new ZYReportControl.CalendarView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(715, 89);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(715, 89);
            this.splitContainer1.SplitterDistance = 586;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(586, 89);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.calendarView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(125, 89);
            this.panel3.TabIndex = 0;
            // 
            // calendarView1
            // 
            this.calendarView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calendarView1.Location = new System.Drawing.Point(0, 0);
            this.calendarView1.Name = "calendarView1";
            this.calendarView1.Size = new System.Drawing.Size(125, 89);
            this.calendarView1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Black;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(3, 98);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(715, 316);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            this.dataGridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyUp);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.02158F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.97842F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(721, 417);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // PLineinfoCtrl
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "PLineinfoCtrl";
            this.Size = new System.Drawing.Size(721, 417);
            this.Load += new System.EventHandler(this.LineinfoCtrl_Load);
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
      
           // e.Graphics.DrawRectangle(Pens.White, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height-1));
        }



        /// <summary>
        /// 绘制广告版信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

            //int rowSpan = tableLayoutPanel3.Height / 4;
            //int ctrlWidth=tableLayoutPanel3.Width;

            //int columSpan = ctrlWidth / 4;
            //int ctrlHeight = tableLayoutPanel3.Height;

            //// Create pen.
            //Pen whitePen = new Pen(Color.White, 3);

            //// Create points that define line.
            //Point point1;
            //Point point2;

            //TableLayoutColumnStyleCollection columnStyles=tableLayoutPanel3.ColumnStyles;


            //int offsetX = 0;
            //int offsetY = 0;

            //string drawString = list1[0];


            //// Create font and brush.

            //int fontSize = (int)(rowSpan * 0.2);

            //Font drawFont = new Font("黑体", fontSize);
            //SolidBrush drawBrush = new SolidBrush(Color.White);


            //// Measure string.
            //SizeF stringSize = new SizeF();
            //stringSize = e.Graphics.MeasureString(drawString, drawFont);
            //offsetY = (int)stringSize.Height;

            //int offsetCell = 0;

            //for (int col = 1; col <= 4; col++)
            //{
            //    if (col > 1)
            //        break;

            //    if (col % 2 != 0)
            //    {
            //        offsetX += columSpan - (int)(columSpan * 0.30);
            //    }
            //    else
            //    {
            //        offsetX += columSpan + (int)(columSpan * 0.30);
            //    }

            //    for (int row = 1; row <= 4; row++)
            //    {


            //        if (col % 2 != 0)
            //        {
            //            point1 = new Point();
            //            //point1.X = (offsetX - (int)stringSize.Width) - ((offsetX - (int)stringSize.Width)/2);
            //            offsetCell=  ((columSpan - (int)(columSpan * 0.30))-(int)stringSize.Width)/2;
            //            point1.X = (offsetX - (int)stringSize.Width) - offsetCell;
                                 
            //            //point1.Y = (rowSpan * row - (int)(stringSize.Height));// -((int)stringSize.Height / 2);

            //            point1.Y = (rowSpan * row - (int)(stringSize.Height)) - ((int)(rowSpan - stringSize.Height)) / 2;
            //            // if()
            //            drawCellInfo(e.Graphics, list1[row-1], fontSize, point1);

            //        }
            //        else
            //        {
            //            point1 = new Point();
            //            offsetCell = ((columSpan + (int)(columSpan * 0.30)) - (int)stringSize.Width)/2;
            //            point1.X = (offsetX - (int)stringSize.Width) - offsetCell;
            //            //- (int)(columSpan * 0.30) + offsetCell;
            //            //point1.X = (offsetX - (int)stringSize.Width) - (int)(columSpan * 0.30);
            //            //point1.Y = (rowSpan * row - (int)(stringSize.Height));// -((int)stringSize.Height / 2);
            //            point1.Y = (rowSpan * row - (int)(stringSize.Height)) - ((int)(rowSpan - stringSize.Height)) / 2;

            //            //drawCellInfo(e.Graphics, list1[row-1], fontSize, point1);

            //        }
                        
                      
            //    }
                   
            //}

            //offsetX = 0;

            //for (int i = 1; i < 4; i++)
            //{
            //    point1 = new Point(0, i * rowSpan);
            //    point2 = new Point(ctrlWidth, i * rowSpan);
            //    e.Graphics.DrawLine(whitePen, point1, point2);


            //    // ColumnStyle style=columnStyles[i];

            //    if (i % 2 != 0)
            //    {
            //        offsetX += columSpan - (int)(columSpan * 0.20);
            //        point1 = new Point(offsetX, 0);
            //        point2 = new Point(offsetX, ctrlHeight);
            //    }
            //    else
            //    {
            //        offsetX += columSpan + (int)(columSpan * 0.30);
            //        point1 = new Point(offsetX, 0);
            //        point2 = new Point(offsetX, ctrlHeight);
            //    }
            //    e.Graphics.DrawLine(whitePen, point1, point2);
            //}


            


           
        }


        /// <summary>
        /// 初始化表单
        /// </summary>
        private void InitialDataGridViewHeader()
        {

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns.Clear();
            int columnWidth = (this.dataGridView1.Width / 14)+6;

            DataGridViewColumn plan0Column = null;

            for (int i = 0; i < 13; i++)
            {
                plan0Column = new DataGridViewTextBoxColumn();
                plan0Column.HeaderText = "     ";
                plan0Column.Name = "header";
                plan0Column.Width = columnWidth;
                dataGridView1.Columns.Add(plan0Column);
            }
            /*
            DataGridViewColumn plan0Column = new DataGridViewTextBoxColumn();
            plan0Column.HeaderText = "     ";
            plan0Column.Name = "plan1";
            plan0Column.Width = columnWidth;
            dataGridView1.Columns.Add(plan0Column);


            DataGridViewColumn plan1Column = new DataGridViewTextBoxColumn();
            plan1Column.HeaderText = "8:30-9:30";
            plan1Column.Name = "plan1";
            plan1Column.Width = columnWidth;
            dataGridView1.Columns.Add(plan1Column);

            DataGridViewColumn plan2Column = new DataGridViewTextBoxColumn();
            plan2Column.HeaderText = "9:30-10:30";
            plan2Column.Name = "plan2";
            plan2Column.Width = columnWidth;
            dataGridView1.Columns.Add(plan2Column);

            DataGridViewColumn plan3Column = new DataGridViewTextBoxColumn();
            plan3Column.HeaderText = "10:30-11:30";
            plan3Column.Name = "plan3";
            plan3Column.Width = columnWidth;
            dataGridView1.Columns.Add(plan3Column);

            DataGridViewColumn plan4Column = new DataGridViewTextBoxColumn();
            plan4Column.HeaderText = "11:30-12:30";
            plan4Column.Name = "plan4";
            plan4Column.Width = columnWidth;
            dataGridView1.Columns.Add(plan4Column);


            DataGridViewColumn plan5Column = new DataGridViewTextBoxColumn();
            plan5Column.HeaderText = "12:30-13:30";
            plan5Column.Name = "plan5";
            plan5Column.Width = columnWidth;
            dataGridView1.Columns.Add(plan5Column);


            DataGridViewColumn plan6Column = new DataGridViewTextBoxColumn();
            plan6Column.HeaderText = "13:30-14:30";
            plan6Column.Name = "plan6";
            plan6Column.Width = columnWidth;
            dataGridView1.Columns.Add(plan6Column);

            DataGridViewColumn plan7Column = new DataGridViewTextBoxColumn();
            plan7Column.HeaderText = "14:30-15:30";
            plan7Column.Name = "plan7";
            plan7Column.Width = columnWidth;
            dataGridView1.Columns.Add(plan7Column);


            DataGridViewColumn plan8Column = new DataGridViewTextBoxColumn();
            plan8Column.HeaderText = "15:30-16:30";
            plan8Column.Name = "plan8";
            plan8Column.Width = columnWidth;
            dataGridView1.Columns.Add(plan8Column);


            DataGridViewColumn plan9Column = new DataGridViewTextBoxColumn();
            plan9Column.HeaderText = "16:30-17:30";
            plan9Column.Name = "plan9";
            plan9Column.Width = columnWidth;
            dataGridView1.Columns.Add(plan9Column);


            DataGridViewColumn plan10Column = new DataGridViewTextBoxColumn();
            plan10Column.HeaderText = "17:30-18:30";
            plan10Column.Name = "plan10";
            plan10Column.Width = columnWidth;
            dataGridView1.Columns.Add(plan10Column);

            DataGridViewColumn plan11Column = new DataGridViewTextBoxColumn();
            plan11Column.HeaderText = "18:30-19:30";
            plan11Column.Name = "plan11";
            plan11Column.Width = columnWidth;
            dataGridView1.Columns.Add(plan11Column);

            DataGridViewColumn plan12Column = new DataGridViewTextBoxColumn();
            plan12Column.HeaderText = "19:30-20:30";
            plan12Column.Name = "plan12";
            plan12Column.Width = columnWidth;
            dataGridView1.Columns.Add(plan12Column);


            */
 
            this.dataGridView1.Rows.Clear();

            dataGridView1.Font = new Font("黑体", 10);  

        }

        /// <summary>
        /// 绘制单元格信息
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="info"></param>
        /// <param name="fSize"></param>
        /// <param name="location"></param>
        private void drawCellInfo(Graphics graph,string info,int fSize,Point location)
        {
            // Create font and brush.
            Font drawFont = new Font("黑体", fSize);
            SolidBrush drawBrush = new SolidBrush(Color.White);


            // Measure string.
            SizeF stringSize = new SizeF();
            stringSize = graph.MeasureString(info, drawFont);

            // Draw string to screen.
            graph.DrawString(info, drawFont, Brushes.White,location);
        }


        /// <summary>
        /// 绘制配置文件信息
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="fontSize"></param>
        /// <param name="location"></param>
        private void drawTileInfo(Graphics graph,float fontSize,PointF location )
        {
            FileInfo info = new FileInfo(SystemUtils.ApplicationPath);
            string imgFile = info.Directory.FullName + "\\image\\" + titleImg;

            if (!File.Exists(imgFile))
                return;

            Image img = Image.FromFile(imgFile,true);
            graph.DrawImage(img, new Point(15, 15));

       
             //绘制星期
            // Create font and brush.
            Font drawFont = new Font("黑体", fontSize);
            SolidBrush drawBrush = new SolidBrush(Color.White);

            Font drawFont1 = new Font("arial", (float)(fontSize*0.5));
            

            // Measure string.
            SizeF stringSize = new SizeF();
            stringSize = graph.MeasureString(this.titleInfo, drawFont);

            SizeF stringSize1 = new SizeF();
            stringSize1 = graph.MeasureString(this.engtileInfo, drawFont1);

            int height = (int)location.Y;

            location.Y = (location.Y - stringSize.Height - stringSize1.Height) - ((location.Y - stringSize.Height) / 2);
            // Draw string to screen.
            graph.DrawString(this.titleInfo, drawFont, Brushes.White, location);



            drawFont1 = new Font("arial", (float)(fontSize * 0.6));
            stringSize1 = graph.MeasureString(this.engtileInfo, drawFont1);

            location.Y = (height - stringSize1.Height) - (stringSize1.Height/2)*3;//(stringSize1.Height) / 2;
            location.X = location.X + (stringSize.Width - stringSize1.Width) / 2+10;
          
            graph.DrawString(this.engtileInfo, drawFont1, Brushes.White, location);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

          // drawDatePanel(e.Graphics);
            

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
    

            float fontSize=(float)(panel1.Height*0.20);
            PointF point=new PointF();

            point.X=(float)(panel1.Width-(panel1.Width-(panel1.Width*0.35)));
            point.Y=(float)(panel1.Height);
            drawTileInfo(e.Graphics,fontSize,point);


        }



        /// <summary>
        /// 加载产线列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LineinfoCtrl_Load(object sender, EventArgs e)
        {
            InitialDataGridViewHeader();
            //dataGridView1.Rows[0].Selected = false;
            LoadDataGrid();
            dataGridView1.ClearSelection();
        }


        /// <summary>
        /// 获取计划项
        /// </summary>
        /// <returns></returns>
        private List<PlanItemMDL> GetPlanItems(out bool refreshReport)
        {

            refreshReport =false;

            try
            {
                List<PlanItemMDL> Plist = new List<PlanItemMDL>();


                DateTime timeStart = new DateTime(DateTime.Now.Year,
                                                  DateTime.Now.Month,
                                                  DateTime.Now.Day, 7, 30, 0);
                DateTime timeEnd = timeStart;

                int hoursToAdd = 1;
                int minuteToAdd = 60;

                List<TimeRange> rangs = new List<TimeRange>();


                DateTime curDateTime = DateTime.Now;
                //获取小时
                for (int i = 0; i < 12; i++)
                {
                    timeStart = timeStart.AddHours(hoursToAdd);

                    timeEnd = timeStart.AddMinutes(minuteToAdd);

                    TimeRange rang = new TimeRange();
                    rang.StartTime = timeStart;
                    rang.EndTime = timeEnd;
                    rangs.Add(rang);

                    PlanItemMDL pl = new PlanItemMDL();
                    pl.ProductID = "";
                    pl.PlanNumber = -1;
                    pl.ActualNumber = -1;
                    pl.Remark = "";
                    Plist.Add(pl);

                    //判断是否在当前范围内
                    if (rang.IsInRange(curDateTime))
                    {
                        int time = rang.EndTime.Subtract(curDateTime).Minutes;
                        time = 60 - time;
                        if (time <= 1)
                        {
                            refreshReport=true;
                        }
                    }
                }

                //ProductionPlanSQLiteDal dal = new ProductionPlanSQLiteDal();
               // ProductionPlanDal dal = new ProductionPlanDal();

               

                string planID = timeStart.ToString("yyyyMMdd");

                planID = string.Format("{0}_{1}", planID, BaseVariable.PLineID);

                //DataTable table = dal.GetProductionPalnByPlanID(planID);
                DataTable table = null;
                if (table == null || table.Rows.Count <= 0)
                {

                    return Plist;
                }

                ///获取数据内容
                foreach (DataRow itemRow in table.Rows)
                {
                    for (int j = 0; j < 12;j++ )
                    {
                        ///获得时间段信息
                        DateTime ptime1 = Convert.ToDateTime(itemRow["start_time"].ToString());
                        DateTime ptime2 = Convert.ToDateTime(itemRow["end_time"]);

                        //判断时间范围
                        if (rangs[j].IsInRange1(ptime1, ptime2) || rangs[j].IsInRange2(ptime1))
                        {
                            ProductionPlanMDL mdl = new ProductionPlanMDL();
                            mdl.Prase(itemRow);

                            //if (Plist[] == null)
                            //    pl = new PlanItemMDL();
                            if (mdl.PlanNum <= 0)
                            {
                                mdl.PlanNum = 0;
                                mdl.Actual_num = 0;
                            }

                            if (mdl.Actual_num <= 0)
                            {
                                //AcqCountListDAL acqCountdal = new AcqCountListDAL();
                                //AcqCountListSQLiteDAL acqCountdal = new AcqCountListSQLiteDAL();
                               // mdl.Actual_num = acqCountdal.GetRangeUnitCount(j.ToString());
                                    
                            }
                            

                            Plist[j].AddItem(mdl.BreakeID, mdl.PlanNum, mdl.Actual_num);
                            Plist[j].Remark = mdl.Remark;
                            break;
                        }


                    }
                }

                return Plist;

            }
            catch(Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return null;
            }
        }



        //private List<PlanItemMDL> GetPlanItems(PlinePlanMDL mdl,int type, out bool refeshReport)
        //{
           
            
        //    refreshReport = false;

        //    try
        //    {
        //        List<PlanItemMDL> Plist = new List<PlanItemMDL>();

        //        DateTime timeStart;
        //        DateTime timeEnd;
        //        int range = 0;

        //        if (type <= 1)
        //        {
        //             timeStart = new DateTime(DateTime.Now.Year,
        //                          DateTime.Now.Month,
        //                          DateTime.Now.Day, mdl.OP1_BEGIN.Hour, mdl.OP1_BEGIN.Minute, 0);
        //             timeEnd = timeStart.AddHours(mdl.OP1_RANGE);

        //             range = mdl.OP1_RANGE;

        //        }
        //        else
        //        {
        //            timeStart = new DateTime(DateTime.Now.Year,
        //                       DateTime.Now.Month,
        //                       DateTime.Now.Day, mdl.OP2_BEGIN.Hour, mdl.OP2_BEGIN.Minute, 0);
        //            timeEnd = timeStart.AddHours(mdl.OP2_RANGE);
        //            range = mdl.OP2_RANGE;

        //        }



        //        int hoursToAdd = 1;
        //        int minuteToAdd = 60;
        


        //        List<TimeRange> rangs = new List<TimeRange>();


        //        DateTime curDateTime = DateTime.Now;

        //        //获取小时
        //        for (int i = 0; i < range; i++)
        //        {
        //            timeStart = timeStart.AddHours(hoursToAdd);

        //            timeEnd = timeStart.AddMinutes(minuteToAdd);

        //            TimeRange rang = new TimeRange();
        //            rang.StartTime = timeStart;
        //            rang.EndTime = timeEnd;
        //            rangs.Add(rang);

        //            PlanItemMDL pl = new PlanItemMDL();
        //            pl.ProductID = "";
        //            pl.PlanNumber = -1;
        //            pl.ActualNumber = -1;
        //            pl.Remark = "";
        //            Plist.Add(pl);

        //            //判断是否在当前范围内
        //            if (rang.IsInRange(curDateTime))
        //            {
        //                int time = rang.EndTime.Subtract(curDateTime).Minutes;
        //                time = 60 - time;
        //                if (time <= 1)
        //                {
        //                    refreshReport = true;
        //                }
        //            }
        //        }

        //        ProductionPlanSQLiteDal dal = new ProductionPlanSQLiteDal();
        //        // ProductionPlanDal dal = new ProductionPlanDal();



        //        string planID = timeStart.ToString("yyyyMMdd");

        //        planID = string.Format("{0}_{1}", planID, BaseVariable.PLineID);

        //        DataTable table = dal.GetProductionPalnByPlanID(planID);

        //        if (table == null || table.Rows.Count <= 0)
        //        {
        //            refeshReport = false;

        //            return Plist;
        //        }

        //        ///获取数据内容
        //        foreach (DataRow itemRow in table.Rows)
        //        {
        //            for (int j = 0; j < range; j++)
        //            {
        //                ///获得时间段信息
        //                DateTime ptime1 = Convert.ToDateTime(itemRow["start_time"].ToString());
        //                DateTime ptime2 = Convert.ToDateTime(itemRow["end_time"]);

        //                //判断时间范围
        //                if (rangs[j].IsInRange1(ptime1, ptime2) || rangs[j].IsInRange2(ptime1))
        //                {
        //                    ProductionPlanMDL planItem = new ProductionPlanMDL();

        //                    planItem.Prase(itemRow);

        //                    //if (Plist[] == null)
        //                    //    pl = new PlanItemMDL();
        //                    if (planItem.PlanNum <= 0)
        //                    {
        //                        planItem.PlanNum = 0;
        //                        planItem.Actual_num = 0;
        //                    }

        //                    if (planItem.Actual_num <= 0)
        //                    {
        //                        //AcqCountListDAL acqCountdal = new AcqCountListDAL();
        //                        AcqCountListSQLiteDAL acqCountdal = new AcqCountListSQLiteDAL();
        //                        planItem.Actual_num = acqCountdal.GetRangeUnitCount(j.ToString());

        //                    }


        //                    Plist[j].AddItem(planItem.BreakeID, planItem.PlanNum, planItem.Actual_num);
        //                    Plist[j].Remark = planItem.Remark;
        //                    break;
        //                }


        //            }
        //        }

        //        return Plist;

        //    }
        //    catch (Exception ex)
        //    {
        //        CLog.WriteErrLogInTrace(ex.Message);
        //        return null;
        //    }
        //}


        /// <summary>
        /// 获取产线采集数据
        /// </summary>
        /// <param name="refreshReport"></param>
        /// <returns></returns>
        private List<AcqUnitMDL> GetPlanItemsMySql(string plineID,int op)
        {


            try
            {
                List<AcqUnitMDL> units = new List<AcqUnitMDL>();


                //DateTime timeStart = new DateTime(DateTime.Now.Year,
                //                                  DateTime.Now.Month,
                //                                  DateTime.Now.Day, 7, 30, 0);
                //DateTime timeEnd = timeStart;

                //int hoursToAdd = 1;
                //int minuteToAdd = 60;

                List<TimeRange> rangs = new List<TimeRange>();


                DateTime curDateTime = DateTime.Now;


                ProductLineCaculator productCa = new ProductLineCaculator();

                List<PDNumberUnit> pllist = productCa.PDActualNumberList;


                AcqLineDAL acqDAL = new AcqLineDAL();

                ChangeTimeDAL coDal = new ChangeTimeDAL();

                foreach (PDNumberUnit unit in pllist)
                {
                    string unitid = unit.GetTagID(plineID);

                    AcqUnitMDL acqunit = acqDAL.GetPlanItemByUnitID(plineID, unitid, op);

                    acqunit.StartTime = unit.rang.StartTime;
                    acqunit.EndTime = unit.rang.EndTime;

                    //换型时间
                    int cocount = coDal.GetChangeTimeByUnit(plineID, unitid);

                    acqunit.AddCO(cocount);

                    units.Add(acqunit);

                }

                if (units == null || units.Count <= 0)
                {
                    return null;
                }


                return units;
        
            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return null;
            }
        }




        private List<AcqUnitMDL> GetPlanItemsByTimeRange(PlinePlanMDL mdl,int type, List<OPMDL> items)
        {

            List<AcqUnitMDL> retUnits = new List<AcqUnitMDL>();

            try
            {
                ///获取时间范围
                TimeRange rang = mdl.GetTimeRange(type);

                AcqLineDAL acqDAL = new AcqLineDAL();


               // List<AcqLineCountMDL> acqs= acqDAL.GetAcqLineUnitByTimeRange(rang, mdl.PLINE);

                List<AcqLineItemMDL> acqs = acqDAL.GetAcqLineUnitByTimeRange(rang, mdl.PLINE);
                ///初始化显示信息单元
                for (int i = 0; i < items.Count; i++) 
                {
                    AcqUnitMDL acqunit = new AcqUnitMDL();

                    acqunit.PLINEID = string.Empty;
                    acqunit.StartTime=items[i].IIME_RANGE.StartTime;
                    acqunit.EndTime=items[i].IIME_RANGE.EndTime;

                    retUnits.Add(acqunit);

                }


                if(acqs==null||acqs.Count<=0)
                    return retUnits;



                int index=0;

                foreach(AcqUnitMDL unit in retUnits)
                {

                   // foreach(AcqLineCountMDL  lineInfo in acqs)
                    foreach (AcqLineItemMDL lineInfo in acqs)
                    {
                        if (unit.IsInAcqRange(lineInfo.START_TIME, lineInfo.END_TIME))
                        {
                            int seq = 0;
                            //获取序列号
                            seq = Convert.ToInt32(lineInfo.TGNAME);

                            //添加产品信息
                           // unit.AddProductItem(seq, lineInfo.UNITID, lineInfo.PN, lineInfo.CUR_COUNT, items[index].OP);
                           // unit.AddProductItem(seq, lineInfo.UNITID, lineInfo.PN,lineInfo.GetEMSCode(), lineInfo.CUR_COUNT, items[index].OP);

                            unit.StartTime = lineInfo.START_TIME;
                            unit.EndTime = lineInfo.END_TIME;

                            ChangeTimeDAL coDal = new ChangeTimeDAL();

                            int cocount = coDal.GetChangeTimeByUnit(mdl.PLINE, lineInfo.UNITID);

                            unit.AddCO(cocount);

                        }

                    }
                    index+=1;

                }

                return retUnits;
            }
            catch 
            {
                throw;
            }

        }

   /// <summary>
   /// 
   /// </summary>
   /// <param name="mdl"></param>
   /// <param name="type"></param>
   /// <returns></returns>
        private List<AcqUnitMDL> GetPlanItemsByMySql(PlinePlanMDL mdl,int type)
        {


            try
            {
                List<AcqUnitMDL> units = new List<AcqUnitMDL>();


                //DateTime timeStart = new DateTime(DateTime.Now.Year,
                //                                  DateTime.Now.Month,
                //                                  DateTime.Now.Day, 7, 30, 0);
                //DateTime timeEnd = timeStart;

                //int hoursToAdd = 1;
                //int minuteToAdd = 60;

                List<TimeRange> rangs = new List<TimeRange>();


                DateTime curDateTime = DateTime.Now;


                ///modify
                ProductLineCaculator productCa = new ProductLineCaculator(7,30,0,17);
                productCa.ReloadPlanUnits();

                List<PDNumberUnit> pllist = productCa.PDActualNumberList;


                AcqLineDAL acqDAL = new AcqLineDAL();

                ChangeTimeDAL coDal = new ChangeTimeDAL();

                //int range=0;

                //if(type<=1)
                //    range=mdl.OP1_RANGE;
                //else
                //    range=mdl.OP2_RANGE;




                int opIndex = 0;

                TimeRange rang = mdl.GetTimeRange(type);

                 List<OPMDL> opItems=null;

                 int lastRange = 0;

                 if (type <= 1)
                 {
                     opItems = mdl.OP1_ITEMS;
                   
                 }
                 else
                 {
                     //lastRange =mdl.OP1_RANGE - 1;
                     opItems = mdl.OP2_ITEMS;
                 }

                // mdl.ReloadOPMDL(ref opItems,7);

                 foreach (OPMDL item in opItems)
                 {
                     string unitid = String.Format("{0}{1}{2:D2}", item.IIME_RANGE.StartTime.ToString("yyyyMMdd"), mdl.PLINE, item.SEQ);
                    
                     AcqUnitMDL acqunit = acqDAL.GetPlanItemByUnitID(mdl.PLINE, unitid, opItems[opIndex].OP);

                     if (acqunit.PNCODE == string.Empty)
                     {
                         acqunit.StartTime = item.IIME_RANGE.StartTime;
                         acqunit.EndTime = item.IIME_RANGE.EndTime;
                     }

                     acqunit.OP = opItems[opIndex].OP.ToString();
                     //换型时间
                     int cocount = coDal.GetChangeTimeByUnit(mdl.PLINE, unitid);

                     acqunit.AddCO(cocount);

                     units.Add(acqunit);

                     opIndex++;

                 }


                //foreach (PDNumberUnit unit in pllist)
                //{

                //   // mdl.PLINE = string.Format("{0:D2}", Convert.ToInt32(mdl.PLINE));

                //   // string unitid = unit.GetTagID(mdl.PLINE);

                //    string unitid = unit.GetTagIDAddRange(mdl.PLINE, lastRange);

                //    if (rang.IsInRange(unit.rang.EndTime))
                //    {
                //        if (opIndex >= opItems.Count)
                //            continue;

                //        AcqUnitMDL acqunit = acqDAL.GetPlanItemByUnitID(mdl.PLINE, unitid, opItems[opIndex].OP);


                //        if (acqunit.PNCODE == string.Empty)
                //        {
                //            acqunit.StartTime = unit.rang.StartTime;
                //            acqunit.EndTime = unit.rang.EndTime;
                //        }

                //        acqunit.OP = opItems[opIndex].OP.ToString();
                //        //换型时间
                //        int cocount = coDal.GetChangeTimeByUnit(mdl.PLINE, unitid);

                //        acqunit.AddCO(cocount);

                //        units.Add(acqunit);

                //        opIndex++;

                //    }
                    //else
                    //{
                    //    AcqUnitMDL acqunit = new AcqUnitMDL();
                    //    acqunit.StartTime = unit.rang.StartTime;
                    //    acqunit.EndTime = unit.rang.EndTime;

                    //    units.Add(acqunit);
                    //}
                   

              //  }

                if (units == null || units.Count <= 0)
                {
                    return null;
                }


                return units;

            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return null;
            }
        }
        /// <summary>
        /// 初始化数据列表
        /// </summary>
        private void LoadDataGrid()
        {

            LoadColumnHeader();
            
            ArrayList list = new ArrayList();
            //list.Add("型 号");
            //list.Add("计划量");
            //list.Add("实际\r\n产量");
            //list.Add("OEE");
            //list.Add("备注");
            list.Add("PN");
            list.Add("ACTUAL");
            //list.Add("Produc\r\ttivity");
            list.Add("OEE");
            list.Add("C/0");
            list.Add("OP");

    

            //List<PlanItemMDL> pItems = GetPlanItems(out refreshReport);

            string plineID = string.Format("{0:D2}",Convert.ToInt32(BaseVariable.LineID));

  

            //if (pItems == null)
            //    return;

            //int rowHeight = (int)((double)this.dataGridView1.Height / 4) - 1;


            PlinePlanDAL dal = new PlinePlanDAL();

            //BaseVariable.LineID
            //PlinePlanMDL mdl = dal.GetPlanInfo(DateTime.Now.ToString("yyyyMMdd") + String.Format("{0:D2}", Convert.ToInt32(BaseVariable.LineID)));

            //int op=17;

            //if(mdl!=null)
            //    op = mdl.OP1;

           // in 

            int type=1;

            List<OPMDL> opItems=null;

            if (!planMDL.GetTimeRange(1).IsInRange(DateTime.Now))
            {
                opItems=this.planMDL.OP2_ITEMS;
                type = 2;

                       
            }
            else
            {
                opItems=this.planMDL.OP1_ITEMS;
            }

            //List<AcqUnitMDL> pItems = GetPlanItemsMySql(plineID, op);

           // List<AcqUnitMDL> pItems = GetPlanItemsByMySql(this.planMDL, type);

            List<AcqUnitMDL> pItems = GetPlanItemsByTimeRange(this.planMDL, type, opItems);

            int rowHeight = (int)((double)this.dataGridView1.Height / 6) - 1;
       
            IntialPlneDateColumn(opItems);
            //if()


            List<CTUnitMDL> ctUnits = new List<CTUnitMDL>();

            for (int i = 0; i < list.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell cellHeader = new DataGridViewTextBoxCell();
                cellHeader.Value = list[i];
               
                row.Cells.Add(cellHeader);


                if (pItems == null)
                    continue;


                string[] keys;


                ProductDal productDal = new ProductDal();

             

                //获取
                for (int j = 0; j < pItems.Count; j++)
                {
                    DataGridViewTextBoxCell contentCell = new DataGridViewTextBoxCell();

                

                    switch(i)
                    {


                        case 0:

                            if (pItems[j] == null || pItems[j].CODE == null)
                            {
                                contentCell.Value = String.Empty;
                                break;
                            }

                            keys = pItems[j].CODE.Split(',');

                            string pncode = string.Empty;

                            CTUnitMDL unit = null;

                              for (int k = 0; k < keys.Length; k++)
                              {


                                  if (keys[k] == null || keys[k].Trim() == string.Empty)
                                  {
                                      break;
                                  } 

                                  // unit = productDal.GetCTUnit(keys[k]);
                                     
                                  //CTUnitMDL mdl = pDal.GetCTUnit(acqUnit.PLINEID, acqUnit.EMS);

                                  if (unit == null)
                                  {
                                      
                                      pncode += keys[k];
                                  }
                                  else
                                  {
                                      pncode += unit.PN;
                                  }


                                  if (k != keys.Length - 1)
                                      pncode += "\r\n";


                              
                                  //if (BaseVariable.COHash.Contains(keys[k]))
                                  //{
                                  //    CTUnitMDL ct = (CTUnitMDL)BaseVariable.COHash[keys[k]];
                                  //    if (k == keys.Length-1)
                                  //        pncode += ct.PN;
                                  //    else
                                  //        pncode += ct.PN + "\r\n";
                                  //
                              }

                              ctUnits.Add(unit);

                              contentCell.Value = pncode;
                                  //contentCell.Value = pItems[j].PNCODE;
                            break;
                        case 1:
                            if (pItems[j].ACUTAL > 0)
                                contentCell.Value = pItems[j].ACUTAL;
                            else
                                contentCell.Value = string.Empty;
                            //contentCell.Value = pItems[j].ACUTAL.ToString();
                            break;
                        case 2:
                            if (pItems[j].ACUTAL > 0)
                            {



                                if (ctUnits.Count <= j)
                                {
                                    contentCell.Value = String.Empty;
                                    break;
                                }

                                if (ctUnits[j]!= null)
                                {

                                    contentCell.Value = pItems[j].GetFormatOEE(ctUnits[j].CT);
                                }
                                else
                                {
                                    contentCell.Value = "ERROR";
                                }

                                ////string pncode = pItems[j].PNCODE.Substring(0, 4);
                                //keys = pItems[j].CODE.Split(',');
                                //string key = keys[0];

                                //if (BaseVariable.COHash.Contains(key))
                                //{
                                //    CTUnitMDL ct = (CTUnitMDL)BaseVariable.COHash[key];
                                //    contentCell.Value = pItems[j].GetFormatOEE(ct.CT);
                                //}
                                //else
                                //{
                                //    contentCell.Value = "ERROR";
                                //}
                            
                             //string pncode=pItems[j].PNCODE.Substring(0,4);

                             //if (BaseVariable.COHash.Contains(pncode))
                             //{
                             //    CTUnitMDL ct = (CTUnitMDL)BaseVariable.COHash[pncode];
                             //    contentCell.Value = pItems[j].GetFormatOEE(ct.CT);
                             // }
                             //else
                             //{
                             //    contentCell.Value = "ERROR";
                             //}
                           
                            }
                            else
                            contentCell.Value = string.Empty;
                           break;
                        case 3:
                           if (pItems[j].ACUTAL > 0)
                               contentCell.Value = pItems[j].C0;
                           else
                               contentCell.Value = string.Empty;
                            break;
                        case 4:



                            contentCell.Value = opItems[j].OP.ToString();

                            //if (pItems[j].OP!=null)
                            //    contentCell.Value = pItems[j].OP.ToString();
                            //else
                            //    contentCell.Value = string.Empty;
                            ////if (mdl == null)
                            //{
                            //    contentCell.Value = "0";
                            //    break;
                            //}


                            // if (pItems[j].ACUTAL >0)
                            //     contentCell.Value = mdl.OP1.ToString();
                            //      else
                               //contentCell.Value = string.Empty;
         
                            break;
                        default:
                            break;
         
                    }

                    row.Cells.Add(contentCell);
                }

                row.Height = rowHeight;
                row.DefaultCellStyle.Font = new Font("黑体", 22, FontStyle.Bold);
                row.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Rows.Add(row);
                //this.dataGridView1.Invalidate();


            }


          

    
            //dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView1.ColumnHeadersVisible = false;
          
            //dataGridView1.RowTemplate.Height = 100;

            //dataGridView1.Height = dataGridView1.Rows.Count * dataGridView1.RowTemplate.Height + dataGridView1.ColumnHeadersHeight;
           
        }



        //private void LoadDataAcqGrid()
        //{
        //    try
        //    {
         
        //    LoadColumnHeader();

        //    ArrayList list = new ArrayList();
        //    //list.Add("型 号");
        //    //list.Add("计划量");
        //    //list.Add("实际\r\n产量");
        //    //list.Add("OEE");
        //    //list.Add("备注");

        //    list.Add("PN");
        //    list.Add("ACTUAL");
        //    //list.Add("Produc\r\ttivity");
        //    list.Add("OEE");
        //    list.Add("C/0");
        //    list.Add("OP");



        //    List<PlanItemMDL> pItems = GetPlanItems(out refreshReport);

        //    //List<AcqUnitMDL> pItems = GetPlanItemsMySql(Par);

        //    //if (pItems == null)
        //    //    return;

        //    //int rowHeight = (int)((double)this.dataGridView1.Height / 4) - 1;

        //    int rowHeight = (int)((double)this.dataGridView1.Height / 6) - 1;

        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        DataGridViewRow row = new DataGridViewRow();
        //        DataGridViewTextBoxCell cellHeader = new DataGridViewTextBoxCell();
        //        cellHeader.Value = list[i];

        //        row.Cells.Add(cellHeader);


        //        if (pItems == null)
        //            continue;

        //        //获取
        //        for (int j = 0; j < pItems.Count; j++)
        //        {
        //            DataGridViewTextBoxCell contentCell = new DataGridViewTextBoxCell();

        //            switch (i)
        //            {
        //                case 0:
        //                    contentCell.Value = pItems[j].ProductID;
        //                    break;
        //                case 1:
        //                    if (pItems[j].PlanNumber >= 0)
        //                        contentCell.Value = pItems[j].PlanNumber;
        //                    else
        //                        contentCell.Value = string.Empty;
        //                    break;
        //                case 2:
        //                    if (pItems[j].ActualNumber >= 0)
        //                        contentCell.Value = pItems[j].ActualNumber;
        //                    else
        //                        contentCell.Value = string.Empty;
        //                    break;
        //                case 3:
        //                    contentCell.Value = pItems[j].GetOEEPrint();
        //                    break;
        //                case 4:
        //                    string remark = pItems[j].Remark;

        //                    if ((int)remark.Length > 10)
        //                    {
        //                        remark = remark.Substring(0, 10);

        //                        remark = remark.Substring(0, 5) + "\r\n" + remark.Substring(5, 5);
        //                    }
        //                    else if ((int)remark.Length > 5)
        //                    {
        //                        remark = remark.Substring(0, 5) + "\r\n" + remark.Substring(5, remark.Length - 5);

        //                    }


        //                    contentCell.Value = remark;

        //                    break;
        //                default:
        //                    break;

        //            }

        //            row.Cells.Add(contentCell);
        //        }

        //        row.Height = rowHeight;
        //        row.DefaultCellStyle.Font = new Font("黑体", 22, FontStyle.Bold);
        //        row.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        //        row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //        this.dataGridView1.Rows.Add(row);
        //        //this.dataGridView1.Invalidate();


        //    }





        //    //dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        //    dataGridView1.ColumnHeadersVisible = false;

        //    //dataGridView1.RowTemplate.Height = 100;

        //    //dataGridView1.Height = dataGridView1.Rows.Count * dataGridView1.RowTemplate.Height + dataGridView1.ColumnHeadersHeight;


        //    }
        //    catch (System.Exception ex)
        //    {
        //        CLog.WriteErrLog("Load ACQ GRID :"+ ex.Message);

        //    }
        //}
        
        /// <summary>
        /// 当前列的加载头
        /// </summary>
        private void LoadColumnHeader()
        {
            try
            {

                if (!InitalPlineDateColumnItem())
                {
                    CreateDefualtGrid();
                }
                //{
                //   CreateDefualtGrid();
                //}
            }
            catch
            {
                throw;
            }


         
        }


        private bool InitalPlineDateColumnItem()
        {
            try
            {

                this.dataGridView1.ClearSelection();
                this.dataGridView1.Rows.Clear();

                //rowHeight = (int)((double)this.dataGridView1.Height / 7) - 1;

                //int hoursToAdd = 1;
                //int minuteToAdd = 60;

                int line = Convert.ToInt32(BaseVariable.LineID);

                string plainid = DateTime.Now.ToString("yyyyMMdd") + string.Format("{0:D2}", line);

              //  this.planMDL =ReloadNewPlan(plainid);

                this.planMDL.PLINE = string.Format("{0:D2}", line);

                ////早班
                //if (planMDL.GetTimeRange(1).IsInRange2(DateTime.Now))
                //{
                //    string tempSpanData = null;

                //    DataGridViewRow row = new DataGridViewRow();
                //    DataGridViewTextBoxCell celltext = new DataGridViewTextBoxCell();

                //    DateTime date = DateTime.Now;

                //    DateTime timeStart = new DateTime(date.Year, date.Month, date.Day,
                //                                      planMDL.OP1_BEGIN.Hour, planMDL.OP1_BEGIN.Minute, 0);

                //    DateTime timeEnd = timeStart;

                //    celltext.Value = "早班";
                //    celltext.Style.Font = new Font("Arail", 22, FontStyle.Bold);

                //    row.Cells.Add(celltext);

                //    for (int i = 0; i < planMDL.OP1_RANGE; i++)
                //    {
                //        // timeStart = timeStart.AddHours(hoursToAdd);

                //        timeEnd = timeStart.AddMinutes(minuteToAdd);

                //        tempSpanData = timeStart.ToString("HH:mm") + "\r\n" + timeEnd.ToString("HH:mm");

                //        celltext = new DataGridViewTextBoxCell();
                //        celltext.Value = tempSpanData;


                //        row.Cells.Add(celltext);

                //        timeStart = timeStart.AddHours(hoursToAdd);
                //    }

                //    row.Height = rowHeight;
                //    row.DefaultCellStyle.Font = new Font("黑体", 20, FontStyle.Bold);
                //    row.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //    row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //    this.dataGridView1.ScrollBars = ScrollBars.None;
                //    this.dataGridView1.Rows.Add(row);
                //}
                //else
                //{


                //    string tempSpanData = null;

                //    DataGridViewRow row = new DataGridViewRow();
                //    DataGridViewTextBoxCell celltext = new DataGridViewTextBoxCell();

                //    DateTime date = DateTime.Now;

                //    DateTime timeStart = new DateTime(date.Year, date.Month, date.Day,
                //                                      planMDL.OP2_BEGIN.Hour, planMDL.OP2_BEGIN.Minute, 0);

                //    DateTime timeEnd = timeStart;

                //    celltext.Value = "晚班";
                //    celltext.Style.Font = new Font("Arail", 23, FontStyle.Bold);

                //    row.Cells.Add(celltext);

                //    for (int i = 0; i < planMDL.OP2_RANGE; i++)
                //    {
                //        // timeStart = timeStart.AddHours(hoursToAdd);

                //        timeEnd = timeStart.AddMinutes(minuteToAdd);

                //        tempSpanData = timeStart.ToString("HH:mm") + "\r\n" + timeEnd.ToString("HH:mm");

                //        celltext = new DataGridViewTextBoxCell();
                //        celltext.Value = tempSpanData;

                //        row.Cells.Add(celltext);
                //        timeStart = timeStart.AddHours(hoursToAdd);
                //    }

                //    row.Height = rowHeight;
                //    row.DefaultCellStyle.Font = new Font("黑体", 20, FontStyle.Bold);
                //    row.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //    row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //    this.dataGridView1.ScrollBars = ScrollBars.None;
                //    this.dataGridView1.Rows.Add(row);
                //}



                return true;
            }
            catch
            {

                throw;
            }
        }

        private bool IntialPlneDateColumn(List<OPMDL> items)
        {
            try
            {

                this.dataGridView1.ClearSelection();
                this.dataGridView1.Rows.Clear();

                rowHeight = (int)((double)this.dataGridView1.Height / 7) - 1;
     
                int hoursToAdd = 1;
                int minuteToAdd = 60;

                int line = Convert.ToInt32(BaseVariable.LineID);

                string plainid = DateTime.Now.ToString("yyyyMMdd") + string.Format("{0:D2}", line);

                //this.planMDL = SystemUtils.ReloadNewPlan(plainid);

                this.planMDL.PLINE = string.Format("{0:D2}", line);

                //this.planMDL.ReloadOPMDL(ref items, 7);

                //早班
                if (planMDL.GetTimeRange(1).IsInRange2(DateTime.Now))
                {
                    string tempSpanData = null;

                    DataGridViewRow row = new DataGridViewRow();
                    DataGridViewTextBoxCell celltext = new DataGridViewTextBoxCell();

                    celltext.Value = "早班";
                    celltext.Style.Font = new Font("Arail", 22, FontStyle.Bold);

                    row.Cells.Add(celltext);

                    for (int i = 0; i < items.Count; i++)
                    {


                        tempSpanData = items[i].IIME_RANGE.StartTime.ToString("HH:mm") + "\r\n" + items[i].IIME_RANGE.EndTime.ToString("HH:mm");

                        celltext = new DataGridViewTextBoxCell();
                        celltext.Value = tempSpanData;


                        row.Cells.Add(celltext);

                    }

                    row.Height = rowHeight;
                    row.DefaultCellStyle.Font = new Font("黑体", 20, FontStyle.Bold);
                    row.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.dataGridView1.ScrollBars = ScrollBars.None;
                    this.dataGridView1.Rows.Add(row);
                }
                else
                {


                    string tempSpanData = null;

                    DataGridViewRow row = new DataGridViewRow();
                    DataGridViewTextBoxCell celltext = new DataGridViewTextBoxCell();

                    DateTime date = DateTime.Now;

                    DateTime timeStart = new DateTime(date.Year, date.Month, date.Day,
                                                      planMDL.OP2_BEGIN.Hour, planMDL.OP2_BEGIN.Minute, 0);

                    DateTime timeEnd = timeStart;

                    celltext.Value = "晚班";
                    celltext.Style.Font = new Font("Arail", 23, FontStyle.Bold);

                    row.Cells.Add(celltext);


                    for (int i = 0; i < items.Count; i++)
                    {


                        tempSpanData = items[i].IIME_RANGE.StartTime.ToString("HH:mm") + "\r\n" + items[i].IIME_RANGE.EndTime.ToString("HH:mm");

                        celltext = new DataGridViewTextBoxCell();
                        celltext.Value = tempSpanData;


                        row.Cells.Add(celltext);

                    }

                    row.Height = rowHeight;
                    row.DefaultCellStyle.Font = new Font("黑体", 20, FontStyle.Bold);
                    row.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.dataGridView1.ScrollBars = ScrollBars.None;
                    this.dataGridView1.Rows.Add(row);

                }


                return true;
            }
            catch
            {

                throw;
            }
  

        }


        private void CreateDefualtGrid()
        {

            this.dataGridView1.ClearSelection();
            this.dataGridView1.Rows.Clear();


            //行的宽度
            // rowHeight = (int)((double)this.dataGridView1.Height /6)-1;
            rowHeight = (int)((double)this.dataGridView1.Height / 7) - 1;
            DateTime date = DateTime.Now;
            DateTime timeStart = new DateTime(date.Year, date.Month, date.Day, 7, 30, 0);
            DateTime timeEnd = timeStart;
            int hoursToAdd = 1;
            int minuteToAdd = 60;

            string tempSpanData = null;

            DataGridViewRow row = new DataGridViewRow();


            DataGridViewTextBoxCell celltext = new DataGridViewTextBoxCell();
            celltext.Value = "";

            row.Cells.Add(celltext);

            for (int i = 0; i < 12; i++)
            {
                timeStart = timeStart.AddHours(hoursToAdd);

                timeEnd = timeStart.AddMinutes(minuteToAdd);

                tempSpanData = timeStart.ToString("HH:mm") + "\r\n" + timeEnd.ToString("HH:mm");

                celltext = new DataGridViewTextBoxCell();
                celltext.Value = tempSpanData;

                row.Cells.Add(celltext);
            }

            row.Height = rowHeight;
            row.DefaultCellStyle.Font = new Font("黑体", 20, FontStyle.Bold);
            row.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.ScrollBars = ScrollBars.None;
            this.dataGridView1.Rows.Add(row);
        }




        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {

        }


        /// <summary>
        /// 控制面板显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {

                if (DoChangeShowStatus != null)
                {
                    DoChangeShowStatus(true, EventArgs.Empty);
                    InitialDataGridViewHeader();
                    //dataGridView1.Rows[0].Selected = false;
                    LoadDataGrid();
                    this.dataGridView1.Invalidate();
                }


            }
            else if (e.Modifiers == Keys.Control&&e.KeyCode == Keys.Z)
            {

                if (DoChangeShowStatus != null)
                {
                    InitialDataGridViewHeader();
                    //dataGridView1.Rows[0].Selected = false;
                    LoadDataGrid();
                    DoChangeShowStatus(false, EventArgs.Empty);
                    this.dataGridView1.Invalidate();
                }

            }
            base.OnKeyDown(e);
        }



        private void dataGridView1_Resize(object sender, EventArgs e)
        {
            InitialDataGridViewHeader();
            //dataGridView1.Rows[0].Selected = false;
            LoadDataGrid();
            //this.dataGridView1.Invalidate();
            //DoChangeShowStatus(false, EventArgs.Empty);
            //this.dataGridView1.Invalidate();
        }


        #endregion

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (DoChangeShowStatus != null)
            {
                DoChangeShowStatus(true, EventArgs.Empty);
                InitialDataGridViewHeader();
                //dataGridView1.Rows[0].Selected = false;
                LoadDataGrid();
                this.dataGridView1.Invalidate();
            }
        }




    }
}
