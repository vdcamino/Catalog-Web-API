using Catalog_Web_API.Models;
using MongoDB.Driver;

namespace Catalog_Web_API.Repositories
{
    public class MongoDBItemsRepository : IInMemItemsRepository
    {
        private const string databaseName = "catalog";
        private const string collectionName = "items";
        private readonly IMongoCollection<Item> itemsCollection;

        public MongoDBItemsRepository(IMongoClient mongoClient)
        {
            // Both the collection and the database will be created by MongoDB Driver the first time they are needed
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            itemsCollection = database.GetCollection<Item>(collectionName);
        }
        // To visualize the MongoDB database, we will run it in a Docker container 
        public void CreateItem(Item item)
        {
            itemsCollection.InsertOne(item);
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
