namespace CBIReportPanal
{
    partial class PLineReportPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PLineReportPanel));
           // this.pLineinfoCtrl1 = new CBIReportPanal.PLineinfoCtrl();

            this.pLineinfoCtrl1 = new ZYReportControl.PLineinfoCtrlAddCurve();
            this.SuspendLayout();
            // 
            // pLineinfoCtrl1
            // 
            this.pLineinfoCtrl1.ColumnFist = ((System.Collections.Generic.List<string>)(resources.GetObject("pLineinfoCtrl1.ColumnFist")));
            this.pLineinfoCtrl1.ColumnSecond = ((System.Collections.Generic.List<string>)(resources.GetObject("pLineinfoCtrl1.ColumnSecond")));
            this.pLineinfoCtrl1.DisplayDate = new System.DateTime(2015, 4, 8, 17, 29, 12, 165);
            this.pLineinfoCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pLineinfoCtrl1.Location = new System.Drawing.Point(0, 0);
            this.pLineinfoCtrl1.Name = "pLineinfoCtrl1";
            this.pLineinfoCtrl1.Size = new System.Drawing.Size(634, 388);
            this.pLineinfoCtrl1.TabIndex = 0;
            this.pLineinfoCtrl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pLineinfoCtrl1_KeyDown);
            // 
            // PLineReportPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(634, 388);
            this.Controls.Add(this.pLineinfoCtrl1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PLineReportPanel";
            this.Text = "产线看板";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReportPanel_FormClosing);
            this.Load += new System.EventHandler(this.ReportPanel_Load);
            this.DoubleClick += new System.EventHandler(this.ReportPanel_DoubleClick);
            this.ResumeLayout(false);

        }

        #endregion

        //private PLineinfoCtrl pLineinfoCtrl1;

        private ZYReportControl.PLineinfoCtrlAddCurve pLineinfoCtrl1;

    }
}