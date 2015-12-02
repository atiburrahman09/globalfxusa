﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="pin.aspx.cs" Inherits="globalfx.a.stake.pin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <div class="row-fluid">
        <div class="span6">
            <div class="grid simple horizontal purple">
                <div class="grid-title text-center">
                    <h4 class="text-center">Stake <span class="semi-bold">PIN</span></h4>

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
                        <div class="span6">
                            <div class="control-group">
                                <div class="input-with-icon  right">
                                    <label>Stake Package</label>
                                    <asp:DropDownList ID="ddlStakeList" CssClass="span12" runat="server"></asp:DropDownList>
                                </div>

                            </div>
                            <div class="control-group">
                                <div class="input-with-icon  right">
                                    <label>Number of PIN:</label>
                                    <asp:TextBox Class="span12" ID="txtbxTotalPin" type="number" runat="server" placeholder="No. of Pin"></asp:TextBox>

                                </div>
                            </div>
                            <div class="control-group">
                                <div class="input-with-icon  right">
                                    <label>Your Password:</label>
                                    <asp:TextBox Class="span12" ID="txtbxPassword" Type="password" runat="server" placeholder="Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-actions">
                        <div class="pull-right">

                            <asp:Button ID="btnGenerate" CssClass="btn btn-primary btn-cons" runat="server" Text="Generate" OnClick="btnGenerate_Click" />

                            <asp:Button class="btn btn-primary btn-cons" ID="btnCancel" runat="server" Text="Cancel" />

                        </div>
                    </div>

                </div>
            </div>
        </div>

        <div class="span6">
            <div class="grid simple horizontal purple">
                <div class="grid-title text-center">
                    <h4 class="text-center">Stake <span class="semi-bold">Status</span></h4>

                </div>
                <div class="grid-body">

                    <div class="row-fluid">
                        <div class="control-group" style="margin: 30px;">
                            <div class="input-with-icon  right total_count">
                                <p>
                                    Total Generate: <span>
                                        <asp:Label ID="lblTotalGenerate" runat="server" Text="0"></asp:Label></span>
                                </p>
                                <p>
                                    Total Used: <span>
                                        <asp:Label ID="lblTotalUsed" runat="server" Text="0"></asp:Label></span>
                                </p>
                                <p>
                                    Active: <span>
                                        <asp:Label ID="lblTotalActive" runat="server" Text="0"></asp:Label></span>
                                </p>
                                <p>
                                    Inactive <span>
                                        <asp:Label ID="lblTotalInactive" runat="server" Text="0"></asp:Label></span>
                                </p>

                            </div>

                        </div>
                    </div>


                </div>
            </div>
        </div>
        <div class="row-fluid">
            <div class="grid simple horizontal purple">
                <div class="grid-body">
                    <asp:GridView ID="gridviewStakePin" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="Serial" HeaderText="#" />
                            <asp:BoundField DataField="StakeName" HeaderText="Stake Name" />
                            <asp:BoundField DataField="StakePin" HeaderText="KEY" />
                            <asp:BoundField DataField="CreatedBy" HeaderText="Created By" />
                            <asp:BoundField DataField="CreatedFrom" HeaderText="Created From" />
                            <asp:BoundField DataField="CreatedDate" HeaderText="Created Date" DataFormatString="{0:dd MMMM yy -hh:mm tt}" />
                            <asp:BoundField DataField="IsActive" HeaderText="Is Active" />
                            <asp:BoundField DataField="IsUsed" HeaderText="Is Used" />
                            <asp:BoundField DataField="UsedBy" HeaderText="Used By" />
                            <asp:BoundField DataField="PinOwner" HeaderText="KEY Owner" />

                            <%-- <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:LinkButton ID="editLinkButton" runat="server" CssClass="btn btn-mini btn-warning"
                                        OnClick="editLinkButton_Click">Edit</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Activation">
                                <ItemTemplate>
                                    <asp:LinkButton ID="activateLinkButton" runat="server" CssClass="btn btn-mini btn-success"
                                        OnClick="activateLinkButton_Click" OnClientClick="return confirm('Are you sure you want to activate this Key?');"><%# Eval("PinActivation")%></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">

        $(function pageLoad(sender, args) {
            $("#gridviewStakePin").dataTable({
                "bStateSave": true


            });
        });
    </script>
</asp:Content>
