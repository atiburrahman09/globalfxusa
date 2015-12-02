<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="stakekeylog.aspx.cs" Inherits="globalfx.a.stake.stakekeylog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
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



        <asp:GridView ID="GridViewStakeLog" runat="server" AutoGenerateColumns="false" CssClass="table table-hover table-condensed">
            <Columns>
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblUserId" runat="server" Text='<%# Eval("UserId")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="UserId" HeaderText="User Id" />
                <asp:BoundField DataField="StakeKey" HeaderText="Stake Key" />
                <asp:BoundField DataField="LogMsg" HeaderText="Log Messege" />
                <asp:BoundField DataField="SentTo" HeaderText="Sent To" />
                <asp:BoundField DataField="SentStatus" HeaderText="Sent Status" />

            </Columns>
        </asp:GridView>

    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
</asp:Content>
