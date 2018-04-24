using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace COMM
{
    public static class Utils
    {


        /// <summary>
        /// 获取分页西信息
        /// </summary>
        /// <param name="count">总的记录数量</param>
        /// <param name="offset">页面偏移量</param>
        /// <param name="pagesize">页面大小</param>
        /// <returns></returns>
        public static int[] GetSplitPage(int count, int offset, int pagesize)
        {
            int[] result = new int[2];

            if (null == offset || offset < 0)
            {
                offset = 0;
            }
            if (null == pagesize || pagesize < 0)
            {
                pagesize = 0;
            }

            int rowsize = 0, tlboffset = 0;

            if (pagesize > 0)
            {

                rowsize = count / pagesize;

                //获取偏移量
                tlboffset = offset * pagesize;

            }
            else
            {

                //指定页面大小的偏移量
                offset = 0;
                pagesize = count;
            }

            result[0] = tlboffset;
            result[1] = pagesize;

            return result;

        }



        public static bool CheckCode(DataRow dataRow, string content)
        {
            try
            {
                if (dataRow[content] != null)
                    return true;


                return false;
            }
            catch
            {
            	return false;
            }
        }
       
    }
}
