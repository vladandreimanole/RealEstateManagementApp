
using System.Net;
using System.Net.Mail;

namespace EmailSender;

public class EmailSenderClass : IEmailSender
{
    public async Task SendEmailTo(string email, string Subject, string Body, List<Attachment> attachments = null)
    {
        var from = new MailAddress("realestateapp@vladm.ro");
        var to = new MailAddress(email);
        var subject = Subject;
        var body = Body;

        //never to this, never;
        var username = "postmaster@sandboxe55a00e3715447e28865a5f436b2f764.mailgun.org";
        var password = "asfasfasdasd";
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
        if (attachments is not null)
        {
            foreach (var attachment in attachments)
            {
                mail.Attachments.Add(attachment);
            }

        }

        await client.SendMailAsync(mail);
    }
}

