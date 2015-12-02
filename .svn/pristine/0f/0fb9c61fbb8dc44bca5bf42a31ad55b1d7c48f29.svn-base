using System;
using System.Data;
using System.Web.UI;
using Global.Core.BLL;
using Lumex.Tech;

namespace globalfx.setting.UserGroup
{
    public partial class Update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    LumexSessionManager.Add("CenterId", "CNT001");
                    LumexSessionManager.Add("ActiveUserId", "Developer");

                    idLabel.Text = userGroupIdForUpdateHiddenField.Value = LumexSessionManager.Get("UserGroupIdForUpdate").ToString().Trim();
                    GetUserGroupById(userGroupIdForUpdateHiddenField.Value.Trim());
                }
            }
            catch (Exception ex)
            {
                msgbox.Attributes.Add("Class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }

        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        protected void GetUserGroupById(string userGroupId)
        {
            UserGroupBLL userGroup = new UserGroupBLL();

            try
            {
                DataTable dt = userGroup.GetUserGroupById(userGroupId);

                if (dt.Rows.Count > 0)
                {
                    userGroupNameForUpdateHiddenField.Value = userGroupNameTextBox.Text = dt.Rows[0]["UserGroupName"].ToString();
                    descriptionTextBox.Text = dt.Rows[0]["Description"].ToString();
                }
                else
                {
                    msgbox.Attributes.Add("Class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
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

        protected void updateButton_Click(object sender, EventArgs e)
        {
            UserGroupBLL userGroup = new UserGroupBLL();

            try
            {
                if (userGroupIdForUpdateHiddenField.Value.Trim() == "")
                {
                    msgbox.Attributes.Add("Class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "User Group not found to update.";
                }
                else if (userGroupNameTextBox.Text == "")
                {
                    msgbox.Attributes.Add("Class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "User Group Name field is required.";
                }
                else if (descriptionTextBox.Text == "")
                {
                    msgbox.Attributes.Add("Class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Description field is required.";
                }
                else
                {
                    userGroup.UserGroupId = userGroupIdForUpdateHiddenField.Value.Trim();
                    userGroup.UserGroupName = userGroupNameTextBox.Text.Trim();
                    userGroup.Description = descriptionTextBox.Text.Trim();

                    if (!userGroup.CheckDuplicateUserGroup(userGroupNameTextBox.Text.Trim()))
                    {
                        userGroup.UpdateUserGroup();

                        userGroupNameForUpdateHiddenField.Value = "";
                        userGroupIdForUpdateHiddenField.Value = "";
                       

                        string message = " <span class='actionTopic'>" + " User Group Updated Successfully</span>.";
                        MyAlertBox("var callbackOk = function () { window.location = \"/setting/UserGroup/List.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");

                    }
                    else
                    {
                        if (userGroupNameForUpdateHiddenField.Value == userGroupNameTextBox.Text.Trim())
                        {
                            userGroup.UserGroupName = "WithOut";
                            userGroup.UpdateUserGroup();

                            userGroupNameForUpdateHiddenField.Value = "";
                            userGroupIdForUpdateHiddenField.Value = "";
                            //MyAlertBox("alert(\"User Group Updated Successfully.\"); window.location=\"/HRUI/UserGroup/List.aspx\"");

                            string message = " <span class='actionTopic'>" + " User Group Updated Successfully.</span>.";
                            MyAlertBox("var callbackOk = function () { window.location = \"/setting/UserGroup/List.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");

                        }
                        else
                        {
                            msgbox.Attributes.Add("Class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Data Duplicate!!!"; msgDetailLabel.Text = "This User Group already exist, try another one.";
                        }
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