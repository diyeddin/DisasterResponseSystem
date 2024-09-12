using DisasterResponseSystem.Data;

namespace DisasterResponseSystem.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Donors = new DonorRepository(_context);
            Donations = new DonationRepository(_context);
            PeopleInNeed = new PersonInNeedRepository(_context);
            Requests = new RequestRepository(_context);
        }

        public IDonorRepository Donors { get; private set; }
        public IDonationRepository Donations { get; private set; }
        public IPersonInNeedRepository PeopleInNeed { get; private set; }
        public IRequestRepository Requests { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
