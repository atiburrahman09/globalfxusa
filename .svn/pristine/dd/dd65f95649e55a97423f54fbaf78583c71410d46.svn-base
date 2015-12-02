<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true"
    CodeBehind="UserPreviligeForBranch.aspx.cs" Inherits="TaskMaster.HRUI.UserPrivilege.UserPreviligeForBranch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div id="body_content">
        <%-- <fieldset>
            <legend>Privilege User List</legend>--%>
        <div id="msgbox" runat="server" visible="false" class="alert alert-error">
            <button type="button" class="close" data-dismiss="alert">
                &times;</button>
            <h4>
                <asp:Label ID="msgTitleLabel" runat="server" Text=""></asp:Label>
            </h4>
            <asp:Label ID="msgDetailLabel" runat="server" Text=""></asp:Label>
        </div>
        <div class="panel panel-primary">
            <header class="panel-heading">
                   <%--     <div class="widget-header-icon">
                            </div>--%>
                        <h3 id="Header3" runat="server" class="widget-header-title">
                      Privilege User List</h3>
                    </header>
            <div class="grid-body PaddingAll9px">
                <div class="row-fluid span12">
                    <div id="userListGridContainer">
                        <asp:GridView ID="userListGridView" runat="server" AutoGenerateColumns="false" CssClass="table table-hover gridView">
                            <Columns>
                                <asp:BoundField DataField="UserId" HeaderText="User ID" />
                                <asp:BoundField DataField="UserName" HeaderText="User Name" />
                                <%--   <asp:BoundField DataField="EmployeeId" HeaderText="Employee ID" />--%>
                                <asp:BoundField DataField="UserGroupName" HeaderText="User Group Name" />
                                <asp:BoundField DataField="IsActive" HeaderText="Active" />
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="setMenuLinkButton" runat="server" CssClass="btn btn-mini btn-success"
                                            OnClick="setMenuLinkButton_Click">Set User Branch</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
        <%--</fieldset>--%>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#userListGridView").dataTable();
        });
    </script>
</asp:Content>
