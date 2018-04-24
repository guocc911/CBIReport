using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using COMM;

namespace CBIReportPanal.Config
{
    public partial class ExttTimeConfigForm : Form
    {
        public ExttTimeConfigForm()
        {
            InitializeComponent();
        }

        private void ExttTimeConfigForm_Load(object sender, EventArgs e)
        {

        }

        private void InitialDataGridViewHeader()
        {

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns.Clear();


            DataGridViewColumn plineColumn = new DataGridViewTextBoxColumn();
            plineColumn.HeaderText = "产线编号";
            plineColumn.Name = "lineid";
            plineColumn.Width = 100;
            dataGridView1.Columns.Add(plineColumn);

            DataGridViewColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.HeaderText = "产线名称";
            nameColumn.Name = "name";
            nameColumn.Width = 100;
            dataGridView1.Columns.Add(nameColumn);

            DataGridViewColumn lunchColumn = new DataGridViewTextBoxColumn();
            lunchColumn.HeaderText = "中餐开始时间";
            lunchColumn.Name = "lunch";
            lunchColumn.Width = 120;
            dataGridView1.Columns.Add(lunchColumn);


            DataGridViewColumn lRangeColumn = new DataGridViewTextBoxColumn();
            lRangeColumn.HeaderText = "中餐时长";
            lRangeColumn.Name = "l_range";
            lRangeColumn.Width = 100;
            dataGridView1.Columns.Add(lRangeColumn);

            DataGridViewColumn dinnerColumn = new DataGridViewTextBoxColumn();
            dinnerColumn.HeaderText = "晚餐开始时间";
            dinnerColumn.Name = "dinner";
            dinnerColumn.Width = 120;
            dataGridView1.Columns.Add(dinnerColumn);


            DataGridViewTextBoxColumn d_rangeColumn = new DataGridViewTextBoxColumn();
            d_rangeColumn.HeaderText = "晚餐时长";
            d_rangeColumn.Name = "d_range";
            d_rangeColumn.Width = 100;
            dataGridView1.Columns.Add(d_rangeColumn);


            DataGridViewColumn delColumn = new DataGridViewButtonColumn();
            delColumn.HeaderText = "修 改";
            delColumn.Name = "";
            delColumn.Width = 61;
            dataGridView1.Columns.Add(delColumn);

            this.dataGridView1.Rows.Clear();

        }


        private void LoadDataGridView()
        {
            try
            {
                this.dataGridView1.Rows.Clear();

                ////ProductDal dal = new ProductDal();
                //ProductSQLiteDal dal = new ProductSQLiteDal();


                //infos = dal.GetProductionInfos();

                ////this.dataGridView1.DataSource = bindingSource1;


                //// Set the DataGridView control's border.
                //dataGridView1.BorderStyle = BorderStyle.Fixed3D;

                //if (infos != null && infos.Rows.Count > 0)
                //{
                //    for (int i = 0; i < infos.Rows.Count; i++)
                //    {

                //        DataRow row = infos.Rows[i];

                //        this.dataGridView1.Rows.Add(Convert.ToString(row["lineid"]) + "号线",
                //                                    Convert.ToString(row["brakename"]),
                //                                    Convert.ToString(row["brakeid"]),
                //                                    Convert.ToString(row["brakecode"]),
                //            //Convert.ToString(row["createtime"]),
                //                                    Convert.ToString(row["factory"]),
                //                                    "修 改", "删 除");
                //    }
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                CLog.WriteErrLogInTrace(ex.Message);
            }


            this.Cursor = Cursors.Default;
        }
        
    }
}
