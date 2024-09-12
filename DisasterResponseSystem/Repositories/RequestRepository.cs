using DisasterResponseSystem.Data;
using DisasterResponseSystem.Models;

namespace DisasterResponseSystem.Repositories
{
    public class RequestRepository : Repository<Request>, IRequestRepository
    {
        public RequestRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
