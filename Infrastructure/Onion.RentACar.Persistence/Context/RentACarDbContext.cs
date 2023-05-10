using Microsoft.EntityFrameworkCore;
using Onion.RentACar.Domain.Entities;

namespace Onion.RentACar.Persistence.Context
{
    public class RentACarDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RentACarDb;Trusted_Connection=true");
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<RentList> RentList { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Status> Status { get; set; }
    }
}
