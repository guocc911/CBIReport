using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDL
{
    public class PlanItemMDL
    {

        private string _productID = string.Empty;

        private int _plannum = 0;

        private int _actualnum = 0;

       // private string _oee = "";

        private string _remark = "";


        public string ProductID
        {
            get { return _productID; }
            set { _productID = value; }
        }


        public int PlanNumber
        {
            get { return _plannum; }
            set { _plannum = value; }
        }

        public int ActualNumber
        {
            get { return _actualnum; }
            set { _actualnum = value; }
        }

        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }


        public PlanItemMDL()
        {
 
        }



        /// <summary>
        /// 
        /// </summary>
        public void AddItem(string PID,int planNum,int actualNum)
        {
            try
            {
                if (_plannum<0)
                    _plannum=0;
                if (_actualnum < 0)
                    _actualnum = 0;
                _productID += "\r\n" + PID;
                _plannum += planNum;
                _actualnum += actualNum;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 获取OEE
        /// </summary>
        /// <returns></returns>
        public string GetOEEPrint()
        {
            try
            {
                if (_plannum < 0 || _actualnum <0|| this.ProductID.Length < 1 || this.ProductID == string.Empty)
                    return string.Empty;
                

                string oeeString = string.Empty;

                double oee = (double)_actualnum / (double)_plannum;

                oeeString = (oee * 100).ToString("F0") + "%";

                return oeeString;

            }
            catch 
            {
                throw;
            }
        }

    }
}
