using MongoDB.Bson;
using MongoDB.Driver;
using Shop.CoffeeOrdering.Common.Interfaces;
using Shop.CoffeeOrdering.Domain.Entity;
using Shop.CoffeeOrdering.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.CoffeeOrdering.Infrastructure.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly IDBFactory _dbFactory;
        private IMongoCollection<Orders> Collection;

        public OrdersRepository(IDBFactory dbFactory)
        {
            _dbFactory = dbFactory;
            Collection = _dbFactory.Database.GetCollection<Orders>("Orders");
        }

        public async Task DeleteOrder(string id)
        {
            var filter = Builders<Orders>.Filter.Eq(a => a.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<Orders>> GetAllOrders()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Orders> GetOrderById(string id)
        {
            return await Collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstOrDefaultAsync();
        }

        public async Task InsertOrder(Orders order)
        {
            await Collection.InsertOneAsync(order);
        }
    }
}
