﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global.Core.BLL;
using Lumex.Tech;

namespace Global.Core.DAL
{
    public class UserAccountDLL
    {
        internal System.Data.DataTable GetTransiction(BLL.UserAccountBLL userAccountBLL, Lumex.Tech.LumexDBPlayer db)
        {
            bool status = true;
            DataTable dt = new DataTable();
            try
            {

            }
            catch (Exception)
            {

                throw;

            }

            return dt;
        }

        internal System.Data.DataTable GetUserPlacementInfoById(string UserId, Lumex.Tech.LumexDBPlayer db)
        {
            bool status = true;
            DataTable dt = new DataTable();
            try
            {
                db.AddParameters("@UserId", UserId);
                dt = db.ExecuteDataTable("SELECT  [Serial],[UserId],[RefferId],[PleacementId],[PlacePosition],[StakeId],[StakeKey],[JoinDate],[isChecked],[CheckedDate],[ActiveDate],[JoinFrom],[ActiveFrom] FROM [dbo].[tblStakeJoining] where [UserId] =@UserId ");
            }
            catch (Exception)
            {

                throw;

            }

            return dt;
        }



        internal DataTable getAccountSummaryById(string UserId, Lumex.Tech.LumexDBPlayer db)
        {
            bool status = true;
            DataTable dt = new DataTable();
            try
            {
                db.AddParameters("@UserId", UserId);
                dt = db.ExecuteDataTable("SELECT [Serial],[UserId],isnull( [Income],0) as Income,isnull( [Deposit],0) as Deposit,isnull( [Commission],0) as Commission,isnull( [FxFund],0) as FxFund,isnull( [TotalIncome],0) as TotalIncome FROM [dbo].[tblUserAccounts] where [UserId]=@UserId ");
            }
            catch (Exception)
            {

                throw;

            }

            return dt;
        }


        internal DataTable getUserIncomeStatementById(string UserId, string FromDate, string ToDate, Lumex.Tech.LumexDBPlayer db)
        {
            bool status = true;
            DataTable dt = new DataTable();
            try
            {

                db.AddParameters("@UserId", UserId);
                db.AddParameters("@FromDate", FromDate);
                db.AddParameters("@ToDate", ToDate);
                dt = db.ExecuteDataTable("GET_USER_RECEIVE_PAYMENT_BY_DATE_RANGE", true);
            }
            catch (Exception)
            {

                throw;

            }

            return dt;
        }


        internal DataTable UpdateUserAccount(string UserId, string StakeId, string StakeKey, Lumex.Tech.LumexDBPlayer db)
        {
            bool status = true;
            DataTable dt = new DataTable();
            try
            {

                db.AddParameters("@UserId", UserId);
                db.AddParameters("@StakeId", StakeId);
                db.AddParameters("@StakeKey", StakeKey);
                db.AddParameters("@ActiveFrom", LumexLibraryManager.GetTerminal());
                dt = db.ExecuteDataTable("[Update_USER_ACCOUNT_ACTIVATION_BY_STAKE_KEY]", true);
            }
            catch (Exception)
            {

                throw;

            }

            return dt;
        }




        internal void InsertReceivePaymentWhenActive(string UserId, string RefferId, string Commission, LumexDBPlayer db)
        {
            try
            {

                db.AddParameters("@UserId", UserId);
                db.AddParameters("@RefferId", RefferId);
                db.AddParameters("@Commission", Commission);
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());
                db.ExecuteNonQuery("[INSERT_RECEIVE_PAYMENT_WHEN_COMMISSION]", true);
            }
            catch (Exception)
            {

                //  throw;

            }


        }

        internal DataTable getTransferRequestByStatus(string Status, LumexDBPlayer db)
        {

            try
            {



                db.AddParameters("@Status", "P");
                db.AddParameters("@userId", (string)LumexSessionManager.Get("ActiveUserId"));

                DataTable dt = db.ExecuteDataTable("SELECT [Serial],[TransferId],[UserId],[TransferTo],[TransferType],[BankName],[SwiftCode],[Amount],[TransferNote],[RejectNote],[Status],[SuccessNote],[CreatedBy],[CreatedDate],[CreatedFrom] FROM [dbo].[tblWithdrawRequest] where Status=@Status and UserId=@userId");

                return dt;
            }
            catch (Exception)
            {

                throw;

            }
        }

