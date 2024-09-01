using System.ComponentModel.DataAnnotations;

namespace DisasterResponseSystem.Models
{
    public class Donor
    {
        [Key]
        public int DonorID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }

        public ICollection<Donation> Donations { get; set; }
    }
}
