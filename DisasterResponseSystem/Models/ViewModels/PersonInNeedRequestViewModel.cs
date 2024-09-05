using System.ComponentModel.DataAnnotations;

namespace DisasterResponseSystem.Models.ViewModels
{
	public class PersonInNeedRequestViewModel
	{
		// PersonInNeed properties
		[Required]
		[Display(Name = "Name")]
		public string RecipientName { get; set; }
		[Required]
		[EmailAddress]
		[Display(Name = "Email")]
		public string RecipientEmail { get; set; }
		[Required]
		[Phone]
		[Display(Name = "Phone")]
		public string RecipientPhone { get; set; }
		[Required]
		[Display(Name = "Address")]
		public string RecipientAddress { get; set; }

		// Request properties
		[Required]
		[Display(Name = "Requested Amount")]
		public int RequestAmount { get; set; }
		[Required]
		[Display(Name = "Case Description")]
		public string RequestDescription { get; set; }
		public string Status { get; set; } = "Pending";
		//[DataType(DataType.Date)]
		//public DateTime? RequestDate { get; set; };
	}
}
