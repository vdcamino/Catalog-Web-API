using Catalog_Web_API.DTOs;
using Catalog_Web_API.Models;

namespace Catalog_Web_API
{
    public static class Extensions
    {   
        public static ItemDTO AsDTO(this Item item)
        {
            return new ItemDTO
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate,
            };
        }
    }
}
