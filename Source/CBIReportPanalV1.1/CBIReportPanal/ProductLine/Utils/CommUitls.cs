
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductLine.Utils
{
    public static class CommUitls
    {

        public static double GetRandomNumber(double minimum, double maximum, int Len)   //Len小数点保留位数
        {
            Random random = new Random();
            return Math.Round(random.NextDouble() * (maximum - minimum) + minimum, Len);
        }

        //public static int GetRandomNumber(double minimum, double maximum)
        //{
        //    Random random = new Random();
        //    return Math.Round(random.Next() * (maximum - minimum) + minimum);
        //}

    }

    public static class SystemUtils
    {
        public static string ApplicationPath = Path.GetDirectoryName(Application.ExecutablePath);
    }
}
