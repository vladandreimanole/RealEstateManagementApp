﻿using EmailSender;
using System.Net;
using System.Net.Mail;

namespace RealEstateManagementApp.Jobs;

public class Worker : IWorker
{
    private readonly ILogger<Worker> _logger;
    private readonly IDataService _dataService;
    private readonly IEmailSender _emailSender;
    public Worker(ILogger<Worker> logger, IDataService dataService, IEmailSender emailSender)
    {
        _logger = logger;
        _dataService = dataService;
        _emailSender = emailSender;
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
                    var signeCcontracts = await _dataService.GetContractsForVerify();
                    foreach (var contract in signeCcontracts)
                    {

                        List<Attachment> attachments = new List<Attachment>();
                        foreach (var bill in contract.Bills)
                        {
                            var pdfBytes = Convert.FromBase64String(bill?.BillPdf);
                            var stream = new MemoryStream(pdfBytes);
                            attachments.Add(new Attachment(stream, "Bill"));
                        }
                        await _emailSender.SendEmailTo(contract?.Tenant?.Email, "Reminder","Body", attachments);


                    }

                    await Task.Delay(7200000);
                }
                else
                {
                    //do it configurable please 
                    await Task.Delay(3000);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occured while trying to verify bills");
            }
        }
    }
}

