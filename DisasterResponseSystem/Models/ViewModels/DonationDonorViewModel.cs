using System.ComponentModel.DataAnnotations;

namespace DisasterResponseSystem.Models.ViewModels
{
	public class DonationDonorViewModel
	{
		// donation
		[Required]
		public int DonationAmount { get; set; }
        public string DonationMessage { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DonationDate { get; set; }

        // donor info
        [Required]
		public string DonorName { get; set; }
		[Required]
		[EmailAddress]
		public string DonorEmail { get; set; }
        [Required]
        [Phone]
        public string DonorPhone { get; set; }
        [Required]
        public string DonorAddress { get; set; }
        
    }
}
