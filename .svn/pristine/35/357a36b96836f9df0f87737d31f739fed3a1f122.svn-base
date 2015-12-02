<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="recoverypassword.aspx.cs" Inherits="globalfx.recoverypassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

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

            <div class="grid simple horizontal purple">
                <div class="grid-title text-center">
                    <h3 class="widget-title bigger lighter">Recover Your Password
                    </h3>
                </div>
                <div class="grid-body">
                    <div class="row-fluid">
                        <div class="span2"></div>
                        <div class="span10">
                            <div class="row-fluid">
                                <div class="control-group">
                                    <label class="control-label">
                                       User Name
                                    </label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtbxUserId" class="form-control" runat="server" required="required" placeholder="User Id"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-fluid">
                                <div class="control-group">
                                    <label class="control-label">
                                        Mobile No
                                    </label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtbxMobileNo" class="form-control" runat="server" required="required" placeholder="Mobile Number"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-fluid">

                                <asp:Button ID="btnSave" ValidationGroup="2" runat="server" Text="Request to Recover"
                                    CssClass="btn btn-primary" OnClick="btnSave_OnClick_Click" />

                                <br />
                            </div>
                        </div>

                    </div>

                    <br />

                    <br />
                    <br />

                    <br />

                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
</asp:Content>
