﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global.Core.DAL;
using Lumex.Tech;

namespace Global.Core.BLL
{
    public class UserAccountBLL
    {
        public bool GetTransiction()
        {
            UserAccountDLL aUser = new UserAccountDLL();
            bool status = false;
            DataTable dt = new DataTable();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                dt = aUser.GetTransiction(this, db);
                db.Stop();
                if (dt.Rows.Count > 0)
                {
                    status = true;

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

        public string Type { get; set; }

        public string BankAccountNo { get; set; }

        public string TransferTo { get; set; }

        public string SwiftCode { get; set; }

        public string Pin { get; set; }

        public string TransferNote { get; set; }

        public DataTable GetUserPlacementInfoById(string UserId)
        {
            UserAccountDLL aUser = new UserAccountDLL();

            DataTable dt = new DataTable();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                dt = aUser.GetUserPlacementInfoById(UserId, db);
                db.Stop();


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                //dt.Clear();
            }
            return dt;
        }

        public DataTable getAccountSummaryById(string UserId)
        {
            UserAccountDLL aUser = new UserAccountDLL();

            DataTable dt = new DataTable();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                dt = aUser.getAccountSummaryById(UserId, db);
                db.Stop();


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                //   dt.Clear();
            }
            return dt;
        }


        public DataTable getUserIncomeStatementById(string UserId, string FromDate, string ToDate)
        {
            UserAccountDLL aUser = new UserAccountDLL();

            DataTable dt = new DataTable();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                dt = aUser.getUserIncomeStatementById(UserId, FromDate, ToDate, db);
                db.Stop();


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                //   dt.Clear();
            }
            return dt;
        }


        public bool UpdateUserAccount(string UserId, string StakeId, string StakeKey)
        {
            UserAccountDLL aUser = new UserAccountDLL();
            bool status = false;
            DataTable dt = new DataTable();
            try
            {

                LumexDBPlayer db = LumexDBPlayer.Start(true);
                dt = aUser.UpdateUserAccount(UserId, StakeId, StakeKey, db);
                if (dt.Rows.Count > 0)
                {
                    Amount = dt.Rows[0][0].ToString();
                    status = true;
                }
              

                db.Stop();


            }
            catch (Exception)
            {

                throw;
            }
            return status;
        }


        public bool InsertReceivePaymentWhenActive(string UserId, string RefferId, string Commission)
        {
            UserAccountDLL aUser = new UserAccountDLL();
            bool status = false;
            DataTable dt = new DataTable();
            try
            {

                LumexDBPlayer db = LumexDBPlayer.Start(true);
                aUser.InsertReceivePaymentWhenActive(UserId, RefferId, Commission, db);
                status = true;
                db.Stop();


            }
            catch (Exception)
            {

                throw;
            }
            return status;
        }

        public string Amount { get; set; }

        public bool RequestToTransfer()
        {
            UserAccountDLL aUser = new UserAccountDLL();
            bool status = false;
            DataTable dt = new DataTable();
            try
            {

                LumexDBPlayer db = LumexDBPlayer.Start(true);
                dt = aUser.RequestToTransfer(this, db);
                if (dt.Rows.Count > 0)
                {
                    transfarId = dt.Rows[0][0].ToString();
                    status = true;
                }

                db.Stop();


            }
            catch (Exception)
            {

                throw;
            }
            return status;
        }

        public string transfarType { get; set; }
        public string transfarId { get; set; }

