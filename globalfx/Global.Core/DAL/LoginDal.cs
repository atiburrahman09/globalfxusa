using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Lumex.Tech;
using Global.Core.BLL;

namespace Global.Core.DAL
{
    public class LoginDal
    {
        //public static bool signin(userReg user, DBPlayer db)
        //{
        //    bool status = false;
        //    try
        //    {
        //        db.AddParameters("@UserId", user.id);
        //        db.AddParameters("@Password", user.pass);
        //        int res = db.ExecuteNonQuery("Login", true);
        //        if (res == 1)
        //        {
        //            status = true;
        //        }
        //        return status;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}
        public static LoginBll GetUserById(string UserId, LumexDBPlayer db)
        {
            DataTable dt;
            LoginBll logbal = new LoginBll();

            try
            {
                db.AddParameters("@UserId", UserId);

                dt = db.ExecuteDataTable("[GET_USER_BY_ID_AT_LOGIN]", true);

                DataTableReader dr = dt.CreateDataReader();

                if (dr.Read())
                {
                    logbal.UserId = dr["UserId"].ToString();
                    logbal.UserName = dr["UserName"].ToString();
                    logbal.UserGroup = dr["UserGroupId"].ToString();
                    logbal.PerPhoto = dr["PerPhoto"].ToString();
                    logbal.LastName = dr["LastName"].ToString();
                    logbal.IsActive = dr["IsActive"].ToString();
                    logbal.IsVarified = dr["isVarified"].ToString();

                }
                else
                {
                    logbal = null;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return logbal;
        }
        public bool VerifyPassword(LoginBll logbal, LumexDBPlayer db)
        {
            DataTable dt;// = new DataTable();

            string UserIdDb, PasswordDb;
            bool status = false;
            string UserId = logbal.UserId;
            // string Password =  LumexLibraryManager.EncodeIntoMd5Hash(logbal.Userpass);
            string Password = ProtectPassword(logbal.UserPass);
            try
            {
                db.AddParameters("@UserId", UserId);

                dt = db.ExecuteDataTable("[GET_USER_PASS_ID_AT_LOGIN]", true);

                DataTableReader dr = dt.CreateDataReader();

                if (dr.Read())
                {
                    UserIdDb = dr["UserId"].ToString();
                    PasswordDb = dr["Password"].ToString();

                    if (UserId == UserIdDb && Password == PasswordDb)
                    {
                        status = true;
                    }
                    else
                    {
                        status = false;
                    }
                }
                else
                {
                    logbal = null;
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }

            return status;
        }
        protected static string ProtectPassword(string password)
        {
            return LumexLibraryManager.EncodeIntoMd5Hash("LTSsL[" + password.Trim() + "]0");
        }

        internal void createAppUserSession(string strSec, LumexDBPlayer db)
        {
            try
            {
                DataTable dt = new DataTable();
                db.AddParameters("@AppSec", strSec);

                dt = db.ExecuteDataTable("INSERT INTO AppSec values(@AppSec)");




            }
            catch (Exception)
            {
                throw;
            }
        }

        internal bool checkAppSec(string appSec, LumexDBPlayer db)
        {
            bool st = false;
            try
            {
                DataTable dt = new DataTable();
                db.AddParameters("@AppSec", appSec.Trim());

                dt = db.ExecuteDataTable("Select AppSec from AppSec where AppSec=@AppSec");
                if (dt.Rows.Count > 0)
                {
                    st = true;
                }



            }
            catch (Exception)
            {
                throw;
            }
            return st;
        }
    }
}
