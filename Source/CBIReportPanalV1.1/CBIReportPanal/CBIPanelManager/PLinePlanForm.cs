using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Syd.ScheduleControls.Data;
using Syd.ScheduleControls.Region;
using Syd.ScheduleControls.Events;
using MDL;
using COM;
using DAL;

namespace CBIReportPanal
{
    public partial class PLinePlanForm : Form
    {
        public PLinePlanForm()
        {
            InitializeComponent();
        }

        private void PLinePlanForm_Load(object sender, EventArgs e)
        {
            loadParam();
            InitalCombox();
            LoadDataView();
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

        private void LoadDataView()
        {
            LoadPlanGrid();

           //DateTime weekstart = DateTime.Now;
           //dayView1.Date = weekstart;
            //dayView1.Appointments = CreateDefualtAppointments(weekstart);
            dayView1.AppointmentCreate += calendar_AppointmentAdd;
            dayView1.AppointmentEdit += calendar_AppointmentEdit;
           // dayView1.a
        }



        /// <summary>
        /// 加载默认的工作计划表
        /// </summary>
        /// <param name="date">The start date.</param>
        /// <returns></returns>
        private static AppointmentList CreateDefualtAppointments(DateTime date)
        {
            List<Brush> brushes = new List<Brush>();
            brushes.Add(Brushes.LimeGreen);
            brushes.Add(Brushes.PowderBlue);
            brushes.Add(Brushes.DarkGreen);
            brushes.Add(Brushes.Green);
            brushes.Add(Brushes.DimGray);
            brushes.Add(Brushes.Red);
            brushes.Add(Brushes.Yellow);
            brushes.Add(Brushes.Aquamarine);
            brushes.Add(Brushes.Plum);
            brushes.Add(Brushes.Orange);
            brushes.Add(Brushes.Pink);



            //create 7am of last monday
            DateTime timeStart = new DateTime(date.Year, date.Month, date.Day, 8, 30, 0);
            //while (timeStart.DayOfWeek != DayOfWeek.Monday)
            //{
            //    timeStart = timeStart.AddDays(-1);
            //}

            AppointmentList appts = new AppointmentList();

            int hoursToAdd = 1;
            
            for (int i = 0; i < 12; i++)
            {

                BrakePlanAppointments app = new BrakePlanAppointments();

                app.Subject = "无型号";
                app.ColorBlockBrush = Brushes.LimeGreen;
                app.DateStart = timeStart.AddHours(i*hoursToAdd);
                app.DateEnd = app.DateStart.AddMinutes(60);
                appts.Add(app);
            }
           

            appts.SortAppointments();

            return appts;
        }


        /// <summary>
        /// 加载计划列表
        /// </summary>
        private void LoadPlanGrid()
        {

            try
            {


                this.dayView1.Appointments.Clear();

                this.dayView1.RefreshAppointments();
                DateTime weekstart = this.dateTimePicker1.Value;
                dayView1.Date = weekstart;

                ProductionPlanDal dal = new ProductionPlanDal();

                int lineID = this.cbPLine.SelectedIndex+1;
                string planID = this.dateTimePicker1.Value.ToString("yyyyMMdd");
                planID = string.Format("{0}_{1}", planID, lineID);

                DataTable table=dal.GetProductionPalnByPlanID(planID);


                if (table == null || table.Rows.Count <= 0)
                {
                    this.dayView1.RefreshAppointments();

                    this.dayView1.Invalidate();
                    return;
                }
                else
                {



                    this.dayView1.Appointments = GetPlanPoints(table);

                    this.dayView1.RefreshAppointments();

                    this.dayView1.Invalidate();
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message.ToString());
            }

        }


        /// <summary>
        /// 获取产线点
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private AppointmentList GetPlanPoints(DataTable table)
        {
            try
            {
                AppointmentList list = new AppointmentList();

                DateTime timeStart = new DateTime(this.dateTimePicker1.Value.Year, 
                                                  this.dateTimePicker1.Value.Month, 
                                                  this.dateTimePicker1.Value.Day, 7, 30, 0);
                DateTime timeEnd=timeStart;

                int hoursToAdd   =  1;
                int minuteToAdd  =  60;

                List<TimeRange> rangs = new List<TimeRange>();

                //获取小时
                for (int i = 0; i < 12; i++)
                {
                    timeStart = timeStart.AddHours(hoursToAdd);

                    timeEnd = timeStart.AddMinutes(minuteToAdd);

                    TimeRange rang = new TimeRange();
                    rang.StartTime = timeStart;
                    rang.EndTime = timeEnd;
                    rangs.Add(rang);
                }


                foreach (DataRow itemRow in table.Rows)
                {
                    foreach(TimeRange item in rangs)
                    {
                        DateTime ptime1=Convert.ToDateTime(itemRow["start_time"].ToString());
                        DateTime ptime2= Convert.ToDateTime(itemRow["end_time"]);
                        
                        if(item.IsInFullRange(ptime1,ptime2))
                        {
                            ProductionPlanMDL mdl = new ProductionPlanMDL();
                            mdl.Prase(itemRow);

                            BrakePlanAppointments app = new BrakePlanAppointments();

                            app.Subject = string.Format("型号：{0} 预计产量:{1}实际产量:{2}",
                                mdl.BreakeID.ToString(), mdl.PlanNum.ToString(), mdl.Actual_num.ToString());
                            app.ColorBlockBrush = Brushes.OrangeRed;
                            app.DateStart = ptime1;
                            app.DateEnd = ptime2;
                            app.MDL = mdl;
                            list.Add(app);
                             break;
                        }

                        if (item.IsInRange(ptime1))
                        {
                            ProductionPlanMDL mdl = new ProductionPlanMDL();
                            mdl.Prase(itemRow);

                            BrakePlanAppointments app = new BrakePlanAppointments();

                            app.Subject = string.Format("型号：{0} 预计产量:{1}/r/n实际产量:{2}",
                                mdl.BreakeID.ToString(), mdl.PlanID.ToString(), mdl.Actual_num.ToString());
                            app.ColorBlockBrush = Brushes.OrangeRed;
                            app.DateStart = ptime1;
                            app.DateEnd = ptime2;
                            app.MDL = mdl;
                            list.Add(app);
                            break;
                        }
                           
                    }
                
                }

              
                return list;

            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.StackTrace);
                return null;
            }


        }

