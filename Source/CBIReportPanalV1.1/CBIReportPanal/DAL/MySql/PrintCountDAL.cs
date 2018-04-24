namespace DAL
{
    using COMM;
    using MDL;
    using System;
    using System.Data;

    public class PrintCountDAL
    {
        public PrintCountMDL GetDataByKeyName(string keyName)
        {
            string format = string.Empty;
            PrintCountMDL tmdl = null;
            DataSet set = null;
            try
            {
                format = "select tid, keyname, keycount, updatetime, remark from print_count where keyname='{0}'";
                format = string.Format(format, keyName);
                set = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, format, null);
                if (set.Tables[0].Rows.Count > 0)
                {
                    tmdl = new PrintCountMDL();
                    tmdl.TID = Convert.ToInt32(set.Tables[0].Rows[0]["tid"]);
                    tmdl.KeyName = keyName;
                    tmdl.KeyCount = Convert.ToInt32(set.Tables[0].Rows[0]["keycount"]);
                    tmdl.UpdapteTime = Convert.ToDateTime(set.Tables[0].Rows[0]["updatetime"]);
                    tmdl.Remark = set.Tables[0].Rows[0]["remark"].ToString();
                }
            }
            catch (Exception exception)
            {
                tmdl = null;
                CLog.WriteErrLogInTrace(exception.Message);
            }
            finally
            {
                if (set != null)
                {
                    set.Dispose();
                }
            }
            return tmdl;
        }

        public int InsertData(PrintCountMDL mdl)
        {
            int num = 0;
            string cmdText = string.Empty;
            try
            {
                cmdText = "insert into print_count (";
                cmdText = string.Format(cmdText + "keyname, keycount, updatetime, remark) values (" + "'{0}', 1, now(), '')", mdl.KeyName);
                num = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, cmdText, null);
            }
            catch (Exception exception)
            {
                CLog.WriteErrLogInTrace(exception.Message);
            }
            return num;
        }

        public int UpdateByKeyName(PrintCountMDL mdl)
        {
            int num = 0;
            string format = string.Empty;
            try
            {
                format = "update print_count set keycount={0},updatetime=now() where keyname='{1}'";
                format = string.Format(format, mdl.KeyCount, mdl.KeyName);
                num = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, format, null);
            }
            catch (Exception exception)
            {
                CLog.WriteErrLogInTrace(exception.Message);
            }
            return num;
        }
    }
}

