using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Global.Core.BLL;
using Lumex.Tech;

namespace globalfx.a.account
{
    public partial class matching : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)LumexSessionManager.Get("UserGroupId") == "UG003")
                {
                    btnTodayBonusGenerate.Visible = false;
                }
            }

        }
        protected void ViewButton_Click(object sender, EventArgs e)
        {
            try
            {

                UserAccountBLL accountBll = new UserAccountBLL();
                DataTable dt = new DataTable();
                if ((string)LumexSessionManager.Get("UserGroupId") == "UG003")
                {
                    dt = accountBll.getMatchingCommissionListbyDateRangeByUserId(fromDateTextBox.Text, toDateTextBox.Text, (string)LumexSessionManager.Get("ActiveUserId"));
                }
                else
                {
                    dt = accountBll.getMatchingCommissionListbyDateRange(fromDateTextBox.Text, toDateTextBox.Text);

                }
                GridMatchCommissionGenerate.DataSource = dt;
                GridMatchCommissionGenerate.DataBind();
                if (GridMatchCommissionGenerate.Rows.Count > 0)
                {
                    // btnTodayBonusGenerate.Visible = true;
                    GridMatchCommissionGenerate.UseAccessibleHeader = true;
                    GridMatchCommissionGenerate.HeaderRow.TableSection = TableRowSection.TableHeader;
                }



            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            finally
            {
                //  MyAlertBox("MyOverlayStop();");
            }
        }
        protected void dailyBonusGenerateButton_Click(object sender, EventArgs e)
        {
            try
            {
                UserAccountBLL accountBll = new UserAccountBLL();
                genologyBLL genology = new genologyBLL();

                bool status = genology.generateBainaryMatchData();
                DataTable dt = genology.getNodeList();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    decimal LeftAmount = 0;
                    decimal RightAmount = 0;

                    genology.getNodeLeftRightAmount(dt.Rows[i]["NodeID"].ToString(), out LeftAmount, out RightAmount);
                    if (LeftAmount > 0 || RightAmount > 0)
                    {
                        genology.CalculateMatchingCommission(dt.Rows[i]["NodeID"].ToString(), LeftAmount, RightAmount);
                    }
                }
                string message = "Matching Commission  <span class='actionTopic'>Calculate</span> Successfully Done. Thanks.";
                MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/a/account/withdraw.aspx\"; }; SuccessAlert(\"" +
                    "Process Succeed" + "\", \"" + message + "\", \"\");");








            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            finally
            {
                MyAlertBox("MyOverlayStop();");
            }
        }
        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }
    }
}