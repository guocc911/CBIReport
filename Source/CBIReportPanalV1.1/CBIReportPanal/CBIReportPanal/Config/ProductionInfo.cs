using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MDL;

namespace CBIReportPanal
{
    public partial class ProductionInfo : Form
    {

        private bool isUpdate=false;

        private ProductionMDL production = null;


        #region properties

        public bool IsUpdate
        {
            get { return isUpdate; }

            set { isUpdate = value; }
        }



        public ProductionMDL Production
        {
            get { return production; }

            set { production = value; }
        }

        #endregion



        public ProductionInfo()
        {
            InitializeComponent();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {

            try
            {

                if (this.txtName.Text.Trim().Length < 1)
                {
                    MessageBox.Show("请填写产品名称！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

                if (this.txtID.Text.Trim().Length < 1)
                {
                    MessageBox.Show("请填填写产品ID！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }

                if (this.txtCode.Text.Trim().Length < 1)
                {
                    MessageBox.Show("请填填写产品编码！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

                if (isUpdate)
                {
                    //Modidfy by guozq 2016-9-6
                    //production.LineNum = this.cbLineNum.SelectedIndex+1;
                    //production.ProductName = this.txtName.Text.Trim();
                    //production.ProductID = this.txtID.Text.Trim();
                    //production.ProductCode = this.txtCode.Text.Trim();
                    production.Factory = this.txtFactory.Text.Trim();
                    production.Remark = this.txtRemark.Text.Trim();
                }
                else
                {
                    production = new ProductionMDL();
                    //production.LineNum = this.cbLineNum.SelectedIndex + 1;
                    //production.ProductName = this.txtName.Text.Trim();
                    //production.ProductID = this.txtID.Text.Trim();
                    //production.ProductCode = this.txtCode.Text.Trim();
                    production.Factory = this.txtFactory.Text.Trim();
                    production.Remark = this.txtRemark.Text.Trim();
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


        private void ProuctionInfo_Load(object sender, EventArgs e)
        {

            LoadProductionInfo();
        }


        /// <summary>
        /// 加载窗口
        /// </summary>
        private void LoadProductionInfo()
        {
            if (isUpdate)
            {
                Text = "CBI产品信息修改";

                //this.txtName.Text = production.ProductName;
                //this.txtID.Text = production.ProductID;
                //this.txtCode.Text = production.ProductCode;
                this.txtFactory.Text = production.Factory;
                this.txtRemark.Text = production.Remark;
                this.btAdd.Text = "修 改";
            }

            InitalCombox();
        }


        /// <summary>
        /// 
        /// </summary>
        private void InitalCombox()
        {
            this.cbLineNum.DataSource = Enum.GetValues(typeof(COMM.LineType));
            this.cbLineNum.SelectedIndex = 0;

            //if (isUpdate)
            //{
            //    this.cbLineNum.SelectedIndex = (int)production.LineNum-1;
            //}
        }
    }
}
