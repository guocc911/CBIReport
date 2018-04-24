
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceController;
using System.IO;
using DAL;
//using SQLiteDAL;
using COMM;
using MDL;
using DAL;

namespace CBIReportPanal
{
    public partial class ReportClientForm
    {
        public static string ProjectDBName = "cbireport.db";

        //public bool loadDB()
        //{
        //    try
        //    {
        //        FileInfo info = new FileInfo(ApplicationPath);

        //        string dbFile = info.Directory.FullName + "\\" + ProjectDBName;


        //    if (!File.Exists(dbFile))
        //        return false;
            

        //    SQLiteDBHelper.ConnString = dbFile;

        //    return true;

        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);

        //    }
           
        //    return false;
 
        //}



        private bool LoadDB()
        {
            bool ret = false;
            try
            {
                CLog.WriteSysLog(BaseVariable.DBConnStr);

                ret = MySqlDBHelper.ModifyConnectionInfo(BaseVariable.DBConnStr);

                CLog.WriteSysLog(ret.ToString());

                return ret;

            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message.ToString());

            }

            return false;
        }

        /// <summary>
        /// 加载新计划
        /// </summary>
        /// <returns></returns>
        public static PlinePlanMDL ReloadNewPlan(string pId)
        {

            PlinePlanMDL mdl = null;

            try
            {

                PlinePlanDAL dal = new PlinePlanDAL();

                if (dal.PlanExists(pId)<=0)
                {

                     mdl = PlinePlanMDL.BuildDefualtPlan(Convert.ToInt32(BaseVariable.LineID),
                                                                     DateTime.Now);
                    if (dal.AddPlinePlan(mdl)>0)
                    {
                        return mdl;
                    }

                    return null;

                }
                else
                {
                    mdl = dal.GetPlanInfo(pId);

                    return mdl;
                }

                return null;

            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message.ToString());

            }

            return null;
        }
    }
}
