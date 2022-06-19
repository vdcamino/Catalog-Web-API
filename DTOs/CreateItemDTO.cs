using System.ComponentModel.DataAnnotations;

namespace Catalog_Web_API.DTOs
{
    public record CreateItemDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, 1000)]
        public decimal Price { get; set; }
    }
}

