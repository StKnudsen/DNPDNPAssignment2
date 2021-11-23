using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace DataAccess.Data
{
    public class ViaDbContext : DbContext
    {
        public DbSet<Adult> Adults { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                "Data Source =C:/Users/LineK/RiderProjects/DNPDNPAssignment2/DataAccess/Families.db");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           /* modelBuilder.Entity<Adult>()
                .HasOne(a => a.Family)
                .WithMany(f => f.Adults);
            modelBuilder.Entity<Adult>()
                .HasOne(a => a.Job);*/
        }
        
    }
}