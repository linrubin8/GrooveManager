using LB.Web.Base.Factory;
using LB.Web.Base.Helper;
using LB.Web.Contants.DBType;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace LB.Web.DB.DAL
{
    public class DALDbCard
    {
        public void Insert(FactoryArgs args, out t_BigID CardID, t_String CardCode, t_String CardName)
        {
            CardID = new t_BigID();
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CardID", CardID, true));
            parms.Add(new LBDbParameter("CardCode", CardCode));
            parms.Add(new LBDbParameter("CardName", CardName));
            parms.Add(new LBDbParameter("ChangeBy", new t_String(args.LoginName)));

            string strSQL = @"
insert into DbCard( CardCode, CardName, ChangeBy, ChangeTime)
values( @CardCode, @CardName,@ChangeBy,datetime('now','localtime'));

select last_insert_rowid() as CardID;
";
            if (args.DBType == 1)
            {
                strSQL = @"
insert into DbCard( CardCode, CardName, ChangeBy, ChangeTime)
values( @CardCode, @CardName,@ChangeBy,getdate()

select @@identity as CardID
";
            }
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
            CardID.Value = Convert.ToInt64(parms["CardID"].Value);
        }

        public void Update(FactoryArgs args, t_BigID CardID, t_String CardCode, t_String CardName)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CardID", CardID));
            parms.Add(new LBDbParameter("CardCode", CardCode));
            parms.Add(new LBDbParameter("CardName", CardName));
            parms.Add(new LBDbParameter("ChangeBy", new t_String(args.LoginName)));

            string strSQL = @"
update DbCard
set CardCode = @CardCode,
    CardName = @CardName,
    ChangeBy= @ChangeBy,
    ChangeTime = datetime('now','localtime')
where CardID = @CardID
";
            if (args.DBType == 1)
            {
                strSQL = @"
update DbCard
set CardCode = @CardCode,
    CardName = @CardName,
    ChangeBy= @ChangeBy,
    ChangeTime = getdate()
where CardID = @CardID
";
            }
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
        }

        public void Delete(FactoryArgs args, t_BigID CardID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CardID", CardID));

            string strSQL = @"
delete DbCard
where CardID = @CardID
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
        }

        public DataTable GetCardCode(FactoryArgs args, t_BigID CardID, t_String CardCode)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CardID", CardID));
            parms.Add(new LBDbParameter("CardCode", CardCode));
            string strSQL = "";
            if (CardID.Value == 0)
            {
                strSQL = @"
                    select CardCode
                    from DbCard
                    where CardCode=@CardCode";
            }
            else
            {
                strSQL = @"
                    select CardCode
                    from DbCard
                    where CardCode=@CardCode and CardID<>@CardID";
            }
            return DBHelper.ExecuteQuery(args, strSQL, parms);
        }

        public void CardConfig(FactoryArgs args, t_String ReadCardSerialCOM, t_String WriteCardSerialCOM,
            t_ID ReadCardBaud, t_String MachineName,
            t_ID UseReadCard, t_ID UseWriteCard,
            t_ID ConnectType, t_String IPAddress, t_ID IPPort)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("ReadCardSerialCOM", ReadCardSerialCOM));
            parms.Add(new LBDbParameter("WriteCardSerialCOM", WriteCardSerialCOM));
            parms.Add(new LBDbParameter("ReadCardBaud", ReadCardBaud));
            parms.Add(new LBDbParameter("MachineName", MachineName));
            parms.Add(new LBDbParameter("UseReadCard", UseReadCard));
            parms.Add(new LBDbParameter("UseWriteCard", UseWriteCard));
            parms.Add(new LBDbParameter("ConnectType", ConnectType));
            parms.Add(new LBDbParameter("IPAddress", IPAddress));
            parms.Add(new LBDbParameter("IPPort", IPPort));

            string strSQL = @"
select 1 from DbCardConfig where rtrim(MachineName)=rtrim(@MachineName)
";
            using (DataTable dtResult = DBHelper.ExecuteQuery(args, strSQL, parms))
            {
                if (dtResult.Rows.Count > 0)
                {
                    strSQL = @"
update  DbCardConfig
set ReadCardSerialCOM = @ReadCardSerialCOM,
    WriteCardSerialCOM = @WriteCardSerialCOM,
    ReadCardBaud = @ReadCardBaud,
    UseReadCard = @UseReadCard,
    UseWriteCard = @UseWriteCard,
    ConnectType = @ConnectType,
    IPAddress = @IPAddress,
    IPPort = @IPPort
where rtrim(MachineName)=rtrim(@MachineName)";
                }
                else
                {
                    strSQL = @"
insert into  DbCardConfig(ReadCardSerialCOM,WriteCardSerialCOM,ReadCardBaud,MachineName,
    ConnectType,IPAddress,IPPort)
values(@ReadCardSerialCOM,@WriteCardSerialCOM,@ReadCardBaud,@MachineName,@ConnectType,@IPAddress,@IPPort)";
                }
                DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
            }
        }
    }
}
