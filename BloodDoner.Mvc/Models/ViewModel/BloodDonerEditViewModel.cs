namespace BloodDoner.Mvc.Models.ViewModel
{
    public class BloodDonerEditViewModel : BloodDonerCreateViewModel
    {
        public int Id { get; set; }
        public string? ExistingProfilePicture { get; set; }
    }
}
