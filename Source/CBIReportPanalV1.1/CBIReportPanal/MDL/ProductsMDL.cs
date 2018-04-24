using System;
using System.Data;
using System.Data.Common;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDL
{



    public class ProductReportMDL
    {
        private string name;

        private double oee;

        private string code;

        private double op;

        private double co;

        public ProductReportMDL()
        {
            name = string.Empty;
            oee = 0.0;
            op = 0.0;
            co = 0.0;
        }

        public string NAME
        {
            get { return name; }
            set { name = value; }
        }



        public string CODE
        {
            get { return code; }
            set { code = value; }

        }
        public double OEE
        {
            get { return oee; }
            set { oee = value; }
        }


        public double OP
        {
            get { return op; }
            set { op = value; }
        }


        public double CO
        {
            get { return co; }
            set { co = value; }
        }

        public string ToString()
        {
           // string ret = string.Format("PN:{0} | {1:F1} | {2:F1}% | {3:F1}H", name, op, oee * 100, co);
            string ret = string.Format("PN:{0} | P:{1:F1} | OEE:{2:F1}% ", name, op, oee * 100);
            return ret;
        }

     
    }
    public class ProductsMDL
    {

        private Hashtable line1Products = null;

        private Hashtable line2Products = null;

        private Hashtable line3Products = null;

        private Hashtable mguProducts = null;


        public Hashtable Line1Products
        {
            get { return line1Products; }
            set { line1Products = value; }
        }



        public Hashtable Line2Products
        {
            get { return line2Products; }
            set { line2Products = value; }
        }

        public Hashtable Line3Products
        {
            get { return line3Products; }
            set { line3Products = value; }
        }



        public Hashtable MGUProducts
        {
            get { return mguProducts; }
            set { mguProducts = value; }
        }

        public ProductsMDL()
        {
            line1Products = new Hashtable();

            line2Products = new Hashtable();
       
            line3Products = new Hashtable();

            mguProducts   = new Hashtable();



        }


        public List<AcqUnitMDL> GetLineList1()
        {
            List<AcqUnitMDL> units = new List<AcqUnitMDL>();

            foreach (DictionaryEntry de in line1Products)
            {
                units.Add((AcqUnitMDL)de.Value);
            }

            return units;
        }

        public List<AcqUnitMDL> GetLineList2()
        {

            List<AcqUnitMDL> units = new List<AcqUnitMDL>();

            foreach (DictionaryEntry de in line2Products)
            {
                units.Add((AcqUnitMDL)de.Value);
            }

            return units;
        }

        public List<AcqUnitMDL> GetLineList3()
        {

            List<AcqUnitMDL> units = new List<AcqUnitMDL>();

            foreach (DictionaryEntry de in line3Products)
            {
                units.Add((AcqUnitMDL)de.Value);
            }

            return units;
        }

        public List<AcqUnitMDL> GetLineList4()
        {
            List<AcqUnitMDL> units = new List<AcqUnitMDL>();

            foreach (DictionaryEntry de in mguProducts)
            {
                units.Add((AcqUnitMDL)de.Value);
            }

            return units;
        }



    }
}
