
namespace PassResetManager
{
    public interface IResetPasswordManager
    {
        Task<bool> SendResetPasswordForUser(string email);

        Task<bool> VerifyResetTokenForUser(string email, string token);
    }
}