namespace BloodDoner.Mvc.Models.ViewModel
{
    public class ManageUsersRolesViewModel
    {
        public required string UserId { get; set; }
        public required string Email { get; set; }
        public required List<string> AvailableRoles { get; set; } = new List<string>();
        public required List<string> UserRoles { get; set; } = new List<string>();
    }
}
