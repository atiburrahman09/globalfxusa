using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Global.Core.BLL;
using Lumex.Tech;

namespace TaskMaster.HRUI.UserPrivilege
{
    public partial class UserPreviligeForBranch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                 msgbox.Visible = false;

            if (!IsPostBack)
            {
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
                DataTable dt = user.GetUserList();
                userListGridView.DataSource = dt;
                userListGridView.DataBind();

                if (dt.Rows.Count < 1)
                {
                    msgbox.Attributes.Add("class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
                }
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

                LumexSessionManager.Add("UserIdForBranch", userListGridView.Rows[row.RowIndex].Cells[0].Text.ToString());
                Response.Redirect("~/HRUI/Branch/SetUserBranch.aspx");
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
       
            }
        }
    }
}