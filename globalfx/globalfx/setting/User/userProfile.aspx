﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="userProfile.aspx.cs" Inherits="globalfx.setting.User.userProfile" %>

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

        <asp:Label ID="lblUserId" Visible="False" runat="server" Text='<%# Eval("UserId")%>' />

        <div class="span6">
            <div class=" tiles white span12">
                <div class="tiles green cover-pic-wrapper">

                    <img src="/assets/img/cover_pic.png" />
                </div>
                <div class="tiles white">
                    <div class="row-fluid">
                        <div class="span3">
                            
                            <%--<div class="user-mini-description">
                                <h3 class="text-success semi-bold"><asp:Label ID="lvlLeft" runat="server" Text="2548"></asp:Label>
                                </h3>
                                <h5>Left</h5>
                                <h3 class="text-success semi-bold"><asp:Label ID="lvlRight" runat="server" Text="457"></asp:Label>
                                </h3>
                                <h5>Right</h5>
                            </div>--%>
                        </div>
                        <div class="span8 user-description-box text-right pull-right ">
                            <h4 class="semi-bold no-margin">
                                <asp:Label ID="lvlName" runat="server" Text=""></asp:Label></h4>
                            <h6 class="no-margin">
                                <asp:Label ID="lvlPosition" runat="server" Text=""></asp:Label></h6>
                            <br>
                            <p><i class="icon-briefcase"></i>
                                <asp:Label ID="lvlExpert" runat="server" Text=""></asp:Label></p>
                            <p><i class="icon-globe"></i>
                                <asp:Label ID="lvlWebsite" runat="server" Text=""></asp:Label></p>
                            <p><i class="icon-file-alt"></i>Download Resume</p>
                            <p><i class="icon-envelope"></i>Send Message</p>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <div class="span6">
            <div class="row-fluid">
                <div class="tiles white span12">
                    <div class="tiles-body">
                        <h3 class="text-center"><span class="semi-bold">User Information</span></h3>
                        <div class="row-fluid bottom_border">
                            <div class="span6">
                                <label>Sure Name:</label>
                                <asp:Label class="text-black" ID="lvlSureName" runat="server" Text=""></asp:Label>

                            </div>
                            <div class="span6">
                                <label>Given Name:</label>
                                <asp:Label class="text-black" ID="lvlGivenName" runat="server" Text=""></asp:Label>

                            </div>
                        </div>
                        <div class="row-fluid bottom_border">
                            <div class="span6">
                                <label>PassPort No:</label>
                                <asp:Label class="text-black" ID="lvlPassPortNo" runat="server" Text=""></asp:Label>

                            </div>
                            <div class="span6">
                                <label>ID Number:</label>
                                <asp:Label class="text-black" ID="lvlIdNumber" runat="server" Text=""></asp:Label>

                            </div>
                        </div>
                        <div class="row-fluid bottom_border">
                            <label>Address:</label>
                            <asp:Label class="text-black" ID="lvlAddress" runat="server" Text=""></asp:Label>

                        </div>


                        <div class="row-fluid bottom_border">
                            <div class="span6">
                                <label>Street:</label>
                                <asp:Label class="text-black" ID="lvlStreet" runat="server" Text=""></asp:Label>

                            </div>
                            <div class="span6">
                                <label>Country:</label>
                                <asp:Label class="text-black" ID="lvlCountry" runat="server" Text=""></asp:Label>

                            </div>
                        </div>
                        <div class="row-fluid bottom_border">
                            <div class="span6">
                                <label>Email:</label>
                                <asp:Label class="text-black" ID="lvlEmail" runat="server" Text=""></asp:Label>

                            </div>
                            <div class="span6">
                                <label>Mobile No:</label>
                                <asp:Label class="text-black" ID="lvlMobileNo" runat="server" Text=""></asp:Label>

                            </div>
                        </div>
                        <div class="row-fluid bottom_border">
                            <div class="span6">
                                <label>Emergency Contract Name:</label>
                                <asp:Label class="text-black" ID="lvlEmrgConctName" runat="server" Text=""></asp:Label>

                            </div>
                            <div class="span6">
                                <label>Emergency Contract Address:</label>
                                <asp:Label class="text-black" ID="lvlEmrgConctAddress" runat="server" Text=""></asp:Label>

                            </div>
                        </div>
                        <div class="row-fluid bottom_border">
                            <div class="span6">
                                <label>Relation:</label>
                                <asp:Label class="text-black" ID="lvlRelation" runat="server" Text=""></asp:Label>

                            </div>
                            <div class="span6">
                                <label>Emergency Contract Email:</label>
                                <asp:Label class="text-black" ID="lvlEmrgConctEmail" runat="server" Text=""></asp:Label>

                            </div>
                        </div>
                        <div class="row-fluid bottom_border">
                            <div class="span6">
                                <label>Emergency Contract Mobile:</label>
                                <asp:Label class="text-black" ID="lvlEmrgConctMobile" runat="server" Text=""></asp:Label>

                            </div>
                            <div class="span6">
                                <label>Emergency Contract Country:</label>
                                <asp:Label class="text-black" ID="lvlEmrgConctCountry" runat="server" Text=""></asp:Label>

                            </div>

                            <asp:LinkButton ID="linkButtonEdit" CssClass="btn btn-success" OnClick="EditBtn_Click" runat="server">Edit</asp:LinkButton>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
</asp:Content>
