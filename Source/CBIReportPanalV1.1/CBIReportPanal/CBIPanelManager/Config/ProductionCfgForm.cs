using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MDL;
using DAL;
using COM;

namespace CBIReportPanal
{
    public partial class ProductionCfgForm : Form
    {
    

        private BindingSource bindingSource1 = new BindingSource();

        private DataTable infos = null;
       // \|∕|¦—\﹨eewrew\werwr

        public ProductionCfgForm()
        {
            InitializeComponent();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// 初始化表单
        /// </summary>
        private void InitialDataGridViewHeader()
        {

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns.Clear();


            DataGridViewColumn deviceColumn = new DataGridViewTextBoxColumn();
            deviceColumn.HeaderText = "产线";
            deviceColumn.Name = "lineid";
            deviceColumn.Width = 100;
            dataGridView1.Columns.Add(deviceColumn);

            DataGridViewColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.HeaderText = "产品名称";
            nameColumn.Name = "brakename";
            nameColumn.Width = 100;
            dataGridView1.Columns.Add(nameColumn);

            DataGridViewColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.HeaderText = "产品ID";
            idColumn.Name = "brakeid";
            idColumn.Width = 80;
            dataGridView1.Columns.Add(idColumn);


            DataGridViewColumn codeColumn = new DataGridViewTextBoxColumn();
            codeColumn.HeaderText = "产品编号";
            codeColumn.Name = "brakecode";
            codeColumn.Width = 100;
            dataGridView1.Columns.Add(codeColumn);

            DataGridViewColumn factoryColumn = new DataGridViewTextBoxColumn();
            factoryColumn.HeaderText = "供应厂家";
            factoryColumn.Name = "factory";
            factoryColumn.Width = 100;
            dataGridView1.Columns.Add(factoryColumn);


            DataGridViewColumn mdfColumn = new DataGridViewButtonColumn();
            mdfColumn.HeaderText = "";
            mdfColumn.Name = "modify";
            mdfColumn.Width = 61;
            dataGridView1.Columns.Add(mdfColumn);


            DataGridViewColumn delColumn = new DataGridViewButtonColumn();
            delColumn.HeaderText = "";
            delColumn.Name = "";
            delColumn.Width = 61;
            dataGridView1.Columns.Add(delColumn);

            //dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Rows.Clear();

        }

        private void ProductionCfgForm_Load(object sender, EventArgs e)
        {
            InitialDataGridViewHeader();
            LoadDataGridView();
        }


        private void LoadDataGridView()
        {
            try
            {
                this.dataGridView1.Rows.Clear();

                ProductDal dal = new ProductDal();



                infos= dal.GetProductionInfos();

                //this.dataGridView1.DataSource = bindingSource1;


                // Set the DataGridView control's border.
                dataGridView1.BorderStyle = BorderStyle.Fixed3D;

                if (infos != null && infos.Rows.Count > 0)
                {
                    for (int i = 0; i < infos.Rows.Count; i++)
                    {

                        DataRow row = infos.Rows[i];

                        this.dataGridView1.Rows.Add(Convert.ToString(row["lineid"])+"号线",
                                                    Convert.ToString(row["brakename"]),
                                                    Convert.ToString(row["brakeid"]),
                                                    Convert.ToString(row["brakecode"]),
                                                    //Convert.ToString(row["createtime"]),
                                                    Convert.ToString(row["factory"]),
                                                    "修 改", "删 除");
                    }
                }
        
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                CLog.WriteErrLogInTrace(ex.Message);
            }


            this.Cursor = Cursors.Default;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            this.dataGridView1.CellValueChanged -= new DataGridViewCellEventHandler(dataGridView1_CellContentClick);

            DataRow rd = null;

            switch (e.ColumnIndex)
            {
                case 5:


                    ProductionInfo addInfoForm = new ProductionInfo();
                    addInfoForm.IsUpdate = true;
                    rd = this.infos.Rows[e.RowIndex];

                    ProductionMDL info = new ProductionMDL();
                    info.Load(rd);

                    addInfoForm.Production = info;
                    if (addInfoForm.ShowDialog() == DialogResult.OK)
                    {
                        ProductDal dal = new ProductDal();
                        if (dal.UpdateProduction(info) > 0)
                        {
                            this.LoadDataGridView();
                            MessageBox.Show("修改产品信息成功！");
                        }
                        else
                        MessageBox.Show("修改产品信息失败！");
                    }
                    

                    break;
                case 6:

                 
                    if (MessageBox.Show("确定要删除该产品信息吗？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                    {
                        rd = this.infos.Rows[e.RowIndex];

                        int id = Convert.ToInt32(rd["tid"]);

                        ProductDal dal = new ProductDal();

                        if (dal.DeleteProduction(id) > 0)
                            this.LoadDataGridView();
                        else
                            MessageBox.Show("删除产品信息失败！");
                    }

                  

                    break;
                default:
                    break;
            }


            this.dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
        }

        private void btAddDevice_Click(object sender, EventArgs e)
        {
            ProductionInfo addInfoForm = new ProductionInfo();

            if (addInfoForm.ShowDialog() == DialogResult.OK)
            {
                ProductDal dal = new ProductDal();

                if (dal.InsertProduction(addInfoForm.Production) > 0)
                {
                    this.LoadDataGridView();
                    MessageBox.Show("添加产品信息成功！");
                }
                else
                {
                    MessageBox.Show("添加产品信息失败！");
                }

            }
        }



    }
}
