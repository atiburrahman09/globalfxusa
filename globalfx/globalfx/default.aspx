﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="globalfx._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="row-fluid">
        <asp:Label ID="lblUserId" Visible="False" runat="server" Text='<%# Eval("UserId")%>' />
        <div class="span6">
            <div class=" tiles white span12">
                <div class="tiles green cover-pic-wrapper">
                    <img src="assets/img/cover_pic.png" />
                </div>
                <div class="tiles white">
                    <div class="row-fluid">
                        <div class="span3">

                              <div class="user-mini-description">
                                <h3 class="text-success semi-bold">
                                    <asp:Label ID="lvlLeft" runat="server" Text=""></asp:Label>
                                </h3>
                                <h5>Left</h5>
                                <h3 class="text-success semi-bold">
                                    <asp:Label ID="lvlRight" runat="server" Text=""></asp:Label>
                                </h3>
                                <h5>Right</h5>
                            </div>
                        </div>
                        <div class="span8 user-description-box text-right pull-right ">
                            <h4 class="semi-bold no-margin">
                                <asp:Label ID="lvlName" runat="server" Text=""></asp:Label></h4>
                            <h6 class="no-margin">
                                <asp:Label ID="lvlPosition" runat="server" Text=""></asp:Label></h6>
                            <br>
                            <p>
                                <i class="icon-mobile-phone"></i>
                                <asp:Label ID="lvlMobile" runat="server" Text=""></asp:Label>
                            </p>
                            <p>
                                <i class="icon-globe"></i>
                                <asp:Label ID="lvlEmail" runat="server" Text=""></asp:Label>
                            </p>

                        </div>

                    </div>
                </div>
            </div>
        </div>
        <div class="span6">
            <div class="grid simple horizontal purple">
                <div class="grid-title">
                    <h3 class="text-center">My <span class="semi-bold">Account</span></h3>
                </div>
                <div class="grid-body">
                    <asp:Label ID="lvlIsActive" runat="server" Text=""></asp:Label>
                    <a id="btnActive" href="/a/account/activation.aspx" runat="server" class="btn btn-success btn-cons" visible="False">Active Here</a>
                    <asp:Label ID="lvlLeftInfo" runat="server" Text="" Visible="False"></asp:Label>
                    <asp:Label ID="lvlRightInfo" runat="server" Text="" Visible="False"></asp:Label>
                    <div id="divinvestinfo" runat="server" class="row-fluid">
                        <h4><span class="semi-bold">MY Investment</span></h4>
                        <div class="row-fluid">
                            <div class="span6">
                                <label>Stake Name</label>
                                <asp:Label class="text-black" ID="lblStakeName" runat="server" Text=""></asp:Label>

                            </div>
                            <div class="span6">
                                <label>Stake Value</label>
                                <asp:Label class="text-black" ID="lblStakeValue" runat="server" Text=""></asp:Label>

                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6">
                                <label>Refferal</label>
                                <asp:Label class="text-black" ID="lblReferal" runat="server" Text=""></asp:Label>

                            </div>
                            <div class="span6">
                                <label>Placement</label>
                                <asp:Label class="text-black" ID="lblPlacement" runat="server" Text=""></asp:Label>

                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6">
                                <label>Join Date</label>
                                <asp:Label class="text-black" ID="lblStakeJoinDate" runat="server" Text=""></asp:Label>

                            </div>
                            <div class="span6">
                                <label>Active Date</label>
                                <asp:Label class="text-black" ID="lblActiveDate" runat="server" Text=""></asp:Label>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <div class="span6 pull-left">
        </div>
        <div class="span6 pull-right">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
</asp:Content>
