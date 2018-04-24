using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace ProductLine
{
    public class PlineInfo
    {

        private string plineID;

        private List<string> pn;

        private List<int> plan;

        private List<int> actual;

        private List<int> oee;


        public string PLineID
        {
            get { return plineID; }
            set { plineID = value; }
        }



        public List<string> PN
        {
            get { return pn; }
            set { pn = value; }
        }

        public List<int> PLAN
        {
            get { return plan; }
            set { plan = value; }
        }


        public List<int> Actual
        {
            get { return actual; }
            set { actual = value; }
        }


        public List<int> OEE
        {
            get { return oee; }
            set { oee = value; }
        }

        public PlineInfo()
        {
            plineID = string.Empty;
            pn = null;
            actual =null;
            plan = null;
            oee = null;

        }
    }
}
