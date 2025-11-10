using BloodDoner.Mvc.Models.ViewModel;
using BloodDoner.Mvc.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BloodDoner.Mvc.Filters
{
  
        public class UniqueEmailFilter : IAsyncActionFilter
        {
            private readonly IBloodDonerService _bloodDonorService;

            public UniqueEmailFilter(IBloodDonerService bloodDonorService)
            {
                _bloodDonorService = bloodDonorService;
            }

            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                if (context.ActionArguments.TryGetValue("donor", out var value) && value is BloodDonerCreateViewModel donor)
                {
                    var existingDonors = await _bloodDonorService.GetAllAsync();

                    if (existingDonors.Any(d => d.Email.Equals(donor.Email, StringComparison.OrdinalIgnoreCase)))
                    {
                        context.ModelState.AddModelError("Email", "Email already exists. Checked from filter.");
                    }
                }
                await next();

            }
        }
    }

