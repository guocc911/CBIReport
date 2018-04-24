namespace MDL
{
    using System;

    public class PrinterMDL
    {
        private int codeType;
        private string countKey;
        private string ipAddress;
        private string lineID;
        private string name;
        private int type;

        public int CodeType
        {
            get
            {
                return this.codeType;
            }
            set
            {
                this.codeType = value;
            }
        }

        public string CountKey
        {
            get
            {
                return this.countKey;
            }
            set
            {
                this.countKey = value;
            }
        }

        public string IPAddress
        {
            get
            {
                return this.ipAddress;
            }
            set
            {
                this.ipAddress = value;
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

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }
    }
}

