using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDL
{



    public class ProductUnit
    {
         private string name;

        private string code;

        private int actual;

        private double oee;

        private double productivity;

        private double co;


        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public string Code
        {
            get { return code; }
            set { code = value; }
        }


        public int Actual
        {
            get { return actual; }
            set { actual = value; }
        }

        public double OEE
        {
            get { return oee; }
            set { oee = value; }
        }

        public double PRPDUCTIVTY
        {
            get { return productivity; }
            set { productivity = value; }
        }


        public double CO
        {
            get { return co; }
            set { co = value; }
        }


        public ProductUnit()
        {
            name =string.Empty;
            code = string.Empty;
            actual = 0;
            productivity = 0.0;
            oee = 0.0;
            co = 0.0;

        }




    }
   
    
    //public class ProductUnitsMDL
    //{

    //    private List<ProductUnit> units;

      

    //    public List<ProductUnit> Units
    //    {
    //        get { return units; }
    //        set { units = value; }
    //    }


    //    public ProductUnitsMDL()
    //    {
    //       units =new  List<ProductUnit>();

    //    }



    //    public string ToString()
    //    {

    //        string ret = string.Empty;

    //        if(units.Count<=0)
    //            return string.Empty;

    //        int at=0;

    //        double pt=0.0;

    //        double oee=0.0;

    //        double co=0.0;

    //        string code=units[0].Code;

    //        foreach(ProductUnit item in units)
    //        {
    //            at+=item.Actual;
    //            oee+=item.OEE;
    //            pt+=item.PRPDUCTIVTY;
    //            co+=item.CO;
    //        }

    //         oee=oee/(double)units.Count;
    //         pt=pt/(double)units.Count;

    //        ret = String.Format("SN:{0} ¦ {1:F1} ¦ {2:F1}% ¦{3F1}H",code, pt, oee, co);

    //        return ret;
            
    //    }


    //    /// <summary>
    //    /// 是否包含当前数据
    //    /// </summary>
    //    /// <param name="unit"></param>
    //    /// <returns></returns>
    //    public bool IsContains(ProductUnit unit)
    //    {
    //       return this.units.Contains(unit);

    //    }


    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="unit"></param>
    //    public void AddProductItem(ProductUnit unit)
    //    {
    //        try
    //        {
    //             this.units.Add(unit);
                
    //        }
    //        catch 
    //        {
    //            throw;
    //        }
    //    }
     



    //}
}
