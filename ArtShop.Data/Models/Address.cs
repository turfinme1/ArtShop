using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ArtShop.Data.Common.GlobalConstants.AddressValidationConstants;

namespace ArtShop.Data.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(StreetNameMaxLength)]
        public required string StreetName { get; set; }

        [MaxLength(ZipCodeMaxLength)]
        public string? ZipCode { get; set; }

        [Required]
        public int CityId { get; set; }

        [ForeignKey(nameof(CityId))]
        public required City City { get; set; }
    }
}
