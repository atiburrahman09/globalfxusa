using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Global.Core.BLL;

namespace globalfx.a.account
{
    public partial class moneygerate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    getgeneratedMoneyList();    
                }
                
                if (GridViewGeneratedMoneyList.Rows.Count > 0)
                {
                    GridViewGeneratedMoneyList.UseAccessibleHeader = true;
                    GridViewGeneratedMoneyList.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
                
            catch (Exception)
            {
                    
                //throw;
            }

        }
        private void GridviewHeadStyle()
        {
            if (GridViewGeneratedMoneyList.Rows.Count > 0)
            {
                GridViewGeneratedMoneyList.UseAccessibleHeader = true;
                GridViewGeneratedMoneyList.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }

        private void getgeneratedMoneyList()
        {
            try
            {
                UserAccountBLL userAccount = new UserAccountBLL();
               DataTable dt =  userAccount.getGeneratedMoneyList();
               GridViewGeneratedMoneyList.DataSource = dt;
               GridViewGeneratedMoneyList.DataBind();

               if (dt.Rows.Count < 1)
               {
                   msgbox.Attributes.Add("Class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Data Not Found!!!"; msgDetailLabel.Text = "";
               }
               GridviewHeadStyle();
            }
            catch (Exception)
            {
                    
                //throw;
            }
        }
        protected void GenerateButton_Click(object sender, EventArgs e)
        {
            try
            {
               
                UserAccountBLL userAccount=new UserAccountBLL();
                userAccount.TransferAmount = Convert.ToDecimal(txtbxAmount.Text.Trim());
                bool status = userAccount.ReceivePaymentMoney(txtbxAmount.Text.Trim());
                if (status)
                {
                    string message = "Payment <span class='actionTopic'>Received</span> Successfully.";
                    MyAlertBox("var callbackOk = function () { MyOverlayStart(); window.location = \"/a/account/moneygerate.aspx\"; }; SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", callbackOk);");
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
        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }
    }
}