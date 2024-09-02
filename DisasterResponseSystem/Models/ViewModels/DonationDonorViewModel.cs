using System.ComponentModel.DataAnnotations;

namespace DisasterResponseSystem.Models.ViewModels
{
	public class DonationDonorViewModel
	{
		// donation
		[Required]
		public int DonationAmount { get; set; }

		// donor info
		[Required]
		public string DonorName { get; set; }
		[Required]
		[EmailAddress]
		public string DonorEmail { get; set; }
		public string DonorMessage { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DonationDate { get; set; }
    }
}
