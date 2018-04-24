using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace MDL
{
   
    /// <summary>
    /// 采集分时单项模板
    /// </summary>
    public class AcqLineCountMDL
    {
        /// <summary>
        /// TAGID   时间+产线编号+时间区域编号+序号
        ///         20150809+01+01+01
        /// </summary>
        private string tid;

        /// <summary>
        /// 产线编号
        /// </summary>
        private string plid;


        /// <summary>
        /// 单元编号
        /// </summary>
        private string unitid;

        /// <summary>
        /// 产品代码
        /// </summary>
        private string pn;

        /// <summary>
        /// PLC EMS地址
        /// </summary>
        private int ems;


        /// <summary>
        /// 产线人数
        /// </summary>
        private int op;

        /// <summary>
        /// 产品编码名称
        /// </summary>
        private string tagName;
        

        /// <summary>
        /// 开始时间
        /// </summary>
        private DateTime startTime;

        /// <summary>
        /// 结束时间
        /// </summary>
        private DateTime endTime;



        /// <summary>
        /// 开始采集时间
        /// </summary>
        private DateTime beginTime;

        /// <summary>
        /// 更新时间
        /// </summary>
        private DateTime updateTime;

        /// <summary>
        /// 当前时段计数统计
        /// </summary>
        private int currentCount;


        /// <summary>
        /// 开始计数位置
        /// </summary>
        private int startCount;

        /// <summary>
        /// 错误信息
        /// </summary>
        private string error;


        /// <summary>
        /// 备注
        /// </summary>
        private string remark;


        public string TID
        {
            get { return tid; }

            set { tid = value; }
        }


        public string PLID
        {
            get { return plid; }

            set { plid = value; }
        }


        public string UNITID
        {
            get { return unitid; }

            set { unitid = value; }
        }


        public int EMS
        {
            get { return ems; }

            set { ems = value; }
        }



        public int OP
        {
            get { return op; }
            set { op = value; }

        }

        public string TGNMAE
        {
            get { return tagName; }

            set { tagName = value; }
        }

        public string PN
        {
            get { return pn; }

            set { pn = value; }
        }


        public DateTime START_TIME
        {
            get { return startTime; }

            set { startTime = value; }
        }

        public DateTime END_TIME
        {
            get { return endTime; }

            set { endTime = value; }
        }


        public DateTime BEGIN_TIME
        {
            get { return beginTime; }

            set { beginTime = value; }
        }



        public DateTime UPDATE_TIME
        {
            get { return updateTime; }

            set { updateTime = value; }
        }

        public int CUR_COUNT
        {
            get { return currentCount; }

            set { currentCount = value; }
        }

        public int START_COUNT
        {
            get { return startCount; }

            set { startCount = value; }
        }

        public string ERROR
        {
            get { return error; }

            set { error = value; }
        }

        public string REMARK
        {
            get { return remark; }

            set { remark = value; }
        }



        public AcqLineCountMDL()
        {
            this.TID = string.Empty;
            this.PLID =string.Empty;
            this.TGNMAE = string.Empty;
            this.PN =string.Empty;
            this.EMS = 0;
            this.OP = 0;
            this.START_COUNT = 0;
            this.ERROR = string.Empty;
            this.CUR_COUNT = 0;
            this.REMARK =string.Empty;

        
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="line"></param>
        /// <param name="tag"></param>
        /// <param name="seq"></param>
        public AcqLineCountMDL(DateTime date,string line,string tag,string seq)
        {

            this.tid = date.ToString("yyyyMMdd") + line + tag + seq;
            this.unitid = date.ToString("yyyyMMdd") + line + tag;



        }


        /// <summary>
        /// 获取EMS编码
        /// </summary>
        /// <param name="ems"></param>
        /// <returns></returns>
        public string FormatEMSCode(int ems)
        {
            try
            {
                string code = String.Format("{0}-{1}", this.PLID, ems);

                return code;
            }
            catch 
            {
                throw;
            }
        }


        public string GetEMSCode()
        {

            try
            {
                string code = String.Format("{0}-{1}", this.PLID, this.ems);

                return code;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 获取产线生产序号
        /// </summary>
        /// <param name="date"></param>
        /// <param name="line"></param>
        /// <param name="tag"></param>
        /// <param name="seq"></param>
        public bool SetTID(DateTime date,string line,string tag,string seq)
        {
            try
            {

                if (date == null)
                    return false;

                if (line == null)
                    return false;

                if (tag == null)
                    return false;

                if (seq == null)
                    return false;


                this.tid = date.ToString("yyyyMMdd") + line + tag + seq;

                this.unitid = date.ToString("yyyyMMdd") + line + tag;

                return true;

            }
            catch 
            {
            	throw;
            }
        
        }

        


        public static AcqLineCountMDL  PraseDataRow(DataRow row)
        {
            AcqLineCountMDL mdl = new AcqLineCountMDL();

            try
            {
                mdl.TID = Convert.ToString(row["TID"]);
                mdl.PLID = Convert.ToString(row["PLID"]);
                mdl.UNITID = Convert.ToString(row["UNITID"]);
                mdl.TGNMAE = Convert.ToString(row["TGNMAE"]);
                mdl.PN = Convert.ToString(row["PN"]);
                mdl.EMS = Convert.ToInt32(row["EMS"]);

                string op=COMM.SystemUtils.ParseItem(row,"OP");

                if (op == string.Empty)
                    mdl.OP = 0;
                else
                    mdl.OP = Convert.ToInt32(row["OP"]);

                mdl.START_COUNT = Convert.ToInt32(row["START_COUNT"]);
                mdl.START_TIME = Convert.ToDateTime(row["START_TIME"]);
                mdl.END_TIME = Convert.ToDateTime(row["END_TIME"]);


                string beginTime = COMM.SystemUtils.ParseItem(row, "BEGIN_TIME");
                if (beginTime == string.Empty)
                    mdl.BEGIN_TIME = mdl.START_TIME;
                else
                    mdl.UPDATE_TIME = Convert.ToDateTime(row["BEGIN_TIME"]);


                string updateTime = COMM.SystemUtils.ParseItem(row, "UPDATE_TIME");
                if (updateTime == string.Empty)
                    mdl.UPDATE_TIME = mdl.END_TIME;
                else
                    mdl.UPDATE_TIME = Convert.ToDateTime(row["UPDATE_TIME"]);

               // mdl.UPDATE_TIME = Convert.ToDateTime(row["UPDATE_TIME"]);

                mdl.ERROR = Convert.ToString(row["ERROR"]);
                mdl.CUR_COUNT = Convert.ToInt32(row["CUR_COUNT"]);
                mdl.REMARK = Convert.ToString(row["REMARK"]);

                return mdl;
            }
            catch
            {
                throw;
            }
         
     
        }
    }
}
