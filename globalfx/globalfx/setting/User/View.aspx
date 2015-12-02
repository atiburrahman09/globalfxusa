<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true"
    CodeBehind="View.aspx.cs" Inherits="globalfx.setting.User.View" %>

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
        <div class="row">

            <!-- PAGE CONTENT BEGINS -->
            <div class="grid simple horizontal purple">
                <div class="grid-title">
                    <span><b style="font-size: 20px; color: #31708f">View User [<asp:Label ID="idLabel" runat="server" Text=""></asp:Label>]</b></span>

                </div>

                <div class="grid-body">


                    <div class="row">
                        <div class="span12">
                            <div class="span3">
                                <h5>User ID:
                                        <asp:Label ID="userIdLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label></h5>

                            </div>
                            <div class="span3">
                                <h5>User Name:
                                        <asp:Label ID="userNameLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label></h5>

                            </div>
                            <%-- <div class="span3">
                                                    <h5> Employee ID: <asp:Label ID="employeeIdLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label></h5>
                                                    
                                                </div>--%>
                            <div class="span3">
                                <h5>User Group:
                                        <asp:Label ID="userGroupLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label></h5>

                            </div>
                            <div class="span3">
                                <h5>Contact Number: 
                                        <asp:Label ID="contactNumberLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label></h5>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="span12">
                            <%-- <div class="span3">
                                                <h5>Department: <asp:Label ID="designationLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label></h5>
                                            </div>
                                            <div class="span3">
                                                <h5>Designation : <asp:Label ID="departmentLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label></h5>
                                            </div>--%>

                            <div class="span3">
                                <h5>Email:
                                        <asp:Label ID="emailLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label></h5>
                            </div>
                        </div>

                    </div>
                    <%-- <div class="row">
                                        <div class="span12">
                                            <div class="span3">
                                                <h5>National ID: <asp:Label ID="nationalIdLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label></h5>
                                            </div>
                                            <div class="span3">
                                                <h5> Passport Number: <asp:Label ID="passportNumberLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label></h5>
                                            </div>
                                            <div class="span3">
                                                <h5> Address:  <asp:Label ID="addressLabel" CssClass="" runat="server" Text=""></asp:Label></h5>
                                            </div>
                                        </div>
                                    </div>--%>
                </div>
            </div>
            <
        </div>
    </div>

    <asp:HiddenField ID="userIdForViewHiddenField" runat="server" />
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
</asp:Content>
