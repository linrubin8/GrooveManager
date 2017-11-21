using LB.Web.Base.Base.Helper;
using LB.Web.Base.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace LB.Web.SM.BLL.Factory
{
    public class AssemblyStart
    {
        System.Timers.Timer mtimer;
        public AssemblyStart()
        {
            DBHelper.GetBLLObjectMethodEevent += DBHelper_GetBLLObjectMethodEevent;
        }

        private void DBHelper_GetBLLObjectMethodEevent(Base.Base.Factory.GetBLLObjectEventArgs args)
        {
            int iSPType = args.SPType;
            if (iSPType == 0 || args.BLLFunction != null)
            {
                return;
            }

            switch (iSPType)
            {
                case 14100:
                case 14101:
                case 14102:
                case 14103:
                case 14104:
                case 14105:
                case 14106:
                case 14107:
                case 14108:
                case 14109:
                case 14110:
                case 14111:
                case 14112:
                case 14113:
                case 14114:
                case 14115:
                case 14116:
                    args.BLLFunction = new BLLSaleCarInOutBill();
                    break;

                case 14900:
                case 14901:
                case 14902:
                case 14903:
                    args.BLLFunction = new BLLSalesCarWeightLog();
                    break;
            }
        }
    }
}
