using System.ComponentModel.DataAnnotations;

namespace DisasterResponseSystem.Models.ViewModels
{
	public class DonationDonorViewModel
	{
		// donor info
		[Required]
		[Display(Name = "Name")]
		public string DonorName { get; set; }
		[Required]
		[EmailAddress]
		[Display(Name = "Email")]
		public string DonorEmail { get; set; }
		[Required]
		[Phone]
		[Display(Name = "Phone")]
		public string DonorPhone { get; set; }
		[Required]
		[Display(Name = "Address")]
		public string DonorAddress { get; set; }

		// donation
		[Required]
		[Display(Name = "Donation Amount")]
		public int DonationAmount { get; set; }
		[Display(Name = "Message")]
        public string DonationMessage { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DonationDate { get; set; } 
    }
}