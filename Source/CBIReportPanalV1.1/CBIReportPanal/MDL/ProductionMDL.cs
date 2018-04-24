using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDL
{

    /// <summary>
    /// 产品定义
    /// </summary>
    public class ProductionMDL
    {

        private string pn;

        private string name;

        private string plid;

        private int ems=0;

        private DateTime create_time;

        private string code;

        private int type;

        private string factory;

        private int ct;

        private int op;

        private string remark;

        #region properties


        public string PN
        {
            get { return pn; }

            set { pn = value; }
        }

        /// <summary>
        /// 产线号
        /// </summary>
        public string Name
        {
            get { return name; }

            set { name = value; }
        }

        /// <summary>
        /// 产线号
        /// </summary>
        public int EMS
        {
            get { return ems; }

            set { ems = value; }
        }





        /// <summary>
        /// 产品名称
        /// </summary>
        public string PLID
        {
            get { return plid; }

            set { plid = value; }
        }


        public DateTime CreateTime
        {
            get { return create_time; }

            set { create_time = value; }

        }



        public string Code
        {
            get { return code; }

            set { code = value; }

        }

        /// <summary>
        /// 厂家
        /// </summary>
        public string Factory
        {
            get { return factory; }

            set { factory = value; }

        }

        public int CodeType
        {
            get { return type; }

            set { type = value; }
        }

        /// <summary>
        /// CT 运维地址
        /// </summary>
        public int CT
        {
            get { return ct; }

            set { ct = value; }
        }


        public int OP
        {
            get { return op; }

            set { op = value; }
        }

        public string Remark
        {
            get { return remark; }

            set { remark = value; }
        }


        public string Key
        {
            get
            {
                if (ems<0 || this.plid == null||this.plid==string.Empty)
                    return string.Empty;

                string code = ems.ToString() + "-" + this.plid.ToString();

                return code;
            }
        }

        public ProductionMDL()
        {
            this.pn = string.Empty;
            this.plid = string.Empty;
            this.name = string.Empty;
            // this.create_time ;
            this.code = "01";
            this.type = 0;
            this.ems = 0;
            this.op = 0;
            this.ct = 0;

        }




        public static ProductionMDL ParseDataRow(DataRow row)
        {

            ProductionMDL mdl = new ProductionMDL();

            try
            {

                if (COMM.Utils.CheckCode(row, "PN"))
                {

                    mdl.PN = Convert.ToString(row["PN"]);

                    if (mdl.PN.Substring(0, 1) == "P")
                        mdl.PN = mdl.PN.Substring(1, mdl.PN.Length - 1);
                }

                if (COMM.Utils.CheckCode(row, "PLID"))
                    mdl.PLID = Convert.ToString(row["PLID"]);

                if (COMM.Utils.CheckCode(row, "NAME"))
                    mdl.Name = Convert.ToString(row["NAME"]);

                if (COMM.Utils.CheckCode(row, "CREATE_TIME"))
                    mdl.CreateTime = Convert.ToDateTime(row["CREATE_TIME"]);

                if (COMM.Utils.CheckCode(row, "CODE"))
                    mdl.Code = Convert.ToString(row["CODE"]);

                if (COMM.Utils.CheckCode(row, "TYPE"))
                    mdl.CodeType = Convert.ToInt32(row["TYPE"]);

                if (COMM.Utils.CheckCode(row, "FACTORY"))
                    mdl.Factory = Convert.ToString(row["FACTORY"]);

                if (COMM.Utils.CheckCode(row, "REMARK"))
                    mdl.Remark = Convert.ToString(row["REMARK"]);

                if (COMM.Utils.CheckCode(row, "EMS"))
                    mdl.EMS = Convert.ToInt32(row["EMS"]);

                if (COMM.Utils.CheckCode(row, "OP"))
                    mdl.OP = Convert.ToInt32(row["OP"]);

                if (COMM.Utils.CheckCode(row, "CT"))
                    mdl.CT = Convert.ToInt32(row["CT"]);


                return mdl;

            }
            catch
            {

                throw;
            }

        }



        #endregion
    }
}
