using BloodDoner.Mvc.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BloodDoner.Mvc.Data
{
    public class BloodDonerDbContext : DbContext
    {
        public BloodDonerDbContext(DbContextOptions<BloodDonerDbContext> options) : base(options) { 
        }
        public DbSet<BloodDonerEntity> BloodDoners { get; set; }
        public DbSet<Donation> Donations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BloodDonerEntity>()
                .HasData(new BloodDonerEntity
                {
                    Id = 1,
                    FullName = "Sanjida Afrin",
                    ContactNumber = "957579758975",
                    DateofBirth = new DateTime(1990, 5, 10),
                    Email="saima@gmail.com",
                    BloodGroup = BloodGroup.BPositive,
                    Weight=60,
                    Address= "Chittagong",
                    LastDonationDate= new DateTime(2024,11, 10),
                    ProfilePicture = "profiles/Screenshot (178).png",

                },
                new BloodDonerEntity
                {
                    Id = 2,
                    FullName = "Saima khan",
                    ContactNumber = "123747428778",
                    DateofBirth = new DateTime(2005, 5, 10),
                    Email = "saima@gmail.com",
                    BloodGroup = BloodGroup.APositive,
                    Weight = 90,
                    Address = "Dhaka",
                    LastDonationDate = new DateTime(2025, 11, 10),
                    ProfilePicture = "profiles/Screenshot (178).png",

                }
                );

        }

    }
}
