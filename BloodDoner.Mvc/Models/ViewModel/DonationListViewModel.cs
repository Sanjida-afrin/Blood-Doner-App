namespace BloodDoner.Mvc.Models.ViewModel
{
    public class DonationListViewModel
    {
       
            public int Id { get; set; }
            public DateTime DonationDate { get; set; }
            public required string DonerName { get; set; }
            public string? Campaign { get; set; }
            public string? Location { get; set; }
        }
    }

