﻿using LB.Web.Base.Factory;
using LB.Web.Base.Helper;
using LB.Web.Contants.DBType;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LB.Web.DB.DAL
{
    public class DALDbReportTemplate
    {
        public DataTable ExistsTemplateName(FactoryArgs args, t_String ReportTemplateName,t_BigID ReportTypeID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("ReportTemplateName", ReportTemplateName));
            parms.Add(new LBDbParameter("ReportTypeID", ReportTypeID));
            string strSQL = @"
select *
from dbo.DbReportTemplate
where rtrim(ReportTemplateName)=rtrim(@ReportTemplateName) and
        ReportTypeID = @ReportTypeID
";
            DataTable dtReturn = DBHelper.ExecuteQuery(args, strSQL, parms);
            return dtReturn;
        }

        public void Insert(FactoryArgs args,
           out t_BigID ReportTemplateID, t_String ReportTemplateName, t_DTSmall TemplateFileTime, t_ID TemplateSeq,
           t_String Description,t_Image TemplateData, t_BigID ReportTypeID,
            t_String PrinterName, t_String MachineName, t_Bool IsManualPaperType, t_String PaperType, t_Bool IsManualPaperSize,
            t_ID PaperSizeHeight, t_ID PaperSizeWidth, t_Bool IsPaperTransverse)
        {
            ReportTemplateID = new t_BigID();
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("ReportTemplateID", ReportTemplateID, true));
            parms.Add(new LBDbParameter("ReportTemplateName",  ReportTemplateName));
            parms.Add(new LBDbParameter("TemplateFileTime", TemplateFileTime));
            parms.Add(new LBDbParameter("TemplateSeq",  TemplateSeq));
            parms.Add(new LBDbParameter("Description",  Description));
            parms.Add(new LBDbParameter("TemplateData", TemplateData));
            parms.Add(new LBDbParameter("ReportTypeID",  ReportTypeID));

            parms.Add(new LBDbParameter("PrinterName", PrinterName));
            parms.Add(new LBDbParameter("MachineName", MachineName));
            parms.Add(new LBDbParameter("IsManualPaperType", IsManualPaperType));
            parms.Add(new LBDbParameter("PaperType", PaperType));
            parms.Add(new LBDbParameter("IsManualPaperSize", IsManualPaperSize));
            parms.Add(new LBDbParameter("PaperSizeHeight", PaperSizeHeight));
            parms.Add(new LBDbParameter("PaperSizeWidth", PaperSizeWidth));
            parms.Add(new LBDbParameter("IsPaperTransverse", IsPaperTransverse));
            string strSQL = @"
insert into dbo.DbReportTemplate( ReportTemplateName,ReportTemplateNameExt, TemplateFileTime,TemplateSeq,Description,TemplateData,ReportTypeID)
values( @ReportTemplateName,'.frx', @TemplateFileTime,@TemplateSeq,@Description,@TemplateData,@ReportTypeID);

select last_insert_rowid() as ReportTemplateID;

insert into dbo.DbPrinterConfig( ReportTemplateID, PrinterName, MachineName, IsManualPaperType, 
PaperType, IsManualPaperSize, PaperSizeHeight, PaperSizeWidth, IsPaperTransverse)
values(@ReportTemplateID, @PrinterName, @MachineName, @IsManualPaperType, 
@PaperType, @IsManualPaperSize, @PaperSizeHeight, @PaperSizeWidth, @IsPaperTransverse);
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
            ReportTemplateID.SetValueWithObject(parms["ReportTemplateID"].Value);
        }

        public void Update(FactoryArgs args,
           t_BigID ReportTemplateID, t_String ReportTemplateName, t_DTSmall TemplateFileTime, t_ID TemplateSeq,
           t_String Description,t_Image TemplateData,
            t_String PrinterName, t_String MachineName, t_Bool IsManualPaperType, t_String PaperType, t_Bool IsManualPaperSize,
            t_ID PaperSizeHeight, t_ID PaperSizeWidth, t_Bool IsPaperTransverse)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("ReportTemplateID", ReportTemplateID));
            parms.Add(new LBDbParameter("ReportTemplateName", ReportTemplateName));
            parms.Add(new LBDbParameter("TemplateFileTime", TemplateFileTime));
            parms.Add(new LBDbParameter("TemplateSeq", TemplateSeq));
            parms.Add(new LBDbParameter("Description", Description));
            parms.Add(new LBDbParameter("TemplateData", TemplateData));

            parms.Add(new LBDbParameter("PrinterName", PrinterName));
            parms.Add(new LBDbParameter("MachineName", MachineName));
            parms.Add(new LBDbParameter("IsManualPaperType", IsManualPaperType));
            parms.Add(new LBDbParameter("PaperType", PaperType));
            parms.Add(new LBDbParameter("IsManualPaperSize", IsManualPaperSize));
            parms.Add(new LBDbParameter("PaperSizeHeight", PaperSizeHeight));
            parms.Add(new LBDbParameter("PaperSizeWidth", PaperSizeWidth));
            parms.Add(new LBDbParameter("IsPaperTransverse", IsPaperTransverse));
            string strSQL = @"
update dbo.DbReportTemplate
set ReportTemplateName = @ReportTemplateName, 
    TemplateFileTime=@TemplateFileTime,
    TemplateSeq=@TemplateSeq,
    Description=@Description,
    TemplateData=isnull(@TemplateData,TemplateData)
where ReportTemplateID = @ReportTemplateID
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);

            LBDbParameterCollection parms1 = new LBDbParameterCollection();
            parms1.Add(new LBDbParameter("ReportTemplateID", ReportTemplateID));
            strSQL = "select 1 from dbo.DbPrinterConfig where ReportTemplateID = @ReportTemplateID";
            using (DataTable dtResult = DBHelper.ExecuteQuery(args, strSQL, parms1))
            {
                if (dtResult.Rows.Count > 0)
                {
                    strSQL = @"insert dbo.DbPrinterConfig( ReportTemplateID, PrinterName, MachineName, IsManualPaperType, 
    PaperType, IsManualPaperSize, PaperSizeHeight, PaperSizeWidth, IsPaperTransverse)
    values(@ReportTemplateID, @PrinterName, @MachineName, @IsManualPaperType, 
    @PaperType, @IsManualPaperSize, @PaperSizeHeight, @PaperSizeWidth, @IsPaperTransverse)";
                    DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
                }
                else
                {
                    strSQL = @"update dbo.DbPrinterConfig
    set PrinterName = @PrinterName,
        MachineName = @MachineName,
        IsManualPaperType = @IsManualPaperType,
        PaperType = @PaperType,
        IsManualPaperSize = @IsManualPaperSize,
        PaperSizeHeight = @PaperSizeHeight,
        PaperSizeWidth = @PaperSizeWidth,
        IsPaperTransverse = @IsPaperTransverse
    where ReportTemplateID = @ReportTemplateID";
                    DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
                }
            }
        }

        public void Delete(FactoryArgs args,
          t_BigID ReportTemplateID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("ReportTemplateID", ReportTemplateID));
            string strSQL = @"
delete dbo.DbPrinterConfig
where ReportTemplateID = @ReportTemplateID;

delete dbo.DbReportTemplate
where ReportTemplateID = @ReportTemplateID

";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
        }
    }
}
