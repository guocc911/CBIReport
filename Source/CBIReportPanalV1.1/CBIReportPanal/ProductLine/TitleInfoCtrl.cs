using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProductLine.Utils;

namespace ProductLine
{
    public partial class TitleInfoCtrl : UserControl
    {


        private string titleImg;

        private string titleInfo;

        private string engtileInfo;

        private float fontSize;


        private PointF location;


        public PointF Location
        {
            set { location = value; }
        }

        public float FontSize
        {
            set { fontSize = value; }
        }




        public string TitleImg
        {
            get { return titleImg; }
            set { titleImg = value; }
 
        }


        public string TitleInfo
        {
            get { return titleInfo; }
            set { titleInfo = value; }

        }


        public string EngtileInfo
        {
            get { return engtileInfo; }
            set { engtileInfo = value; }

        }



        public TitleInfoCtrl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 绘制配置文件信息
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="fontSize"></param>
        /// <param name="location"></param>
        private void drawTileInfo(Graphics graph, float fontSize, PointF location)
        {
            FileInfo info = new FileInfo(SystemUtils.ApplicationPath);
            string imgFile = info.Directory.FullName + "\\img\\" + titleImg;

            if (!File.Exists(imgFile))
                return;

            Image img = Image.FromFile(imgFile, true);
            graph.DrawImage(img, new Point(30, 15));


            //绘制星期
            // Create font and brush.
            Font drawFont = new Font("黑体", fontSize);
            SolidBrush drawBrush = new SolidBrush(Color.DarkRed);

            Font drawFont1 = new Font("黑体", (float)(fontSize * 0.5));


            // Measure string.
            SizeF stringSize = new SizeF();
            stringSize = graph.MeasureString(this.titleInfo, drawFont);

            SizeF stringSize1 = new SizeF();
            stringSize1 = graph.MeasureString(this.engtileInfo, drawFont1);

            int height = (int)location.Y;

            location.Y = (location.Y - stringSize.Height - stringSize1.Height) - ((location.Y - stringSize.Height) / 2);
            // Draw string to screen.
            graph.DrawString(this.titleInfo, drawFont, Brushes.DarkRed, location);



            drawFont1 = new Font("Arail", (float)(fontSize * 0.5));
            stringSize1 = graph.MeasureString(this.engtileInfo, drawFont1);

            location.Y = (height - stringSize1.Height) - (stringSize1.Height / 2) * 3;//(stringSize1.Height) / 2;
            location.X = location.X + (stringSize.Width - stringSize1.Width) / 2 + 10;

            graph.DrawString(this.engtileInfo, drawFont1, Brushes.Black, location);

        }

        private void TitleInfoCtrl_Paint(object sender, PaintEventArgs e)
        {
            //ReloadSize();

            drawTileInfo(e.Graphics, fontSize, location);
        }


        //private void ReloadSize()
        //{
        //    fontSize = (float)(this.Height * 0.20);

        //    PointF location = new PointF();

        //    location.X = (float)(this.Width - (this.Width - (this.Width * 0.35)));
        //    location.Y = (float)(this.Height*0.1);
        //}


        private void TitleInfoCtrl_Load(object sender, EventArgs e)
        {
  
        }

    }
}
