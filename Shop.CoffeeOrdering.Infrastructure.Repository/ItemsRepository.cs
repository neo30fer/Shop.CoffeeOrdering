using MongoDB.Bson;
using MongoDB.Driver;
using Shop.CoffeeOrdering.Common.Interfaces;
using Shop.CoffeeOrdering.Domain.Entity;
using Shop.CoffeeOrdering.Infrastructure.Data;
using Shop.CoffeeOrdering.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.CoffeeOrdering.Infrastructure.Repository
{
    public class ItemsRepository : IItemsRepository
    {
        private readonly IDBFactory _dbFactory;
        private IMongoCollection<Items> Collection;
        
        public ItemsRepository(IDBFactory dbFactory)
        {
            _dbFactory = dbFactory;
            Collection = _dbFactory.Database.GetCollection<Items>("Items");
        }

        public async Task DeleteItem(string id)
        {
            var filter = Builders<Items>.Filter.Eq(a => a.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<Items>> GetAllItems()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Items> GetItemById(string id)
        {
            return await Collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstOrDefaultAsync();
        }

        public async Task InsertItem(Items item)
        {
            await Collection.InsertOneAsync(item);
        }

        public async Task UpdateItem(Items item)
        {
            var filter = Builders<Items>.Filter.Eq(a => a.Id, item.Id);
            await Collection.ReplaceOneAsync(filter, item);
        }
    }
}
