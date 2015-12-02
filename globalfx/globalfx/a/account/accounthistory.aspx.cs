﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Global.Core.BLL;
using Lumex.Tech;

namespace globalfx.a.account
{
    public partial class accounthistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    getmyAccountSummary((string)LumexSessionManager.Get("ActiveUserId"));
                }
                loadGridView();
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void loadGridView()
        {
            GridViewGeneratedMoneyList.DataSource = null;
            GridViewGeneratedMoneyList.DataBind();
            GridDailyBonusGenerate.DataSource = null;
            GridDailyBonusGenerate.DataBind();
            GridCommision.DataSource = null;
            GridCommision.DataBind();
            if (Convert.ToInt32(ddlHistory.SelectedValue) == 0)
            {
                if (GridViewGeneratedMoneyList.Rows.Count > 0)
                {
                    GridViewGeneratedMoneyList.UseAccessibleHeader = true;
                    GridViewGeneratedMoneyList.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            else if (Convert.ToInt32(ddlHistory.SelectedValue) == 1)
            {
                if (GridDailyBonusGenerate.Rows.Count > 0)
                {
                    GridDailyBonusGenerate.UseAccessibleHeader = true;
                    GridDailyBonusGenerate.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            else if (Convert.ToInt32(ddlHistory.SelectedValue) == 2)
            {
                if (GridCommision.Rows.Count > 0)
                {
                    GridCommision.UseAccessibleHeader = true;
                    GridCommision.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            else
            {

            }
        }

        private void getmyAccountSummary(string UserId)
        {
            try
            {
                UserAccountBLL userAccount = new UserAccountBLL();
                DataTable dt = new DataTable();
                dt = userAccount.getMoneyGenerateAmountById(UserId);
                if (dt.Rows.Count > 0)
                {
                    lvlMoneyGenerate.Text = (('$') + dt.Rows[0][0].ToString());
                }
                dt = userAccount.getCommissionById(UserId);
                if (dt.Rows.Count > 0)
                {
                    lvlCommission.Text = (('$') + dt.Rows[0][0].ToString());
                }
                dt = userAccount.getDailyBonusById(UserId);
                if (dt.Rows.Count > 0)
                {
                    lvlDailyBonus.Text = (('$') + dt.Rows[0][0].ToString());
                }

            }
            catch (Exception)
            {

                // throw;
            }
        }
        protected void ViewButton_Click(object sender, EventArgs e)
        {
            //Test To confirm 

            UserAccountBLL userAccount = new UserAccountBLL();
            userAccount.historyOf = Convert.ToInt32(ddlHistory.SelectedValue);

            if (userAccount.historyOf == 0)
            {
                try
                {
                    DataTable dt = userAccount.getMoneyGenerateAmountByDateRangeById(fromDateTextBox.Text, toDateTextBox.Text, (string)LumexSessionManager.Get("ActiveUserId"));
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
            else if (userAccount.historyOf == 1)
            {

                try
                {
                    var j = 0;
                    DataTable dt = userAccount.getDailybounsListbyDateRange(fromDateTextBox.Text, toDateTextBox.Text);
                    DataTable newTable = new DataTable();
                    DataColumn column;
                    column = newTable.Columns.Add();
                    column.ColumnName = "BonusDate";
                    column.DataType = typeof(DateTime);

                    column = newTable.Columns.Add();
                    column.ColumnName = "DailyBonus";
                    column.DataType = typeof(string);
                    DateTime StartDate = DateTime.ParseExact(fromDateTextBox.Text, "dd/MM/yyyy", null); ; ;
                    DateTime EndDate =  DateTime.ParseExact(toDateTextBox.Text,"dd/MM/yyyy",null);;

                    for (var i = StartDate; i <= EndDate; i = i.AddDays(1))
                    {


                        double amount = 0;
                        while (j < dt.Rows.Count && i ==  DateTime.ParseExact(dt.Rows[j]["BonusDate"].ToString(),"dd/MM/yyyy", null))
                        {
                            amount += Convert.ToDouble(dt.Rows[j]["DailyBonus"]);
                            j++;

                        }

                        if (amount < 1)
                        {
                            continue;
                        }
                        else
                        {
                            DataRow row;
                            row = newTable.NewRow();
                            row["BonusDate"] = i;
                            row["DailyBonus"] = amount;
                            newTable.Rows.Add(row);

                        }

                    }
                    GridDailyBonusGenerate.DataSource = newTable;
                    GridDailyBonusGenerate.DataBind();

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
            else if (userAccount.historyOf == 2)
            {
                try
                {
                    var j = 0;
                    DataTable dt = userAccount.getTotalMatchingCommissionListbyDateRange(fromDateTextBox.Text, toDateTextBox.Text);

                    DataTable newTable = new DataTable();
                    DataColumn column;
                    column = newTable.Columns.Add();
                    column.ColumnName = "TransectionDate";
                    column.DataType = typeof(DateTime);

                    column = newTable.Columns.Add();
                    column.ColumnName = "Amount";
                    column.DataType = typeof(string);
                    DateTime StartDate = DateTime.ParseExact(fromDateTextBox.Text, "dd/MM/yyyy", null); ; ;
                    DateTime EndDate = DateTime.ParseExact(toDateTextBox.Text, "dd/MM/yyyy", null); ;


                    for (var i = StartDate; i <= EndDate; i = i.AddDays(1))
                    {

                        double amount = 0;
                        while (j < dt.Rows.Count && i == DateTime.ParseExact(dt.Rows[j]["TransectionDate"].ToString(), "dd/MM/yyyy", null))
                        {
                            amount += Convert.ToDouble(dt.Rows[j]["Amount"]);
                            j++;

                        }

                        if (amount < 1)
                        {
                            continue;
                        }
                        else
                        {
                            DataRow row;
                            row = newTable.NewRow();
                            row["TransectionDate"] = i;
                            row["Amount"] = amount;
                            newTable.Rows.Add(row);


                        }

                    }
                    GridCommision.DataSource = newTable;
                    GridCommision.DataBind();


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
            else
            {
                msgbox.Attributes.Add("Class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Select a list!!!"; msgDetailLabel.Text = "";
            }
        }
        private void GridviewHeadStyle()
        {
            if (Convert.ToInt32(ddlHistory.SelectedValue) == 0)
            {
                if (GridViewGeneratedMoneyList.Rows.Count > 0)
                {
                    GridViewGeneratedMoneyList.UseAccessibleHeader = true;
                    GridViewGeneratedMoneyList.HeaderRow.TableSection = TableRowSection.TableHeader;

                }
            }
            if (Convert.ToInt32(ddlHistory.SelectedValue) == 1)
            {
                if (GridDailyBonusGenerate.Rows.Count > 0)
                {
                    GridDailyBonusGenerate.UseAccessibleHeader = true;
                    GridDailyBonusGenerate.HeaderRow.TableSection = TableRowSection.TableHeader;

                }
            }
            if (Convert.ToInt32(ddlHistory.SelectedValue) == 2)
            {
                if (GridCommision.Rows.Count > 0)
                {
                    GridCommision.UseAccessibleHeader = true;
                    GridCommision.HeaderRow.TableSection = TableRowSection.TableHeader;

                }
            }

        }

    }
}