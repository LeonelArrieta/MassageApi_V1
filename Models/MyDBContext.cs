using Microsoft.EntityFrameworkCore;

namespace MassageApi_V1.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shift>().ToTable("Shift");
            modelBuilder.Entity<MassageType>().ToTable("MassageType");
            modelBuilder.Entity<Contact>().ToTable("Contact");
            modelBuilder.Entity<User>().ToTable("User");
        }

        public DbSet<Shift> Shifts { get; set; }
        public DbSet<MassageType> MassageTypes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
