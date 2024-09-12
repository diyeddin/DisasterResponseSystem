using DisasterResponseSystem.Data;
using DisasterResponseSystem.Models;

namespace DisasterResponseSystem.Repositories
{
    public class PersonInNeedRepository : Repository<PersonInNeed>, IPersonInNeedRepository
    {
        public PersonInNeedRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
