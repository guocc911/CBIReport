
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data;
using System.Text;
using System.Xml;
using MDL;
using COMM;

namespace ProductLine.Utils
{
    public class WorkSpace
    {
        #region Fields

        private string cfgFile = "";

        private string _lastProjectPath = "'";

        private int _selectIndex = 0;


        private static string documentName = "ProductLine";

        private DBInfo dbinfo=null;

   

        #endregion

        #region Properities
        //public string LastProjectPath
        //{
        //    get { return _lastProjectPath; }
        //    set { _lastProjectPath = value; }
        //}


        //public int SelectIndex
        //{
        //    get { return _selectIndex; }
        //    set { _selectIndex = value; }
        //}


        public DBInfo DBInfo 
        {
            get { return dbinfo; }
            set { dbinfo = value; }
        }



        #endregion

        public WorkSpace(string filePath)
        {
            cfgFile = Path.Combine(filePath,documentName+".cfg");
          //  devices = new List<DeviceInfo>();
            //_lastProjectPath = "";
            //_selectIndex = 0;
        }



        private void InitialPileAdapter()
        {
 
        }

        /// <summary>
        /// 加载工作空间
        /// </summary>
        /// <returns></returns>
        public bool Load()
        {
            bool ret = false;
            try
            {
                if (File.Exists(cfgFile))
                {
                    XmlDocument congfigdoc = new XmlDocument();

                    congfigdoc.Load(cfgFile);

                    //XmlNode nodes = congfigdoc.SelectSingleNode("TraceSystem/WorkSapce");

                    //foreach (XmlNode node in nodes.ChildNodes)
                    //{
                    //    switch (node.Name)
                    //    {
                    //        case "LastProject":
                    //            this._lastProjectPath = node.InnerText;
                    //            break;
                    //        case "SelectIndex":
                    //            this._selectIndex = Convert.ToInt32(node.InnerText);
                    //            break;
                    //        default:
                    //            break;
                    //    }
                    //}


                    XmlNode nodes = congfigdoc.SelectSingleNode(documentName);

                    DBInfo info=new DBInfo();

                    foreach (XmlNode node in nodes.ChildNodes)
                    {
                        switch (node.Name)
                        {

                            case "DBConfig":
                                foreach(XmlNode item in node.ChildNodes)
                                {
                                    switch (item.Name)
                                    {
                                        case "Server":
                                            info.Server = item.InnerText;
                                            break;
                                        case "Name":
                                            info.DBName = item.InnerText;
                                            break;
                                        case "User":
                                            info.User = item.InnerText;
                                            break;
                                        case "Password":
                                            info.PWD = item.InnerText;
                                            break;

                                        default:
                                            break;
                                    }
                                }
                                break;

                           
                            default:
                                break;
                            
                        }
                    }
                    this.dbinfo = info;

                    //this.dbinfo = DBInfo.DeCodeInfo(info);

                }
                else
                {
                    WriteFile();
                }
            }
            catch
            {
                throw;
            }
            return ret;
        }


        /// <summary>
        /// 保存工作空间
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            try
            {
                bool ret = false;

                ret= WriteFile();

                return true;
            }
            catch
            {
                throw;
            }
  
        }

        /// <summary>
        /// 写配置文件
        /// </summary>
        private bool WriteFile()
        {
            bool ret = false;
            try
            {

                XmlWriterSettings setting = new XmlWriterSettings();
                setting.Encoding = System.Text.Encoding.UTF8;
                setting.Indent = true;
                setting.IndentChars = "  ";

                if (File.Exists(cfgFile))
                {
                    File.Delete(cfgFile);
                }


                using (XmlWriter xtr = XmlWriter.Create(cfgFile, setting))
                {
                    xtr.WriteStartDocument();
                    xtr.WriteStartElement(documentName);
                    xtr.WriteStartElement("WorkSapce");

                    //xtr.WriteElementString("LastProject", this._lastProjectPath);
                    //xtr.WriteElementString("SelectIndex", this._selectIndex.ToString());


                    xtr.WriteEndElement();

                     //数据库配置信息
                    if (dbinfo == null)
                        dbinfo = new Utils.DBInfo();

                        //DBInfo  info = DBInfo.EnCodeInfo(this.dbinfo);
                        xtr.WriteStartElement("DBConfig");
                        xtr.WriteElementString("Server", dbinfo.Server);
                        xtr.WriteElementString("User", dbinfo.User);
                        xtr.WriteElementString("Name", dbinfo.DBName);
                        xtr.WriteElementString("Password", dbinfo.PWD);
                        xtr.WriteEndElement();



                 
                    xtr.WriteEndElement();
                    xtr.WriteEndDocument();
                    xtr.Flush();

                }

                ret = true;
            }
            catch
            {
            }
            return ret;
        }



    }
}
