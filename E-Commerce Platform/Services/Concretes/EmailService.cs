using E_Commerce_Platform.Services.Abstracts;
using System.Net;
using System.Net.Mail;

namespace E_Commerce_Platform.Services.Concretes
{
    public class EmailService : IEmailService
    {
       

        public async Task SendMessageAsync(string Recipient, string From, string Subject, string Body, string DisplayName, string Password, bool IsHtml)
        {
            await SendMessageAsync(new[] { Recipient }, From, Subject, Body, DisplayName, Password, IsHtml);
        }
        public async Task SendMessageAsync(string[] Recipients, string From, string Subject, string Body, string DisplayName, string Password, bool IsHtml)
        {
            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = IsHtml;
            mail.From = new MailAddress(From, DisplayName, System.Text.Encoding.UTF8);
            mail.Subject = Subject;
            mail.Body = Body;
            foreach (var Recipient in Recipients)
            {
                mail.To.Add(Recipient);
            }
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential(From, Password);
           
            smtp.Port = 587;
            smtp.EnableSsl = true;
            
            smtp.Host = "smtp.yandex.ru";
            await smtp.SendMailAsync(mail);
        }

        
    }
}
            
