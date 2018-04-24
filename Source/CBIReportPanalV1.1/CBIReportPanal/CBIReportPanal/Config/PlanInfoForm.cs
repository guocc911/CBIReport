using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MDL;
using COMM;
using DAL;

namespace CBIReportPanal.Config
{
    public partial class PlanInfoForm : Form
    {

        private bool isUpdate=false;


        private bool loadPlan = false;


        private PlinePlanMDL plineMDL = null;

        private delegate void delegateChangeValue(int index);


        #region properties

        public bool IsUpdate
        {
            get { return isUpdate; }

            set { isUpdate = value; }
        }


        public PlinePlanMDL PLAN 
        {
            get { return plineMDL; }

            set { plineMDL = value; }
        }





        #endregion



        public PlanInfoForm()
        {
            InitializeComponent();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {

            try
            {

                if (this.txtOP1.Text.Trim().Length<1)
                {
                    MessageBox.Show("请填写早班人数", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (this.txtOP2.Text.Trim().Length < 1)
                {
                    MessageBox.Show("请填写晚班人数", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }


                
              

                if (!this.plineMDL.GetTimeRange(1).IsLessThan(this.plineMDL.GetTimeRange(2).StartTime))
                {
                    MessageBox.Show("晚班的起始时间必须大于早报的结束时间！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }


              //  if(this.plineMDL.OP1_RANGE!=this.cb)

               // if (PlinePlanMDL.CheckOPSet(this.plineMDL.GetTimeRange(1).StartTime, this.plineMDL.OP1_RANGE, this.plineMDL.GetTimeRange(2).StartTime))
               //{
               //    MessageBox.Show("晚班的起始时间需要大于早班的结束时间！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
               //}


             //   this.plineMDL.OP1 = Convert.ToInt32(txtOP1.Text.Trim());
              //  this.plineMDL.OP2 = Convert.ToInt32(txtOP2.Text.Trim());


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


        private void ProuctionInfo_Load(object sender, EventArgs e)
        {
            LoadPlanInfo();
        }


        /// <summary>
        /// 加载窗口
        /// </summary>
        private void LoadPlanInfo()
        {

            try
            {
                this.lbLineid.Text = this.plineMDL.NAME;

                this.lbPlanDate.Text = this.plineMDL.CREATE_TIME.ToShortDateString();

                this.txtOP1.Text = this.plineMDL.OP1.ToString();

                this.txtOP2.Text = this.plineMDL.OP2.ToString();

                loadPlan = false;


                InitalCombox();




                loadPlan = true;
                //LoadRangeChange();


                this.comboBox1.SelectedIndex = this.plineMDL.OP1_RANGE - 1;

                this.comboBox2.SelectedIndex = this.plineMDL.OP2_RANGE - 1;



            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
       
        }


        private void LoadRangeChange(int index)
        {


  

            if (this.comboBox1.DataSource != null && index==1)
            {
                if (loadPlan)
                {
                    this.plineMDL.OP1_RANGE = this.comboBox1.SelectedIndex + 1;

                    this.plineMDL = PlinePlanMDL.ReLoadPlanMDL(this.plineMDL);
                  
                }
               
                TimeRange range1 = this.plineMDL.GetTimeRange(1);
                this.dateTimePicker1.Value = range1.StartTime;
                this.lbEndTime1.Text = range1.EndTime.ToString("HH:mm:ss");

            }

            if (this.comboBox2.DataSource != null && index ==2)
            {
                if (loadPlan)
                {
                    this.plineMDL.OP2_RANGE = this.comboBox2.SelectedIndex + 1;

                    this.plineMDL = PlinePlanMDL.ReLoadPlanMDL(this.plineMDL);
                }

                TimeRange range2 = this.plineMDL.GetTimeRange(2);
                this.dateTimePicker2.Value = range2.StartTime;
                this.LbEndTime2.Text = range2.EndTime.ToString("HH:mm:ss");
            }


        }

        private void DoLoadRangeChange(int index)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new delegateChangeValue(LoadRangeChange), new object[] { index });
            }
            else
            {
                LoadRangeChange(index);
            }
        }

        private void InitalCombox()
        {
      
           
            ArrayList list1 = new ArrayList();
            ArrayList list2 = new ArrayList();

            for (int i = 1; i <= 12; i++)
            {
                list1.Add(i.ToString());
                list2.Add(i.ToString());
            }

    
           
            this.comboBox1.DataSource = list1;
            this.comboBox2.DataSource = list2;


            //if (this.plineMDL != null)
            //{
            this.comboBox1.SelectedIndex = this.plineMDL.OP1_RANGE - 1;
            this.comboBox2.SelectedIndex = this.plineMDL.OP2_RANGE - 1;
            //    return;
            //}



           // this.comboBox1.Enabled = false;
          //  this.comboBox2.Enabled = false;


        }

       
        



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.plineMDL.OP1_RANGE = this.comboBox1.SelectedIndex+1;
            DoLoadRangeChange(1);
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           // this.plineMDL.OP2_RANGE = this.comboBox2.SelectedIndex + 1;
            DoLoadRangeChange(2);

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.plineMDL.OP1_BEGIN = this.dateTimePicker1.Value;

            DateTime time = this.plineMDL.OP1_BEGIN.AddHours(this.plineMDL.OP1_RANGE);
            DoLoadRangeChange(1);
            this.lbEndTime1.Text = time.ToString("HH:mm:ss");
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

            this.plineMDL.OP2_BEGIN = this.dateTimePicker2.Value;

            DateTime time = this.plineMDL.OP2_BEGIN.AddHours(this.plineMDL.OP2_RANGE);
            DoLoadRangeChange(2);
            this.LbEndTime2.Text = time.ToString("HH:mm:ss");
        }

        private void txtOP1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键

            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符
                }
            }

                
        }

        private void txtOP2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键

            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符
                }
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DoLoadRangeChange(1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PLineOPSetting setting = new PLineOPSetting();

            setting.DefualtOP = this.plineMDL.OP1;
            setting.LINEID = this.plineMDL.NAME;

            setting.OPS = this.plineMDL.OP1_ITEMS;

            if (setting.ShowDialog() == DialogResult.Yes)
            {

                this.plineMDL.OP1_ITEMS = setting.OPS;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PLineOPSetting setting = new PLineOPSetting();

            setting.OPS = this.plineMDL.OP2_ITEMS;

            setting.DefualtOP = this.plineMDL.OP2;
            setting.LINEID = this.plineMDL.NAME;


            if (setting.ShowDialog() == DialogResult.Yes)
            {
                this.plineMDL.OP2_ITEMS = setting.OPS;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ModifyOPForm moForm = new ModifyOPForm();
            moForm.Info = this.plineMDL.NAME+"早班默认OP";
            moForm.OP = this.plineMDL.OP1;

            ///修改早班OP
            if (moForm.ShowDialog() == DialogResult.OK)
            {
                this.plineMDL.OP1=moForm.OP;

                for (int i = 0; i < this.plineMDL.OP1_ITEMS.Count; i++)
                {
                    this.plineMDL.OP1_ITEMS[i].OP = this.plineMDL.OP1;
                }
               
                XmlHelper helper = new XmlHelper("App.xml");
           
                helper.UpdateInnerText("/Root/APP/OP",this.plineMDL.GetOPItem());

                LoadPlanInfo();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ModifyOPForm moForm = new ModifyOPForm();

            moForm.Info = this.plineMDL.NAME + "晚班默认OP";
            moForm.OP = this.plineMDL.OP2;

            ///修改早班OP
            if (moForm.ShowDialog() == DialogResult.OK)
            {
                this.plineMDL.OP2 = moForm.OP;

                for (int i = 0; i < this.plineMDL.OP2_ITEMS.Count; i++)
                {
                    this.plineMDL.OP2_ITEMS[i].OP = this.plineMDL.OP2;
                }
               

                XmlHelper helper = new XmlHelper("App.xml");

                helper.UpdateInnerText("/Root/APP/OP", this.plineMDL.GetOPItem());

                LoadPlanInfo();
            }
        }






    }
}
