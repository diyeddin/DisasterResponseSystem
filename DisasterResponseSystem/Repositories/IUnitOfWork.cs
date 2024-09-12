namespace DisasterResponseSystem.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IDonorRepository Donors { get; }
        IDonationRepository Donations { get; }
        IPersonInNeedRepository PeopleInNeed { get; }
        IRequestRepository Requests { get; }
        int Complete();
    }
}
