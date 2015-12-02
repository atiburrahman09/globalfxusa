﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Global.Core;
using Global.Core.BLL;
using Lumex.Tech;

namespace globalfx.news
{
    public partial class newsfeed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    GetNewsFeedList();
                }

                if (GridViewNewsFeedList.Rows.Count > 0)
                {
                    GridViewNewsFeedList.UseAccessibleHeader = true;
                    GridViewNewsFeedList.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {

                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        private void GetNewsFeedList()
        {
            NewsFeedBLL newsFeedBll = new NewsFeedBLL();

            try
            {
                DataTable dt = newsFeedBll.GetNewsFeedList();
                GridViewNewsFeedList.DataSource = dt;
                GridViewNewsFeedList.DataBind();


                GridviewHeadStyle();
            }
            catch (Exception ex)
            {
                msgbox.Attributes.Add("Class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }
        private void GridviewHeadStyle()
        {
            if (GridViewNewsFeedList.Rows.Count > 0)
            {
                GridViewNewsFeedList.UseAccessibleHeader = true;
                GridViewNewsFeedList.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }
        private void GridViewStyle()
        {
            if (GridViewNewsFeedList.Rows.Count > 0)
            {
                GridViewNewsFeedList.UseAccessibleHeader = true;
                GridViewNewsFeedList.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            NewsFeedBLL newsFeedBll = new NewsFeedBLL();
            newsFeedBll.Title = txtbxTitle.Text.Trim();
            newsFeedBll.BodyText = txtbxBody.Text.Trim();
            newsFeedBll.Value = Convert.ToDateTime(validdateTextBox.Text.Trim()).ToString("yyyy-MM-dd");
            //newsFeedBll.Value = LumexLibraryManager.ParseAppDate(validdateTextBox.Text.Trim());
            if (btnSave.Text == "Save")
            {
                bool status = newsFeedBll.SaveNewsInfo();
                string message = " <span class='actionTopic'>" +
                                             " News Feed Saved Successfully ! " +
                                              "</span>.";
                MyAlertBox("var callbackOk = function () { window.location = \"/news/newsfeed.aspx\"; }; SuccessAlert(\"" +
                    "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                btnSave.Text = "Update";
            }
            else
            {
                newsFeedBll.Serial = hdbFieldId.Value;

                bool status = newsFeedBll.UpdateNewsInfo();
                if (status)
                {
                    string message = " <span class='actionTopic'>" +
                                             " News Feed Updated Successfully ! " +
                                              "</span>.";
                    MyAlertBox("var callbackOk = function () { window.location = \"/news/newsfeed.aspx\"; }; SuccessAlert(\"" +
                        "Process Succeed" + "\", \"" + message + "\", callbackOk);");
                }
            }



        }

        protected void EditLinkButton_OnClick(object sender, EventArgs e)
        {
            try
            {
                NewsFeedBLL newsFeedBll = new NewsFeedBLL();
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                btnSave.Text = "Update";
                newsFeedBll.NewsFeedId = GridViewNewsFeedList.Rows[row.RowIndex].Cells[0].Text.ToString();
                hdbFieldId.Value = GridViewNewsFeedList.Rows[row.RowIndex].Cells[0].Text.ToString();
                DataTable dt = newsFeedBll.GetNewsFeedDataById();

                if (dt.Rows.Count > 0)
                {
                    txtbxTitle.Text = dt.Rows[0]["NewsTitale"].ToString();
                    txtbxBody.Text = dt.Rows[0]["NewsBody"].ToString();
                    validdateTextBox.Text = dt.Rows[0]["ValidDate"].ToString() ;
                }
            }
            catch (Exception ex)
            {
                msgbox.Attributes.Add("Class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }
    }
}