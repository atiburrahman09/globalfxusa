using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Global.Core.BLL;
using Lumex.Tech;

namespace globalfx.setting.UserPrivilege
{
    public partial class SetUserMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    LoadUserInfo(LumexSessionManager.Get("UserIdForSetMenu").ToString().Trim());
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

        private void PopulateUserMenu()
        {
            AppMenuBLL appMenu = new AppMenuBLL();

            try
            {
                DataTable dtUserMenu = appMenu.GetUserMenuData(userIdLabel.Text.Trim(), menuForAppDropDownList.SelectedValue.Trim(), menuTypeDropDownList.SelectedValue.Trim());
                DataTable dtAllMenu = appMenu.GetAllMenusForMappingUserMenu(menuForAppDropDownList.SelectedValue.Trim(), menuTypeDropDownList.SelectedValue.Trim());
                DataRow dr = null;

                for (int i = 0; i < dtUserMenu.Rows.Count; i++)
                {
                    for (int j = 0; j < dtAllMenu.Rows.Count; j++)
                    {
                        if (dtUserMenu.Rows[i]["ParentMenuId"].ToString() == dtAllMenu.Rows[j]["MenuId"].ToString())
                        {
                            dr = dtUserMenu.NewRow();

                            dr["MenuId"] = dtAllMenu.Rows[j]["MenuId"].ToString();
                            dr["MenuName"] = dtAllMenu.Rows[j]["MenuName"].ToString();
                            dr["ToolTipDescription"] = dtAllMenu.Rows[j]["ToolTipDescription"].ToString();
                            dr["ParentMenuId"] = dtAllMenu.Rows[j]["ParentMenuId"].ToString();
                            dr["URL"] = dtAllMenu.Rows[j]["URL"].ToString();
                            dr["MenuSorting"] = dtAllMenu.Rows[j]["MenuSorting"].ToString();
                            dr["DisplayName"] = dtAllMenu.Rows[j]["DisplayName"].ToString();
                            dr["ImageURL"] = dtAllMenu.Rows[j]["ImageURL"].ToString();
                            dr["MenuTarget"] = dtAllMenu.Rows[j]["MenuTarget"].ToString();

                            dtUserMenu.Rows.Add(dr);
                        }
                    }
                }

                ///////////////////////////////to convert column data type////////////////////////////////
                //DataTable dtCloned = dtUserMenu.Clone();
                //dtCloned.Columns["UserMenuSorting"].DataType = typeof(Int32);
                //foreach (DataRow row in dtUserMenu.Rows)
                //{
                //    dtCloned.ImportRow(row);
                //}

                dtUserMenu = dtUserMenu.DefaultView.ToTable(true, "MenuId", "MenuName", "ToolTipDescription", "ParentMenuId", "URL", "MenuSorting", "DisplayName", "MenuTarget", "ImageURL");
                dtUserMenu.DefaultView.Sort = "MenuSorting";
                dtUserMenu = dtUserMenu.DefaultView.ToTable();

                ///////////////////////////////to sort by column(s)///////////////////////////////////////
                //if (dtUserMenu.Rows.Count > 0)
                //{
                //    DataView dv = dtUserMenu.DefaultView;
                //    dv.Sort = "UserMenuSorting";
                //    dtUserMenu = dv.ToTable();
                //}

                if (dtUserMenu.Rows.Count > 0)
                {
                   // testAllMenu.Items.Clear();
                    AddTopMenuItems(dtUserMenu);
                }
                else
                {
                    //msgbox.Visible = true; msgTitleLabel.Text = "User Menu Not Found!!!"; msgDetailLabel.Text = "";
                }
            }
            catch (Exception ex)
            {
                msgbox.Attributes.Add("class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                appMenu = null;
            }
        }

        private void PopulateAllMenu()
        {
            AppMenuBLL appMenu = new AppMenuBLL();

            try
            {
                DataTable dt = appMenu.GetAllMenuData(menuForAppDropDownList.SelectedValue.Trim(), menuTypeDropDownList.SelectedValue.Trim());

                if (dt.Rows.Count > 0)
                {
                    //testAllMenu.Items.Clear();
                    AddTopMenuItems(dt);
                }
                else
                {
                    msgbox.Attributes.Add("class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
                }
            }
            catch (Exception ex)
            {
                msgbox.Attributes.Add("class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                appMenu = null;
            }
        }

        private void AddTopMenuItems(DataTable menuData)
        {
            DataView view = new DataView(menuData);
            view.RowFilter = "ParentMenuId=0";

            foreach (DataRowView row in view)
            {
                MenuItem newMenuItem = new MenuItem(row["DisplayName"].ToString(), row["MenuId"].ToString());
                newMenuItem.NavigateUrl = "javascript:void(0)"; //row["URL"].ToString();
                newMenuItem.ToolTip = row["ToolTipDescription"].ToString();
                //newMenuItem.SeparatorImageUrl = "~/Content/Images/home.png";
                //newMenuItem.PopOutImageUrl = "~/Content/Images/home.png";
                newMenuItem.Target = row["MenuTarget"].ToString();
                newMenuItem.ImageUrl = row["ImageURL"].ToString();
                //testAllMenu.Items.Add(newMenuItem);
                AddChildMenuItems(menuData, newMenuItem);
            }
        }

        private void AddChildMenuItems(DataTable menuData, MenuItem parentMenuItem)
        {
            DataView view = new DataView(menuData);
            view.RowFilter = "ParentMenuId=" + parentMenuItem.Value;

            foreach (DataRowView row in view)
            {
                MenuItem newMenuItem = new MenuItem(row["DisplayName"].ToString(), row["MenuId"].ToString());
                newMenuItem.NavigateUrl = "javascript:void(0)"; //row["URL"].ToString();
                newMenuItem.ToolTip = row["ToolTipDescription"].ToString();
                //newMenuItem.SeparatorImageUrl = "~/Content/Images/home.png";
                //newMenuItem.PopOutImageUrl = "~/Content/Images/home.png";
                newMenuItem.Target = row["MenuTarget"].ToString();
                newMenuItem.ImageUrl = row["ImageURL"].ToString();
                parentMenuItem.ChildItems.Add(newMenuItem);
                AddChildMenuItems(menuData, newMenuItem);
            }
        }

        protected void allMenuImageButton_Click(object sender, ImageClickEventArgs e)
        {
            if (menuForAppDropDownList.Text == "----------Select----------")
            {
                msgbox.Attributes.Add("class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu For App. field is required.";
            }
            else if (menuTypeDropDownList.Text == "----------Select----------")
            {
                msgbox.Attributes.Add("class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu Type field is required.";
            }
            else
            {
                PopulateAllMenu();
            }
        }

        protected void refreshMenuImageButton_Click(object sender, ImageClickEventArgs e)
        {
            if (menuForAppDropDownList.Text == "----------Select----------")
            {
                msgbox.Attributes.Add("class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu For App. field is required.";
            }
            else if (menuTypeDropDownList.Text == "----------Select----------")
            {
                msgbox.Attributes.Add("class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu Type field is required.";
            }
            else
            {
                PopulateUserMenu();
            }
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
                msgbox.Attributes.Add("class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
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
                    PopulateUserMenu();
                }
                else
                {
                    menuTypeDropDownList.Items.Insert(0, "----------Select----------");
                    menuTypeDropDownList.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                msgbox.Attributes.Add("class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
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

                if (dt.Rows.Count > 1)
                {
                    menuGroupDropDownList.SelectedIndex = 1;
                    userMenuPane.Visible = true;
                    GetMenuListToPrivilegeUser();
                    GetPrivilegedMenuByUser();
                }
            }
            catch (Exception ex)
            {
                msgbox.Attributes.Add("class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                appMenu = null;
            }
        }

        protected void LoadUserInfo(string userId)
        {
            UserBLL user = new UserBLL();

            try
            {
                DataTable dt = user.GetUserById(userId);

                if (dt.Rows.Count > 0)
                {
                    userIdLabel.Text = dt.Rows[0]["UserId"].ToString();
                    userNameLabel.Text = dt.Rows[0]["UserName"].ToString();
                 //  employeeIdLabel.Text = dt.Rows[0]["EmployeeId"].ToString();
                    userGroupNameLabel.Text = dt.Rows[0]["UserGroupId"].ToString();
                   // activeStatusLabel.Text = dt.Rows[0]["IsActive"].ToString();

                    userPriviligePane.Visible = true;
                }
                else
                {
                    userPriviligePane.Visible = false;
                    msgbox.Attributes.Add("class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
                }
            }
            catch (Exception ex)
            {
                msgbox.Attributes.Add("class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                user = null;
            }
        }

        protected void menuForAppDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            userMenuPane.Visible = false;
            menuTypeDropDownList.Items.Clear();
            menuGroupDropDownList.Items.Clear();
            //testAllMenu.Items.Clear();
            groupWiseMenuListListBox.Items.Clear();
            countMenuLabel.Text = "Total: " + groupWiseMenuListListBox.Items.Count.ToString();
            groupWiseUserMenuListListBox.Items.Clear();
            countUserMenuLabel.Text = "Total: " + groupWiseUserMenuListListBox.Items.Count.ToString();

            if (menuForAppDropDownList.SelectedValue == "----------Select----------")
            {
                msgbox.Attributes.Add("class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu For App. field is required.";
            }
            else
            {
                LoadMenuTypesByApp();
            }
        }

        protected void menuTypeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            userMenuPane.Visible = false;
            menuGroupDropDownList.Items.Clear();
            //testAllMenu.Items.Clear();
            groupWiseMenuListListBox.Items.Clear();
            countMenuLabel.Text = "Total: " + groupWiseMenuListListBox.Items.Count.ToString();
            groupWiseUserMenuListListBox.Items.Clear();
            countUserMenuLabel.Text = "Total: " + groupWiseUserMenuListListBox.Items.Count.ToString();

            if (menuTypeDropDownList.SelectedValue == "----------Select----------")
            {
                msgbox.Attributes.Add("class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu Type field is required.";
            }
            else
            {
                LoadMenuGroupsByMenuAppAndType();
                PopulateUserMenu();
            }
        }

        protected void menuGroupDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupWiseMenuListListBox.Items.Clear();
            countMenuLabel.Text = "Total: " + groupWiseMenuListListBox.Items.Count.ToString();
            groupWiseUserMenuListListBox.Items.Clear();
            countUserMenuLabel.Text = "Total: " + groupWiseUserMenuListListBox.Items.Count.ToString();

            if (menuGroupDropDownList.SelectedValue == "----------Select----------")
            {
                userMenuPane.Visible = false;
                msgbox.Attributes.Add("class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu Group field is required.";
            }
            else
            {
                userMenuPane.Visible = true;
                GetMenuListToPrivilegeUser();
                GetPrivilegedMenuByUser();
            }
        }
        //************************
        protected void GetMenuListToPrivilegeUser()
        {
            AppMenuBLL appMenuBLL = new AppMenuBLL();

            try
            {
                groupWiseMenuListListBox.Items.Clear();

                DataTable dt = appMenuBLL.GetMenuListToPrivilegeUser(LumexSessionManager.Get("ActiveUserId").ToString(),menuForAppDropDownList.SelectedValue.Trim(), menuTypeDropDownList.SelectedValue.Trim(), menuGroupDropDownList.SelectedValue.Trim() );

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        groupWiseMenuListListBox.Items.Add(new ListItem(dt.Rows[i]["MenuName"].ToString(), dt.Rows[i]["MenuId"].ToString()));
                    }
                }
                else
                {
                    msgbox.Attributes.Add("class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "User Menu Not Found!!!"; msgDetailLabel.Text = "";
                }
            }
            catch (Exception ex)
            {
                msgbox.Attributes.Add("class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                appMenuBLL = null;
                countMenuLabel.Text = "Total: " + groupWiseMenuListListBox.Items.Count.ToString();
            }
        }

        protected void GetPrivilegedMenuByUser()
        {
            AppMenuBLL appMenuBLL = new AppMenuBLL();

            try
            {
                groupWiseUserMenuListListBox.Items.Clear();

                DataTable dt = appMenuBLL.GetPrivilegedMenuByUser(userIdLabel.Text.Trim(), menuForAppDropDownList.SelectedValue.Trim(), menuTypeDropDownList.SelectedValue.Trim(), menuGroupDropDownList.SelectedValue.Trim());

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        groupWiseUserMenuListListBox.Items.Add(new ListItem(dt.Rows[i]["MenuName"].ToString(), dt.Rows[i]["MenuId"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                appMenuBLL = null;
                countUserMenuLabel.Text = "Total: " + groupWiseUserMenuListListBox.Items.Count.ToString();
            }
        }

        protected void removeAllButton_Click(object sender, EventArgs e)
        {
            try
            {
                groupWiseUserMenuListListBox.Items.Clear();
                countUserMenuLabel.Text = "Total: " + groupWiseUserMenuListListBox.Items.Count.ToString();
            }
            catch (Exception ex)
            {
                msgbox.Attributes.Add("class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }

        protected void addAllButton_Click(object sender, EventArgs e)
        {
            try
            {
                groupWiseUserMenuListListBox.Items.Clear();

                for (int i = 0; i < groupWiseMenuListListBox.Items.Count; i++)
                {
                    groupWiseUserMenuListListBox.Items.Add(new ListItem(groupWiseMenuListListBox.Items[i].Text, groupWiseMenuListListBox.Items[i].Value));
                }

                countUserMenuLabel.Text = "Total: " + groupWiseUserMenuListListBox.Items.Count.ToString();
            }
            catch (Exception ex)
            {
                msgbox.Attributes.Add("class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }

        protected void removeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (groupWiseUserMenuListListBox.SelectedIndex > -1)
                {
                    groupWiseUserMenuListListBox.Items.RemoveAt(groupWiseUserMenuListListBox.SelectedIndex);
                }

                countUserMenuLabel.Text = "Total: " + groupWiseUserMenuListListBox.Items.Count.ToString();
            }
            catch (Exception ex)
            {
                msgbox.Attributes.Add("class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (groupWiseMenuListListBox.SelectedIndex > -1)
                {
                    for (int i = 0; i < groupWiseUserMenuListListBox.Items.Count; i++)
                    {
                        if (groupWiseUserMenuListListBox.Items[i].Value == groupWiseMenuListListBox.SelectedValue) { return; }
                    }

                    groupWiseUserMenuListListBox.Items.Add(new ListItem(groupWiseMenuListListBox.SelectedItem.Text, groupWiseMenuListListBox.SelectedItem.Value));
                    groupWiseUserMenuListListBox.SelectedIndex = groupWiseUserMenuListListBox.Items.Count - 1;
                }

                countUserMenuLabel.Text = "Total: " + groupWiseUserMenuListListBox.Items.Count.ToString();
            }
            catch (Exception ex)
            {
                msgbox.Attributes.Add("class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            AppMenuBLL appMenuBLL = new AppMenuBLL();
            List<string> userPrivilegeMenus = new List<string>();

            try
            {
                if (menuForAppDropDownList.Text == "----------Select----------")
                {
                    msgbox.Attributes.Add("class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu For App. field is required.";
                }
                else if (menuTypeDropDownList.Text == "----------Select----------")
                {
                    msgbox.Attributes.Add("class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu Type field is required.";
                }
                else if (menuGroupDropDownList.Text == "----------Select----------")
                {
                    msgbox.Attributes.Add("class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu Group field is required.";
                }
                else
                {
                    for (int i = 0; i < groupWiseUserMenuListListBox.Items.Count; i++)
                    {
                        userPrivilegeMenus.Add(groupWiseUserMenuListListBox.Items[i].Value.Trim());
                    }

                    appMenuBLL.SaveUserPrivilegeMenu(userIdLabel.Text.Trim(), menuForAppDropDownList.SelectedValue.Trim(), menuTypeDropDownList.SelectedValue.Trim(), menuGroupDropDownList.SelectedValue.Trim(), userPrivilegeMenus);

                    PopulateUserMenu();
                    //MyAlertBox("alert(\"User's Menu List Saved Successfully.\");");
                    string message = " <span class='actionTopic'>" + " User's Menu List Saved Successfully.</span>.";
                    MyAlertBox("var callbackOk = function () { window.location = \"\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");
                    
                }
            }
            catch (Exception ex)
            {
                msgbox.Attributes.Add("class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
            finally
            {
                appMenuBLL = null;
                userPrivilegeMenus = null;
            }
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/setting/UserPrivilege/PrivilegeUserList.aspx");
        }
    }
}