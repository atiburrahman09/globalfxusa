﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="create.aspx.cs" Inherits="globalfx.a.stake.create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <div class="row-fluid">
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
                <h4 class="text-center">Create <span class="semi-bold">Stake</span></h4>
                <asp:HiddenField ID="hdbFieldId" runat="server" />
            </div>
            <div class="grid-body">

                <div class="row-fluid">
                    <div class="span5">
                        <div class="control-group">
                            <div class="input-with-icon  right">
                                <label>Stake Name:</label>
                                <asp:TextBox class="span12" ID="txtBxStakeName" required="required" runat="server" placeholder="Stake Name"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                    <div class="span6">
                        <div class="control-group">
                            <div class="input-with-icon  right">

                                <label>Amount:</label>
                                <asp:TextBox class="span12" ID="txtBxAmount" required="required" runat="server" placeholder="$"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                </div>



                <div class="row-fluid">
                    <div class="span5">
                        <div class="control-group">
                            <div class="input-with-icon  right">

                                <label>Daily Award:</label>
                                <asp:TextBox class="span12" Style="width: 46%;" ID="txtBxAwardFrom" runat="server" placeholder="0%"></asp:TextBox>&nbsp; to &nbsp;
                                    <asp:TextBox class="span12" Style="width: 46%;" ID="txtBxAwardTo" required="required" runat="server" placeholder="0%"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                    <div class="span6">
                        <div class="control-group">
                            <div class="input-with-icon  right">

                                <label>Avarage</label>
                                <asp:TextBox class="span12" ID="txtBxAvarage" required="required" runat="server" placeholder="%"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span5">
                        <div class="control-group">
                            <div class="input-with-icon  right">

                                <label>Duration:</label>
                                <asp:TextBox class="span12" ID="txtBxDuration" required="required" runat="server" placeholder="Months"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                    <div class="span6">
                        <div class="control-group">
                            <div class="input-with-icon  right">
                                <label>Bainory Cap:</label>
                                <asp:TextBox class="span12" ID="txtBxBainoryCap" required="required" runat="server" placeholder="Baionary Cap"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span11">
                        <label>Commission:</label>
                        <asp:TextBox class="span12" ID="txtBxCommission" required="required" runat="server" placeholder="%"></asp:TextBox>

                    </div>
                </div>
                <div class="form-actions">
                    <div class="pull-right">
                        <asp:Button class="btn btn-primary btn-cons" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                        <asp:Button class="btn btn-primary btn-cons" ID="btnCancel" runat="server" Text="Cancel" />

                    </div>
                </div>

                <br />

                <asp:GridView ID="gridviewStake" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="StakeId" HeaderText="ID" />
                        <asp:BoundField DataField="StakeName" HeaderText="Stake Name" />
                        <asp:BoundField DataField="Amount" HeaderText="Amount" />
                        <asp:BoundField DataField="DailyAwardFrom" HeaderText="Award From" />
                        <asp:BoundField DataField="DailyAwardTo" HeaderText="Award To" />
                        <asp:BoundField DataField="Avarage" HeaderText="Avg" />
                        <asp:BoundField DataField="TotalDuration" HeaderText="Duration" />
                        <asp:BoundField DataField="BinaryCap" HeaderText="Binary Cap" />
                        <asp:BoundField DataField="Parcentage" HeaderText="Commission" />
                        <asp:BoundField DataField="CreatedDate" HeaderText="Created Date" />
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
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function pageLoad(sender, args) {
            $("#gridviewStake").dataTable();
        });
    </script>
</asp:Content>
