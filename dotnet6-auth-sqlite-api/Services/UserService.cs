using dotnet6_auth_sqlite_api.Contracts;
using dotnet6_auth_sqlite_api.Data;
using dotnet6_auth_sqlite_api.Models.Authentication;

namespace dotnet6_auth_sqlite_api.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _appDbContext;

        public UserService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public User Create(User user)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int userId)
        {
            throw new NotImplementedException();
        }

        public User Get(UserLogin userLogin)
        {
            User user = _appDbContext.Users.FirstOrDefault(user =>
                user.Username.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase) && user.Password.Equals(userLogin.Password)
               );
            return user;
        }

        public User Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
