using System.ComponentModel.DataAnnotations;

namespace Catalog_Web_API.DTOs
{
    public record DeleteItemDTO
    {
        [Required]
        public Guid Id { get; set; }
    }
}

