using System.ComponentModel.DataAnnotations;
using BloodDoner.Mvc.Models.Entities;

namespace BloodDoner.Mvc.Models.ViewModel
{
    public class BloodDonerCreateViewModel
    {
        [Required]
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

        public IFormFile? ProfilePicture { get; set; }

    }
}
