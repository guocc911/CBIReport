using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COMM;

namespace ProductLine.Utils
{
    public class DBInfo
    {

        private string _server;

        private string _dbname;

        private string _user;

        private string _password;


        public string Server
        {
            get { return _server; }
            set { _server = value; }
        }




        public string DBName
        {
            get { return _dbname; }
            set { _dbname = value; }
        }

        public string User
        {
            get { return _user; }
            set { _user = value; }
        }

        public string PWD
        {
            get { return _password; }
            set { _password = value; }
        }


        public DBInfo()
        {
            _server = "localhost";
            _dbname = "tracedb";
            _user = "root";
            _password = "123456";
        }

        //
        public static DBInfo EnCodeInfo(DBInfo info)
        {
            DBInfo config = new DBInfo();

            DES des = new DES();

            config.Server =info.Server;// des.MD5Encrypt(info.Server, des.GenerateKey());
            config.User = des.MD5Encrypt(info.User,des.GenerateKey());
            config.DBName = des.MD5Encrypt(info.DBName, des.GenerateKey());
            config.PWD = des.MD5Encrypt(info.PWD, des.GenerateKey());

            return config;
 
        }


        public static DBInfo DeCodeInfo(DBInfo info)
        {
            DBInfo config = new DBInfo();

            DES des = new DES();

            config.Server = info.Server;// des.MD5Encrypt(info.Server, des.GenerateKey());
            config.User = des.MD5Decrypt(info.User, des.GenerateKey());
            config.DBName = des.MD5Decrypt(info.DBName, des.GenerateKey());
            config.PWD = des.MD5Decrypt(info.PWD, des.GenerateKey());

            return config;
        
        }
    }
}
