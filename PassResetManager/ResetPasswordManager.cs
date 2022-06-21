﻿
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

            isCorect = user.PassResetToken == token ? true : false;

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Exception occured while verifying reset token for user {email}");
            return false;
        }

        return isCorect;
    }

    public async Task SendResetPasswordForUser(string email)
    {
        try
        {
            try
            {
                var user = await _dataService.GetUserByEmail(email);
                if (user == null)
                {
                    var message = $"No user found for email {email}";
                    _logger.LogError(message);
                    throw new Exception(message);
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
    }

    public async Task SendEmailTo(string email)
    {
        var from = new MailAddress("jo7n2xhdsn45jsruasdasdethereal.email");
        var to = new MailAddress(email);
        var subject = _optionsMonitor.CurrentValue.Subject;
        var body = _optionsMonitor.CurrentValue.Body;

        //never to this, never;
        var username = "asdasdasd";
        var password = "asdasd";
        var host = "smtp.ethereal.email";
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
