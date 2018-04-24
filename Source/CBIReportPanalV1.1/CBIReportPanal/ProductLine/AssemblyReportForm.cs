using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using System.Collections;
using ProductLine.Utils;

namespace ProductLine
{
    public partial class AssemblyReportForm : Form
    {


        private ArrayList plinelist = new ArrayList();

        private int index = 0;


        public event EventHandler CloseReportPanelEvent;

        private string titleImg = "log.png";


        private string titleInfo = "泛博制动部件(武汉)有限公司";
        private string engtileInfo = "Chassis Brakes International (Wuhan) Co., Ltd ";

        public AssemblyReportForm()
        {

            InitializeComponent();

        }


        


        private void MainForm_Load(object sender, EventArgs e)
        {

            //ConvertToNewEMCData();

            InialPlineGridInfo();
            this.Location = new Point((1024 - 640), 0);
            UpdateAllGrid();

           // this.dataGridView1.Visible = false;
            LoadTimerUpdate();
        }


        private void UpdateAllGrid()
        {
            InitialTotalGridViewHeader();
            LoadTotalGridDataGrid();
          //  InitialGrid2ViewHeader();
         //   LoadDataGrid2();
        }

        /// <summary>
        /// 加载客户信息标题
        /// </summary>
        /// <summary>
        /// 初始化表单
        /// </summary>
        private void InitialTotalGridViewHeader()
        {

            dataGridView2.RowHeadersVisible = false;
            dataGridView2.Columns.Clear();
           // int columnWidth = (this.dataGridView2.Width / 5)- 1;
            int columnWidth = (this.dataGridView2.Width / 4) - 1;
            DataGridViewColumn plan0Column = null;

            //for (int i = 0; i < 5; i++)
            //{
            //    plan0Column = new DataGridViewTextBoxColumn();
            //    plan0Column.HeaderText = "     ";
            //    plan0Column.Name = "header";
            //    plan0Column.Width = columnWidth;
            //    dataGridView2.Columns.Add(plan0Column);
            //}

            for (int i = 0; i < 4; i++)
            {
                plan0Column = new DataGridViewTextBoxColumn();
                plan0Column.HeaderText = "     ";
                plan0Column.Name = "header";
                plan0Column.Width = columnWidth;
                dataGridView2.Columns.Add(plan0Column);
            }

            this.dataGridView2.Rows.Clear();
            dataGridView2.ClearSelection();
            this.dataGridView2.Enabled = false;
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.ScrollBars = ScrollBars.None;

        }

