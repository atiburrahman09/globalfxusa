using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Global.Core.BLL;
using Lumex.Tech;

namespace globalfx.a.account
{
    public partial class myaccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                getmyAccountSummary((string)LumexSessionManager.Get("ActiveUserId"));
            }
            catch (Exception)
            {

                //throw;
            }
            if (GridViewBlanceSheet.Rows.Count > 0)
            {
                // generateButton.Visible = true;
                GridViewBlanceSheet.UseAccessibleHeader = true;
                GridViewBlanceSheet.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void getmyAccountSummary(string UserId)
        {
            try
            {
                UserAccountBLL userAccount = new UserAccountBLL();
                DataTable dt = userAccount.getAccountSummaryById(UserId);
                if (dt.Rows.Count > 0)
                {
                    lvlIncome.Text = dt.Rows[0]["Income"].ToString();
                    lvlDeposit.Text =  dt.Rows[0]["Deposit"].ToString();
                    lvlCommision.Text =  dt.Rows[0]["Commission"].ToString();
                    lvlFund.Text = dt.Rows[0]["FxFund"].ToString();
                    if (Convert.ToDecimal(dt.Rows[0]["Deposit"].ToString()) > 0)
                    {
                        btnDeposit.Visible = true;
                    }
                    if (Convert.ToDecimal(dt.Rows[0]["Commission"].ToString()) > 0)
                    {
                        btnCommissionTransfer.Visible = true;

                    }
                    //if (Convert.ToDecimal(dt.Rows[0]["FxFund"].ToString()) > 0)
                    //{
                    //    btnFxFundTransfer.Visible = true;

                    //}
                }
                else
                {

                    lvlIncome.Text = "0";
                    lvlDeposit.Text = "0";
                    lvlCommision.Text = "0";
                    lvlFund.Text = "0";
                }
            }
            catch (Exception)
            {

                // throw;
            }
        }
        protected void ViewButton_Click(object sender, EventArgs e)
        {
            try
            {
                UserAccountBLL userAccount = new UserAccountBLL();
                DataTable dt = userAccount.getUserIncomeStatementById((string)LumexSessionManager.Get("ActiveUserId"), LumexLibraryManager.ParseAppDate(fromDateTextBox.Text), LumexLibraryManager.ParseAppDate(toDateTextBox.Text));

                DesignGridviewBalaceSheet(dt);

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            finally
            {
                //MyAlertBox("MyOverlayStop();");
            }
        }
        private void DesignGridviewBalaceSheet(DataTable userDt)
        {
            try
            {
                DataTable dt = new DataTable();
                DataRow dr = null;

                dt.Columns.Add(new DataColumn("TransectionId"));
                dt.Columns.Add(new DataColumn("TransectionDate"));
                dt.Columns.Add(new DataColumn("Receiveon"));
                dt.Columns.Add(new DataColumn("Particular"));
                dt.Columns.Add(new DataColumn("DebitAmount"));
                dt.Columns.Add(new DataColumn("CreditAmount"));
                dt.Columns.Add(new DataColumn("BalanceAmount"));

                if (userDt.Rows.Count > 0)
                {
                    decimal openingBalance = Convert.ToDecimal(userDt.Rows[0]["OpeningBalance"].ToString());

                    dr = dt.NewRow();
                    dr["TransecTionID"] = "";
                    dr["TransectionDate"] = "";
                    dr["Receiveon"] = "";
                    dr["Particular"] = "";
                    dr["DebitAmount"] = "";
                    dr["CreditAmount"] = "Forward Balance";
                    dr["BalanceAmount"] = openingBalance.ToString();

                    dt.Rows.Add(dr);

                    for (int i = 0; i < userDt.Rows.Count; i++)
                    {
                        dr = dt.NewRow();
                        dr["TransectionId"] = userDt.Rows[i]["TransecTionID"].ToString();
                        dr["TransectionDate"] = userDt.Rows[i]["TransectionDate"].ToString();
                        dr["Receiveon"] = userDt.Rows[i]["Receiveon"].ToString();
                        dr["Particular"] = userDt.Rows[i]["Particular"].ToString();
                        decimal Balance = Convert.ToDecimal(userDt.Rows[i]["Balance"]);
                        if (Balance > 0)
                        {
                            dr["DebitAmount"] = Balance.ToString();
                            openingBalance = openingBalance + Balance;
                            dr["CreditAmount"] = "0.00";
                            dr["BalanceAmount"] = openingBalance.ToString();

                        }
                        else
                        {
                            Balance = Balance * (-1);
                            dr["CreditAmount"] = Balance.ToString();
                            openingBalance = openingBalance - Balance;
                            dr["DebitAmount"] = "0.00";
                            dr["BalanceAmount"] = openingBalance.ToString();
                        }


                        dt.Rows.Add(dr);
                    }
                }

                GridViewBlanceSheet.DataSource = dt;
                GridViewBlanceSheet.DataBind();
                if (GridViewBlanceSheet.Rows.Count > 0)
                {
                    // generateButton.Visible = true;
                    GridViewBlanceSheet.UseAccessibleHeader = true;
                    GridViewBlanceSheet.HeaderRow.TableSection = TableRowSection.TableHeader;
                }


            }
            catch (Exception)
            {


            }
            finally
            {
                //MyAlertBox("MyOverlayStop();");
            }
        }

        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        protected void btnDepositTransfer_OnClick(Object sender, EventArgs e)
        {
            Deposit.Visible = true;
            btnDeposit.Visible = false;
        }
        protected void btnCommissionTransfer_OnClick(Object sender, EventArgs e)
        {
            Commission.Visible = true;
            btnCommissionTransfer.Visible = false;
        }
        protected void btnFxFundTransfer_OnClick(Object sender, EventArgs e)
        {
            FxFund.Visible = false;
            btnFxFundTransfer.Visible = false;
        }


        protected void btnDepositOk_OnClick(object sender, EventArgs e)
        {
            UserAccountBLL accountBll = new UserAccountBLL();
            UserBLL userBll = new UserBLL();
            bool status = false;
            accountBll.Amount = txtbxDepositAmmount.Text.Trim();
            userBll.UserId = (string)LumexSessionManager.Get("ActiveUserId");
            if (userBll.varifypin(userBll.UserId, txtbxDepositPin.Text))
            {
                if (Convert.ToDecimal(accountBll.Amount) <= Convert.ToDecimal(lvlDeposit.Text))
                {
                    status =
                        accountBll.UpdateUserIncomeBalanceFromDeposit((string) LumexSessionManager.Get("ActiveUserId"),
                            accountBll.Amount);
                    if (status)
                    {
                        string message = " <span class='actionTopic'>" + " Income Balance Updated Successfully " +
                                         "</span>.";
                        MyAlertBox(
                            "var callbackOk = function () { window.location = \"/a/account/myaccount.aspx\"; }; SuccessAlert(\"" +
                            "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                    }
                    else
                    {
                        string message = " <span class='actionTopic'>" + " Transfer Failed " +
                                         "</span>.";
                        MyAlertBox(
                            "var callbackOk = function () { window.location = \"/\"; }; WarningAlert(\"" +
                            "Warning!!" + "\", \"" + message + "\", \"\");");
                    }
                }
                else
                {
                    string message = " <span class='actionTopic'>" + "Sorry You don't have sufficent Balance." +
                                         "</span>.";
                    MyAlertBox(
                        "var callbackOk = function () { window.location = \"/\"; }; WarningAlert(\"" +
                        "Warning!!" + "\", \"" + message + "\", \"\");");
                }
            }
            else
            {
                string message = " <span class='actionTopic'>" + " Pin is Incorrect " +
                                         "</span>.";
                MyAlertBox(
                    "var callbackOk = function () { window.location = \"/\"; }; WarningAlert(\"" +
                    "Warning!!" + "\", \"" + message + "\", \"\");");
            }


        }

        protected void btnDepositCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(this.Request.Url.ToString());
        }

        protected void btnCommissionOK_OnClick(object sender, EventArgs e)
        {
            UserAccountBLL accountBll = new UserAccountBLL();
            UserBLL userBll = new UserBLL();
            accountBll.Amount = txtbxCommissionAmount.Text.Trim();
            userBll.UserId = (string) LumexSessionManager.Get("ActiveUserId");
            if (userBll.varifypin(userBll.UserId,txtbxPinCommission.Text))
            {
                if (Convert.ToDecimal(accountBll.Amount) <= Convert.ToDecimal(lvlCommision.Text))
                {
                    bool status =
                        accountBll.UpdateUserIncomeBalanceFromCommission(
                            (string) LumexSessionManager.Get("ActiveUserId"), accountBll.Amount);
                    if (status)
                    {
                        string message = " <span class='actionTopic'>" + " Income Balance Updated Successfully " +
                                         "</span>.";
                        MyAlertBox(
                            "var callbackOk = function () { window.location = \"/a/account/myaccount.aspx\"; }; SuccessAlert(\"" +
                            "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                    }
                    else
                    {
                        string message = " <span class='actionTopic'>" + " Transfer Failed " +
                                         "</span>.";
                        MyAlertBox(
                            "var callbackOk = function () { window.location = \"/\"; }; SuccessAlert(\"" +
                            "Process Succeed" + "\", \"" + message + "\", \"\");");
                    }
                }
                else
                {
                    string message = " <span class='actionTopic'>" + "Sorry You don't have sufficent Balance." +
                                         "</span>.";
                    MyAlertBox(
                        "var callbackOk = function () { window.location = \"/\"; }; WarningAlert(\"" +
                        "Warning!!" + "\", \"" + message + "\", \"\");");
                }
            }
            else
            {
                string message = " <span class='actionTopic'>" + " Invalid Pin. " +
                                         "</span>.";
                MyAlertBox(
                    "var callbackOk = function () { window.location = \"/\"; }; WarningAlert(\"" +
                    "Warning!!" + "\", \"" + message + "\", \"\");");
            }

        }

        protected void btnCommissionCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(this.Request.Url.ToString());
        }

        protected void btnFxOK_OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void btnFxCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(this.Request.Url.ToString());
        }
    }
}