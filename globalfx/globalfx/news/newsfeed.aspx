﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="newsfeed.aspx.cs" Inherits="globalfx.news.newsfeed" %>

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


        <div class="grid simple">
            <div class="grid-body no-border">
                <h4 class="text-center" style="margin-top: 0px; padding-top: 20px;"><span class="semi-bold">News Feed</span></h4>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="control-group">
                            <div class="input-with-icon  right">
                                <label><strong>Title:</strong></label>
                                <asp:TextBox class="span12" ID="txtbxTitle" required="required" runat="server"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="control-group">
                            <div class="input-with-icon  right">
                                <label><strong>Body:</strong></label>
                                <asp:TextBox ID="txtbxBody" CssClass="span12" required="required" TextMode="MultiLine" runat="server"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div class="span6">
                            <label>Valid to</label>
                            <div class="input-append success date">
                                <asp:TextBox ID="validdateTextBox" data-date-format="dd/mm/yyyy" CssClass="date-textbox"
                                    runat="server"></asp:TextBox>
                                <span class="add-on"><span class="arrow"></span><i class="icon-th"></i></span>
                            </div>
                        </div>

                    </div>

                </div>
                <div class="form-actions">
                    <div class="pull-right">
                        <asp:Button class="btn btn-primary btn-cons" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                        <asp:Button class="btn btn-danger btn-cons" ID="btnCancel" runat="server" Text="Cancel" />
                    </div>
                </div>

            </div>
        </div>
        <div class="grid-body">
            <div class="row-fluid">
                <asp:HiddenField ID="hdbFieldId" Visible="False" runat="server" />
                <asp:GridView ID="GridViewNewsFeedList" runat="server" AutoGenerateColumns="false" CssClass="table table-hover table-condensed">
                    <Columns>

                        <asp:BoundField DataField="Serial" HeaderText="ID" />
                        <asp:BoundField DataField="NewsBody" HeaderText="News Body" />
                        <asp:BoundField DataField="NewsTitale" HeaderText="News Title" />
                        <asp:BoundField DataField="ValidDate" HeaderText="Valid Date" />
                        <asp:BoundField DataField="CreatedBy" HeaderText="Created By" />
                        <asp:BoundField DataField="CreatedDate" HeaderText="Created Date" />
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="EditLinkButton" CssClass="btn btn-success" runat="server" OnClick="EditLinkButton_OnClick">Edit</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {

            var dateFormat = '<%= Session["DateFormatForDatePicker"] %>';
            $(".date-textbox").datepicker({ format: dateFormat });
            $(".date-textbox, .icon-calendar").click(function () {
                $(this).parent().find(".date-textbox").focus();
            });


            $('#GridViewNewsFeedList').dataTable({
                "bStateSave": true,
            });



        }
    </script>
</asp:Content>
