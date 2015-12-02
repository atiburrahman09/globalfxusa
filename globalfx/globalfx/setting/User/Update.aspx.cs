using System;
using System.Data;
using System.Web.UI;
using Global.Core.BLL;
using Lumex.Tech;
using System.Web.UI.WebControls;
using System.IO;
using System.Web;

namespace globalfx.setting.User
{
    public partial class Update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {
                    LoadUserGroups();
                    //GetBranch();
                   // GetBranch();

                   userIdForUpdateHiddenField.Value = (string)LumexSessionManager.Get("UserIdForUpdate");
                    if (string.IsNullOrEmpty(userIdForUpdateHiddenField.Value))
                    {
                       Response.Redirect("~/setting/User/List.aspx",true);
                    }
                    else
                    {
                        GetUserById(userIdForUpdateHiddenField.Value.Trim());
                    }
                  
                }

                if(LumexSessionManager.Get("UserGroupId").ToString()=="UG001")
                {
                    txtbxemail.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
                msgbox.Attributes.Add("Class", "alert alert-warning");
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


        

        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        protected void LoadUserGroups()
        {
            UserGroupBLL userGroup = new UserGroupBLL();

            try
            {
                DataTable dt = userGroup.GetActiveUserGroupList();

                drpdownGroup.DataSource = dt;
                drpdownGroup.DataValueField = "UserGroupId";
                drpdownGroup.DataTextField = "UserGroupName";
                drpdownGroup.DataBind();
                drpdownGroup.Items.Insert(0, "----------Select----------");
                drpdownGroup.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
                msgbox.Attributes.Add("Class", "alert alert-warning");
            }
            finally
            {
                userGroup = null;
            }
        }

        protected void GetUserById(string userId)
        {
            UserBLL user = new UserBLL();

            try
            {
                DataTable dt = user.GetUserById(userId);
               // DataTable dt2 = user.GetUserById(LumexSessionManager.Get("ActiveUserId").ToString());
                if (dt.Rows.Count > 0)
                {
                    lblUserId.Text = dt.Rows[0]["UserId"].ToString();
                    txtbxUserName.Text = dt.Rows[0]["UserName"].ToString();
                    txtbxmobile.Text = dt.Rows[0]["ContactNumber"].ToString().Remove(0, 3);
                    txtbxemail.Text = dt.Rows[0]["Email"].ToString();
                    //txtbxDateOfBirth.Text = dt.Rows[0]["DOB"].ToString();
                    //drpdwnSex.SelectedValue = dt.Rows[0]["Gender"].ToString();
                    //drpdwnLastEducation.SelectedValue = dt.Rows[0]["LastDegree"].ToString();
                    //txtbxsubject.Text = dt.Rows[0]["DegreeSubject"].ToString();
                    //txtbxYear.Text = dt.Rows[0]["PassingYear"].ToString();
                    //txtbxNameofOrganization.Text = dt.Rows[0]["InstituteName"].ToString();
                    //drpdwnOccupation.SelectedValue = dt.Rows[0]["Occupation"].ToString();
                    //txtbxDesignation.Text = dt.Rows[0]["Designation"].ToString();
                    //txtbxFatherName.Text = dt.Rows[0]["FatherName"].ToString();
                    //txtbxMotherName.Text = dt.Rows[0]["MotherName"].ToString();
                    //txtbxExperienceICT.Text = dt.Rows[0]["ExperienceICT"].ToString();
                    //txtbxPresentAddress.Text = dt.Rows[0]["PresentAddress"].ToString();
                    //txtbxParmanentAddress.Text = dt.Rows[0]["ParmanentAddress"].ToString();
                    //if ((string)LumexSessionManager.Get("UserGroupId") != "UG001")
                    //{
                    //    userGroupdiv.Visible = false;
                    //    hiddentfieldGroupId.Value = dt.Rows[0]["UserGroupId"].ToString();
                    //}
                    //else
                    //{
                        drpdownGroup.SelectedValue = dt.Rows[0]["UserGroupId"].ToString();
                    //    hiddentfieldGroupId.Value = "";
                    //}
                    
                   // hiddenfeildphoto.Value = dt.Rows[0]["PerPhoto"].ToString();
                    hiddenfeildEmail.Value = dt.Rows[0]["Email"].ToString();
                   //BranchDropDownList.SelectedValue = dt.Rows[0]["BranchId"].ToString();
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
                user = null;
            }
        }
        protected void txtbxEmailTextchanged(object sender, EventArgs e)
        {
            try
            {
                UserBLL userbll = new UserBLL();
                if (userbll.CheckDuplicateUser(txtbxemail.Text))
                {

                    msgTitleLabel.Text = "Error!!";
                    msgDetailLabel.Text = "Email address alredy exits!!!";
                    msgbox.Visible = true;
                    msgbox.Attributes.Add("Class", "alert alert-warning");

                }

            }
            catch (Exception ex)
            {

                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");

            }

        }
        protected void btnUserUpdate_click(object sender, EventArgs e)
        {
            try
            {

                UserBLL userbll = new UserBLL();


                userbll.UserName = txtbxUserName.Text;
                userbll.Cell = "+88" + txtbxmobile.Text;
                userbll.Email = txtbxemail.Text;
                //userbll.DOB = txtbxDateOfBirth.Text;
                //userbll.Gender = drpdwnSex.Text;
                //if (hiddentfieldGroupId.Value == "")
                //{
                    userbll.UserGroupId = drpdownGroup.SelectedValue;
                //}
                //else
                //{
                //    userbll.UserGroupId = hiddentfieldGroupId.Value;
                //}
                //userbll.Certificate = "";
                //userbll.Occupation = drpdwnOccupation.SelectedValue;
                //userbll.Organization = txtbxNameofOrganization.Text;
                //userbll.Designation = txtbxDesignation.Text;
                //userbll.ExperienceICT = txtbxExperienceICT.Text;
                //userbll.LastDegree = drpdwnLastEducation.SelectedValue;
                //userbll.DegreeSubject = txtbxsubject.Text;
                //userbll.PassingYear = txtbxYear.Text;

                //userbll.FatherName = txtbxFatherName.Text;
                //userbll.MotherName = txtbxMotherName.Text;
                //userbll.ParmanentAdd = txtbxParmanentAddress.Text;
                //userbll.PresentAdd = txtbxPresentAddress.Text;
                userbll.UserId = userIdForUpdateHiddenField.Value;
                //userbll.Branch = BranchDropDownList.SelectedValue;
                string IsUpload = photoUploadfn(userbll.Email);

                if (IsUpload == "")
                {

                    msgTitleLabel.Text = "Error!!!!";
                    msgDetailLabel.Text = "  Pleace Check File Extention or File size.You can only upload Image and size less than 128Kb";
                    msgbox.Visible = true;
                    string message = " <span class='actionTopic'>" + " Pleace Check File Extention or File size.You can only upload Image and size less than 128Kb</span>.";
                    MyAlertBox("var callbackOk = function () { window.location = \"/setting/user/update.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");

                }
                else
                {
                    userbll.PerPhoto = IsUpload;
                    bool status = userbll.UpdateUser();



                    if (status)
                    {
                        //if (hiddentfieldGroupId.Value == "")
                        //{
                            string message = " <span class='actionTopic'>" + "User Update Successfully.</span>.";
                            MyAlertBox("var callbackOk = function () { window.location = \"/setting/User/List.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                        //}
                        //else
                        //{
                        //    string message = " <span class='actionTopic'>" + "User Update Successfully.</span>.";
                        //    MyAlertBox("var callbackOk = function () { window.location = \"/default.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                        //}



                    }
                }

            }
            catch (Exception ex)
            {

                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");

            }
            //UserBLL user = new UserBLL();

            //try
            //{
            //    //if (userIdForUpdateHiddenField.Value.Trim() == "")
            //    {
            //        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "User not found to update.";
            //    }
            //    if (userIdTextBox.Text == "")
            //    {
            //        msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "User ID field is required.";
            //    }
            //    else if (userNameTextBox.Text == "")
            //    {
            //        msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "User Name field is required.";
            //    }
            //    else if (userGroupDropDownList.SelectedValue == "----------Select----------")
            //    {
            //        msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "User Group field is required.";
            //    }
            //    else if (contactNumberTextBox.Text == "")
            //    {
            //        msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Contact Number field is required.";
            //    }
            //    else if (emailTextBox.Text == "")
            //    {
            //        msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Email field is required.";
            //    }
            //    //else if (addressTextBox.Text == "")
            //    //{
            //    //    msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Address field is required.";
            //    //}
            //    else
            //    {
            //        user.Serial = hdnfldUserSerial.Value.ToString();
            //        user.UserId = idLabel.Text;
            //        user.UserName = userNameTextBox.Text.Trim();
            //        string[] emp = employeeIdTextBox.Text.Split('#');
            //        if (emp.Length > 1)
            //        {
            //            user.EmployeeId = emp[0];
            //        }
            //        else
            //        {
            //            user.EmployeeId = employeeIdTextBox.Text.Trim();
            //        }
            //        user.Department = departmentTextBox.Text.Trim();
            //        user.Designation = designationTextBox.Text.Trim();
            //        // user.Address = addressTextBox.Text.Trim();
            //        user.ContactNumber = contactNumberTextBox.Text.Trim();
            //        user.Email = emailTextBox.Text.Trim();
            //        // user.NationalId = nationalIdTextBox.Text.Trim();
            //        user.PassportNumber = passportNumberTextBox.Text.Trim();
            //        user.UserGroupId = userGroupDropDownList.SelectedValue.Trim();
            //        user.Branch = drpdwnBranch.SelectedValue.Trim();
            //        //user.Password = passwordTextBox.Text.Trim();

            //        user.UpdateUser();

            //        userIdForUpdateHiddenField.Value = "";
            //        string message = " <span class='actionTopic'>" + " User Updated Successfully</span>.";
            //        MyAlertBox("var callbackOk = function () { window.location = \"/HRUI/User/List.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");


            //    }


            //    if (userGroupDropDownList.SelectedValue == "----------Select----------")
            //    {
            //        msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "User Group field is required.";
            //    }
            //    else if (drpdwnBranch.SelectedValue == "")
            //    {
            //        msgbox.Visible = true; msgTitleLabel.Text = "Validation!!!"; msgDetailLabel.Text = "Branch field is required.";

            //    }
            //    else
            //    {
            //        user.UserId = idLabel.Text;
            //        user.UserGroupId = userGroupDropDownList.SelectedValue.Trim();
            //        user.Branch = drpdwnBranch.SelectedValue.Trim();
            //        user.UpdateUser();

            //        string message = " <span class='actionTopic'>" + " User Updated Successfully</span>.";
            //        MyAlertBox("var callbackOk = function () { window.location = \"/HRUI/User/List.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");


            //    }
            //}
            //catch (Exception ex)
            //{
            //    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            //}
            //finally
            //{
            //    user = null;
            //}




        }
        private string photoUploadfn(string userId)
        {
            string result = "";
            try
            {


                FileUpload FilePP = new FileUpload();
                FilePP = fileupload;
                if (FilePP.HasFile && FilePP.PostedFile.ContentLength <= 131072)
                {

                    string getExtention = Path.GetExtension(FilePP.FileName);

                    if (getExtention == ".jpg" || getExtention == ".jpeg" || getExtention == ".png" || getExtention == ".gif")
                    {

                        // hidFileName.Value = filename;
                        // string path = HttpContext.Current.Server.MapPath(WebConfigurationManager.AppSettings["AttachmentPath"] + "/ModuleContents/");
                        string loc = "/UsersContents/" + userId + "/";
                        string path = HttpContext.Current.Server.MapPath(loc);
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                            string fileLoaction = "~/UsersContents/" + hiddenfeildEmail.Value;

                            Directory.Delete(Server.MapPath(fileLoaction), true);
                        }
                       

                        path = path + "profilephoto" + getExtention;

                        FilePP.PostedFile.SaveAs(path);
                        result = "profilephoto" + getExtention;

                    }


                }
                else
                {
                    string loc = "/UsersContents/" + userId + "/";
                    string path = HttpContext.Current.Server.MapPath(loc);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                        
                    }
                    if(hiddenfeildphoto.Value=="")
                        {
                            hiddenfeildphoto.Value = "perphoto";
                        }
                      result = hiddenfeildphoto.Value;
                    

                }
               




            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
        

    }
}
