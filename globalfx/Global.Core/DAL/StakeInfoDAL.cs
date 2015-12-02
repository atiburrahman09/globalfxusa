﻿using Lumex.Tech;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Core.DAL
{
    class StakeInfoDAL
    {
        //            @StakeName	nvarchar(100)	,
        //@DailyAwardFrom	decimal(18, 2)	,
        //@DailyAwardTo	decimal(18, 2)	,
        //@Avarage	decimal(18, 2)	,
        //@TotalDuration	decimal(18, 2)	,
        //@BinaryCap	decimal(18, 2)	,
        //@Parcentage	decimal(18, 2)	,
        //@CreatedBy	varchar(50)	,
        //@CreatedFrom	varchar(50)	
        internal System.Data.DataTable SaveStaKeInfo(BLL.StakeInfoBLL stakeInfoBLL, LumexDBPlayer db)
        {

            bool status = true;
            DataTable dt = new DataTable();
            try
            {
                db.AddParameters("@StakeName", stakeInfoBLL.StakeName);
                db.AddParameters("@Amount", stakeInfoBLL.Amount);
                db.AddParameters("@DailyAwardFrom", stakeInfoBLL.DailyAwardFrom);
                db.AddParameters("@DailyAwardTo", stakeInfoBLL.DailyAwardTo);
                db.AddParameters("@Avarage", stakeInfoBLL.AvgAward);
                db.AddParameters("@TotalDuration", stakeInfoBLL.TotalDuration);
                db.AddParameters("@BinaryCap", stakeInfoBLL.BinaryCap);
                db.AddParameters("@Parcentage", stakeInfoBLL.Parcentage);
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId"));
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());
                dt = db.ExecuteDataTable("[INSERT_STAKE_INFO]", true);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        internal void UpdateStakeInfo(BLL.StakeInfoBLL stakeInfoBLL, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@StakeId", stakeInfoBLL.StakeId);
                db.AddParameters("@StakeName", stakeInfoBLL.StakeName);
                db.AddParameters("@Amount", stakeInfoBLL.Amount);
                db.AddParameters("@DailyAwardFrom", stakeInfoBLL.DailyAwardFrom);
                db.AddParameters("@DailyAwardTo", stakeInfoBLL.DailyAwardTo);
                db.AddParameters("@Avarage", stakeInfoBLL.AvgAward);
                db.AddParameters("@TotalDuration", stakeInfoBLL.TotalDuration);
                db.AddParameters("@BinaryCap", stakeInfoBLL.BinaryCap);
                db.AddParameters("@Parcentage", stakeInfoBLL.Parcentage);
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId"));
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());
                db.ExecuteDataTable("[UPDATE_STAKE_INFO]", true);

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal DataTable GetStakeInfoList(LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = db.ExecuteDataTable("[GET_STAKE_INFO_LIST]", false);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        internal void SaveGeneratedPin(DataTable dt, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@StakeGen", dt);
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId"));
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());
                db.ExecuteDataTable("INSERT_STAKE_PIN", true);

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal DataTable getGeneratedPinList(LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = db.ExecuteDataTable("[GET_STAKE_PIN_LIST]", false);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        internal bool CheckDuplicateKey(string pinserial, LumexDBPlayer db)
        {
            bool status = false;
            try
            {
                db.AddParameters("@StakeKey", pinserial);
                DataTable dt = db.ExecuteDataTable("CHECK_DUPLICATE_STAKET_KEY", true);
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

        internal void UpdateStakePinActivation(string serial, string IsActive, LumexDBPlayer db)
        {

            try
            {
                db.AddParameters("@Serial", serial);
                db.AddParameters("@IsActive", IsActive);
                int i = db.ExecuteNonQuery("Update tblStakePin Set IsActive=@IsActive Where Serial = @Serial");

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal DataTable getStakePinListByOwner(string UserId, LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                db.AddParameters("@UserId", UserId);
                dt = db.ExecuteDataTable("SELECT [Serial],[StakeId],[dbo].[GetStakeNameByID]([StakeId]) as StakeName,[StakePin],[PinOwner],[SentTo],[IsActive],[IsUsed],[SendSMS] from tblStakePin where PinOwner=@UserId");
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }



        internal void updateKeyonTransfer(BLL.StakeInfoBLL stakeInfoBLL, DataTable dt, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@StakeKey", dt);

                db.AddParameters("@SentTo", stakeInfoBLL.sendto);
                db.AddParameters("@SentBy", stakeInfoBLL.transferBy);
                db.AddParameters("@SendSms",stakeInfoBLL.sendSms);
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId"));
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());
                db.ExecuteDataTable("[UPDATE_STAKE_PIN_ON_TRANSFER]", true);

            }
            catch (Exception)
            {
                    
                throw;
            }
        }

        internal DataTable getStakePinListBySentto(string UserId, LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                db.AddParameters("@UserId", UserId);
                dt = db.ExecuteDataTable("SELECT [Serial],[StakeId],[dbo].[GetStakeNameByID]([StakeId]) as StakeName,[StakePin],[PinOwner],[SentTo],[IsActive],[IsUsed],[SendSMS] from tblStakePin where SentTo=@UserId");
            }
            catch (Exception)
            {

                throw;
            }
            return dt; ;
        }

        internal void updateKeyWhenReceived(string Serial, string UserId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@UserId", UserId);
                db.AddParameters("@Serial", Serial);
                db.ExecuteDataTable("Update [dbo].[tblStakePin] Set PinOwner=@UserID,SentTo='' where Serial=@Serial and  IsActive='Yes' and IsUsed='No'");
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal void updateKeyWhenReject(string Serial, string UserId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@UserId", UserId);
                db.AddParameters("@Serial", Serial);
                db.ExecuteDataTable("Update [dbo].[tblStakePin] Set SentTo='', SendSMS='' where Serial=@Serial and  IsActive='Yes' and IsUsed='No'");
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal DataTable getStakeKeyLogdatabyUser(string UserId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@UserId", UserId);

                DataTable dt = db.ExecuteDataTable("SELECT [Serial],[UserId],[StakeKey],[LogMsg],[SentTo],[SentStatus],[PurchaseStatus],[CreaetedBy],[CreatedFrom],[CreatedDate]FROM [dbo].[tblStakeLog] where (UserId = @UserId or SentTo = @UserId)");

                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal DataTable getStakeKeyLogdataAll(LumexDBPlayer db)
        {
            try
            {
               

                DataTable dt = db.ExecuteDataTable("SELECT [Serial],[UserId],[StakeKey],[LogMsg],[SentTo],[SentStatus],[PurchaseStatus],[CreaetedBy],[CreatedFrom],[CreatedDate]FROM [dbo].[tblStakeLog] ");

                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal DataTable CheckStakeKeyAvailability(string StakeKey, string UserId, string StakeId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@StakeKey",StakeKey);
                db.AddParameters("@UserId", UserId);
                db.AddParameters("@StakeId", StakeId);

                DataTable dt = db.ExecuteDataTable("SELECT [Serial] from tblStakePin where PinOwner=@UserId and StakePin=@StakeKey and IsActive='Yes' and IsUsed='No' and StakeId=@StakeId");
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal DataTable GetStakeInfoById(string stakeId, LumexDBPlayer db)
        {
            try
            {

                db.AddParameters("@StakeId", stakeId);
                DataTable dt = db.ExecuteDataTable("[GET_STAKE_INFO_BY_ID]",true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal DataTable getstakeAmountByStakeId(string stakeId, LumexDBPlayer db)
        {
            try
            {

                db.AddParameters("@StakeId", stakeId);
                DataTable dt = db.ExecuteDataTable("SELECT [Amount] FROM [dbo].[tblStakeInfo] where [StakeId]=@StakeId");
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal DataTable GetFreeStakeKeyListByStakeId(string stakeId, LumexDBPlayer db)
        {
            try
            {

                db.AddParameters("@StakeId", stakeId);
                DataTable dt = db.ExecuteDataTable("SELECT [Serial],[StakeId],[StakePin],[PinOwner],[SentTo],[IsActive],[IsUsed],[SendSMS],[CreatedBy],[UsedBy],[CreatedFrom],[CreatedDate] FROM [dbo].[tblStakePin] where StakeId=@StakeId and IsActive='Yes' and IsUsed='No'");
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal DataTable updateKeyWhenPurchase(string NoofPin, string UnitPrice, string StakeId, string payby, LumexDBPlayer db)
        {
            try
            {

                db.AddParameters("@UserId", LumexSessionManager.Get("ActiveUserId"));
                db.AddParameters("@NoofPin",NoofPin);
                db.AddParameters("@PinAmount", UnitPrice);
                db.AddParameters("@StakeId", StakeId);
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());
                db.AddParameters("@PayBy", payby);
                DataTable dt = db.ExecuteDataTable("[UPDATE_STAKE_PIN_ON_PURCHEAS_AND_PAYMENT]",true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
