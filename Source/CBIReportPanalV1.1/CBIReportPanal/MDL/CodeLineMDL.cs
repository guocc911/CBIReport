namespace MDL
{
    using System;

    public class CodeLineMDL
    {
        private string code;
        private DateTime createTime;
        private string stationID;
        private int tID;
        private int writePLC;

        public string Code
        {
            get
            {
                return this.code;
            }
            set
            {
                this.code = value;
            }
        }

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

        public string StationID
        {
            get
            {
                return this.stationID;
            }
            set
            {
                this.stationID = value;
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

        public int WritePLC
        {
            get
            {
                return this.writePLC;
            }
            set
            {
                this.writePLC = value;
            }
        }
    }
}

