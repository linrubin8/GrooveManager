﻿using LB.Web.Base.Base.Helper;
using LB.Web.Base.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace LB.Web.MI.BLL.Factory
{
    public class AssemblyStart
    {
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
                case 20100:
                case 20101:
                case 20102:
                    args.BLLFunction = new BLLDBItemType();
                    break;

                case 20200:
                case 20201:
                case 20202:
                    args.BLLFunction = new BLLDBUOM();
                    break;

                case 20300:
                case 20301:
                case 20302:
                    args.BLLFunction = new BLLDBItemBase();
                    break;

                case 13400:
                case 13401:
                case 13402:
                    args.BLLFunction = new BLLDbCustomer();
                    break;

                case 13500:
                case 13501:
                case 13502:
                case 13503:
                    args.BLLFunction = new BLLDbCar();
                    break;

                case 20400:
                    args.BLLFunction = new BLLDbCarWeight();
                    break;

                case 14600:
                case 14601:
                case 14602:
                    args.BLLFunction = new BLLDbBank();
                    break;

                case 20600:
                case 20601:
                case 20602:
                    args.BLLFunction = new BLLDbSupplier();
                    break;
            }
        }
    }
}
