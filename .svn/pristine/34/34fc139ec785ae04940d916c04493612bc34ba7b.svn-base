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
    public partial class paymentmethod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (GridViewPaymentMethod.Rows.Count > 0)
                {
                    GridViewPaymentMethod.UseAccessibleHeader = true;
                    GridViewPaymentMethod.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void GridviewHeadStyle()
        {
            if (GridViewPaymentMethod.Rows.Count > 0)
            {
                GridViewPaymentMethod.UseAccessibleHeader = true;
                GridViewPaymentMethod.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlType.SelectedValue == "0")
            {
                divCard.Visible = false;
                divCardExpireDate.Visible = false;
                divCardOwner.Visible = false;
                divOnlineEmail.Visible = false;
                divOwnerName.Visible = false;
                divBankName.Visible = true;
                divBank.Visible = true;
                divSwift.Visible = true;
                getPaymentMethodList((string)LumexSessionManager.Get("ActiveUserId"));

            }
            else if (ddlType.SelectedValue == "1")
            {
                divCard.Visible = true;
                divCardExpireDate.Visible = true;
                divCardOwner.Visible = true;
                divOnlineEmail.Visible = false;
                divOwnerName.Visible = false;
                divBankName.Visible = false;
                divBank.Visible = false;
                divSwift.Visible = false;
                getPaymentMethodList((string)LumexSessionManager.Get("ActiveUserId"));
            }
            else if (ddlType.SelectedValue == "2")
            {
                divCard.Visible = false;
                divCardExpireDate.Visible = false;
                divCardOwner.Visible = false;
                divOnlineEmail.Visible = true;
                divOwnerName.Visible = true;
                divBankName.Visible = false;
                divBank.Visible = false;
                divSwift.Visible = false;

                getPaymentMethodList((string)LumexSessionManager.Get("ActiveUserId"));
            }

        }

        private void getPaymentMethodList(string UserId)
        {
            UserAccountBLL account = new UserAccountBLL();
            DataTable dt = account.GetPaymentInfoNyId(UserId, ddlType.SelectedValue);
            if (ddlType.SelectedValue == "0")
            {
                //GridViewPaymentMethod.Columns["UserId"].Visible = true;
                GridViewPaymentMethod.Columns[1].Visible = true;
                GridViewPaymentMethod.Columns[2].Visible = true;
                GridViewPaymentMethod.Columns[3].Visible = true;
                GridViewPaymentMethod.Columns[4].Visible = true;
                GridViewPaymentMethod.Columns[5].Visible = true;
                //
                GridViewPaymentMethod.Columns[6].Visible = false;
                GridViewPaymentMethod.Columns[7].Visible = false;
                GridViewPaymentMethod.Columns[8].Visible = false;
                GridViewPaymentMethod.Columns[9].Visible = false;
                GridViewPaymentMethod.Columns[10].Visible = false;

                GridViewPaymentMethod.DataSource = dt;
                GridViewPaymentMethod.DataBind();
                GridviewHeadStyle();
            }
            else if (ddlType.SelectedValue == "1")
            {
                GridViewPaymentMethod.Columns[1].Visible = true;
                GridViewPaymentMethod.Columns[6].Visible = true;
                GridViewPaymentMethod.Columns[7].Visible = true;
                GridViewPaymentMethod.Columns[8].Visible = true;
                //For Others 
                GridViewPaymentMethod.Columns[2].Visible = false;
                GridViewPaymentMethod.Columns[3].Visible = false;
                GridViewPaymentMethod.Columns[4].Visible = false;
                GridViewPaymentMethod.Columns[5].Visible = false;
                GridViewPaymentMethod.Columns[9].Visible = false;
                GridViewPaymentMethod.Columns[10].Visible = false;
                GridViewPaymentMethod.DataSource = dt;
                GridViewPaymentMethod.DataBind();
                GridviewHeadStyle();
            }
            else if (ddlType.SelectedValue == "2")
            {
                GridViewPaymentMethod.Columns[1].Visible = true;
                GridViewPaymentMethod.Columns[9].Visible = true;
                GridViewPaymentMethod.Columns[10].Visible = true;
                //
                GridViewPaymentMethod.Columns[2].Visible = false;
                GridViewPaymentMethod.Columns[3].Visible = false;
                GridViewPaymentMethod.Columns[4].Visible = false;
                GridViewPaymentMethod.Columns[5].Visible = false;
                GridViewPaymentMethod.Columns[6].Visible = false;
                GridViewPaymentMethod.Columns[7].Visible = false;
                GridViewPaymentMethod.Columns[8].Visible = false;
                GridViewPaymentMethod.DataSource = dt;
                GridViewPaymentMethod.DataBind();
                GridviewHeadStyle();
            }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                UserAccountBLL account = new UserAccountBLL();
                account.Type = ddlType.SelectedValue;
                account.TypeName = ddlType.SelectedItem.Text.ToString().Trim();
                account.UserId = (string)LumexSessionManager.Get("ActiveUserId");
                account.BankName = txtbxBankName.Text.Trim();
                account.BankAccountNo = txtbxAccountNo.Text.Trim();
                account.SwiftCode = txtbxSwiftCode.Text.Trim();
                account.CardOwnerName = txtbxCardOwnerName.Text.Trim();
                account.CardNumber = txtbxCardNumber.Text.Trim();
                account.CardExpireDate = txtbxCardExpireDate.Text.Trim();
                account.GateWayOwnerName = txtbxOwnerName.Text.Trim();
                account.OnlineEmail = txtbxEmail.Text.Trim();
                string message = "";
                if (btnSubmit.Text == "Submit")
                {

                    bool status = account.SavePaymentInfo();
                    if (status)
                    {
                        message = "Your " + ddlType.SelectedItem.Text + " payment Information has been saved.";
                        MyAlertBox(
                            "var callbackOk = function () { MyOverlayStart(); window.location = \"/a/account/paymentmethod.aspx\"; }; WarningAlert(\"" +
                            "Warning!!" + "\", \"" + message + "\", \"\");");
                    }



                }
                else
                {
                    //string serial = LumexSessionManager.Get("SerialForUpdate").ToString();
                    bool status = account.UpdatePaymentInfoBySerial();
                    if (status)
                    {
                        message = "Your " + ddlType.SelectedItem.Text + " payment Information has been Updated.";
                        MyAlertBox(
                            "var callbackOk = function () { MyOverlayStart(); window.location = \"/a/account/paymentmethod.aspx\"; }; WarningAlert(\"" +
                            "Warning!!" + "\", \"" + message + "\", \"\");");
                    }
                }
            }

            catch (Exception)
            {
                //throw;
            }
        }
        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        protected void EditLinkButton_OnClick(object sender, EventArgs e)
        {
            try
            {
                UserAccountBLL user = new UserAccountBLL();
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;
                string serial = GridViewPaymentMethod.Rows[row.RowIndex].Cells[0].Text.ToString();
                LumexSessionManager.Add("SerialForUpdate", lblSerial.Text);
                DataTable dt = user.GetPaymentMethodInfoBySerial(serial);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["GatewayType"].ToString() == "0")
                    {
                        divCard.Visible = false;
                        divCardExpireDate.Visible = false;
                        divCardOwner.Visible = false;
                        divOnlineEmail.Visible = false;
                        divOwnerName.Visible = false;
                        divBankName.Visible = true;
                        divBank.Visible = true;
                        divSwift.Visible = true;
                        txtbxBankName.Text = dt.Rows[0]["BankName"].ToString();
                        txtbxAccountNo.Text = dt.Rows[0]["BankAccount"].ToString();
                        txtbxSwiftCode.Text = dt.Rows[0]["SwiftCode"].ToString();
                        btnSubmit.Text = "Update";
                        ddlType.SelectedValue = "0";
                    }
                    else if (dt.Rows[0]["GatewayType"].ToString() == "1")
                    {
                        divCard.Visible = true;
                        divCardExpireDate.Visible = true;
                        divCardOwner.Visible = true;
                        divOnlineEmail.Visible = false;
                        divOwnerName.Visible = false;
                        divBankName.Visible = false;
                        divBank.Visible = false;
                        divSwift.Visible = false;
                        txtbxCardOwnerName.Text = dt.Rows[0]["CardWoner"].ToString();
                        txtbxCardNumber.Text = dt.Rows[0]["CardNo"].ToString();
                        txtbxCardExpireDate.Text = dt.Rows[0]["ExpireDate"].ToString();
                        btnSubmit.Text = "Update";
                        ddlType.SelectedValue = "1";
                    }
                    else if (dt.Rows[0]["GatewayType"].ToString() == "2")
                    {
                        divCard.Visible = false;
                        divCardExpireDate.Visible = false;
                        divCardOwner.Visible = false;
                        divOnlineEmail.Visible = true;
                        divOwnerName.Visible = true;
                        divBankName.Visible = false;
                        divBank.Visible = false;
                        divSwift.Visible = false;
                        txtbxEmail.Text = dt.Rows[0]["GatewayEmail"].ToString();
                        txtbxOwnerName.Text = dt.Rows[0]["GatewayOwner"].ToString();
                        btnSubmit.Text = "Update";
                        ddlType.SelectedValue = "2";

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}