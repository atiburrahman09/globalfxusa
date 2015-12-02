﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="upload.aspx.cs" Inherits="globalfx.a.manage.upload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="grid simple horizontal purple">
        <div class="grid-title">
            <h3>File <span class="semi-bold">Upload</span> </h3>
        </div>
        <div class="grid-body">
            <div class="row-fluid">
                <div class="span6">
                    <div class="row-fluid">
                        <div class="control-group">
                            <label class="semi-bold">PPT File</label>
                            <div class="controls">
                                <asp:FileUpload CssClass="uploader" ID="pptflupload" runat="server" />
                            </div>

                        </div>
                        <div class="span12">
                            <asp:Button ID="uploadpptButton" runat="server" Text="Upload"
                                CssClass="btn btn-primary" OnClick="uploadButton_Click" />
                        </div>
                    </div>
                </div>
                <div class="span6">
                    <div class="row-fluid">
                        <div class="control-group">
                            <label class="semi-bold">PDF File</label>
                            <div class="controls">
                                <asp:FileUpload CssClass="uploader" ID="pdfFileUpload" runat="server" />
                            </div>

                        </div>
                        <div class="span12">
                            <asp:Button ID="btnpdfUpload" runat="server" Text="Upload"
                                CssClass="btn btn-primary" OnClick="btnpdfUpload_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <br />
            <%--<asp:Repeater ID="RepeaterImages" runat="server">
                <ItemTemplate>
                    <asp:Image ID="Image" runat="server" ImageUrl='<%# Container.DataItem %>' />
                </ItemTemplate>
            </asp:Repeater>--%>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" EmptyDataText="No files uploaded">
                <Columns>
                    <asp:BoundField DataField="Text" HeaderText="File Name" />
                   
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script>
        $('#GridView1').dataTable();
    </script>
</asp:Content>
