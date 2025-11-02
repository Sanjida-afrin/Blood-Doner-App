namespace BloodDoner.Mvc.Models.ViewModel
{
    public class CampaignListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; } = string.Empty;
        public int DonerCount { get; set; }
    }
}
