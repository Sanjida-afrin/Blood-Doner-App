using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BloodDoner.Mvc.Models.Entities
{
    public class Donation : BaseEntity
    {
        public required DateTime DonationDate { get; set; }

        [ForeignKey("BloodDoner")]
        public required int BloodDonerId { get; set; }
    }
}
