namespace DAL
{
    using COMM;
    using System;
    using System.Data;
    using System.Xml;


    public class DeviceListDAL
    {
        public DataTable GetDeviceList(string lineID)
        {
            string format = string.Empty;
            try
            {
                format = "select tid,deviceid,devicestate,remark from device_list where (devicetype='PLC' or devicetype='TCP/IP') and lineid='{0}'";
                format = string.Format(format, lineID);
                return MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, format, null).Tables[0];
            }
            catch (Exception exception)
            {
                CLog.WriteErrLogInTrace(exception.Message);
                return null;
            }
        }

        public int GetPassCondition(string stationID)
        {
            string format = string.Empty;
            int num = 0;
            DataSet set = null;
            try
            {
                format = "select passcondition from device_list where devicetype='串口' and stationid='{0}'";
                format = string.Format(format, stationID);
                set = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, format, null);
                if ((set.Tables[0].Rows.Count > 0) && (set.Tables[0].Rows[0]["passcondition"].ToString() != string.Empty))
                {
                    num = Convert.ToInt32(set.Tables[0].Rows[0]["passcondition"]);
                }
            }
            catch (Exception exception)
            {
                CLog.WriteErrLogInTrace(exception.Message);
            }
            finally
            {
                if (set != null)
                {
                    set.Dispose();
                }
            }
            return num;
        }

        public int GetPassCondition(string stationID, string lineID)
        {
            string format = string.Empty;
            int num = 0;
            DataSet set = null;
            try
            {
                format = "select passcondition from device_list where devicetype='串口' and stationid='{0}' and lineid='{1}'";
                format = string.Format(format, stationID, lineID);
                set = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, format, null);
                if ((set.Tables[0].Rows.Count > 0) && (set.Tables[0].Rows[0]["passcondition"].ToString() != string.Empty))
                {
                    num = Convert.ToInt32(set.Tables[0].Rows[0]["passcondition"]);
                }
            }
            catch (Exception exception)
            {
                CLog.WriteErrLogInTrace(exception.Message);
            }
            finally
            {
                if (set != null)
                {
                    set.Dispose();
                }
            }
            return num;
        }

        public int UpdateByField(string fieldName, string fieldValue, int valueType, string keyName, string keyValue)
        {
            int num = 0;
            string format = string.Empty;
            try
            {
                if (valueType == 2)
                {
                    format = "update device_list set {0}='{1}' where {2}='{3}'";
                }
                else if (valueType == 1)
                {
                    format = "update device_list set {0}={1} where {2}='{3}'";
                }
                format = string.Format(format, new object[] { fieldName, fieldValue, keyName, keyValue });
                num = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, format, null);
                if (num <= 0)
                {
                    CLog.WriteErrLog(format);
                }
                return num;
            }
            catch (Exception exception)
            {
                CLog.WriteErrLogInTrace(exception.Message);
                CLog.WriteErrLog(format);
                return 0;
            }
        }
    }
}

