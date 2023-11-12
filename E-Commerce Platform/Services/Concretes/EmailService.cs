using E_Commerce_Platform.DataBase.Models;
using E_Commerce_Platform.DTOs;
using E_Commerce_Platform.Services.Abstracts;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace E_Commerce_Platform.Services.Concretes
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly string _from;
        private readonly string _password;
        private readonly int _port;
        private readonly string _host;
        private readonly string _username;
        private readonly string _server;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
            _from = _configuration.GetValue<string>("MailSettings:EmailAdress");
            _password = _configuration.GetValue<string>("MailSettings:Password");
            _port = _configuration.GetValue<int>("MailSettings:Port");
            _host = _configuration.GetValue<string>("MailSettings:Host");
            _username = _configuration.GetValue<string>("MailSettings:Username");
            _server = _configuration.GetValue<string>("MailSettings:Server");
        }
        public void SendActivationURL(User user, string token)
        {
            var activationUrl = $"{_server}Auth/Verify?ID={user.Id}&token={token}";
            var messageDto = new EmailDTO()
            {

                Subject = "Account activation URL - Electro ECommerce Online Shopping",
                Recipients = new List<string>()
                {
                    user.Email
                },
                Body = $@"Hello dear {user.Surname} {user.Name},<br><br>
                You can activate your account by clicking the button below:<br><br>
                <a href=""{activationUrl}"" style=""display: inline-block; padding: 15px 30px; border-radius: 10px; background-color: #4CAF50; color: white; text-align: center; text-decoration: none; font-size: 18px; margin: 4px 2px; cursor: pointer;"">Activate Account</a>"

            };
            SendEmail(messageDto);

        }

        public void SendEmail(EmailDTO DTO)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_from));
            foreach (var recipient in DTO.Recipients)
            {
                email.To.Add(MailboxAddress.Parse(recipient));
            }
            email.Subject = DTO.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = DTO.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(_host, _port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_from, _password);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}

