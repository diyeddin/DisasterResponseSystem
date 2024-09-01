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
        public DateTime DateRecieved { get; set; } = DateTime.Now;
        public bool IsAllocated { get; set; } = false;

        public int? DonorID { get; set; }
        public Donor Donor { get; set; }
    }
}
