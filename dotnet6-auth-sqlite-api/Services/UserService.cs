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
            user.Password = EncryptionService.GetSHA256(user.Password);
            _appDbContext.Users.Add(user);
            return user;
        }

        public bool Delete(int userId)
        {
            var user = _appDbContext.Users.FirstOrDefault(user => user.Id == userId);
            if (user == null) return false;
            _appDbContext.Users.Remove(user);
            _appDbContext.SaveChangesAsync();
            return true;
        }

        public User Get(UserLogin userLogin)
        {
            var user = _appDbContext.Users.FirstOrDefault(user =>
                user.Username.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase) && 
                user.Password.Equals(EncryptionService.GetSHA256(userLogin.Password))
               );
            _appDbContext.SaveChangesAsync();
            return user;
        }

        public User Update(User user)
        {
            var newUser = _appDbContext.Users.FirstOrDefault(newUser => newUser.Id == user.Id);
            if (newUser == null) return null;
            newUser.Password = EncryptionService.GetSHA256(newUser.Password);
            _appDbContext.Users.Update(newUser);
            _appDbContext.SaveChangesAsync();
            return newUser;
        }
    }
}
