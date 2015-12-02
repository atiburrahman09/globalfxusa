﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net.Mail;
using Lumex.Tech;
using Global.Core.DAL;
using System.Data;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

using System.Configuration;



namespace Global.Core.BLL
{
    public class MailContactBLL
    {

        public string UserMail { get; set; }

        public string MailBody { get; set; }

        public string MailSubject { get; set; }

        public bool sendemailtocompleteResigtration(UserBLL user, string body)
        {
            bool status = false;
            try
            {
                MailMessage mail = new MailMessage();
                LumexDBPlayer db = LumexDBPlayer.Start();
                UserDAL userdal = new UserDAL();
                DataTable dt = userdal.UpdateUserVarificationCode(user, db);
                db.Stop();
                if (dt.Rows.Count > 0)
                {

                    UserMail = user.Email;
                    MailBody = body;

                    //    MailBody = "Dear " + dt.Rows[0][0].ToString() + "\n To complete Your Resigtration Process \r\n\r\n\r\"Please Click the Link :" + user.ActivationUrl + "\r\n\r\n Your Login Name is : " + user.UserId + "\r\n\r\n If any problem feel free to contact site Admin. \r\n";

                }

                //   SmtpClient SmtpServer = new SmtpClient("mail.lovetelsolution.com");
                SmtpClient SmtpServer = new SmtpClient(SystemBLL.MailServer);
                mail.From = new MailAddress(SystemBLL.MailAddess);
                mail.IsBodyHtml = true;
                mail.To.Add(UserMail);
                mail.Subject = "Resigtration Conformation";
                mail.Body = MailBody;
                SmtpServer.Port = SystemBLL.Port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(SystemBLL.MailAddess, SystemBLL.MailPass);
                //SmtpServer.EnableSsl = SystemBLL.Enablessl;
                ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                SmtpServer.Send(mail);
                status = true;


            }
            catch (Exception)
            {
                throw;
            }
            return status;
        }


        public bool SendEmailForPasswordReset(UserBLL userBll)
        {
            bool status = false;
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                UserDAL userDAL = new UserDAL();
                userDAL.UpdateUserVarificationCode(userBll, db);
                db.Stop();
                UserMail = userBll.Email;
                MailSubject = "Password Reset Request";
                MailBody = "Dear " + userBll.UserName + "\nTo Reset Your Access password \r\n\r\n\r\"Please Click the Link :" + userBll.ActivationUrl + "\r\n\r\n Your varification code is : " + userBll.varifycode + "\r\n\r\n If any problem feel free to contact site Admin \r\n";

                status = sendemailToConfirm();

            }
            catch (Exception)
            {

                throw;
            }
            return status;
        }

        public bool sendemailToConfirm()
        {
            bool status = false;
            try
            {

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(SystemBLL.MailServer);

                mail.From = new MailAddress(SystemBLL.MailAddess);
                mail.To.Add(UserMail);
                mail.Subject = MailSubject;
                mail.IsBodyHtml = true;
                mail.Body = MailBody;
                SmtpServer.Port = SystemBLL.Port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(SystemBLL.MailAddess, SystemBLL.MailPass);
                // SmtpServer.EnableSsl = SystemBLL.Enablessl;
                ServicePointManager.ServerCertificateValidationCallback =
    delegate(object s, X509Certificate certificate,
             X509Chain chain, SslPolicyErrors sslPolicyErrors)
    { return true; };
                SmtpServer.Send(mail);
                status = true;
            }

            catch (Exception)
            {
                throw;
            }
            return status;
        }



        public void SendHtmlFormattedEmail(string recepientEmail, string subject, string body)
        {
            //using (MailMessage mailMessage = new MailMessage())
            //{
            //    mailMessage.From = new MailAddress(SystemBLL.MailAddess);
            //    mailMessage.Subject = subject;
            //    mailMessage.Body = body;
            //    mailMessage.IsBodyHtml = true;
            //    mailMessage.To.Add(new MailAddress(recepientEmail));
            //    SmtpClient smtp = new SmtpClient();
            //    smtp.Host = ConfigurationManager.AppSettings["Host"];
            //    smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
            //    System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
            //    NetworkCred.UserName = ConfigurationManager.AppSettings["UserName"];
            //    NetworkCred.Password = ConfigurationManager.AppSettings["Password"];
            //    smtp.UseDefaultCredentials = true;
            //    smtp.Credentials = NetworkCred;
            //    smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
            //    smtp.Send(mailMessage);
            //}
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(SystemBLL.MailServer);

            mail.From = new MailAddress(SystemBLL.MailAddess);
            mail.To.Add(recepientEmail);
            mail.Subject = subject;
            mail.IsBodyHtml = true;
            mail.Body = body;
            SmtpServer.Port = SystemBLL.Port;
            SmtpServer.Credentials = new System.Net.NetworkCredential(SystemBLL.MailAddess, SystemBLL.MailPass);
            // SmtpServer.EnableSsl = SystemBLL.Enablessl;
            ServicePointManager.ServerCertificateValidationCallback =delegate(object s, X509Certificate certificate,X509Chain chain, SslPolicyErrors sslPolicyErrors){ return true; };
            SmtpServer.Send(mail);
            //  status = true;
        }
    }
}
