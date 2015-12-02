﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true"
    CodeBehind="UpdateMenuGroup.aspx.cs" Inherits="globalfx.setting.AppMenu.UpdateMenuGroup" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="page-content">
        <div id="msgbox" runat="server" visible="false" class="alert alert-block alert-success">
            <button data-dismiss="alert" class="close" type="button">
                <i class="icon icon-times"></i>
            </button>
            <h4>
                <asp:Label ID="msgTitleLabel" runat="server" Text=""></asp:Label>
            </h4>
            <asp:Label ID="msgDetailLabel" runat="server" Text=""></asp:Label>
        </div>
        <div class="row widget-container-col ui-sortable" style="min-height: 261px;">
            <div class="panel panel-primary" style="opacity: 1;">
                <div class="panel-heading">
                    <h5 class="widget-title bigger lighter">
                        <i class="icon icon-table"></i> Update Menu Group [<asp:Label ID="idLabel"
                            runat="server" Text=""></asp:Label>]
                    </h5>
                </div>
                <div class="grid-body">
                    <div class="row">
                            <div class="span12">
                                <div class="span3">
                                    <div class="control-group">
                                        <h6>
                                            Menu For App.
                                        </h6>
                                        <asp:DropDownList CssClass="form-control" ID="menuForAppDropDownList" runat="server" AutoPostBack="true"
                                            OnSelectedIndexChanged="menuForAppDropDownList_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="span3">
                                    <div class="control-group">
                                        <h6>
                                            Menu Type
                                        </h6>
                                        <asp:DropDownList CssClass="form-control" ID="menuTypeDropDownList" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="span3">
                                    <div class="control-group">
                                        <h6>
                                            Menu Target
                                        </h6>
                                        <asp:DropDownList CssClass="form-control" ID="menuTargetDropDownList" runat="server">
                                            <asp:ListItem>_blank</asp:ListItem>
                                            <asp:ListItem Selected="True">_parent</asp:ListItem>
                                            <asp:ListItem>_search</asp:ListItem>
                                            <asp:ListItem>_self</asp:ListItem>
                                            <asp:ListItem>_top</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="span3">
                                    <div class="control-group">
                                        <h6>
                                            Menu Group Name
                                        </h6>
                                        <asp:TextBox  CssClass="form-control" ID="menuGroupNameTextBox" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="span12">
                                <div class="span3">
                                    <div class="control-group">
                                        <h6>
                                            Display Name
                                        </h6>
                                         <asp:TextBox CssClass="form-control" ID="displayNameTextBox" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="span3">
                                    <div class="control-group">
                                        <h6>
                                            Description
                                        </h6>
                                         <asp:TextBox CssClass="form-control" ID="descriptionTextBox" runat="server" ></asp:TextBox>
                                    </div>
                                </div>
                                <div class="span3">
                                    <div class="control-group">
                                        <h6>
                                              Menu URL
                                        </h6>
                                         <asp:TextBox CssClass="form-control" ID="urlTextBox" runat="server" ></asp:TextBox>
                                    </div>
                                </div>
                                <div class="span3">
                                    <div class="control-group">
                                        <h6>
                                            Image URL
                                        </h6>
                                         <asp:TextBox CssClass="form-control" ID="imageURLTextBox" runat="server" ></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    <div>
                        <label class="infoLabel">
                            *** URL Note: Use " javascript:void(0) " as blank URL instead of symbol ' # '
                        </label>
                    </div>
                    <hr />
                    <asp:Button ID="updateButton" runat="server" style="margin-left: 25px; margin-bottom: 10px;" Text="Update" CssClass="btn btn-primary"
                        OnClick="updateButton_Click" />
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="appMenuGroupIdForUpdateHiddenField" runat="server" />
    <asp:HiddenField ID="appMenuGroupNameHiddenField" runat="server" />
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#updateButton").on("click", function (e) {
                if ($('#menuForAppDropDownList option:selected').text() == '----------Select----------') {
                    alert('Menu For App. field is required.');
                    $('#menuForAppDropDownList').focus();
                    e.preventDefault();
                    $("#form1").valid();
                    //return false;
                }

                if ($('#menuTypeDropDownList option:selected').text() == '----------Select----------') {
                    alert('Menu Type field is required.');
                    $('#menuTypeDropDownList').focus();
                    e.preventDefault();
                    $("#form1").valid();
                    //return false;
                }
            });

            $("#menuGroupNameTextBox").rules("add", {
                required: true
            });

            $("#displayNameTextBox").rules("add", {
                required: true
            });

            $("#urlTextBox").rules("add", {
                required: true
            });
        });
    </script>
</asp:Content>
