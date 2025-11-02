namespace BloodDoner.Mvc.Models.Entities
{
    public class DonerCampaignEntity 
    {
        public int BloodDonerId { get; set; }
        public BloodDonerEntity BloodDoner { get; set; } = null!;
        public int CampaignId { get; set; }
        public CampaignEntity Campaign { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
