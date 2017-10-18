using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace WebUI.Utilities
{
    public class Email
    {
        /// <summary>
        /// Envia un correo a traves de una cuenta de Gmail.
        /// </summary>
        /// <param name="toEmail">Email del destinatario</param>
        /// <param name="toName">Nombre del destinatario</param>
        /// <param name="subject">Asunto del mail</param>
        /// <param name="body">Cuerpo o Mensaje del mail</param>
        public static void Enviar(string toEmail, string toName, string subject, string body)
        {
            string htmlBody = body;
            var toAddress = new MailAddress(toEmail, toName);
            var mail = new MailMessage
            {
                From = new MailAddress("doble136@hotmail.com", "Mandame Fruta"),
                Subject = subject,
                IsBodyHtml = true,
                Body = htmlBody,
            };
            mail.To.Add(toAddress);
            using (SmtpClient SmtpServer = new SmtpClient("smtp.live.com"))
            {
                SmtpServer.Send(mail);
            }
            

        }
    }
}