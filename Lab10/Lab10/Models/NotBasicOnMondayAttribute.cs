using System.ComponentModel.DataAnnotations;

namespace Lab10.Models
{
    public class NotBasicOnMondayAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            var form = (Consultation)validationContext.ObjectInstance;

            if (form.SelectedProduct == "Основи" && form.ConsultationDate.DayOfWeek == DayOfWeek.Monday)
            {
                return new ValidationResult("Consultation on the Основи product cannot take place on Mondays");
            }

            return ValidationResult.Success;
        }
    }
}
