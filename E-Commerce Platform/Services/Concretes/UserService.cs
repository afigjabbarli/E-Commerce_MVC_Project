using E_Commerce_Platform.DataBase;
using E_Commerce_Platform.DataBase.Models;
using E_Commerce_Platform.Services.Abstracts;

namespace E_Commerce_Platform.Services.Concretes
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ECommerceDBContext _eCommerceDBContext;
        private User _currentUser;
        public UserService(IHttpContextAccessor httpContextAccessor, ECommerceDBContext eCommerceDBContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _eCommerceDBContext = eCommerceDBContext;
        }

        public bool IsCurrentUserAuthenticated()
        {
            return _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public User CurrentUser
        {
            get
            {

                if (_currentUser != null)
                {
                    return _currentUser;
                }

                if (_httpContextAccessor.HttpContext.User == null)
                {
                    throw new Exception("User is not authenticated");
                }

                var userIdClaim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id");
                if (userIdClaim is null)
                {
                    throw new Exception("User is not authenticated");
                }

                var userId = Convert.ToInt32(userIdClaim.Value);
                var user = _eCommerceDBContext.Users.SingleOrDefault(u => u.Id == userId);
                if (user is null)
                {
                    throw new Exception("User not found in system");
                }

                _currentUser = user;

                return _currentUser;
            }
        }
    }
}
