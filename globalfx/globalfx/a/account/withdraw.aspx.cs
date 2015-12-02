﻿using System;
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
    public partial class withdraw : System.Web.UI.Page
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
            if (GridViewWithdrawRequest.Rows.Count > 0)
            {
                // generateButton.Visible = true;
                GridViewWithdrawRequest.UseAccessibleHeader = true;
                GridViewWithdrawRequest.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                    lvlIncomeWallet.Text = (('$') + dt.Rows[0]["Income"].ToString());
                    lvlDepositWallet.Text = (('$') +dt.Rows[0]["Deposit"].ToString());
                    lvlCommisionWallet.Text = (('$') + dt.Rows[0]["Commission"].ToString());
                    lvlFxFund.Text = (('$') + dt.Rows[0]["FxFund"].ToString());
                }
                else
                {

                    lvlIncomeWallet.Text = "0";
                    lvlDepositWallet.Text = "0";
                    lvlCommisionWallet.Text = "0";
                    lvlFxFund.Text = "0";
                }
            }
            catch (Exception)
            {

                // throw;
            }
        }

        public void btnRequestSend_Click(object sender, EventArgs e)
        {
            UserAccountBLL account = new UserAccountBLL();
            UserBLL userBll = new UserBLL();
            account.Type = ddlType.SelectedValue;
            account.BankAccountNo = ddlPaymentMethod.SelectedItem.Text;
            account.TransferTo = txtbxTransferTo.Text.Trim();
            account.SwiftCode = ddlPaymentMethod.SelectedValue;
            account.Pin = txtbxTransferPin.Text.Trim();
            account.TransferNote = txtbxTransferNote.Text.Trim();
            account.Amount = txtbxAmount.Text.Trim();
            account.transfarType = ddlType.SelectedValue;
            string message = "";
            if (account.checkUserIncomeAmounttoActin(30, (string)LumexSessionManager.Get("ActiveUserId")))
            {
                if (userBll.varifypin((string)LumexSessionManager.Get("ActiveUserId"), account.Pin))
                {
                    if (ddlType.SelectedValue == "1")
                    {
                        if (Convert.ToDecimal(account.Amount) < 4000)
                        {
                            if (account.TransferTo != (string)LumexSessionManager.Get("ActiveUserId") && userBll.CheckDuplicateUser(account.TransferTo))
                            {
                                account.Status = "A";
                                bool status = account.RequestToTransfer();
                                if (status)
                                {
                                    account.updateUserAccountforTransfer();
                                    account.updateWithdrawRequest(account.transfarId, "A");
                                    message =
                                        "Payment <span class='actionTopic'>Fund Transfer</span> Successfully Done. Thanks.";
                                    MyAlertBox(
                                        "var callbackOk = function () { MyOverlayStart(); window.location = \"/a/account/withdraw.aspx\"; }; SuccessAlert(\"" +
                                        "Process Succeed" + "\", \"" + message + "\", callbackOk);");

                                }

                            }
                            else
                            {
                                message =
                                    "Please Give   <span class='actionTopic'>Correct User Info </span> to Transfer.";
                                MyAlertBox(
                                    "var callbackOk = function () { MyOverlayStart(); window.location = \"/a/account/withdraw.aspx\"; }; WarningAlert(\"" +
                                    "Warning!!" + "\", \"" + message + "\", \"\");");
                            }
                        }
                        else
                        {
                            account.Status = "P";
                            bool status = account.RequestToTransfer();
                            if (status)
                            {
                                account.updateUserAccountforTransfer();
                                message =
                                    "Payment <span class='actionTopic'>Transfer Request</span> Successfully Done. Thanks.";
                                MyAlertBox(
                                    "var callbackOk = function () { MyOverlayStart(); window.location = \"/a/account/withdraw.aspx\"; }; SuccessAlert(\"" +
                                    "Process Succeed" + "\", \"" + message + "\", callbackOk);");

                            }
                        }

                    }
                    else if (ddlType.SelectedValue == "0")
                    {
                        if (Convert.ToDecimal(account.Amount) >= 30)
                        {

                            account.Status = "P";
                            bool status = account.RequestToTransfer();
                            if (status)
                            {
                                account.updateUserAccountforTransfer();
                                message =
                                    "Payment <span class='actionTopic'>Transfer Request</span> Successfully Done. Thanks.";
                                MyAlertBox(
                                    "var callbackOk = function () { MyOverlayStart(); window.location = \"/a/account/withdraw.aspx\"; }; SuccessAlert(\"" +
                                    "Process Succeed" + "\", \"" + message + "\", callbackOk);");

                            }
                        }
                        else
                        {
                            message = "You can not transfer less than <span class='actionTopic'>$30</span>, Thanks.";
                            MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/moneygerate.aspx\"; }; SuccessAlert(\"" + "Warning note!!" + "\", \"" + message + "\", \"\");");


                        }

                    }


                }
                else
                {
                    message = "Please Enter Your Correct <span class='actionTopic'>Pin</span> to Transfer.";
                    MyAlertBox(
                        "var callbackOk = function () { MyOverlayStart(); window.location = \"/a/account/withdraw.aspx\"; }; WarningAlert(\"" +
                        "Warning!!" + "\", \"" + message + "\", \"\");");
                }
            }

            else
            {
                message = "You have no sufficient  <span class='actionTopic'>Amount</span> to Transfer.";
                MyAlertBox(
                    "var callbackOk = function () { MyOverlayStart(); window.location = \"/a/account/withdraw.aspx\"; }; WarningAlert(\"" +
                    "Warning!!" + "\", \"" + message + "\", \"\");");

            }
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlType.SelectedValue == "0")
            {
                divPeson.Visible = false;
               // divBank.Visible = true;
               // divSwift.Visible = true;
                divPaymethod.Visible = true;
                LoadPaymentMethodList();
            }
            else if (ddlType.SelectedValue == "1")
            {
                divPeson.Visible = true;
               // divBank.Visible = false;
                divPaymethod.Visible = false;

            }
            else if (ddlType.SelectedValue == "2")
            {
                divPeson.Visible = false;
                // divBank.Visible = true;
                // divSwift.Visible = true;
                divPaymethod.Visible = true;
                LoadPaymentMethodList();
            }
            else if (ddlType.SelectedValue == "3")
            {
                divPeson.Visible = false;
                // divBank.Visible = true;
                // divSwift.Visible = true;
                divPaymethod.Visible = true;
                LoadPaymentMethodList();
            }

        }

        private void LoadPaymentMethodList()
        {
            try
            {
                UserAccountBLL account = new UserAccountBLL();
                string Type = "";
                if (ddlType.SelectedValue == "0")
                {
                    Type = "0";
                }
                else if (ddlType.SelectedValue == "2")
                {
                    Type = "1";
                }
                else if (ddlType.SelectedValue == "3")
                {
                    Type = "2";
                }

                DataTable dt = account.GetPaymentInfoNyIdandType((string)LumexSessionManager.Get("ActiveUserId"),Type);

                if (ddlType.SelectedValue == "0")
                {
                    ddlPaymentMethod.Items.Clear();
                    ddlPaymentMethod.DataSource = dt;
                    ddlPaymentMethod.DataTextField = "BankName";
                    ddlPaymentMethod.DataValueField = "Account";
                    ddlPaymentMethod.DataBind();
                    ddlPaymentMethod.Items.Insert(0, "Select Here..");
                    ddlPaymentMethod.SelectedIndex = 0;
                    ddlPaymentMethod.Items[0].Value = "";

                }
                else if (ddlType.SelectedValue == "2")
                {
                    ddlPaymentMethod.Items.Clear();
                    ddlPaymentMethod.DataSource = dt;
                    ddlPaymentMethod.DataTextField = "CardNo";
                    ddlPaymentMethod.DataValueField = "CardWoner";
                    ddlPaymentMethod.DataBind();
                    ddlPaymentMethod.Items.Insert(0, "Select Here..");
                    ddlPaymentMethod.SelectedIndex = 0;
                    ddlPaymentMethod.Items[0].Value = "";
                }
                else if (ddlType.SelectedValue == "3")
                {
                    ddlPaymentMethod.Items.Clear();
                    ddlPaymentMethod.DataSource = dt;
                    ddlPaymentMethod.DataTextField = "GatewayOwner";
                    ddlPaymentMethod.DataValueField = "GatewayEmail";
                    ddlPaymentMethod.DataBind();
                    ddlPaymentMethod.Items.Insert(0, "Select Here..");
                    ddlPaymentMethod.SelectedIndex = 0;
                    ddlPaymentMethod.Items[0].Value = "";
                }
            }
            catch (Exception)
            {
                
               // throw;
            }
        }
        protected void txtbxTransferTo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                usernote.Attributes.Remove("data-content");
                usernote.Attributes.Remove("data-original-title");
                UserBLL userBll = new UserBLL();
                if (txtbxTransferTo.Text != "")
                {
                    DataTable dt = userBll.GetUserInfoById(txtbxTransferTo.Text);
                    if (dt.Rows.Count > 0)
                    {
                        string TransferToName = "Name:" + dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
                        string Contactinfo = "Cell:" + dt.Rows[0]["MobileNo"].ToString() + ", Email:" +
                                             dt.Rows[0]["Email"].ToString();
                        usernote.Attributes.Add("data-content", Contactinfo);
                        usernote.Attributes.Add("data-original-title", TransferToName);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void ViewButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlStatus.SelectedValue == "P")
                {
                    GridViewWithdrawRequest.Columns[7].Visible = false;
                    GridViewWithdrawRequest.Columns[8].Visible = false;
                }
                else if (ddlStatus.SelectedValue == "R")
                {
                    // GridViewWithdrawRequest.Columns[6].Visible = false;
                    GridViewWithdrawRequest.Columns[8].Visible = false;
                }
                else if (ddlStatus.SelectedValue == "A")
                {
                    // GridViewWithdrawRequest.Columns[6].Visible = false;
                    GridViewWithdrawRequest.Columns[7].Visible = false;
                }
                if (ddlTransFlow.SelectedValue == "1")
                {
                    GridViewWithdrawRequest.Columns[1].Visible = false;
                    GridViewWithdrawRequest.Columns[2].Visible = true;
                }
                else if (ddlTransFlow.SelectedValue == "2")
                {
                    GridViewWithdrawRequest.Columns[1].Visible = true;
                    GridViewWithdrawRequest.Columns[2].Visible = false;
                }
                UserAccountBLL userAccount = new UserAccountBLL();
                DataTable dt = new DataTable();
                if (ddlTransFlow.SelectedValue == "1")
                {
                    dt = userAccount.getWithdrawRequestListForUser((string)LumexSessionManager.Get("ActiveUserId"), LumexLibraryManager.ParseAppDate(fromDateTextBox.Text), LumexLibraryManager.ParseAppDate(toDateTextBox.Text), ddlStatus.SelectedValue);
                }
                else if (ddlTransFlow.SelectedValue == "2")
                {


                    dt = userAccount.getWithdrawRequestListToUser((string)LumexSessionManager.Get("ActiveUserId"),
                       LumexLibraryManager.ParseAppDate(fromDateTextBox.Text),
                       LumexLibraryManager.ParseAppDate(toDateTextBox.Text), ddlStatus.SelectedValue);

                }
                GridViewWithdrawRequest.DataSource = dt;
                GridViewWithdrawRequest.DataBind();
                if (GridViewWithdrawRequest.Rows.Count > 0)
                {
                    // generateButton.Visible = true;
                    GridViewWithdrawRequest.UseAccessibleHeader = true;
                    GridViewWithdrawRequest.HeaderRow.TableSection = TableRowSection.TableHeader;
                }



            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            finally
            {
                //  MyAlertBox("MyOverlayStop();");
            }
        }
        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

    }
}