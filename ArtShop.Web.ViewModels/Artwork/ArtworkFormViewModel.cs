using System.ComponentModel.DataAnnotations;
using ArtShop.Web.ViewModels.Style;
using ArtShop.Web.ViewModels.Subject;
using static ArtShop.Data.Common.ValidationConstants.ArtworkValidationConstants;
using static ArtShop.Data.Common.ValidationConstants.ErrorMessages;

namespace ArtShop.Web.ViewModels.Artwork
{
    public class ArtworkFormViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(NameMaxLength,
            MinimumLength = NameMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(SummaryMaxLength,
            MinimumLength = SummaryMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Summary { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(DescriptionMaxLength,
            MinimumLength = DescriptionMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(PriceMinValue,
            PriceMaxValue,
            ErrorMessage = NumberValueErrorMessage)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public int Quantity { get; set; }

        [Required]
        [Range(YearMadeMinValue, YearMadeMaxValue)]
        public int YearMade { get; set; }

        [Required]
        [Range(DimensionMinValue,DimensionMaxValue)]
        public double Height { get; set; }

        [Required]
        [Range(DimensionMinValue, DimensionMaxValue)]
        public double Width { get; set; }

        [Range(DimensionMinValue, DimensionMaxValue)]
        public double? Depth { get; set; }

        [Required]
        public bool IsFramed { get; set; }

        [Required]
        public int StyleId { get; set; }

        public IEnumerable<StyleViewModel> Styles { get; set; } = [];

        [Required]
        public int SubjectId { get; set; }

        public IEnumerable<SubjectViewModel> Subjects { get; set; } = [];

        public string CreatorId { get; set; } = string.Empty;
    }
}
