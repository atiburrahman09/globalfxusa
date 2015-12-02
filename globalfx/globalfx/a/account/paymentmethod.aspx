﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="paymentmethod.aspx.cs" Inherits="globalfx.a.account.paymentmethod" %>

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
        <div class="span6">
            <div class="grid simple">
                <div class="grid-body no-border">
                    <h4 class="text-center" style="padding-top: 20px">Payment <span class="semi-bold">Method</span></h4>
                    <asp:Label ID="lblSerial" runat="server" Text="" Visible="false"></asp:Label>
                    <div class="row-fluid">
                        <div class="span6">
                            <div class="control-group">
                                <div class="input-with-icon  right">
                                    <label><b>Type:</b></label>
                                    <asp:DropDownList class="span12" ID="ddlType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                        <asp:ListItem Text="Select Please" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Bank" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Card" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Online" Value="2"></asp:ListItem>

                                    </asp:DropDownList>

                                </div>

                            </div>
                            <div class="control-group" id="divBankName" runat="server" visible="False">
                                <div class="input-with-icon  right">
                                    <label><b>Bank Name:</b></label>
                                    <asp:TextBox class="span12" ID="txtbxBankName" runat="server" placeholder="Bank Name"></asp:TextBox>

                                </div>
                            </div>
                            <div class="control-group" id="divBank" runat="server" visible="False">
                                <div class="input-with-icon  right">
                                    <label><b>Bank Account No:</b></label>
                                    <asp:TextBox class="span12" ID="txtbxAccountNo" runat="server" placeholder="Account No"></asp:TextBox>

                                </div>
                            </div>
                            <div class="control-group" id="divCard" runat="server" visible="False">
                                <label>Card Number</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtbxCardNumber" type="text" class="span10" placeholder="CardNumber" runat="server" AutoPostBack="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="control-group" id="divSwift" runat="server" visible="False">
                                <div class="input-with-icon  right">
                                    <label><b>Swift Code:</b></label>
                                    <asp:TextBox class="span12" ID="txtbxSwiftCode" runat="server" placeholder="Swift Code"></asp:TextBox>

                                </div>
                            </div>

                            <div class="control-group" id="divCardOwner" runat="server" visible="False">
                                <div class="input-with-icon  right">
                                    <label><b>Card Owner Name</b></label>
                                    <asp:TextBox class="span12" ID="txtbxCardOwnerName" runat="server" placeholder="Card Owner Name"></asp:TextBox>

                                </div>
                            </div>

                            <div class="control-group" id="divCardExpireDate" runat="server" visible="False">
                                <div class="input-with-icon  right">
                                    <label>Card Expire Date</label>
                                    <div class="input-append success date">
                                        <asp:TextBox ID="txtbxCardExpireDate" data-date-format="dd/mm/yyyy" CssClass="date-textbox span10"
                                            runat="server"></asp:TextBox>
                                        <span class="add-on"><span class="arrow"></span><i class="icon-th"></i></span>
                                    </div>

                                </div>
                            </div>

                            <div class="control-group" id="divOnlineEmail" runat="server" visible="False">
                                <div class="input-with-icon  right">
                                    <label><b>Email Address:</b></label>
                                    <asp:TextBox class="span12" ID="txtbxEmail" runat="server" placeholder="Email"></asp:TextBox>

                                </div>
                            </div>

                            <div class="control-group" id="divOwnerName" runat="server" visible="False">
                                <div class="input-with-icon  right">
                                    <label><b>Gateway Name:</b></label>
                                    <asp:TextBox class="span12" ID="txtbxOwnerName" runat="server" placeholder="Name"></asp:TextBox>

                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="form-actions">
                        <div class="text-center">
                            <asp:Button class="btn btn-primary btn-cons" ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                        </div>
                    </div>

                </div>
            </div>
        </div>


        <div class="clearfix"></div>
        <br />
        <br />
        <div class="row-fluid">
            <div class="clearfix"></div>
            <asp:GridView ID="GridViewPaymentMethod" runat="server" AutoGenerateColumns="false"
                CssClass="table table-hover">
                <Columns>
                    <asp:BoundField DataField="Serial" HeaderText="#" Visible="True" />
                    <asp:BoundField DataField="UserId" HeaderText="User Id" Visible="False" />
                    <asp:BoundField DataField="GatewayType" HeaderText="Gateway Type" Visible="False" />
                    <asp:BoundField DataField="BankName" HeaderText="Bank Name" Visible="False" />
                    <asp:BoundField DataField="BankAccount" HeaderText="Bank A/C" Visible="False" />
                    <asp:BoundField DataField="SwiftCode" HeaderText="Swift Code" Visible="False" />
                    <asp:BoundField DataField="CardNo" HeaderText="Card No" Visible="False" />
                    <asp:BoundField DataField="CardWoner" HeaderText="CardWoner" Visible="False" />
                    <asp:BoundField DataField="ExpireDate" HeaderText="Expire Date" DataFormatString="{0:dd MMMM yy -hh:mm tt}" Visible="False" />
                    <asp:BoundField DataField="GatewayEmail" HeaderText="Gateway Email" Visible="False" />
                    <asp:BoundField DataField="GatewayOwner" HeaderText="Gateway Name" Visible="False" />
                    
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton ID="EditLinkButton" CssClass="btn btn-success" runat="server" OnClick="EditLinkButton_OnClick">Edit</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>



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

            $('#GridViewPaymentMethod').dataTable({
                "bStateSave": true,
            });



        }
    </script>
</asp:Content>
