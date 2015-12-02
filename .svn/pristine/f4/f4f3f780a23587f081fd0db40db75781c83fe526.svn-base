using System;
using System.Data;
using Global.Core.BLL;
using Lumex.Tech;

namespace Global.Core.DAL
{
    public class UserGroupDAL
    {
        public DataTable SaveUserGroup(UserGroupBLL userGroup, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@UserGroupName", userGroup.UserGroupName.Trim());
                db.AddParameters("@Description", userGroup.Description.Trim());
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId"));
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());
                db.AddParameters("@BranchId", LumexSessionManager.Get("UserBranchId"));
                db.AddParameters("@GroupOrder","1");
                DataTable dt = db.ExecuteDataTable("INSERT_USER_GROUP", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                userGroup = null;
            }
        }

        public DataTable GetUserGroupList(LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@BranchId", LumexSessionManager.Get("UserBranchId"));
                DataTable dt = db.ExecuteDataTable("GET_USER_GROUPS", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetDeletedUserGroupListByDateRangeAll(string fromDate, string toDate, string search, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@FromDate", fromDate.Trim());
                db.AddParameters("@ToDate", toDate.Trim());
                db.AddParameters("@Search", search.Trim());
                db.AddParameters("@BranchId", LumexSessionManager.Get("UserBranchId"));

                DataTable dt = db.ExecuteDataTable("GET_DELETED_USER_GROUPS_BY_DATE_RANGE_ALL", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetActiveUserGroupList(LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@BranchId", LumexSessionManager.Get("UserBranchId"));
                DataTable dt = db.ExecuteDataTable("GET_ACTIVE_USER_GROUP_LIST", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetUserGroupById(string userGroupId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@UserGroupId", userGroupId);
                DataTable dt = db.ExecuteDataTable("GET_USER_GROUP_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CheckDuplicateUserGroup(string userGroupName, LumexDBPlayer db)
        {
            bool status = false;

            try
            {
                db.AddParameters("@UserGroupName", userGroupName);
                db.AddParameters("@BranchId", LumexSessionManager.Get("UserBranchId"));
                DataTable dt = db.ExecuteDataTable("CHECK_DUPLICATE_USER_GROUP", true);

                if (dt.Rows.Count > 0)
                {
                    status = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return status;
        }

        public void UpdateUserGroupActivation(string userGroupId, string activationStatus, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@UserGroupId", userGroupId);
                db.AddParameters("@IsActive", activationStatus);
                db.AddParameters("@ActivatedBy", LumexSessionManager.Get("ActiveUserId"));
                db.AddParameters("@ActivatedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_USER_GROUP_ACTIVATION", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteUserGroup(string userGroupId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@UserGroupId", userGroupId);
                db.AddParameters("@DeletedBy", LumexSessionManager.Get("ActiveUserId"));
                db.AddParameters("@DeletedFrom", LumexLibraryManager.GetTerminal());
                db.AddParameters("@BranchId", LumexSessionManager.Get("UserBranchId"));
                db.ExecuteNonQuery("DELETE_USER_GROUP_BY_ID", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateUserGroup(UserGroupBLL userGroup, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@UserGroupId", userGroup.UserGroupId.Trim());
                db.AddParameters("@UserGroupName", userGroup.UserGroupName.Trim());
                db.AddParameters("@Description", userGroup.Description.Trim());
                db.AddParameters("@ModifiedBy", LumexSessionManager.Get("ActiveUserId"));
                db.AddParameters("@ModifiedFrom", LumexLibraryManager.GetTerminal());
                db.AddParameters("@GroupOrder","1");
                db.ExecuteNonQuery("UPDATE_USER_GROUP_BY_ID", true);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                userGroup = null;
            }
        }
    }
}
