using Models.Client.Data;

namespace Models.Client.Repositories
{
    public interface IAuthRepository
    {
        User Login(string email, string password);
        void Register(User user);
    }
}