        /// <summary>
        /// 初始化数据列表
        /// </summary>
        private void LoadTotalGridDataGrid()
        {

            ///LoadColumnHeader();

            ArrayList list = new ArrayList();
            //list.Add("型 号");
            //list.Add("计划量");
            //list.Add("实际\r\n产量");
            //list.Add("OEE");
            //list.Add("备注");

            list.Add("PLine");
            list.Add("Produc\r\ttivity");
            list.Add("C/O");
          //  list.Add("Down Time");
            list.Add("OEE");

            int rowHeight = (int)((double)this.dataGridView2.Height /5) - 6;
            //if (pItems == null)
            //    return;

            Random ran = new Random();
            int RandKey = ran.Next(100, 999);

            DataGridViewRow row = new DataGridViewRow();


            int fontSize = 15;

            if (this.Width > 1000)
                fontSize = fontSize * 2;

          //  for (int i = 0; i < 5; i++)
            for (int i = 0; i < 4; i++)
            {
                DataGridViewTextBoxCell contentCell = new DataGridViewTextBoxCell();
                contentCell.Value = list[i].ToString();

                contentCell.Style.ForeColor = Color.White;
               // contentCell.Style.Font= new Font("黑体", 15, FontStyle.Bold);
                row.Cells.Add(contentCell);
            }
            row.Height = rowHeight;
            row.DefaultCellStyle.Font = new Font("黑体", fontSize, FontStyle.Bold);

            row.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView2.Rows.Add(row);


            for (int c = 0; c < 4; c++) 
            {
                row = new DataGridViewRow();

                for (int i = 0; i < 4; i++)
              //  for (int i = 0; i < 5; i++)
                {
                    DataGridViewTextBoxCell contentCell = new DataGridViewTextBoxCell();
                    switch (i)
                    {
                        case 0://编号
                            if (c>2)
                              contentCell.Value = "MGU Line";
                            else
                                contentCell.Value = "Line" + (c + 1).ToString();
                            break;
                        case 1://生产效率
                           // RandKey = ran.Next(8, 9.6);
                            //double productivity = CommUitls.GetRandomNumber(8.0, 9.6, 1);
                            //contentCell.Value = productivity.ToString(); //+ "%";

                            if ((c % 2) == 0)
                            {
                                double productivity = CommUitls.GetRandomNumber(8.2, 9.4, 1);
                                contentCell.Value = productivity.ToString();
                            }
                            else
                            {
                                double productivity = CommUitls.GetRandomNumber(8.0,9.0+c* 0.5, 1);
                                contentCell.Value = productivity.ToString() ;
                            }

                            break;
                        case 2://换型时间

                            if ((c % 2)== 0)
                            {
                                double change = CommUitls.GetRandomNumber(0.07, 0.21 + c * 0.05, 2);
                                contentCell.Value = change.ToString() + "h";
                            }
                            else
                            {
                                double change = CommUitls.GetRandomNumber(0.05, 0.22+ c * 0.02, 2);
                                contentCell.Value = change.ToString() + "h";
                            }

                            break;
                        //case 3://故障时间
                        //    //RandKey = ran.Next(88, 95);
                        //    //contentCell.Value =RandKey.ToString()+"%";

                        //    if ((c % 2) == 0)
                        //    {
                        //        double change = CommUitls.GetRandomNumber(0.02,c*0.10, 2);
                        //        contentCell.Value = change.ToString() + "h";
                        //    }
                        //    else
                        //    {
                        //        double change = CommUitls.GetRandomNumber(0.01, 0.10, 2);
                        //        contentCell.Value = change.ToString() + "h";
                        //    }
                        //    break;
                       // case 4:
                        case 3:
                            // RandKey = ran.Next(90, 97);
                            //contentCell.Value =RandKey.ToString()+"%";

                            int oee = GetRandomValue(c, 2);
                            contentCell.Value = oee.ToString() + "%";
                            break;
                        default:
                            break;

                    }

                    contentCell.Style.ForeColor = Color.White;
                    row.Cells.Add(contentCell);
                }
                row.Height = rowHeight;
                row.DefaultCellStyle.Font = new Font("黑体", fontSize, FontStyle.Bold);

                row.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView2.Rows.Add(row);
            }

            ////Cloumn
            //for (int i = 0; i < 4; i++)
            //{
            //    DataGridViewRow row = new DataGridViewRow();


            //    //row
            //    for (int j = 0; j < 5; j++)
            //    {
            //        DataGridViewTextBoxCell contentCell = new DataGridViewTextBoxCell();

            //        switch (j)
            //        {
            //            case 0:
            //                contentCell.Value = list[i];
            //                break;
            //            case 1:
            //                contentCell.Value = "Line"+(i+1).ToString();
            //                break;
            //            case 2:
            //                contentCell.Value = string.Empty; ;
            //                break;
            //            case 3:
            //                contentCell.Value = string.Empty;

            //                break;

            //            default:
            //                break;

            //        }
            //        contentCell.Style.ForeColor = Color.White;
            //        row.Cells.Add(contentCell);
            //    }

            //    row.Height = rowHeight;
            //    row.DefaultCellStyle.Font = new Font("黑体", 12, FontStyle.Bold);

            //    row.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //    row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    this.dataGridView2.Rows.Add(row);


            //}


        }


