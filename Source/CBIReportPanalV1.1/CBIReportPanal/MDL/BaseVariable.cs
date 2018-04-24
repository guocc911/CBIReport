namespace MDL
{
    //using MDL;
   // using System;
    using System.Collections.Generic;
    using System.Collections;

    public static class BaseVariable
    {
        public static string DataCheckOut = "1";
        public static Hashtable COHash = null;
        public static string[] LineNames = null;
        public static string DBConnStr = string.Empty;
        public static IOLogikMDL IOLogik = null;
        public static string LineID = string.Empty;
        public static OPCServerMDL MxOPCServer = null;
        public static List<PLCDataMDL> PLCDataListL1 = new List<PLCDataMDL>();
        public static List<PLCDataMDL> PLCDataListL2 = new List<PLCDataMDL>();
        public static List<PrinterMDL> PrinterList = new List<PrinterMDL>();
        public static OPCServerMDL RexOPCServer = null;
        public static List<PLCDataMDL> RexrothDataListL1 = new List<PLCDataMDL>();
        public static List<PLCDataMDL> RexrothDataListL2 = new List<PLCDataMDL>();
        public static List<BarCodeScanMDL> ScannerListL1 = new List<BarCodeScanMDL>();
        public static List<BarCodeScanMDL> ScannerListL2 = new List<BarCodeScanMDL>();
        public static string SysDebug = "1";
        public static int PlanTimeSpan = 10;
        public static int PLineID = 0;
        public static int UpdateTime = 10;
    }
}

