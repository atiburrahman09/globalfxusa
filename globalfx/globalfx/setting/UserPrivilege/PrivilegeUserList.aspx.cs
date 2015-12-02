using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Global.Core.BLL;
using Lumex.Tech;

namespace globalfx.setting.UserPrivilege
{
    public partial class PrivilegeUserList : System.Web.UI.Page
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
        private void GridviewHeadStyle()
        {
            if (userListGridView.Rows.Count > 0)
            {
                userListGridView.UseAccessibleHeader = true;
                userListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        //private void GetBranch()
        //{
        //    DataTable dt = new DataTable();
        //    BranchBLL branchBll = new BranchBLL();
        //    try
        //    {

        //        dt = branchBll.GetBranchList();
        //        if (dt.Rows.Count > 0)
        //        {
        //            BranchDropDownList.DataSource = dt;
        //            BranchDropDownList.DataValueField = "BranchId";
        //            BranchDropDownList.DataTextField = "Name";


        //            BranchDropDownList.DataBind();

        //            BranchDropDownList.Items.Insert(0, "----------Select----------");
        //            //    BranchDropDownList.SelectedIndex = 0;
        //            BranchDropDownList.SelectedValue = (string)LumexSessionManager.Get("UserBranchId");


        //        }
        //        dt.Clear();

        //    }
        //    catch (Exception ex)
        //    {

        //        string message = ex.Message;
        //        if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
        //        MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
        //    }
        //}
        protected void GetUserList()
        {
            UserBLL user = new UserBLL();

            try
            {
                DataTable dt = user.GetUserListByBruchId(LumexSessionManager.Get("UserBranchId").ToString());
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
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
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
        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        protected void setMenuLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                LumexSessionManager.Add("UserIdForSetMenu", userListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());
                Response.Redirect("~/setting/UserPrivilege/SetUserMenu.aspx");
            }
            catch (Exception ex)
            {
                msgbox.Attributes.Add("Class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }
    }
}