        /// <summary>
        /// 加载客户信息标题
        /// </summary>
        /// <summary>
        /// 初始化表单
        /// </summary>
        private void InitialGrid2ViewHeader()
        {

            //dataGridView1.RowHeadersVisible = false;
            //dataGridView1.Columns.Clear();
            //int columnWidth = (this.dataGridView1.Width / 5) - 1;

            //DataGridViewColumn plan0Column = null;

            //for (int i = 0; i < 5; i++)
            //{
            //    plan0Column = new DataGridViewTextBoxColumn();
            //    plan0Column.HeaderText = "     ";
            //    plan0Column.Name = "header";
            //    plan0Column.Width = columnWidth;
            //    dataGridView1.Columns.Add(plan0Column);
            //}

            //this.dataGridView1.Rows.Clear();
            //dataGridView1.ClearSelection();
            //this.dataGridView1.Enabled = false;
            //this.dataGridView1.ReadOnly = true;
            //this.dataGridView1.ScrollBars = ScrollBars.None;

        }

        /// <summary>
        /// 初始化数据列表
        /// </summary>
        //private void LoadDataGrid2()
        //{
        //    if (index >= 4)
        //        index = 0;

        //    ArrayList list = new ArrayList();

        //    list.Add("MGU Lin1");
        //    list.Add("PN");
        //    list.Add("PLAN");
        //    list.Add("ACTUAL");
        //    list.Add("OEE");

        //    PlineInfo info = (PlineInfo)plinelist[index];

        //    int rowHeight = (int)((double)this.dataGridView1.Height / 5) - 6;
        //    //if (pItems == null)
        //    //    return;

        //    Random ran = new Random();
        //    int RandKey = ran.Next(100, 999);

        //    DataGridViewRow row = new DataGridViewRow();


        //    for (int i = 0; i < 5; i++)
        //    {
        //        DataGridViewTextBoxCell contentCell = new DataGridViewTextBoxCell();
        //        if (i > 0)
        //        {
        //                contentCell.Value = list[i].ToString();
        //        }
        //        else
        //            contentCell.Value = "";


        //        contentCell.Style.ForeColor = Color.White;
        //        row.Cells.Add(contentCell);
        //    }


        //    row.Height = rowHeight;
        //    row.DefaultCellStyle.Font = new Font("黑体", 9, FontStyle.Bold);

        //    row.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        //    row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    this.dataGridView1.Rows.Add(row);


        //    for (int c = 0; c < 4; c++)
        //    {
        //        row = new DataGridViewRow();

        //        double oee = 0.0;
        //        int plan = 0;
        //        for (int i = 0; i < 5; i++)
        //        {
        //            DataGridViewTextBoxCell contentCell = new DataGridViewTextBoxCell();

    

        //            switch (i)
        //            {
        //                case 0:

        //                    //contentCell.Value = "MGU Lin1";
        //                    contentCell.Value=info.PLineID;
        //                    break;
        //                case 1:
        //                    //contentCell.Value = string.Empty;
        //                    contentCell.Value=info.PN[c];
        //                    break;
        //                case 2:
        //                    //RandKey = ran.Next(500, 800);
        //                    //contentCell.Value = (RandKey ).ToString();
        //                   // contentCell.Value = string.Empty;
        //                     plan = (int)CommUitls.GetRandomNumber(info.PLAN[c] - 10, info.PLAN[c] + 50, 2);
        //                      contentCell.Value = plan.ToString();
        //                    break;
        //                case 3:
                           
        //                    //contentCell.Value = (RandKey - 40).ToString();
        //                   // contentCell.Value = string.Empty;

        //                     oee = (int)CommUitls.GetRandomNumber(info.OEE[c] - 4, info.OEE[c] + 3, 2);
                           
        //                     double changeVal = oee / 100;
        //                   // int actual = (int)CommUitls.GetRandomNumber(info.Actual[c] - 10, info.Actual[c] + 50, 2);
        //                     int actual = (int)(plan * changeVal);

        //                     contentCell.Value = actual.ToString();
        //                    //contentCell.Value = info.Actual[i].ToString();
        //                    break;
        //                case 4:
        //                    //RandKey = ran.Next(88, 95);
        //                    //contentCell.Value = RandKey.ToString() + "%";
        //                   // contentCell.Value = string.Empty;

