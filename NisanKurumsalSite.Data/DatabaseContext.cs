using Microsoft.EntityFrameworkCore;
using NisanKurumsalSite.Entities;

namespace NisanKurumsalSite.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; database=NisanKurumsalSite; integrated security=true; TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // bu metot veritabanı oluştuktan sonra tablolara başlangıç kaydı atmamızı sağlar.
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Admin",
                    Surname = "User",
                    Email = "admin@user.nisan",
                    IsActive = true,
                    IsAdmin = true,
                    Password = "123456"
                }
                );
            base.OnModelCreating(modelBuilder);
        }

    }
}
