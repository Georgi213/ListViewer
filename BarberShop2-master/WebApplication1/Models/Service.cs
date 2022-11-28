using MimeKit;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc.Razor;

namespace WebApplication1.Models
{
    public class Service
    {
       
        public async void SendEmailDefault()
        {
            try
            {
               
                MailMessage message = new MailMessage();
             
                message.IsBodyHtml = true; 
                message.From = new MailAddress("georgijblinov3@outlook.com", "Моя компания"); 
                message.To.Add("georgijblinov096@gmail.com"); //адресат сообщения
                message.Subject = "Сообщение от System.Net.Mail"; //тема сообщения
                message.Body = "<div style=\"color: red;\">Сообщение от System.Net.Mail</div>";
                //message.Attachments.Add(new Attachment("... путь к файлу ...")); 

                var client = new SmtpClient("smtp.mailtrap.io", 2525)
                {
                    Credentials = new NetworkCredential("16285c1bbabdd1", "f9122b3e2925fd"),
                    EnableSsl = true
                };
                client.Send(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
              
            }
        }

       //Car2131312
    }
}
