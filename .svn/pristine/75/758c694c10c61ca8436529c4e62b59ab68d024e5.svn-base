<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="globalfx.setting.User.ChangePassword" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headPlaceHolder" runat="server">
    <link href="/Content/Style/PasswordStrength.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
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
                            <h5 class="widget-title bigger lighter">
                                <i class="icon icon-table"></i><small class="white"><i class="icon icon-angle-double-right"></i>Change User Password</small>
                            </h5>
                        </div>
                        <div class="grid-body">
                            <div class="row-fluid">


                                <div class="span4">
                                    <div class="control-group">
                                        <label class="control-label">
                                            Current Password
                                        </label>
                                        <div class="controls">
                                            <asp:TextBox ID="currentPasswordTextBox" class="form-control" runat="server" TextMode="Password" required="required"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="2" ControlToValidate="currentPasswordTextBox"
                                                ErrorMessage="*" Display="Dynamic" ForeColor="red" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="span4">
                                    <div class="control-group">
                                        <label class="control-label">
                                            New Password
                                        </label>
                                        <div class="controls">
                                            <asp:TextBox ID="newPasswordTextBox" runat="server" class="form-control" TextMode="Password" required="required"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rqrvalidpass" ValidationGroup="2" ControlToValidate="newPasswordTextBox"
                                                ErrorMessage="*" Display="Dynamic" ForeColor="red" runat="server" /><br />
                                            <asp:RegularExpressionValidator ID="revChPassword" runat="server" Display="dynamic"
                                                ControlToValidate="newPasswordTextBox" Font-Size="11px" ErrorMessage="Password must be 6-16 nonblank characters."
                                                ValidationExpression="[^\s]{6,16}" ForeColor="Red" />
                                        </div>
                                    </div>
                                </div>
                                <div class="span4">
                                    <div class="control-group">
                                        <label class="control-label">
                                            Confirm New Password
                                        </label>
                                        <div class="controls">
                                            <asp:TextBox ID="confirmNewPasswordTextBox" class="form-control" runat="server" TextMode="Password" required="required"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvConPassword" ValidationGroup="2" ControlToValidate="confirmNewPasswordTextBox"
                                                ErrorMessage="*" Display="Dynamic" ForeColor="red" runat="server" /><br />
                                            <asp:CompareValidator ID="cmvPasswordRpt" Font-Size="11px" runat="server" Display="Dynamic"
                                                EnableClientScript="true" ValidationGroup="edit" ControlToValidate="confirmNewPasswordTextBox"
                                                ValidateEmptyText="true" ErrorMessage="Your passwords do not match." ControlToCompare="newPasswordTextBox"
                                                ForeColor="Red" />
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="row-fluid">
                                <div class="text-center">
                                    <asp:Button ID="passwordUpdateButton" ValidationGroup="2" runat="server" Text="Update Password"
                                        CssClass="btn btn-primary" Style="margin-left: 25px;" OnClick="passwordUpdateButton_Click" />
                                </div>
                               
                                <br />
                            </div>



                        </div>
                    </div>
                </div>
            </div>


        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="passwordUpdateButton" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script src="/Scripts/PasswordStrength.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('#newPasswordTextBox').keyup(function () {
                $('#passwordStrengthLabel').text(checkStrength($('#newPasswordTextBox').val()));
            });
        });
    </script>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#passwordUpdateButton").click(function (e) {
                $("#currentPasswordTextBox").rules("add", {
                    required: true
                });

                $("#newPasswordTextBox").rules("add", {
                    required: true,
                    minlength: 6
                });

                $("#confirmNewPasswordTextBox").rules("add", {
                    equalTo: "#newPasswordTextBox"
                });

                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });
        }
    </script>
</asp:Content>
