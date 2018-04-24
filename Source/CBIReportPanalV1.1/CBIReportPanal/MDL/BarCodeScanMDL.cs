namespace MDL
{
    using System;

    public class BarCodeScanMDL
    {
        private string barCodeItemID;
        private int comPort;
        private string comSet;
        private string enableTraceSysItemID;
        private int lightIOPort;
        private string lineID;
        private int lineType;
        private string stationID;

        public string BarCodeItemID
        {
            get
            {
                return this.barCodeItemID;
            }
            set
            {
                this.barCodeItemID = value;
            }
        }

        public int ComPort
        {
            get
            {
                return this.comPort;
            }
            set
            {
                this.comPort = value;
            }
        }

        public string ComSet
        {
            get
            {
                return this.comSet;
            }
            set
            {
                this.comSet = value;
            }
        }

        public string EnableTraceSysItemID
        {
            get
            {
                return this.enableTraceSysItemID;
            }
            set
            {
                this.enableTraceSysItemID = value;
            }
        }

        public int LightIOPort
        {
            get
            {
                return this.lightIOPort;
            }
            set
            {
                this.lightIOPort = value;
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

        public int LineType
        {
            get
            {
                return this.lineType;
            }
            set
            {
                this.lineType = value;
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
    }
}

