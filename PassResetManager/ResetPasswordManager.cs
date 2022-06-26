
using DataManager.Services;
using Microsoft.Extensions.Logging;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Options;

namespace PassResetManager;

public class ResetPasswordManager : IResetPasswordManager
{
    private readonly ILogger<ResetPasswordManager> _logger;

    private readonly IDataService _dataService;
    private readonly IOptionsMonitor<EmailOptionsMonitor> _optionsMonitor;


    public ResetPasswordManager(ILogger<ResetPasswordManager> logger, IDataService dataService, IOptionsMonitor<EmailOptionsMonitor> optionsMonitor)
    {
        _logger = logger;
        _dataService = dataService;
        _optionsMonitor = optionsMonitor;
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
                await SendEmailTo(email);
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

    public async Task SendEmailTo(string email)
    {
        var from = new MailAddress("realestateapp@vladm.ro");
        var to = new MailAddress(email);
        var subject = _optionsMonitor.CurrentValue.Subject;
        var body = _optionsMonitor.CurrentValue.Body;

        //never to this, never;
        var username = "postmaster@sandboxe55a00e3715447e28865a5f436b2f764.mailgun.org";
        var password = "f4dc95d989341ac97bd814b56ef47c92-4f207195-a76429d6";
        var host = "smtp.mailgun.org";
        var port = 587;

        var client = new SmtpClient(host, port);
        client.Credentials = new NetworkCredential(username, password);
        client.EnableSsl = true;
        var mail = new MailMessage();
        mail.Subject = subject;
        mail.From = from;
        mail.To.Add(to);
        mail.Body = body;
        mail.IsBodyHtml = true;

        await client.SendMailAsync(mail);
    }

}

