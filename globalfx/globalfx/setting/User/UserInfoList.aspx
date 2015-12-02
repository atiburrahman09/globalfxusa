﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="UserInfoList.aspx.cs" Inherits="globalfx.setting.User.UserInfoList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="grid simple">

        <div class="grid-title text-center">
            <h3 class="text-center" style="margin-top: 0px;">Update <span class="semi-bold">From</span></h3>

        </div>
        <div class="grid-body">
            <div id="msgbox" runat="server" visible="False" class="alert alert-warning">
                <button data-dismiss="alert" class="close" type="button">
                    <i class="icon icontimes"></i>
                </button>
                <h4 class="help">
                    <asp:Label ID="msgTitleLabel" runat="server" Text=""></asp:Label>
                </h4>
                <asp:Label ID="msgDetailLabel" runat="server" Text=""></asp:Label>
            </div>
            <div class="form-no-horizontal-spacing" id="form_iconic_validation">
                <div class="row-fluid column-seperation">
                    <div class="span6">
                        <h4>Basic Information</h4>
                        <div class="row-fluid">
                            <div class="span5">
                                <asp:HiddenField ID="hdnfldduplicate" runat="server" />
                                <div class="control-group">
                                    <div class="input-with-icon  right">
                                        <i id="iconuserName" runat="server" class=""></i>
                                        <asp:Label ID="LevelUser" runat="server" Text="User Name"></asp:Label>
                                        <asp:TextBox ID="txtbxUserName" AutoPostBack="True" ReadOnly="True" placeholder="Login Name" required="required" CssClass="span12" runat="server" ></asp:TextBox>

                                    </div>
                                </div>
                            </div>

                            <div class="span6">
                                <div class="control-group">
                                    <div class="input-with-icon  right">
                                        <i class=""></i>
                                        <asp:Label ID="LevelFirst" runat="server" Text="First Name"></asp:Label>
                                        <asp:TextBox ID="txtbxFirstName" required="required" placeholder="First Name" CssClass="span12" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span5">
                                <div class="control-group">
                                    <div class="input-with-icon  right">
                                        <i class=""></i>
                                        <asp:Label ID="Label1" runat="server" Text="Last Name"></asp:Label>
                                        <asp:TextBox ID="txtbxLastName" required="required" placeholder="Last Name" CssClass="span12" runat="server"></asp:TextBox>


                                    </div>
                                </div>
                            </div>
                            <div class="span6">
                                <div class="control-group">
                                    <div class="input-with-icon  right">
                                        <i class=""></i>
                                        <asp:Label ID="Label2" runat="server" Text="Passport No or ID"></asp:Label>
                                        <asp:TextBox ID="txtbxPassportNo" placeholder="Passport No. or ID" CssClass="span12" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span11">
                                <div class="control-group">
                                    <div class="input-with-icon  right">
                                        <i class=""></i>
                                        <asp:Label ID="Label3" runat="server" Text="Address"></asp:Label>
                                        <asp:TextBox ID="txtbxAddress" required="required" placeholder="Address" CssClass="span12" runat="server"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span5">
                                <div class="control-group">
                                    <div class="input-with-icon  right">
                                        <i class=""></i>
                                        <asp:Label ID="Label4" runat="server" Text="House"></asp:Label>
                                        <asp:TextBox ID="txtbxHouse" required="required" placeholder="House No." CssClass="span12" runat="server"></asp:TextBox>

                                    </div>
                                </div>
                            </div>

                            <div class="span6">
                                <div class="control-group">
                                    <div class="input-with-icon  right">
                                        <i class=""></i>
                                        <asp:Label ID="Label5" runat="server" Text="Street"></asp:Label>
                                        <asp:TextBox ID="txtbxStreet" required="required" placeholder="Street No." CssClass="span12" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>


                        <div class="row-fluid">
                            <div class="span5">
                                <div class="control-group">
                                    <div class="input-with-icon  right">
                                        <i class=""></i>
                                        <asp:Label ID="Label6" runat="server" Text="Area"></asp:Label>
                                        <asp:TextBox ID="txtbxArea" placeholder="Area" CssClass="span12" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="span6">
                                <div class="control-group">
                                    <div class="input-with-icon  right">
                                        <i class=""></i>
                                        <asp:Label ID="Label7" runat="server" Text="Select Country"></asp:Label>
                                        <asp:DropDownList ID="ddlCountry" required="required" CssClass="span12" runat="server"></asp:DropDownList>

                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span11">
                                <div class="control-group">
                                    <div class="input-with-icon  right">
                                        <i class=""></i>
                                        <asp:Label ID="Label8" runat="server" Text="Cell No"></asp:Label>
                                        <asp:TextBox ID="txtbxCell" ReadOnly="True" required="required" placeholder="Cell No." CssClass="span12" runat="server"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                        </div>


                        <div class="row-fluid">
                            <div class="span11">
                                <div class="control-group">
                                    <div class="input-with-icon  right">
                                        <i class=""></i>
                                            <asp:Label ID="Label9" runat="server" Text="Email"></asp:Label>
                                        <asp:TextBox ID="txtbxEmail" ReadOnly="True" required="required" placeholder="Email" CssClass="span12" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic"
                                            runat="server" ErrorMessage="Please Enter Valid Email ID-(sample@domain.com)"
                                            ControlToValidate="txtbxEmail"
                                            CssClass="text-error"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                        </asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>
                        </div>





                    </div>
                    <div class="span6">

                        <h4>Emergency Contract Information</h4>


                        <div class="row-fluid">
                            <div class="span12">
                                <div class="control-group">
                                    <div class="input-with-icon  right">
                                        <i class=""></i>
                                        <asp:Label ID="Label10" runat="server" Text="Contact Person"></asp:Label>
                                        <asp:TextBox ID="txtcontactPerson" placeholder="Contact Person" CssClass="span12" runat="server"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="control-group">
                                    <div class="input-with-icon  right">
                                        <i class=""></i>
                                        <asp:Label ID="Label11" runat="server" Text="Contact Address"></asp:Label>
                                        <asp:TextBox ID="txtbxContactAddress" placeholder="Contact Address" CssClass="span12" runat="server"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="control-group">
                                    <div class="input-with-icon  right">
                                        <i class=""></i>
                                        <asp:Label ID="Label12" runat="server" Text="Select Contact Relation"></asp:Label>
                                        <asp:DropDownList ID="ddlContactRelation" class="span12" runat="server"></asp:DropDownList>

                                    </div>
                                </div>
                            </div>
                        </div>


                        <div class="row-fluid">
                            <div class="span12">
                                <div class="control-group">
                                    <div class="input-with-icon  right">
                                        <i class=""></i>
                                        <asp:Label ID="Label13" runat="server" Text="Contact Cell No"></asp:Label>
                                        <asp:TextBox ID="txtbxContactMobile" placeholder="Contact Cell No" CssClass="span12" runat="server"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="control-group">
                                    <div class="input-with-icon  right">
                                        <i class=""></i>
                                        <asp:Label ID="Label14" runat="server" Text="Contact Email"></asp:Label>
                                        <asp:TextBox ID="txtContactEmail" placeholder="Contact Email" CssClass="span12" runat="server"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="control-group">
                                    <div class="input-with-icon  right">
                                        <i class=""></i>
                                        <asp:Label ID="Label15" runat="server" Text="Select Country"></asp:Label>
                                        <asp:DropDownList ID="ddlContactCountry" class="span12" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid small-text">NOTE - All Above information is true and relaiable. </div>

                    </div>
                </div>
                <div class="form-actions">
                    <div class="pull-left">

                        <asp:LinkButton ID="btnSave" class="btn btn-primary btn-cons" runat="server" OnClick="btnSave_Click"><i class="icon-ok"></i> Update Info</asp:LinkButton>

                        <asp:Button ID="brnCancel" class="btn btn-danger btn-cons" runat="server" Text="Cancel" OnClick="btnCancel_Click"/>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
</asp:Content>
