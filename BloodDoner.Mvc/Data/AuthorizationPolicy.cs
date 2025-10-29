using Microsoft.AspNetCore.Authorization;

namespace BloodDoner.Mvc.Data
{
    public static class AuthorizationPolicy
    {
        public static void AddPolicies(AuthorizationOptions options)
        {
            options.AddPolicy("RequireDonorRole", policy => policy.RequireClaim("DonorEligibility"));
            options.AddPolicy("RequireAdminRole", policy => policy.RequireClaim("Admin"));
            options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
            options.AddPolicy("RequireAdminOrDonorRole", policy => policy.RequireRole("Admin", "Donor"));

        }
    }
}
