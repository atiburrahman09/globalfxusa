<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="initialDataGroup.aspx.cs" Inherits="globalfx.a.initialdata.initialDataGroup" %>

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
    </div>
    <div class="grid simple horizontal purple">
        <div class="grid-title text-center">
            <h3 class="text-center">Initial Data <span class="semi-bold">Group</span></h3>
        </div>

        <div class="grid-body">
            
            <asp:HiddenField ID="hdbFieldId" runat="server" />
            <div class="row-fluid">
                <div class="span5">
                    <div class="control-group">
                        <div class="input-with-icon  right">

                            <label>Group Name:</label>
                            <asp:TextBox Class="span12" ID="txtbxGroupName" runat="server" placeholder="Group Name"></asp:TextBox>

                        </div>
                    </div>
                </div>
                <div class="span7">
                    <div class="control-group">
                        <div class="input-with-icon  right">

                            <label>Description</label>
                            <asp:TextBox Class="span12" ID="txtDescription" runat="server" placeholder="Description"></asp:TextBox>

                        </div>
                    </div>
                </div>
            </div>
            <div class="form-actions">
                <div class="pull-right">
                    <asp:Button class="btn btn-primary btn-cons" ID="btnSave" runat="server" Text="Save" OnClick="btnSaveElementGroup_Click" />
                    <asp:Button class="btn btn-primary btn-cons" ID="btnCancel" runat="server" Text="Cancel" />

                </div>
            </div>


            <br />
            <br />
            <div class="row-fluid">
                <asp:GridView ID="gridviewElementGroupList" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover">
                    <Columns>

                        <asp:BoundField DataField="ElementGrpId" HeaderText="ID" />
                        <asp:BoundField DataField="ElementGrpName" HeaderText="Name" />
                        <asp:BoundField DataField="ElementGrpDes" HeaderText="Description" />
                        <asp:BoundField DataField="CreatedBy" HeaderText="Created By" />
                        <asp:BoundField DataField="CreateDate" HeaderText="Created Date" />
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>

                                <asp:LinkButton ID="btnEdit" OnClick="EditLinkButton_OnClick" CssClass="btn btn-info" runat="server"> Edit</asp:LinkButton>

                                <%-- <asp:ImageButton ID="EditDepartmetImageButton" runat="server" ImageUrl="~/Content/Images/edit-icon_24.png"
                                        ToolTip="Edit" AlternateText="Edit" OnClick="EditDepartmetImageButton_Click" />
                                --%>
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
            $('#gridviewElementGroupList').dataTable();

        }
    </script>
</asp:Content>
