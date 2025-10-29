namespace BloodDoner.Mvc.Models.ViewModel
{
    public class UserWithRolesViewModel
    {
        public required string UserId { get; set; }
        public required string Email { get; set; }

        public required List<string> Roles { get; set; } = new List<string>();
    }
}
