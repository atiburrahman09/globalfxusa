<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="dailybonus.aspx.cs" Inherits="globalfx.a.account.dailybonus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="row-fluid">
        <div class="grid simple horizontal purple">
            <div class="grid-title text-center">
                <h3 class="text-center"><span class="semi-bold">Daily</span> Bonus</h3>
            </div>
            <div class="grid-body">
                <div id="msgbox" runat="server" visible="false" class="alert alert-block alert-success">
                    <button data-dismiss="alert" class="close" type="button">
                        <i class="icon icontimes"></i>
                    </button>
                    <h4>
                        <asp:Label ID="msgTitleLabel" runat="server" Text=""></asp:Label>
                    </h4>
                    <asp:Label ID="msgDetailLabel" runat="server" Text=""></asp:Label>
                </div>
                <div class="row-fluid">
                    <div class="span3">

                        <div class="controls">
                            <label>&nbsp;</label>
                            <asp:Button class="btn btn-success btn-cons" ID="btnTodayBonusGenerate" runat="server" OnClick="dailyBonusGenerateButton_Click" Text="Generate Daily Bonus" />

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
                    <div class="span3 pull-right">
                        <label>&nbsp;</label>
                        <asp:Button class="btn btn-primary btn-cons" ID="btnShow" runat="server" OnClick="ViewButton_Click" Text="Show Daily Bonus" />

                    </div>
                </div>
                <div class="row-fluid">
                    <div class="clearfix"></div>
                    <asp:GridView ID="GridDailyBonusGenerate" runat="server" AutoGenerateColumns="false"
                        CssClass="table table-hover">
                        <Columns>
                            <asp:BoundField DataField="Serial" HeaderText="#" />
                            <asp:BoundField DataField="UserId" HeaderText="User Id" />
                            <asp:BoundField DataField="DailyBonus" HeaderText="Bonus ($)" />
                            <asp:BoundField DataField="BonusDate" HeaderText="Date" DataFormatString="{0:dd MMMM yy -hh:mm tt}" />
                            <asp:BoundField DataField="InvestAmount" HeaderText="Invest ($)" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {

            var dateFormat = '<%= Session["DateFormatForDatePicker"] %>';
            $(".date-textbox").datepicker({ format: dateFormat });
            $(".date-textbox, .icon-calendar").click(function() {
                $(this).parent().find(".date-textbox").focus();
            });
            
            $('#GridDailyBonusGenerate').dataTable({
                "bStateSave": true,
            });
            $("#btnTodayBonusGenerate").click(function () {
                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });


        }
    </script>
</asp:Content>
