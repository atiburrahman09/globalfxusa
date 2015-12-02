﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Global.Core.BLL;
using Lumex.Tech;

namespace globalfx.setting.User
{
    public partial class UserInfoList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                if ((string)LumexSessionManager.Get("UserGroupId") == "UG001")
                {
                    txtbxEmail.ReadOnly = false;
                    txtbxCell.ReadOnly = false;

                }
                else
                {
                    txtbxEmail.ReadOnly = true;
                    txtbxCell.ReadOnly = true;
                }
                getCountryData();
                //getRelationData();
                UpdateUserInfo();

            }



        }
        //protected void txtbxUserName_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        iconuserName.Attributes.Remove("class");
        //        lblUsernameNote.Visible = false;
        //        UserBLL user = new UserBLL();
        //        Regex reg = new Regex(@"^[a-z0-9_-]{5,15}$");

        //        if (reg.IsMatch(txtbxUserName.Text))
        //        {
        //            if (user.CheckDuplicateUser(txtbxUserName.Text.Trim()))
        //            {
        //                //  iconuserName.Attributes.Remove("class");
        //                iconuserName.Attributes.Add("class", "icon icon-ban-circle text-error");
        //                hdnfldduplicate.Value = "1";
        //                txtbxUserName.Focus();
        //            }
        //            else
        //            {
        //                // iconuserName.Attributes.Remove("class");
        //                iconuserName.Attributes.Add("class", "icon icon-ok-sign text-success");
        //                hdnfldduplicate.Value = "0";
        //                txtbxFirstName.Focus();
        //            }
        //        }
        //        else
        //        {
        //            lblUsernameNote.Visible = true;
        //            lblUsernameNote.Text = "User Name must be 5-15 char small letter alpha char (_ allow) ei. jhonsmith_ or jhonsmith ";

        //        }
        //    }
        //    catch (Exception)
        //    {

        //        //throw;
        //    }
        //}

        private void getRelationData()
        {
            DataTable dt = new DataTable();
            initialDataBLL LookUpBll = new initialDataBLL();
            LookUpBll.ElementGroupId = "EG002";
            try
            {
                dt = LookUpBll.GetElementDataListByGroupId();
                ddlContactRelation.DataSource = dt;
                ddlContactRelation.DataTextField = "Name";
                ddlContactRelation.DataValueField = "Id";
                ddlContactRelation.DataBind();
                ddlContactRelation.Items.Insert(0, "Select Relation..");
                ddlContactRelation.SelectedIndex = 0;
                ddlContactRelation.Items[0].Value = "";
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                UserBLL aUserBll = new UserBLL();

                if (txtbxFirstName.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "First Name field is required.";
                    msgbox.Attributes.Add("Class", "alert alert-warning");
                    txtbxFirstName.Focus();
                }
                else if (txtbxLastName.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Last Name field is required.";
                    msgbox.Attributes.Add("Class", "alert alert-warning");
                    txtbxLastName.Focus();
                }
                else if (txtbxAddress.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Address field is required.";
                    msgbox.Attributes.Add("Class", "alert alert-warning");
                    txtbxAddress.Focus();
                }
                else if (txtbxHouse.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "House No field is required.";
                    msgbox.Attributes.Add("Class", "alert alert-warning");
                    txtbxHouse.Focus();
                }
                else if (txtbxStreet.Text == "")
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Street field is required.";
                    msgbox.Attributes.Add("Class", "alert alert-warning");
                    txtbxStreet.Focus();
                }
                else if (txtbxCell.Text == "")
                {
                    msgbox.Visible = true;
                    msgTitleLabel.Text = "Validation!!!";
                    msgDetailLabel.Text = "Cell Number field is required.";
                    msgbox.Attributes.Add("Class", "alert alert-warning");
                    txtbxCell.Focus();
                }

                else
                {
                    UserBLL aUser = new UserBLL();
                    LoginBll login = new LoginBll();
                    aUser.UserId = txtbxUserName.Text;
                    aUser.FirstName = txtbxFirstName.Text.Trim();
                    aUser.LastName = txtbxLastName.Text.Trim();
                    aUser.PassportNo = txtbxPassportNo.Text.Trim();
                    aUser.Address = txtbxAddress.Text.Trim();
                    aUser.Country = ddlCountry.SelectedValue;
                    aUser.House = txtbxHouse.Text.Trim();
                    aUser.Street = txtbxStreet.Text.Trim();
                    aUser.Area = txtbxArea.Text.Trim();
                    aUser.MobileNo = txtbxCell.Text.Trim();
                    aUser.Email = txtbxEmail.Text.Trim();
                    aUser.EmrName = txtcontactPerson.Text.Trim();
                    aUser.EmrAddress = txtbxContactAddress.Text.Trim();
                    aUser.EmrRelation = ddlContactRelation.SelectedValue;
                    aUser.EmrMobile = txtbxContactMobile.Text.Trim();
                    aUser.EmeEmail = txtContactEmail.Text.Trim();
                    aUser.EmeCountry = ddlContactCountry.SelectedValue;
                    aUser.IsActive = "No";
                    aUser.Isvarified = "No";
                    aUser.Createdby = LumexSessionManager.Get("ActiveUserId").ToString();
                    aUser.CreatedFrom = LumexLibraryManager.GetTerminal();
                    aUser.UserGroupId = "UG003";
                    aUser.PerPhoto = "";



                    bool status = aUserBll.UpdateUserInfo(aUser);
                    if (status)
                    {
                        string message = " <span class='actionTopic'>" + " Data Update Successfully as Id: " +
                                         aUser.UserId + "</span>.";
                        MyAlertBox(
                            "var callbackOk = function () { window.location = \"/a/stake/create.aspx\"; }; SuccessAlert(\"" +
                            "Process Succeed" + "\", \"" + message + "\", \"\");");
                    }
                    else
                    {
                        string message = " <span class='actionTopic'>" + " Data Update Successfully as Id: " +
                                         aUser.UserId + "</span>.";
                        MyAlertBox(
                            "var callbackOk = function () { window.location = \"/a/stake/create.aspx\"; }; SuccessAlert(\"" +
                            "Process Succeed" + "\", \"" + message + "\", \"\");");
                    }
                }

            }
            catch (Exception)
            {

                //  throw;
            }

        }
        private void getCountryData()
        {
            DataTable dt = new DataTable();
            initialDataBLL LookUpBll = new initialDataBLL();
            LookUpBll.ElementGroupId = "EG001";
            try
            {
                dt = LookUpBll.GetElementDataListByGroupId();
                ddlCountry.DataSource = dt;
                ddlCountry.DataTextField = "ElementName";
                ddlCountry.DataValueField = "ElementId";
                ddlCountry.DataBind();
                ddlCountry.Items.Insert(0, "Select Country..");
                ddlCountry.SelectedIndex = 0;
                ddlCountry.Items[0].Value = "";

                ddlContactCountry.DataSource = dt;
                ddlContactCountry.DataTextField = "ElementName";
                ddlContactCountry.DataValueField = "ElementId";
                ddlContactCountry.DataBind();
                ddlContactCountry.Items.Insert(0, "Select Country..");
                ddlContactCountry.SelectedIndex = 0;
                ddlContactCountry.Items[0].Value = "";

            }
            catch (Exception ex)
            {

                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }


        protected void UpdateUserInfo()
        {
            UserBLL aUser = new UserBLL();

            try
            {

                aUser.UserId = LumexSessionManager.Get("UserIdForUpdate").ToString();
                DataTable dt = new DataTable();
                dt = aUser.GetUserInfoById(aUser.UserId);
                hdnfldduplicate.Value = aUser.UserId;
                if (dt.Rows.Count > 0)
                {
                    txtbxUserName.Text = dt.Rows[0]["UserId"].ToString();
                    txtbxFirstName.Text = dt.Rows[0]["FirstName"].ToString();
                    txtbxLastName.Text = dt.Rows[0]["LastName"].ToString();
                    txtbxPassportNo.Text = dt.Rows[0]["PassportNo"].ToString();
                    txtbxAddress.Text = dt.Rows[0]["Address"].ToString();
                    ddlCountry.SelectedValue = dt.Rows[0]["Country"].ToString();
                    txtbxHouse.Text = dt.Rows[0]["House"].ToString();
                    txtbxStreet.Text = dt.Rows[0]["Street"].ToString();
                    txtbxArea.Text = dt.Rows[0]["Area"].ToString();
                    txtbxCell.Text = dt.Rows[0]["MobileNo"].ToString();
                    txtbxEmail.Text = dt.Rows[0]["Email"].ToString();
                    txtcontactPerson.Text = dt.Rows[0]["EmrName"].ToString();
                    txtbxContactAddress.Text = dt.Rows[0]["EmrAdress"].ToString();
                    ddlContactRelation.SelectedValue = dt.Rows[0]["RelationName"].ToString();
                    txtbxContactMobile.Text = dt.Rows[0]["EmrMobile"].ToString();
                    txtContactEmail.Text = dt.Rows[0]["EmrEmail"].ToString();
                    ddlContactCountry.SelectedValue = dt.Rows[0]["EmarCountryName"].ToString();
                    //aUser.IsActive = dt.Rows[0]["IsActive"].ToString();
                    //aUser.Isvarified = dt.Rows[0]["IsVarified"].ToString();
                    //aUser.Createdby = dt.Rows[0]["CreatedBy"].ToString();
                    //aUser.CreatedFrom = dt.Rows[0]["CreatedFrom"].ToString();
                    //aUser.UserGroupId = dt.Rows[0]["UserGroupId"].ToString();
                    //aUser.PerPhoto = dt.Rows[0]["PerPhoto"].ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnCancel_Click(Object sender, EventArgs e)
        {
            Response.Redirect("/setting/User/userProfile.aspx");
        }

    }
}