﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="initialDataElement.aspx.cs" Inherits="globalfx.a.initialdata.initialDataElement" %>

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
        <div class="grid-body no-border">
            <legend class="text-center" style="padding-top: 20px">Initial Data <span class="semi-bold">Group</span></legend>
            <asp:HiddenField ID="hdbFieldId" runat="server" />
            <div class="row-fluid">
                <div class="span8">
                    <div class="control-group">
                        <div class="input-with-icon  right">
                            <label>Element Name:</label>
                            <asp:TextBox class="span12" ID="txtbxElementName" runat="server" placeholder="Element Name"></asp:TextBox>

                        </div>
                    </div>
                </div>
                <div class="span4">
                    <div class="control-group">
                        <div class="input-with-icon  right">
                            <label>Group</label>
                            <asp:DropDownList class="span12" ID="ddlGroup" runat="server">
                                <%--    <asp:ListItem Text="Group 1" Value="0"></asp:ListItem>
                                --%>
                            </asp:DropDownList>

                        </div>
                    </div>
                </div>
            </div>

            <div class="row-fluid">
                <div class="span11">
                    <label>Description</label>
                    <asp:TextBox class="span12" ID="txtbxDescription" runat="server" placeholder="Description"></asp:TextBox>

                    <br />

                    <br />

                </div>
            </div>
            <div class="form-actions">
                <div class="pull-right">
                    <asp:Button class="btn btn-primary btn-cons" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                    <asp:Button class="btn btn-primary btn-cons" ID="btnReject" runat="server" Text="Reject" OnClick="btnReject_Click" />

                </div>
            </div>
            <br />
            <br />
            <div class="row-fluid">
                <asp:GridView ID="gridviewInitialDataElement" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover">

                    <Columns>
                        <asp:BoundField DataField="ElementId" HeaderText="ID" />
                        <asp:BoundField DataField="ElementName" HeaderText="Element Name" />
                        <asp:BoundField DataField="ElementGroup" HeaderText="Group " />
                        <asp:BoundField DataField="Suffix" HeaderText="Description" />
                        <asp:BoundField DataField="CreatedBy" HeaderText="Created By" />
                        <asp:TemplateField></asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" OnClick="EditLinkButton_OnClick" CssClass="btn btn-info" runat="server"> Edit</asp:LinkButton>

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

        $(function pageLoad(sender, args) {
            $("#gridviewInitialDataElement").dataTable();
        });
    </script>
</asp:Content>
