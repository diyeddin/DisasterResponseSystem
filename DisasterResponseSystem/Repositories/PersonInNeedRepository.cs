using DisasterResponseSystem.Data;
using DisasterResponseSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace DisasterResponseSystem.Repositories
{
    public class PersonInNeedRepository : Repository<PersonInNeed>, IPersonInNeedRepository
    {
        public PersonInNeedRepository(ApplicationDbContext context) : base(context)
        {
        }

        public PersonInNeed GetPersonInNeedWithRequest(int? id)
        {
            return _context.PeopleInNeed
                .Include(p => p.Requests)
                .AsNoTracking()
                .FirstOrDefault(p => p.PersonInNeedID == id);
        }
    }
}
