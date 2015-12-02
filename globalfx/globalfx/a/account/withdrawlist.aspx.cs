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
    public partial class withdrawlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception)
            {

                //throw;
            }
        }
        protected void ViewButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlStatus.SelectedValue == "P")
                {
                    GridViewWithdrawRequest.Columns[6].Visible = false;
                    GridViewWithdrawRequest.Columns[7].Visible = false;
                }
                else if (ddlStatus.SelectedValue == "R")
                {
                   // GridViewWithdrawRequest.Columns[5].Visible = false;
                    GridViewWithdrawRequest.Columns[7].Visible = false;
                    GridViewWithdrawRequest.Columns[10].Visible = false;
                    GridViewWithdrawRequest.Columns[11].Visible = false;

                }
                else if (ddlStatus.SelectedValue == "A")
                {
                   // GridViewWithdrawRequest.Columns[5].Visible = false;
                    GridViewWithdrawRequest.Columns[6].Visible = false;
                    GridViewWithdrawRequest.Columns[10].Visible = false;
                    GridViewWithdrawRequest.Columns[11].Visible = false;
                }
                UserAccountBLL userAccount = new UserAccountBLL();
                DataTable dt = userAccount.getWithdrawRequestList(LumexLibraryManager.ParseAppDate(fromDateTextBox.Text), LumexLibraryManager.ParseAppDate(toDateTextBox.Text), ddlStatus.SelectedValue);

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
                MyAlertBox("MyOverlayStop();");
            }
        }
        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }
        protected void ReceiveKeyLinkButton_Click(object sender, EventArgs e)
        {
            LinkButton lnkBtn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

            string Id = GridViewWithdrawRequest.Rows[row.RowIndex].Cells[0].Text.ToString();

            UserAccountBLL userAccount = new UserAccountBLL();

            userAccount.updateWithdrawRequest(Id, "A");

            string message = " <span class='actionTopic'>" +
                                         "Transfer Approved successfully." + "</span>.";
            MyAlertBox(
                "var callbackOk = function () { window.location = \"/a/stake/stakekeymanage.aspx\"; }; SuccessAlert(\"" +
                "Process Failed" + "\", \"" + message + "\", \"\");");
            // RemoveNewKeyToSendList(row);
            ViewButton_Click(sender, e);
        }
        protected void RejectKeyLinkButton_Click(object sender, EventArgs e)
        {
            LinkButton lnkBtn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

            string Id = GridViewWithdrawRequest.Rows[row.RowIndex].Cells[0].Text.ToString();

            UserAccountBLL userAccount = new UserAccountBLL();

            userAccount.updateWithdrawRequest(Id, "R");
            string message = " <span class='actionTopic'>" +
                                         "Transfer Reject successfully." + "</span>.";
            MyAlertBox(
                "var callbackOk = function () { window.location = \"/a/stake/stakekeymanage.aspx\"; }; WarningAlert(\"" +
                "Process Failed" + "\", \"" + message + "\", \"\");");
            ViewButton_Click(sender, e);
        }

       
    }
}