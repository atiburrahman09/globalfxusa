﻿using System;
using System.Data;
using System.Web.UI;
using Global.Core.BLL;
using Lumex.Tech;
using System.Web.UI.WebControls;
using System.Web;

namespace globalfx.setting.User
{
    public partial class ResetUserPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    // GetBranch();
                    GetUserList();
                }



                if (userListGridView.Rows.Count > 0)
                {
                    userListGridView.UseAccessibleHeader = true;
                    userListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {

                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void GetUserList()
        {
            UserBLL user = new UserBLL();

            try
            {
                DataTable dt = user.GetActiveUserList();
                userListGridView.DataSource = dt;
                userListGridView.DataBind();

                if (dt.Rows.Count < 1)
                {
                    msgbox.Attributes.Add("Class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
                }
                GridviewHeadStyle();
            }
            catch (Exception ex)
            {
                msgbox.Attributes.Add("Class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                user = null;
            }
        }
        protected void drpdownCenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetUserList();
        }
        protected void btnresetPass_click(object sender, EventArgs e)
        {
            UserBLL userBll = new UserBLL();
            Button Btn = (Button)sender;
            GridViewRow row = (GridViewRow)Btn.NamingContainer;
            userBll.UserId = userListGridView.Rows[row.RowIndex].Cells[0].Text.ToString();
            try
            {
                
                bool status = userBll.CheckUserIdOrMailForResetPass(userBll.UserId);

                //varificationSection.Visible = true;
                //userCheckSection.Visible = false;
                if (status)
                {
                    Random random = new Random();

                    MailContactBLL mailContactBll = new MailContactBLL();
                    userBll.varifycode = random.Next(100000, 999998) + 1;

                    string key = dataEncryptbll.addforvarifycore;
                    string encrypeteduid = dataEncryptbll.EncryptRijndael(userBll.UserId + "#" + userBll.varifycode, key);
                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                    string[] Partsofurl = url.Split('/');
                    userBll.ActivationUrl = Server.HtmlEncode("http://" + Partsofurl[2] + "/page/varify.aspx/?uid=" + encrypeteduid);


                    bool mailSend = mailContactBll.SendEmailForPasswordReset(userBll);

                    if (mailSend)
                    {
                        string message = " <span class='actionTopic'>" + "Your mail Send Successfully. Please Cheak your Mail Inbox or Spam" + "</span>.";

                        MyAlertBox("var callbackOk = function () { window.location = \"/setting/User/ResetUserPassword.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");


                    }
                    else
                    {
                        string message = " <span class='actionTopic'>" + "Sorry !! Mail Not Send to this User Please Check User mail or ID is Correct !!!" + "</span>.";
                        MyAlertBox("var callbackOk = function () { window.location = \"/setting/User/ResetUserPassword.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                    }

                }
                else
                {
                    msgbox.Attributes.Add("Class", "alert alert-warning");
                    msgbox.Visible = true;
                    msgTitleLabel.Text = "Exception";
                    msgDetailLabel.Text = "User Id or Email is Not Correct";
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void blockLinkButton_Click(object sender, EventArgs e)
        {

            LinkButton Btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)Btn.NamingContainer;
            string UserId = userListGridView.Rows[row.RowIndex].Cells[0].Text.ToString();
            string Status = "";
            try
            {
                if (userListGridView.Rows[row.RowIndex].Cells[6].Text.ToString() == "Yes")
                {
                    Status = "No";
                }
                else
                {
                    Status = "Yes";
                }
                UserBLL userBll = new UserBLL();

                userBll.UpdateUserActivation(UserId, Status);

                string message = " <span class='actionTopic'>" + "Your mail Send Successfully. Please Cheak your Mail Inbox or Spam" + "</span>.";

                MyAlertBox("var callbackOk = function () { window.location = \"/setting/User/ResetUserPassword.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");



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
        private void GridviewHeadStyle()
        {
            if (userListGridView.Rows.Count > 0)
            {
                userListGridView.UseAccessibleHeader = true;
                userListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        //protected void GetUserById(string userId)
        //{
        //    UserBLL user = new UserBLL();

        //    try
        //    {
        //        DataTable dt = user.GetUserById(userId);

        //        if (dt.Rows.Count > 0)
        //        {
        //            userIdLabel.Text = dt.Rows[0]["UserId"].ToString();
        //            userNameLabel.Text = dt.Rows[0]["UserName"].ToString();
        //            //employeeIdLabel.Text = dt.Rows[0]["EmployeeId"].ToString();
        //            userGroupLabel.Text = dt.Rows[0]["UserGroupName"].ToString();
        //            contactNumberLabel.Text = dt.Rows[0]["ContactNumber"].ToString();

        //            actionPane.Visible = true;
        //        }
        //        else
        //        {
        //            actionPane.Visible = false;
        //            msgbox.Visible = true;
        //            msgTitleLabel.Text = "User Data Not Found!!!";
        //            msgDetailLabel.Text = "";
        //            msgbox.Attributes.Add("class", "alert alert-warning");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message;
        //        if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
        //        MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
        //    }
        //    finally
        //    {
        //        user = null;
        //        MyAlertBox("MyOverlayStop();");
        //    }
        //}

        //protected void getUserInfoButton_Click(object sender, EventArgs e)
        //{
        //    GetUserById(userIdTextBox.Text.Trim());
        //}

        //protected void passwordResetButton_Click(object sender, EventArgs e)
        //{
        //    UserBLL user = new UserBLL();

        //    try
        //    {
        //        if (string.IsNullOrEmpty(newPasswordTextBox.Text.Trim()))
        //        {
        //            msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "New Password field is required.";
        //        }
        //        else if (string.IsNullOrEmpty(confirmNewPasswordTextBox.Text.Trim()))
        //        {
        //            msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Confirm New Password field is required.";
        //        }
        //        else if (newPasswordTextBox.Text.Trim() != confirmNewPasswordTextBox.Text.Trim())
        //        {
        //            msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "New Password & Confirm New Password do not match.";
        //        }
        //        else
        //        {
        //            user.UserId = userIdLabel.Text.Trim();
        //            user.Password = newPasswordTextBox.Text.Trim();
        //            user.UpdateUserPassword(user.UserId, user.Password);

        //            string message = "User <span class='actionTopic'>Password Reset</span> Successfully.";
        //            MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/HRUI/User/ResetUserPassword.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message;
        //        if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
        //        MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
        //    }
        //    finally
        //    {
        //        user = null;
        //    }
        //}
    }
}