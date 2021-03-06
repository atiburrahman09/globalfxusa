﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Global.Core.BLL;
using Lumex.Tech;

namespace globalfx.a.stake
{
    public partial class pin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                if (!IsPostBack)
                {
                    loadtStakeList();
                    GetGeneratedPinList();
                }

                if (gridviewStakePin.Rows.Count > 0)
                {
                    gridviewStakePin.UseAccessibleHeader = true;
                    gridviewStakePin.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                msgbox.Visible = false;
            }
            catch (Exception)
            {

              //  throw;
            }
        }

        private void GetGeneratedPinList()
        {
            try
            {
                StakeInfoBLL stakeInfo = new StakeInfoBLL();
                DataTable dt = stakeInfo.getGeneratedPinList();
                gridviewStakePin.DataSource = dt;
                gridviewStakePin.DataBind();

                if (dt.Rows.Count > 0)
                {
                    // PinStatistic

                    string[] pindata = dt.Rows[0]["PinStatistic"].ToString().Split('/');

                    lblTotalUsed.Text = pindata[0];
                    lblTotalActive.Text = pindata[1];
                    lblTotalGenerate.Text = dt.Rows.Count.ToString();
                    lblTotalInactive.Text =
                        (int.Parse(lblTotalGenerate.Text) - int.Parse(lblTotalActive.Text)).ToString();
                }
            }
            catch (Exception)
            {

                // throw;
            }
        }

        private void loadtStakeList()
        {
            DataTable dt = new DataTable();
            StakeInfoBLL stakeInfo = new StakeInfoBLL();
            try
            {
                dt = stakeInfo.GetStakeInfoList();
                ddlStakeList.DataSource = dt;
                ddlStakeList.DataTextField = "StakeName";
                ddlStakeList.DataValueField = "StakeId";
                ddlStakeList.DataBind();
                ddlStakeList.Items.Insert(0, "Select Here..");
                ddlStakeList.SelectedIndex = 0;
                ddlStakeList.Items[0].Value = "";

            }
            catch (Exception ex)
            {

                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }
        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                LoginBll loginbll = new LoginBll();
                loginbll.UserId = (string)LumexSessionManager.Get("ActiveUserId");
                loginbll.UserPass = txtbxPassword.Text.Trim();
                if (loginbll.VerifyPassword())
                {

                    StakeInfoBLL stake = new StakeInfoBLL();
                    int TotalPin = Convert.ToInt16(txtbxTotalPin.Text);
                    DataTable dt = new DataTable();
                    DataRow dr = null;
                    dt.Columns.Add(new DataColumn("StakeId"));
                    dt.Columns.Add(new DataColumn("StakePin"));
                    dt.Columns.Add(new DataColumn("IsActive"));
                    for (int i = 0; i < TotalPin; )
                    {
                        Random random = new Random();

                       
                        string pinserial = GetSerialNumber();


                        dr = dt.NewRow();
                        if (!stake.CheckDuplicateKey(pinserial))
                        {
                            dr["StakeId"] = ddlStakeList.SelectedValue;
                            dr["StakePin"] = pinserial;
                            dr["IsActive"] = "Yes";
                            dt.Rows.Add(dr);
                            i++;
                        }
                    }
                    if (dt.Rows.Count == TotalPin && TotalPin > 0)
                    {

                        bool status = stake.SaveGeneratedPin(dt);
                        if (status)
                        {
                            UserAccountBLL accountBll = new UserAccountBLL();  
                            accountBll.TotalAmount = Convert.ToDecimal(txtbxTotalPin.Text)*
                                                  stake.getstakeAmountByStakeId(ddlStakeList.SelectedValue);
                            accountBll.Particular = "Generate PIN Amount-" + accountBll.TotalAmount.ToString() + " of Stake" +
                                                ddlStakeList.SelectedItem.Text;
                            accountBll.RPType = "CR";
                            accountBll.AffectforId = "";
                            accountBll.Affectfor = "PIN Generate";

                            accountBll.InsertReceivePaymentWhenAffectIncome();



                            GetGeneratedPinList();
                            string message = " <span class='actionTopic'> The" + TotalPin.ToString() +
                                             " is Generated successfully. Thanks" + "</span>.";
                            MyAlertBox(
                                "var callbackOk = function () { window.location = \"/a/initialdata/initialDataElement.aspx\"; }; SuccessAlert(\"" +
                                "Process Succeed" + "\", \"" + message + "\", \"\");");
                        }
                    }
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Password Miss Match!!"; msgDetailLabel.Text = "Sorry your given password don't Match. Try Correct one.";
                    msgbox.Attributes.Add("Class", "alert alert-warning");


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
        protected void editLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                //    LumexSessionManager.Add("AppMenuIdForUpdate", menuListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());
                //    Response.Redirect("~/setting/AppMenu/UpdateMenu.aspx");
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
                msgbox.Attributes.Add("Class", "alert alert-warning");
            }
        }
        protected void activateLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                StakeInfoBLL stakeInfo = new StakeInfoBLL();

                string serial = gridviewStakePin.Rows[row.RowIndex].Cells[0].Text.ToString();
                string IsActive = "Yes";
                if (gridviewStakePin.Rows[row.RowIndex].Cells[7].Text.ToString() == "yes")
                {
                    string message = " <span class='actionTopic'>" + " This Pin Already Used you can not Deactive this Pin. Thanks" + "</span>.";
                    MyAlertBox(
                        "var callbackOk = function () { window.location = \"/a/initialdata/initialDataElement.aspx\"; }; WarningAlert(\"" +
                        "Process Failed" + "\", \"" + message + "\", \"\");");
                }
                else if (gridviewStakePin.Rows[row.RowIndex].Cells[9].Text.ToString() != (string)LumexSessionManager.Get("ActiveUserId"))
                {
                    string message = " <span class='actionTopic'>" + " This Pin is already transfered, you can not Deactive this Pin. Thanks" + "</span>.";
                    MyAlertBox(
                        "var callbackOk = function () { window.location = \"/a/initialdata/initialDataElement.aspx\"; }; WarningAlert(\"" +
                        "Process Failed" + "\", \"" + message + "\", \"\");");
                }
                else
                {
                    if (lnkBtn.Text == "Active")
                    {
                        IsActive = "Yes";
                    }
                    else
                    {
                        IsActive = "No";
                    }
                    stakeInfo.UpdateStakePinActivation(serial, IsActive);
                    string message = " <span class='actionTopic'>" + " This Pin activation updated Successfully. Thanks" + "</span>.";
                    MyAlertBox(
                        "var callbackOk = function () { window.location = \"/a/initialdata/initialDataElement.aspx\"; }; SuccessAlert(\"" +
                        "Process Succeed" + "\", \"" + message + "\", \"\");");

                    GetGeneratedPinList();
                }

                //   appMenu.UpdateMenuActivation(menuListGridView.Rows[row.RowIndex].Cells[0].Text.ToString(), "True");

                // MyAlertBox("alert(\"Menu Activated Successfully.\"); window.location=\"/setting/AppMenu/MenuList.aspx\"");
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
                msgbox.Attributes.Add("Class", "alert alert-warning");
            }
        }
    }
}