        //                   // int oee = (int)CommUitls.GetRandomNumber(info.OEE[c] - 4, info.OEE[c] + 3, 2);
        //                 //   int oee = GetRandomValue(info.PLineID, 2);
        //                    contentCell.Value = ((int)oee).ToString() + "%";
        //                    //contentCell.Value = info.OEE[i].ToString() + "%";
        //                    break;

        //                default:
        //                    break;

        //            }

        //            contentCell.Style.ForeColor = Color.White;
        //            row.Cells.Add(contentCell);
        //        }
        //        row.Height = rowHeight;
        //        row.DefaultCellStyle.Font = new Font("黑体", 9, FontStyle.Bold);

        //        row.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        //        row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //        this.dataGridView1.Rows.Add(row);
        //    }

        //    index++;

        //}


        private int  GetRandomValue(int lineID,int oee)
        {
            try
            {
                int ret = 80;

                switch (lineID)
                {
                    case 0:

                        ret = (int)CommUitls.GetRandomNumber(85, 87, 2);

                        break;
                    case 1:
                        ret = (int)CommUitls.GetRandomNumber(86, 90, 2);

                        break;
                    case 2:
                        ret = (int)CommUitls.GetRandomNumber(90, 92, 2);

                         break;
                    case 3:
                         ret = (int)CommUitls.GetRandomNumber(90, 94, 2);

                        break;
                    default:
                        break;

                }

                return ret;

            }
            catch
            {
                return 0;
            }
        }

        private void InialPlineGridInfo()
        {

            PlineInfo line1 = new PlineInfo();

            line1.PLineID = "Line1";
            List<string> pnlist1 = new List<string>();
            pnlist1.Add("102032");
            pnlist1.Add("10332");
            pnlist1.Add("104232");
            pnlist1.Add("156332");
            pnlist1.Add("132332");

            List<string> pnlist2= new List<string>();
            pnlist2.Add("201234");
            pnlist2.Add("201564");
            pnlist2.Add("207334");
            pnlist2.Add("101234");
            pnlist2.Add("421034");



            List<string> pnlist3 = new List<string>();
            pnlist3.Add("342343");
            pnlist3.Add("674354");
            pnlist3.Add("104232");
            pnlist3.Add("156332");
            pnlist3.Add("189923");


            List<string> pnlist4 = new List<string>();
            pnlist4.Add("212032");
            pnlist2.Add("323324");
            pnlist4.Add("404232");
            pnlist4.Add("213325");
            pnlist4.Add("232332");

            line1.PN = pnlist1;

            List<int> pList = new List<int>();
            pList.Add(1200);
            pList.Add(1300);
            pList.Add(1450);
            pList.Add(1420);
            pList.Add(1220);
            line1.PLAN = pList;

            List<int> actualList = new List<int>();
            actualList.Add(1254);
            actualList.Add(1249);
            actualList.Add(1239);
            actualList.Add(1322);
            actualList.Add(1122);
            line1.Actual = actualList;
            List<int> oeeList = new List<int>();
            oeeList.Add(86);
            oeeList.Add(88);
            oeeList.Add(90);
            oeeList.Add(92);
            oeeList.Add(92);
            line1.OEE = oeeList;

            plinelist.Add(line1);

            PlineInfo line2= new PlineInfo();

            line2.PLineID = "Line2";
            line2.PN = pnlist2;
            line2.PLAN = pList;
            line2.Actual = actualList;
            line2.OEE = oeeList;
            plinelist.Add(line2);

            PlineInfo line3 = new PlineInfo();

            line3.PLineID = "Line3";
            line3.PN = pnlist3;
            line3.PLAN = pList;
            line3.Actual = actualList;
            line3.OEE = oeeList;
            plinelist.Add(line3);

            PlineInfo line4 = new PlineInfo();

            line4.PLineID = "MGU\r\tLine";
            line4.PN = pnlist4;
            line4.PLAN = pList;
            line4.Actual = actualList;
            line4.OEE = oeeList;
            plinelist.Add(line4);
 
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopTimerUpdate();
        }


