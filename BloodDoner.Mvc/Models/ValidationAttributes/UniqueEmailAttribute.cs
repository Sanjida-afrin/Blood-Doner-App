using System.ComponentModel.DataAnnotations;
using BloodDoner.Mvc.Services.Interfaces;

namespace BloodDoner.Mvc.Models.ValidationAttributes
{
        public class UniqueEmailAttribute : ValidationAttribute
        {
            protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
            {
                if (value is string email && !string.IsNullOrWhiteSpace(email))
                {
                    var donorService = validationContext.GetService<IBloodDonerService>();
                    if (donorService is null)
                    {
                        return ValidationResult.Success;
                    }
                    var existingDoners = donorService.GetAllAsync().GetAwaiter().GetResult();

                    if (existingDoners.Any(d => d.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
                    {
                        return new ValidationResult(ErrorMessage);
                    }
                }
                return ValidationResult.Success;
            }
        }
    }

