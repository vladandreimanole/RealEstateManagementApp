using System.Net;
using System.Net.Mail;

namespace RealEstateManagementApp.Jobs;

public class Worker : IWorker
{
    private readonly ILogger<Worker> _logger;
    private readonly IDataService _dataService;
    public Worker(ILogger<Worker> logger, IDataService dataService)
    {
        _logger = logger;
        _dataService = dataService;
    }

    public async Task DoWork(CancellationToken cancelToken)
    {
        await Task.Yield();
        while (!cancelToken.IsCancellationRequested)
        {
            try
            {
                if (DateTime.Now.Day == 1 && DateTime.Now.Hour == 12)
                {
                        var users = await _dataService.GetUsers();
                        var contracts = await _dataService.GetContracts();
                        foreach (var contract in contracts)
                        {
                            List<Attachment> attachments = new List<Attachment>();
                            foreach (var bill in contract.Bills)
                            {
                                var pdfBytes = Convert.FromBase64String(bill?.BillPdf);
                                var stream = new MemoryStream(pdfBytes);
                                attachments.Add(new Attachment(stream, "Bill"));
                            }
                            await SendEmailTo(users.Where(i=>i.UserId == contract.Tenant.UserId).Select(x=>x.Email).FirstOrDefault("manole.vlad@yahoo.com"), attachments);
                        }
                    
                    await Task.Delay(7200000);
                }
                else
                {
                    //do it configurable please 
                    await Task.Delay(3000);
                }

            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Exception occured while trying to verify bills");
            }
        }
    }

    public async Task SendEmailTo(string email, List<Attachment> attachments)
    {
        var from = new MailAddress("realestateapp@vladm.ro");
        var to = new MailAddress(email);
        var subject = "Reminder";
        var body = "Factura";

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
        foreach (var attachment in attachments)
        {
            mail.Attachments.Add(attachment);
        }
        await client.SendMailAsync(mail);
    }
}

