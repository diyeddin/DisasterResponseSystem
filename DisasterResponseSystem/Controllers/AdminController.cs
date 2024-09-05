using DisasterResponseSystem.Data;
using DisasterResponseSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DisasterResponseSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var objectRequestList = _context.Requests.Include(r => r.PersonInNeed).ToList();

            IEnumerable<PersonInNeedRequestViewModel> objPersonInNeedRequestViewModels = objectRequestList.Select(r => new PersonInNeedRequestViewModel
            {
                PersonID = r.PersonInNeed.PersonInNeedID,
                RecipientName = r.PersonInNeed.Name,
                RecipientEmail = r.PersonInNeed.Email,
                RecipientPhone = r.PersonInNeed.Phone,
                RecipientAddress = r.PersonInNeed.Address,
                RequestAmount = r.RequestedAmount,
                RequestDescription = r.Description,
                Status = r.Status,
                RequestDate = r.RequestDate
            });

            return View(objPersonInNeedRequestViewModels);
        }

        // GET: Requests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personInNeed = await _context.PeopleInNeed
                .Include(r => r.Requests)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.PersonInNeedID == id);

            if (personInNeed == null)
            {
                return NotFound();
            }
            
            return View(personInNeed);
        }
    }
}
