<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="withdrawlist.aspx.cs" Inherits="globalfx.a.account.withdrawlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="grid simple horizontal purple">
        <div class="grid-title text-center">
            <h3 class="text-center"><span class="semi-bold">Withdraw </span>Request</h3>
        </div>
        <div class="grid-body">
            <div class="row-fluid">
                <div class="span3">
                    <label>From Date</label>
                    <div class="input-append success date">



                        <asp:TextBox ID="fromDateTextBox" data-date-format="dd/mm/yyyy" CssClass="date-textbox"
                            runat="server"></asp:TextBox>
                        <span class="add-on"><span class="arrow"></span><i class="icon-th"></i></span>
                    </div>

                </div>
                <div class="span3">
                    <label>To Date</label>
                    <div class="input-append success date">
                        <asp:TextBox ID="toDateTextBox" data-date-format="dd/mm/yyyy" CssClass="date-textbox"
                            runat="server"></asp:TextBox>
                        <span class="add-on"><span class="arrow"></span><i class="icon-th"></i></span>
                    </div>
                </div>
                <div class="span3">
                    <label>Status</label>
                    <div class="controls">
                        <asp:DropDownList ID="ddlStatus" runat="server">
                            <asp:ListItem Text="Select Please" Value=""></asp:ListItem>
                            <asp:ListItem Text="Pending" Value="P"></asp:ListItem>
                            <asp:ListItem Text="Rejected" Value="R"></asp:ListItem>
                            <asp:ListItem Text="Success" Value="A"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="pull-right">
                    <label>&nbsp;</label>
                    <asp:Button class="btn btn-primary btn-cons" ID="btnShow" runat="server" OnClick="ViewButton_Click" Text="Show Income Statement" />

                </div>
            </div>
            <div class="row-fluid">
                <div class="clearfix"></div>
                <asp:GridView ID="GridViewWithdrawRequest" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover">
                    <Columns>
                        <asp:BoundField DataField="TransferId" HeaderText="#" />
                        <asp:BoundField DataField="TransferTo" HeaderText="To" />
                        <asp:BoundField DataField="BankName" HeaderText="Gateway" />
                        <asp:BoundField DataField="SwiftCode" HeaderText="AC/No" />
                        <asp:BoundField DataField="Amount" HeaderText="Amount ($)" />
                        <asp:BoundField DataField="TransferNote" HeaderText="Note" />
                        <asp:BoundField DataField="RejectNote" HeaderText="Reject Note" />
                        <asp:BoundField DataField="SuccessNote" HeaderText="Sucess Note" />
                        <asp:BoundField DataField="CreatedDate" HeaderText="Date" DataFormatString="{0:dd MMMM yy -hh:mm tt}" />
                        <asp:BoundField DataField="CreatedFrom" HeaderText="Request From" />
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="sendLinkButton" runat="server" CssClass="btn btn-info"
                                    OnClick="ReceiveKeyLinkButton_Click" OnClientClick="return confirm('Are you sure you want to Approve.?');"> Approve</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="RejectLinkButton" runat="server" CssClass="btn btn-danger"
                                    OnClick="RejectKeyLinkButton_Click" OnClientClick="return confirm('Are you sure you want to Reject?');"> Reject</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
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

            $('#GridViewWithdrawRequest').dataTable({
                "bStateSave": true,
            });



        }
    </script>
</asp:Content>
