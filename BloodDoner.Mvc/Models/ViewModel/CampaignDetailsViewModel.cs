namespace BloodDoner.Mvc.Models.ViewModel
{
    public class CampaignDetailsViewModel
    {
       
            public int Id { get; set; }
            public string Title { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string Location { get; set; } = string.Empty;
            public List<BloodDonerInCampaignViewModel> Doners { get; set; } = new List<BloodDonerInCampaignViewModel>();
        }

        public class BloodDonerInCampaignViewModel
        {
            public int Id { get; set; }
            public string FullName { get; set; } = string.Empty;
            public string ContactNumber { get; set; } = string.Empty;
            public int Age { get; set; }
            public string Email { get; set; } = string.Empty;
            public string BloodGroup { get; set; } = string.Empty;
            public string? Address { get; set; }
            public string LastDonationDate { get; set; } = string.Empty;
            public string? ProfilePicture { get; set; }
            public int DonerCount { get; set; }
        }
    }

