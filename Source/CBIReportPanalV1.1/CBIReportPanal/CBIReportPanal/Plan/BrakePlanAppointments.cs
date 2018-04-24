using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syd.ScheduleControls.Data;
using MDL;


namespace CBIReportPanal
{
    public class BrakePlanAppointments:Appointment
    {

        private int _tid;

        private int _planNum;

        private ProductionPlanMDL _mdl;

        public int TID
        {
            get { return _tid; }
            set { _tid = value; }
        }

        public int PlanNum
        {
            get { return _planNum; }
            set { _planNum = value; }
        }

        public ProductionPlanMDL MDL
        {
            get { return _mdl; }
            set { _mdl = value; }
        }


    }
}
