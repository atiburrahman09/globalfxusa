using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Global.Core.BLL;
using Lumex.Tech;

namespace globalfx
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ViewUserInfo();
                }
            }
            catch (Exception)
            {

                // throw;
            }
        }

        private void ViewUserInfo()
        {
            UserBLL aUser = new UserBLL();
            try
            {

                //if (Session["UserIdForView"] == null)
                //{
                //    aUser.UserId = LumexSessionManager.Get("ActiveUserId").ToString();
                //}
                //else
                //{
                //    aUser.UserId = LumexSessionManager.Get("UserIdForView").ToString();
                //}
                aUser.UserId = LumexSessionManager.Get("ActiveUserId").ToString();
                lblUserId.Text = aUser.UserId;
                LumexSessionManager.Add("UserIdForUpdate", lblUserId.Text);
                DataTable dt = new DataTable();
                dt = aUser.GetUserInfoByIdForView(aUser.UserId);

                if (dt.Rows.Count > 0)
                {
                    lvlName.Text = dt.Rows[0]["FirstName"].ToString() + dt.Rows[0]["LastName"].ToString();
                    lvlEmail.Text = dt.Rows[0]["Email"].ToString();
                    lvlMobile.Text = dt.Rows[0]["MobileNo"].ToString();
                    lvlLeft.Text = dt.Rows[0]["TotalLeft"].ToString() + " [" + dt.Rows[0]["LeftCount"].ToString() + "]";
                    lvlRight.Text = dt.Rows[0]["TotalRight"].ToString() + " [" + dt.Rows[0]["RightCount"].ToString() + "]";

                    LumexSessionManager.Remove("UserIdForView");
                    if (dt.Rows[0]["IsActive"].ToString() == "Yes")
                    {

                        btnActive.Visible = false;
                        lvlIsActive.Visible = false;

                        UserAccountBLL userAccount = new UserAccountBLL();

                        dt = userAccount.GetUserActivationInfoById(lblUserId.Text);
                        lblStakeName.Text = dt.Rows[0]["StakeName"].ToString();
                        lblStakeValue.Text = (('$') + dt.Rows[0]["Invest"].ToString());
                        lblReferal.Text = dt.Rows[0]["RefferId"].ToString();
                        lblPlacement.Text = dt.Rows[0]["PleacementId"].ToString() + "(" + dt.Rows[0]["PlacePosition"].ToString() + ")";
                        lblStakeJoinDate.Text = dt.Rows[0]["JoinDate"].ToString();
                        lblActiveDate.Text = dt.Rows[0]["ActiveDate"].ToString();

                    }
                    else
                    {
                        lvlIsActive.Visible = true;
                        lvlIsActive.Text = "Click the Active button to active your account.";
                        btnActive.Visible = true;
                    }
                }
            }
            catch (Exception)
            {

                //  throw;
            }
        }

    }
}
