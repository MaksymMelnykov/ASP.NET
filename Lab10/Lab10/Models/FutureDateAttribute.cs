using System.ComponentModel.DataAnnotations;

namespace Lab10.Models
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var selectedDate = (DateTime)value;

            if (selectedDate.Date <= DateTime.Today || selectedDate.DayOfWeek == DayOfWeek.Saturday || selectedDate.DayOfWeek == DayOfWeek.Sunday)
            {
                return new ValidationResult("The desired date should be in the future and not fall on a weekend!");
            }

            return ValidationResult.Success;
        }
    }
}
