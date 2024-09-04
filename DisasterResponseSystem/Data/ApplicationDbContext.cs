using DisasterResponseSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace DisasterResponseSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Donation> Donations{ get; set; }
		public DbSet<Donor> Donors { get; set; }
	}
}
