namespace CBIReportPanal
{
    partial class ModifyOPForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.lbPlineInfo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOP = new System.Windows.Forms.TextBox();
            this.btOK = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 45;
            this.label1.Text = "产线信息：";
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(223, 307);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 53;
            this.btCancel.Text = "退 出";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // lbPlineInfo
            // 
            this.lbPlineInfo.AutoSize = true;
            this.lbPlineInfo.Location = new System.Drawing.Point(125, 32);
            this.lbPlineInfo.Name = "lbPlineInfo";
            this.lbPlineInfo.Size = new System.Drawing.Size(29, 12);
            this.lbPlineInfo.TabIndex = 46;
            this.lbPlineInfo.Text = "null";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 47;
            this.label2.Text = "产线OP：";
            // 
            // txtOP
            // 
            this.txtOP.Location = new System.Drawing.Point(127, 75);
            this.txtOP.MaxLength = 2;
            this.txtOP.Name = "txtOP";
            this.txtOP.Size = new System.Drawing.Size(61, 21);
            this.txtOP.TabIndex = 48;
            this.txtOP.TextChanged += new System.EventHandler(this.txtOP_TextChanged);
           
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(72, 131);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 49;
            this.btOK.Text = "确 定";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(212, 131);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 50;
            this.button2.Text = "取 消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // ModifyOPForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 177);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.txtOP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbPlineInfo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModifyOPForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OP信息修改";
            this.Load += new System.EventHandler(this.UserInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Label lbPlineInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOP;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button button2;
    }
}