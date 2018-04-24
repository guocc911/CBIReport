using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MDL;
using COMM;
//using DAL;
using SQLiteDAL;

namespace CBIReportPanal
{
    public partial class PlaninfoItemForm : Form
    {

        private bool isUpdate = false;

        private int _lineID = -1;


        private ProductionPlanMDL plan = null;

        public bool IsUpdate
        {
            get { return isUpdate; }

            set { isUpdate = value; }
        }



        public ProductionPlanMDL ProductionPlan
        {
            get { return plan; }

            set { plan = value; }
        }

        public int LineID
        {
            set { _lineID = value; }
        }


        public DateTime AppointmentDateEnd { get { return this.dtpDateEnd.Value; } set { this.dtpDateEnd.Value = value; } }
        /// <summary>
        /// Gets or sets the appointment date start.
        /// </summary>
        /// <value>
        /// The appointment date start.
        /// </value>
        public DateTime AppointmentDateStart { get { return this.dtpDateStart.Value; } set { this.dtpDateStart.Value = value; } }


        public PlaninfoItemForm()
        {
            InitializeComponent();
        }




        /// <summary>
        /// 加载窗口
        /// </summary>
        private void LoadPlanInfo()
        {
            if (isUpdate)
            {
                Text = "CBI产品计划";
                this.txtPlan_Num.Text = plan.PlanNum.ToString();
                this.txtRemark.Text = plan.Remark;
                this.lbLineID.Text = _lineID.ToString() + "号产线";
               // this.txtActualNum.Text = plan.Actual_num.ToString();
                this.txtPlan_Num.Text=plan.PlanNum.ToString();
                this.txtRemark.Text = plan.Remark.ToString();
                this.btSave.Text = "修改";
                this.btDel.Visible = true;
            }
            else
            {
                Text = "CBI新增产品计划修改";
                this.txtPlan_Num.Text = "0";
                this.txtRemark.Text = "0";
                this.btDel.Visible = false;
            }

            InitalCombox();
        }



        /// <summary>
        /// 
        /// </summary>
        private void InitalCombox()
        {
            try
            {
                //this.cbLineNum.DataSource = Enum.GetValues(typeof(COM.LineType));
                //this.cbLineNum.SelectedIndex = 0;

                //this.cbLineNum.SelectedIndex = this._lineID-1;



                this.lbLineID.Text = _lineID.ToString() + "号产线";

                //if (isUpdate)
                //{
                //    this.cbLineNum.SelectedIndex = this._lineID;
                //}

               // ProductDal dal = new ProductDal();
                ProductSQLiteDal dal = new ProductSQLiteDal();

         
                this.cbProductioName.DataSource = dal.GetProductionNames();

                if (this.cbProductioName.DataSource!=null)
                   this.cbProductioName.SelectedIndex = 0;

                if (isUpdate)
                {
                    this.cbProductioName.Text = plan.BreakeID;
                }


                this.cbShift.DataSource = Enum.GetValues(typeof(COMM.ShiftType));
                this.cbShift.SelectedIndex = 0;

                    
                if (isUpdate)
                {

                    this.cbShift.SelectedIndex = (int)plan.Shift;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btSave_Click(object sender, EventArgs e)
        {

            try
            {

                //if (this.cbLineNum.Text.Trim().Length < 1)
                //{
                //    MessageBox.Show("请选择生产线！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //}

                if (this.cbProductioName.Text.Trim().Length < 1)
                {
                    MessageBox.Show("请填写产品名称！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }

                if (this.txtPlan_Num.Text.Trim().Length < 1)
                {
                    MessageBox.Show("请填写预计产量！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

                if (this.cbShift.Text.Trim().Length < 1)
                {
                    MessageBox.Show("请选择班次！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

                if (isUpdate)
                {
                    
                   // plan.Pline_ID = this.cbLineNum.SelectedIndex;
                    plan.Pline_ID = this._lineID;
                    plan.BreakeID = this.cbProductioName.Text.Trim();
                    plan.PlanNum = Convert.ToInt32(this.txtPlan_Num.Text.Trim());
                  //  plan.Actual_num = Convert.ToInt32(this.txtActualNum.Text.Trim());
                    plan.StartTime = this.dtpDateStart.Value;
                    plan.EndTime = this.dtpDateEnd.Value;
                    plan.Shift = this.cbShift.SelectedIndex;
                    plan.Remark = this.txtRemark.Text.Trim();
                 
                }
                else
                {
                    plan = new ProductionPlanMDL();
                    plan.PlanID = string.Format("{0}_{1}", this.dtpDateStart.Value.ToString("yyyyMMdd"), this._lineID);
                   // plan.Pline_ID = this.cbLineNum.SelectedIndex;
                    plan.Pline_ID =this._lineID;
                    plan.BreakeID = this.cbProductioName.Text.Trim();
                    plan.PlanNum = Convert.ToInt32(this.txtPlan_Num.Text.Trim());
                    plan.StartTime = this.dtpDateStart.Value;
                    plan.EndTime = this.dtpDateEnd.Value;
                    plan.Shift = this.cbShift.SelectedIndex;
                    plan.CreateTime = DateTime.Now;
                    plan.Remark = this.txtRemark.Text.Trim();
                }

                //info.Remark = this.txtRemark.Text.Trim();

                this.DialogResult = DialogResult.OK;

                this.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void PlaninfoItemForm_Load(object sender, EventArgs e)
        {
            LoadPlanInfo();
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort; ;
            this.Close();
        }

      



    }
}
