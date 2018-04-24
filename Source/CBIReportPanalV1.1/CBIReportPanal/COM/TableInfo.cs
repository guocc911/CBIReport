using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace COMM

{
    /// <summary>
    /// 表信息
    /// </summary>
    public class TableInfo
    {

        private int count = 0;

        private int curindex = 0;

        private int pageSize = 0;

        private int selectedPage = 0;

        /// <summary>
        /// 电桩总数
        /// </summary>
        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        /// <summary>
        /// 选择的页号
        /// </summary>
        public int SelectedIndex
        {
            get { return curindex; }
            set { curindex = value; }
        }

        /// <summary>
        /// 选择页面
        /// </summary>
        public int SelectedPage
        {
            get { return selectedPage; }
            set { selectedPage = value; }
        }

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }

        }



        public int PageNum
        {
            get
            {
                if (count <= 0 && pageSize <= 0)
                    return 0;

                int ret = count / pageSize;

                return ret;
            }
        }

    }
}
