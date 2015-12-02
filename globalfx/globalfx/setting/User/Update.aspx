﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true"
    CodeBehind="Update.aspx.cs" Inherits="globalfx.setting.User.Update" %>

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

        <div class="grid simple horizontal purple">
            <div class="grid-title">
                <h5 class="widget-title bigger lighter">
                    <i class="icon icon-table"></i>&nbsp; Update User [<asp:Label ID="lblUserId" runat="server"
                        Text=""></asp:Label>] 
                    <%--  <div class="left">--%>

                    <a title="Back" type="button" style="float: right; margin: -7px 10px -7px -7px;" href="List.aspx">
                        <i class="icon icon-2x fa-reply white"></i>
                    </a>
                    <%--</div>--%>
                </h5>

            </div>
            <div class="grid-body">
                <label class="text-info red">
                    All * feilds are required</label>
                <br />
                <label class="text-info  ">
                    Basic :</label>
                <div class="row-fluid">
                            <div class="span12">
                                <div class="span4">
                                    <div class="control-group">
                                        <label class="control-label">
                                            User Name<span class="red">*</span>
                                        </label>
                                        <div class="controls">
                                            <div class="input-prepend inside span12">
                                                <div class="add-on">
                                                    <span class="icon icon-user"></span>
                                                </div>
                                                <asp:TextBox ID="txtbxUserName" class="form-control" required="required" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="span4">
                                    <div class="control-group">
                                        <label class="control-label">
                                            Mobile Number<span class="red">*</span>
                                        </label>
                                        <div class="controls">
                                            <div class="input-prepend inside span12">
                                                <div class="add-on">
                                                    <span class="icon icon-phone"></span>
                                                </div>
                                                <asp:TextBox ID="txtbxmobile" required="required" CssClass="form-control" MaxLength="11" class="form-control1"
                                                    runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="span4">
                                    <div class="control-group">
                                        <label class="control-label">
                                            Email<span class="red">*</span>
                                        </label>
                                        <div class="controls">
                                            <div class="input-prepend inside span12">
                                                <div class="add-on">
                                                    <span class="icon icon-envelope"></span>
                                                </div>
                                                <asp:TextBox ID="txtbxemail" class="form-control" type="email" placeholder="Enter email"
                                                    required="required" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row-fluid">

                                <%-- <div class="span4">
                                            <div class="control-group">

                                                <h6>Date of Birth</h6>


                                                <div class="input-prepend inside span12">
                                                    <asp:TextBox runat="server" ID="txtbxDateOfBirth" data-date-format="dd/mm/yyyy" CssClass="form-control date-picker" required="required" placeholder="Date"></asp:TextBox>

                                                    <span class="input-prepend inside span12-add-on">
                                                        <i class="iconcalendar bigger-110"></i>
                                                    </span>
                                                </div>

                                            </div>
                                        </div>--%>
                                <%-- <div class="span4">
                                            <div class="control-group">
                                                <h6>Gender<span class="red">*</span>
                                                </h6>
                                                <asp:DropDownList ID="drpdwnSex" class="form-control" required="required" runat="server">
                                                    <asp:ListItem Value="">--Select Please--</asp:ListItem>
                                                    <asp:ListItem Value="Male">Male</asp:ListItem>
                                                    <asp:ListItem Value="Female">Female</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>--%>
                                <div class="span4">
                                    <div class="span12">

                                        <div class="span5">
                                            <div class="control-group">
                                                <h6>Photo<span class="red">*</span>
                                                </h6>
                                                <asp:HiddenField ID="hidFileName" runat="Server" />


                                                <asp:FileUpload ID="fileupload" class="btn btn-file" runat="server" required="required" />


                                            </div>
                                        </div>
                                        <div class="span6">
                                            <div class="control-group">
                                                <h6></h6>
                                                <span id="errorlbl" class="red">Size less than 128Kb   </span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row-fluid">
                                <label class="text-info ">
                                    Access Info:</label>
                                <div class="span12">
                                    <div class="span4">
                                        <div class="control-group">
                                            <h6>User Group<span class="red">*</span>
                                            </h6>
                                            <asp:DropDownList ID="drpdownGroup" class="form-control" required="required" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="span4">
                                        <div class="control-group">
                                            <h6>Password<span class="red">*</span>
                                            </h6>
                                            <asp:TextBox ID="passwordTextBox" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rqrvalidpass" ControlToValidate="passwordTextBox"
                                                ErrorMessage="*" Display="Dynamic" ForeColor="red" runat="server" />
                                            <asp:RegularExpressionValidator ID="revChPassword" runat="server" Display="dynamic"
                                                ControlToValidate="passwordTextBox" ErrorMessage="Password must be 6-16 nonblank characters."
                                                ValidationExpression="[^\s]{6,16}" ForeColor="Red" />
                                        </div>
                                    </div>
                                    <div class="span4">
                                        <div class="control-group">
                                            <h6>Confirm Password<span class="red">*</span></h6>
                                            <asp:TextBox ID="confirmPasswordTextBox" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvConPassword" ControlToValidate="confirmPasswordTextBox"
                                                ErrorMessage="*" Display="Dynamic" ForeColor="red" runat="server" />
                                            <asp:CompareValidator ID="cmvPasswordRpt" runat="server" Display="Dynamic" EnableClientScript="true"
                                                ValidationGroup="edit" ControlToValidate="passwordTextBox" ValidateEmptyText="true"
                                                ErrorMessage="Your passwords do not match." ControlToCompare="confirmPasswordTextBox"
                                                ForeColor="Red" />


                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="span12">
                                <div class="row-fluid ">
                                    <div class="span12">
                                        <asp:Button ID="saveButton" runat="server" ValidationGroup="6" Text="Create" CssClass="btn btn-primary"
                                            Font-Bold="True" Style="margin-left: 25px;" OnClick="btnUserUpdate_click" />
                                    </div>
                                </div>
                                <br />
                            </div>
                        </div>
                <%--<div class="row">
                    <div class="span12">
                        <div class="span4">
                            <div class="control-group">
                                <h6 class="typo">Username Name<span class="red">*</span>
                                </h6>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <span class="icon icon-user"></span>
                                    </div>
                                    <asp:TextBox ID="txtbxUserName" class="form-control" required="required" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="span4">
                            <div class="control-group">
                                <h6>Mobile Number<span class="red">*</span>
                                </h6>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <span class="icon icon-phone"></span><span class="countrycode">+88</span>
                                    </div>
                                    <asp:TextBox ID="txtbxmobile" required="required" CssClass="form-control" MaxLength="11" class="form-control1"
                                        runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="span4">
                            <div class="control-group">
                                <h6>Email<span class="red">*</span>
                                </h6>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <span class="icon icon-envelope"></span>
                                    </div>
                                    <asp:TextBox ID="txtbxemail" class="form-control" type="email" ReadOnly="True" placeholder="Enter email"
                                        required="required" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="span12">

                        
                        <div class="span4">
                            <div class="span12">

                                <div class="span5">
                                    <div class="control-group">
                                        <h6>Photo<span class="red">*</span>
                                        </h6>
                                        <asp:HiddenField ID="hidFileName" runat="Server" />


                                        <asp:FileUpload ID="fileupload" class="btn btn-file" runat="server" required="required" />


                                    </div>
                                </div>
                                <div class="span6">
                                    <div class="control-group">
                                        <h6></h6>
                                        <span id="errorlbl" class="red">Size less than 128Kb   </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="span12">
                        <label class="text-info  ">
                            Access Info:</label>
                        <div class="span4">
                            <div class="control-group">
                                <h6>User Group<span class="red">*</span>
                                </h6>
                                <asp:DropDownList ID="drpdownGroup" class="form-control" required="required" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>

                    </div>
                    <div class="span12">
                        <div class="row ">
                            <div class="span4">
                                <asp:Button ID="saveButton" runat="server" ValidationGroup="6" Text="Update" CssClass="btn btn-primary"
                                    Font-Bold="True" Style="margin-left: 25px;" OnClick="btnUserUpdate_click" />
                            </div>
                            <br />
                        </div>

                    </div>

                </div>--%>

            </div>
        </div>
    </div>

    <asp:HiddenField ID="userIdForUpdateHiddenField" runat="server" />
    <asp:HiddenField ID="hiddenfeildphoto" runat="server" />
    <asp:HiddenField ID="hiddenfeildEmail" runat="server" />
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">

        $(document).ready(function () {
            $('.date-picker').datepicker({
                autoclose: true,
                todayHighlight: true
            });

            $('#fileupload').bind('change', function () {

                //converts the file size from bytes to KB
                var fileSize = this.files[0].size / 1024;

                //gets the full file name including the extension
                var fileName = this.files[0].name;

                //finds where the extension starts
                var dotPosition = fileName.lastIndexOf(".");

                //gets only the extension
                var fileExt = fileName.substring(dotPosition);
                var lbl = document.getElementById('errorlbl');
                //checks whether the file is .png and less than 1 MB
                if (fileSize <= 128 && (fileExt == ".png" || fileExt == ".jpeg" || fileExt == ".jpg")) {

                    lbl.innerHTML = "Image Validated.";
                    lbl.className = "text-success";

                }
                else {
                    lbl.innerHTML = "File is too big.Image should be under 128KB and only imagefile(png,jpeg,jpg).";
                }
            });

        });
    </script>
</asp:Content>
