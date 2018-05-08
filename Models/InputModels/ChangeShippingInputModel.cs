using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModel
{
    public class ChangeShippingInputModel
    {
        [Required(ErrorMessage = "Please enter address")]
        public string address { get; set; }

        [Required(ErrorMessage = "Please enter Zip code")]
        [RegularExpression("[0-9]{3}", ErrorMessage = "Zip code must be 3 digits")]
        public string zipCode { get; set; }

        [Required(ErrorMessage = "Please select country")]
        public string country { get; set; }

        [Required(ErrorMessage = "Please enter city")]
        public string city { get; set; }
    }
}