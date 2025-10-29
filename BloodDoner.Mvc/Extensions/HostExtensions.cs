using BloodDoner.Mvc.Data;

namespace BloodDoner.Mvc.Extension
{
    public static class HostExtensions
    {
        public static async Task SeedDatabaseAsync(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                await SeedData.InitializeAsync(services);
            }
            catch (Exception)
            {

            }
        }
    }
}