﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ArtShop.Data.Common.GlobalConstants.ReviewValidationConstants;

namespace ArtShop.Data.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(CommentMaxLength)]
        public string? Comment { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public required string CreatorId { get; set; }

        [ForeignKey(nameof(CreatorId))]
        public IdentityUser? Creator { get; set; }

        [Required]
        public int ArtworkId { get; set; }

        [ForeignKey(nameof(ArtworkId))]
        public required Artwork Artwork { get; set; }
    }
}
