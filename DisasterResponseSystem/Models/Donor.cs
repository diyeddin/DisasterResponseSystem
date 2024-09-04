using System.ComponentModel.DataAnnotations;

namespace DisasterResponseSystem.Models
{
    public class Donor
    {
        [Key]
        public int DonorID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }

        public ICollection<Donation> Donations { get; set; }
    }
}
