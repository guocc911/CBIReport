using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ProductLine.Utils
{
    public static class ApplicationInfo
    {
        public static string ApplicationPath = Path.GetFullPath(Application.ExecutablePath);
    }
}
