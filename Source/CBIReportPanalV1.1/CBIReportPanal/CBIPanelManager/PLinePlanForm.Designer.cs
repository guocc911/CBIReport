namespace CBIReportPanal
{
    partial class PLinePlanForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PLinePlanForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cbPLine = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btNew = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dayView1 = new Syd.ScheduleControls.DayScheduleControl();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.计划PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.产品设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.公告消息设置NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dayView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.cbPLine);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(21, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "计划查看选项：";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(299, 32);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(124, 21);
            this.dateTimePicker1.TabIndex = 5;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // cbPLine
            // 
            this.cbPLine.FormattingEnabled = true;
            this.cbPLine.Location = new System.Drawing.Point(77, 35);
            this.cbPLine.Name = "cbPLine";
            this.cbPLine.Size = new System.Drawing.Size(121, 20);
            this.cbPLine.TabIndex = 4;
            this.cbPLine.SelectedIndexChanged += new System.EventHandler(this.cbPLine_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "日期：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "产线：";
            // 
            // btNew
            // 
            this.btNew.Location = new System.Drawing.Point(535, 59);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(86, 25);
            this.btNew.TabIndex = 1;
            this.btNew.Text = "添加生产计划";
            this.btNew.UseVisualStyleBackColor = true;
            this.btNew.Click += new System.EventHandler(this.btNew_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dayView1);
            this.groupBox2.Location = new System.Drawing.Point(21, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(654, 360);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "生产计划：";
            // 
            // dayView1
            // 
            this.dayView1.Date = new System.DateTime(((long)(0)));
            this.dayView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dayView1.Location = new System.Drawing.Point(3, 17);
            this.dayView1.Name = "dayView1";
            this.dayView1.RenderWorkingHoursOnly = true;
            this.dayView1.SingleDay = true;
            this.dayView1.Size = new System.Drawing.Size(648, 340);
            this.dayView1.TabIndex = 0;
            this.dayView1.Text = "日产品计划";
            this.dayView1.WorkEndHour = 21;
            this.dayView1.WorkStartHour = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 506);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "注：双击计划表进行编辑的删除";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.计划PToolStripMenuItem,
            this.设置SToolStripMenuItem,
            this.关于AToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(686, 25);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 计划PToolStripMenuItem
            // 
            this.计划PToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.更行ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.计划PToolStripMenuItem.Name = "计划PToolStripMenuItem";
            this.计划PToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.计划PToolStripMenuItem.Text = "计划(&P)";
            // 
            // 更行ToolStripMenuItem
            // 
            this.更行ToolStripMenuItem.Name = "更行ToolStripMenuItem";
            this.更行ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.更行ToolStripMenuItem.Text = "更新&R";
            this.更行ToolStripMenuItem.Click += new System.EventHandler(this.更行ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.退出ToolStripMenuItem.Text = "退出&E";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 设置SToolStripMenuItem
            // 
            this.设置SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.产品设置ToolStripMenuItem,
            this.公告消息设置NToolStripMenuItem});
            this.设置SToolStripMenuItem.Name = "设置SToolStripMenuItem";
            this.设置SToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.设置SToolStripMenuItem.Text = "设置(&S)";
            // 
            // 产品设置ToolStripMenuItem
            // 
            this.产品设置ToolStripMenuItem.Name = "产品设置ToolStripMenuItem";
            this.产品设置ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.产品设置ToolStripMenuItem.Text = "产品设置&P";
            this.产品设置ToolStripMenuItem.Click += new System.EventHandler(this.产品设置ToolStripMenuItem_Click);
            // 
            // 公告消息设置NToolStripMenuItem
            // 
            this.公告消息设置NToolStripMenuItem.Name = "公告消息设置NToolStripMenuItem";
            this.公告消息设置NToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.公告消息设置NToolStripMenuItem.Text = "公告消息设置&N";
            this.公告消息设置NToolStripMenuItem.Click += new System.EventHandler(this.公告消息设置NToolStripMenuItem_Click);
            // 
            // 关于AToolStripMenuItem
            // 
            this.关于AToolStripMenuItem.Name = "关于AToolStripMenuItem";
            this.关于AToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.关于AToolStripMenuItem.Text = "关于(&A)";
            this.关于AToolStripMenuItem.Click += new System.EventHandler(this.关于AToolStripMenuItem_Click);
            // 
            // PLinePlanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 576);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btNew);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PLinePlanForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "产线计划管理软件";
            this.Load += new System.EventHandler(this.PLinePlanForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dayView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btNew;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbPLine;
        private Syd.ScheduleControls.DayScheduleControl dayView1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 计划PToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 产品设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 公告消息设置NToolStripMenuItem;
    }
}