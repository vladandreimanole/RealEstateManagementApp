
using System.Net.Mail;

namespace EmailSender;

    public interface IEmailSender
    {
    Task SendEmailTo(string email, string Subject, string Body, List<Attachment> attachments = null);
    }