        private void ConvertToNewEMCData()
        {
            try
            {
                string stationFile = SystemUtils.ApplicationPath + "\\staion.csv";
                string emcFile = SystemUtils.ApplicationPath + "\\ct.csv";
                string destFile = SystemUtils.ApplicationPath + "\\Product.csv";
                
                CSVFileHelper.CombineTestData(stationFile, emcFile, destFile);

            }
            catch (System.Exception ex)
            {
            	
            }
            
        }



        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData ==Keys.S)
            {

                //if (DoChangeShowStatus != null)
                //{
                //    DoChangeShowStatus(true, EventArgs.Empty);
                //    InitialDataGridViewHeader();
                //    //dataGridView1.Rows[0].Selected = false;
                //    LoadDataGrid();
                //    this.dataGridView1.Invalidate();
                //}

                SetWindowsStatus(true);
            }
            else if (keyData ==Keys.Z)
            {

                //if (DoChangeShowStatus != null)
                //{
                //    InitialDataGridViewHeader();
                //    //dataGridView1.Rows[0].Selected = false;
                //    LoadDataGrid();
                //    DoChangeShowStatus(false, EventArgs.Empty);
                //    this.dataGridView1.Invalidate();
                //}
                SetWindowsStatus(false);
            }
          //  base.OnKeyDown(e);
            return base.ProcessDialogKey(keyData);
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

        private void AssemblyReportForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {

                //if (DoChangeShowStatus != null)
                //{
                //    DoChangeShowStatus(true, EventArgs.Empty);
                //    InitialDataGridViewHeader();
                //    //dataGridView1.Rows[0].Selected = false;
                //    LoadDataGrid();
                //    this.dataGridView1.Invalidate();
                //}


            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Z)
            {

                //if (DoChangeShowStatus != null)
                //{
                //    InitialDataGridViewHeader();
                //    //dataGridView1.Rows[0].Selected = false;
                //    LoadDataGrid();
                //    DoChangeShowStatus(false, EventArgs.Empty);
                //    this.dataGridView1.Invalidate();
                //}

            }
            base.OnKeyDown(e);
        }

        private void AssemblyReportForm_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView2_Resize(object sender, EventArgs e)
        {
            UpdateAllGrid();
        }
        /// <summary>
        /// 绘制配置文件信息
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="fontSize"></param>
        /// <param name="location"></param>
        private void drawTileInfo(Graphics graph, float fontSize, PointF location)
        {
            FileInfo info = new FileInfo(Utils.ApplicationInfo.ApplicationPath);
            string imgFile = info.Directory.FullName + "\\img\\" + titleImg;

            if (!File.Exists(imgFile))
                return;

            Image img = Image.FromFile(imgFile, true);
            graph.DrawImage(img, new Point(15, 15));


            //绘制星期
            // Create font and brush.
            Font drawFont = new Font("黑体", fontSize);
            SolidBrush drawBrush = new SolidBrush(Color.White);

            Font drawFont1 = new Font("arial", (float)(fontSize * 0.5));


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

            location.Y = (height - stringSize1.Height) - (stringSize1.Height / 2) * 3;//(stringSize1.Height) / 2;
            location.X = location.X + (stringSize.Width - stringSize1.Width) / 2 + 10;

            graph.DrawString(this.engtileInfo, drawFont1, Brushes.White, location);

        }
        private void splitContainer3_Panel1_Paint(object sender, PaintEventArgs e)
        {
            float fontSize = (float)(splitContainer3.Panel1.Height * 0.15);
            PointF point = new PointF();

            point.X = (float)(splitContainer3.Panel1.Width - (splitContainer3.Panel1.Width - (splitContainer3.Panel1.Width * 0.22)));
            point.Y = (float)(splitContainer3.Panel1.Height);
            drawTileInfo(e.Graphics, fontSize, point);
        }
    }
}
