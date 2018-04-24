namespace MDL
{
    using System;

    public class PLCDataMDL
    {
        private string dataType;
        private string dataValue;
        private string dbFieldName;
        private int dbFieldType;
        private int decPoint;
        private bool isKey;
        private string itemID;
        private bool quality;
        private string stationID;
        private DateTime timeStamp;
        private int uniqueID;
        private int updateCount;

        public string DataType
        {
            get
            {
                return this.dataType;
            }
            set
            {
                this.dataType = value;
            }
        }

        public string DataValue
        {
            get
            {
                return this.dataValue;
            }
            set
            {
                this.dataValue = value;
            }
        }

        public string DBFieldName
        {
            get
            {
                return this.dbFieldName;
            }
            set
            {
                this.dbFieldName = value;
            }
        }

        public int DBFieldType
        {
            get
            {
                return this.dbFieldType;
            }
            set
            {
                this.dbFieldType = value;
            }
        }

        public int DecPoint
        {
            get
            {
                return this.decPoint;
            }
            set
            {
                this.decPoint = value;
            }
        }

        public bool IsKey
        {
            get
            {
                return this.isKey;
            }
            set
            {
                this.isKey = value;
            }
        }

        public string ItemID
        {
            get
            {
                return this.itemID;
            }
            set
            {
                this.itemID = value;
            }
        }

        public bool Quality
        {
            get
            {
                return this.quality;
            }
            set
            {
                this.quality = value;
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

        public DateTime TimeStamp
        {
            get
            {
                return this.timeStamp;
            }
            set
            {
                this.timeStamp = value;
            }
        }

        public int UniqueID
        {
            get
            {
                return this.uniqueID;
            }
            set
            {
                this.uniqueID = value;
            }
        }

        public int UpdateCount
        {
            get
            {
                return this.updateCount;
            }
            set
            {
                this.updateCount = value;
            }
        }
    }
}

