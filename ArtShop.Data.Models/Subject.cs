﻿using System.ComponentModel.DataAnnotations;
using static ArtShop.Data.Common.ValidationConstants.SubjectValidationConstants;


namespace ArtShop.Data.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public required string Name { get; set; }

        public List<Artwork> Artworks { get; set; } = [];
    }
}
