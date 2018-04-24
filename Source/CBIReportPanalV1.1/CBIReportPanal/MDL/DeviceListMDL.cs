namespace MDL
{
    using System;

    public class DeviceListMDL
    {
        private string deviceID;
        private string deviceName;
        private string deviceState;
        private string deviceType;
        private string lineID;
        private int passCondition;
        private string remark;
        private string stationID;
        private int tID;

        public string DeviceID
        {
            get
            {
                return this.deviceID;
            }
            set
            {
                this.deviceID = value;
            }
        }

        public string DeviceName
        {
            get
            {
                return this.deviceName;
            }
            set
            {
                this.deviceName = value;
            }
        }

        public string DeviceState
        {
            get
            {
                return this.deviceState;
            }
            set
            {
                this.deviceState = value;
            }
        }

        public string DeviceType
        {
            get
            {
                return this.deviceType;
            }
            set
            {
                this.deviceType = value;
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

        public int PassCondition
        {
            get
            {
                return this.passCondition;
            }
            set
            {
                this.passCondition = value;
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
    }
}

