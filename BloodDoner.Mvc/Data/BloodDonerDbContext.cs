using BloodDoner.Mvc.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BloodDoner.Mvc.Data
{
    public class BloodDonerDbContext : IdentityDbContext<IdentityUser>
    {
        private readonly UserManager<IdentityUser> _userManager;
        public BloodDonerDbContext(DbContextOptions<BloodDonerDbContext> options) : base(options) 
        {
        
        }
        public DbSet<BloodDonerEntity> BloodDoners { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<CampaignEntity> Campaigns { get; set; }
        public DbSet<DonerCampaignEntity> DonerCampaigns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DonerCampaignEntity>()
                .HasKey(dc => new { dc.BloodDonerId, dc.CampaignId });
            
            modelBuilder.Entity<DonerCampaignEntity>()
                .HasOne(dc => dc.BloodDoner)
                .WithMany(bd => bd.DonerCampaigns)
                .HasForeignKey(dc => dc.BloodDonerId);

            modelBuilder.Entity<DonerCampaignEntity>()
                .HasOne(dc => dc.Campaign)
                .WithMany(c => c.DonerCampaigns)
                .HasForeignKey(dc => dc.CampaignId);

            //modelBuilder.Entity<Donation>()
            //    .HasOne(d => d.BloodDoner)
            //    .WithMany(bd => bd.Donations)
            //    .HasForeignKey(d => d.BloodDonerId)
            //    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BloodDonerEntity>()
                .HasData(new BloodDonerEntity
                {
                    Id = 1,
                    FullName = "Sanjida Afrin",
                    ContactNumber = "957579758975",
                    DateofBirth = new DateTime(1990, 5, 10),
                    Email = "saima@gmail.com",
                    BloodGroup = BloodGroup.BPositive,
                    Weight = 60,
                    Address = "Chittagong",
                    LastDonationDate = new DateTime(2024, 11, 10),
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

                });
            //modelBuilder.Entity<IdentityRole>()
            //    .HasData(new IdentityRole
            //    {
            //        Id = "1",
            //        Name = "Admin",
            //        NormalizedName = "ADMIN"
            //    },

            //    new IdentityRole
            //    {
            //        Id = "2",
            //        Name = "Donor",
            //        NormalizedName = "Donor"
            //    });
          
        }
    }
}
