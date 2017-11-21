using LB.Web.Base.Base.Helper;
using LB.Web.Base.Factory;
using LB.Web.Base.Helper;
using LB.Web.Contants.DBType;
using LB.Web.SM.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace LB.Web.SM.BLL
{
    public class BLLSalesCarWeightLog : IBLLFunction
    {
        private DALSalesCarWeightLog _DALSalesCarWeightLog = null;
        public BLLSalesCarWeightLog()
        {
            _DALSalesCarWeightLog = new DAL.DALSalesCarWeightLog();

        }

        public override string GetFunctionName(int iFunctionType)
        {
            string strFunName = "";
            switch (iFunctionType)
            {
                case 14900:
                    strFunName = "Insert";
                    break;

                case 14901:
                    strFunName = "UpdateSteadyTime";
                    break;

                case 14902:
                    strFunName = "UpdateOutTime";
                    break;

                case 14903:
                    strFunName = "GetCameraImage";
                    break;

            }
            return strFunName;
        }

        public void Insert(FactoryArgs args, out t_BigID WeightLogID, t_DTSmall InWeightTime,
            t_Image CameraBuffer,t_Image ScreenBuffer)
        {
            WeightLogID = new t_BigID();
            _DALSalesCarWeightLog.Insert(args, out WeightLogID);
            SaveCameraImage(args, WeightLogID, new t_ID(0), CameraBuffer, ScreenBuffer);
        }

        public void UpdateSteadyTime(FactoryArgs args, t_BigID WeightLogID,
            t_Image CameraBuffer, t_Image ScreenBuffer)
        {
            _DALSalesCarWeightLog.UpdateSteadyTime(args, WeightLogID);
            SaveCameraImage(args, WeightLogID, new t_ID(1), CameraBuffer, ScreenBuffer);
        }

        public void UpdateOutTime(FactoryArgs args, t_BigID WeightLogID,
            t_Image CameraBuffer, t_Image ScreenBuffer)
        {
            _DALSalesCarWeightLog.UpdateOutTime(args, WeightLogID);
            SaveCameraImage(args, WeightLogID, new t_ID(2), CameraBuffer, ScreenBuffer);
        }

        public void SaveCameraImage(FactoryArgs args, t_BigID WeightLogID,t_ID CarWeightStatus,
            t_Image CameraBuffer, t_Image ScreenBuffer)
        {
            try
            {
                string strDatePath = GetPicturePath(DateTime.Now);

                if (CameraBuffer.Value != null)
                {
                    string strImagePath = Path.Combine(strDatePath, WeightLogID.Value.ToString() + "_Image_Camera_"+ CarWeightStatus .Value.ToString()+ ".jpg");
                    CommonHelper.SaveFile(strImagePath, CameraBuffer.Value);
                }
                if (ScreenBuffer.Value != null)
                {
                    string strImagePath = Path.Combine(strDatePath, WeightLogID.Value.ToString() + "_Image_Screen_" + CarWeightStatus.Value.ToString() + ".jpg");
                    CommonHelper.SaveFile(strImagePath, ScreenBuffer.Value);
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private string GetPicturePath( DateTime dtDate)
        {
            string strPath = AppDomain.CurrentDomain.BaseDirectory;
            string strCameraPath = Path.Combine(strPath, "LBCameraPicture");
            if (!Directory.Exists(strCameraPath))
            {
                Directory.CreateDirectory(strCameraPath);
            }

            string strPicFile = "WeightLog";
            string strInBillPath = Path.Combine(strCameraPath, strPicFile);
            if (!Directory.Exists(strInBillPath))
            {
                Directory.CreateDirectory(strInBillPath);
            }
            string strDatePath = Path.Combine(strInBillPath, dtDate.ToString("yyyy-MM-dd"));
            if (!Directory.Exists(strDatePath))
            {
                Directory.CreateDirectory(strDatePath);
            }
            return strDatePath;
        }

        public void GetCameraImage(FactoryArgs args, t_BigID WeightLogID,
            out t_Image InWeightCamera, out t_Image InWeightScreen,
            out t_Image SteadyWeightCamera, out t_Image SteadyWeightScreen,
            out t_Image OutWeightCamera, out t_Image OutWeightScreen)
        {
            InWeightCamera = new t_Image();
            InWeightScreen = new t_Image();
            SteadyWeightCamera = new t_Image();
            SteadyWeightScreen = new t_Image();
            OutWeightCamera = new t_Image();
            OutWeightScreen = new t_Image();

            t_DTSmall InWeightTime = new t_DTSmall();
            t_DTSmall SteadyWeightTime = new t_DTSmall();
            t_DTSmall OutWeightTime = new t_DTSmall();
            using (DataTable dtBill = _DALSalesCarWeightLog.GetSalesCarWeightLog(args, WeightLogID))
            {
                if (dtBill.Rows.Count > 0)
                {
                    DataRow drBill = dtBill.Rows[0];
                    InWeightTime.SetValueWithObject(drBill["InWeightTime"]);
                    SteadyWeightTime.SetValueWithObject(drBill["SteadyWeightTime"]);
                    OutWeightTime.SetValueWithObject(drBill["OutWeightTime"]);
                }
            }

            //读取入场图片
            if (InWeightTime.Value != null)
            {
                string strInPath = GetPicturePath( (DateTime)InWeightTime.Value);
                string strPathImg1 = Path.Combine(strInPath, WeightLogID.Value.ToString() + "_Image_Camera_0.jpg");
                string strPathImg2 = Path.Combine(strInPath, WeightLogID.Value.ToString() + "_Image_Screen_0.jpg");

                if (File.Exists(strPathImg1))
                {
                    InWeightCamera.SetValueWithObject(CommonHelper.ReadFile(strPathImg1));
                }
                if (File.Exists(strPathImg2))
                {
                    InWeightScreen.SetValueWithObject(CommonHelper.ReadFile(strPathImg2));
                }
            }

            if (SteadyWeightTime.Value != null)
            {
                string strInPath = GetPicturePath((DateTime)SteadyWeightTime.Value);
                string strPathImg1 = Path.Combine(strInPath, WeightLogID.Value.ToString() + "_Image_Camera_1.jpg");
                string strPathImg2 = Path.Combine(strInPath, WeightLogID.Value.ToString() + "_Image_Screen_1.jpg");

                if (File.Exists(strPathImg1))
                {
                    SteadyWeightCamera.SetValueWithObject(CommonHelper.ReadFile(strPathImg1));
                }
                if (File.Exists(strPathImg2))
                {
                    SteadyWeightScreen.SetValueWithObject(CommonHelper.ReadFile(strPathImg2));
                }
            }

            if (OutWeightTime.Value != null)
            {
                string strInPath = GetPicturePath((DateTime)OutWeightTime.Value);
                string strPathImg1 = Path.Combine(strInPath, WeightLogID.Value.ToString() + "_Image_Camera_2.jpg");
                string strPathImg2 = Path.Combine(strInPath, WeightLogID.Value.ToString() + "_Image_Screen_2.jpg");

                if (File.Exists(strPathImg1))
                {
                    OutWeightCamera.SetValueWithObject(CommonHelper.ReadFile(strPathImg1));
                }
                if (File.Exists(strPathImg2))
                {
                    OutWeightScreen.SetValueWithObject(CommonHelper.ReadFile(strPathImg2));
                }
            }
        }
    }
}
