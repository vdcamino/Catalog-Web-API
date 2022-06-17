namespace Catalog_Web_API.DTOs
{
    // In this case, the object returned by the API will be equal to the object stored in the databse 
    public record ItemDTO
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public decimal Price { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}
