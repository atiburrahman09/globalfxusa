﻿using System;
using System.Data;
using System.Web.UI;
using Global.Core.BLL;
using Lumex.Tech;

namespace globalfx.setting.AppMenu
{
    public partial class UpdateMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    LoadMenuApps();

                    idLabel.Text = appMenuIdForUpdateHiddenField.Value = LumexSessionManager.Get("AppMenuIdForUpdate").ToString().Trim();
                    GetMenuById(appMenuIdForUpdateHiddenField.Value.Trim());
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
                    LoadMenuGroupsByMenuAppAndType();
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

        protected void LoadMenuGroupsByMenuAppAndType()
        {
            AppMenuBLL appMenu = new AppMenuBLL();

            try
            {
                DataTable dt = appMenu.GetMenuGroupsByMenuAppAndType(menuForAppDropDownList.SelectedValue.Trim(), menuTypeDropDownList.SelectedValue.Trim());

                menuGroupDropDownList.DataSource = dt;
                menuGroupDropDownList.DataValueField = "MenuGroupId";
                menuGroupDropDownList.DataTextField = "MenuGroupName";
                menuGroupDropDownList.DataBind();
                menuGroupDropDownList.Items.Insert(0, "----------Select----------");
                menuGroupDropDownList.SelectedIndex = 0;
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

        protected void LoadMenuLevelsByMenuAppTypeAndGroup()
        {
            AppMenuBLL appMenu = new AppMenuBLL();

            try
            {
                DataTable dt = appMenu.GetMenuLevelsByMenuAppTypeAndGroup(menuForAppDropDownList.SelectedValue.Trim(), menuTypeDropDownList.SelectedValue.Trim(), menuGroupDropDownList.SelectedValue.Trim());

                menuLevelDropDownList.DataSource = dt;
                menuLevelDropDownList.DataValueField = "MenuLevel";
                menuLevelDropDownList.DataTextField = "MenuLevel";
                menuLevelDropDownList.DataBind();
                menuLevelDropDownList.Items.Insert(0, "----------Select----------");
                menuLevelDropDownList.SelectedIndex = 0;
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

        protected void LoadParentMenusByMenuAppTypeGroupAndLevel()
        {
            AppMenuBLL appMenu = new AppMenuBLL();

            try
            {
                DataTable dt = appMenu.GetParentMenusByMenuAppTypeGroupAndLevel(menuForAppDropDownList.SelectedValue.Trim(), menuTypeDropDownList.SelectedValue.Trim(), menuGroupDropDownList.SelectedValue.Trim(), menuLevelDropDownList.SelectedValue.Trim());

                parentMenuDropDownList.DataSource = dt;
                parentMenuDropDownList.DataValueField = "MenuId";
                parentMenuDropDownList.DataTextField = "MenuName";
                parentMenuDropDownList.DataBind();
                parentMenuDropDownList.Items.Insert(0, "----------Select----------");
                parentMenuDropDownList.SelectedIndex = 0;
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

        protected void LoadOnlyParentMenusByMenuAppTypeGroupAndLevel()
        {
            AppMenuBLL appMenu = new AppMenuBLL();

            try
            {
                DataTable dt = appMenu.GetOnlyParentMenusByMenuAppTypeGroupAndLevel(menuForAppDropDownList.SelectedValue.Trim(), menuTypeDropDownList.SelectedValue.Trim(), menuGroupDropDownList.SelectedValue.Trim(), menuLevelDropDownList.SelectedValue.Trim());

                filterBySubParentDropDownList.DataSource = dt;
                filterBySubParentDropDownList.DataValueField = "MenuId";
                filterBySubParentDropDownList.DataTextField = "MenuName";
                filterBySubParentDropDownList.DataBind();
                filterBySubParentDropDownList.Items.Insert(0, "All");
                filterBySubParentDropDownList.SelectedIndex = 0;
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

        protected void LoadChildMenusByParentMenuId(string parentMenuId)
        {
            AppMenuBLL appMenu = new AppMenuBLL();

            try
            {
                DataTable dt = appMenu.GetChildMenusByParentMenuId(parentMenuId);

                parentMenuDropDownList.DataSource = dt;
                parentMenuDropDownList.DataValueField = "MenuId";
                parentMenuDropDownList.DataTextField = "MenuName";
                parentMenuDropDownList.DataBind();
                parentMenuDropDownList.Items.Insert(0, "----------Select----------");
                parentMenuDropDownList.SelectedIndex = 0;
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

        protected void GetMenuById(string menuId)
        {
            AppMenuBLL appMenu = new AppMenuBLL();

            try
            {
                DataTable dt = appMenu.GetMenuById(menuId);

                if (dt.Rows.Count > 0)
                {
                    appMenuNameHiddenField.Value = menuNameTextBox.Text = dt.Rows[0]["MenuName"].ToString();
                    descriptionTextBox.Text = dt.Rows[0]["ToolTipDescription"].ToString();
                    urlTextBox.Text = dt.Rows[0]["URL"].ToString();
                    displayNameTextBox.Text = dt.Rows[0]["DisplayName"].ToString();
                    imageURLTextBox.Text = dt.Rows[0]["ImageURL"].ToString();
                    menuTargetDropDownList.SelectedValue = dt.Rows[0]["MenuTarget"].ToString();

                    LoadMenuApps();
                    menuForAppDropDownList.SelectedValue = dt.Rows[0]["MenuForApp"].ToString();

                    LoadMenuTypesByApp();
                    menuTypeDropDownList.SelectedValue = dt.Rows[0]["MenuType"].ToString();

                    LoadMenuGroupsByMenuAppAndType();
                    menuGroupDropDownList.SelectedValue = dt.Rows[0]["MenuGroupId"].ToString();

                    menuDisplayDropDownList.SelectedValue = dt.Rows[0]["IsDisplay"].ToString();

                    LoadMenuLevelsByMenuAppTypeAndGroup();
                    menuLevelDropDownList.SelectedValue = dt.Rows[0]["ParentMenuLevel"].ToString();
                    LoadOnlyParentMenusByMenuAppTypeGroupAndLevel();

                    LoadParentMenusByMenuAppTypeGroupAndLevel();
                    parentMenuDropDownList.SelectedValue = dt.Rows[0]["ParentMenuId"].ToString();

                    menuDefaultDropDownList.SelectedValue = dt.Rows[0]["IsDefault"].ToString();
                    subParentMenuDropDownList.SelectedValue = dt.Rows[0]["IsSubParent"].ToString();
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
                    msgbox.Attributes.Add("Class", "alert alert-warning");
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

        protected void updateButton_Click(object sender, EventArgs e)
        {
            AppMenuBLL appMenu = new AppMenuBLL();

            try
            {
                if (menuNameTextBox.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu Name field is required.";
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
                else if (menuForAppDropDownList.Text == "----------Select----------")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu For App. field is required.";
                    msgbox.Attributes.Add("Class", "alert alert-warning");
                }
                else if (menuTypeDropDownList.Text == "----------Select----------")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu Type field is required.";
                    msgbox.Attributes.Add("Class", "alert alert-warning");
                }
                else if (menuGroupDropDownList.Text == "----------Select----------")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu Group field is required.";

                    msgbox.Attributes.Add("Class", "alert alert-warning");
                }
                else if (menuDisplayDropDownList.Text == "----------Select----------")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu Display field is required.";
                    msgbox.Attributes.Add("Class", "alert alert-warning");
                }
                else if (menuLevelDropDownList.Text == "----------Select----------")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu Level field is required.";
                    msgbox.Attributes.Add("Class", "alert alert-warning");
                }
                else if (parentMenuDropDownList.Text == "----------Select----------")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Parent Menu field is required.";
                    msgbox.Attributes.Add("Class", "alert alert-warning");
                }
                else if (menuDefaultDropDownList.Text == "----------Select----------")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu Default field is required.";
                    msgbox.Attributes.Add("Class", "alert alert-warning");
                }
                else if (subParentMenuDropDownList.Text == "----------Select----------")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Use as Sub-Parent field is required.";
                    msgbox.Attributes.Add("Class", "alert alert-warning");
                }
                else
                {
                    appMenu.MenuId = idLabel.Text.Trim();
                    appMenu.MenuName = menuNameTextBox.Text.Trim();
                    appMenu.DisplayName = displayNameTextBox.Text.Trim();
                    appMenu.ToolTipDescription = descriptionTextBox.Text.Trim();
                    appMenu.URL = urlTextBox.Text.Trim();
                    appMenu.MenuForApp = menuForAppDropDownList.SelectedValue.Trim();
                    appMenu.MenuType = menuTypeDropDownList.SelectedValue.Trim();
                    appMenu.MenuGroupId = menuGroupDropDownList.SelectedValue.Trim();
                    appMenu.IsDisplay = menuDisplayDropDownList.SelectedValue.Trim();
                    appMenu.MenuLevel = menuLevelDropDownList.SelectedValue.Trim();
                    appMenu.ParentMenuId = parentMenuDropDownList.SelectedValue.Trim();
                    appMenu.IsDefault = menuDefaultDropDownList.SelectedValue.Trim();
                    appMenu.IsSubParent = subParentMenuDropDownList.SelectedValue.Trim();
                    appMenu.MenuTarget = menuTargetDropDownList.SelectedValue.Trim();
                    appMenu.ImageUrl = imageURLTextBox.Text.Trim();

                    if (!appMenu.CheckDuplicateMenu(menuNameTextBox.Text.Trim()))
                    {
                        appMenu.UpdateMenu();

                        appMenuIdForUpdateHiddenField.Value = "";
                        appMenuNameHiddenField.Value = "";
                        MyAlertBox("alert(\"Menu Updated Successfully.\"); window.location=\"/setting/AppMenu/MenuList.aspx\"");
                    }
                    else
                    {
                        if (appMenuNameHiddenField.Value == menuNameTextBox.Text.Trim())
                        {
                            appMenu.MenuName = "WithOut";
                            appMenu.UpdateMenu();

                            appMenuIdForUpdateHiddenField.Value = "";
                            appMenuNameHiddenField.Value = "";
                            MyAlertBox("alert(\"Menu Updated Successfully.\"); window.location=\"/setting/AppMenu/MenuList.aspx\"");
                        }
                        else
                        {
                            msgbox.Visible = true; msgTitleLabel.Text = "Data Duplicate!!!"; msgDetailLabel.Text = "This Menu already exist, try another one.";
                            msgbox.Attributes.Add("Class", "alert alert-warning");
                        }
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
            if (menuForAppDropDownList.SelectedValue == "----------Select----------")
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu For App. field is required.";
                msgbox.Attributes.Add("Class", "alert alert-warning");
            }
            else
            {
                LoadMenuTypesByApp();
            }
        }

        protected void menuTypeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (menuTypeDropDownList.SelectedValue == "----------Select----------")
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu Type field is required.";
                msgbox.Attributes.Add("Class", "alert alert-warning");
            }
            else
            {
                LoadMenuGroupsByMenuAppAndType();
            }
        }

        protected void menuGroupDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (menuGroupDropDownList.SelectedValue == "----------Select----------")
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu Group field is required.";
                msgbox.Attributes.Add("Class", "alert alert-warning");
            }
            else
            {
                LoadMenuLevelsByMenuAppTypeAndGroup();
            }
        }

        protected void menuLevelDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (menuLevelDropDownList.SelectedValue == "----------Select----------")
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu Level field is required.";
                msgbox.Attributes.Add("Class", "alert alert-warning");
            }
            else
            {
                LoadParentMenusByMenuAppTypeGroupAndLevel();
                LoadOnlyParentMenusByMenuAppTypeGroupAndLevel();
            }
        }

        protected void filterBySubParentDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filterBySubParentDropDownList.SelectedValue.Trim() == "All")
            {
                LoadParentMenusByMenuAppTypeGroupAndLevel();
            }
            else
            {
                LoadChildMenusByParentMenuId(filterBySubParentDropDownList.SelectedValue.Trim());
            }
        }
    }
}