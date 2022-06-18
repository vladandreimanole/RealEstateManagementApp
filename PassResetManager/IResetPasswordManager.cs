
namespace PassResetManager
{
    public interface IResetPasswordManager
    {
        Task SendEmailTo(string email);
        Task SendResetPasswordForUser(string email);
    }
}