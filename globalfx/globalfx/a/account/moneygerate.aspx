﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="moneygerate.aspx.cs" Inherits="globalfx.a.account.moneygerate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="grid simple horizontal purple">
        <div id="msgbox" runat="server" visible="false" class="alert alert-block alert-success">
            <button data-dismiss="alert" class="close" type="button">
                <i class="icon icon-times"></i>
            </button>
            <h4>
                <asp:Label ID="msgTitleLabel" runat="server" Text=""></asp:Label>
            </h4>
            <asp:Label ID="msgDetailLabel" runat="server" Text=""></asp:Label>
        </div>
        <div class="grid-title text-center">
            <h3 class="text-center"><span class="semi-bold">Money </span>Generate</h3>
        </div>
        <div class="grid-body">
            <div class="row-fluid">
                <div class="span3">
                    <label>Amount($)</label>
                    <div class="input-append success date">
                        <asp:TextBox ID="txtbxAmount" CssClass="span12"
                            runat="server"></asp:TextBox>
                    </div>

                </div>
                <div class="span3">
                    <label>Your Password</label>
                    <div class="input-append success date">
                        <asp:TextBox ID="toDateTextBox" type="password"
                            runat="server"></asp:TextBox>

                    </div>
                </div>

                <div class="pull-right">
                    <label>&nbsp;</label>
                    <asp:Button class="btn btn-primary btn-cons" ID="btnShow" runat="server" OnClick="GenerateButton_Click" Text="Generate Money" />

                </div>
            </div>
            <div class="row-fluid">
                <div class="clearfix"></div>
                <asp:GridView ID="GridViewGeneratedMoneyList" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover">
                    <Columns>
                        <asp:BoundField DataField="Serial" HeaderText="#" />
                        <asp:BoundField DataField="GenerateDate" HeaderText="Date" DataFormatString="{0:dd MMMM yy -hh:mm tt}" />
                        <asp:BoundField DataField="Amount" HeaderText="Amount ($)" />
                        <asp:BoundField DataField="GenerateBy" HeaderText="User" />
                        <asp:BoundField DataField="GenerateFrom" HeaderText="From" />


                    </Columns>
                </asp:GridView>



            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
</asp:Content>
