using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using LB.Web.Contants.DBType;
using LB.Web.Base.Base.Helper;
using System.Data.SQLite;
using System.IO;

namespace LB.Web.Base.Helper
{
	public class DBMSSQL: IDBBase
    {
		DbCommand IDBBase.CreateCommand()
        {
            SQLiteCommand cmd = new SQLiteCommand();
			cmd.CommandTimeout = CommandTimeout;
			return cmd;
        }

		DbConnection IDBBase.CreateConnection( string dbName )
        {
			string strConnectionString = BulidConnectString( dbName );
			return new SQLiteConnection( strConnectionString );
        }

		DbDataAdapter IDBBase.CreateDataAdapter()
        {
            return new SQLiteDataAdapter();
        }

		DbParameter IDBBase.CreateParameter( LBDbParameter dbParm )
        {
			int iScale = LBDBType.GetSqlDbTypeScale( dbParm.LBDBType);
			if( iScale < 0 )
			{
				iScale = 0;
			}

            SQLiteParameter parameter = new SQLiteParameter("@" + dbParm.ParameterName, LBDBType.GetSqlDbType(dbParm.LBDBType));
            parameter.Value = dbParm.Value == null ? DBNull.Value : dbParm.Value;
            return parameter;


    //        return new SQLiteParameter(
				//"@" + dbParm.ParameterName,
    //            LBDBType.GetSqlDbType( dbParm.LBDBType ),
    //            LBDBType.GetSqlDbTypeSize( dbParm.LBDBType),
				//dbParm.Direction,
				//true,
    //            LBDBType.GetSqlDbTypePrecision( dbParm.LBDBType),
				//(byte)iScale,
				//"", 
				//DataRowVersion.Current,
				//dbParm.Value == null ? DBNull.Value : dbParm.Value );
        }

		private Dictionary<string, bool> mdictSnapshot = new Dictionary<string, bool>();
		bool IDBBase.SnapshotSupported( string dbName )
		{
			string strKey = DBPath.ToLower() + ";" + dbName.ToLower();
			if( mdictSnapshot.ContainsKey( strKey ) )
			{
				return mdictSnapshot[strKey];
			}
			else
			{
				bool bStatus = false;
				string strSQL = @"if exists(select 1 from sysobjects where name = 'sysdatabases' and xtype = 'V' )
begin
	if exists( select 1 from sys.databases where name = '{0}' and snapshot_isolation_state_desc = 'ON' )
		select 1 as SnapshotStatus
	else
		select 0 as SnapshotStatus
end
else
	select 0 as SnapshotStatus";

				strSQL = string.Format( strSQL, dbName );

				using( SQLiteDataAdapter da = new SQLiteDataAdapter( strSQL, BulidConnectString_Master() ) )
				{
					using( DataTable dt = new DataTable() )
					{
						da.Fill( dt );
						if( dt.Rows.Count > 0 )
						{
							bStatus = Convert.ToBoolean( Convert.ToInt32( dt.Rows[0]["SnapshotStatus"] ) );
						}
					}
				}

				mdictSnapshot.Add( strKey, bStatus );
				return bStatus;
			}
		}

		#region -- InitSettings --

		//public const string MC_strConnection = "server={0};database={1};Integrated Security=True;";
  //      public const string MC_strConnectionByUser = "server={0};database={1};User ID={2};Password={3};";

		#region -- 配置值 --

		private static int miCommandTimeout;
		//private static string mstrUserID = "";
		//private static string mstrPassword = "";
		private static string mstrDBPath = "";
		private static string mstrCtrlDBName = "";
		private static bool mbLoginSecure = false;

		private static int CommandTimeout
		{
			get
			{
				return miCommandTimeout;
			}
		}

		//private static string UserID
		//{
		//	get
		//	{
		//		return mstrUserID;
		//	}
		//}

		//private static string Password
		//{
		//	get
		//	{
		//		return mstrPassword;
		//	}
		//}

		private static string DBPath
		{
			get
			{
				return mstrDBPath;
			}
		}

        private static string CtrlDBName
        {
            get
            {
                return mstrCtrlDBName;
            }
        }

        //private static bool LoginSecure
        //{
        //	get
        //	{
        //		return mbLoginSecure;
        //	}
        //}

        public static void InitSettings(
			int commandTimeout, string dbPath,string strCtrlDBName)
		{
			miCommandTimeout = commandTimeout;
            mstrDBPath = dbPath;
            //mbLoginSecure = bLoginSecure;
            //mstrUserID = strUser;
            //mstrPassword = strPassword;
            mstrCtrlDBName = strCtrlDBName;
		}

		#endregion -- 配置值 --

		private static string GetConnectString( string dbPath, string dbName )
		{
			//string strResult = "";
			//if( LoginSecure )
			//{
			//	strResult = string.Format( MC_strConnection, dbPath, dbName );
			//}
			//else
			//{
			//	strResult = string.Format( MC_strConnectionByUser, dbPath, dbName, UserID, Password );
			//}

   //         LogHelper.WriteLog(strResult);


            return "Data Source=" + Path.Combine(dbPath, dbName);
		}

		public static string BulidConnectString_Control()
		{
			return GetConnectString( DBPath, CtrlDBName );
		}

        public static string BulidConnectString_Master()
        {
            return GetConnectString(DBPath, "master");
        }

        public static string BulidConnectString( string DataBaseName )
		{
			return GetConnectString(DBPath, DataBaseName );
		}

		#endregion -- InitSettings --
	}
}
