using DisasterResponseSystem.Models;
using DisasterResponseSystem.Models.ViewModels;
using DisasterResponseSystem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DisasterResponseSystem.Controllers
{
    public class RequestController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RequestController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
        public IActionResult Create(PersonInNeedRequestViewModel obj)
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

                _unitOfWork.PeopleInNeed.Add(personInNeed);
                _unitOfWork.Requests.Add(request);

                _unitOfWork.Complete();

                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }
    }
}
