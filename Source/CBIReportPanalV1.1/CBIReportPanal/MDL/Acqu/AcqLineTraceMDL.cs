using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDL
{

    /// <summary>
    /// 
    /// </summary>
    public class AcqLineTraceMDL
    {


        private string acqid;

        private DateTime acq_date;

        private string seqid;

        private string plid;

        private int  ems;

        private string stationid;

        private int beg_count;

        private string error;

        #region Properties

        public string ACQID
        {
            get{return acqid;}

            set { acqid = value; }
        }


        public DateTime ACQ_DATE
        {
            get { return acq_date; }

            set { acq_date = value; }
        }

        public string SEQID
        {
            get { return seqid; }

            set { seqid = value; }
        }


        public string PLID
        {
            get { return plid; }

            set { plid = value; }
        }


        public string STATIONID
        {

            get { return stationid; }

            set { stationid = value; }
        }

        public int EMS
        {
            get { return ems; }

            set { ems = value; }
        }

        public int BEG_COUNT
        {
            get { return beg_count; }

            set { beg_count = value; }
        }

    

        public string  ERROR
        {
            get { return error; }

            set { error = value; }
        }

     

        #endregion



        public AcqLineTraceMDL()
        {
            acqid="0";
            acq_date= DateTime.Now;
            seqid=String.Empty;
            plid=String.Empty;
            ems=0;
            stationid=string.Empty;
            beg_count=0;
            error=string.Empty;    
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        public void Parse(DataRow row)
        {

            try
            {

                AcqLineTraceMDL mdl = PraseDataRow(row);

                this.ACQID = mdl.ACQID;
                this.ACQ_DATE = mdl.ACQ_DATE;
                this.SEQID = mdl.SEQID;
                this.PLID = mdl.PLID;
                this.EMS = mdl.EMS;
                this.STATIONID = mdl.STATIONID;
                this.BEG_COUNT = mdl.BEG_COUNT;
                this.ERROR = mdl.ERROR;
         
            }
            catch 
            {
                throw;
            }



        }

        /// <summary>
        /// 解析数据
        /// </summary>
        /// <param name="row"></param>
        public static AcqLineTraceMDL PraseDataRow(DataRow row)
        {

            AcqLineTraceMDL mdl = new AcqLineTraceMDL();

            try
            {
                mdl.ACQID = Convert.ToString(row["ACQID"]);
                mdl.ACQ_DATE = Convert.ToDateTime(row["ACQ_DATE"]);
                mdl.SEQID = Convert.ToString(row["SEQID"]);
                mdl.PLID = Convert.ToString(row["PLID"]);
                mdl.EMS = Convert.ToInt32(row["EMS"]);
                mdl.STATIONID = Convert.ToString(row["STATIONID"]);
                mdl.BEG_COUNT = Convert.ToInt32(row["BEG_COUNT"]);
                mdl.ERROR = Convert.ToString(row["ERROR"]);
         

                return mdl;
            }
            catch
            {
                throw;
            }


        }

        //public static AcqLineUnitMDL ParseDataRow(DataRow row)
        //{
        //    try
        //    {


        //    }
        //    catch
        //    {

        //    }
        //}
    }
}
