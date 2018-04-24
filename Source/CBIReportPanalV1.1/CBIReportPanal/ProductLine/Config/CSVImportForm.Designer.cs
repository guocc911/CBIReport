namespace ProductLine.Config
{
    partial class CSVImportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CSVImportForm));
            this.v = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtOutPut = new System.Windows.Forms.TextBox();
            this.btConvert = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // v
            // 
            this.v.Location = new System.Drawing.Point(375, 30);
            this.v.Name = "v";
            this.v.Size = new System.Drawing.Size(62, 23);
            this.v.TabIndex = 0;
            this.v.Text = "导入文件";
            this.v.UseVisualStyleBackColor = true;
            this.v.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "文件路径：";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(94, 31);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(255, 21);
            this.txtPath.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "状态：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.v);
            this.groupBox1.Controls.Add(this.txtPath);
            this.groupBox1.Location = new System.Drawing.Point(26, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(456, 75);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "导入配置文件：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Controls.Add(this.txtOutPut);
            this.groupBox2.Controls.Add(this.btConvert);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(26, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(456, 116);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "转换数据入库：";
            // 
            // txtOutPut
            // 
            this.txtOutPut.BackColor = System.Drawing.SystemColors.Control;
            this.txtOutPut.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOutPut.Location = new System.Drawing.Point(94, 41);
            this.txtOutPut.Name = "txtOutPut";
            this.txtOutPut.ReadOnly = true;
            this.txtOutPut.Size = new System.Drawing.Size(255, 14);
            this.txtOutPut.TabIndex = 3;
            // 
            // btConvert
            // 
            this.btConvert.Location = new System.Drawing.Point(375, 39);
            this.btConvert.Name = "btConvert";
            this.btConvert.Size = new System.Drawing.Size(62, 23);
            this.btConvert.TabIndex = 3;
            this.btConvert.Text = "数据入库";
            this.btConvert.UseVisualStyleBackColor = true;
            this.btConvert.Click += new System.EventHandler(this.btConvert_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(84, 81);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(281, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // CSVImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 235);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CSVImportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "产线配置导入";
            this.Load += new System.EventHandler(this.CSVImportForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button v;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btConvert;
        private System.Windows.Forms.TextBox txtOutPut;
        private System.Windows.Forms.ProgressBar progressBar1;

    }
}