<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true"
    CodeBehind="PrivilegeUserList.aspx.cs" Inherits="globalfx.setting.UserPrivilege.PrivilegeUserList" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headPlaceHolder" runat="server">
    <link href="/Content/Style/PageCSS/PrivilegeUserList.css" rel="stylesheet" type="text/css" />
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
                        <i class="icon icon-table"></i>UserPrivilege <small class="white"><i class="icon icon-angle-double-right">
                        </i>Privilege User List </small>
                    </h5>
                </div>
                <div class="grid-body">

<%--                    <div class="row">
                        <div class="span12">

                               <div class="span4">
                                        <div class="control-group">
                                            <h5>
                                                Branch Name</h5>
                                            <asp:DropDownList ID="BranchDropDownList" class="form-control select2-container" runat="server"
                                                AutoPostBack="true" OnSelectedIndexChanged="drpdownCenter_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                            </div>
                        </div>--%>
                    <div class="row">
                        <div class="span12">
                            <div id="userListGridContainer">
                                <asp:GridView ID="userListGridView" runat="server" AutoGenerateColumns="false" CssClass="table table-hover gridView">
                                    <Columns>
                                        <asp:BoundField DataField="UserId" HeaderText="User ID" />
                                        <asp:BoundField DataField="UserName" HeaderText="User Name" />
                                        <%--   <asp:BoundField DataField="EmployeeId" HeaderText="Employee ID" />--%>
                                        <asp:BoundField DataField="UserGroupId" HeaderText="User Group Id" />
                                        <asp:BoundField DataField="Email" HeaderText="Email" />
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="setMenuLinkButton" runat="server" CssClass="btn btn-mini btn-success"
                                                    OnClick="setMenuLinkButton_Click">Set Menu</asp:LinkButton>
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
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#userListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, 100, -1], [10, 15, 20, 25, 50, 100, "All"]],
                
            });
        });
    </script>
</asp:Content>
