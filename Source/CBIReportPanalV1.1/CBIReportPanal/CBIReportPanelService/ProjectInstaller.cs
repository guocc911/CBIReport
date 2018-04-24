using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Runtime;
using System.ServiceProcess;
using System.Threading;
using System.Diagnostics;


namespace CBIReportPanelService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        //private void serviceProcessInstaller1_AfterInstall(object sender, InstallEventArgs e)
        //{
        //    Process p = new Process();
        //    p.StartInfo.FileName = "cmd.exe";
        //    p.StartInfo.UseShellExecute = false;
        //    p.StartInfo.RedirectStandardInput = true;
        //    p.StartInfo.RedirectStandardOutput = true;
        //    p.StartInfo.RedirectStandardError = true;
        //    p.StartInfo.CreateNoWindow = true;
        //    p.Start();
        //    string Cmdstring = "sc start CBIReportPanelService"; //CMD命令    myservice服务名称
        //    p.StandardInput.WriteLine(Cmdstring);
        //    p.StandardInput.WriteLine("exit");

        //}

        private void serviceInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            string Cmdstring = "sc start CBIReportPanelService"; //CMD命令    myservice服务名称
            p.StandardInput.WriteLine(Cmdstring);
            p.StandardInput.WriteLine("exit");
        }
    }
}
