using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDL
{
    public class StaionEMCMDL
    {

        private string plid;

        private int emc;

        private string pn;

        /// <summary>
        /// 产品ID
        /// </summary>
        public string PLID
        {
            get { return plid; }
            set { plid=value; }
        }

        /// <summary>
        /// EMC数据
        /// </summary>
        public int EMC
        {
            get { return emc; }
            set { emc = value; }
        }


        /// <summary>
        /// 产品编号
        /// </summary>
        public string PN
        {
            get { return pn; }
            set { pn = value; }
        
        }
    }
}
