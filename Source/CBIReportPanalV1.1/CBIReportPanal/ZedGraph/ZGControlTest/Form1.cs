//============================================================================
//ZedGraph demo code
//The code contained in this file (only) is released into the public domain, so you
//can copy it into your project without any license encumbrance.  Note that
//the actual ZedGraph library code is licensed under the LGPL, which is not
//public domain.
//
//This file is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
//=============================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using DataGather;
using COMM;
using MDL;
using DAL;

namespace ZGControlTest
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

		}


        private PlinePlanMDL planMDL = null;

        private void IntialPalnData()
        {
            ProductLineCaculator plc = new ProductLineCaculator();
            plc.ReLoad();

            int line = Convert.ToInt32(BaseVariable.LineID);

            string plainid = DateTime.Now.ToString("yyyyMMdd") + string.Format("{0:D2}", line);

            this.planMDL =ReloadNewPlan(plainid);

            this.planMDL.PLINE = string.Format("{0:D2}", line);


            GraphPane myPane = zg1.GraphPane;
            myPane.Fill = new Fill(Color.Black);

            myPane.XAxis.Title.Text = "Section of plan";
            myPane.XAxis.Title.FontSpec.FontColor = Color.White;
            myPane.XAxis.Type = AxisType.Date;
            myPane.XAxis.Scale.Format = "HH:mm";
           



            myPane.YAxis.Title.Text = "Changeover Time";
            myPane.YAxis.Title.FontSpec.FontColor = Color.White;


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

            LineDTDAL dtDal = new LineDTDAL();

            ChangeTimeDAL ctDal = new ChangeTimeDAL();

            TimeRange tRange=new TimeRange(opItems[0].IIME_RANGE.StartTime,opItems[opItems.Count-1].IIME_RANGE.EndTime);

            List<TimeRange> dtrangs = dtDal.GetTimeRangeByRange(this.planMDL.PLINE, tRange);
          

            
            PointPairList list = new PointPairList();
            PointPairList changelist = new PointPairList();
           


            Color changeColor = Color.White;



            for (int i = 0; i < opItems.Count;i++ )
            {
                int haveDt = 0;

                if (dtrangs != null && dtrangs.Count > 0)
                {
                    foreach (TimeRange item in dtrangs)
                    {

                        if (item.IsInFullRange(opItems[i].IIME_RANGE.StartTime, opItems[i].IIME_RANGE.EndTime))
                        {
                            haveDt = 1;
                            continue;
                        }

                    }
                }

              
                // double x = (double)i * 5.0;
                double x =(double)new XDate(opItems[i].IIME_RANGE.StartTime);
                 
                int count=0;

                if (haveDt<=0)
                    count = ctDal.GetChangeTime(opItems[i].LINEID.Substring(opItems[i].LINEID.Length - 2, 2), opItems[i].IIME_RANGE);
                 

                double changeOver = 0;

                if (count > 0)
                {
                    //除以分钟
                    changeOver = Math.Round((double)count / (double)60, 2);

                    if (changeOver > 18)
                    {
                        changeOver = 18;
                    }

                    if (changeOver > 10)
                    {
                        changeColor = Color.Red;
                    }

              
                }

                double y = 5;

                changelist.Add(x, changeOver);
                list.Add(x, y);
            }

            LineItem defualtCurve = myPane.AddCurve("Standard",
                list, Color.Yellow, SymbolType.None);

            LineItem changeOverCurve = myPane.AddCurve("ChangeOver",
               changelist, changeColor, SymbolType.Circle);
           // changeOverCurve.Symbol.Fill.Color = Color.White;
            changeOverCurve.Line.Width = 2;
            changeOverCurve.Symbol.Fill = new Fill(changeColor);
           
            
            defualtCurve.Label.IsVisible = false;
            changeOverCurve.Label.IsVisible = false;

            myPane.XAxis.Scale.FontSpec.FontColor = Color.White; 
            myPane.XAxis.Title.FontSpec.FontColor = Color.White;

            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.Scale.FontSpec.FontColor = Color.White;
            myPane.YAxis.Title.FontSpec.FontColor = Color.White;
            myPane.YAxis.Scale.Max = 18;
            myPane.YAxis.Scale.Min = -1;



       

            //// Fill the axis background with a gradient
             myPane.Chart.Fill = new Fill( Color.Black, Color.Black, 45.0f );


            //// Enable scrollbars if needed
             zg1.IsShowHScrollBar = false;
             zg1.IsShowVScrollBar = false;
             zg1.IsAutoScrollRange = true;
             zg1.IsScrollY2 = true;

            //// OPTIONAL: Show tooltips when the mouse hovers over a point
             zg1.IsShowPointValues = true;
             zg1.PointValueEvent += new ZedGraphControl.PointValueHandler(MyPointValueHandler);
             
           
            SetSize();

            //// Tell ZedGraph to calculate the axis ranges
            //// Note that you MUST call this after enabling IsAutoScrollRange, since AxisChange() sets
            //// up the proper scrolling parameters
            zg1.AxisChange();
            zg1.IsEnableHZoom = false;
            zg1.IsEnableVZoom = false;
            zg1.IsEnableWheelZoom = false;
            //// Make sure the Graph gets redrawn
            zg1.Invalidate();

  
        }


        public static PlinePlanMDL ReloadNewPlan(string pId)
        {

            PlinePlanMDL mdl = null;

            try
            {

                PlinePlanDAL dal = new PlinePlanDAL();

                if (dal.PlanExists(pId) <= 0)
                {

                    mdl = PlinePlanMDL.BuildDefualtPlan(Convert.ToInt32(BaseVariable.LineID),
                                                                    DateTime.Now);
                    if (dal.AddPlinePlan(mdl) > 0)
                    {
                        return mdl;
                    }

                    return null;

                }
                else
                {
                    mdl = dal.GetPlanInfo(pId);

                    return mdl;
                }

                return null;

            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message.ToString());

            }

            return null;
        }

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

        public bool loadParam()
        {


            try
            {
                XmlHelper helper = new XmlHelper("App.xml");
                BaseVariable.DBConnStr = helper.SelectValue("/Root/APP/DBConnstr");
                BaseVariable.DataCheckOut = helper.SelectValue("/Root/APP/DataCheckOut");
                BaseVariable.SysDebug = helper.SelectValue("/Root/APP/SysDebug");
                MySqlDBHelper.Conn = BaseVariable.DBConnStr;

                BaseVariable.PLineID = Convert.ToInt32(helper.SelectValue("/Root/APP/LineID"));


                string line = helper.SelectValue("/Root/APP/LineID");

                //String.Format("{0:D2}",Convert.ToInt32(line));

                BaseVariable.LineID = String.Format("{0:D2}", Convert.ToInt32(line));

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

		private void Form1_Load( object sender, EventArgs e )
		{



            loadParam();


            if (!LoadDB())
            {

                MessageBox.Show("初始化数据库失败，请连接管理员！");
                this.Dispose();
                return;
            }


          


            IntialPalnData();

            //// Get a reference to the GraphPane instance in the ZedGraphControl
            //GraphPane myPane = zg1.GraphPane;
            //myPane.Fill = new Fill(Color.Black);
          
            
            //// Set the titles and axis labels
            //myPane.Title.Text = "Demonstration of Dual Y Graph";
            //myPane.XAxis.Title.Text = "Time, Days";
            //myPane.XAxis.Title.FontSpec.FontColor = Color.White;

            //myPane.YAxis.Title.Text = "Parameter A";
            //myPane.Y2Axis.Title.Text = "Parameter B";

            //// Make up some data points based on the Sine function
            //PointPairList list = new PointPairList();
            //PointPairList list2 = new PointPairList();
            //for ( int i = 0; i < 36; i++ )
            //{
            //    double x = (double)i * 5.0;
            //    double y = Math.Sin( (double)i * Math.PI / 15.0 ) * 16.0;
            //    double y2 = y * 13.5;
            //    list.Add( x, y );
            //    list2.Add( x, y2 );
            //}

            //// Generate a red curve with diamond symbols, and "Alpha" in the legend
            //LineItem myCurve = myPane.AddCurve( "Alpha",
            //    list, Color.Red, SymbolType.Diamond );
            //// Fill the symbols with white
            //myCurve.Symbol.Fill = new Fill( Color.White );
           
            //// Generate a blue curve with circle symbols, and "Beta" in the legend
            //myCurve = myPane.AddCurve( "Beta",
            //    list2, Color.Blue, SymbolType.Circle );
            //// Fill the symbols with white
            //myCurve.Symbol.Fill = new Fill( Color.White );
            //// Associate this curve with the Y2 axis
            //myCurve.IsY2Axis = true;

            //// Show the x axis grid
            //myPane.XAxis.MajorGrid.IsVisible = true;

            //// Make the Y axis scale red
            //myPane.YAxis.Scale.FontSpec.FontColor = Color.Red;
            //myPane.YAxis.Title.FontSpec.FontColor = Color.Red;
            //// turn off the opposite tics so the Y tics don't show up on the Y2 axis
            //myPane.YAxis.MajorTic.IsOpposite = false;
            //myPane.YAxis.MinorTic.IsOpposite = false;
            //// Don't display the Y zero line
            //myPane.YAxis.MajorGrid.IsZeroLine = false;
            //// Align the Y axis labels so they are flush to the axis
            //myPane.YAxis.Scale.Align = AlignP.Inside;
            //// Manually set the axis range
            //myPane.YAxis.Scale.Min = -30;
            //myPane.YAxis.Scale.Max = 30;

            //// Enable the Y2 axis display
            //myPane.Y2Axis.IsVisible = true;
            //// Make the Y2 axis scale blue
            //myPane.Y2Axis.Scale.FontSpec.FontColor = Color.Blue;
            //myPane.Y2Axis.Title.FontSpec.FontColor = Color.Blue;
            //// turn off the opposite tics so the Y2 tics don't show up on the Y axis
            //myPane.Y2Axis.MajorTic.IsOpposite = false;
            //myPane.Y2Axis.MinorTic.IsOpposite = false;
            //// Display the Y2 axis grid lines
            //myPane.Y2Axis.MajorGrid.IsVisible = true;
            //// Align the Y2 axis labels so they are flush to the axis
            //myPane.Y2Axis.Scale.Align = AlignP.Inside;

            //// Fill the axis background with a gradient
            //myPane.Chart.Fill = new Fill( Color.White, Color.LightGray, 45.0f );

            //// Add a text box with instructions
            //TextObj text = new TextObj(
            //    "Zoom: left mouse & drag\nPan: middle mouse & drag\nContext Menu: right mouse",
            //    0.05f, 0.95f, CoordType.ChartFraction, AlignH.Left, AlignV.Bottom );
            //text.FontSpec.StringAlignment = StringAlignment.Near;
            //myPane.GraphObjList.Add( text );

            //// Enable scrollbars if needed
            //zg1.IsShowHScrollBar = true;
            //zg1.IsShowVScrollBar = true;
            //zg1.IsAutoScrollRange = true;
            //zg1.IsScrollY2 = true;

            //// OPTIONAL: Show tooltips when the mouse hovers over a point
            //zg1.IsShowPointValues = true;
            //zg1.PointValueEvent += new ZedGraphControl.PointValueHandler( MyPointValueHandler );

            //// OPTIONAL: Add a custom context menu item
            //zg1.ContextMenuBuilder += new ZedGraphControl.ContextMenuBuilderEventHandler(
            //                MyContextMenuBuilder );

            //// OPTIONAL: Handle the Zoom Event
            //zg1.ZoomEvent += new ZedGraphControl.ZoomEventHandler( MyZoomEvent );

            //// Size the control to fit the window
            //SetSize();

            //// Tell ZedGraph to calculate the axis ranges
            //// Note that you MUST call this after enabling IsAutoScrollRange, since AxisChange() sets
            //// up the proper scrolling parameters
            //zg1.AxisChange();
            //zg1.IsEnableHZoom = false;
            //zg1.IsEnableVZoom = false;
            //zg1.IsEnableWheelZoom = false;
            //// Make sure the Graph gets redrawn
            //zg1.Invalidate();
           
		}

        


		/// <summary>
		/// On resize action, resize the ZedGraphControl to fill most of the Form, with a small
		/// margin around the outside
		/// </summary>
		private void Form1_Resize( object sender, EventArgs e )
		{
			SetSize();
		}

		private void SetSize()
		{
			zg1.Location = new Point( 10, 10 );
			// Leave a small margin around the outside of the control
			zg1.Size = new Size( this.ClientRectangle.Width - 20,
					this.ClientRectangle.Height - 20 );
		}

		/// <summary>
		/// Display customized tooltips when the mouse hovers over a point
		/// </summary>
		private string MyPointValueHandler( ZedGraphControl control, GraphPane pane,
						CurveItem curve, int iPt )
		{
			// Get the PointPair that is under the mouse
			PointPair pt = curve[iPt];

			return curve.Label.Text + " is " + pt.Y.ToString( "f2" ) + " units at " + pt.X.ToString( "f1" ) + " days";
		}

		/// <summary>
		/// Customize the context menu by adding a new item to the end of the menu
		/// </summary>
		private void MyContextMenuBuilder( ZedGraphControl control, ContextMenuStrip menuStrip,
						Point mousePt, ZedGraphControl.ContextMenuObjectState objState )
		{
			ToolStripMenuItem item = new ToolStripMenuItem();
			item.Name = "add-beta";
			item.Tag = "add-beta";
			item.Text = "Add a new Beta Point";
			item.Click += new System.EventHandler( AddBetaPoint );

			menuStrip.Items.Add( item );
		}

		/// <summary>
		/// Handle the "Add New Beta Point" context menu item.  This finds the curve with
		/// the CurveItem.Label = "Beta", and adds a new point to it.
		/// </summary>
		private void AddBetaPoint( object sender, EventArgs args )
		{
			// Get a reference to the "Beta" curve IPointListEdit
			IPointListEdit ip = zg1.GraphPane.CurveList["Beta"].Points as IPointListEdit;
			if ( ip != null )
			{
				double x = ip.Count * 5.0;
				double y = Math.Sin( ip.Count * Math.PI / 15.0 ) * 16.0 * 13.5;
				ip.Add( x, y );
				zg1.AxisChange();
				zg1.Refresh();
			}
		}

		// Respond to a Zoom Event
		private void MyZoomEvent( ZedGraphControl control, ZoomState oldState,
					ZoomState newState )
		{
			// Here we get notification everytime the user zooms
		}


	}
}