﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="pinset.aspx.cs" Inherits="globalfx.setting.User.pinset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="false">
        <ContentTemplate>

            <div class="row-fluid">
                <div id="msgbox" runat="server" visible="false" class="alert alert-block alert-success">
                    <button data-dismiss="alert" class="close" type="button">
                        <i class="icon icon-times"></i>
                    </button>
                    <h4>
                        <asp:Label ID="msgTitleLabel" runat="server" Text=""></asp:Label>
                    </h4>
                    <asp:Label ID="msgDetailLabel" runat="server" Text=""></asp:Label>
                </div>
                <div class="row-fluid">

                    <div class="grid simple horizontal purple" style="opacity: 1;">
                        <div class="grid-title">
                            <h3 class="widget-title bigger lighter">
                                <i class="icon icon-table"></i>&nbsp; Change Pin
                            </h3>

                        </div>
                        <asp:HiddenField ID="hbdforId" runat="server" />

                        <div class="grid-body">
                            <div class="row-fluid">
                                <div class="row-fluid">
                                    <div class="alert alert-warning">
                                        <button data-dismiss="alert" class="close"></button>
                                        <span class="semi-bold">You already Changed PIN
                                            <asp:Label ID="lblChangeCout" CssClass="link" runat="server" Text="0"></asp:Label>
                                            times. Can not change PIN after 3 Times with out pay 5$.</span>
                                        <asp:Button ID="btnPayforPinGenerate" CssClass="btn btn-success btn-cons" Visible="False" runat="server" Text="Pay($5) to Generate Pin." OnClick="btnPayforPinGenerate_Click" />
                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div class="control-group">
                                        <label class="control-label">
                                            Current Pin
                                        </label>
                                        <div class="controls">
                                            <asp:TextBox ID="currentPinTextBox" class="form-control" runat="server" TextMode="Password" required="required"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="2" ControlToValidate="currentPinTextBox"
                                                ErrorMessage="*" Display="Dynamic" ForeColor="red" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div class="control-group">
                                        <label class="control-label">
                                            New Pin
                                        </label>
                                        <div class="controls">
                                            <asp:TextBox ID="newPinTextBox" runat="server" class="form-control" TextMode="Password" required="required"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rqrvalidpass" ValidationGroup="2" ControlToValidate="newPinTextBox"
                                                ErrorMessage="*" Display="Dynamic" ForeColor="red" runat="server" /><br />
                                            <asp:RegularExpressionValidator ID="revChPin" runat="server" Display="dynamic"
                                                ControlToValidate="newPinTextBox" Font-Size="11px" ErrorMessage="Pin must be 4-6 nonblank value."
                                                ValidationExpression="[^\s]{4,6}" ForeColor="Red" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div class="control-group">
                                        <label class="control-label">
                                            Confirm New Pin
                                        </label>
                                        <div class="controls">
                                            <asp:TextBox ID="confirmNewPinTextBox" class="form-control" runat="server" TextMode="Password" required="required"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvConPin" ValidationGroup="2" ControlToValidate="confirmNewPinTextBox"
                                                ErrorMessage="*" Display="Dynamic" ForeColor="red" runat="server" /><br />
                                            <asp:CompareValidator ID="cmvPinRpt" Font-Size="11px" runat="server" Display="Dynamic"
                                                EnableClientScript="true" ValidationGroup="edit" ControlToValidate="confirmNewPinTextBox"
                                                ValidateEmptyText="true" ErrorMessage="Your pin do not match." ControlToCompare="newPinTextBox"
                                                ForeColor="Red" />
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="row-fluid">

                                <asp:Button ID="btnChangePin" CssClass="btn btn-success btn-cons" runat="server" Text="Change Pin" OnClick="btnChangePin_Click" />


                                <br />
                            </div>



                        </div>
                    </div>
                </div>
            </div>


        </ContentTemplate>

    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
</asp:Content>
