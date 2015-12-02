﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true"
    CodeBehind="DeletedList.aspx.cs" Inherits="globalfx.setting.UserGroup.DeletedList" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/DeletedList.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="False">
        <ContentTemplate>
            <div class="page-content">
                <div id="msgbox" runat="server" visible="false" class="alert alert-block alert-success">
                    <button data-dismiss="alert" class="close" type="button">
                        <i class="icon icon-times"></i>
                    </button>
                    <h4>
                        <asp:Label ID="msgTitleLabel" runat="server" Text=""></asp:Label>
                    </h4>
                    <asp:Label ID="msgDetailLabel" runat="server" Text=""></asp:Label>
                </div>
                <div class="row widget-container-col ui-sortable" style="min-height: 261px;">
                    <div class="panel panel-primary" style="opacity: 1;">
                        <div class="panel-heading">
                            <h5 class="widget-title bigger lighter">
                                <i class="icon icon-table"></i>UserGroup <small class="white"><i class="icon icon-angle-double-right">
                                </i>Create User Group </small>
                            </h5>
                        </div>
                        <div class="grid-body">
                            <div class="row">
                                <div class="span12">
                                    <%--<div class="widget-body PaddingAll9px">
                    <div class="row-fluid">
                        <div class="span4">
                            <div class="span4 lblvartical">
                                Date From</div>
                            <div class="span8">
                                <div class="input-prepend date textSpace" id="Div1" data-date-format="dd/mm/yyyy">
                                    <span class="add-on"><i class="icon-th"></i></span>
                                    <asp:TextBox ID="fromDateTextBox" runat="server" Width="180px"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="span4">
                            <div class="span4 lblvartical">
                                Date To</div>
                            <div class="span8">
                                <div class="input-prepend date textSpace" id="Div2" data-date-format="dd/mm/yyyy">
                                    <span class="add-on"><i class="icon-th"></i></span>
                                    <asp:TextBox ID="toDateTextBox" runat="server" Width="180px"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="span2">
                            <asp:Button ID="deletedListButton" runat="server" Text="Get Deleted List" CssClass="btn btn-info"
                                OnClick="deletedListButton_Click" /></div>
                        <div class="span2">
                            <asp:Button ID="allDeletedListButton" runat="server" Text="Get All Deleted List"
                                CssClass="btn btn-info" OnClick="allDeletedListButton_Click" /></div>
                    </div>
                    <hr />
                    <div id="deletedListGridContainer">
                        <asp:GridView ID="deletedListGridView" runat="server" AutoGenerateColumns="false"
                            CssClass="table table-hover">
                            <Columns>
                                <asp:BoundField DataField="UserGroupId" HeaderText="User Group ID" />
                                <asp:BoundField DataField="UserGroupName" HeaderText="Name" />
                                <asp:BoundField DataField="Description" HeaderText="Description" />
                                <asp:BoundField DataField="CreatedDateTime" HeaderText="Created Date" />
                                <asp:BoundField DataField="DeletedDateTime" HeaderText="Deleted Date" />
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="viewLinkButton" CssClass="btn btn-info" runat="server" OnClick="viewLinkButton_Click">View</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>--%>
                                    <div class="span3">
                                        <div class="control-group">
                                            <h6>
                                                Date From
                                            </h6>
                                            <div class="input-group">
                                                <div class="input-group-addon">
                                                    <i class="icon icon-calendar bigger-110"></i>
                                                </div>
                                                <div class="date" id="Div1" data-date-format="dd/mm/yyyy">
                                                    <span class="add-on"></span>
                                                    <asp:TextBox ID="fromDateTextBox" class="form-control" runat="server" required="required"
                                                        placeholder=""></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="span3">
                                        <div class="control-group">
                                            <h6>
                                                Date To
                                            </h6>
                                            <div class="input-group">
                                                <div class="input-group-addon">
                                                    <i class="icon icon-calendar bigger-110"></i>
                                                </div>
                                                <div class="date" id="Div2" data-date-format="dd/mm/yyyy">
                                                    <span class="add-on"></span>
                                                    <asp:TextBox ID="toDateTextBox" class="form-control" runat="server" required="required"
                                                        placeholder=""></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6" style="margin-top: 35px">
                                       
                                            <asp:Button ID="deletedListButton" runat="server" Text="Get Deleted List" CssClass="btn btn-info buttontopmargin5px"
                                                OnClick="deletedListButton_Click" />
                                       
                                        <asp:Button ID="allDeletedListButton" runat="server" Text="Get All Deleted List"
                                            CssClass="btn btn-info buttontopmargin5px" OnClick="allDeletedListButton_Click" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="span12">
                                        <hr />
                                        <div id="deletedListGridContainer">
                                            <asp:GridView ID="deletedListGridView" runat="server" AutoGenerateColumns="false"
                                                CssClass="table table-hover">
                                                <Columns>
                                                    <asp:BoundField DataField="UserGroupId" HeaderText="User Group ID" />
                                                    <asp:BoundField DataField="UserGroupName" HeaderText="Name" />
                                                    <asp:BoundField DataField="Description" HeaderText="Description" />
                                                    <asp:BoundField DataField="CreatedDateTime" HeaderText="Created Date" />
                                                    <asp:BoundField DataField="DeletedDateTime" HeaderText="Deleted Date" />
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="viewLinkButton" CssClass="btn btn-info" runat="server" OnClick="viewLinkButton_Click">View</asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="deletedListButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="allDeletedListButton" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            var dateFormat = '<%= Session["DateFormatForDatePicker"] %>';
            $(".date-textbox").datepicker({ format: dateFormat });
            $(".date-textbox, .icon-calendar").click(function () {
                $(this).parent().find(".date-textbox").focus();
            });

            //            $("#fromDateTextBox").rules("add", {
            //                required: true
            //            });

            //            $("#toDateTextBox").rules("add", {
            //                required: true
            //            });


            $("#Div1").datepicker();
            $("#Div2").datepicker();


            //           $("#deletedListGridView").dataTable({
            //                "bProcessing": true,
            //                "sPaginationType": "full_numbers",
            //                "aLengthMenu": [[10, 15, 20, 25, 50, -1], [10, 15, 20, 25, 50, "All"]],
            //                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [5]}]
            //            });
        });


        function pageLoad(sender, args) {
            $('#deletedListGridView').dataTable({
                "bJQueryUI": true,
                "sPaginationType": "full_numbers",
                "aaSorting": [[0, "desc"]]
            });
        }


    </script>
</asp:Content>
