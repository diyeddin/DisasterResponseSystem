using DisasterResponseSystem.Models;

namespace DisasterResponseSystem.Repositories
{
    public interface IRequestRepository : IRepository<Request>
    {
        IEnumerable<Request> GetRequestsWithPeopleInNeed();
    }
}
