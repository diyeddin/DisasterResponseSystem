using DisasterResponseSystem.Data;
using DisasterResponseSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace DisasterResponseSystem.Repositories
{
    public class RequestRepository : Repository<Request>, IRequestRepository
    {
        public RequestRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Request> GetRequestsWithPeopleInNeed()
        {
            return _context.Requests
                .Include(r => r.PersonInNeed)
                .ToList();
        }
    }
}
