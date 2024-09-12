namespace DisasterResponseSystem.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IDonorRepository Donors { get; }
        IDonationRepository Donations { get; }
        int Complete();
    }
}
