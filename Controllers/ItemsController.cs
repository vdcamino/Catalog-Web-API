using Catalog_Web_API.DTOs;
using Catalog_Web_API.Models;
using Catalog_Web_API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog_Web_API.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IInMemItemsRepository repository;

        public ItemsController(IInMemItemsRepository repository)
        {
            this.repository = repository;
        }

        // GET /items
        [HttpGet]
        public async Task<IEnumerable<ItemDTO>> GetItemsAsync()
        {
            var items = (await repository.GetItemsAsync())  // Parenthesis make the select action to be performed only after GetItemsAsync
                        .Select(item => item.AsDTO());

            return items;
        }
        
        // GET /items/{id}
        [HttpGet("{Id}")]
        public async Task <ActionResult<ItemDTO>> GetItemAsync(Guid Id)
        {
            var item = await repository.GetItemAsync(Id);

            if (item is null)
            {
                return NotFound();
            }

            return item.AsDTO();
        }

        // POST /items
        [HttpPost]
        public async Task<ActionResult<ItemDTO>> CreateItem(CreateItemDTO itemDTO)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDTO.Name,
                Price = itemDTO.Price,
                CreatedDate = DateTimeOffset.Now
            };


            await repository.CreateItemAsync(item);

            return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, item.AsDTO());
            
        }

        // PUT /items/id
        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateItem(Guid id, UpdateItemDTO itemDTO)
        {
            var existingItem = await repository.GetItemAsync(id);
            if (existingItem is null)
            {
                return NotFound();
            }

            Item updatedItem = existingItem;

            existingItem.Name = itemDTO.Name;
            existingItem.Price = itemDTO.Price;

            await repository.UpdateItemAsync(updatedItem);

            return NoContent();
        }

        // DELETE /items/id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(Guid id)
        {
            var existingItem = await repository.GetItemAsync(id);
            if (existingItem is null)
            {
                return NotFound();
            }

            await repository.DeleteItemAsync(id);

            return NoContent();
        }
    }
}
