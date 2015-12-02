using System;
using System.Data;
using System.Web.UI;
using Global.Core.BLL;
using Lumex.Tech;

namespace globalfx.setting.UserGroup
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
            try
            {
                msgbox.Visible = false;
              
                

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

        protected void saveButton_Click(object sender, EventArgs e)
        {
            UserGroupBLL userGroup = new UserGroupBLL();

            try
            {
                if (userGroupNameTextBox.Text == "")
                {
                    msgbox.Attributes.Add("Class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "User Group Name field is required.";
                }
                else if (descriptionTextBox.Text == "")
                {
                    msgbox.Attributes.Add("Class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Description field is required.";
                }
                else
                {
                    userGroup.UserGroupName = userGroupNameTextBox.Text.Trim();
                    userGroup.Description = descriptionTextBox.Text.Trim();

                    if (!userGroup.CheckDuplicateUserGroup(userGroup.UserGroupName.Trim()))
                    {
                        DataTable dt = userGroup.SaveUserGroup();

                        if (dt.Rows.Count > 0)
                        {
                           // MyAlertBox("alert(\"User Group Created Successfully with User Group ID: " + dt.Rows[0][0].ToString() + " \"); window.location=\"/HRUI/UserGroup/List.aspx\"");

                            string message = " <span class='actionTopic'>" + " User Group Created Successfully with User Group ID: " + dt.Rows[0][0].ToString() + "</span>.";
                            MyAlertBox("var callbackOk = function () { window.location = \"/setting/UserGroup/List.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");

                        
                        
                        
                        
                        }
                        else
                        {
                            msgbox.Attributes.Add("Class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Failed to Create User Group!!!"; msgDetailLabel.Text = "";
                        }
                    }
                    else
                    {
                        msgbox.Attributes.Add("Class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Data Duplicate!!!"; msgDetailLabel.Text = "This User Group already exist, try another one.";
                    }
                }
            }
            catch (Exception ex)
            {
                msgbox.Attributes.Add("Class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                userGroup = null;
            }
        }
    }
}