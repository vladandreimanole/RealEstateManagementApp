
namespace RealEstateManagementApp.Jobs;

    public class RentReminderJob : IHostedService
    {
        private ILogger<RentReminderJob> _logger;
        private IWorker _worker;

        public RentReminderJob(ILogger<RentReminderJob> logger, IWorker worker)
        {
            _logger = logger;
            _worker = worker;
        }

        public async Task StartAsync(CancellationToken cancelToken)
        {
            _ = _worker.DoWork(cancelToken);
        }

        public Task StopAsync(CancellationToken cancelToken)
        {
            _logger.LogWarning("RentReminderJob is stopping....");
            return Task.CompletedTask;
        }

    }

