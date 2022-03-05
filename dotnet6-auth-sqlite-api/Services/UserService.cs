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
            var user = _appDbContext.Users.FirstOrDefault(user =>
                user.Username.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase) && user.Password.Equals(userLogin.Password)
               );
            _appDbContext.SaveChangesAsync();
            return user;
        }

        public User Update(User user)
        {
            var newUser = _appDbContext.Users.FirstOrDefault(newUser => newUser.Id == user.Id);
            if (newUser == null) return null;
            _appDbContext.Users.Update(newUser);
            _appDbContext.SaveChangesAsync();
            return newUser;
        }
    }
}
