using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace RealEstateManagementApp.Helpers
{
    public class PasswordHasher : IPasswordHasher<User>
    {

        private readonly IOptionsMonitor<PasswordOptionsMonitor> _optionsMonitor;
        public PasswordHasher(IOptionsMonitor<PasswordOptionsMonitor> optionsMonitor)
        {
            _optionsMonitor = optionsMonitor;
        }

        public string HashPassword(User user, string password)
        {
            return PasswordHelper.HashPassword(password, _optionsMonitor.CurrentValue.PasswordSalt);
        }

        public PasswordVerificationResult VerifyHashedPassword(User user, string hashedPassword, string providedPassword)
        {
            return hashedPassword != HashPassword(user, providedPassword) ? PasswordVerificationResult.Failed : PasswordVerificationResult.Success;
        }
    }
}