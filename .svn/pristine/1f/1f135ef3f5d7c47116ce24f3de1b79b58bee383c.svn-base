<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="varify.aspx.cs" Inherits="globalfx.page.varify" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="row-fluid">


        <div class="grid simple horizontal purple">
            <div class="grid-title text-center">

                <h2 class="section-title">
                    <span class="semi-bold">Varify and Reset </span></></h2>

            </div>

            <div class="grid-body">
                <div class="row-fluid">
                    <div class="span12">
                        <div class="span2">
                        </div>
                        <div class="span10">
                            <h4>Hi
                    <asp:Label ID="userNameLabel" runat="server" Text=""></asp:Label>,<span class="title-small">Varify
                        & Set Your Password</span></h4>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row-fluid" id="varificationSection" runat="server" visible="False">
                    <div class="span2">
                    </div>
                    <div class="span10">
                        <div class="control-group">
                            <div class="input-with-icon  right">
                                <label>Verification Code</label>

                                <asp:TextBox class="span3" ID="verificationCodeTextBox" runat="server" placeholder="Verification Code"></asp:TextBox>

                            </div>
                        </div>
                        <div class="row-fluid">

                            <div class="span12">

                                <asp:Button ID="verifyButton" runat="server" Text="Verify Here" CssClass="btn btn-primary margin-top-bottom-10px" OnClick="verifyButton_Click" />
                            </div>

                        </div>
                    </div>

                </div>
                <div class="row-fluid" id="changePasswordSection" runat="server" visible="False">
                    <div class="span2">
                    </div>
                    <div class="span10">


                        <div class="row-fluid">
                            <div class="control-group">
                                <label class="control-label">New Password </label>

                                <div class="controls">
                                    <asp:TextBox ID="newPasswordTextBox" class="form-control" TextMode="Password" runat="server" required="required"
                                        placeholder="New Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rqrvalidpass" ControlToValidate="newPasswordTextBox"
                                        ErrorMessage="*" Display="Dynamic" ForeColor="red" runat="server" /><br />
                                    <asp:RegularExpressionValidator ID="revChPassword" runat="server" Display="dynamic"
                                        ControlToValidate="newPasswordTextBox" ErrorMessage="Password must be 6 - 10 char and containing at least an alphabet and one Number"
                                        ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{6,10})$" CssClass="text-danger" />
                                </div>

                            </div>
                            <div class="row-fluid">
                                <div class="control-group">
                                    <label class="control-label">Confirm Password</label>

                                    <div class="controls">
                                        <asp:TextBox ID="confirmPasswordTextBox" class="form-control" TextMode="Password" runat="server" required="required"
                                            placeholder="Confirm Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvConPassword" ControlToValidate="confirmPasswordTextBox"
                                            ErrorMessage="*" Display="Dynamic" ForeColor="red" runat="server" /><br />
                                        <asp:CompareValidator ID="cmvPasswordRpt" Font-Size="11px" runat="server" Display="Dynamic"
                                            EnableClientScript="true" ValidationGroup="edit" ControlToValidate="confirmPasswordTextBox"
                                            ValidateEmptyText="true" ErrorMessage="Your passwords do not match." ControlToCompare="newPasswordTextBox"
                                            ForeColor="Red" />
                                    </div>
                                </div>
                            </div>

                            <div class="row-fluid">

                                <asp:Button ID="okButton" runat="server" Text="Set Password" CssClass="btn btn-primary margin-top-bottom-10px" OnClick="okButton_Click" />

                            </div>
                        </div>
                    </div>
                </div>
                <asp:HiddenField ID="hdnfldUserID" runat="server" />
                <asp:HiddenField ID="hdnfldVarifiCode" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
</asp:Content>
