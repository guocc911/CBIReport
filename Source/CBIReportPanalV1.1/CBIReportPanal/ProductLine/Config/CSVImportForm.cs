using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProductLine.Utils;
using DAL;
using MDL;

namespace ProductLine.Config
{
    public partial class CSVImportForm : Form
    {




        private delegate void DelegateUpdateImportInfo(string info,int nVlaue);


        public CSVImportForm()
        {
            InitializeComponent();
        }

        private void CSVImportForm_Load(object sender, EventArgs e)
        {
            this.txtOutPut.Text = String.Empty;
           

        }



        private void ImportButton_Click(object sender, EventArgs e)
        {

            /// 选取本地文件夹
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = SystemUtils.ApplicationPath;
            openFileDialog.Filter = "All files (*.*)|*.*|csv files (*.csv)|*.csv";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            try
            {


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.txtPath.Text = openFileDialog.FileName;

                }
                else
                {
                    this.txtPath.Text = String.Empty;
                    this.txtOutPut.Text = String.Empty;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
          
            



 
        }


        private void UpdateContentInfo(string info,int nValue)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new DelegateUpdateImportInfo(UpdateContentInfo), new object[] { info, nValue });
            }
            else 
            {
                this.txtOutPut.Text=info;
                if (nValue > 100)
                    nValue = 100;

                this.progressBar1.Value = nValue;
             
            }
        }


        private void btConvert_Click(object sender, EventArgs e)
        {


            if (this.txtPath.Text == null || this.txtPath.Text == String.Empty)
            {
                MessageBox.Show("请填选择导入文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            try
            {


                string selectFile = this.txtPath.Text.Trim();


                if(selectFile==null||selectFile==string.Empty)
                {
                    MessageBox.Show("未获导入数据信息!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



              

                //if (openFileDialog.ShowDialog() == DialogResult.Yes)
                //{
                //    csvTable = CSVFileHelper.OpenCSV(selectFile);
                //}
                //else
                //{
                //    this.txtPath.Text = String.Empty;
                //    this.lbContent.Text = String.Empty;
                //}

                DataTable csvTable = null;


                csvTable = CSVFileHelper.OpenCSV(selectFile);


                if (csvTable == null || csvTable.Rows.Count <= 1)
                {
                    MessageBox.Show("未获导入数据信息!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (csvTable.Columns == null)
                {
                    MessageBox.Show("未获导入正确数据信息!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (csvTable.Columns.Count != 5)
                {
                    MessageBox.Show("未获导入正确数据信息!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (csvTable.Columns[0].ColumnName != "PN")
                {
                    MessageBox.Show("未获导入正确数据信息!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                if (MessageBox.Show("请确保产线为非生产状态，确定更新请选择‘是’", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    return;
                }

                ProductDal dal = new ProductDal();

                int countAdd = 0;
                int countRef = 0;


                int count = csvTable.Rows.Count;

                double div = (double)count / 100;

                double pogressValue = 0;
                
                foreach (DataRow row in csvTable.Rows)
                {
                    ProductionMDL mdl = new ProductionMDL();

                    mdl = ProductionMDL.ParseDataRow(row);

                    int ret = -1;

                    pogressValue += div;

                    if (dal.IsExist(mdl.PN) > 0)
                    {
                        ret=dal.UpdateProduction(mdl);

                        if (ret > 0)
                        {
                             countRef++;
                             UpdateContentInfo(mdl.PN + "更新成功", (int)div);
                        }
                        else
                        {
                            UpdateContentInfo(mdl.PN + "更新失败", (int)div);
                        }
                    }
                    else
                    {
                        ret=dal.InsertProduction(mdl);

                        if (ret > 0)
                        {  
                            countAdd++;
                            UpdateContentInfo(mdl.PN + "入库成功", (int)div);
                        }
                        else
                        {
                            UpdateContentInfo(mdl.PN + "入库失败", (int)div);
                        }
                    }
                
                }

            //    UpdateContentInfo((countAdd+countRef).ToString() + "记录入库成功！");

                MessageBox.Show((countAdd + countRef).ToString() + "记录入库成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
    }
}
