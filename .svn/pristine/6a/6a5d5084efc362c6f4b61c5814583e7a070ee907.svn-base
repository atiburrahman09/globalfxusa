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
    public partial class dailybonus : System.Web.UI.Page
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
                    dt = accountBll.getDailybounsListbyDateRangeByUserId(fromDateTextBox.Text, toDateTextBox.Text,(string)LumexSessionManager.Get("ActiveUserId"));
                }
                else
                {
                    dt = accountBll.getDailybounsListbyDateRange(fromDateTextBox.Text, toDateTextBox.Text);
            
                }
                GridDailyBonusGenerate.DataSource = dt;
                GridDailyBonusGenerate.DataBind();
                if (GridDailyBonusGenerate.Rows.Count > 0)
                {
                    // btnTodayBonusGenerate.Visible = true;
                    GridDailyBonusGenerate.UseAccessibleHeader = true;
                    GridDailyBonusGenerate.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                MyAlertBox("MyOverlayStop();");
            }
        }
        protected void dailyBonusGenerateButton_Click(object sender, EventArgs e)
        {
            try
            {
                UserAccountBLL accountBll = new UserAccountBLL();

                bool status = accountBll.generateDailyBonus(DateTime.Now.ToString("dd/MM/yyyy"));
                if (status)
                {
                    accountBll.InsertReceivePaymentWhenDailybonus();
                }

                DataTable dt = accountBll.getDailybounsListbyDateRange(DateTime.Now.ToString("dd/MM/yyyy"),
                    DateTime.Now.ToString("dd/MM/yyyy"));
                GridDailyBonusGenerate.DataSource = dt;
                GridDailyBonusGenerate.DataBind();
                if (GridDailyBonusGenerate.Rows.Count > 0)
                {
                    // btnTodayBonusGenerate.Visible = true;
                    GridDailyBonusGenerate.UseAccessibleHeader = true;
                    GridDailyBonusGenerate.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                MyAlertBox("MyOverlayStop();");
            }
        }
        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }
    }
}