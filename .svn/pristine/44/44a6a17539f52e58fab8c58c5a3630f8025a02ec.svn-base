using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using globalfx.setting.User;
using Lumex.Tech;
using Global.Core.BLL;
using System.Data;

namespace globalfx.a.initialdata
{
    public partial class initialDataElement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtbxElementName.Focus();
                GetElementGroupNameId();
                getElementDataList();
            }
            if (gridviewInitialDataElement.Rows.Count > 0)
            {
                gridviewInitialDataElement.UseAccessibleHeader = true;
                gridviewInitialDataElement.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            msgbox.Visible = false;
        }

        private void getElementDataList()
        {
            try
            {
                initialDataBLL initialData = new initialDataBLL();
                DataTable dt = initialData.GetElementDataList();
                gridviewInitialDataElement.DataSource = dt;
                gridviewInitialDataElement.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void GetElementGroupNameId()
        {
            DataTable dt = new DataTable();
            initialDataBLL LookUpBll = new initialDataBLL();
            try
            {
                dt = LookUpBll.GetElementGroupNameIdList();
                ddlGroup.DataSource = dt;
                ddlGroup.DataTextField = "Name";
                ddlGroup.DataValueField = "Id";
                ddlGroup.DataBind();
                ddlGroup.Items.Insert(0, "Select Here..");
                ddlGroup.SelectedIndex = 0;
                ddlGroup.Items[0].Value = "";

            }
            catch (Exception ex)
            {

                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool check = false;
            try
            {

                initialDataBLL initialData = new initialDataBLL();

                initialData.ElementDataName = txtbxElementName.Text.Trim();
                initialData.ElementDataDescp = txtbxDescription.Text.Trim();
                initialData.ElementGroupId = ddlGroup.SelectedValue;
                if (btnSave.Text != "Update")
                {

                    if (initialData.checkDuplicateLookupData())
                    {

                        check = true;


                        check = true;
                        // MyAlertBox("Data has been saved successfully!!");
                        initialData.SaveLookUpElementData();

                        string message = " <span class='actionTopic'>" + " Data Saved Successfully as Id: " +
                                         initialData.ElementDataId.ToString() + "</span>.";
                        MyAlertBox(
                            "var callbackOk = function () { window.location = \"/a/initialdata/initialDataElement.aspx\"; }; SuccessAlert(\"" +
                            "Process Succeed" + "\", \"" + message + "\", \"\");");

                    }
                    else
                    {
                        msgbox.Visible = true;
                        msgTitleLabel.Text = "Duplicate Data";
                        msgTitleLabel.Text = "This Group is already Added.";
                    }

                }
                else
                {

                    initialData.ElementDataId = hdbFieldId.Value;
                    initialData.ElementDataName = txtbxElementName.Text;
                    initialData.ElementGroupId = ddlGroup.SelectedValue.ToString();
                    initialData.ElementDataDescp = txtbxDescription.Text;
                    initialData.UpdateLookUpElementData();
                    btnSave.Text = "Save";
                    string message = " <span class='actionTopic'>" + " Data Updated Successfully of Id: " +
                                initialData.ElementDataId.ToString() + "</span>.";
                    MyAlertBox(
                        "var callbackOk = function () { window.location = \"/a/initialdata/initialDataElement.aspx\"; }; SuccessAlert(\"" +
                        "Process Succeed" + "\", \"" + message + "\", \"\");");
                    txtbxElementName.Text = "";
                    txtbxDescription.Text = "";
                    ddlGroup.SelectedIndex = 0;
                }
                if (check == false)
                {
                    MyAlertBox("Data save failed!!");

                }
                getElementDataList();



            }
            catch (Exception)
            {

                throw;
            }

        }

        private bool checkDuplicateElementData(initialDataBLL initialData)
        {
            bool status = false;
            try
            {

                status = initialData.checkDuplicateLookupData();
            }
            catch (Exception)
            {

                //throw;
            }
            return status;
        }
        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
            txtbxElementName.Text = "";
            txtbxDescription.Text = "";
        }
        protected void EditLinkButton_OnClick(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                hdbFieldId.Value = gridviewInitialDataElement.Rows[row.RowIndex].Cells[0].Text.ToString();

                initialDataBLL initialData = new initialDataBLL();

                initialData.ElementDataId = hdbFieldId.Value;
                DataTable dt = initialData.GetElementDataById();

                if (dt.Rows.Count > 0)
                {

                    txtbxElementName.Text = dt.Rows[0]["ElementName"].ToString();
                    txtbxDescription.Text = dt.Rows[0]["Suffix"].ToString();
                    ddlGroup.SelectedValue = dt.Rows[0]["ElementGrpId"].ToString(); ;
                }

                btnSave.Text = "Update";


            }
            catch (Exception ex)
            {
                msgbox.Attributes.Add("Class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }

    }
}