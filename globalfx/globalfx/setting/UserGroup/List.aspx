<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true"
    CodeBehind="List.aspx.cs" Inherits="globalfx.setting.UserGroup.List" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/UserGroupList.css" rel="stylesheet" type="text/css" />
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
        <div class="row-fluid">

            <div class="row widget-container-col ui-sortable" style="min-height: 261px;">
                <div class="grid simple horizontal purple">
                    <div class="grid-title">
                        <h5 class="widget-title bigger lighter">
                            <i class="icon icon-table white"></i>&nbsp; User Group list 
                        </h5>
                    </div>
                    <div class="grid-body">
                        <div class="row-fluid">

                            <asp:GridView ID="userGroupListGridView" runat="server" AutoGenerateColumns="false"
                                CssClass="table table-hover">
                                <Columns>
                                    <asp:BoundField DataField="UserGroupId" HeaderText="User Group ID" />
                                    <asp:BoundField DataField="UserGroupName" HeaderText="User Group Name" />
                                    <asp:BoundField DataField="Description" HeaderText="Description" />
                                    <asp:BoundField DataField="IsActive" HeaderText="Active" />
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="editLinkButton" runat="server" CssClass="btn btn-info clickProcessing"
                                                OnClick="editLinkButton_Click">Edit</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="activateLinkButton" runat="server" CssClass="btn btn-success clickProcessing"
                                                OnClick="activateLinkButton_Click">Activate</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="deactivateLinkButton" CssClass="btn btn-warning clickProcessing"
                                                runat="server" OnClick="deactivateLinkButton_Click">Deactivate</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%-- <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="deleteLinkButton" CssClass="btn btn-danger clickProcessing" runat="server"
                                                OnClick="deleteLinkButton_Click">Delete</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
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
            $("#userGroupListGridView").dataTable();
        });
        function pageLoad(sender, args) {



            $(".clickProcessing").live("click", function (e) {
                if (haveOverlay == 0) {

                    var col = $(this).parent().children().parent().index();
                    var row = $(this).parent().parent().index();
                    Id = $("#userGroupListGridView").find("tr td:nth-child(1)").eq(row).text();
                    isActive = $("#userGroupListGridView").find("tr td:nth-child(4)").eq(row).text();

                    var id = $(this).attr("id");
                    var str = $(this).attr("href");
                    var arr = str.split("'");
                    var msg = "";

                    if (isActive == "True" && id == "activateLinkButton") {
                        WarningAlert("Process Redundant", "This User Group? <span class='actionTopic'>already activated</span>.", "");
                    }
                    else if (isActive == "False" && id == "deactivateLinkButton") {
                        WarningAlert("Process Redundant", "This User Group? <span class='actionTopic'>already deactivated</span>.", "");
                    }
                    else {

                        if (id == "activateLinkButton") {
                            msg = "Are you sure you want to <span class='actionTopic'>activate</span> thisUser Group?";
                        }
                        else if (id == "deactivateLinkButton") {
                            msg = "Are you sure you want to <span class='actionTopic'>deactivate</span> this User Group?";
                        }
                        else if (id == "deleteLinkButton") {
                            msg = "Are you sure you want to <span class='actionTopic'>delete</span> this User Group?";
                        }
                        else if (id == "editLinkButton") {
                            msg = "Are you sure you want to <span class='actionTopic'>Edit</span> this User Group?";
                        }


                        ConfirmProcess(msg, function () {
                            MyOverlayStart();
                            __doPostBack(arr[1], '');
                        }, function () {

                        });
                    }

                    e.preventDefault();
                }
            });


        };
    </script>
</asp:Content>
