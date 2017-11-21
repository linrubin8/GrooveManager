using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SQLite;

namespace LB.Web.Contants.DBType
{
	public interface ILBDbType 
	{
		object Value
		{
			get;
			set;
		}

		void SetValueWithObject( object value );

		string DBTypeName
		{
			get;
		}
	}

    public class LBDBType
    {
        public const string t_BigID = "t_BigID";
        public const string t_Bool = "t_Bool";
        public const string t_DTSmall = "t_DTSmall";
        public const string t_Float = "t_Float";
        public const string t_ID = "t_ID";
        public const string t_String = "t_String";
        public const string t_nText = "t_nText";
        public const string t_Decimal = "t_Decimal";
        public const string t_SmallID = "t_SmallID";
        public const string t_Byte = "t_Byte";
        public const string t_Image = "t_Image";
        public const string t_Table = "t_Table";
        public const string t_Object = "t_Object";

        public static DbType GetSqlDbType( string strDbTypeName )
		{
			switch( strDbTypeName )
			{
				case LBDBType.t_BigID:
					return DbType.Int64;

				case LBDBType.t_ID:
                    return DbType.Int32;

                case LBDBType.t_String:
                    return DbType.String;

                case LBDBType.t_nText:
					return DbType.String;

                case LBDBType.t_Decimal:
                    return DbType.Decimal;

                case LBDBType.t_Float:
					return DbType.Decimal;
                    
				case LBDBType.t_DTSmall:
					return DbType.DateTime;

				case LBDBType.t_SmallID:
					return DbType.Int16;

				case LBDBType.t_Bool:
					return DbType.Boolean;

				case LBDBType.t_Image:
					return DbType.Binary;

                case LBDBType.t_Object:
                    return DbType.Object;

                case LBDBType.t_Byte:
                    return DbType.Byte;

                default:
					return DbType.String;
			}
		}

        public static ILBDbType GetILBDbType(string strDBTypeName)
        {
            switch (strDBTypeName)
            {
                case LBDBType.t_BigID:
                    return new t_BigID();
                    break;
                case LBDBType.t_Bool:
                    return new t_Bool();
                    break;
                case LBDBType.t_DTSmall:
                    return new t_DTSmall();
                    break;
                case LBDBType.t_Float:
                    return new t_Float();
                    break;
                case LBDBType.t_ID:
                    return new t_ID();
                    break;
                case LBDBType.t_String:
                    return new t_String();
                    break;
                case LBDBType.t_nText:
                    return new t_nText();
                    break;
                case LBDBType.t_Decimal:
                    return new t_Decimal();
                    break;
                case LBDBType.t_SmallID:
                    return new t_SmallID();
                    break;
                case LBDBType.t_Byte:
                    return new t_Byte();
                    break;
                case LBDBType.t_Image:
                    return new t_Image();
                    break;
                case LBDBType.t_Table:
                    return new t_Table();
                    break;
                case LBDBType.t_Object:
                    return new t_Object();
                    break;
            }
            return new t_String();
        }
        
        public static int GetSqlDbTypeSize(string strDBTypeName)
        {
            switch (strDBTypeName)
            {
                case LBDBType.t_String:
                    return 2000;
                case LBDBType.t_DTSmall:
                    return 100;
                case LBDBType.t_Float:
                case LBDBType.t_Decimal:
                    return 100;
                case LBDBType.t_ID:
                    return 100;
                case LBDBType.t_BigID:
                    return 100;
                case LBDBType.t_Byte:
                    return 10;
                case LBDBType.t_Bool:
                    return 1;
                case LBDBType.t_Object:
                    return 2000;
                case LBDBType.t_nText:
                    return 5;
                default:
                    return int.MaxValue;
            }
        }

        public static byte GetSqlDbTypePrecision(string strDBTypeName)
        {
            switch (strDBTypeName)
            {
                case LBDBType.t_BigID:
                case LBDBType.t_Bool:
                case LBDBType.t_Float:
                case LBDBType.t_ID:
                case LBDBType.t_Decimal:
                case LBDBType.t_SmallID:
                case LBDBType.t_Byte:
                    return 10;
                default:
                    return 0;
            }
        }

        public static byte GetSqlDbTypeScale(string strDBTypeName)
        {
            switch (strDBTypeName)
            {
                case LBDBType.t_Decimal:
                case LBDBType.t_Float:
                    return 4;
                default:
                    return 0;
            }
        }
    }
}
