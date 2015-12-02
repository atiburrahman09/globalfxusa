﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true"
    CodeBehind="View.aspx.cs" Inherits="globalfx.setting.UserGroup.View" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/ViewDetail.css" rel="stylesheet" type="text/css" />
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

            <div class="row widget-container-col ui-sortable" style="min-height: 261px;">
                <div class="grid simple horizontal purple" style="opacity: 1;">
                    <div class="grid-title">
                        <h5 class="widget-title bigger lighter">
                            <i class="icon icon-table"></i>View User Group [<asp:Label ID="idLabel" runat="server" Text=""></asp:Label>]
                        </h5>
                    </div>
                    <div class="panel-body">
                        <br />
                        <div class="row">
                            <div class="span12">
                                <div class="col-sm-6">
                                    <div class="row">
                                        <div class="span4">
                                            User Group Name:
                                        </div>
                                        <div class="span8">
                                            <asp:Label ID="userGroupNameLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">

                                    <div class="row">
                                        <div class="span4">
                                            Description:
                                        </div>
                                        <div class="span8">
                                            <asp:Label ID="descriptionLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <asp:HiddenField ID="userGroupIdForViewHiddenField" runat="server" />
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
</asp:Content>