        private void InitalCombox()
        {
            try
            {
                this.cbPLine.DataSource = Enum.GetValues(typeof(COM.LineType));
                this.cbPLine.SelectedIndex = 0;
            }
            catch(Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
            }

        }

        /// <summary>
        /// Handles the AppointmentEdit event of the calendar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syd.ScheduleControls.Events.AppointmentEditEventArgs"/> instance containing the event data.</param>
        private void calendar_AppointmentEdit(object sender, AppointmentEditEventArgs e)
        {
            //show a dialog to edit the appointment
            using (PlaninfoItemForm dialog = new PlaninfoItemForm())
            {
                dialog.AppointmentDateStart = e.Appointment.DateStart;
                dialog.AppointmentDateEnd = e.Appointment.DateEnd;
                dialog.LineID = this.cbPLine.SelectedIndex + 1;

                ProductionPlanDal dal=new ProductionPlanDal();
        
                ProductionPlanMDL mdl=dal.GetProductionPalnByID(((BrakePlanAppointments)e.Appointment).MDL.TID);

                if (mdl != null)
                {
                    dialog.IsUpdate = true;
                    dialog.ProductionPlan = mdl;
                }
                else
                    dialog.IsUpdate = false;
         
                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    int ret=-1;

                    if(dialog.IsUpdate)
                    {
                        ret=dal.UpdateProductionPlanItem(dialog.ProductionPlan);
                    }
                    else
                    {
                        ret=dal.InsertProductionPlanItem(dialog.ProductionPlan);
                    }

                    if(ret>0)
                    {

                        LoadPlanGrid();
                        //    //if the user clicked 'save', update the appointment dates and title
                        //e.Appointment.DateStart = dialog.AppointmentDateStart;
                        //e.Appointment.DateEnd = dialog.AppointmentDateEnd;
                        //e.Appointment.Subject =dialog.ProductionPlan.BreakeID + ":" + dialog.ProductionPlan.PlanNum.ToString();
                        ////have to tell the controls to refresh appointment display
              
                        //dayView1.RefreshAppointments();
                  

                        MessageBox.Show("修改数据成功！");
                
                        //dayView1.Invalidate();
                    
                    }
                    else
                    {
                          MessageBox.Show("修改数据失败！");
                    }

                }
                else if (result == DialogResult.Abort)
                {
      
                    int  ret = dal.DeleteProudctionPlanItem(dialog.ProductionPlan.TID);
             

                    if (ret > 0)
                    {

                        LoadPlanGrid();
                        //    //if the user clicked 'save', update the appointment dates and title
                        //e.Appointment.DateStart = dialog.AppointmentDateStart;
                        //e.Appointment.DateEnd = dialog.AppointmentDateEnd;
                        //e.Appointment.Subject =dialog.ProductionPlan.BreakeID + ":" + dialog.ProductionPlan.PlanNum.ToString();
                        ////have to tell the controls to refresh appointment display

                        //dayView1.RefreshAppointments();


                        MessageBox.Show("删除数据成功！");

                        //dayView1.Invalidate();

                    }
                    else
                    {
                        MessageBox.Show("删除数据失败！");
                    }

                }
            }
        }


