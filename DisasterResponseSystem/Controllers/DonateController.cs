using DisasterResponseSystem.Data;
using DisasterResponseSystem.Models;
using DisasterResponseSystem.Models.ViewModels;
using DisasterResponseSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DisasterResponseSystem.Controllers
{
    public class DonateController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DonateController(IUnitOfWork unitOfWork)
        {
			_unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var objDonationList = _unitOfWork.Donations.GetDonationsWithDonors();

            IEnumerable<DonationDonorViewModel> objDonationDonorViewModels = objDonationList.Select(d => new DonationDonorViewModel
            {
                DonationAmount = d.Amount,
                DonorName = d.Donor.Name,
                DonorEmail = d.Donor.Email,
                DonorPhone = d.Donor.Phone,
                DonorAddress = d.Donor.Address,
                DonationMessage = d.Message,
				DonationDate = d.DateRecieved
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
		public IActionResult Create(DonationDonorViewModel obj)
		{
			if (ModelState.IsValid)
			{
				Donor donor = new Donor
				{
					Name = obj.DonorName,
					Email = obj.DonorEmail,
					Phone = obj.DonorPhone,
					Address = obj.DonorAddress
				};

				Donation donation = new Donation
				{
					Amount = obj.DonationAmount,
					Message = obj.DonationMessage,
					Donor = donor
				};

				_unitOfWork.Donors.Add(donor);
				_unitOfWork.Donations.Add(donation);

				_unitOfWork.Complete();

				return RedirectToAction(nameof(Index));
			}
			return View(obj);
		}
	}
}
