namespace MDL
{
    using System;

    public class PrintCountMDL
    {
        private int keyCount;
        private string keyName;
        private string remark;
        private int tID;
        private DateTime updapteTime;

        public int KeyCount
        {
            get
            {
                return this.keyCount;
            }
            set
            {
                this.keyCount = value;
            }
        }

        public string KeyName
        {
            get
            {
                return this.keyName;
            }
            set
            {
                this.keyName = value;
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

        public int TID
        {
            get
            {
                return this.tID;
            }
            set
            {
                this.tID = value;
            }
        }

        public DateTime UpdapteTime
        {
            get
            {
                return this.updapteTime;
            }
            set
            {
                this.updapteTime = value;
            }
        }
    }
}

