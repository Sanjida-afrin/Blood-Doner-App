using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDoner.Mvc.Models.Entities
{
    public class Donation : BaseEntity
    {
        public required DateTime DonationDate { get; set; }

        [ForeignKey("BloodDoner")]
        public required int BloodDonerId { get; set; }
        public BloodDonerEntity BloodDoner { get; set; } = null!;

        [ForeignKey("Campaign")]
        public int? CampaignId { get; set; }
        public CampaignEntity? Campaign { get; set; }

        public string? Location { get; set; }
    }
}
