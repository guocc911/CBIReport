namespace DataGather
{
    using COMM;
    using MDL;
    using System;
    using System.Text;

    public class IOLogik
    {
        private int[] hConnection;
        private string ipAddress;
        private string password;
        private ushort port;
        private uint timeOut;

        public IOLogik(IOLogikMDL ioLogik)
        {
            this.hConnection = new int[1];
            this.ipAddress = ioLogik.IP;
            this.port = ioLogik.Port;
            this.timeOut = ioLogik.ConnTimeOut;
            this.password = ioLogik.Password;
        }

        public IOLogik(string serverIPAddress, ushort serverPort, uint connectTimeOut, string pwd)
        {
            this.hConnection = new int[1];
            this.ipAddress = serverIPAddress;
            this.port = serverPort;
            this.timeOut = connectTimeOut;
            this.password = pwd;
        }

        private void CheckErr(int iRet, string szFunctionName)
        {
            string str = "MXIO_OK";
            switch (iRet)
            {
                case 0x3e9:
                    str = "ILLEGAL_FUNCTION";
                    break;

                case 0x3ea:
                    str = "ILLEGAL_DATA_ADDRESS";
                    break;

                case 0x3eb:
                    str = "ILLEGAL_DATA_VALUE";
                    break;

                case 0x3ec:
                    str = "SLAVE_DEVICE_FAILURE";
                    break;

                case 0x3ee:
                    str = "SLAVE_DEVICE_BUSY";
                    break;

                case 0x7d1:
                    str = "EIO_TIME_OUT";
                    break;

                case 0x7d2:
                    str = "EIO_INIT_SOCKETS_FAIL";
                    break;

                case 0x7d3:
                    str = "EIO_CREATING_SOCKET_ERROR";
                    break;

                case 0x7d4:
                    str = "EIO_RESPONSE_BAD";
                    break;

                case 0x7d5:
                    str = "EIO_SOCKET_DISCONNECT";
                    break;

                case 0x7d6:
                    str = "PROTOCOL_TYPE_ERROR";
                    break;

                case 0xbb9:
                    str = "SIO_OPEN_FAIL";
                    break;

                case 0xbba:
                    str = "SIO_TIME_OUT";
                    break;

                case 0xbbb:
                    str = "SIO_CLOSE_FAIL";
                    break;

                case 0xbbc:
                    str = "SIO_PURGE_COMM_FAIL";
                    break;

                case 0xbbd:
                    str = "SIO_FLUSH_FILE_BUFFERS_FAIL";
                    break;

                case 0xbbe:
                    str = "SIO_GET_COMM_STATE_FAIL";
                    break;

                case 0xbbf:
                    str = "SIO_SET_COMM_STATE_FAIL";
                    break;

                case 0xbc0:
                    str = "SIO_SETUP_COMM_FAIL";
                    break;

                case 0xbc1:
                    str = "SIO_SET_COMM_TIME_OUT_FAIL";
                    break;

                case 0xbc2:
                    str = "SIO_CLEAR_COMM_FAIL";
                    break;

                case 0xbc3:
                    str = "SIO_RESPONSE_BAD";
                    break;

                case 0xbc4:
                    str = "SIO_TRANSMISSION_MODE_ERROR";
                    break;

                case 0xfa1:
                    str = "PRODUCT_NOT_SUPPORT";
                    break;

                case 0xfa2:
                    str = "HANDLE_ERROR";
                    break;

                case 0xfa3:
                    str = "SLOT_OUT_OF_RANGE";
                    break;

                case 0xfa4:
                    str = "CHANNEL_OUT_OF_RANGE";
                    break;

                case 0xfa5:
                    str = "COIL_TYPE_ERROR";
                    break;

                case 0xfa6:
                    str = "REGISTER_TYPE_ERROR";
                    break;

                case 0xfa7:
                    str = "FUNCTION_NOT_SUPPORT";
                    break;

                case 0xfa8:
                    str = "OUTPUT_VALUE_OUT_OF_RANGE";
                    break;

                case 0xfa9:
                    str = "INPUT_VALUE_OUT_OF_RANGE";
                    break;

                case 0:
                    return;
            }
            Console.WriteLine("Function \"{0}\" execution Fail. Error Message : {1}\n", szFunctionName, str);
            if ((iRet == 0x7d1) || (iRet == 0xfa2))
            {
                MXIO_CS.MXEIO_Exit();
                Console.WriteLine("Press any key to close application\r\n");
                Console.ReadLine();
            }
        }

        public bool Connect()
        {
            try
            {
                byte[] bytStatus = new byte[1];
                int num = MXIO_CS.MXEIO_Init();
                switch (MXIO_CS.MXEIO_E1K_Connect(Encoding.UTF8.GetBytes(this.ipAddress), this.port, this.timeOut, this.hConnection, Encoding.UTF8.GetBytes(this.password)))
                {
                    case 0:
                        switch (MXIO_CS.MXEIO_CheckConnection(this.hConnection[0], this.timeOut, bytStatus))
                        {
                            case 0:
                                return true;

                            case 0x7d1:
                            case 0xfa2:
                                MXIO_CS.MXEIO_Exit();
                                break;
                        }
                        return false;

                    case 0x7d1:
                    case 0xfa2:
                        MXIO_CS.MXEIO_Exit();
                        break;
                }
                return false;
            }
            catch (Exception exception)
            {
                CLog.WriteErrLogInTrace(string.Format("在连接IOLogik时出错，{0}", exception.Message));
                return false;
            }
        }

        public bool DisConnect()
        {
            try
            {
                int num = MXIO_CS.MXEIO_Disconnect(this.hConnection[0]);
                MXIO_CS.MXEIO_Exit();
                return (num == 0);
            }
            catch (Exception exception)
            {
                CLog.WriteErrLogInTrace(string.Format("在设置IO端口状态时出错，{0}", exception.Message));
                return false;
            }
        }

        public bool Do_Writes(byte channel, uint dwSetDOValue)
        {
            try
            {
                byte bytCount = 1;
                byte bytStartChannel = channel;
                switch (MXIO_CS.E1K_DO_Writes(this.hConnection[0], bytStartChannel, bytCount, dwSetDOValue))
                {
                    case 0:
                        return true;

                    case 0x7d1:
                    case 0xfa2:
                        MXIO_CS.MXEIO_Exit();
                        break;
                }
                return false;
            }
            catch (Exception exception)
            {
                CLog.WriteErrLogInTrace(string.Format("在设置IO端口状态时出错，{0}", exception.Message));
                return false;
            }
        }
    }
}

