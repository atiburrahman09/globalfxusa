﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Global.Core.BLL;
using Lumex.Tech;

namespace globalfx.setting.User
{
    public partial class userProfile : System.Web.UI.Page
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

                if (Session["UserIdForView"] == null)
                {
                    aUser.UserId = LumexSessionManager.Get("ActiveUserId").ToString();
                }
                else
                {
                    aUser.UserId = LumexSessionManager.Get("UserIdForView").ToString();
                }

                lblUserId.Text = aUser.UserId;
                LumexSessionManager.Add("UserIdForUpdate", lblUserId.Text);
                DataTable dt = new DataTable();
                dt = aUser.GetUserInfoByIdForView(aUser.UserId);

                if (dt.Rows.Count > 0)
                {

                    lvlGivenName.Text = dt.Rows[0]["FirstName"].ToString();
                    lvlSureName.Text = dt.Rows[0]["LastName"].ToString();
                    lvlPassPortNo.Text = dt.Rows[0]["PassportNo"].ToString();
                    lvlAddress.Text = dt.Rows[0]["Address"].ToString();
                    lvlCountry.Text = dt.Rows[0]["Country"].ToString();
                    lvlStreet.Text = dt.Rows[0]["House"].ToString();
                    lvlMobileNo.Text = dt.Rows[0]["MobileNo"].ToString();
                    lvlEmail.Text = dt.Rows[0]["Email"].ToString();
                    lvlEmrgConctName.Text = dt.Rows[0]["EmrName"].ToString();
                    lvlEmrgConctAddress.Text = dt.Rows[0]["EmrAdress"].ToString();
                    lvlRelation.Text = dt.Rows[0]["RelationName"].ToString();
                    lvlEmrgConctMobile.Text = dt.Rows[0]["EmrMobile"].ToString();
                    lvlEmrgConctEmail.Text = dt.Rows[0]["EmrEmail"].ToString();
                    lvlEmrgConctCountry.Text = dt.Rows[0]["EmarCountryName"].ToString();

                    LumexSessionManager.Remove("UserIdForView");
                }
            }
            catch (Exception)
            {

                //  throw;
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            UserBLL aUser = new UserBLL();
            LinkButton lnkBtn = (LinkButton)sender;
            LumexSessionManager.Add("UserIdForUpdate", lblUserId.Text);
            Response.Redirect("~/setting/User/UserInfoList.aspx");

        }
    }
}