using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using COM;
using DAL;

namespace CBIReportPanal
{
    public partial class NoticeConfigForm : Form
    {




        private NoticeDal noticeDal = null;

        public NoticeConfigForm()
        {
            InitializeComponent();
        }

        private void NoticeConfigForm_Load(object sender, EventArgs e)
        {
            LoadNotice();
        }


        private void LoadNotice()
        {
            try
            {
                noticeDal=new NoticeDal();
                this.txtNotice.Text = noticeDal.GetNoticeInfo();
            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.noticeDal.UpdateNotice(this.txtNotice.Text.Trim()) > 0)
                {
                    LoadNotice();
                    MessageBox.Show("保存公告信息成功！");
                }
                else
                {
                    LoadNotice();
                    MessageBox.Show("保存公告信息失败！");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                CLog.WriteErrLogInTrace(ex.Message);
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }
    }
}
