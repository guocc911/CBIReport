
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceController;

namespace CBIReportPanal
{
    public partial class ReportClientForm
    {
       private WindowsServiceMonitor _windowsServiceMonitor;


       //private void StarttoolStripButton_Click(object sender, EventArgs e)
       //{
       //    ChangeServiceStauts(true);
       //}



       private void StoptoolStripButton_Click(object sender, EventArgs e)
       {
           ChangeServiceStauts(false);
       }



       /// <summary>
       /// 初始化服务监控器
       /// </summary>
       protected bool InitialServiceMonitor()
       {
           try
           {
               _windowsServiceMonitor = new WindowsServiceMonitor("CBIReportPanelService");

               if (_windowsServiceMonitor != null)
                   return true;
               else
                   return false;
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message.ToString());
               return false;
           }
       }

       /// <summary>
       /// 初始化服务状态
       /// </summary>
       private void InitialServiceStatus()
       {
           if (!ServiceRunning())
           {

               this.StarttoolStripButton.Enabled = true;
               this.开启服务ToolStripMenuItem.Enabled = true;
               this.StoptoolStripButton.Enabled = false;
               this.关闭服务ToolStripMenuItem.Enabled = false;
               this.StaustoolStripStatusLabel.Text = "采集服务已关闭！";
               //ChangeServiceStauts(true);
           }
           else
           {
               this.StarttoolStripButton.Enabled = false;
               this.开启服务ToolStripMenuItem.Enabled = false;
               this.StoptoolStripButton.Enabled = true;
               this.关闭服务ToolStripMenuItem.Enabled = true;
               this.StaustoolStripStatusLabel.Text = "采集服务已开启！";
           }
 
       }

       /// <summary>
       /// 改变服务状态
       /// </summary>
       /// <param name="status">true 启动服务 false 关闭服务</param>
       protected void ChangeServiceStauts(bool status)
       {

           if (status)
               StartService();
           else
               StopService();
 
       }


       protected bool ServiceRunning()
       {
           try
           {
             
               if (_windowsServiceMonitor==null)
                   return false;

               return _windowsServiceMonitor.IsRunning;

           }
           catch (Exception ex)
           {
               return false;
           }
       }

        protected bool StartService()
        {
            try
            {
                if (_windowsServiceMonitor == null)
                    return false;

                if (!ServiceRunning())
                {
                    _windowsServiceMonitor.Start();
                    InitialServiceStatus();
                    MessageBox.Show("开启采集服务成功！");
                    return true;
                }
                else
                {
                    InitialServiceStatus();
                    return true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }


        protected bool StopService()
        {
            try
            {
                if (ServiceRunning())
                {
                    _windowsServiceMonitor.Stop();
                    InitialServiceStatus();
                    MessageBox.Show("关闭采集服务成功！");
                    return true;
                }
                else
                {
                    InitialServiceStatus();
                    return true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }

    }
}
