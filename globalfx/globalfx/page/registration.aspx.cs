using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Global.Core.DAL;
using Lumex.Tech;
using Global.Core.BLL;
using globalfx.setting.User;
using System.Text.RegularExpressions;

namespace globalfx.page
{
    public partial class registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                if (!IsPostBack)
                {

                    string imp = Request.QueryString["u"];
                    if (imp != null)
                    {
                        imp = imp.Replace(" ", "+");
                        string paraval = urlencrp.DESDecrypt(imp);
                        if (!string.IsNullOrEmpty(paraval))
                        {
                            string[] splitval = paraval.Split('#');
                            if (splitval.Length > 0)
                            {
                                ddlPosition.SelectedValue = hdnPosition.Value = splitval[0];
                                txtbxPlacementId.Text = hdnPlaceId.Value = splitval[1];
                                txtbxReferId.Text = hdnRefid.Value = splitval[2];
                                ddlPosition.Enabled = false;
                                txtbxPlacementId.ReadOnly = true;
                                txtbxReferId.ReadOnly = true;
                                hdnvalidplace.Value = "0";
                                txtbxPlacementId_TextChanged(sender,e);

                            }
                        }
                    }
                    getCountryData();
                    getRelationData();
                }
            }
            catch (Exception ex)
            {

                string message = "Somthing goes worng!! Try later. Thanks.";
                //  if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");

            }

        }
        protected void txtbxReferId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                usernote.Attributes.Remove("data-content");
                usernote.Attributes.Remove("data-original-title");
                UserBLL userBll = new UserBLL();
                if (txtbxReferId.Text != "")
                {
                    DataTable dt = userBll.GetUserInfoById(txtbxReferId.Text);
                    if (dt.Rows.Count > 0)
                    {
                        string TransferToName = "Name:" + dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
                        string Contactinfo = "Cell:" + dt.Rows[0]["MobileNo"].ToString() + ", Email:" +
                                             dt.Rows[0]["Email"].ToString();
                        usernote.Attributes.Add("data-content", Contactinfo);
                        usernote.Attributes.Add("data-original-title", TransferToName);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void txtbxPlacementId_TextChanged(object sender, EventArgs e)
        {
            try
            {

                Areffer.Attributes.Remove("data-content");
                Areffer.Attributes.Remove("data-original-title");
                UserBLL userBll = new UserBLL();
                if (txtbxPlacementId.Text != "")
                {
                    if (txtbxPlacementId.Text != txtbxUserName.Text)
                    {
                        DataTable dt = userBll.GetUserInfoById(txtbxPlacementId.Text);
                        if (dt.Rows.Count > 0)
                        {
                            if (userBll.checkPlacementIdValidity(dt.Rows[0]["UserId"].ToString(),
                                ddlPosition.SelectedValue))
                            {
                                txtbxPlacementId.Text = "";
                                string message = " <span class='actionTopic'>" +
                                                 " Placement Informarion is not correct!!" +
                                                 ddlPosition.SelectedItem.Text +
                                                 " Is not free of the Placement Id</span>.";
                                MyAlertBox(
                                    "var callbackOk = function () { window.location = \"/page/registration.aspx\"; }; WarningAlert(\"" +
                                    "Process Succeed" + "\", \"" + message + "\", \"\");");
                                hdnvalidplace.Value = "1";
                            }
                            else
                            {
                                string TransferToName = "Name:" + dt.Rows[0]["FirstName"].ToString() + " " +
                                                        dt.Rows[0]["LastName"].ToString();
                                string Contactinfo = "Cell:" + dt.Rows[0]["MobileNo"].ToString() + ", Email:" +
                                                     dt.Rows[0]["Email"].ToString();
                                Areffer.Attributes.Add("data-content", Contactinfo);
                                Areffer.Attributes.Add("data-original-title", TransferToName);
                                hdnvalidplace.Value = "0";

                            }
                        }
                    }
                    else
                    {
                        txtbxPlacementId.Text = "";
                        ddlPosition.SelectedIndex = 0;
                        string message = " <span class='actionTopic'>" +
                                         " Placement Informarion is not correct!!" +
                                         ddlPosition.SelectedItem.Text +
                                         " Is not free of the Placement Id</span>.";
                        MyAlertBox(
                            "var callbackOk = function () { window.location = \"/page/registration.aspx\"; }; WarningAlert(\"" +
                            "Process Succeed" + "\", \"" + message + "\", \"\");");
                        hdnvalidplace.Value = "1";
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
        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        private void getRelationData()
        {
            DataTable dt = new DataTable();
            initialDataBLL LookUpBll = new initialDataBLL();
            LookUpBll.ElementGroupId = "EG002";
            try
            {
                dt = LookUpBll.GetElementDataListByGroupId();
                ddlContactRelation.DataSource = dt;
                ddlContactRelation.DataTextField = "ElementName";
                ddlContactRelation.DataValueField = "ElementId";
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

        protected void txtbxUserName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                iconuserName.Attributes.Remove("class");
                lblUsernameNote.Visible = false;
                UserBLL user = new UserBLL();
                Regex reg = new Regex(@"^[a-z0-9_-]{5,15}$");

                if (reg.IsMatch(txtbxUserName.Text))
                {
                    if (user.CheckDuplicateUser(txtbxUserName.Text.Trim()))
                    {
                        //  iconuserName.Attributes.Remove("class");
                        iconuserName.Attributes.Add("class", "icon icon-ban-circle text-error");
                        hdnfldduplicate.Value = "1";
                        txtbxUserName.Focus();
                    }
                    else
                    {
                        // iconuserName.Attributes.Remove("class");
                        iconuserName.Attributes.Add("class", "icon icon-ok-sign text-success");
                        hdnfldduplicate.Value = "0";
                        txtbxFirstName.Focus();
                    }
                }
                else
                {
                    lblUsernameNote.Visible = true;
                    lblUsernameNote.Text = "User Name must be 5-15 char small letter alpha char (_ allow) ei. jhonsmith_ or jhonsmith ";

                }
            }
            catch (Exception)
            {

                //throw;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                UserBLL aUser = new UserBLL();
                if (txtbxUserName.Text == "")
                {
                    msgbox.Visible = true;
                    msgTitleLabel.Text = "Validation!!!";
                    msgDetailLabel.Text = "User Name field is required.";
                    msgbox.Attributes.Add("Class", "alert alert-warning");
                    txtbxUserName.Focus();
                }
                else if (txtbxFirstName.Text == "")
                {
                    msgbox.Visible = true;
                    msgTitleLabel.Text = "Validation!!!";
                    msgDetailLabel.Text = "First Name field is required.";
                    msgbox.Attributes.Add("Class", "alert alert-warning");
                    txtbxFirstName.Focus();
                }
                else if (txtbxLastName.Text == "")
                {
                    msgbox.Visible = true;
                    msgTitleLabel.Text = "Validation!!!";
                    msgDetailLabel.Text = "Last Name field is required.";
                    msgbox.Attributes.Add("Class", "alert alert-warning");
                    txtbxLastName.Focus();
                }
                else if (txtbxAddress.Text == "")
                {
                    msgbox.Visible = true;
                    msgTitleLabel.Text = "Validation!!!";
                    msgDetailLabel.Text = "Address field is required.";
                    msgbox.Attributes.Add("Class", "alert alert-warning");
                    txtbxAddress.Focus();
                }
                else if (txtbxHouse.Text == "")
                {
                    msgbox.Visible = true;
                    msgTitleLabel.Text = "Validation!!!";
                    msgDetailLabel.Text = "House No field is required.";
                    msgbox.Attributes.Add("Class", "alert alert-warning");
                    txtbxHouse.Focus();
                }
                else if (txtbxStreet.Text == "")
                {
                    msgbox.Visible = true;
                    msgTitleLabel.Text = "Validation!!!";
                    msgDetailLabel.Text = "Street field is required.";
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
                else if (txtbxCellConfrm.Text == "")
                {
                    msgbox.Visible = true;
                    msgTitleLabel.Text = "Validation!!!";
                    msgDetailLabel.Text = "Cell Confirm field is required.";
                    msgbox.Attributes.Add("Class", "alert alert-warning");
                    txtbxCellConfrm.Focus();
                }
                else if (txtbxEmail.Text == "")
                {
                    msgbox.Visible = true;
                    msgTitleLabel.Text = "Validation!!!";
                    msgDetailLabel.Text = "Email field is required.";
                    msgbox.Attributes.Add("Class", "alert alert-warning");
                    txtbxEmail.Focus();
                }
                else if (txtbxPin.Text == "")
                {
                    msgbox.Visible = true;
                    msgTitleLabel.Text = "Validation!!!";
                    msgDetailLabel.Text = "Pin field is required.";
                    msgbox.Attributes.Add("Class", "alert alert-warning");
                    txtbxPin.Focus();
                }
                else if (txtbxReferId.Text == "")
                {
                    msgbox.Visible = true;
                    msgTitleLabel.Text = "Validation!!!";
                    msgDetailLabel.Text = "Reffer ID field is required.";
                    msgbox.Attributes.Add("Class", "alert alert-warning");
                    txtbxReferId.Focus();
                }
                else if (txtbxPlacementId.Text == ""||txtbxPlacementId.Text==txtbxUserName.Text)
                {
                    msgbox.Visible = true;
                    msgTitleLabel.Text = "Validation!!!";
                    msgDetailLabel.Text = "Placement ID field is required. or Not valid.";
                    msgbox.Attributes.Add("Class", "alert alert-warning");
                    txtbxPlacementId.Text = "";
                    txtbxPlacementId.Focus();
                }
                else if (ddlPosition.SelectedItem.Text == "")
                {
                    msgbox.Visible = true;
                    msgTitleLabel.Text = "Validation!!!";
                    msgDetailLabel.Text = "Join Position field is required.";
                    msgbox.Attributes.Add("Class", "alert alert-warning");
                    ddlPosition.Focus();
                }

                else
                {
                    if (!aUser.CheckDuplicateUser(txtbxUserName.Text) && hdnvalidplace.Value == "0")
                    {

                        LoginBll login = new LoginBll();
                        aUser.UserId = txtbxUserName.Text.Trim();
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
                        aUser.EmrRelation = ddlContactRelation.SelectedValue;
                        aUser.EmrAddress = txtbxContactAddress.Text.Trim();
                        aUser.EmrMobile = txtbxContactMobile.Text.Trim();
                        aUser.EmeEmail = txtContactEmail.Text.Trim();
                        aUser.EmeCountry = ddlContactCountry.SelectedValue;
                        aUser.UserGroupId = "UG003";
                        aUser.Password =
                            (string)
                                LumexLibraryManager.EncodeIntoMd5Hash("LTSsL[" + txtpxPasswordset.Text.Trim() + "]0");
                        ;
                        aUser.ActualPass = retypePassword.Text.Trim();
                        aUser.UserPin = txtbxPin.Text.Trim();
                        aUser.IsActive = "No";
                        aUser.PerPhoto = "";
                        aUser.Isvarified = "No";
                        aUser.Createdby = "";
                        bool status = aUser.SaveUserInfo();
                        if (status)
                        {

                            if (txtbxPlacementId.Text != "" && ddlPosition.SelectedValue != "" &&
                                txtbxReferId.Text != "")
                            {
                                aUser.InsertIntoGenolgyTree(txtbxPlacementId.Text, ddlPosition.SelectedValue,
                                    txtbxReferId.Text, aUser.UserId);
                            }
                            Random random = new Random();
                            MailContactBLL mailContactBll = new MailContactBLL();
                            aUser.varifycode = random.Next(100000, 999998) + 1;

                            string key = dataEncryptbll.addforvarifycore;
                            string encrypeteduid = dataEncryptbll.EncryptRijndael(
                                aUser.UserId + "#" + aUser.varifycode, key);
                            string url = HttpContext.Current.Request.Url.AbsoluteUri;
                            string[] Partsofurl = url.Split('/');
                            aUser.ActivationUrl =
                                Server.HtmlEncode("http://" + Partsofurl[2] + "/page/varify.aspx/?uid=" + encrypeteduid);
                            string body = PopulateBody(aUser);

                            bool mailSend = mailContactBll.sendemailtocompleteResigtration(aUser, body);
                            aUser = null;
                            ClearTextBox();
                          
                        }
                    }
                    else
                    {
                        string message = " <span class='actionTopic'>" + " Placement Informarion is not correct!!" +
                                         ddlPosition.SelectedItem.Text + " Is not free of the Placement Id</span>.";
                        MyAlertBox(
                            "var callbackOk = function () { window.location = \"/page/registration.aspx\"; }; WarningAlert(\"" +
                            "Process Succeed" + "\", \"" + message + "\", \"\");");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            



        }

        private string PopulateBody(UserBLL userBll)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/assets/oth/thanksemail.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{UserId}", userBll.UserId);
            body = body.Replace("{Password}", userBll.ActualPass);
            body = body.Replace("{Cell}", userBll.MobileNo);
            body = body.Replace("{PIN}", userBll.UserPin);
            body = body.Replace("{varifyurl}", userBll.ActivationUrl);
            return body;
        }



        private void ClearTextBox()
        {
            txtbxUserName.Text = "";
            txtbxFirstName.Text = "";
            txtbxLastName.Text = "";
            txtbxPassportNo.Text = "";
            txtbxAddress.Text = "";
            ddlCountry.SelectedValue = "";
            txtbxHouse.Text = "";
            txtbxStreet.Text = "";
            txtbxArea.Text = "";
            txtbxCell.Text = "";
            txtbxCellConfrm.Text = "";
            txtbxEmail.Text = "";
            txtcontactPerson.Text = "";
            ddlContactRelation.SelectedValue = "";
            txtbxContactAddress.Text = "";
            txtbxContactMobile.Text = "";
            txtContactEmail.Text = "";
            ddlContactCountry.SelectedValue = "";
            txtpxPasswordset.Text = "";
            retypePassword.Text = "";
            txtbxPin.Text = "";
            txtpinConfirm.Text = "";
            //lvlSuccess.Text = "Your Information Has Been Saved! Please Check Your Email For Activation!";
            msgbox.Visible = true;
            msgTitleLabel.Text = "Information Saved";
            msgDetailLabel.Text = "Your Information Has Been Saved! Please Check Your Email For Activation!";
            msgbox.Attributes.Add("class", "alert alert-success");
            txtbxPlacementId.Text = "";
            txtbxReferId.Text = "";
            ddlPosition.SelectedValue = "";
            hdnPlaceId.Value = "1";


        }

        protected void ddlPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                UserBLL userBll = new UserBLL();
                if (userBll.checkPlacementIdValidity(txtbxPlacementId.Text, ddlPosition.SelectedValue))
                {
                    txtbxPlacementId.Text = "";
                    string message = " <span class='actionTopic'>" + " Placement Informarion is not correct!!" + ddlPosition.SelectedItem.Text + " Is not free of the Placement Id</span>.";
                    MyAlertBox("var callbackOk = function () { window.location = \"/page/registration.aspx\"; }; WarningAlert(\"" +
                        "Process Succeed" + "\", \"" + message + "\", \"\");");
                    hdnvalidplace.Value = "1";
                }
                else
                {
                    hdnvalidplace.Value = "0";
                }

            }
            catch (Exception)
            {
                
                throw;
            }
        }



    }
}