        /// <summary>
        /// Handles the AppointmentAdd event of the calendar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syd.ScheduleControls.Events.AppointmentCreateEventArgs"/> instance containing the event data.</param>
        private void calendar_AppointmentAdd(object sender, AppointmentCreateEventArgs e)
        {
            //show a dialog to add an appointment
            using (PlaninfoItemForm dialog = new PlaninfoItemForm())
            {
                dialog.LineID = this.cbPLine.SelectedIndex + 1;
                if (e.Date != null)
                {
                    dialog.AppointmentDateStart = e.Date.Value;
                    dialog.AppointmentDateEnd = e.Date.Value.AddMinutes(30);
                }

                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    ProductionPlanDal dal = new ProductionPlanDal();

                    if (dal.InsertProductionPlanItem(dialog.ProductionPlan) > 0)
                    {
                        //if the user clicked 'save', save the new appointment 
                        ////string title = dialog.AppointmentTitle;
                        //DateTime dateStart = dialog.AppointmentDateStart;
                        //DateTime dateEnd = dialog.AppointmentDateEnd;
                        //e.Control.Appointments.Add(new BrakePlanAppointments()
                        //{
                        //    Subject = dialog.ProductionPlan.BreakeID + ":" + dialog.ProductionPlan.PlanNum.ToString(),
                        //    DateStart = dateStart,
                        //    DateEnd = dateEnd
                        //});

                        ////have to tell the controls to refresh appointment display

                       // dayView1.RefreshAppointments();
                        // dayView2.RefreshAppointments();

                        //get the controls to repaint 
                        LoadPlanGrid();
                        MessageBox.Show("添加数据成功！");
                        //dayView1.Invalidate();
                    }
                    else
                    {
                        MessageBox.Show("添加数据失败！");
                    }

                }
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btApply_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btNew_Click(object sender, EventArgs e)
        {
            PlaninfoItemForm dialog = new PlaninfoItemForm();
     
            DateTime timeStart = new DateTime(this.dateTimePicker1.Value.Year, 
                                                this.dateTimePicker1.Value.Month, 
                                                this.dateTimePicker1.Value.Day, 8, 30, 0);
            DateTime timeEnd=timeStart.AddMinutes(60);

            dialog.AppointmentDateStart=timeStart;
            dialog.AppointmentDateEnd = timeEnd;
            dialog.LineID = this.cbPLine.SelectedIndex + 1;
            if (dialog.ShowDialog() == DialogResult.OK)
            {

                ProductionPlanDal dal = new ProductionPlanDal();

                if (dal.InsertProductionPlanItem(dialog.ProductionPlan) > 0)
                {
                    LoadPlanGrid(); 

                    MessageBox.Show("添加数据成功！");
                    dayView1.Invalidate();
                }
                else
                {
                    MessageBox.Show("添加数据失败！");
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.LoadPlanGrid();

        }

        private void 产品设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductionCfgForm form = new ProductionCfgForm();
            form.ShowDialog();
        }

        private void 更行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadDataView();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 公告消息设置NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoticeConfigForm form = new NoticeConfigForm();
            form.ShowDialog();
        }

        private void 关于AToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cbPLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadPlanGrid();
        }


      
      


    }
}
