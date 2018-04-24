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
            this.lbPLineID = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dayView1 = new Syd.ScheduleControls.DayScheduleControl();
            this.label2 = new System.Windows.Forms.Label();
            this.btAddPlan = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dayView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbPLineID);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(21, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(484, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "计划查看选项：";
            // 
            // lbPLineID
            // 
            this.lbPLineID.AutoSize = true;
            this.lbPLineID.Location = new System.Drawing.Point(69, 36);
            this.lbPLineID.Name = "lbPLineID";
            this.lbPLineID.Size = new System.Drawing.Size(53, 12);
            this.lbPLineID.TabIndex = 6;
            this.lbPLineID.Text = "产线名称";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(331, 33);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(124, 21);
            this.dateTimePicker1.TabIndex = 5;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(260, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "计划日期：";
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dayView1);
            this.groupBox2.Location = new System.Drawing.Point(21, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(484, 430);
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
            this.dayView1.Size = new System.Drawing.Size(478, 410);
            this.dayView1.TabIndex = 0;
            this.dayView1.Text = "日产品计划";
            this.dayView1.WorkEndHour = 24;
            this.dayView1.WorkStartHour = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 576);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "注：双击计划表进行编辑的删除";
            // 
            // btAddPlan
            // 
            this.btAddPlan.Location = new System.Drawing.Point(546, 47);
            this.btAddPlan.Name = "btAddPlan";
            this.btAddPlan.Size = new System.Drawing.Size(87, 51);
            this.btAddPlan.TabIndex = 7;
            this.btAddPlan.Text = "添加产线计划";
            this.btAddPlan.UseVisualStyleBackColor = true;
            this.btAddPlan.Click += new System.EventHandler(this.btNew_Click);
            // 
            // PLinePlanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 607);
            this.Controls.Add(this.btAddPlan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PLinePlanForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "产线计划管理";
            this.Load += new System.EventHandler(this.PLinePlanForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dayView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Syd.ScheduleControls.DayScheduleControl dayView1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbPLineID;
        private System.Windows.Forms.Button btAddPlan;
    }
}