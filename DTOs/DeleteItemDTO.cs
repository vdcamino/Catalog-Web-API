using System.ComponentModel.DataAnnotations;

namespace Catalog_Web_API.DTOs
{
    public class DeleteItemDTO
    {
        [Required]
        public Guid Id { get; set; }
    }
}

