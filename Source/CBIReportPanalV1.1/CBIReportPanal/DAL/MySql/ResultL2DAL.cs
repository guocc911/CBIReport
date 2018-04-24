namespace DAL
{
    using COMM;
    using MDL;
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class ResultL2DAL
    {
        public bool CheckAllResult(string keyFieldName, string barCode, string productType)
        {
            bool flag = true;
            int integrity = 1;
            int valid = 1;
            int result = 0;
            string format = string.Empty;
            string resultDesc = string.Empty;
            DataSet set = new DataSet();
            try
            {
                format = "select st115_pf,st123,st124_pf,st150_t,st160,st170,st176_pf,st177,st180,st230,st240,st250,st260,st290,st310,st320,st340_t1,st340_t2,st340_a1,st340_a2,st360_xminx1,st360_xminy1,st360_xmaxx1,st360_xmaxy1,st360_yminx1,st360_yminy1,st360_ymaxx1,st360_ymaxy1,st361,st362_t1,st362_t2,st362_a1,st362_a2,st362_p1,st362_p2,st370,st380,st390 from result_line2 where {0}='{1}' order by updatetime desc limit 1";
                format = string.Format(format, keyFieldName, barCode);
                set = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, format, null);
                if (set.Tables[0].Rows.Count <= 0)
                {
                    return false;
                }
                for (int i = 0; i < set.Tables[0].Columns.Count; i++)
                {
                    double num5 = 0.0;
                    double num6 = 0.0;
                    double num7 = 0.0;
                    DataSet set2 = null;
                    string columnName = set.Tables[0].Columns[i].ColumnName;
                    if (set.Tables[0].Rows[0][columnName].ToString() != string.Empty)
                    {
                        num5 = Convert.ToDouble(set.Tables[0].Rows[0][columnName]);
                    }
                    format = "select maxvalues,minvalues from process_parameter where lineid='2' and productid='{0}' and processs='{1}'";
                    format = string.Format(format, productType, columnName);
                    set2 = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, format, null);
                    if (set2.Tables[0].Rows.Count > 0)
                    {
                        if (set2.Tables[0].Rows[0]["maxvalues"].ToString() != string.Empty)
                        {
                            num6 = Convert.ToDouble(set2.Tables[0].Rows[0]["maxvalues"]);
                        }
                        if (set2.Tables[0].Rows[0]["minvalues"].ToString() != string.Empty)
                        {
                            num7 = Convert.ToDouble(set2.Tables[0].Rows[0]["minvalues"]);
                        }
                        if (set.Tables[0].Rows[0][columnName].ToString() == string.Empty)
                        {
                            integrity = 0;
                            flag = false;
                            resultDesc = resultDesc + string.Format("{0}为空;", columnName);
                            CLog.WriteStationLog("ST400", string.Format("{0}的{1}检测结果为空", barCode, columnName));
                        }
                        if ((num5 < num7) || (num5 > num6))
                        {
                            valid = 0;
                            flag = false;
                            resultDesc = resultDesc + string.Format("{0}不合格;", columnName);
                            CLog.WriteStationLog("ST400", string.Format("{0}的{1}检测结果{2}不合格，范围为{3}-{4}", new object[] { barCode, columnName, num5, num7, num6 }));
                        }
                    }
                    set2.Dispose();
                }
                if (flag)
                {
                    result = 1;
                }
                this.UpdateResultByKeyCode(keyFieldName, barCode, integrity, valid, result, resultDesc);
                return flag;
            }
            catch (Exception exception)
            {
                CLog.WriteErrLogInTrace(exception.Message);
                flag = false;
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

        public void CheckResultState()
        {
            string str = string.Empty;
            string str2 = string.Empty;
            string str3 = string.Empty;
            string cmdText = string.Empty;
            int num = 0;
            DataSet set = new DataSet();
            try
            {
                cmdText = "select calipercode,brakecode,bracketcode from result_line2 where calipercode is not null and brakecode is not null and bracketcode is not null and result is null and (resultdesc is null or resultdesc='')";
                set = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, cmdText, null);
                if (set.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < set.Tables[0].Columns.Count; i++)
                    {
                        str = set.Tables[0].Rows[i]["calipercode"].ToString();
                        str2 = set.Tables[0].Rows[i]["brakecode"].ToString();
                        str3 = set.Tables[0].Rows[i]["bracketcode"].ToString();
                        cmdText = "update result_line2 set integrity=1,valid=1,result=1 where calipercode='{0}' and brakecode='{1}' and bracketcode='{2}'";
                        cmdText = string.Format(cmdText, str, str2, str3);
                        num = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, cmdText, null);
                    }
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
        }

        public bool CheckStationResult(string keyFieldName, string barCode, string productType, string stationID, List<PLCDataMDL> testItemList)
        {
            bool flag = true;
            string cmdText = string.Empty;
            DataSet set = new DataSet();
            try
            {
                cmdText = cmdText + "select ";
                foreach (PLCDataMDL amdl in testItemList)
                {
                    cmdText = cmdText + amdl.DBFieldName;
                    cmdText = cmdText + ",";
                }
                if (testItemList.Count > 0)
                {
                    cmdText = cmdText.Substring(0, cmdText.Length - 1);
                }
                else
                {
                    return false;
                }
                cmdText = string.Format(cmdText + " from result_line2 where {0}='{1}' order by updatetime desc limit 1", keyFieldName, barCode);
                set = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, cmdText, null);
                if (set.Tables[0].Rows.Count <= 0)
                {
                    return false;
                }
                for (int i = 0; i < set.Tables[0].Columns.Count; i++)
                {
                    string columnName = set.Tables[0].Columns[i].ColumnName;
                    if (set.Tables[0].Rows[0][columnName].ToString() == string.Empty)
                    {
                        return false;
                    }
                }
                return flag;
            }
            catch (Exception exception)
            {
                CLog.WriteErrLogInTrace(exception.Message);
                flag = false;
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

        public bool Exist(string keyName, string keyValue)
        {
            string format = string.Empty;
            try
            {
                format = "select count({0}) from result_line2 where {0}='{1}'";
                format = string.Format(format, keyName, keyValue);
                return (Convert.ToInt32(MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, format, null)) > 0);
            }
            catch (Exception exception)
            {
                CLog.WriteErrLogInTrace(exception.Message);
                return false;
            }
        }

        public string GetBracketByCaliperCode(string caliperCode)
        {
            try
            {
                object obj2 = null;
                string format = string.Empty;
                format = "select bracketcode from result_line2 where calipercode='{0}' order by updatetime desc limit 1";
                format = string.Format(format, caliperCode);
                obj2 = MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, format, null);
                if (obj2 != null)
                {
                    return obj2.ToString();
                }
                return "";
            }
            catch (Exception exception)
            {
                CLog.WriteErrLogInTrace(exception.Message);
                return "";
            }
        }

        public string GetBracketByCaliperOrBrakeCode(string caliperCode, string brakeCode)
        {
            try
            {
                object obj2 = null;
                string format = string.Empty;
                format = "select bracketcode from result_line2 where calipercode='{0}' or brakecode='{1}' order by updatetime desc limit 1";
                format = string.Format(format, caliperCode, brakeCode);
                obj2 = MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, format, null);
                if (obj2 != null)
                {
                    return obj2.ToString();
                }
                return "";
            }
            catch (Exception exception)
            {
                CLog.WriteErrLogInTrace(exception.Message);
                return "";
            }
        }

        public string GetBrakeByCaliperCode(string caliperCode)
        {
            try
            {
                object obj2 = null;
                string format = string.Empty;
                format = "select brakecode from result_line2 where length(brakecode)>0 and brakecode is not null and calipercode='{0}' order by updatetime desc limit 1";
                format = string.Format(format, caliperCode);
                obj2 = MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, format, null);
                if (obj2 != null)
                {
                    return obj2.ToString();
                }
                return "";
            }
            catch (Exception exception)
            {
                CLog.WriteErrLogInTrace(exception.Message);
                return "";
            }
        }

        public string GetCaliperByBrakeCode(string brakeCode)
        {
            try
            {
                object obj2 = null;
                string format = string.Empty;
                format = "select calipercode from result_line2 where length(calipercode)>0 and calipercode is not null and brakecode='{0}' order by updatetime desc limit 1";
                format = string.Format(format, brakeCode);
                obj2 = MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, format, null);
                if (obj2 != null)
                {
                    return obj2.ToString();
                }
                return "";
            }
            catch (Exception exception)
            {
                CLog.WriteErrLogInTrace(exception.Message);
                return "";
            }
        }

        public string GetFieldValueByKeyCode(string fieldName, string keyName, string keyValue)
        {
            try
            {
                object obj2 = null;
                string format = string.Empty;
                format = "select {0} from result_line2 where {1}='{2}' order by tid desc limit 1";
                format = string.Format(format, fieldName, keyName, keyValue);
                obj2 = MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, format, null);
                if (obj2 != null)
                {
                    return obj2.ToString();
                }
                return "";
            }
            catch (Exception exception)
            {
                CLog.WriteErrLogInTrace(exception.Message);
                return "";
            }
        }

        public int InsertCode(string codeName, string codeValue)
        {
            string format = string.Empty;
            try
            {
                format = "insert into result_line2({0},createtime) values ('{1}',now())";
                format = string.Format(format, codeName, codeValue);
                return MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, format, null);
            }
            catch (Exception exception)
            {
                CLog.WriteErrLogInTrace(exception.Message);
                return 0;
            }
        }

        public int MoveBrakeDataToCaliper(string brakeCode, string caliperCode)
        {
            int num11;
            int num = 0;
            int num9 = 0;
            int num10 = 0;
            string format = string.Empty;
            DataSet set = new DataSet();
            MySqlParameter[] commandParameters = null;
            try
            {
                format = "select tid,st300,st320,st332,st350,st360,st361,st290,trialproduce from result_line2 where (length(calipercode)<=0 or calipercode is null) and brakecode='{0}' order by updatetime desc limit 1";
                format = string.Format(format, brakeCode);
                set = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, format, null);
                if (set.Tables[0].Rows.Count <= 0)
                {
                    return 0;
                }
                num = Convert.ToInt32(set.Tables[0].Rows[0]["tid"]);
                if (set.Tables[0].Rows[0]["trialproduce"].ToString() != string.Empty)
                {
                    num9 = Convert.ToInt32(set.Tables[0].Rows[0]["trialproduce"]);
                }
                commandParameters = new MySqlParameter[] { new MySqlParameter("@brakecode", brakeCode), new MySqlParameter("@st300", set.Tables[0].Rows[0]["st300"]), new MySqlParameter("@st320", set.Tables[0].Rows[0]["st320"]), new MySqlParameter("@st332", set.Tables[0].Rows[0]["st332"]), new MySqlParameter("@st350", set.Tables[0].Rows[0]["st350"]), new MySqlParameter("@st360", set.Tables[0].Rows[0]["st360"]), new MySqlParameter("@st361", set.Tables[0].Rows[0]["st361"]), new MySqlParameter("@st290", set.Tables[0].Rows[0]["st290"]), new MySqlParameter("@calipercode", caliperCode) };
                if (num9 == 1)
                {
                    format = "update result_line2 set brakecode=@brakecode,st300=@st300,st320=@st320,st332=@st332,st350=@st350,st360=@st360,st361=@st361,st290=@st290,trialproduce=1,updatetime = now() where calipercode=@calipercode";
                }
                else
                {
                    format = "update result_line2 set brakecode=@brakecode,st300=@st300,st320=@st320,st332=@st332,st350=@st350,st360=@st360,st361=@st361,st290=@st290,updatetime = now() where calipercode=@calipercode";
                }
                num10 = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, format, commandParameters);
                if (num10 > 0)
                {
                    format = "delete from result_line2 where tid={0}";
                    format = string.Format(format, num);
                }
                num11 = num10;
            }
            catch (Exception exception)
            {
                CLog.WriteErrLogInTrace(exception.Message);
                num11 = 0;
            }
            finally
            {
                set.Dispose();
            }
            return num11;
        }

        public int UpdateByField(string fieldName, object fieldValue, string keyName, string keyValue)
        {
            string format = string.Empty;
            try
            {
                Type type = fieldValue.GetType();
                if (type == typeof(string))
                {
                    format = "update result_line2 set {0}='{1}',updatetime = now() where {2}='{3}'";
                }
                else
                {
                    if ((((type != typeof(int)) && (type != typeof(double))) && (type != typeof(float))) && (type != typeof(bool)))
                    {
                        throw new Exception("fieldValue的值只能为string、bool、int、double或float类型");
                    }
                    format = "update result_line2 set {0}={1},updatetime = now() where {2}='{3}'";
                }
                format = string.Format(format, new object[] { fieldName, fieldValue, keyName, keyValue });
                return MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, format, null);
            }
            catch (Exception exception)
            {
                CLog.WriteErrLogInTrace(exception.Message);
                return 0;
            }
        }

        public int UpdateByField(string fieldName, string fieldValue, int valueType, string keyName, string keyValue)
        {
            int num = 0;
            string format = string.Empty;
            try
            {
                if (valueType == 2)
                {
                    format = "update result_line2 set {0}='{1}',updatetime = now(),uploadsign = 0 where {2}='{3}'";
                }
                else if (valueType == 1)
                {
                    format = "update result_line2 set {0}={1},updatetime = now(),uploadsign = 0 where {2}='{3}'";
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

        public int UpdateDigiForceByKeyCode(string keyFieldName, string barCode, DigiForceMDL mdl)
        {
            string format = string.Empty;
            try
            {
                format = "update result_line2 set st360_xminx1={0},st360_xminy1={1},st360_xmaxx1={2},st360_xmaxy1={3},st360_yminx1={4},st360_yminy1={5},st360_ymaxx1={6},st360_ymaxy1={7} where {8}='{9}'";
                format = string.Format(format, new object[] { mdl.Xminx, mdl.Xminy, mdl.Xmaxx, mdl.Xmaxy, mdl.Yminx, mdl.Yminy, mdl.Ymaxx, mdl.Ymaxy, keyFieldName, barCode });
                CLog.WriteStationLog("ST360", format);
                return MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, format, null);
            }
            catch (Exception exception)
            {
                CLog.WriteErrLogInTrace(exception.Message);
                return 0;
            }
        }

        public bool UpdateProductNameByKeyCode(string keyFieldName, string barCode, string productType)
        {
            object obj2 = null;
            string format = string.Empty;
            string str2 = string.Empty;
            bool flag = false;
            try
            {
                format = "select productname from process_parameter where productid='{0}' limit 1";
                format = string.Format(format, productType);
                obj2 = MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, format, null);
                if (obj2 != null)
                {
                    str2 = obj2.ToString();
                }
                format = "update result_line2 set productname='{0}' where {1}='{2}'";
                format = string.Format(format, str2, keyFieldName, barCode);
                if (MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, format, null) > 0)
                {
                    flag = true;
                }
            }
            catch (Exception exception)
            {
                CLog.WriteErrLogInTrace(exception.Message);
                flag = false;
            }
            return flag;
        }

        public int UpdateResultByKeyCode(string keyFieldName, string barCode, int integrity, int valid, int result, string resultDesc)
        {
            string format = string.Empty;
            try
            {
                format = "update result_line2 set integrity={0},valid={1},result={2},resultdesc='{3}' where {4}='{5}'";
                format = string.Format(format, new object[] { integrity, valid, result, resultDesc, keyFieldName, barCode });
                return MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, format, null);
            }
            catch (Exception exception)
            {
                CLog.WriteErrLogInTrace(exception.Message);
                return 0;
            }
        }
    }
}

