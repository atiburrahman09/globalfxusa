﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="incomehistoryall.aspx.cs" Inherits="globalfx.a.account.accountreport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="grid simple horizontal purple">
        <div class="grid-title text-center">
            <h3 class="text-center"><span class="semi-bold">Income </span>Calender:</h3>
        </div>
        <div class="grid-body">
            <div class="row-fluid">
                <div class="clearfix"></div>
                <asp:GridView ID="GridViewIncomeSamary" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="UserId" HeaderText="#" />
                        <asp:BoundField DataField="Income" HeaderText="Income ($)" />
                        <asp:BoundField DataField="Deposit" HeaderText="Deposit ($)" />
                        <asp:BoundField DataField="Commission" HeaderText="Commision ($)" />
                        <asp:BoundField DataField="FxFund" HeaderText="FX Fund ($)" />
                        <asp:BoundField DataField="TotalIncome" HeaderText="Total Income ($)" />

                    </Columns>
                </asp:GridView>
            </div>
            <h3 class="text-center semi-bold">Income History</h3>
            <div class="row-fluid">
                <div class="span3">
                    <label>User Name</label>
                    <div class="input-append success date">

                        <asp:TextBox ID="txtbxUserId" CssClass="span11" runat="server"></asp:TextBox>

                    </div>

                </div>
                <div class="span3">
                    <label>From Date</label>
                    <div class="input-append success date">

                        <asp:TextBox ID="fromDateTextBox" data-date-format="dd/mm/yyyy" CssClass="date-textbox span10"
                            runat="server"></asp:TextBox>
                        <span class="add-on"><span class="arrow"></span><i class="icon-th"></i></span>
                    </div>

                </div>
                <div class="span3">
                    <label>To Date</label>
                    <div class="input-append success date">
                        <asp:TextBox ID="toDateTextBox" data-date-format="dd/mm/yyyy" CssClass="date-textbox span10"
                            runat="server"></asp:TextBox>
                        <span class="add-on"><span class="arrow"></span><i class="icon-th"></i></span>
                    </div>
                </div>

                <div class="span2 pull-right">
                    <label>&nbsp;</label>
                    <asp:Button class="btn btn-primary btn-cons" ID="btnShow" runat="server" OnClick="ViewButton_Click" Text="Show Income Statement" />

                </div>
            </div>
            <div class="row-fluid">
                <div class="clearfix"></div>
                <asp:GridView ID="GridViewBlanceSheet" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="TransectionId" HeaderText="Transection Id" />
                        <asp:BoundField DataField="TransectionDate" HeaderText="Date" />
                        <asp:BoundField DataField="Receiveon" HeaderText="Tramnsection" />
                        <asp:BoundField DataField="Particular" HeaderText="Narration" />
                        <asp:BoundField DataField="DebitAmount" HeaderText="Receive ($)" />
                        <asp:BoundField DataField="CreditAmount" HeaderText="Payment ($)" />
                        <asp:BoundField DataField="BalanceAmount" HeaderText="Balance ($)" />
                    </Columns>
                </asp:GridView>



            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {

            var dateFormat = '<%= Session["DateFormatForDatePicker"] %>';
            $(".date-textbox").datepicker({ format: dateFormat });
            $(".date-textbox, .icon-calendar").click(function () {
                $(this).parent().find(".date-textbox").focus();
            })

            $('#GridViewBlanceSheet').dataTable({
                "bStateSave": true,
            });
            $('#GridViewIncomeSamary').dataTable({
                "bStateSave": true,
            });



        }
    </script>
</asp:Content>
