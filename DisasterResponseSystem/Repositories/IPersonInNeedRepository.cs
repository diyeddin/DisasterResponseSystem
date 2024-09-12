using DisasterResponseSystem.Models;

namespace DisasterResponseSystem.Repositories
{
    public interface IPersonInNeedRepository : IRepository<PersonInNeed>
    {
        PersonInNeed GetPersonInNeedWithRequest(int? id);
    }
}
