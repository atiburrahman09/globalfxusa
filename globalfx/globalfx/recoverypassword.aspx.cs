using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Global.Core.BLL;
using Lumex.Tech;

namespace globalfx
{
    public partial class recoverypassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSave_OnClick_Click(object sender, EventArgs e)
        {
            UserBLL aUser = new UserBLL();
            aUser.UserId = txtbxUserId.Text.Trim();
            aUser.MobileNo = txtbxMobileNo.Text.Trim();
            DataTable dt = new DataTable();
            dt = aUser.GetUserInfoById(aUser.UserId);
            if (dt.Rows.Count > 0)
            {
                if (txtbxMobileNo.Text == dt.Rows[0]["MobileNo"].ToString() && txtbxUserId.Text == dt.Rows[0]["UserId"].ToString())
                {
                    string email = dt.Rows[0]["Email"].ToString();
                    try
                    {
                        UserBLL userBll = new UserBLL();
                        bool status = userBll.CheckUserIdOrMailForResetPass(email);

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

                                MyAlertBox("var callbackOk = function () { window.location = \"index.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");


                            }
                            else
                            {
                                string message = " <span class='actionTopic'>" + "Sorry !! Mail Not Send to this User Please Check User mail or ID is Correct !!!" + "</span>.";
                                MyAlertBox("var callbackOk = function () { window.location = \"recoverpassword.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
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
                else
                {
                    string message = " <span class='actionTopic'>" + " Invalid Mobile Number " +
                                          "</span>.";
                    MyAlertBox(
                        "var callbackOk = function () { window.location = \"passwordrecovary.aspx\"; }; SuccessAlert(\"" +
                        "Process Succeed" + "\", \"" + message + "\", \"\");");
                }
            }
            else
            {
                string message = " <span class='actionTopic'>" + " User Id Invalid " +
                                          "</span>.";
                MyAlertBox(
                    "var callbackOk = function () { window.location = \"passwordrecovary.aspx\"; }; SuccessAlert(\"" +
                    "Process Succeed" + "\", \"" + message + "\", \"\");");
            }

        }
        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }
    }
}