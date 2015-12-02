﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="tree.aspx.cs" Inherits="globalfx.generic.tree" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="row-fluid">
        <div class="grid simple horizontal purple">
            <div class="grid-title">
                <h3 class="text-center semi-bold">Geneology Tree</h3>
            </div>
            <div class="grid-body">
                <div class="row-fluid">

                    <div class="span4 pull-right">
                        <label>Downline User Id</label>
                        <div class="input-append success date">
                            <asp:TextBox ID="txtbxUserId" CssClass="span7" runat="server"></asp:TextBox>
                            <asp:LinkButton ID="btnSearchTree" class="btn btn-success btn-cons" OnClick="btnSearchTree_Click" runat="server"><i class="icon icon-search"></i> Search</asp:LinkButton>


                        </div>
                    </div>

                </div>
                <br />
                <div class="row-fluid pop">

                    <p class="text-center">

                        <a type="button" id="lbl1" runat="server" data-toggle="popover" class="btn popover1">
                            <asp:Image ID="ilbl1" ImageUrl="/assets/img/user.png" ImageAlign="Middle" Width="70px" runat="server" />
                        </a>
                    </p>
                    <p class="text-center popname">
                        <asp:LinkButton ID="btnlbl1" Text="lbl1" CssClass="bold semi-bold" runat="server" OnClick="btnlbl1_Click"><i class="icon icon-anchor"></i> </asp:LinkButton>

                    </p>



                    <div class="row-fluid">
                        <div class="span6">
                            <p class="text-center">
                                <a type="button" id="lbl2L" runat="server" data-toggle="popover" class="btn popover1">
                                    <asp:Image ID="ilbl2L" ImageUrl="/assets/img/user.png" ImageAlign="Middle" Width="70px" runat="server" />
                                </a>
                            </p>
                            <p class="text-center popname">

                                <asp:LinkButton ID="btnlbl2L" Text="btnlbl2L" OnClick="btnlbl1_Click" runat="server"></asp:LinkButton>
                            </p>

                            <div class="row-fluid">
                                <div class="span6">
                                    <p class="text-center">
                                        <a type="button" id="lbl21L" runat="server" data-toggle="popover" class="btn popover1">
                                            <asp:Image ID="ilbl21L" ImageUrl="/assets/img/user.png" ImageAlign="Middle" Width="70px" runat="server" />
                                        </a>
                                    </p>
                                    <p class="text-center popname">

                                        <asp:LinkButton ID="btnlbl21L" Text="btnlbl21L" OnClick="btnlbl1_Click" runat="server"></asp:LinkButton>
                                    </p>

                                    <div class="row-fluid">
                                        <div class="span6">
                                            <p class="text-center">
                                                <a type="button" id="lbl211L" runat="server" data-toggle="popover" class="btn popover1">
                                                    <asp:Image ID="ilbl211L" ImageUrl="/assets/img/user.png" ImageAlign="Middle" Width="70px" runat="server" />
                                                </a>
                                            </p>
                                            <p class="text-center popname">

                                                <asp:LinkButton ID="btnlbl211L" OnClick="btnlbl1_Click" Text="lbl211L" runat="server"></asp:LinkButton>
                                            </p>

                                        </div>
                                        <div class="span6">
                                            <p class="text-center">
                                                <a type="button" id="lbl212R" runat="server" data-toggle="popover" class="btn popover1">
                                                    <asp:Image ID="ilbl212R" ImageUrl="/assets/img/user.png" ImageAlign="Middle" Width="70px" runat="server" />
                                                </a>
                                            </p>
                                            <p class="text-center popname">

                                                <asp:LinkButton ID="btnlbl212R" OnClick="btnlbl1_Click" Text="lbl212R" runat="server"></asp:LinkButton>
                                            </p>

                                        </div>
                                    </div>
                                </div>
                                <div class="span6">
                                    <p class="text-center">
                                        <a type="button" id="lbl22R" runat="server" data-toggle="popover" class="btn popover1">
                                            <asp:Image ID="ilbl22R" ImageUrl="/assets/img/user.png" ImageAlign="Middle" Width="70px" runat="server" />
                                        </a>
                                    </p>
                                    <p class="text-center popname">

                                        <asp:LinkButton ID="btnlbl22R" OnClick="btnlbl1_Click" Text="lbl22R" runat="server"></asp:LinkButton>
                                    </p>

                                    <div class="row-fluid">
                                        <div class="span6">
                                            <p class="text-center">
                                                <a type="button" id="lbl221L" runat="server" data-toggle="popover" class="btn popover1">
                                                    <asp:Image ID="ilbl221L" ImageUrl="/assets/img/user.png" ImageAlign="Middle" Width="70px" runat="server" />
                                                </a>
                                            </p>
                                            <p class="text-center popname">

                                                <asp:LinkButton ID="btnlbl221L" OnClick="btnlbl1_Click" Text="lbl221L" runat="server"></asp:LinkButton>
                                            </p>

                                        </div>
                                        <div class="span6">
                                            <p class="text-center">
                                                <a type="button" id="lbl222R" runat="server" data-toggle="popover" class="btn popover1">

                                                    <asp:Image ID="ilbl222R" ImageUrl="/assets/img/user.png" ImageAlign="Middle" Width="70px" runat="server" />

                                                </a>
                                            </p>
                                            <p class="text-center popname">

                                                <asp:LinkButton ID="btnlbl222R" OnClick="btnlbl1_Click" Text="lbl222R" runat="server"></asp:LinkButton>

                                            </p>

                                        </div>
                                    </div>


                                </div>
                            </div>
                        </div>



                        <div class="span6">
                            <p class="text-center">
                                <a type="button" data-placement="left" id="lbl3R" runat="server" data-toggle="popover" class="btn popover1">
                                    <asp:Image ID="ilbl3R" ImageUrl="/assets/img/user.png" ImageAlign="Middle" Width="70px" runat="server" />
                                </a>
                            </p>
                            <p class="text-center popname">

                                <asp:LinkButton ID="btnlbl3R" OnClick="btnlbl1_Click" Text="lbl3R" runat="server"></asp:LinkButton>

                            </p>

                            <div class="row-fluid">
                                <div class="span6">
                                    <p class="text-center">
                                        <a type="button" id="lbl31L" runat="server" data-toggle="popover" class="btn popover1">
                                            <asp:Image ID="ilbl31L" ImageUrl="/assets/img/user.png" ImageAlign="Middle" Width="70px" runat="server" />
                                        </a>
                                    </p>
                                    <p class="text-center popname">
                                        <asp:LinkButton ID="btnlbl31L" OnClick="btnlbl1_Click" Text="lbl31L" runat="server"></asp:LinkButton>


                                    </p>

                                    <div class="row-fluid">
                                        <div class="span6">
                                            <p class="text-center">
                                                <a type="button" id="lbl311L" runat="server" data-toggle="popover" class="btn popover1">
                                                    <asp:Image ID="ilbl311L" ImageUrl="/assets/img/user.png" ImageAlign="Middle" Width="70px" runat="server" />
                                                </a>
                                            </p>
                                            <p class="text-center popname">
                                                <asp:LinkButton ID="btnlbl311L" OnClick="btnlbl1_Click" Text="lbl311L" runat="server"></asp:LinkButton>


                                            </p>

                                        </div>
                                        <div class="span6">
                                            <p class="text-center">
                                                <a type="button" id="lbl312R" runat="server" data-toggle="popover" class="btn popover1">
                                                    <asp:Image ID="ilbl312R" ImageUrl="/assets/img/user.png" ImageAlign="Middle" Width="70px" runat="server" />
                                                </a>
                                            </p>
                                            <p class="text-center popname">
                                                <asp:LinkButton ID="btnlbl312R" OnClick="btnlbl1_Click" Text="btnLbl21L" runat="server"></asp:LinkButton>
                                            </p>

                                        </div>
                                    </div>
                                </div>

                                <div class="span6">
                                    <p class="text-center">
                                        <a type="button" data-placement="left" id="lbl32R" runat="server" data-toggle="popover" class="btn popover1">
                                            <asp:Image ID="ilbl32R" ImageUrl="/assets/img/user.png" ImageAlign="Middle" Width="70px" runat="server" />
                                        </a>
                                    </p>
                                    <p class="text-center popname">
                                        <asp:LinkButton ID="btnlbl32R" OnClick="btnlbl1_Click" Text="lbl32R" runat="server"></asp:LinkButton>


                                    </p>

                                    <div class="row-fluid">
                                        <div class="span6">
                                            <p class="text-center">
                                                <a type="button" id="lbl321L" runat="server" data-toggle="popover" class="btn popover1">
                                                    <asp:Image ID="ilbl321L" ImageUrl="/assets/img/user.png" ImageAlign="Middle" Width="70px" runat="server" />
                                                </a>
                                            </p>
                                            <p class="text-center popname">
                                                <asp:LinkButton ID="btnlbl321L" OnClick="btnlbl1_Click" Text="lbl321L" runat="server"></asp:LinkButton>


                                            </p>

                                        </div>

                                        <div class="span6">
                                            <p class="text-center">
                                                <a type="button" data-placement="left" id="lbl322R" runat="server" data-toggle="popover" class="btn popover1">
                                                    <asp:Image ID="ilbl322R" ImageUrl="/assets/img/user.png" ImageAlign="Middle" Width="70px" runat="server" />
                                                </a>
                                            </p>
                                            <p class="text-center popname">
                                                <asp:LinkButton ID="btnlbl322R" OnClick="btnlbl1_Click" Text="lbl322R" runat="server"></asp:LinkButton>


                                            </p>

                                        </div>
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
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
     <script type="text/javascript">
        function pageLoad(sender, args) {

          
            $("#btnSearchTree").click(function () {
                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });


        }
    </script>
</asp:Content>
