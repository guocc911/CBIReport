using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProductLine.Utils;

namespace ProductLine
{
    public partial class PrintConfig : Form
    {

        private DBInfo _info;


        public DBInfo DBinfo
        {
            get { return _info; }
            set { _info = value; }
        }

        public PrintConfig()
        {
            InitializeComponent();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }



        private void DataBaseConfig_Load(object sender, EventArgs e)
        {
            try
            {
                InitalDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        /// <summary>
        /// 初始化界面
        /// </summary>
        private void InitalDialog()
        {
            try
            {
                this.txtHost.Text = _info.Server.Trim();
                this.txtDBName.Text = _info.DBName.Trim();
                this.txtUser.Text = _info.User.Trim();
                this.txtPassword.Text = _info.PWD.Trim();
                
            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// 测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btTesting_Click(object sender, EventArgs e)
        {

            try
            {
                if (this.txtHost.Text.Trim().Length < 1)
                {
                    MessageBox.Show("请填写连接主机地址！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (this.txtDBName.Text.Trim().Length < 1)
                {
                    MessageBox.Show("请填数据库名称！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (this.txtUser.Text.Trim().Length < 1)
                {
                    MessageBox.Show("请填写用户名称！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }


                if (this.txtPassword.Text.Trim().Length < 1)
                {
                    MessageBox.Show("请填密码！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }


                bool ret = COMM.MySqlDBHelper.TestCoonnectin(this.txtHost.Text.Trim(),
                                                             this.txtDBName.Text.Trim(),
                                                             this.txtUser.Text.Trim(),
                                                             this.txtPassword.Text.Trim());
                if (ret)
                {
                    MessageBox.Show("测试连接成功！");
                }
                else
                {
                    MessageBox.Show("测试连接失败！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }



        /// <summary>
        /// 应用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btApply_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.txtHost.Text.Trim().Length < 1)
                {
                    MessageBox.Show("请填写连接主机地址！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (this.txtDBName.Text.Trim().Length < 1)
                {
                    MessageBox.Show("请填数据库名称！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (this.txtUser.Text.Trim().Length < 1)
                {
                    MessageBox.Show("请填写用户名称！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }


                if (this.txtPassword.Text.Trim().Length < 1)
                {
                    MessageBox.Show("请填密码！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }


                bool ret = COMM.MySqlDBHelper.TestCoonnectin(this.txtHost.Text.Trim(),
                                                             this.txtDBName.Text.Trim(),
                                                             this.txtUser.Text.Trim(),
                                                             this.txtPassword.Text.Trim());

                if (!ret)
                {
                    MessageBox.Show("保存连接失败,请重试！");

                    return;
                }

                _info.Server = this.txtHost.Text.Trim();
                _info.DBName = this.txtDBName.Text.Trim();
                _info.User = this.txtUser.Text.Trim();
                _info.PWD = this.txtPassword.Text.Trim();

                this.DialogResult = DialogResult.Yes;

                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
