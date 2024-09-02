using System.ComponentModel.DataAnnotations;

namespace DisasterResponseSystem.Models
{
    public class Donation
    {
        [Key]
        public int DonationID { get; set; }
        [Required]
        //[DataType(DataType.Currency)]
        public int Amount { get; set; }

        public int? DonorID { get; set; }
        public Donor Donor { get; set; }
        public bool IsAllocated { get; set; } = false;

        [DataType(DataType.Date)]
        public DateTime DateRecieved { get; set; } = DateTime.Now;
    }
}
