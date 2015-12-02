﻿using System;
using System.Data;
using Global.Core.DAL;
using Lumex.Tech;

namespace Global.Core.BLL
{
    public class UserBLL
    {
        public string UserId { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }
        public string PassportNumber { get; set; }
        public string Password { get; set; }
        public string UserGroupId { get; set; }
        public string Branch { get; set; }

        public DataTable SaveUser()
        {
            UserDAL user = new UserDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                DataTable dt = user.SaveUser(this, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                user = null;
            }
        }

        public bool ValidateUser()
        {
            UserDAL user = new UserDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                Boolean isValid = UserDAL.ValidateUser(this, db);
                db.Stop();

                return isValid;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                user = null;
            }
        }


        public bool UpdateUserPassword(string userId, string password)
        {
            UserDAL user = new UserDAL();
            bool status = false;
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                user.UpdateUserPassword(userId, password, db);
                status = true;
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                user = null;
            }
            return status;
        }


        public DataTable GetUserList()
        {
            UserDAL user = new UserDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = user.GetUserList(db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                user = null;
            }
        }

        public DataTable GetDeletedUserListByDateRangeAll(string fromDate, string toDate, string search)
        {
            UserDAL user = new UserDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = user.GetDeletedUserListByDateRangeAll(fromDate, toDate, search, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                user = null;
            }
        }

        public DataTable GetActiveUserList()
        {
            UserDAL user = new UserDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = user.GetActiveUserList(db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                user = null;
            }
        }

        public DataTable GetUserById(string userId)
        {
            UserDAL user = new UserDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = user.GetUserById(userId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                user = null;
            }
        }

        public bool CheckDuplicateSalesCenter(string userId)
        {
            UserDAL user = new UserDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                bool status = user.CheckDuplicateUser(userId, db);
                db.Stop();
                return status;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                user = null;
            }
        }

        public void UpdateUserActivation(string userId, string activationStatus)
        {
            UserDAL user = new UserDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                user.UpdateUserActivation(userId, activationStatus, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                user = null;
            }
        }

        public void DeleteUser(string userId)
        {
            UserDAL user = new UserDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                user.DeleteUser(userId, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                user = null;
            }
        }

        public bool UpdateUser()
        {
            bool status = false;
            UserDAL user = new UserDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                status = user.UpdateUser(this, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                user = null;
            }
            return status;
        }

        public string ValidDate { get; set; }

        public string Serial { get; set; }

        public DataTable GetUserListByBruchId(string BranchId)
        {
            UserDAL user = new UserDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = user.GetUserListByBruchId(BranchId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                user = null;
            }
        }
        public bool CheckDuplicateUser(string emailId)
        {
            UserDAL user = new UserDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                bool status = user.CheckDuplicateUser(emailId, db);
                db.Stop();
                return status;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                user = null;
            }
        }
        public string ActivationUrl { get; set; }

        public int varifycode { get; set; }



        public bool CheckUserIdOrMailForResetPass(string UserId)
        {
            UserDAL user = new UserDAL();
            bool status = false;
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = user.CheckUserIdOrMailForResetPass(UserId, db);
                db.Stop();
                if (dt.Rows.Count > 0)
                {
                    UserId = dt.Rows[0]["UserId"].ToString();
                    Email = dt.Rows[0]["Email"].ToString();
                    UserName = dt.Rows[0]["UserName"].ToString();
                    status = true;

                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                user = null;
            }
            return status;
        }

        public string Cell { get; set; }

        public string DOB { get; set; }

        public string Gender { get; set; }

        public string Certificate { get; set; }

        public string Occupation { get; set; }

        public string Organization { get; set; }

        public string ExperienceICT { get; set; }

        public string LastDegree { get; set; }

        public string DegreeSubject { get; set; }

        public string PassingYear { get; set; }

        public string FatherName { get; set; }

        public string MotherName { get; set; }

        public string ParmanentAdd { get; set; }

        public string PresentAdd { get; set; }

        public string PerPhoto { get; set; }



        public string ActualPass { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PassportNo { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string House { get; set; }

        public string Street { get; set; }

        public string Area { get; set; }

        public string MobileNo { get; set; }

        public string EmrName { get; set; }

        public string EmrAddress { get; set; }

        public string EmrMobile { get; set; }

        public string EmeEmail { get; set; }

        public String EmeCountry { get; set; }

        public string UserPin { get; set; }

        public string EmrRelation { get; set; }

        public bool SaveUserInfo()
        {
           UserDAL aUserDal=new UserDAL();
            bool status = false;
            DataTable dt=new DataTable();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                dt = aUserDal.SaveUserInfo(this,db);
                db.Stop();
                if (dt.Rows.Count > 0)
                {
                    status = true;
                    UserId = dt.Rows[0][0].ToString();
                }
               
            }
            catch (Exception)
            {
                
                throw;
            }
            finally
            {
                dt.Clear();
            }
            return status;

        }

        public DataTable GetUserInfoList()
        {
            DataTable dt=new DataTable();
            UserDAL aUserDal=new UserDAL();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                dt = aUserDal.GetUserInfoList(db);
                db.Stop();
                return dt;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public string IsActive { get; set; }

        public string Isvarified { get; set; }

        public string Createdby { get; set; }

        public DataTable GetUserInfoById(string userId)
        {
            UserDAL user = new UserDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = user.GetUserInfoById(userId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                user = null;
            }
        }

        public string CreatedFrom { get; set; }

        public bool UpdateUserInfo(UserBLL aUser)
        {
            bool status = false;
            UserDAL user = new UserDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                status = user.UpdateUserInfo(aUser, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                user = null;
            }
            return status;
        }

        public bool varifypin(string userid, string UserPin)
        {
            bool status = false;
            UserDAL user = new UserDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                status = user.varifypin(userid,UserPin, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                user = null;
            }
            return status;
        }



        public void InsertIntoGenolgyTree(string placeId, string position, string referId, string UserId)
        {
            UserDAL user = new UserDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                user.InsertIntoGenolgyTree(placeId,position,referId,UserId, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                user = null;
            }
        }

        public DataTable GetUserInfoByIdForView(string userId)
        {
            UserDAL user = new UserDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = user.GetUserInfoByIdforView(userId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                user = null;
            }
        }

        public DataTable GetUserByGroupId( UserBLL aUser)
        {
            DataTable dt = new DataTable();
            UserDAL aUserDal = new UserDAL();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                dt = aUserDal.GetUserByGroupId(db,aUser);
                db.Stop();
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable getUserPasswordsetValidity()
        {
            UserDAL userDal = new UserDAL();
            DataTable dt = new DataTable();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                dt = userDal.getUserPasswordsetValidity(db, this);
                db.Stop();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                userDal = null;
            }
            return dt;
        }

        public string Commission { get; set; }

        public string Pin { get; set; }

        public bool UpdateUserPin(string userId, string pin)
        {
            UserDAL user = new UserDAL();
            bool status = false;
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                user.UpdateUserPin(userId, pin, db);
                status = true;
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                user = null;
            }
            return status;
        }

        public DataTable checkuserPinchangevalidity(string UserId)
        {

            UserDAL userDal = new UserDAL();
            DataTable dt = new DataTable();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                dt = userDal.checkuserPinchangevalidity(UserId,db);
                db.Stop();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                userDal = null;
            }
            return dt;
        }

        public bool checkPlacementIdValidity(string UserId,string Position)
        {
            UserDAL user = new UserDAL();
            bool status = false;
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
               DataTable dt= user.checkPlacementIdValidity(UserId, Position, db);
                if (dt.Rows.Count > 0)
                {
                    status = true;
                }
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                user = null;
            }
            return status;
        }

       
    }
}
