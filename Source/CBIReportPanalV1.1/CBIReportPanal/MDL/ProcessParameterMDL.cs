namespace MDL
{
    using System;

    public class ProcessParameterMDL
    {
        private DateTime createTime;
        private string lineID;
        private double maxValues;
        private double minValues;
        private string processs;
        private string productID;
        private string productName;
        private string remark;

        public DateTime CreateTime
        {
            get
            {
                return this.createTime;
            }
            set
            {
                this.createTime = value;
            }
        }

        public string LineID
        {
            get
            {
                return this.lineID;
            }
            set
            {
                this.lineID = value;
            }
        }

        public double MaxValues
        {
            get
            {
                return this.maxValues;
            }
            set
            {
                this.maxValues = value;
            }
        }

        public double MinValues
        {
            get
            {
                return this.minValues;
            }
            set
            {
                this.minValues = value;
            }
        }

        public string Processs
        {
            get
            {
                return this.processs;
            }
            set
            {
                this.processs = value;
            }
        }

        public string ProductID
        {
            get
            {
                return this.productID;
            }
            set
            {
                this.productID = value;
            }
        }

        public string ProductName
        {
            get
            {
                return this.productName;
            }
            set
            {
                this.productName = value;
            }
        }

        public string Remark
        {
            get
            {
                return this.remark;
            }
            set
            {
                this.remark = value;
            }
        }
    }
}

