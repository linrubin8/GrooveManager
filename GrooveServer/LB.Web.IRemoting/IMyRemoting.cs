using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LB.Web.IRemoting
{
    public delegate void RemotingEventHandler(string fax);
    public interface IMyRemoting
    {
        void SendRemoting(string fax);

        DataSet RunProcedure(int ProcedureType, string strLoginName, byte[] bSerializeValue, byte[] bSerializeDataType,
            out DataTable dtOut, out string ErrorMsg, out bool bolIsError);

        DataTable RunView(int iViewType, string strLoginName, string strFieldNames, string strWhere, string strOrderBy,
            out string ErrorMsg, out bool bolIsError);
        
        DataTable RunDirectSQL(string strLoginName, string strSQL,
           out string ErrorMsg, out bool bolIsError);

        bool ConnectServer();

        DataTable ReadClientFileInfo();

        void ReadFileByte(string strFileFullName, int iPosition, int iMaxLength, out byte[] bSplitFile);

        void ReadRegister(out bool IsRegister,out int ProductType,out DateTime DeadLine);
    }
}
