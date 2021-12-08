using Microsoft.EntityFrameworkCore;
using Equipment_Rental_Application.Models;

namespace Equipment_Rental_Application.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Item> Items{ get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<History> History { get; set; }

    }
}
