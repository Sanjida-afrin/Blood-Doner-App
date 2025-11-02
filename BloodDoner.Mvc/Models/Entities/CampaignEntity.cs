using System.Collections.ObjectModel;

namespace BloodDoner.Mvc.Models.Entities
{
    public class CampaignEntity: BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; } = string.Empty;
        public Collection<DonerCampaignEntity> DonerCampaigns { get; set; } = new Collection<DonerCampaignEntity>();


    }
}
