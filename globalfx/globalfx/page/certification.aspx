﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="certification.aspx.cs" Inherits="globalfx.page.certification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <div class="container-fluid">
        <div class="row-fluid">


            <div class="aboutus investment">
                <div class="span3"></div>
                <div class="span6">
                    <img style="width: 100%;" src="/assets/img/certification.jpg" />
                </div>
                <div class="span3">

                    <a class="btn btn-success btn-cons" href="/download/presentation.ppt">Download PPT</a>

                    <a class="btn btn-success btn-cons" href="/download/fxpresent.pdf">Download PDF</a>


                </div>
            </div>

        </div>


    </div>



    <div class="clearfix"></div>
    <div class="getway">
        <div class="container text-center ">
            <ul>
                <li><a href="#">
                    <img src="/assets/img/cc/ico-american-express.jpg" />
                </a></li>
                <li><a href="#">
                    <img src="/assets/img/cc/ico-discover.jpg" />
                </a></li>
                <li><a href="#">
                    <img src="/assets/img/cc/ico-mastercard.jpg" />
                </a></li>
                <li><a href="#">
                    <img src="/assets/img/cc/ico-paypal.jpg" />
                </a></li>
                <li><a href="#">
                    <img src="/assets/img/cc/ico-visa.jpg" />
                </a></li>
            </ul>
            <p>
                Risk Warning: Trading on financial markets carries risks. Contracts for Difference (‘CFDs’) 
                        are complex financial products that are traded on margin. Trading CFDs carries a high level 
                        of risk since leverage can work both to your advantage and disadvantage. As a result, CFDs may not be suitable for all
                        investors because you may lose all your invested capital. You should not risk more than you are prepared to lose.
                        Before deciding to trade, you need to ensure that you understand the risks involved taking into account your investment 
                        objectives and level of experience
                   
            </p>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
</asp:Content>
