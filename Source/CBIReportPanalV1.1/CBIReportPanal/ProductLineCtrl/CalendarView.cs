using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace ProductLine
{
    public partial class CalendarView : UserControl
    {

        /// <summary>
        /// 更新计时器
        /// </summary>
        private Timer updateTimer;

        private delegate void UpdateInfodDelegate();


        /// <summary>
        /// 构造函数
        /// </summary>
        public CalendarView()
        {
            InitializeComponent();
            InitTimer();
        }

       


        /// <summary>
        /// 初始化计数器
        /// </summary>
        private void InitTimer()
        {

            if (updateTimer != null)
                updateTimer.Enabled = false;

            updateTimer = new Timer();
            updateTimer.Tick+=new EventHandler(updateTimer_Tick);
            updateTimer.Interval = 1000;
            updateTimer.Start();
        }

        /// <summary>
        /// 关闭计数器
        /// </summary>
        private void EndTimer()
        {
            if (updateTimer == null)
                return;
            updateTimer.Stop();
            updateTimer.Enabled = false;
            updateTimer = null;

        }

        /// <summary>
        /// 
        /// </summary>
        private void updateTimer_Tick(object obj,EventArgs args)
        {
            updateTimer.Tick -= new EventHandler(updateTimer_Tick);
            UpdateDisplay();
            updateTimer.Tick += new EventHandler(updateTimer_Tick);
        }


        /// <summary>
        /// 更新显示数据
        /// </summary>
        private void UpdateDisplay()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateInfodDelegate(UpdateDisplay));
            }
            else
            {
                this.Invalidate();
            }
        }



        private void CalendarView_Paint(object sender, PaintEventArgs e)
        {
            drawDatePanel(e.Graphics);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="graph"></param>
        private void drawDatePanel(Graphics graph)
        {

            DateTime curDateTime = DateTime.Now;

            string drawString = "";

            StringFormat stringFormat = new StringFormat();
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;

            string day = curDateTime.ToString("D", DateTimeFormatInfo.InvariantInfo);

            string[] dayDis = day.Split(',');

            //int fontSize = (int)(panel1.Height * 0.06);
            int fontSize = (int)(this.Height * 0.06);
            int oldSize = 0;

            //绘制星期
            // Create font and brush.
            Font drawFont = new Font("Arial", fontSize);
            SolidBrush drawBrush = new SolidBrush(Color.White);


            // Measure string.
            SizeF stringSize = new SizeF();
            stringSize = graph.MeasureString(dayDis[0], drawFont);

            // graph.DrawString(dayDis[0], drawFont, Brushes.White, new PointF(0, 0));

            //绘制月份
            string[] monthDis = dayDis[1].Split(' ');

            fontSize = (int)(this.Height * 0.25);
            drawFont = new Font("Arial", fontSize);

            stringSize = new SizeF();
            stringSize = graph.MeasureString(monthDis[1], drawFont);

            PointF offset = new PointF();
            offset.X = (float)(this.Width - stringSize.Width) / 2;
            offset.Y = (float)(this.Height * 0.10);

            // Draw string to screen.
            graph.DrawString(monthDis[1], drawFont, Brushes.DarkOrange, offset);

            //绘制年份


            fontSize = (int)(this.Height * 0.09);
            drawFont = new Font("Arial", fontSize);

            stringSize = new SizeF();
            drawString = monthDis[2] + "." + monthDis[3];
            if (drawString.Length > 11)
            {
                string[] temp = drawString.Split('.');
                drawString = temp[0] + "\r\n    " + temp[1];

            }
            stringSize = graph.MeasureString(drawString, drawFont);

            offset = new PointF();
            offset.X = (float)(this.Width - stringSize.Width) / 2;
            offset.Y = (float)(this.Height * 0.45);


            // Draw string to screen.
            graph.DrawString(drawString, drawFont, Brushes.White, offset);

            //绘制时间

            fontSize = (int)(this.Height * 0.09);
            drawFont = new Font("Arial", fontSize);

            stringSize = new SizeF();
            drawString = curDateTime.ToLongTimeString().ToString();

            drawString = dayDis[0] + "    " + drawString;

            stringSize = graph.MeasureString(drawString, drawFont);

            offset = new PointF();
            offset.X = (float)(this.Width - stringSize.Width) / 2;
            offset.Y = (float)(this.Height * 0.60);

            // Draw string to screen.
            graph.DrawString(drawString, drawFont, Brushes.White, offset);

        }
    }
}
