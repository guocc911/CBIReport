using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDL
{

    /// <summary>
    /// 产线信息    Modify in 2018.3.25
    /// </summary>
    public class AssemblyLineMDL
    {


        private string plid;

        private string plname;

        private int pltype;

        private int pause_status=0;

        private int num;

        private int dt_pos;

        private int tg_oee;

        private int tg_op;

        private int ct_threshold;

        private int enable_th;

        private string remark;

        public string PLID
        {
            get{return plid;}
            set{plid=value;}
    
        }


        public string PL_NAME
        {
            get { return plname; }
            set { plname = value; }
        }


        public int PL_TYPE
        {
            get { return pltype; }
            set { pltype = value; }
        }



        public int PAUSE_STATUS
        {
            get { return pause_status; }
            set { pause_status = value; }

        }


        public int NUM
        {
            get { return num; }
            set { num = value; }
        }


        public int DT_POS
        {
            get { return dt_pos; }
            set { dt_pos = value; }
        }


        public int TG_OEE
        {
            get { return tg_oee; }
            set { tg_oee = value; }
        }

        public int TG_OP
        {
            get { return tg_op; }
            set { tg_op = value; }
        }


        public int CT_THRESHOLD
        {
            get { return ct_threshold; }
            set { ct_threshold = value; }
        }

        public int ENABLE_TH
        {
            get { return enable_th; }
            set { enable_th = value; }
        }

        public string REMARK
        {
            get { return remark; }
            set { remark = value; }
        }


        public static AssemblyLineMDL ParseDataRow(DataRow row)
        {
            AssemblyLineMDL mdl = new AssemblyLineMDL();

            try
            {

                mdl.PLID = Convert.ToString(row["PLID"]);
                mdl.PL_NAME=Convert.ToString(row["PL_NAME"]);
                mdl.PL_TYPE = Convert.ToInt32(row["PL_TYPE"]);
                mdl.PAUSE_STATUS = Convert.ToInt32(row["PUASE_STATUS"]);
                mdl.NUM = Convert.ToInt32(row["NUM"]);
                mdl.DT_POS = Convert.ToInt32(row["DT_POINT"]);
                mdl.REMARK = Convert.ToString(row["REMARK"]);
                mdl.CT_THRESHOLD = Convert.ToInt32(row["CT_THRESHOLD"]);
                mdl.TG_OP = Convert.ToInt32(row["TG_OP"]);
                mdl.TG_OEE = Convert.ToInt32(row["TG_OEE"]);
                mdl.ENABLE_TH = Convert.ToInt32(row["ENABLE_TH"]);

                return mdl;

            }
            catch
            {
                throw;
            }
        }
    }
}
