using DisasterResponseSystem.Data;
using DisasterResponseSystem.Models;
using DisasterResponseSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DisasterResponseSystem.Controllers
{
    public class RequestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RequestController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonInNeedRequestViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var personInNeed = new PersonInNeed
                {
                    Name = obj.RecipientName,
                    Email = obj.RecipientEmail,
                    Phone = obj.RecipientPhone,
                    Address = obj.RecipientAddress
                };

                var request = new Request
                {
                    RequestedAmount = obj.RequestAmount,
                    Description = obj.RequestDescription,
                    Status = obj.Status,
                    PersonInNeed = personInNeed
                };

                _context.PeopleInNeed.Add(personInNeed);
                _context.Requests.Add(request);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }
    }
}
