
using DataManager.Services;
using Microsoft.Extensions.Logging;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Options;
using EmailSender;

namespace PassResetManager;

public class ResetPasswordManager : IResetPasswordManager
{
    private readonly ILogger<ResetPasswordManager> _logger;

    private readonly IDataService _dataService;
    private readonly IOptionsMonitor<EmailOptionsMonitor> _optionsMonitor;
    private readonly IEmailSender _emailSender;


    public ResetPasswordManager(ILogger<ResetPasswordManager> logger, IDataService dataService, IOptionsMonitor<EmailOptionsMonitor> optionsMonitor, IEmailSender emailSender)
    {
        _logger = logger;
        _dataService = dataService;
        _optionsMonitor = optionsMonitor;
        _emailSender = emailSender;
    }

    public async Task<bool> VerifyResetTokenForUser(string email, string token)
    {
        bool isCorect = false;
        try
        {
            var user = await _dataService.GetUserByEmail(email);

            if(user is null)
            {
                _logger.LogError($"No used identified for {email}");
                return false;
            }

            isCorect = user.PassResetToken == token ? true : false;

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Exception occured while verifying reset token for user {email}");
            return false;
        }

        return isCorect;
    }

    public async Task<bool> SendResetPasswordForUser(string email)
    {
        bool send = false;
        try
        {
            try
            {
                var user = await _dataService.GetUserByEmail(email);
                if (user == null)
                {
                    var message = $"No user found for email {email}";
                    _logger.LogError(message);
                    return send;
                }

                user.PassResetToken = Guid.NewGuid().ToString();

                var updatedUser = await _dataService.UpdateUserAccount(user);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to generate password reset token for email {email}");
            }

            try
            {
                await _emailSender.SendEmailTo(email, _optionsMonitor.CurrentValue.Subject, _optionsMonitor.CurrentValue.Body);
                send = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occured while trying to send reset email");

            }

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to reset password");

        }

        return send;
    }
}

