using DisasterResponseSystem.Data;
using DisasterResponseSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

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

            //dynamic mymodel = new ExpandoObject();
            //mymodel.PersonInNeedRequestViewModels = objPersonInNeedRequestViewModels;
            //mymodel.AvailableFunds = getAvailableFunds();

            ViewData["AvailableFunds"] = getAvailableFunds();

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

        [HttpGet]
        public async Task<IActionResult> Allocate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        [HttpPost, ActionName("Allocate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmAllocate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            if (request.RequestedAmount > getAvailableFunds())
            {
                return RedirectToAction(nameof(Index));
            }
            else if (request.Status != "Allocated" && request.RequestedAmount <= getAvailableFunds())
            {
                request.Status = "Allocated";
                request.AllocatedAmount = request.RequestedAmount;
                _context.Update(request);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private int getAvailableFunds()
        {
            var availableFunds = _context.Donations.Sum(d => d.Amount) - _context.Requests.Sum(r => r.AllocatedAmount);

            return availableFunds;
        }
    }
}
