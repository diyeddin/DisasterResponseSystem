using DisasterResponseSystem.Data;
using DisasterResponseSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace DisasterResponseSystem.Repositories
{
    public class DonationRepository : Repository<Donation>, IDonationRepository
    {
        public DonationRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Donation> GetDonationsWithDonors()
        {
            return _context.Donations
                .Include(d => d.Donor)
                .OrderByDescending(d => d.DateRecieved)
                .ToList();
        }
    }
}
