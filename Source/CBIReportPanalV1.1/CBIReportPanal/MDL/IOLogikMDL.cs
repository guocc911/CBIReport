namespace MDL
{
    using System;

    public class IOLogikMDL
    {
        private uint connTimeOut;
        private string ip;
        private string password;
        private ushort port;

        public uint ConnTimeOut
        {
            get
            {
                return this.connTimeOut;
            }
            set
            {
                this.connTimeOut = value;
            }
        }

        public string IP
        {
            get
            {
                return this.ip;
            }
            set
            {
                this.ip = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }

        public ushort Port
        {
            get
            {
                return this.port;
            }
            set
            {
                this.port = value;
            }
        }
    }
}

