using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDoner.Mvc.Models.Entities
{
    public class BloodDonerEntity : BaseEntity
    {
        public required string FullName { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 10)]
        public required string ContactNumber { get; set; }

        public required DateTime DateofBirth { get; set; }

        [EmailAddress]
        public required string Email { get; set; }
        public required BloodGroup BloodGroup { get; set; }

        [Range(50, 150)]
        [Display(Name = "Weight(kg")]
        public float Weight { get; set; }
        public string? Address { get; set; }
        public DateTime? LastDonationDate { get; set; }
        public string? ProfilePicture { get; set; }
        public Collection<Donation> Donations { get; set; } = new Collection<Donation>();
        public Collection<DonerCampaignEntity> DonerCampaigns { get; set; } = new Collection<DonerCampaignEntity>();

    }


}
