using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtShop.Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public required string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public required IdentityUser User { get; set; }

        //public List<Artwork> Artworks { get; set; } = [];

        public List<ArtworkOrder> ArtworksOrders { get; } = [];
    }
}
