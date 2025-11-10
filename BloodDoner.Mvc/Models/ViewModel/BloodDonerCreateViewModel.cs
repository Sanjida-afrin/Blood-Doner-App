using System.ComponentModel.DataAnnotations;
using BloodDoner.Mvc.Models.Entities;
using BloodDoner.Mvc.Models.ValidationAttributes;

namespace BloodDoner.Mvc.Models.ViewModel
{
    public class BloodDonerCreateViewModel
    {
        [Required]
        public required string FullName { get; set; }

        [Phone]
        [Length(15, 10)]
        public required string ContactNumber { get; set; }
       
        [MinimumAge(18)]
        public required DateTime DateofBirth { get; set; }

        [EmailAddress]
        //[UniqueEmail(ErrorMessage = "Email already exist.")]
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
