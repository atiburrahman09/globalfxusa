<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="globalfx.page.contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="row-fluid">
        <div class="grid simple">            
            <div class="grid-body no-border">
                <h2 class="text-center"style="margin-top:0px; padding-top:20px;">Contact <span class="semi-bold">Us</span></h2>
			<form class="form-no-horizontal-spacing" id="form_iconic_validation">	
                <div class="row-fluid column-seperation">                
                  <div class="span12">                      
                      <iframe width="100%" height="272" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2911.802779467336!2d-79.0184009849755!3d43.12966909414428!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x89d3678b08525129%3A0xe46a7ec665cfe286!2s3909+Witmer+Rd%2C+Niagara+Falls%2C+NY+14305%2C+USA!5e0!3m2!1sen!2sbd!4v1446560236058"></iframe>
                  </div>
                </div>
            </div>
        </div>
    </div>



    <div class="row-fluid">
        <div class="grid simple">
            <div class="grid-body no-border">
                
                    <div class="row-fluid column-seperation">
                        <div class="span12">
                            <h4>Feel Free to  <span class="semi-bold">Contact Us</span></h4>
                            <div class="row-fluid">
                                <div class="span12">
                                    <div class="control-group">
                                        <div class="input-with-icon  right">
                                            <i class=""></i>
                                            <input name="yourName" id="yourName" type="text" class="span12" placeholder="Your Name">
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row-fluid">
                                <div class="span12">
                                    <div class="control-group">
                                        <div class="input-with-icon  right">
                                            <i class=""></i>
                                            <input name="yourEamil" id="yourEamil" type="text" class="span12" placeholder="Your Email">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row-fluid">
                                <div class="span12">
                                    <div class="control-group">
                                        <div class="input-with-icon  right">
                                            <i class=""></i>
                                            <input name="subject" id="subject" type="text" class="span12" placeholder=" Subject">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row-fluid">
                                <div class="span12">
                                    <div class="control-group">
                                        <div class="input-with-icon  right">
                                            <i class=""></i>
                                            <textarea id="text-editor" class="span12" rows="10" placeholder="Your Message ..."></textarea>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="form-actions">
                        <div class="pull-right">
                            <button class="btn btn-primary btn-cons" type="submit"><i class="icon-ok"></i>Submit</button>
                            <button class="btn btn-danger btn-cons" type="reset">Reset</button>
                        </div>
                    </div>
               
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
</asp:Content>
