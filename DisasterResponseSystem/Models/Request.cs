using System.ComponentModel.DataAnnotations;

namespace DisasterResponseSystem.Models
{
    public class Request
    {
        [Key]
        public int RequestID { get; set; }
        [Required]
        public int RequestedAmount { get; set; }
        public int AllocatedAmount { get; set; } = 0;
        [Required]
        public string Description { get; set; }
        public string Status { get; set; } = "Pending";
        [DataType(DataType.Date)]
        public DateTime RequestDate { get; set; } = DateTime.Now;

        public int? PersonInNeedID { get; set; }
        public PersonInNeed PersonInNeed { get; set; }
    }
}