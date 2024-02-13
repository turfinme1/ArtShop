using System.ComponentModel.DataAnnotations;
using static ArtShop.Data.Common.ValidationConstants.ArtworkValidationConstants;
using static ArtShop.Data.Common.ValidationConstants.ErrorMessages;

namespace ArtShop.Web.ViewModels.Artwork
{
    public class ArtworkViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(NameMaxLength, 
            MinimumLength = NameMinLength, 
            ErrorMessage = StringLengthErrorMessage)]
        public required string Name { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(SummaryMaxLength, 
            MinimumLength = SummaryMinLength, 
            ErrorMessage = StringLengthErrorMessage)]
        public required string Summary { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(DescriptionMaxLength, 
            MinimumLength = DescriptionMinLength, 
            ErrorMessage = StringLengthErrorMessage)]
        public required string Description { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(PriceMinValue,
            PriceMaxValue,
            ErrorMessage = NumberValueErrorMessage)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public int Quantity { get; set; }

        public double OverallRatingScore { get; set; }
        
        [Required]
        public required string CreatorId { get; set; }

        // TODO: list of categories model, orders model, reviews model
    }
}
