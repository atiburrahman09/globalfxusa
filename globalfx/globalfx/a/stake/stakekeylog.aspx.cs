using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Tech;
using Global.Core.BLL;

namespace globalfx.a.stake
{
    public partial class stakekeylog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                getStakeKeyLogdata();
                if (GridViewStakeLog.Rows.Count > 0)
                {
                    GridViewStakeLog.UseAccessibleHeader = true;
                    GridViewStakeLog.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void GridviewHeadStyle()
        {
            if (GridViewStakeLog.Rows.Count > 0)
            {
                GridViewStakeLog.UseAccessibleHeader = true;
                GridViewStakeLog.HeaderRow.TableSection = TableRowSection.TableHeader;

            }

        }
        private void GridViewStyle()
        {
            if (GridViewStakeLog.Rows.Count > 0)
            {
                GridViewStakeLog.UseAccessibleHeader = true;
                GridViewStakeLog.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void getStakeKeyLogdata()
        {
            try
            {
                StakeInfoBLL stakeInfo = new StakeInfoBLL();
                DataTable dt = new DataTable();
                if ((string) LumexSessionManager.Get("UserGroupId") == "UG003")
                {
                    dt = stakeInfo.getStakeKeyLogdatabyUser((string) LumexSessionManager.Get("ActiveUserId"));
                    GridViewStakeLog.DataSource = dt;
                    GridViewStakeLog.DataBind();
                    if (dt.Rows.Count < 1)
                    {
                        msgbox.Attributes.Add("Class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
                    }
                    GridviewHeadStyle();
                }
                else
                {
                    dt = stakeInfo.getStakeKeyLogdataAll();
                    GridViewStakeLog.DataSource = dt;
                    GridViewStakeLog.DataBind();
                    if (dt.Rows.Count < 1)
                    {
                        msgbox.Attributes.Add("Class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
                    }
                    GridviewHeadStyle();
                }


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

