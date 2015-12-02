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
    public partial class accountreport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                getallUserAcountSummary();
            }
            catch (Exception)
            {
                
                //throw;
            }

        }

        private void getallUserAcountSummary()
        {
            try
            {
                UserAccountBLL accountBll = new UserAccountBLL();
                DataTable dt = accountBll.getAccountSummaryAllUser();
                GridViewIncomeSamary.DataSource = dt;
                GridViewIncomeSamary.DataBind();

            }
            catch (Exception)
            {
                
               // throw;
            }
            if (GridViewBlanceSheet.Rows.Count > 0)
            {
                // generateButton.Visible = true;
                GridViewBlanceSheet.UseAccessibleHeader = true;
                GridViewBlanceSheet.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (GridViewIncomeSamary.Rows.Count > 0)
            {
                // generateButton.Visible = true;
                GridViewIncomeSamary.UseAccessibleHeader = true;
                GridViewIncomeSamary.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        
        protected void ViewButton_Click(object sender, EventArgs e)
        {
            try
            {
                UserAccountBLL userAccount = new UserAccountBLL();
                DataTable dt = userAccount.getUserIncomeStatementById(txtbxUserId.Text, LumexLibraryManager.ParseAppDate(fromDateTextBox.Text), LumexLibraryManager.ParseAppDate(toDateTextBox.Text));

                DesignGridviewBalaceSheet(dt);

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            finally
            {
                //MyAlertBox("MyOverlayStop();");
            }
        }
        private void DesignGridviewBalaceSheet(DataTable userDt)
        {
            try
            {
                DataTable dt = new DataTable();
                DataRow dr = null;

                dt.Columns.Add(new DataColumn("TransectionId"));
                dt.Columns.Add(new DataColumn("TransectionDate"));
                dt.Columns.Add(new DataColumn("Receiveon"));
                dt.Columns.Add(new DataColumn("Particular"));
                dt.Columns.Add(new DataColumn("DebitAmount"));
                dt.Columns.Add(new DataColumn("CreditAmount"));
                dt.Columns.Add(new DataColumn("BalanceAmount"));

                if (userDt.Rows.Count > 0)
                {
                    decimal openingBalance = Convert.ToDecimal(userDt.Rows[0]["OpeningBalance"].ToString());

                    dr = dt.NewRow();
                    dr["TransecTionID"] = "";
                    dr["TransectionDate"] = "";
                    dr["Receiveon"] = "";
                    dr["Particular"] = "";
                    dr["DebitAmount"] = "";
                    dr["CreditAmount"] = "Forward Balance";
                    dr["BalanceAmount"] = openingBalance.ToString();

                    dt.Rows.Add(dr);

                    for (int i = 0; i < userDt.Rows.Count; i++)
                    {
                        dr = dt.NewRow();
                        dr["TransectionId"] = userDt.Rows[i]["TransecTionID"].ToString();
                        dr["TransectionDate"] = userDt.Rows[i]["TransectionDate"].ToString();
                        dr["Receiveon"] = userDt.Rows[i]["Receiveon"].ToString();
                        dr["Particular"] = userDt.Rows[i]["Particular"].ToString();
                        decimal Balance = Convert.ToDecimal(userDt.Rows[i]["Balance"]);
                        if (Balance > 0)
                        {
                            dr["DebitAmount"] = Balance.ToString();
                            openingBalance = openingBalance + Balance;
                            dr["CreditAmount"] = "0.00";
                            dr["BalanceAmount"] = openingBalance.ToString();

                        }
                        else
                        {
                            Balance = Balance * (-1);
                            dr["CreditAmount"] = Balance.ToString();
                            openingBalance = openingBalance - Balance;
                            dr["DebitAmount"] = "0.00";
                            dr["BalanceAmount"] = openingBalance.ToString();
                        }


                        dt.Rows.Add(dr);
                    }
                }

                GridViewBlanceSheet.DataSource = dt;
                GridViewBlanceSheet.DataBind();
                if (GridViewBlanceSheet.Rows.Count > 0)
                {
                    // generateButton.Visible = true;
                    GridViewBlanceSheet.UseAccessibleHeader = true;
                    GridViewBlanceSheet.HeaderRow.TableSection = TableRowSection.TableHeader;
                }


            }
            catch (Exception)
            {


            }
            finally
            {
                //MyAlertBox("MyOverlayStop();");
            }
        }

        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

    }
}