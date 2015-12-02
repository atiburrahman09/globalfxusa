﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true"
    CodeBehind="ListView.aspx.cs" Inherits="globalfx.setting.UserGroup.ListView" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/UserGroupList.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
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
          <div class="row">
            <div class="span12">
        <div class="row widget-container-col ui-sortable" style="min-height: 261px;">
            <div class="panel panel-primary" style="opacity: 1;">
                <div class="panel-heading">
                    <h5 class="widget-title bigger lighter">
                        <i class="icon icon-table"></i>UserGroup <small class="white"><i class="icon icon-angle-double-right">
                        </i>User Group List View</small>
                    </h5>
                </div>
                <div class="grid-body  padding-all-10px">
                    <div class="row">
                        <div class="span12">
                            <asp:GridView ID="userGroupListGridView" runat="server" AutoGenerateColumns="false"
                                CssClass="table table-hover">
                                <Columns>
                                    <asp:BoundField DataField="UserGroupId" HeaderText="User Group ID" />
                                    <asp:BoundField DataField="UserGroupName" HeaderText="User Group Name" />
                                    <asp:BoundField DataField="Description" HeaderText="Description" />
                                    <asp:BoundField DataField="IsActive" HeaderText="Active" />
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
    <%-- </fieldset>--%>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#userGroupListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, 100, -1], [10, 15, 20, 25, 50, 100, "All"]],
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [4]}]
            });
        });
    </script>
</asp:Content>
