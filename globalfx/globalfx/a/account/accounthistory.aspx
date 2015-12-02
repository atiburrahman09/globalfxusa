﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="accounthistory.aspx.cs" Inherits="globalfx.a.account.accounthistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="row-fluid">
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
            <div class="span4">
                <div class="bg_whtie radius_top_bottom">
                    <div class="grid-body no-border">
                        <h4 class="text-center" style="padding-top: 20px;">Money <span class="semi-bold">Generate</span></h4>
                        <div class="row-fluid">
                            <div class="control-group" style="margin: 30px;">
                                <div class=" total_count">
                                    <p>
                                        <asp:Label class="text-center font20" ID="lvlMoneyGenerate" runat="server" Text=""></asp:Label>
                                    </p>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="span4">
                <div class="bg_whtie radius_top_bottom">
                    <div class="grid-body no-border">
                        <h4 class="text-center" style="padding-top: 20px">Daily <span class="semi-bold">Bonus</span></h4>
                        <div class="row-fluid">
                            <div class="control-group" style="margin: 30px;">
                                <div class=" total_count">
                                    <p>
                                        <asp:Label class="text-center font20" ID="lvlDailyBonus" runat="server" Text=""></asp:Label>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="span4">
                <div class="bg_whtie radius_top_bottom">
                    <div class="grid-body no-border">
                        <h4 class="text-center" style="padding-top: 20px"><span class="semi-bold">Commission</span></h4>
                        <div class="row-fluid">
                            <div class="control-group" style="margin: 30px;">
                                <div class=" total_count">
                                    <p>
                                        <asp:Label class="text-center font20" ID="lvlCommission" runat="server" Text=""></asp:Label>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="clearfix"></div>

        <div class="form-actions">
            <br />
            <div class="grid simple horizontal purple">

                <div class="grid-body">
                    <div class="row-fluid">
                        <div class="span3">
                            <label><b>History Of:</b></label>
                            <asp:DropDownList ID="ddlHistory" runat="server">
                                <asp:ListItem Text="Select Please" Value=""></asp:ListItem>
                                <asp:ListItem Text="Money Generate" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Daily Bonus" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Commission" Value="2"></asp:ListItem>
                            </asp:DropDownList>
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

                        <div class="pull-right">
                            <label>&nbsp;</label>
                            <asp:Button class="btn btn-primary btn-cons" ID="btnShow" runat="server" OnClick="ViewButton_Click" Text=" View " />

                        </div>
                    </div>
                    <div class="row-fluid">
                        <div class="clearfix"></div>
                        <asp:GridView ID="GridViewGeneratedMoneyList" runat="server" AutoGenerateColumns="false"
                            CssClass="table table-hover">
                            <Columns>
                                <asp:BoundField DataField="Serial" HeaderText="#" />
                                <asp:BoundField DataField="GenerateDate" HeaderText="Date" DataFormatString="{0:dd MMMM yy}" />
                                <asp:BoundField DataField="Amount" HeaderText="Amount ($)" />


                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="GridDailyBonusGenerate" runat="server" AutoGenerateColumns="false"
                            CssClass="table table-hover">
                            <Columns>
                                <asp:BoundField DataField="BonusDate" HeaderText="Date" DataFormatString="{0:dd MMMM yy}" />
                                <asp:BoundField DataField="DailyBonus" HeaderText="Bonus ($)" />

                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="GridCommision" runat="server" AutoGenerateColumns="false"
                            CssClass="table table-hover">
                            <Columns>
                                <asp:BoundField DataField="TransectionDate" HeaderText="Date" DataFormatString="{0:dd MMMM yy}" />
                                <asp:BoundField DataField="Amount" HeaderText="Commission Amount ($)" />
                                
                            </Columns>
                        </asp:GridView>


                    </div>
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
            $(".date-textbox, .icon-calendar").click(function () {
                $(this).parent().find(".date-textbox").focus();
            });

            $('#GridViewGeneratedMoneyList').dataTable({
                "bStateSave": true,
            });
            $('#GridDailyBonusGenerate').dataTable({
                "bStateSave": true,
            });
            $('#GridCommision').dataTable({
                "bStateSave": true,
            });



        }
    </script>
</asp:Content>
