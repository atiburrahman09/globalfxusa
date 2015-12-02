using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using globalfx.setting.User;
using Lumex.Tech;
using Global.Core.BLL;
using System.Data;

namespace globalfx.a.initialdata
{
    public partial class initialDataGroup : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetElementGroupList();
            }
            msgbox.Visible = false;
        }
        protected void GetElementGroupList()
        {
            try
            {
                DataTable dt = new DataTable();
                initialDataBLL lookupBll = new initialDataBLL();
                dt = lookupBll.GetElementGroupList();
                if (dt.Rows.Count > 0)
                {
                    gridviewElementGroupList.DataSource = dt;
                    gridviewElementGroupList.DataBind();
                }
                GridviewStyle();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }

        }
        private void GridviewStyle()
        {
            if (gridviewElementGroupList.Rows.Count > 0)
            {
                gridviewElementGroupList.UseAccessibleHeader = true;
                gridviewElementGroupList.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }
        protected void btnSaveElementGroup_Click(object sender, EventArgs e)
        {
            try
            {
                initialDataBLL lookupBll = new initialDataBLL();
                lookupBll.ElementGroupName = txtbxGroupName.Text;
                lookupBll.ElementGroupDes = txtDescription.Text;
                if (btnSave.Text != "Update")
                {

                    if (lookupBll.checkDuplicateLookupGroup())
                    {

                        bool Status = lookupBll.SaveLookUpGroup();
                        if (Status)
                        {
                            string message = " <span class='actionTopic'>" + " Data Saved Successfully as Id: " +
                                             lookupBll.ElementGroupId.ToString() + "</span>.";
                            MyAlertBox(
                                "var callbackOk = function () { window.location = \"/HRUI/LookUpData/ElementGroup/AddElementGroup.aspx\"; }; SuccessAlert(\"" +
                                "Process Succeed" + "\", \"" + message + "\", \"\");");
                            GetElementGroupList();
                        }
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
                    lookupBll.ElementGroupId = hdbFieldId.Value;
                    lookupBll.UpdateLookUpGroup();
                    btnSave.Text = "Save";
                    string message = " <span class='actionTopic'>" + " Data Updated Successfully of Id: " +
                                      lookupBll.ElementGroupId.ToString() + "</span>.";
                    MyAlertBox(
                        "var callbackOk = function () { window.location = \"/HRUI/LookUpData/ElementGroup/AddElementGroup.aspx\"; }; SuccessAlert(\"" +
                        "Process Succeed" + "\", \"" + message + "\", \"\");");
                    GetElementGroupList();
                    txtDescription.Text = "";
                    txtbxGroupName.Text = "";
                }


            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }
        protected void EditLinkButton_OnClick(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;


                hdbFieldId.Value = gridviewElementGroupList.Rows[row.RowIndex].Cells[0].Text.ToString();
                txtbxGroupName.Text = gridviewElementGroupList.Rows[row.RowIndex].Cells[1].Text.ToString();
                txtDescription.Text = gridviewElementGroupList.Rows[row.RowIndex].Cells[2].Text.ToString();



                btnSave.Text = "Update";


            }
            catch (Exception ex)
            {
                msgbox.Attributes.Add("Class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }




    }
}