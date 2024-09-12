using DisasterResponseSystem.Models;
using DisasterResponseSystem.Models.ViewModels;
using DisasterResponseSystem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DisasterResponseSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Request> objectRequestList = _unitOfWork.Requests.GetRequestsWithPeopleInNeed();

            IEnumerable <PersonInNeedRequestViewModel> objPersonInNeedRequestViewModels = objectRequestList.Select(r => new PersonInNeedRequestViewModel
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
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PersonInNeed personInNeed = _unitOfWork.PeopleInNeed.GetPersonInNeedWithRequest(id);

            if (personInNeed == null)
            {
                return NotFound();
            }
            
            return View(personInNeed);
        }

        [HttpGet]
        public IActionResult Allocate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = _unitOfWork.Requests.Get(id);

            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        [HttpPost, ActionName("Allocate")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmAllocate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = _unitOfWork.Requests.Get(id);

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
                _unitOfWork.Complete();
            }

            return RedirectToAction(nameof(Index));
        }

        private int getAvailableFunds()
        {
            var availableFunds = _unitOfWork.Donations.Sum(d => d.Amount) - _unitOfWork.Requests.Sum(r => r.AllocatedAmount);

            return availableFunds;
        }
    }
}
