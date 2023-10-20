using System.ComponentModel.DataAnnotations;

namespace WebAuctions.ViewModels
{
    public class CreateAuctionVM
    {
        [Required]
        [RegularExpression(@"^.*\.(jpg|jpeg|png|gif)$", ErrorMessage = "The Picture must be in a valid image format (jpg, jpeg, png, gif).")]
        public string Picture { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(255)]
        public string AuctionName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Expiration Date")]
        [CustomValidation(typeof(CreateAuctionVM), "ValidateExpirationDate")]
        public DateTime ExpirationDate { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public static ValidationResult ValidateExpirationDate(DateTime expDate, ValidationContext context)
        {
            if (expDate <= DateTime.Now)
            {
                return new ValidationResult("The Expiration Date must be in the future.");
            }

            return ValidationResult.Success;
        }
    }
}