namespace Catalog_Web_API.DTOs
{
    public class ItemDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
