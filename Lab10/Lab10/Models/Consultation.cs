using System.ComponentModel.DataAnnotations;

namespace Lab10.Models
{
    public class Consultation
    {
        [Required (ErrorMessage = "The 'First and Last Name' field is required!")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "The 'Email' field is required!")]
        [EmailAddress(ErrorMessage = "Enter the correct Email!")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$", ErrorMessage = "Invalid Email address!")]
        public string Email { get; set; }

        [Required (ErrorMessage = "The 'Preferred date of consultation' field is required!")]
        [DataType(DataType.Date)]
        [FutureDate (ErrorMessage = "The desired date should be in the future and not fall on a weekend!")]
        public DateTime ConsultationDate { get; set; }

        [Required (ErrorMessage = "Select a product!")]
        [NotBasicOnMonday(ErrorMessage = "Consultation on the Основи product cannot be held on Mondays!")]
        public string SelectedProduct { get; set; }
    }
}
