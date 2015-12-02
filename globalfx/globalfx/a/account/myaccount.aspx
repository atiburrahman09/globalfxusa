﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="myaccount.aspx.cs" Inherits="globalfx.a.account.myaccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <h3 class="text-center">User<span class="semi-bold"> Account Info:</span></h3>
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
        <div class="span3">
            <div class="bg_whtie radius_top_bottom">
                <div class="grid-body no-border">
                    <h4 class="text-center" style="padding-top: 20px;">Income <span class="semi-bold">Wallet</span></h4>
                    <div class="row-fluid">
                        <div class="control-group" style="margin: 30px;">
                            <div class=" total_count">
                                <p>
                                   <span>$</span>  <asp:Label class="text-center font20" ID="lvlIncome" runat="server" Text=""></asp:Label>
                                </p>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="span3">
            <div class="bg_whtie radius_top_bottom">
                <div class="grid-body no-border">
                    <h4 class="text-center" style="padding-top: 20px">Deposit <span class="semi-bold">Wallet</span></h4>
                    <div class="row-fluid">
                        <div class="control-group" style="margin: 30px;">
                            <div class=" total_count">
                                <p>
                                   <span>$</span> <asp:Label class="text-center font20" ID="lvlDeposit" runat="server" Text=""></asp:Label>
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div class="span12 text-center">
                            <asp:Button ID="btnDeposit" CssClass="btn btn-success" runat="server" Visible="False" Text="Transfer To Income" OnClick="btnDepositTransfer_OnClick" />
                        </div>
                        <div class="span12" runat="server" id="Deposit" visible="False">


                            <div class="control-group">
                                <label class="control-label">
                                    Ammount<span class="red">*</span>
                                </label>
                                <div class="controls">
                                    <div class="input-prepend inside span12">

                                        <asp:TextBox ID="txtbxDepositAmmount" class="form-control" required="required" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">
                                    Pin<span class="red">*</span>
                                </label>
                                <div class="controls">
                                    <div class="input-prepend inside span12">
                                        <asp:TextBox ID="txtbxDepositPin" CssClass="form-control" required="requierd" runat="server"></asp:TextBox>
                                    </div>
                                    <asp:Button ID="btnDepositOk" CssClass="btn btn-primary btn-cons" runat="server" Text="OK" OnClick="btnDepositOk_OnClick" />
                                    <asp:Button ID="btnDepositCancel" CssClass="btn btn-warning" runat="server" Text="Cancel" OnClick="btnDepositCancel_OnClick" />
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="span3">
            <div class="bg_whtie radius_top_bottom">
                <div class="grid-body no-border">
                    <h4 class="text-center" style="padding-top: 20px">Commission <span class="semi-bold">Wallet</span></h4>
                    <div class="row-fluid">
                        <div class="control-group" style="margin: 30px;">
                            <div class=" total_count">
                                <p>
                                   <span>$</span> <asp:Label class="text-center font20" ID="lvlCommision" runat="server" Text=""></asp:Label>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span12 text-center">
                        <asp:Button ID="btnCommissionTransfer" CssClass="btn btn-success" runat="server" Visible="False" Text="Transfer To Income" OnClick="btnCommissionTransfer_OnClick" />
                    <br/>
                    </div>

                    <div class="span12" runat="server" id="Commission" visible="False">
                        <div class="">
                            <div class="">
                                <div class="control-group">
                                    <label class="control-label">
                                        Ammount<span class="red">*</span>
                                    </label>
                                    <div class="controls">
                                        <div class="input-prepend inside span12">
                                            <asp:TextBox ID="txtbxCommissionAmount" class="form-control" required="required" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="">
                                <div class="control-group">
                                    <label class="control-label">
                                        Pin<span class="red">*</span>
                                    </label>
                                    <div class="controls">
                                        <div class="input-prepend inside span12">
                                            <asp:TextBox ID="txtbxPinCommission" required="required" CssClass="form-control" class="form-control1"
                                                runat="server"></asp:TextBox>
                                        </div>
                                        <asp:Button ID="btnCommissionOK" CssClass="btn btn-primary btn-cons" runat="server" Text="OK" OnClick="btnCommissionOK_OnClick" />
                                        <asp:Button ID="btnCommissionCancel" CssClass="btn btn-warning" runat="server" Text="Cancel" OnClick="btnCommissionCancel_OnClick" />
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="span3">
            <div class="bg_whtie radius_top_bottom">
                <div class="grid-body no-border">
                    <h4 class="text-center" style="padding-top: 20px">Fx <span class="semi-bold">Fund</span></h4>
                    <div class="row-fluid">
                        <div class="control-group" style="margin: 30px;">
                            <div class=" total_count">
                                <p>
                                   <span>$</span> <asp:Label class="text-center font20" ID="lvlFund" runat="server" Text=""></asp:Label>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <asp:Button ID="btnFxFundTransfer" CssClass="btn btn-primary" runat="server" Visible="False" Text="Transfer To Income" OnClick="btnFxFundTransfer_OnClick" />
                    </div>

                    <div class="span12" runat="server" id="FxFund" visible="False">
                        <div class="">
                            <div class="">
                                <div class="control-group">
                                    <label class="control-label">
                                        Ammount<span class="red">*</span>
                                    </label>
                                    <div class="controls">
                                        <div class="input-prepend inside span12">

                                           <span>$</span> <asp:TextBox ID="txtbxFxAmmount" class="form-control" required="required" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="">
                                <div class="control-group">
                                    <label class="control-label">
                                        Pin<span class="red">*</span>
                                    </label>
                                    <div class="controls">
                                        <div class="input-prepend inside span12">
                                            <asp:TextBox ID="txtbxFxPin" required="required" CssClass="form-control" class="form-control1"
                                                runat="server"></asp:TextBox>
                                        </div>
                                        <asp:Button ID="btnFxOK" CssClass="btn btn-primary" runat="server" Text="OK" OnClick="btnFxOK_OnClick" />
                                        <asp:Button ID="btnFxCancel" CssClass="btn btn-warning" runat="server" Text="Cancel" OnClick="btnFxCancel_OnClick" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="form-actions">
            <br />
            <div class="grid simple horizontal purple">
                <div class="grid-title text-center">
                    <h3 class="text-center"><span class="semi-bold">Income </span>Calender:</h3>
                </div>
                <div class="grid-body">
                    <div class="row-fluid">
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
                                <asp:BoundField DataField="Receiveon" HeaderText="Transection" />
                                <asp:BoundField DataField="Particular" HeaderText="Narration" />
                                <asp:BoundField DataField="DebitAmount" HeaderText="Receive($)" />
                                <asp:BoundField DataField="CreditAmount" HeaderText="Payment($)" />
                                <asp:BoundField DataField="BalanceAmount" HeaderText="Balance($)" />
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
            })

            $('#GridViewBlanceSheet').dataTable({
                "bStateSave": true,
            });



        }
    </script>
</asp:Content>
