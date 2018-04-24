namespace MDL
{
    using System;

    public class DetailResultMDL
    {
        private string code;
        private DateTime createTime;
        private string result;
        private string stationID;
        private string testItem;
        private int tID;

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

        public string Result
        {
            get
            {
                return this.result;
            }
            set
            {
                this.result = value;
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

        public string TestItem
        {
            get
            {
                return this.testItem;
            }
            set
            {
                this.testItem = value;
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
    }
}

