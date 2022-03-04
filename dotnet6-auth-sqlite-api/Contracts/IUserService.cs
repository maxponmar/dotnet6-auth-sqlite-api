using dotnet6_auth_sqlite_api.Models.Authentication;

namespace dotnet6_auth_sqlite_api.Contracts
{
    public interface IUserService
    {
        public User Get(UserLogin userLogin);
        public User Create(User user);
        public User Update(User user);
        public bool Delete(int userId);
    }
}
