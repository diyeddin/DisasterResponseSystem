using DisasterResponseSystem.Models;

namespace DisasterResponseSystem.Repositories
{
    public interface IDonationRepository : IRepository<Donation>
    {
        IEnumerable<Donation> GetDonationsWithDonors();
    }
}
