﻿using System.ComponentModel.DataAnnotations;

namespace Catalog_Web_API.DTOs
{
    public record UpdateItemDTO
    {
        [Required]
        public string Name { get; init; }

        [Required]
        [Range(1, 1000)]
        public decimal Price { get; init; }
    }
}

