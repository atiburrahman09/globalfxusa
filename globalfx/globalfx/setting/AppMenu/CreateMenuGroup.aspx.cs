using System;
using System.Data;
using System.Web.UI;
using Global.Core.BLL;

namespace globalfx.setting.AppMenu
{
    public partial class CreateMenuGroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    urlTextBox.Text = "javascript:void(0)";

                    LoadMenuApps();
                }

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

        protected void LoadMenuApps()
        {
            AppMenuBLL appMenu = new AppMenuBLL();

            try
            {
                DataTable dt = appMenu.GetMenuApps();

                menuForAppDropDownList.DataSource = dt;
                menuForAppDropDownList.DataValueField = "MenuForApp";
                menuForAppDropDownList.DataTextField = "MenuForApp";
                menuForAppDropDownList.DataBind();

                if (dt.Rows.Count == 1)
                {
                    menuForAppDropDownList.SelectedIndex = 0;
                    LoadMenuTypesByApp();
                }
                else
                {
                    menuForAppDropDownList.Items.Insert(0, "----------Select----------");
                    menuForAppDropDownList.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
                msgbox.Attributes.Add("Class", "alert alert-warning");
            }
            finally
            {
                appMenu = null;
            }
        }

        protected void LoadMenuTypesByApp()
        {
            AppMenuBLL appMenu = new AppMenuBLL();

            try
            {
                DataTable dt = appMenu.GetMenuTypesByApp(menuForAppDropDownList.SelectedValue.Trim());

                menuTypeDropDownList.DataSource = dt;
                menuTypeDropDownList.DataValueField = "MenuType";
                menuTypeDropDownList.DataTextField = "MenuType";
                menuTypeDropDownList.DataBind();

                if (dt.Rows.Count == 1)
                {
                    menuTypeDropDownList.SelectedIndex = 0;
                }
                else
                {
                    menuTypeDropDownList.Items.Insert(0, "----------Select----------");
                    menuTypeDropDownList.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
                msgbox.Attributes.Add("Class", "alert alert-warning");
            }
            finally
            {
                appMenu = null;
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            AppMenuBLL appMenu = new AppMenuBLL();

            try
            {
                if (menuGroupNameTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu Group Name field is required.";
                    msgbox.Attributes.Add("Class", "alert alert-warning");
                }
                else if (displayNameTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Display Name field is required.";
                    msgbox.Attributes.Add("Class", "alert alert-warning");
                }
                else if (urlTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu URL field is required.";
                    msgbox.Attributes.Add("Class", "alert alert-warning");
                }
                else if (menuTypeDropDownList.Text == "----------Select----------")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu Type field is required.";
                    msgbox.Attributes.Add("Class", "alert alert-warning");
                }
                else if (menuForAppDropDownList.Text == "----------Select----------")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu For App. field is required.";
                    msgbox.Attributes.Add("Class", "alert alert-warning");
                }
                else
                {
                    appMenu.MenuGroupName = menuGroupNameTextBox.Text.Trim();
                    appMenu.DisplayName = displayNameTextBox.Text.Trim();
                    appMenu.ToolTipDescription = descriptionTextBox.Text.Trim();
                    appMenu.URL = urlTextBox.Text.Trim();
                    appMenu.MenuType = menuTypeDropDownList.SelectedValue.Trim();
                    appMenu.MenuForApp = menuForAppDropDownList.SelectedValue.Trim();
                    appMenu.MenuTarget = menuTargetDropDownList.SelectedValue.Trim();
                    appMenu.ImageUrl = imageURLTextBox.Text.Trim();

                    if (!appMenu.CheckDuplicateMenuGroup(appMenu.MenuGroupName))
                    {
                        DataTable dt = appMenu.SaveMenuGroup();

                        if (dt.Rows.Count > 0)
                        {
                            MyAlertBox("alert(\"Menu Group Created Successfully with Menu Group ID: " + dt.Rows[0][0].ToString() + " \"); window.location=\"/setting/AppMenu/MenuGroupList.aspx\"");
                        }
                        else
                        {
                            msgbox.Visible = true; msgTitleLabel.Text = "Failed to Create Menu Group!!!"; msgDetailLabel.Text = "";
                            msgbox.Attributes.Add("Class", "alert alert-warning");
                        }
                    }
                    else
                    {
                        msgbox.Visible = true; msgTitleLabel.Text = "Data Duplicate!!!"; msgDetailLabel.Text = "This Menu Group already exist, try another one.";
                        msgbox.Attributes.Add("Class", "alert alert-warning");
                    }
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
                msgbox.Attributes.Add("Class", "alert alert-warning");
            }
            finally
            {
                appMenu = null;
            }
        }

        protected void menuForAppDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMenuTypesByApp();
        }
    }
}