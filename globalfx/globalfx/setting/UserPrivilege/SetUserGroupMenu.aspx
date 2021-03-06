﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true"
    CodeBehind="SetUserGroupMenu.aspx.cs" Inherits="globalfx.setting.UserPrivilege.SetUserGroupMenu" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
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
            <div class="span12">
                <div class="row widget-container-col ui-sortable" style="min-height: 261px;">
                    <div class="grid simple horizontal purple" style="opacity: 1;">
                        <div class="panel-heading">
                            <h5 class="widget-title bigger lighter">
                                <i class="icon icon-table"></i>UserPrivilege <small class="white"><i class="icon icon-angle-double-right"></i>Set User Group Menu </small>
                            </h5>
                        </div>
                        <div class="grid-body">
                            <div class="row-fluid">
                                <div class="span12">
                                    <%--<div class="col-sm-1">
                            </div>--%>
                                    <div class="span3">
                                        <div class="control-group">
                                            <h5>User Group</h5>
                                            <asp:DropDownList ID="userGroupDropDownList" runat="server" class="form-control"
                                                placeholder="User Group" required="required">
                                                <asp:ListItem Value="">Select here..</asp:ListItem>
                                                <asp:ListItem Value="UG001">Admin</asp:ListItem>
                                                <asp:ListItem Value="UG002">Manager</asp:ListItem>
                                                <asp:ListItem Value="UG003">Investor</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="span5">
                                        <div style="margin-top: 39px">
                                            <asp:Button ID="userGroupMenuListButton" runat="server" Text="Get User Group Menu List"
                                                CssClass="btn btn-info" OnClick="userGroupMenuListButton_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <hr />
                            <div id="userPriviligePane" runat="server" visible="false">
                                <%--    <div class="row">
                            <div class="span12">
                                <div id="MenuContent">
                                    <div id="allMenuList">
                                        <asp:Menu ID="testAllMenu" runat="server" Orientation="Horizontal" MaximumDynamicDisplayLevels="9"
                                            StaticEnableDefaultPopOutImage="true" StaticPopOutImageUrl="~/Content/images/arrow_a.gif"
                                            DynamicEnableDefaultPopOutImage="true" DynamicPopOutImageUrl="~/Content/images/arrow_a.gif"
                                            CssClass="navigation">
                                        </asp:Menu>
                                    </div>
                                    <div id="allMenuImg">
                                        <asp:ImageButton ID="refreshMenuImageButton" runat="server" AlternateText="Refresh"
                                            CssClass="menuProcessing" ToolTip="Refresh Menu" ImageUrl="~/content/images/Refresh-icon.png"
                                            OnClick="refreshMenuImageButton_Click" />
                                        <asp:ImageButton ID="allMenuImageButton" runat="server" AlternateText="All Menu"
                                            Visible="false" CssClass="menuProcessing" ToolTip="Get All Menu" ImageUrl="~/Content/Images/database-icon.png"
                                            OnClick="allMenuImageButton_Click" />
                                    </div>
                                    <div class="empty">
                                    </div>
                                </div>
                            </div>
                        </div>--%>
                                <hr />
                                <div class="row-fluid">
                                    <div class="span12">
                                        <div id="userMenuSearch">
                                            <%--<div class="col-sm-1">
                                </div>--%>
                                            <div class="span3">
                                                <div class="control-group">
                                                    <h5>Menu For App.</h5>
                                                    <asp:DropDownList ID="menuForAppDropDownList" runat="server" AutoPostBack="true"
                                                        class="form-control" required="required" OnSelectedIndexChanged="menuForAppDropDownList_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="span3">
                                                <div class="control-group">
                                                    <h5 class="typo">Menu Type</h5>
                                                    <asp:DropDownList ID="menuTypeDropDownList" runat="server" AutoPostBack="true" class="form-control"
                                                        OnSelectedIndexChanged="menuTypeDropDownList_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="span3">
                                                <div class="control-group">
                                                    <h5 class="typo">Menu Group</h5>
                                                    <asp:DropDownList ID="menuGroupDropDownList" runat="server" AutoPostBack="true" class="form-control"
                                                        OnSelectedIndexChanged="menuGroupDropDownList_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="span2">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <hr />
                                <div id="userMenuPane" runat="server" visible="false">
                                    <div id="listPane" class="widget-separator grid-12">
                                        <div class="row-fluid">
                                            <div class="span12">
                                                <div class="span5">
                                                    <h4>Group Wise Menu List</h4>
                                                    <asp:ListBox ID="groupWiseMenuListListBox" runat="server" CssClass="width-100"></asp:ListBox>
                                                    <asp:Label ID="countMenuLabel" runat="server" Text="Total: 0"></asp:Label>
                                                </div>
                                                <div class="span2">
                                                    <div class="margin-top-bottom-3px">
                                                        <asp:Button ID="addButton" CssClass="btn btn-warning clickProcessing width-full"
                                                            Style="width: 100%;" runat="server" Text="Add" OnClick="addButton_Click" />
                                                    </div>
                                                    <div class="margin-top-bottom-3px">
                                                        <asp:Button ID="removeButton" CssClass="btn btn-danger clickProcessing" Style="width: 100%;"
                                                            runat="server" Text="Remove" OnClick="removeButton_Click" />
                                                    </div>
                                                    <hr />
                                                    <div class="margin-top-bottom-3px">
                                                        <asp:Button ID="addAllButton" CssClass="btn btn-warning clickProcessing" Style="width: 100%;"
                                                            runat="server" Text="Add All" OnClick="addAllButton_Click" />
                                                    </div>
                                                    <div class="margin-top-bottom-3px">
                                                        <asp:Button ID="removeAllButton" CssClass="btn btn-danger clickProcessing" Style="width: 100%;"
                                                            runat="server" Text="Remove All" OnClick="removeAllButton_Click" />
                                                    </div>
                                                </div>
                                                <div class="span5">
                                                    <h4>Group Wise User Group's Menu List</h4>
                                                    <asp:ListBox ID="groupWiseUserGroupMenuListListBox" runat="server" CssClass="width-100"></asp:ListBox>
                                                    <asp:Label ID="countUserMenuLabel" runat="server" Text="Total: 0"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <hr />
                                        <div class="padding-all-5px">
                                            <asp:Button ID="saveButton" CssClass="btn btn-success btn-3d" runat="server" Text="Save"
                                                OnClick="saveButton_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="userGroupIdForSetMenuHiddenField" runat="server" />
        <triggers>
            <asp:AsyncPostBackTrigger EventName="Click" ControlID="userGroupMenuListButton" />
            <asp:AsyncPostBackTrigger ControlID="saveButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="addButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="addAllButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="removeAllButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="removeButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="refreshMenuImageButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="refreshMenuImageButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="menuForAppDropDownList" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="menuTypeDropDownList" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="menuGroupDropDownList" EventName="SelectedIndexChanged" />
        </triggers>
        <%-- </fieldset>--%>
    </div>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            //$(".navigation ul ul:hover").css({ display: "none" });
            $(".navigation ul li").click(function () {
                $(this).find('ul:first').fadeToggle(500);
            });

            $('#userGroupDropDownList option:contains("Super Admin")').attr("disabled", true);

            $("#userGroupMenuListButton").click(function () {
                $("#userGroupDropDownList").rules("add", {
                    required: true
                });

                if (haveOverlay == 0) {
                    $("#form1").valid();

                    if (haveOverlay == 1) {
                        return false;
                    } else {
                        MyOverlayStart();
                    }
                }
            });

            $("#saveButton").click(function () {
                $("#menuForAppDropDownList").rules("add", {
                    required: true
                });

                $("#menuTypeDropDownList").rules("add", {
                    required: true
                });

                $("#menuGroupDropDownList").rules("add", {
                    required: true
                });

                if (haveOverlay == 0) {
                    $("#form1").valid();

                    if (haveOverlay == 1) {
                        return false;
                    } else {
                        MyOverlayStart();
                    }
                }
            });

            $(".menuProcessing").click(function () {
                $("#menuForAppDropDownList").rules("add", {
                    required: true
                });

                $("#menuTypeDropDownList").rules("add", {
                    required: true
                });

                if (haveOverlay == 0) {
                    $("#form1").valid();

                    if (haveOverlay == 1) {
                        return false;
                    } else {
                        MyOverlayStart();
                    }
                }
            });
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $(".clickProcessing").live("click", function () {
                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });

            $(".indexChangeProcessing").live("change", function () {
                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });
        });
    </script>
</asp:Content>
