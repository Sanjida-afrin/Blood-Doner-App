using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BloodDoner.Mvc.Models.ViewModel
{
    public class DonationCreateViewModel
    {
        [Required]
        public int BloodDonerId { get; set; }
        public int? CampaignId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DonationDate { get; set; }
        public string? Location { get; set; }
        public IEnumerable<SelectListItem> Doners { get; set; }= Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> Campaigns { get; set; } = Enumerable.Empty<SelectListItem>();

        public Dictionary<string, string> CampaignLocations { get; set; } = new Dictionary<string, string>();

    }
}
