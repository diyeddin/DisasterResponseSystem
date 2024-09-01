using DisasterResponseSystem.Data;
using DisasterResponseSystem.Models;
using DisasterResponseSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DisasterResponseSystem.Controllers
{
    public class DonateController : Controller
    {
		private readonly ApplicationDbContext _context;

		public DonateController(ApplicationDbContext context)
		{
			_context = context;
		}

        public IActionResult Index()
        {
            var objDonationList = _context.Donations.Include(d => d.Donor).ToList(); // Eager loading

            IEnumerable<DonationDonorViewModel> objDonationDonorViewModels = objDonationList.Select(d => new DonationDonorViewModel
            {
                DonationAmount = d.Amount,
                DonorName = d.Donor.Name,
                DonorEmail = d.Donor.Email,
                DonorMessage = d.Donor.Message
            });

            return View(objDonationDonorViewModels);
        }

		//GET
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(DonationDonorViewModel obj)
		{
			if (ModelState.IsValid)
			{
				var donor = new Donor
				{
					Name = obj.DonorName,
					Email = obj.DonorEmail,
					Message = obj.DonorMessage
				};

				var donation = new Donation
				{
					Amount = obj.DonationAmount,
					Donor = donor
				};

				_context.Donors.Add(donor);
				_context.Donations.Add(donation);

				await _context.SaveChangesAsync();

				return RedirectToAction(nameof(Index));
			}
			return View(obj);
		}
	}
}
