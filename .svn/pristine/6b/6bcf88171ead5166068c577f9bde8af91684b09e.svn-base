<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true"
    CodeBehind="DeletedList.aspx.cs" Inherits="globalfx.setting.User.DeletedList" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headPlaceHolder" runat="server">
    <%--<link href="/Content/Style/CSSPages/DeletedList.css" rel="stylesheet" type="text/css" />--%>
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div id="body_content">
        <fieldset>
            <legend>Deleted User List</legend>
            <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1"
                ChildrenAsTriggers="False">
                <ContentTemplate>





                    <div id="msgbox" runat="server" visible="false" class="alert alert-warning">
                        <button type="button" class="close" data-dismiss="alert">
                            &times;</button>
                        <h4>
                            <asp:Label ID="msgTitleLabel" runat="server" Text=""></asp:Label>
                        </h4>
                        <asp:Label ID="msgDetailLabel" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h5 class="widget-title bigger lighter">
                        <i class="icon icon-table"></i> User <small class="white"><i class="icon icon-angle-double-right">
                        </i>User Deleted List</small>
                    </h5>
                        </div>
                        <div class="panel-body">
                             <div class="row" style="margin-bottom: 30px;">
                        <div class="span12">
                            <div class="col-lg-4">
                                <h6>Date From</h6>
                                <%--  <div class="span8">
                            <i class="icon-calendar"></i>
                            <asp:TextBox ID="" CssClass="date-textbox" runat="server" Width="130px"></asp:TextBox></div>--%>
                                <div class="input-group bootstrap-timepicker">
                                    <asp:TextBox runat="server" ID="fromDateTextBox" CssClass="form-control date-picker" required="required" placeholder="Time"></asp:TextBox>

                                    <span class="input-group-addon">
                                        <i class="icon-clock-o bigger-110"></i>
                                    </span>
                                </div>
                            </div>
                            <div class="span4">
                                <h6>
                                    Date To
                                </h6>
                                <div class="input-group bootstrap-timepicker">
                                    <asp:TextBox runat="server" ID="toDateTextBox" CssClass="form-control date-picker" required="required" placeholder="Time"></asp:TextBox>

                                    <span class="input-group-addon">
                                        <i class="icon-clock-o bigger-110"></i>
                                    </span>
                                </div>
                                <%--<div class="span8">
                                    <i class="icon-calendar"></i>
                                    <asp:TextBox ID="" CssClass="date-textbox" runat="server" Width="130px"></asp:TextBox>
                                </div>--%>
                            </div>
                            </div>
                        </div>
                    <div class="row clearfix"></div>
                    <div class="row" style="margin-bottom: 30px;">
                        <div class="span12">
                            <div class="col-md-2">
                                
                                    <asp:Button ID="deletedListButton" runat="server" Text="Get Deleted List" CssClass="btn btn-info"
                                        OnClick="deletedListButton_Click" />
                                </div>
                                <div class="col-md-2">
                                    <asp:Button ID="allDeletedListButton" runat="server" Text="Get All Deleted List" CssClass="btn btn-info"
                                        OnClick="allDeletedListButton_Click" />
                                </div>
                            </div>
                        
                    </div>

                    <hr />
                            <div class="row">
                                <div class="span12">
                                    
                               
                    <div id="deletedListGridContainer">
                        <asp:GridView ID="deletedListGridView" runat="server" AutoGenerateColumns="false"
                            CssClass="table table-hover dataTable">
                            <Columns>
                                <asp:BoundField DataField="UserId" HeaderText="User ID" />
                                <asp:BoundField DataField="UserName" HeaderText="Name" />
                                <asp:BoundField DataField="EmployeeId" HeaderText="Employee ID" />
                                <asp:BoundField DataField="Department" HeaderText="Department" />
                                <asp:BoundField DataField="DeletedDateTime" HeaderText="Deleted Date" />
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="viewLinkButton" runat="server" CssClass="btn btn-info" OnClick="viewLinkButton_Click">View</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
 </div>
                            </div>
                        </div>
                    </div>
                   
                </ContentTemplate>
                <Triggers>

                    <asp:AsyncPostBackTrigger ControlID="deletedListButton"
                        EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="allDeletedListButton"
                        EventName="Click" />

                </Triggers>

            </asp:UpdatePanel>




        </fieldset>
    </div>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(function () {
                var dateFormat = '<%= Session["DateFormatForDatePicker"] %>';
                //$(".date-textbox").datepicker({ format: dateFormat });
                //$(".date-textbox, .icon-calendar").click(function () {
                //    $(this).parent().find(".date-textbox").focus();
                //});
                $('.date-picker').datepicker({
                    autoclose: true,
                    todayHighlight: true
                    
                })
				//show datepicker when clicking on the icon
				.next().on(ace.click_event, function () {
				    $(this).prev().focus();
				});
                $("#fromDateTextBox").rules("add", {
                    required: true
                });

                $("#toDateTextBox").rules("add", {
                    required: true
                });

                $("#deletedListGridView").dataTable({
                    "bProcessing": true,
                    "sPaginationType": "full_numbers",
                    "aLengthMenu": [[10, 15, 20, 25, 50, -1], [10, 15, 20, 25, 50, "All"]],
                    "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [5] }]
                });
            });
        }
    </script>
</asp:Content>
