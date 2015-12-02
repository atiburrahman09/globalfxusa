﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Global.Core.BLL;
using Lumex.Tech;

namespace globalfx.a.stake
{
    public partial class stakekeymanage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    getStakeKeyList();
                    getStakeKeyReceivableList();
                    loadtStakeList();
                }

                gridviewsttle();
            }
            catch (Exception)
            {

                //throw;
            }

        }

        private void getStakeKeyReceivableList()
        {
            try
            {
                StakeInfoBLL stakeInfo = new StakeInfoBLL();
                DataTable dt = stakeInfo.getStakePinListBySentto((string)LumexSessionManager.Get("ActiveUserId"));
                grdviewReceiavleKey.DataSource = dt;
                grdviewReceiavleKey.DataBind();

                lblReceivableKey.Text = dt.Rows.Count.ToString();


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void gridviewsttle()
        {
            if (gridviewMyStakePin.Rows.Count > 0)
            {
                gridviewMyStakePin.UseAccessibleHeader = true;
                gridviewMyStakePin.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gridviewSendKeyList.Rows.Count > 0)
            {
                gridviewSendKeyList.UseAccessibleHeader = true;
                gridviewSendKeyList.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (grdviewReceiavleKey.Rows.Count > 0)
            {
                grdviewReceiavleKey.UseAccessibleHeader = true;
                grdviewReceiavleKey.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void getStakeKeyList()
        {
            try
            {
                StakeInfoBLL stakeInfo = new StakeInfoBLL();
                DataTable dt = stakeInfo.getStakePinListByOwner((string)LumexSessionManager.Get("ActiveUserId"));
                gridviewMyStakePin.DataSource = dt;
                gridviewMyStakePin.DataBind();
                for (int i = 0; i < gridviewMyStakePin.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(gridviewMyStakePin.Rows[i].Cells[5].Text))
                    {
                        LinkButton lnkbtn = (LinkButton)gridviewMyStakePin.Rows[i].FindControl("sendLinkButton");

                        lnkbtn.Enabled = false;
                        //break;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void sendLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;
                // Label lblUserId = (Label)userListGridView.Rows[row.RowIndex].FindControl("lblUserId");

                addNewKeyToSendList(row);
                divPinTransfer.Visible = true;
                lnkBtn.Text = "Added to Send";
                lnkBtn.Enabled = false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void ReceiveKeyLinkButton_Click(object sender, EventArgs e)
        {
            LinkButton lnkBtn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

            Label lblSerial = (Label)grdviewReceiavleKey.Rows[row.RowIndex].FindControl("lblSerial");

            StakeInfoBLL stakeInfo = new StakeInfoBLL();

            stakeInfo.updateKeyWhenReceived(lblSerial.Text, (string)LumexSessionManager.Get("ActiveUserId"));
            getStakeKeyList();
            getStakeKeyReceivableList();
            string message = " <span class='actionTopic'>" +
                                         "Key received successfully." + "</span>.";
            MyAlertBox(
                "var callbackOk = function () { window.location = \"/a/stake/stakekeymanage.aspx\"; }; WarningAlert(\"" +
                "Process Failed" + "\", \"" + message + "\", \"\");");
            // RemoveNewKeyToSendList(row);
        }
        protected void RejectKeyLinkButton_Click(object sender, EventArgs e)
        {
            LinkButton lnkBtn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

            Label lblSerial = (Label)grdviewReceiavleKey.Rows[row.RowIndex].FindControl("lblSerial");

            StakeInfoBLL stakeInfo = new StakeInfoBLL();

            stakeInfo.updateKeyWhenReject(lblSerial.Text, (string)LumexSessionManager.Get("ActiveUserId"));
            getStakeKeyList();
            getStakeKeyReceivableList();
        }

        protected void removeLinkButton_Click(object sender, EventArgs e)
        {
            LinkButton lnkBtn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;
            RemoveNewKeyToSendList(row);
        }

        private void addNewKeyToSendList(GridViewRow row)
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            try
            {

                dt.Columns.Add(new DataColumn("Serial"));
                dt.Columns.Add(new DataColumn("StakeName"));
                dt.Columns.Add(new DataColumn("StakePin"));
                for (int i = 0; i < gridviewSendKeyList.Rows.Count; i++)
                {
                    dr = dt.NewRow();

                    Label lblSerial = (Label)gridviewSendKeyList.Rows[i].FindControl("lblSerial");
                    dr["Serial"] = lblSerial.Text;
                    dr["StakeName"] = gridviewSendKeyList.Rows[i].Cells[1].Text.ToString();
                    dr["StakePin"] = gridviewSendKeyList.Rows[i].Cells[2].Text.ToString();
                    dt.Rows.Add(dr);

                }
                dr = dt.NewRow();
                Label lblSerialparent = (Label)gridviewMyStakePin.Rows[row.RowIndex].FindControl("lblSerial");
                dr["Serial"] = lblSerialparent.Text;
                dr["StakeName"] = gridviewMyStakePin.Rows[row.RowIndex].Cells[1].Text.ToString();
                dr["StakePin"] = gridviewMyStakePin.Rows[row.RowIndex].Cells[2].Text.ToString();
                dt.Rows.Add(dr);

                gridviewSendKeyList.DataSource = dt;
                gridviewSendKeyList.DataBind();
                if (gridviewSendKeyList.Rows.Count > 0)
                {
                    gridviewSendKeyList.UseAccessibleHeader = true;
                    gridviewSendKeyList.HeaderRow.TableSection = TableRowSection.TableHeader;
                }


            }
            catch (Exception)
            {

                //  throw;
            }
        }

        private void RemoveNewKeyToSendList(GridViewRow row)
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            try
            {
                string keytodelete = gridviewSendKeyList.Rows[row.RowIndex].Cells[2].Text.ToString();

                dt.Columns.Add(new DataColumn("Serial"));
                dt.Columns.Add(new DataColumn("StakeName"));
                dt.Columns.Add(new DataColumn("StakePin"));
                for (int i = 0; i < gridviewSendKeyList.Rows.Count; i++)
                {
                    dr = dt.NewRow();

                    Label lblSerial = (Label)gridviewSendKeyList.Rows[i].FindControl("lblSerial");
                    dr["Serial"] = lblSerial.Text;
                    dr["StakeName"] = gridviewSendKeyList.Rows[i].Cells[1].Text.ToString();
                    dr["StakePin"] = gridviewSendKeyList.Rows[i].Cells[2].Text.ToString();
                    dt.Rows.Add(dr);

                }


                dt.Rows.RemoveAt(row.RowIndex);

                gridviewSendKeyList.DataSource = dt;
                gridviewSendKeyList.DataBind();
                if (gridviewSendKeyList.Rows.Count > 0)
                {
                    gridviewSendKeyList.UseAccessibleHeader = true;
                    gridviewSendKeyList.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

                for (int i = 0; i < gridviewMyStakePin.Rows.Count; i++)
                {
                    if (gridviewMyStakePin.Rows[i].Cells[2].Text == keytodelete)
                    {
                        LinkButton lnkbtn = (LinkButton)gridviewMyStakePin.Rows[i].FindControl("sendLinkButton");

                        lnkbtn.Enabled = true;
                        lnkbtn.Text = "Add to Send";
                        //break;
                    }
                }
                if (gridviewSendKeyList.Rows.Count == 0)
                {
                    divPinTransfer.Visible = false;
                }

            }
            catch (Exception)
            {

                //  throw;
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
        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        protected void btnSendTo_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                DataRow dr = null;
                UserBLL user = new UserBLL();
                StakeInfoBLL stake = new StakeInfoBLL();

                if (user.varifypin((string)LumexSessionManager.Get("ActiveUserId"), txtbxUserPin.Text.Trim()))
                {
                    dt.Columns.Add(new DataColumn("Serial"));
                    dt.Columns.Add(new DataColumn("StakePin"));
                    dt.Columns.Add(new DataColumn("StakeName"));

                    for (int i = 0; i < gridviewSendKeyList.Rows.Count; i++)
                    {
                        dr = dt.NewRow();

                        Label lblSerial = (Label)gridviewSendKeyList.Rows[i].FindControl("lblSerial");
                        dr["Serial"] = lblSerial.Text;
                        dr["StakeName"] = gridviewSendKeyList.Rows[i].Cells[1].Text.ToString();
                        dr["StakePin"] = gridviewSendKeyList.Rows[i].Cells[2].Text.ToString();
                        dt.Rows.Add(dr);

                    }

                    stake.sendto = txtbxTransferTo.Text;
                    stake.transferBy = (string)LumexSessionManager.Get("ActiveUserId");
                    stake.sendSms = txtbxSendSMS.Text;
                    if (stake.sendto != stake.transferBy)
                    {
                        bool status = stake.updateKeyonTransfer(dt);

                        if (status)
                        {
                            string message = " <span class='actionTopic'>" +
                                             " This Pin is transfered successfully. Thanks" + "</span>.";
                            MyAlertBox(
                                "var callbackOk = function () { window.location = \"/a/stake/stakekeymanage.aspx\"; }; SuccessAlert(\"" +
                                "Process Success" + "\", \"" + message + "\", callbackOk);");
                        }
                    }
                    else
                    {


                        string message = " <span class='actionTopic'>" +
                                         "Key Sender and Receiver will not Same. Thanks" + "</span>.";
                        MyAlertBox(
                            "var callbackOk = function () { window.location = \"/a/stake/stakekeymanage.aspx\"; }; WarningAlert(\"" +
                            "Process Failed" + "\", \"" + message + "\", \"\");");
                    }

                }
                else
                {
                    string message = " <span class='actionTopic'>" + " This Pin is already transfered, you can not Deactive this Pin. Thanks" + "</span>.";
                    MyAlertBox(
                        "var callbackOk = function () { window.location = \"/a/stake/stakekeymanage.aspx\"; }; WarningAlert(\"" +
                        "Process Failed" + "\", \"" + message + "\", \"\");");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnReceiableKey_Click(object sender, EventArgs e)
        {
            //divreceivablekey.Visible = true;
            try
            {
                if (grdviewReceiavleKey.Rows.Count > 0)
                {
                    divreceivablekey.Visible = true;
                }
                else
                {
                    divreceivablekey.Visible = false;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnPurchaseKey_Click(object sender, EventArgs e)
        {
            try
            {
                divStakePurchase.Visible = true;

                UserAccountBLL accountBll = new UserAccountBLL();
                DataTable dt = accountBll.getAccountSummaryById((string)LumexSessionManager.Get("ActiveUserId"));

                lblIncome.Text = dt.Rows[0]["Income"].ToString();
                lblFxFund.Text = dt.Rows[0]["FxFund"].ToString();

            }
            catch (Exception)
            {

                //throw;
            }
        }
        private void loadtStakeList()
        {
            DataTable dt = new DataTable();
            StakeInfoBLL stakeInfo = new StakeInfoBLL();
            try
            {
                dt = stakeInfo.GetStakeInfoList();
                ddlstakeList.DataSource = dt;
                ddlstakeList.DataTextField = "StakeName";
                ddlstakeList.DataValueField = "StakeId";
                ddlstakeList.DataBind();
                ddlstakeList.Items.Insert(0, "Select Here..");
                ddlstakeList.SelectedIndex = 0;
                ddlstakeList.Items[0].Value = "";

            }
            catch (Exception ex)
            {

                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }
        protected void txtbxNoStake_TextChanged(object sender, EventArgs e)
        {
            try
            {
                StakeInfoBLL stakeInfo = new StakeInfoBLL();
                if (ddlstakeList.SelectedIndex != 0)
                {

                    lblStakeName.Text = ddlstakeList.SelectedItem.Text;
                    lblQuntity.Text = txtbxNoStake.Text;
                    lblUnitPrice.Text = stakeInfo.getstakeAmountByStakeId(ddlstakeList.SelectedValue).ToString();
                    lblPrice.Text = (Convert.ToDecimal(lblQuntity.Text) * Convert.ToDecimal(lblUnitPrice.Text)).ToString();
                    lblTotalPrice.Text = lblPrice.Text;

                }
                else
                {
                    lblStakeName.Text = "0";
                    lblQuntity.Text = "0.00";
                    lblUnitPrice.Text = "0.00";
                    lblPrice.Text = "0.00";
                    lblTotalPrice.Text = "0.00";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string GetSerialNumber()
        {
            Guid serialGuid = Guid.NewGuid();
            string uniqueSerial = serialGuid.ToString("N");

            string uniqueSerialLength = uniqueSerial.Substring(0, 8).ToUpper();

            char[] serialArray = uniqueSerialLength.ToCharArray();
            string finalSerialNumber = "";

            int j = 0;
            for (int i = 0; i < 8; i++)
            {
                for (j = i; j < 4 + i; j++)
                {
                    finalSerialNumber += serialArray[j];
                }
                if (j == 8)
                {
                    break;
                }
                else
                {
                    i = (j) - 1;
                    finalSerialNumber += "-";
                }
            }

            return finalSerialNumber;
        }

        protected void btnPurches_Click(object sender, EventArgs e)
        {
            try
            {

                UserAccountBLL userAccount = new UserAccountBLL();
                StakeInfoBLL stakeInfo = new StakeInfoBLL();
                UserBLL user = new UserBLL();
                if (user.varifypin((string)LumexSessionManager.Get("ActiveUserId"), txtbxUserPintoPurches.Text))
                {
                    DataTable dt = userAccount.getAccountSummaryById((string) LumexSessionManager.Get("ActiveUserId"));
                    Decimal WalletAmount = 0;
                    string totalcount = "";
                    if (ddlPaymentBy.SelectedValue == "1")
                    {
                        WalletAmount = Convert.ToDecimal(dt.Rows[0]["Income"].ToString());
                    }
                    else if (ddlPaymentBy.SelectedValue == "2")
                    {
                        WalletAmount = Convert.ToDecimal(dt.Rows[0]["FxFund"].ToString());
                    }
                    if (Convert.ToDecimal(lblTotalPrice.Text) <= WalletAmount)
                    {
                        ///NEW///

                        StakeInfoBLL stake = new StakeInfoBLL();
                        int TotalPin = Convert.ToInt16(txtbxNoStake.Text);
                        DataTable dtstake = new DataTable();
                        DataRow dr = null;
                        dtstake.Columns.Add(new DataColumn("StakeId"));
                        dtstake.Columns.Add(new DataColumn("StakePin"));
                        dtstake.Columns.Add(new DataColumn("IsActive"));

                        for (int i = 0; i < TotalPin;)
                        {
                            string pinserial = GetSerialNumber();


                            dr = dtstake.NewRow();
                            if (!stake.CheckDuplicateKey(pinserial))
                            {
                                dr["StakeId"] = ddlstakeList.SelectedValue;
                                dr["StakePin"] = pinserial;
                                dr["IsActive"] = "Yes";
                                dtstake.Rows.Add(dr);
                                i++;
                            }
                        }
                        if (dtstake.Rows.Count == TotalPin && TotalPin > 0)
                        {
                            bool status = stake.SaveGeneratedPin(dtstake);

                            if (status)
                            {
                                dt = stakeInfo.updateKeyWhenPurchase(lblQuntity.Text, lblUnitPrice.Text,
                                    ddlstakeList.SelectedValue, ddlPaymentBy.SelectedValue);
                                if (dt.Rows.Count > 0)
                                {
                                    totalcount = dt.Rows[0][0].ToString();
                                }
                                string message = " <span class='actionTopic'>" + totalcount +
                                                 "KEY purchase Successfully. Thanks" + "</span>.";
                                MyAlertBox(
                                    "var callbackOk = function () { window.location = \"/a/stake/stakekeymanage.aspx\"; }; SuccessAlert(\"" +
                                    "Process Success" + "\", \"" + message + "\",callbackOk);");
                                getStakeKeyList();
                            }
                        }
                    }
                    else
                    {
                        string message = " <span class='actionTopic'>" +
                                         "Sorry you don't have sufficent Amount to purchase KEY. Thanks" + "</span>.";
                        MyAlertBox(
                            "var callbackOk = function () { window.location = \"/a/initialdata/stakekeymanage.aspx\"; }; WarningAlert(\"" +
                            "Process Failed" + "\", \"" + message + "\", \"\");");
                    }
                }
                else
                {
                    string message = " <span class='actionTopic'>" +"Sorry Your PIN is not Correct. Input the correct one Thanks" + "</span>.";
                    MyAlertBox(
                        "var callbackOk = function () { window.location = \"/a/initialdata/stakekeymanage.aspx\"; }; WarningAlert(\"" +
                        "Process Failed" + "\", \"" + message + "\", \"\");");
                 
                    
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }

    }
}