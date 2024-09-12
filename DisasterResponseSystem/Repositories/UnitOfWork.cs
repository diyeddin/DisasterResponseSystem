using DisasterResponseSystem.Data;

namespace DisasterResponseSystem.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Donations = new DonationRepository(_context);
        }
        public IDonorRepository Donors { get; private set; }
        public IDonationRepository Donations { get; private set; }

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
