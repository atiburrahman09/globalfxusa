﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="globalfx.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="container bg_purple">
        <div class="grid simple" style="max-width: 400px; margin: 100px auto">
            <div class="grid-body no-border" style="border-radius: 10px;">

                <h3 class="text-center">Login <span class="semi-bold">Here</span></h3>
                <p>Enter your username and password to login</p>
                <div class="row-fluid">
                    <div class="input-append span12 primary">
                        <asp:TextBox class="span10" ID="txtbxUserName" placeholder="someone@example.com" runat="server"></asp:TextBox>

                        <span class="add-on"><span class="arrow"></span><i class="icon-align-justify"></i></span>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="input-append span12 primary">
                        <asp:TextBox class="span10" type="password" ID="txtbxPassword" placeholder="your password" runat="server"></asp:TextBox>

                        <span class="add-on"><span class="arrow"></span><i class="icon-lock"></i></span>
                    </div>
                </div>
                <div>
                    <asp:Label ID="lblmsg" CssClass="lblMsg" runat="server" Visible="false" Text=""></asp:Label>

                </div>
                <div class="form-actions" style="border-bottom-left-radius: 10px; border-bottom-right-radius: 10px;">
                    <div class="text-center">
                        <asp:Button class="btn btn-primary btn-cons" ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="SIGN IN" />
                        <asp:Button class="btn btn-warning btn-cons" ID="btnForgotPassword" runat="server" OnClick="btnForgotPassword_Click" Text="Forgot Password" />

                        
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
</asp:Content>
