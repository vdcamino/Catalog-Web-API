using Catalog_Web_API.Models;
using MongoDB.Driver;

namespace Catalog_Web_API.Repositories
{
    public class MongoDBItemsRepository : IInMemItemsRepository
    {
        private readonly IMongoCollection<Item> itemsCollection;
        // Still need the collection name and the database name to group everything into a collection

        public MongoDBItemsRepository(IMongoClient mongoClient)
        {

        }

        public void CreateItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItems()
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
