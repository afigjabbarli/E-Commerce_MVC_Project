using E_Commerce_Platform.DataBase.Models;
using E_Commerce_Platform.DTOs;

namespace E_Commerce_Platform.Services.Abstracts
{
    public interface IEmailService
    {
        void SendActivationURL(User user, string token);
        void SendEmail(EmailDTO DTO);
    }
}
