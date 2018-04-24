namespace DAL
{
    using COMM;
    using System;
    using System.Data;

    public class ProcessParameterDAL
    {
        public bool ExistParam(string lineid, string productid, string stationID)
        {
            bool flag = false;
            string format = string.Empty;
            DataSet set = null;
            try
            {
                format = "select count(*) as num from process_parameter where lineid='{0}' and productid='{1}' and substring(processs,1,5)='{2}'";
                format = string.Format(format, lineid, productid, stationID.Substring(0, 5));
                set = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, format, null);
                if ((set.Tables[0].Rows.Count > 0) && (set.Tables[0].Rows[0]["num"].ToString() != "0"))
                {
                    flag = true;
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
            return flag;
        }
    }
}

