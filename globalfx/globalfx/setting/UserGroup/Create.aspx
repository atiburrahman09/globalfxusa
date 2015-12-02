<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true"
    CodeBehind="Create.aspx.cs" Inherits="globalfx.setting.UserGroup.Create" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="False">
        <ContentTemplate>
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


                    <div class="row-fluid" style="min-height: 261px;">
                        <div class="grid simple horizontal purple">
                            <div class="grid-title">
                                <h5 class="widget-title bigger lighter">
                                    <i class="icon icon-table"></i>Create User Group 
                                </h5>
                            </div>
                            <div class="grid-body">
                                <div class="row-fluid">

                                    <div class="span4">
                                        <div class="control-group">
                                            <h6 class="control-label">User Group Name
                                            </h6>
                                            <div class="controls">
                                                <asp:TextBox ID="userGroupNameTextBox" class="form-control" required="required" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="span8">
                                        <div class="control-group">
                                            <h6 class="control-label">Description
                                            </h6>
                                            <div class="controls">
                                                <asp:TextBox ID="descriptionTextBox" runat="server" class="form-control" required="required"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    k

                                </div>

                                <div class="row">

                                    <div class="span12 text-center input-group save_button">
                                        <div aria-label="" role="group" class="btn-group">
                                            <div role="group" class="btn-group">
                                                <asp:Button ID="saveButton" runat="server" Text="Save Group" CssClass="btn btn-primary btn-lg"
                                                    OnClick="saveButton_Click" />

                                            </div>

                                        </div>

                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>


                </div>
                <!-- PAGE CONTENT ENDS -->
            </div>
            <!-- /.page-content -->
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="saveButton" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#userGroupNameTextBox").rules("add", {
                required: true
            });

            $("#descriptionTextBox").rules("add", {
                required: true
            });
        });
    </script>
</asp:Content>
