﻿using Global.Core.BLL;
using Lumex.Tech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace globalfx
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblmsg.Visible = false;
                lblmsg.Text = "";
                if (Session["ActiveUserId"] != null)
                {
                    Response.Redirect("default.aspx");
                }
            }
            catch (Exception ex)
            {

                string message = "Somthing Going wrong Please Try Again Later!!";
                // if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtbxUserName.Text != "" && txtbxPassword.Text != "")
            {
                try
                {

                    LoginBll loginbll = new LoginBll();
                    loginbll.UserId = txtbxUserName.Text.ToString();
                    loginbll.UserPass = txtbxPassword.Text.ToString();
                    if (loginbll.VerifyPassword())
                    {
                        loginbll = loginbll.GetUserById(loginbll.UserId);
                        if (loginbll.IsVarified == "Yes")
                        {
                            LumexSessionManager.Add("UserGroupId", loginbll.UserGroup);
                            LumexSessionManager.Add("ActiveUserId", loginbll.UserId);
                            LumexSessionManager.Add("ActiveUserName", loginbll.UserName);
                            LumexSessionManager.Add("UserLastName", loginbll.LastName);
                            LumexSessionManager.Add("UserAvater", loginbll.PerPhoto);
                            LumexSessionManager.Add("isMenu", "N");
                            LumexSessionManager.Add("ActiveMenuFor", "globalapp");
                            //LumexSessionManager.Add("UserIdForView","");

                            Response.Redirect("~/default.aspx", false);
                        }
                        else
                        {
                            string message = " <span class='actionTopic'>" +" Your account is not Varified. Please Check your Email. Thanks"+ "</span>.";
                            MyAlertBox("var callbackOk = function () { window.location = \"/login.aspx\"; }; SuccessAlert(\"" +
                                "Process Succeed" + "\", \"" + message + "\", \"\");");
                        }
                    }
                    else
                    {
                        lblmsg.Visible = true;
                        lblmsg.Text = "User ID or Password is invalid.";

                    }


                }
                catch (Exception ex)
                {
                   // lblmsg.Visible = true;
                  //  lblmsg.Text = ex.ToString();
                }


            }
            else
            {
                lblmsg.Visible = true;
                lblmsg.Text = "UserName or Password field is Empty.";
            }


        }

        protected void btnForgotPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/recoverypassword.aspx");
        }
        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }
    }
}