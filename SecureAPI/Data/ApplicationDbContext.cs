using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecureAPI.DTO;
using SecureAPI.Models;

namespace SecureAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SPReportes>().HasNoKey().ToSqlQuery("SPReportes");
            base.OnModelCreating(modelBuilder); 
        }

        public DbSet<Entry> Entries { get; set; }
        public DbSet<SPReportes> SPReportes { get; set; }
    }
}
