using System;
using System.Data;
using System.Web.UI;
using Global.Core.BLL;
using Lumex.Tech;

namespace globalfx.setting.User
{
    public partial class View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    idLabel.Text = userIdForViewHiddenField.Value = LumexSessionManager.Get("UserIdForView").ToString().Trim();
                    GetUserById(userIdForViewHiddenField.Value.Trim());
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
                msgbox.Attributes.Add("Class","alert alert-warning");
            }
        }

        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        protected void GetUserById(string userId)
        {
            UserBLL user = new UserBLL();

            try
            {
                DataTable dt = user.GetUserById(userId);

                if (dt.Rows.Count > 0)
                {
                    userIdLabel.Text = dt.Rows[0]["UserId"].ToString();
                    userNameLabel.Text = dt.Rows[0]["UserName"].ToString();
                    //employeeIdLabel.Text = dt.Rows[0]["EmployeeId"].ToString();
                    //departmentLabel.Text = dt.Rows[0]["Department"].ToString();
                    //designationLabel.Text = dt.Rows[0]["Designation"].ToString();
                    //addressLabel.Text = dt.Rows[0]["Address"].ToString();
                    contactNumberLabel.Text = dt.Rows[0]["ContactNumber"].ToString();
                    emailLabel.Text = dt.Rows[0]["Email"].ToString();
                    //nationalIdLabel.Text = dt.Rows[0]["NationalId"].ToString();
                    //passportNumberLabel.Text = dt.Rows[0]["PassportNumber"].ToString();
                    userGroupLabel.Text = dt.Rows[0]["UserGroupName"].ToString();
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
                user = null;
            }
        }
    }
}