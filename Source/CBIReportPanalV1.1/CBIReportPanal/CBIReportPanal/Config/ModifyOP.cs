using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Threading;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace CBIReportPanal
{
    public partial class ModifyOPForm : Form
    {

        private string info = string.Empty;

        private int op = 0;



        public string Info
        {
            get { return info; }
            set { info = value; }
        }

        public int OP
        {
            get { return op; }
            set { op = value; }
        }


        public ModifyOPForm()
        {
            InitializeComponent();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }




        private void btOK_Click(object sender, EventArgs e)
        {
            if (this.txtOP.Text.Length <= 0)
            {
                MessageBox.Show("请填写OP数量！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }


            this.OP = Convert.ToInt32(txtOP.Text);
            this.DialogResult = DialogResult.OK;

        }

   

        private void UserInfo_Load(object sender, EventArgs e)
        {
            this.txtOP.Text=this.op.ToString();
            this.lbPlineInfo.Text = this.info;
        }

        private void txtOP_TextChanged(object sender, EventArgs e)
        {
            Match m = Regex.Match(this.txtOP.Text.Trim(), @"^[0-9]\d*\.\d{0,2}$|^\d*$");
            if (!m.Success)
            {
                MessageBox.Show("请填写正确的数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
