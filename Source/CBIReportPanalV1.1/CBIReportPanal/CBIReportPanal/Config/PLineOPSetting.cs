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


namespace CBIReportPanal.Config
{
    public partial class PLineOPSetting : Form
    {


        private List<OPMDL> ops = null;


        private int defualtOP = 0;

        private string lineid = string.Empty;



        public int DefualtOP
        {
            get { return defualtOP; }

            set { defualtOP = value; }
        }

        public string LINEID
        {
            get { return lineid; }

            set { lineid = value; }
        }



        public List<OPMDL> OPS
        {
            get { return ops; }

            set { ops = value; }
        }


        public PLineOPSetting()
        {
            InitializeComponent();
        }



        private void InitialDataGridViewHeader()
        {

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns.Clear();


            //DataGridViewColumn plineColumn = new DataGridViewTextBoxColumn();
            //plineColumn.HeaderText = "产线编号";
            //plineColumn.Name = "lineid";
            //plineColumn.Width = 80;
            //dataGridView1.Columns.Add(plineColumn);

            DataGridViewColumn seqColumn = new DataGridViewTextBoxColumn();
            seqColumn.HeaderText = "序号";
            seqColumn.Name = "seq";
            seqColumn.Width = 80;
            seqColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(seqColumn);


            DataGridViewColumn beginColumn = new DataGridViewTextBoxColumn();
            beginColumn.HeaderText = "开始时间";
            beginColumn.Name = "";
            beginColumn.Width = 100;
            beginColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(beginColumn);

            DataGridViewColumn endColumn = new DataGridViewTextBoxColumn();
            endColumn.HeaderText = "结束时间";
            endColumn.Name = "";
            endColumn.Width = 100;
            endColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(endColumn);


            DataGridViewColumn opColumn = new DataGridViewTextBoxColumn();
            opColumn.HeaderText = "OP";
            opColumn.Name = "";
            opColumn.Width = 60;
            opColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(opColumn);


            DataGridViewColumn modifyColumn = new DataGridViewButtonColumn();
            modifyColumn.HeaderText = "修改";
            modifyColumn.Name = "";
            modifyColumn.Width = 80;
            modifyColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(modifyColumn);

            this.dataGridView1.Rows.Clear();

        }

        private void LoadDataGridView()
        {
            try
            {
                this.dataGridView1.Rows.Clear();

                //// Set the DataGridView control's border.
                dataGridView1.BorderStyle = BorderStyle.Fixed3D;


                if (OPS != null && ops.Count > 0)
                {
                    for (int i = 0; i < ops.Count; i++)
                    {

                        DataGridViewRow row = new DataGridViewRow();

                        ////产线编号
                        //DataGridViewTextBoxCell seqCell = new DataGridViewTextBoxCell();
                        //seqCell.Value = ops[i].LINEID;
                        //row.Cells.Add(seqCell);

                        //序列号
                        DataGridViewTextBoxCell snCell = new DataGridViewTextBoxCell();
                        snCell.Value = ops[i].SEQ.ToString();
                        row.Cells.Add(snCell);

                        //
                        DataGridViewTextBoxCell beginCell = new DataGridViewTextBoxCell();
                        beginCell.Value = ops[i].IIME_RANGE.StartTime.ToString("HH:mm:ss");
                        row.Cells.Add(beginCell);


                        DataGridViewTextBoxCell endCell = new DataGridViewTextBoxCell();
                        endCell.Value = ops[i].IIME_RANGE.EndTime.ToString("HH:mm:ss");
                        row.Cells.Add(endCell);


                        DataGridViewTextBoxCell opCell = new DataGridViewTextBoxCell();
                        opCell.Value = ops[i].OP.ToString();
                        row.Cells.Add(opCell);
                

                        DataGridViewButtonCell modifyCell = new DataGridViewButtonCell();
                        modifyCell.Value = "修 改";
                        row.Cells.Add(modifyCell);

                       // row.Height = defualtRowSize;
                        row.DefaultCellStyle.Font = new Font("黑体", 10, FontStyle.Regular);

                        row.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        this.dataGridView1.Rows.Add(row);

                        this.dataGridView1.ClearSelection();

                       // this.dataGridView1.Enabled = false;
                        this.dataGridView1.ReadOnly = true;
                        this.dataGridView1.ScrollBars = ScrollBars.None;

                    }

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                //CLog.WriteErrLogInTrace(ex.Message);
            }


            this.Cursor = Cursors.Default;
        }



        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void PLineOPSetting_Load(object sender, EventArgs e)
        {
            try
            {
                this.lbDefaultOP.Text= this.defualtOP.ToString();
                this.lbPline.Text = this.lineid;


                ReloadDateGrid();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        private void ReloadDateGrid()
        {
            try
            {
                InitialDataGridViewHeader();
                LoadDataGridView();

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.CellValueChanged -= new DataGridViewCellEventHandler(dataGridView1_CellContentClick);

          
            switch (e.ColumnIndex)
            {
                case 4:


                    ModifyOPForm dlg = new ModifyOPForm();

                    OPMDL mdl=ops[e.RowIndex];

                    dlg.Info = " 工作时间范围 :" + mdl.IIME_RANGE.StartTime.ToShortTimeString() + "---" +
                               mdl.IIME_RANGE.EndTime.ToShortTimeString();

                    dlg.OP = mdl.OP;

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        ops[e.RowIndex].OP = dlg.OP;
                        ReloadDateGrid();
                    }


                    break;

                default:
                    break;
            }


            this.dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);

        }

        private void btApply_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
