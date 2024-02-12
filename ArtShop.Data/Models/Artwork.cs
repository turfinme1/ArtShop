using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ArtShop.Data.Common.GlobalConstants.ArtworkValidationConstants;

namespace ArtShop.Data.Models
{
    public class Artwork
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(SummaryMaxLength)]
        public required string Summary { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public required string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public double OverallRatingScore { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
        
        [Required]
        public required string CreatorId { get; set; }

        [ForeignKey(nameof(CreatorId))]
        public required IdentityUser Creator { get; set; }

        public List<Category> Categories { get; set; } = [];
        
        public List<ArtworkCategory> ArtworksCategories { get; } = [];
        
        //public List<Order> Orders { get; set; } = [];
        
        public List<ArtworkOrder> ArtworksOrders { get; set; } = [];

        //public List<Review> Reviews { get; set; } = [];
    }
}
