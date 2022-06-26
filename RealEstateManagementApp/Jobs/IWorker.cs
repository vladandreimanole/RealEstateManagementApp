namespace RealEstateManagementApp.Jobs;

    public interface IWorker
    {
        Task DoWork(CancellationToken cancelToken);
    }