        public DataTable getWithdrawRequestList(string fromDate, string toDate, string Status)
        {
            UserAccountDLL aUser = new UserAccountDLL();

            DataTable dt = new DataTable();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                dt = aUser.getWithdrawRequestList(fromDate, toDate, Status, db);
                db.Stop();


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                //   dt.Clear();
            }
            return dt;
        }

        public DataTable getWithdrawRequestListForUser(string UserId, string formDate, string toDate, string status)
        {
            UserAccountDLL aUser = new UserAccountDLL();

            DataTable dt = new DataTable();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                dt = aUser.getWithdrawRequestListForUser(UserId, formDate, toDate, status, db);
                db.Stop();


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                //   dt.Clear();
            }
            return dt;
        }
        public DataTable getWithdrawRequestListToUser(string UserId, string formDate, string toDate, string status)
        {
            UserAccountDLL aUser = new UserAccountDLL();

            DataTable dt = new DataTable();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                dt = aUser.getWithdrawRequestListToUser(UserId, formDate, toDate, status, db);
                db.Stop();


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                //   dt.Clear();
            }
            return dt;
        }

        public DataTable updateWithdrawRequest(string Id, string Status)
        {
            UserAccountDLL aUser = new UserAccountDLL();

            DataTable dt = new DataTable();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                dt = aUser.updateWithdrawRequest(Id, Status, db);
                db.Stop();


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                //   dt.Clear();
            }
            return dt;
        }

        public void updateUserAccountforTransfer()
        {

            UserAccountDLL aUser = new UserAccountDLL();


            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                aUser.updateUserAccountforTransfer(this, db);
                db.Stop();


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                //   dt.Clear();
            }

        }

        public bool generateDailyBonus(string Date)
        {
            UserAccountDLL aUser = new UserAccountDLL();
            bool status = false;
            DataTable dt = new DataTable();
            try
            {

                LumexDBPlayer db = LumexDBPlayer.Start(true);
                dt = aUser.generateDailyBonus(Date, db);

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
            return status;
        }

        public void InsertReceivePaymentWhenDailybonus()
        {
            UserAccountDLL aUser = new UserAccountDLL();

            DataTable dt = new DataTable();
            try
            {

                LumexDBPlayer db = LumexDBPlayer.Start(true);
                aUser.InsertReceivePaymentWhenDailybonus(db);

                db.Stop();


            }
            catch (Exception)
            {

                throw;
            }

        }

        public DataTable getGeneratedMoneyList()
        {
            UserAccountDLL aUser = new UserAccountDLL();

            DataTable dt = new DataTable();
            try
            {

                LumexDBPlayer db = LumexDBPlayer.Start(true);
                dt = aUser.getGeneratedMoneyList(db);

                db.Stop();

                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool checkUserIncomeAmounttoActin(decimal Amount, string UserId)
        {
            UserAccountDLL aUser = new UserAccountDLL();
            bool status = false;
            DataTable dt = new DataTable();
            try
            {

                LumexDBPlayer db = LumexDBPlayer.Start(true);
                dt = aUser.getAccountSummaryById(UserId, db);

                db.Stop();

                if (dt.Rows.Count > 0)
                {
                    if (Convert.ToDecimal(dt.Rows[0]["Income"].ToString()) >= Amount)
                    {
                        status = true;
                    }
                }

                return status;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertReceivePaymentWhenPinChange()
        {
            UserAccountDLL aUser = new UserAccountDLL();

            DataTable dt = new DataTable();
            try
            {

                LumexDBPlayer db = LumexDBPlayer.Start(true);
                dt = aUser.InsertReceivePaymentWhenPinChange(db);

                db.Stop();


            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool ReceivePaymentMoney(string amount)
        {
            UserAccountDLL userAccountDll = new UserAccountDLL();
            DataTable dt = new DataTable();
            bool status = false;
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                dt = userAccountDll.ReceivePaymentMoney(amount, db);

                status = true;

                db.Stop();
            }
            catch (Exception)
            {

                throw;
            }
            return status;
        }

        public decimal TransferAmount { get; set; }


        public decimal TotalAmount { get; set; }

        public string Particular { get; set; }

        public string RPType { get; set; }

        public string AffectforId { get; set; }

        public string Affectfor { get; set; }

        public string TransectionId { get; set; }

        public bool InsertReceivePaymentWhenAffectIncome()
        {
            UserAccountDLL userAccountDll = new UserAccountDLL();
            DataTable dt = new DataTable();
            bool status = false;
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                dt = userAccountDll.InsertReceivePaymentWhenAffectIncome(this, db);
                if (dt.Rows.Count > 0)
                {
                    TransectionId = dt.Rows[0][0].ToString();
                }
                status = true;

                db.Stop();
            }
            catch (Exception)
            {

                throw;
            }
            return status;
        }

        public object Status { get; set; }

        public DataTable getAccountSummaryAllUser()
        {
            UserAccountDLL aUser = new UserAccountDLL();

            DataTable dt = new DataTable();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                dt = aUser.getAccountSummaryAllUser(db);
                db.Stop();


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                //   dt.Clear();
            }
            return dt;
        }

        public DataTable getDailybounsListbyDateRange(string FromDate, string ToDate)
        {
            UserAccountDLL aUser = new UserAccountDLL();

            DataTable dt = new DataTable();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                dt = aUser.getDailybounsListbyDateRange(FromDate, ToDate, db);
                db.Stop();


            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable getDailybounsListbyDateRangeByUserId(string FromDate, string ToDate, string UserId)
        {
            UserAccountDLL aUser = new UserAccountDLL();

            DataTable dt = new DataTable();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                dt = aUser.getDailybounsListbyDateRangeByUserId(FromDate, ToDate, UserId, db);
                db.Stop();


            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetUserActivationInfoById(string UserId)
        {
            UserAccountDLL aUser = new UserAccountDLL();

            DataTable dt = new DataTable();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                dt = aUser.GetUserActivationInfoById(UserId, db);
                db.Stop();


            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }



        public DataTable getMatchingCommissionListbyDateRangeByUserId(string FromDate, string ToDate, string UserId)
        {
            UserAccountDLL aUser = new UserAccountDLL();

            DataTable dt = new DataTable();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                dt = aUser.getMatchingCommissionListbyDateRangeByUserId(FromDate, ToDate,UserId, db);
                db.Stop();


            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable getMatchingCommissionListbyDateRange(string FromDate, string ToDate)
        {
            UserAccountDLL aUser = new UserAccountDLL();

            DataTable dt = new DataTable();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                dt = aUser.getMatchingCommissionListbyDateRange(FromDate, ToDate, db);
                db.Stop();


            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public bool UpdateUserIncomeBalanceFromDeposit(string UserId, string ammount)
        {
            UserAccountDLL aUser = new UserAccountDLL();
            bool status = false;
            DataTable dt=new DataTable();
            
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                dt = aUser.UpdateUserIncomeBalanceFromDeposit(UserId, ammount, db);
                status = true;
                db.Stop();


            }
            catch (Exception)
            {

                throw;
            }

            return status;
        }

        public bool UpdateUserIncomeBalanceFromCommission(string UserId, string ammount)
        {
            UserAccountDLL aUser = new UserAccountDLL();
            bool status = false;
            DataTable dt = new DataTable();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                dt = aUser.UpdateUserIncomeBalanceFromCommission(UserId,ammount, db);
                status = true;
                db.Stop();


            }
            catch (Exception)
            {

                throw;
            }

            return status;
        }

        public DataTable getMoneyGenerateAmountById(string UserId)
        {
            UserAccountDLL aUser = new UserAccountDLL();

            DataTable dt = new DataTable();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                dt = aUser.getMoneyGenerateAmountById(UserId, db);
                db.Stop();


            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable getCommissionById(string UserId)
        {
            UserAccountDLL aUser = new UserAccountDLL();

            DataTable dt = new DataTable();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                dt = aUser.getCommissionById(UserId, db);
                db.Stop();


            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable getDailyBonusById(string UserId)
        {
            UserAccountDLL aUser = new UserAccountDLL();

            DataTable dt = new DataTable();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                dt = aUser.getDailyBonusById(UserId, db);
                db.Stop();


            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public int historyOf { get; set; }


        public DataTable getMoneyGenerateAmountByDateRangeById(string FromDate, string ToDate, string UserId)
        {
            UserAccountDLL aUser = new UserAccountDLL();

            DataTable dt = new DataTable();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                dt = aUser.getMoneyGenerateAmountByDateRangeById(FromDate, ToDate, UserId, db);
                db.Stop();


            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable getTotalMatchingCommissionListbyDateRange(string FromDate, string ToDate)
        {
            UserAccountDLL aUser = new UserAccountDLL();

            DataTable dt = new DataTable();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                dt = aUser.getTotalMatchingCommissionListbyDateRange(FromDate, ToDate, db);
                db.Stop();


            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public string CardOwnerName { get; set; }

        public string CardNumber { get; set; }

        public string CardExpireDate { get; set; }

        public string OnlineEmail { get; set; }

        public string GateWayOwnerName { get; set; }

        public string UserId { get; set; }

        public bool SavePaymentInfo()
        {
            UserAccountDLL user=new UserAccountDLL();
            bool status = false;

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                user.SavePaymentInfo(this, db);
                status = true;
                db.Stop();

            }
            catch (Exception)
            {
                throw;
            }
            return status;
        }

        public string BankName { get; set; }

        public string TypeName { get; set; }



        public DataTable GetPaymentInfoNyId(string UserId,string Type)
        {
            UserAccountDLL user = new UserAccountDLL();
            DataTable dt=new DataTable();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                dt=user.GetPaymentInfoById(UserId,Type, db);
                db.Stop();

            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }

        public DataTable GetPaymentMethodInfoBySerial(string serial)
        {
            UserAccountDLL user = new UserAccountDLL();
            DataTable dt = new DataTable();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                dt = user.GetPaymentInfoBySerial(serial, db);
                db.Stop();

            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }

        public bool UpdatePaymentInfoBySerial()
        {
            

                UserAccountDLL user = new UserAccountDLL();
                DataTable dt = new DataTable();
                bool status = false;

                try
                {
                    LumexDBPlayer db = LumexDBPlayer.Start();
                    dt = user.UpdatePaymentInfoBySerial(this,db);
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

            return status;
        }

        public DataTable GetPaymentInfoNyIdandType(string UserId, string Type)
        {
            UserAccountDLL user = new UserAccountDLL();
            DataTable dt = new DataTable();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                dt = user.GetPaymentInfoNyIdandType(UserId,Type, db);
                db.Stop();

            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }
    }
}
