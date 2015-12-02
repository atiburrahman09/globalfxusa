using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Lumex.Tech;

namespace Global.Core.DLL
{
    public class SystemDAL
    {
        internal DataTable getActiveMessage(LumexDBPlayer db)
        {
            try
            {
                DataTable dt = db.ExecuteDataTable("[GET_ACTIVE_MESSAGE]", false);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal void updateActiveMessage(string Message, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@Msg", Message);
                db.ExecuteNonQuery("[UPDATE_ACTIVE_MESSAGE]", true);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}