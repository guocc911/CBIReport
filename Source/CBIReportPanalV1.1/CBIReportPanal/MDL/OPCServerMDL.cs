namespace MDL
{
    using System;

    public class OPCServerMDL
    {
        private string groupName;
        private string opcip = string.Empty;
        private string opcName;

        public string GroupName
        {
            get
            {
                return this.groupName;
            }
            set
            {
                this.groupName = value;
            }
        }

        public string OPCIP
        {
            get
            {
                return this.opcip;
            }
            set
            {
                this.opcip = value;
            }
        }

        public string OPCName
        {
            get
            {
                return this.opcName;
            }
            set
            {
                this.opcName = value;
            }
        }
    }
}

