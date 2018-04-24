using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDL
{
    public class UserMDL
    {

        private string name;

        private string password;

        private int  level;

        private string depno;


        #region Properties

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public string Password
        {
            get { return password; }
            set { password = value; }
        }


        public int Level
        {
            get { return level; }
            set { level = value; }
        }


        public string DeparmentNO
        {
            get { return depno; }
            set { depno = value; }
        }
        #endregion 
    }
}
