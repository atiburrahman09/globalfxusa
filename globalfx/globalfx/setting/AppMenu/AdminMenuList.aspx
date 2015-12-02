<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true"
    CodeBehind="AdminMenuList.aspx.cs" Inherits="globalfx.setting.AppMenu.AdminMenuList" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/AppMenuList.css" rel="stylesheet" type="text/css" />
    <link href="/Content/Style/CSSPages/AppMenuTest.css" rel="stylesheet" type="text/css" />
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
        <div class="row widget-container-col ui-sortable" style="min-height: 261px;">
            <div class="panel panel-primary" style="opacity: 1;">
                <div class="panel-heading">
                    <h5 class="widget-title bigger lighter">
                        <i class="icon icon-table"></i> App. Menu List
                    </h5>
                </div>
                <div class="grid-body">
                    <div class="row">
                        <div class="span12">
                            <div id="allMenuImg">
                                <asp:ImageButton ID="refreshMenuImageButton" runat="server" AlternateText="All Menu"
                                    ToolTip="Refresh Menu" ImageUrl="~/Content/Images/Refresh-icon.png" OnClick="refreshMenuImageButton_Click" />
                                <asp:ImageButton ID="allMenuImageButton" runat="server" AlternateText="All Menu"
                                    ToolTip="Get All Menu" ImageUrl="~/Content/Images/database-icon.png" Height="40" Width="40" OnClick="allMenuImageButton_Click" />
                            </div>
                        </div>
                    </div>
                     <%-- <div id="MenuContent">
                        <div id="allMenuList">
                            <asp:Menu ID="testAllMenu" runat="server" Orientation="Horizontal" StaticEnableDefaultPopOutImage="false"
                                DynamicEnableDefaultPopOutImage="false" MaximumDynamicDisplayLevels="9" CssClass="navigation">
                            </asp:Menu>
                        </div>--%>
                        <div class="row">
                            <div class="span12">
                                <div class="span4">
                                    <div class="control-group">
                                        <h6>
                                            Menu For App.
                                        </h6>
                                        <asp:DropDownList CssClass="form-control" ID="menuForAppDropDownList" runat="server" AutoPostBack="true"
                                            OnSelectedIndexChanged="menuForAppDropDownList_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="span4">
                                    <div class="control-group">
                                        <h6>
                                            Menu Type
                                        </h6>
                                        <asp:DropDownList CssClass="form-control" ID="menuTypeDropDownList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="menuTypeDropDownList_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="span4">
                                    <div class="control-group">
                                        <h6>
                                            Menu Group
                                        </h6>
                                        <asp:DropDownList CssClass="form-control" ID="menuGroupDropDownList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="menuGroupDropDownList_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                       
                        <div class="row">
                      
                            <div class="span12">
                                <div class="span4">
                                    <div class="control-group">
                                        <h6>
                                            Parent Menu Level
                                        </h6>
                                        <asp:DropDownList CssClass="form-control" ID="menuLevelDropDownList" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                           
                        </div>
                       
                        <div class="row">
                            <div class="span12">
                                <asp:Button ID="getMenuListButton" runat="server" Text="Get Menu List" CssClass="btn btn-info"
                                    OnClick="getMenuListButton_Click" />
                                <asp:Button ID="getAllMenuListButton" runat="server" Text="Get All List" CssClass="btn btn-info"
                                    OnClick="getAllMenuListButton_Click" />
                            </div>
                        </div>
                         <hr />
                        <div class="row">
                         <div class="span12">
                            <asp:GridView ID="menuListGridView" runat="server" AutoGenerateColumns="false" CssClass="table table-hover gridView">
                                <Columns>
                                    <asp:BoundField DataField="MenuId" HeaderText="ID" />
                                    <asp:BoundField DataField="MenuName" HeaderText="Name" />
                                    <asp:BoundField DataField="ParentMenuName" HeaderText="Parent Menu" />
                                    <asp:BoundField DataField="MenuGroupName" HeaderText="Group" />
                                    <asp:BoundField DataField="IsSubParent" HeaderText="Parent" />
                                    <asp:BoundField DataField="IsActive" HeaderText="Active" />
                                    <asp:BoundField DataField="MenuType" HeaderText="Type" />
                                    <asp:BoundField DataField="MenuForApp" HeaderText="For" />
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="activateLinkButton" runat="server" CssClass="btn btn-mini btn-success"
                                                OnClick="activateLinkButton_Click" OnClientClick="return confirm('Are you sure you want to activate this Menu?');">Activate</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="deactivateLinkButton" runat="server" CssClass="btn btn-mini btn-inverse"
                                                OnClick="deactivateLinkButton_Click" OnClientClick="return confirm('Are you sure you want to deactivate this Menu?');">Deactivate</asp:LinkButton>
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
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#getMenuListButton").on("click", function (e) {
                if ($('#menuForAppDropDownList option:selected').text() == '----------Select----------') {
                    alert('Menu For App. field is required.');
                    $('#menuForAppDropDownList').focus();
                    e.preventDefault();
                    $("#form1").valid();
                    //return false;
                }

                if ($('#menuTypeDropDownList option:selected').text() == '----------Select----------') {
                    alert('Menu Type field is required.');
                    $('#menuTypeDropDownList').focus();
                    e.preventDefault();
                    $("#form1").valid();
                    //return false;
                }

                if ($('#menuGroupDropDownList option:selected').text() == '----------Select----------') {
                    alert('Menu Group field is required.');
                    $('#menuGroupDropDownList').focus();
                    e.preventDefault();
                    $("#form1").valid();
                    //return false;
                }

                if ($('#menuLevelDropDownList option:selected').text() == '----------Select----------') {
                    alert('Menu Level field is required.');
                    $('#menuLevelDropDownList').focus();
                    e.preventDefault();
                    $("#form1").valid();
                    //return false;
                }
            });

            //$(".navigation ul ul").css({ display: "none" });
            $(".navigation ul li").click(function () {
                $(this).find('ul:first').slideToggle(400);
            });

            $("#menuListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, 100, -1], [10, 15, 20, 25, 50, 100, "All"]],
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [8, 9]}]
            });
        });
    </script>
</asp:Content>
