namespace ProductLine
{
    partial class AssemblyCtrlForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssemblyCtrlForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.PlanShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开启看板ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据库配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.产线型号配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLogInfo = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StaustoolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PlanShowToolStripMenuItem,
            this.配置ToolStripMenuItem,
            this.关于ToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(451, 25);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // PlanShowToolStripMenuItem
            // 
            this.PlanShowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开启看板ToolStripMenuItem1,
            this.退出ToolStripMenuItem2});
            this.PlanShowToolStripMenuItem.Name = "PlanShowToolStripMenuItem";
            this.PlanShowToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.PlanShowToolStripMenuItem.Text = "看板";
            // 
            // 开启看板ToolStripMenuItem1
            // 
            this.开启看板ToolStripMenuItem1.Name = "开启看板ToolStripMenuItem1";
            this.开启看板ToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.开启看板ToolStripMenuItem1.Tag = "产线看板操作";
            this.开启看板ToolStripMenuItem1.Text = "开启产线看板";
            this.开启看板ToolStripMenuItem1.Click += new System.EventHandler(this.开启看板ToolStripMenuItem1_Click);
            // 
            // 退出ToolStripMenuItem2
            // 
            this.退出ToolStripMenuItem2.Name = "退出ToolStripMenuItem2";
            this.退出ToolStripMenuItem2.Size = new System.Drawing.Size(148, 22);
            this.退出ToolStripMenuItem2.Text = "退出";
            this.退出ToolStripMenuItem2.Click += new System.EventHandler(this.退出ToolStripMenuItem2_Click);
            // 
            // 配置ToolStripMenuItem
            // 
            this.配置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据库配置ToolStripMenuItem,
            this.产线型号配置ToolStripMenuItem});
            this.配置ToolStripMenuItem.Name = "配置ToolStripMenuItem";
            this.配置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.配置ToolStripMenuItem.Text = "配置";
            // 
            // 数据库配置ToolStripMenuItem
            // 
            this.数据库配置ToolStripMenuItem.Name = "数据库配置ToolStripMenuItem";
            this.数据库配置ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.数据库配置ToolStripMenuItem.Text = "数据库配置";
            this.数据库配置ToolStripMenuItem.Click += new System.EventHandler(this.数据库配置ToolStripMenuItem_Click);
            // 
            // 产线型号配置ToolStripMenuItem
            // 
            this.产线型号配置ToolStripMenuItem.Name = "产线型号配置ToolStripMenuItem";
            this.产线型号配置ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.产线型号配置ToolStripMenuItem.Text = "产线型号配置";
            this.产线型号配置ToolStripMenuItem.Click += new System.EventHandler(this.产线型号配置ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem1
            // 
            this.关于ToolStripMenuItem1.Name = "关于ToolStripMenuItem1";
            this.关于ToolStripMenuItem1.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem1.Text = "关于";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLogInfo);
            this.groupBox1.Location = new System.Drawing.Point(21, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 189);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "看板运行日志：";
            // 
            // txtLogInfo
            // 
            this.txtLogInfo.Location = new System.Drawing.Point(20, 20);
            this.txtLogInfo.Multiline = true;
            this.txtLogInfo.Name = "txtLogInfo";
            this.txtLogInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogInfo.Size = new System.Drawing.Size(372, 147);
            this.txtLogInfo.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StaustoolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 236);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(451, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StaustoolStripStatusLabel
            // 
            this.StaustoolStripStatusLabel.Name = "StaustoolStripStatusLabel";
            this.StaustoolStripStatusLabel.Size = new System.Drawing.Size(92, 17);
            this.StaustoolStripStatusLabel.Text = "数据库连接状态";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Tag = "CBI精益管理看板系统";
            this.notifyIcon1.Text = "CBI精益管理看板系统";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // AssemblyCtrlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(451, 258);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AssemblyCtrlForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "产线监控看板（大屏显示）";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AssemblyCtrlForm_FormClosing);
            this.Load += new System.EventHandler(this.AssemblyCtrlForm_Load);
            this.SizeChanged += new System.EventHandler(this.AssemblyCtrlForm_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AssemblyCtrlForm_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem PlanShowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开启看板ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtLogInfo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StaustoolStripStatusLabel;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem 配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据库配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 产线型号配置ToolStripMenuItem;
    }
}