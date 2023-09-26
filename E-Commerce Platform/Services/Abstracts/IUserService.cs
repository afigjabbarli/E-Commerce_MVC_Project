using E_Commerce_Platform.DataBase.Models;

namespace E_Commerce_Platform.Services.Abstracts
{
    public interface IUserService
    {
        bool IsCurrentUserAuthenticated();
        public User CurrentUser { get; }
    }
}
