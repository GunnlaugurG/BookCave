using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModel
{
    public class ChangeCardInputModel
    {
        [Required(ErrorMessage = "Please enter cardholders name")]
        public string cardholderName { get; set; }

        [Required(ErrorMessage = "Please enter cardnumber")]
        [RegularExpression("[0-9]{16}", ErrorMessage = "Cardnumber must be 16 digits")]
        public string cardNumber { get; set; }

        [Required(ErrorMessage = "Please select country")]
        [RegularExpression("[0-9]{3}", ErrorMessage = "cvc number must be 3 digits")]
        public string cvc { get; set; }
    }
}