using MDL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;



namespace MDL
{
 
    public class XmlHelper
    {
        private string path = AppDomain.CurrentDomain.BaseDirectory;
        private XmlDocument xmlDoc = new XmlDocument();

        public XmlHelper(string fileName)
        {
            this.path = this.path + fileName;
            this.xmlDoc.Load(this.path);
        }

        public void DeleteAllNode(string nodePath)
        {
            XmlNode node = this.xmlDoc.SelectSingleNode(nodePath);
            for (int i = node.ChildNodes.Count - 1; i >= 0; i--)
            {
                node.RemoveChild(node.ChildNodes[i]);
            }
            this.xmlDoc.Save(this.path);
        }

        public void Insert(string nodePath, string node, Hashtable hashTable)
        {
            XmlNode node2 = this.xmlDoc.SelectSingleNode(nodePath);
            XmlElement newChild = this.xmlDoc.CreateElement(node);
            foreach (string str in hashTable.Keys)
            {
                newChild.SetAttribute(str, Convert.ToString(hashTable[str]));
            }
            node2.AppendChild(newChild);
            this.xmlDoc.Save(this.path);
        }

        public IOLogikMDL SelectIOLogik(string nodePath)
        {
            XmlNode node = this.xmlDoc.SelectSingleNode(nodePath);
            return new IOLogikMDL { IP = node.Attributes["IP"].Value, Port = ushort.Parse(node.Attributes["Port"].Value), ConnTimeOut = uint.Parse(node.Attributes["ConnTimeOut"].Value), Password = node.Attributes["Password"].Value };
        }

        public OPCServerMDL SelectOPCServer(string nodePath)
        {
            XmlNode node = this.xmlDoc.SelectSingleNode(nodePath);
            return new OPCServerMDL { OPCIP = node.Attributes["OPCIP"].Value, OPCName = node.Attributes["OPCName"].Value, GroupName = node.Attributes["GroupName"].Value };
        }

        public List<PLCDataMDL> SelectPLCDataList(string nodePath)
        {
            List<PLCDataMDL> list = new List<PLCDataMDL>();
            XmlNodeList childNodes = this.xmlDoc.SelectSingleNode(nodePath).ChildNodes;
            int num = 0;
            foreach (XmlNode node2 in childNodes)
            {
                PLCDataMDL item = new PLCDataMDL();
                if (node2.LocalName == "PLCData")
                {
                    item.UniqueID = ++num;
                    item.ItemID = node2.Attributes["ItemID"].Value;
                    item.StationID = node2.Attributes["StationID"].Value;
                    item.DBFieldName = node2.Attributes["DBFieldName"].Value;
                    if (node2.Attributes["DBFieldType"].Value != string.Empty)
                    {
                        item.DBFieldType = Convert.ToInt32(node2.Attributes["DBFieldType"].Value);
                    }
                    else
                    {
                        item.DBFieldType = 0;
                    }
                    if (node2.Attributes["DecPoint"].Value != string.Empty)
                    {
                        item.DecPoint = Convert.ToInt32(node2.Attributes["DecPoint"].Value);
                    }
                    else
                    {
                        item.DecPoint = 0;
                    }
                    item.IsKey = Convert.ToBoolean(node2.Attributes["IsKey"].Value);
                    list.Add(item);
                }
            }
            return list;
        }

        public List<PrinterMDL> SelectPrinterList(string nodePath)
        {
            PrinterMDL rmdl;
            List<PrinterMDL> list = new List<PrinterMDL>();
            XmlNodeList childNodes = this.xmlDoc.SelectSingleNode(nodePath + "/L1/PrinterList").ChildNodes;
            foreach (XmlNode node2 in childNodes)
            {
                rmdl = new PrinterMDL();
                if (node2.LocalName == "Printer")
                {
                    rmdl.Name = node2.Attributes["Name"].Value;
                    rmdl.IPAddress = node2.Attributes["IPAddress"].Value;
                    rmdl.Type = Convert.ToInt32(node2.Attributes["Type"].Value);
                    rmdl.CodeType = Convert.ToInt32(node2.Attributes["CodeType"].Value);
                    rmdl.CountKey = node2.Attributes["CountKey"].Value;
                    rmdl.LineID = "L1";
                    list.Add(rmdl);
                }
            }
            childNodes = this.xmlDoc.SelectSingleNode(nodePath + "/L2/PrinterList").ChildNodes;
            foreach (XmlNode node2 in childNodes)
            {
                rmdl = new PrinterMDL();
                if (node2.LocalName == "Printer")
                {
                    rmdl.Name = node2.Attributes["Name"].Value;
                    rmdl.IPAddress = node2.Attributes["IPAddress"].Value;
                    rmdl.Type = Convert.ToInt32(node2.Attributes["Type"].Value);
                    rmdl.CodeType = Convert.ToInt32(node2.Attributes["CodeType"].Value);
                    rmdl.CountKey = node2.Attributes["CountKey"].Value;
                    rmdl.LineID = "L2";
                    list.Add(rmdl);
                }
            }
            return list;
        }

        public List<string> SelectRealDataSQL(string nodePath)
        {
            List<string> list = new List<string>();
            XmlNodeList childNodes = this.xmlDoc.SelectSingleNode(nodePath).ChildNodes;
            foreach (XmlNode node2 in childNodes)
            {
                string[] strArray = node2.ChildNodes[3].InnerText.Split(new char[] { '%' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (((i % 2) == 1) && !list.Contains(strArray[i]))
                    {
                        list.Add(strArray[i]);
                    }
                }
            }
            return list;
        }

        public List<BarCodeScanMDL> SelectScannerList(string nodePath)
        {
            List<BarCodeScanMDL> list = new List<BarCodeScanMDL>();
            XmlNodeList childNodes = this.xmlDoc.SelectSingleNode(nodePath).ChildNodes;
            foreach (XmlNode node2 in childNodes)
            {
                BarCodeScanMDL item = new BarCodeScanMDL();
                if (node2.LocalName == "Scanner")
                {
                    item.StationID = node2.Attributes["StationID"].Value;
                    item.ComPort = int.Parse(node2.Attributes["ComPort"].Value);
                    item.ComSet = node2.Attributes["ComSet"].Value;
                    item.LightIOPort = int.Parse(node2.Attributes["LightIOPort"].Value);
                    item.LineType = int.Parse(node2.Attributes["LineType"].Value);
                    item.BarCodeItemID = node2.Attributes["BarCodeItemID"].Value;
                    item.EnableTraceSysItemID = node2.Attributes["EnableTraceSysItemID"].Value;
                    list.Add(item);
                }
            }
            return list;
        }

        public string SelectValue(string nodePath)
        {
            return this.xmlDoc.SelectSingleNode(nodePath).InnerText;
        }

        public void UpdateAttribute(string nodePath, string attribute, string value)
        {
            XmlElement element = (XmlElement) this.xmlDoc.SelectSingleNode(nodePath);
            if ((element.Attributes != null) || (element.Attributes.Count != 0))
            {
                element.SetAttribute(attribute, value);
            }
            this.xmlDoc.Save(this.path);
        }

        public void UpdateInnerText(string nodePath, string value)
        {
            this.xmlDoc.SelectSingleNode(nodePath).InnerText = value;
            this.xmlDoc.Save(this.path);
        }
    }
}

