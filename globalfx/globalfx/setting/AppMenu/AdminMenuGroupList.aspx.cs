using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Global.Core.BLL;


namespace globalfx.setting.AppMenu
{
    public partial class AdminMenuGroupList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    LoadMenuApps();
                    GetMenuGroupList();
                }

                if (menuGroupListGridView.Rows.Count > 0)
                {
                    menuGroupListGridView.UseAccessibleHeader = true;
                    menuGroupListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                msgbox.Attributes.Add("Class","alert alert-warning");
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
                    menuTypeDropDownList.Items.Insert(1, "All");
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

        protected void GetMenuGroupList()
        {
            AppMenuBLL appMenu = new AppMenuBLL();

            try
            {
                DataTable dt = appMenu.GetMenuGroupList();
                menuGroupListGridView.DataSource = dt;
                menuGroupListGridView.DataBind();

                if (menuGroupListGridView.Rows.Count > 0)
                {
                    menuGroupListGridView.UseAccessibleHeader = true;
                    menuGroupListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

                if (dt.Rows.Count < 1)
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

        protected void GetMenuGroupListByMenuAppAndType()
        {
            AppMenuBLL appMenu = new AppMenuBLL();

            try
            {
                DataTable dt = appMenu.GetMenuGroupsByMenuAppAndType(menuForAppDropDownList.SelectedValue.Trim(), menuTypeDropDownList.SelectedValue.Trim());
                menuGroupListGridView.DataSource = dt;
                menuGroupListGridView.DataBind();

                if (menuGroupListGridView.Rows.Count > 0)
                {
                    menuGroupListGridView.UseAccessibleHeader = true;
                    menuGroupListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

                if (dt.Rows.Count < 1)
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

        protected void activateLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                AppMenuBLL appMenu = new AppMenuBLL();
                appMenu.UpdateMenuGroupActivation(menuGroupListGridView.Rows[row.RowIndex].Cells[0].Text.ToString(), "True");

                MyAlertBox("alert(\"Menu Group Activated Successfully.\"); window.location=\"/setting/AppMenu/MenuGroupList.aspx\"");
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
                msgbox.Attributes.Add("Class", "alert alert-warning");
            }
        }

        protected void deactivateLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                AppMenuBLL appMenu = new AppMenuBLL();
                appMenu.UpdateMenuGroupActivation(menuGroupListGridView.Rows[row.RowIndex].Cells[0].Text.ToString(), "False");

                MyAlertBox("alert(\"Menu Group Deactivated Successfully.\"); window.location=\"/setting/AppMenu/MenuGroupList.aspx\"");
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
                msgbox.Attributes.Add("Class", "alert alert-warning");
            }
        }

        protected void menuForAppDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMenuTypesByApp();
        }

        protected void getGroupListButton_Click(object sender, EventArgs e)
        {
            if (menuForAppDropDownList.Text == "----------Select----------")
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu For App. field is required.";
            }
            else if (menuTypeDropDownList.Text == "----------Select----------")
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Menu Type field is required.";
            }
            else
            {
                GetMenuGroupListByMenuAppAndType();
            }
        }

        protected void getAllGroupListButton_Click(object sender, EventArgs e)
        {
            GetMenuGroupList();
        }
    }
}