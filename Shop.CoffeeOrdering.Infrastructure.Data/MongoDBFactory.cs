using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Shop.CoffeeOrdering.Common.Interfaces;
using System;

namespace Shop.CoffeeOrdering.Infrastructure.Data
{
    public class MongoDBFactory : IDBFactory
    {
        private readonly IConfiguration _configuration;
        public MongoClient client;
        
        public MongoDBFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IMongoDatabase Database
        {
            get
            {
                client = new MongoClient(_configuration.GetConnectionString("CoffeeShopConnection"));
                return client.GetDatabase("Ordering");
            }
        }
    }
}