        internal DataTable RequestToTransfer(BLL.UserAccountBLL userAccountBLL, LumexDBPlayer db)
        {

            try
            {

                db.AddParameters("@UserId", (string)LumexSessionManager.Get("ActiveUserId"));
                db.AddParameters("@TransferTo", userAccountBLL.TransferTo);
                db.AddParameters("@TransferType", userAccountBLL.transfarType);
                db.AddParameters("@BankName", userAccountBLL.BankAccountNo);
                db.AddParameters("@SwiftCode", userAccountBLL.SwiftCode);
                db.AddParameters("@Amount", userAccountBLL.Amount);
                db.AddParameters("@TransferNote", userAccountBLL.TransferNote);
                db.AddParameters("@Status", userAccountBLL.Status);
                db.AddParameters("@CreatedBy", (string)LumexSessionManager.Get("ActiveUserId"));
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                DataTable dt = db.ExecuteDataTable("[INSERT_WITHDRAW_REQUEST]", true);
                return dt;
            }
            catch (Exception)
            {

                throw;

            }
        }

        internal DataTable getWithdrawRequestList(string formDate, string toDate, string status, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@Status", status);
                db.AddParameters("@formdate", formDate);
                db.AddParameters("@toDate", toDate);
                DataTable dt = db.ExecuteDataTable("SELECT [Serial],[TransferId],[UserId],[TransferTo],[TransferType],[BankName],[SwiftCode],[Amount],[TransferNote],[RejectNote],[Status],[SuccessNote],[CreatedBy],[CreatedDate],[CreatedFrom] FROM [dbo].[tblWithdrawRequest] where Status=@Status and  CAST(CreatedDate AS DATE) BETWEEN CAST(@formdate AS DATE) AND CAST(@toDate AS DATE)");
                return dt;
            }
            catch (Exception)
            {

                throw;

            }
        }

        internal DataTable getWithdrawRequestListForUser(string UserId, string formDate, string toDate, string status, LumexDBPlayer db)
        {
            try
            {

                db.AddParameters("@Status", status);
                db.AddParameters("@userId", UserId);
                db.AddParameters("@formdate", formDate);
                db.AddParameters("@toDate", toDate);


                DataTable dt = db.ExecuteDataTable("SELECT [Serial],[TransferId],[UserId],[TransferTo],[TransferType],[BankName],[SwiftCode],[Amount],[TransferNote],[RejectNote],[Status],[SuccessNote],[CreatedBy],[CreatedDate],[CreatedFrom] FROM [dbo].[tblWithdrawRequest] where Status=@Status and UserId=@userId and  CAST(CreatedDate AS DATE) BETWEEN CAST(@formdate AS DATE) AND CAST(@toDate AS DATE)");

                return dt;
            }
            catch (Exception)
            {

                throw;

            }
        }
        internal DataTable getWithdrawRequestListToUser(string UserId, string formDate, string toDate, string status, LumexDBPlayer db)
        {
            try
            {

                db.AddParameters("@Status", status);
                db.AddParameters("@userId", UserId);
                db.AddParameters("@formdate", formDate);
                db.AddParameters("@toDate", toDate);


                DataTable dt = db.ExecuteDataTable("SELECT [Serial],[TransferId],[UserId],[TransferTo],[TransferType],[BankName],[SwiftCode],[Amount],[TransferNote],[RejectNote],[Status],[SuccessNote],[CreatedBy],[CreatedDate],[CreatedFrom] FROM [dbo].[tblWithdrawRequest] where Status=@Status and TransferTo=@userId and  CAST(CreatedDate AS DATE) BETWEEN CAST(@formdate AS DATE) AND CAST(@toDate AS DATE)");

                return dt;
            }
            catch (Exception)
            {

                throw;

            }
        }

        internal DataTable updateWithdrawRequest(string Id, string Status, LumexDBPlayer db)
        {
            try
            {

                db.AddParameters("@TransferId", Id);
                db.AddParameters("@Status", Status);
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());
                db.AddParameters("@CreatedBy", (string)LumexSessionManager.Get("ActiveUserId"));


                DataTable dt = db.ExecuteDataTable("[INSERT_RECEIVE_PAYMENT_WHEN_TRANSFER_AMOUNT]", true);

                return dt;
            }
            catch (Exception)
            {

                throw;

            }
        }

        internal void updateUserAccountforTransfer(BLL.UserAccountBLL userAccountBLL, LumexDBPlayer db)
        {
            try
            {

                db.AddParameters("@Amount", userAccountBLL.Amount);
                db.AddParameters("@userId", (string)LumexSessionManager.Get("ActiveUserId"));

                db.ExecuteNonQuery("Update tblUserAccounts Set Income = ISNULL( Income,0)-@Amount where UserId=@userId");


            }
            catch (Exception)
            {

                throw;

            }
        }

        internal DataTable generateDailyBonus(string Date, LumexDBPlayer db)
        {
            try
            {


                db.AddParameters("@CreatedBy", (string)LumexSessionManager.Get("ActiveUserId"));
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                DataTable dt = db.ExecuteDataTable("[INSERT_DAILY_BONUS]", true);

                return dt;
            }
            catch (Exception)
            {

                throw;

            }
        }

        internal void InsertReceivePaymentWhenDailybonus(LumexDBPlayer db)
        {
            try
            {


                db.AddParameters("@CreatedBy", (string)LumexSessionManager.Get("ActiveUserId"));
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("[INSERT_RECEIVE_PAYMENT_WHEN_DAILY_BONUS]", true);


            }
            catch (Exception)
            {

                //  throw;

            }
        }

        internal DataTable getGeneratedMoneyList(LumexDBPlayer db)
        {

            try
            {

                DataTable dt = db.ExecuteDataTable("SELECT [Serial],[Amount],[GenerateBy],[GenerateFrom],[GenerateDate] FROM [dbo].[tblMoneyGenerate]");
                return dt;

            }
            catch (Exception)
            {

                throw;

            }
        }


        internal DataTable InsertReceivePaymentWhenPinChange(LumexDBPlayer db)
        {

            try
            {
                db.AddParameters("@UserId", (string)LumexSessionManager.Get("ActiveUserId"));
                db.AddParameters("Amount", "5");
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());
                DataTable dt = db.ExecuteDataTable("INSERT_RECEIVE_PAYMENT_WHEN_PINCHANGE", true);
                return dt;

            }
            catch (Exception)
            {

                throw;

            }
        }


        internal DataTable ReceivePaymentMoney(string amount, LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                db.AddParameters("@Amount", amount);
                db.AddParameters("@GenerateBy", LumexSessionManager.Get("ActiveUserId"));
                db.AddParameters("@GenerateFrom", LumexLibraryManager.GetTerminal());
                dt = db.ExecuteDataTable("[INSERT_RECEIVE_PAYMENT_WHEN_GENERATE_MONRY]", true);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }


        internal DataTable InsertReceivePaymentWhenAffectIncome(BLL.UserAccountBLL userAccountBLL, LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {

                db.AddParameters("@UserId", LumexSessionManager.Get("ActiveUserId"));
                db.AddParameters("@AffectforId", userAccountBLL.AffectforId);
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());
                db.AddParameters("@RPType", userAccountBLL.RPType);
                db.AddParameters("@Amount", userAccountBLL.TotalAmount.ToString());
                db.AddParameters("@Particular", userAccountBLL.Particular);
                db.AddParameters("@AffectFor", userAccountBLL.Affectfor);
                dt = db.ExecuteDataTable("[INSERT_RECEIVE_PAYMENT_WHEN_AFFECT_INCOME]", true);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        internal DataTable getAccountSummaryAllUser(LumexDBPlayer db)
        {
            bool status = true;
            DataTable dt = new DataTable();
            try
            {

                dt = db.ExecuteDataTable("SELECT [Serial],[UserId],isnull( [Income],0) as Income,isnull( [Deposit],0) as Deposit,isnull( [Commission],0) as Commission,isnull( [FxFund],0) as FxFund,isnull( [TotalIncome],0) as TotalIncome FROM [dbo].[tblUserAccounts]");
            }
            catch (Exception)
            {

                throw;

            }

            return dt;
        }

        internal DataTable getDailybounsListbyDateRange(string FromDate, string ToDate, LumexDBPlayer db)
        {

            DataTable dt = new DataTable();
            try
            {
                db.AddParameters("@FromDate",LumexLibraryManager.ParseAppDate(FromDate));
                db.AddParameters("@ToDate", LumexLibraryManager.ParseAppDate(ToDate));
                dt = db.ExecuteDataTable("SELECT [Serial],[UserId],[DailyBonus],CONVERT(VARCHAR, CAST([BonusDate] AS SMALLDATETIME), 103)as  [BonusDate] ,[CreatedFrom],[CreatedBy],[InvestAmount] FROM [dbo].[tblDailyBous] where CAST(BonusDate AS DATE) BETWEEN CAST(@FromDate AS DATE) AND CAST(@ToDate AS DATE) ORDER BY [BonusDate] ASC");
            }
            catch (Exception)
            {

                throw;

            }

            return dt;
        }

        internal DataTable getDailybounsListbyDateRangeByUserId(string FromDate, string ToDate, string UserId, LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                db.AddParameters("@UserId",UserId);
                db.AddParameters("@FromDate", LumexLibraryManager.ParseAppDate(FromDate));
                db.AddParameters("@ToDate", LumexLibraryManager.ParseAppDate(ToDate));
                dt = db.ExecuteDataTable("SELECT [Serial],[UserId],[DailyBonus],[BonusDate],[CreatedFrom],[CreatedBy],[InvestAmount]FROM [dbo].[tblDailyBous] where UserId=@UserId and CAST(BonusDate AS DATE) BETWEEN CAST(@FromDate AS DATE) AND CAST(@ToDate AS DATE)");
            }
            catch (Exception)
            {

                throw;

            }

            return dt;
        }

        internal DataTable GetUserActivationInfoById(string UserId, LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                db.AddParameters("@UserId", UserId);

                dt = db.ExecuteDataTable("SELECT [Serial],[UserId],[RefferId],[PleacementId],[PlacePosition],[StakeId],dbo.GetStakeAmountByUserId(UserId) as Invest,dbo.GetStakeNameByID([StakeId]) as StakeName,CONVERT(VARCHAR, CAST([JoinDate] AS SMALLDATETIME), 106)as [JoinDate],[isChecked],[CheckedDate],CONVERT(VARCHAR, CAST([ActiveDate] AS SMALLDATETIME), 106) as [ActiveDate],[JoinFrom],[ActiveFrom]FROM [tblStakeJoining] where UserId=@UserId");
            }
            catch (Exception)
            {

                throw;

            }

            return dt;
        }

        internal DataTable getMatchingCommissionListbyDateRangeByUserId(string FromDate, string ToDate, string UserId, LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                db.AddParameters("@UserId", UserId);
                db.AddParameters("@FromDate", LumexLibraryManager.ParseAppDate(FromDate));
                db.AddParameters("@ToDate", LumexLibraryManager.ParseAppDate(ToDate));
                dt = db.ExecuteDataTable("Select [Serial],[UserId],[Leftcarry],[RightCarry],[CarryFlash],[CarryForward],[CarryFrwdPosition],[MatchCommission],[DailyAcBonus],[CalculateDate] FROM [dbo].[tblDailyFlashHistory] where UserId=@UserId and CAST(CalculateDate AS DATE) BETWEEN CAST(@FromDate AS DATE) AND CAST(@ToDate AS DATE)");
            }
            catch (Exception)
            {

                throw;

            }

            return dt;
        }

        internal DataTable getMatchingCommissionListbyDateRange(string FromDate, string ToDate, LumexDBPlayer db)
        {
             DataTable dt = new DataTable();
            try
            {

                db.AddParameters("@FromDate", LumexLibraryManager.ParseAppDate(FromDate));
                db.AddParameters("@ToDate", LumexLibraryManager.ParseAppDate(ToDate));
                dt = db.ExecuteDataTable("Select [Serial],[UserId],[Leftcarry],[RightCarry],[CarryFlash],[CarryForward],[CarryFrwdPosition],[MatchCommission],[DailyAcBonus],[CalculateDate] FROM [dbo].[tblDailyFlashHistory] where CAST(CalculateDate AS DATE) BETWEEN CAST(@FromDate AS DATE) AND CAST(@ToDate AS DATE)");
            }
            catch (Exception)
            {

                throw;

            }

            return dt;
        }

        internal DataTable UpdateUserIncomeBalanceFromDeposit(string UserId, string ammount, LumexDBPlayer db)
        {

            DataTable dt = new DataTable();
            try
            {
                db.AddParameters("@UserId", UserId);
                db.AddParameters("@Amount", ammount);
                dt = db.ExecuteDataTable("UPDATE [dbo].[tblUserAccounts]   SET [Income] = ISNULL(Income,0)+ @Amount,[Deposit] = ISNULL(Deposit,0)- @Amount WHERE UserId=@UserId");

            }
            catch (Exception)
            {
                
                throw;
            }
            return dt;
        }

        internal DataTable UpdateUserIncomeBalanceFromCommission(string UserId,string ammount, LumexDBPlayer db)
        {

            DataTable dt = new DataTable();
            try
            {
                db.AddParameters("@UserId", UserId);
                db.AddParameters("@Amount", ammount);
                dt = db.ExecuteDataTable("UPDATE [dbo].[tblUserAccounts]   SET [Income] = ISNULL(Income,0)+ @Amount,[Commission] = ISNULL(Commission,0)- @Amount WHERE UserId=@UserId");

            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        internal DataTable getMoneyGenerateAmountById(string UserId, LumexDBPlayer db)
        {
            DataTable dt=new DataTable();
            try
            {
                db.AddParameters("@UserId", UserId);
                dt = db.ExecuteDataTable("Select Sum(ISNULL([Amount],0)) from [dbo].[tblMoneyGenerate]");
            }
            catch (Exception)
            {
                
                throw;
            }
            return dt;
        }

        internal DataTable getCommissionById(string UserId, LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                db.AddParameters("@UserId", UserId);
                dt = db.ExecuteDataTable("Select Sum(ISNULL([Amount],0)) from [dbo].[tblReceivePayment] where Receiveon = 'Matching Commission' or Receiveon='Reffer Commission'");
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        internal DataTable getDailyBonusById(string UserId, LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                db.AddParameters("@UserId", UserId);
                dt = db.ExecuteDataTable("Select Sum(ISNULL([DailyBonus],0)) from [dbo].[tblDailyBous]");
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        internal DataTable getMoneyGenerateAmountByDateRangeById(string FromDate, string ToDate, string UserId, LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {

                db.AddParameters("@FromDate", LumexLibraryManager.ParseAppDate(FromDate));
                db.AddParameters("@ToDate", LumexLibraryManager.ParseAppDate(ToDate));

                dt = db.ExecuteDataTable("Select [Serial],[Amount],[GenerateBy],[GenerateFrom],[GenerateDate] FROM [dbo].[tblMoneyGenerate] where CAST(GenerateDate AS DATE) BETWEEN CAST(@FromDate AS DATE) AND CAST(@ToDate AS DATE)");
            }
            catch (Exception)
            {

                throw;

            }

            return dt;
        }

        internal DataTable getTotalMatchingCommissionListbyDateRange(string FromDate, string ToDate, LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {

                db.AddParameters("@FromDate", LumexLibraryManager.ParseAppDate(FromDate));
                db.AddParameters("@ToDate", LumexLibraryManager.ParseAppDate(ToDate));

                dt = db.ExecuteDataTable("Select [amount],CONVERT(VARCHAR, CAST([TransectionDate] AS SMALLDATETIME), 103) as [TransectionDate] FROM [dbo].[tblReceivePayment] where CAST(TransectionDate AS DATE) BETWEEN CAST(@FromDate AS DATE) AND CAST(@ToDate AS DATE) ORDER BY [TransectionDate] ASC");

               
            }
            catch (Exception)
            {

                throw;

            }

            return dt;
        }
        internal void SavePaymentInfo(UserAccountBLL account, LumexDBPlayer db)
        {
            bool status;
            DataTable dt = new DataTable();
            try
            {
                db.AddParameters("@UserId", account.UserId);
                db.AddParameters("@GatewayType", account.Type);
                db.AddParameters("@BankName", account.BankName);
                db.AddParameters("@BankAccount", account.BankAccountNo);
                db.AddParameters("@SwiftCode", account.SwiftCode);
                db.AddParameters("@CardNo", account.CardNumber);
                db.AddParameters("@CardWoner", account.CardOwnerName);
                db.AddParameters("@ExpireDate",LumexLibraryManager.ParseAppDate( account.CardExpireDate));
                db.AddParameters("@GatewayEmail", account.OnlineEmail);
                db.AddParameters("@GatewayOwner", account.GateWayOwnerName);
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId"));
                db.AddParameters("@IsActive", "Yes");
                db.ExecuteNonQuery("INSERT INTO [dbo].[tblPaymetnMethod] ([GatewayType], [BankName], [BankAccount], [SwiftCode], [CardNo], [CardWoner], [ExpireDate], [GatewayEmail], [GatewayOwner], [UserId], [CreatedBy], [IsActive]) VALUES (@GatewayType, @BankName, @BankAccount, @SwiftCode, @CardNo, @CardWoner, @ExpireDate, @GatewayEmail, @GatewayOwner, @UserId, @CreatedBy, @IsActive)");
                status = true;
            }
            catch (Exception)
            {
                throw;
            }

        }

        internal DataTable GetPaymentInfoById(string UserId,string Type, LumexDBPlayer db)
        {
            DataTable dt=new DataTable();
            try
            {
                db.AddParameters("@UserId", UserId);
                db.AddParameters("@Type", Type);

                dt = db.ExecuteDataTable("SELECT [Serial],[GatewayType],[BankName],[BankAccount],[SwiftCode],[CardNo],[CardWoner],[ExpireDate],[GatewayEmail],[GatewayOwner],[UserId],[CreatedBy],[IsActive]FROM [dbo].[tblPaymetnMethod] where UserId=@UserId and GatewayType=@Type");
            }
            catch (Exception)
            {
                
                throw;
            }
            return dt;
        }

        internal DataTable GetPaymentInfoBySerial(string serial, LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                db.AddParameters("@Serial", serial);
                dt = db.ExecuteDataTable("SELECT [Serial],[GatewayType],[BankName],[BankAccount],[SwiftCode],[CardNo],[CardWoner],[ExpireDate],[GatewayEmail],[GatewayOwner],[UserId],[CreatedBy],[IsActive]FROM [dbo].[tblPaymetnMethod] where Serial=@Serial");
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        internal DataTable UpdatePaymentInfoBySerial(UserAccountBLL account, LumexDBPlayer db)
        {
            bool status;
            DataTable dt = new DataTable();
            try
            {
                db.AddParameters("@serial", LumexSessionManager.Get("Serial").ToString());
                db.AddParameters("@UserId", account.UserId);
                db.AddParameters("@GatewayType", account.Type);
                db.AddParameters("@BankName", account.BankName);
                db.AddParameters("@BankAccount", account.BankAccountNo);
                db.AddParameters("@SwiftCode", account.SwiftCode);
                db.AddParameters("@CardNo", account.CardNumber);
                db.AddParameters("@CardWoner", account.CardOwnerName);
                db.AddParameters("@ExpireDate", LumexLibraryManager.ParseAppDate(account.CardExpireDate));
                db.AddParameters("@GatewayEmail", account.OnlineEmail);
                db.AddParameters("@GatewayOwner", account.GateWayOwnerName);
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId"));
                db.AddParameters("@IsActive", "Yes");
                db.ExecuteNonQuery("INSERT INTO [dbo].[tblPaymetnMethod] ([GatewayType], [BankName], [BankAccount], [SwiftCode], [CardNo], [CardWoner], [ExpireDate], [GatewayEmail], [GatewayOwner], [UserId], [CreatedBy], [IsActive]) VALUES (@GatewayType, @BankName, @BankAccount, @SwiftCode, @CardNo, @CardWoner, @ExpireDate, @GatewayEmail, @GatewayOwner, @UserId, @CreatedBy, @IsActive)");
                status = true;
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }

        internal DataTable GetPaymentInfoNyIdandType(string UserId, string Type, LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                db.AddParameters("@UserId", UserId);
                db.AddParameters("@Type", Type);

                dt = db.ExecuteDataTable("SELECT [BankName],([BankAccount]+'#'+[SwiftCode]) as Account,[CardNo],[CardWoner],[ExpireDate],[GatewayEmail],[GatewayOwner],[UserId],[CreatedBy],[IsActive]FROM [dbo].[tblPaymetnMethod] where UserId=@UserId and GatewayType=@Type");
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }
    }
}
