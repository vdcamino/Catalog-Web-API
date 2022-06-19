using Catalog_Web_API.Models;
using System.Collections.Generic;

namespace Catalog_Web_API.Repositories
{
    public class InMemItemsRepository : IInMemItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item {Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(), Name = "Iron Man", Price =1022, CreatedDate = DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(), Name = "Potion", Price = 1, CreatedDate = DateTimeOffset.UtcNow},
        };

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await Task.FromResult(items);
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            var item = items.Where(item => item.Id == id).SingleOrDefault();
            return await Task.FromResult(item);
        }

        public async Task CreateItemAsync(Item item)
        {
            items.Add(item);
            await Task.CompletedTask;
        }
        
        public async Task UpdateItemAsync(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
            await Task.CompletedTask;
        } 
        
        public async Task DeleteItemAsync(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}

