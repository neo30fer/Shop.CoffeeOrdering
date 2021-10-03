using MongoDB.Bson;
using MongoDB.Driver;
using Shop.CoffeeOrdering.Common.Interfaces;
using Shop.CoffeeOrdering.Domain.Entity;
using Shop.CoffeeOrdering.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.CoffeeOrdering.Infrastructure.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IDBFactory _dbFactory;
        private IMongoCollection<Users> Collection;

        public UsersRepository(IDBFactory dbFactory)
        {
            _dbFactory = dbFactory;
            Collection = _dbFactory.Database.GetCollection<Users>("Users");
            if (Collection.Find(a => a.UserName == "admin" && a.Password == "123456").FirstOrDefault<Users>() == null)
            {
                Collection.InsertOne(new Users()
                {
                    UserName = "admin",
                    FirstName = "Administrator",
                    LastName = "CoffeeShop",
                    Password = "123456"
                });
            }
        }

        public Users Authenticate(string userName, string password)
        {
            return Collection.Find(a => a.UserName == userName && a.Password == password).FirstOrDefault<Users>();
        }
        public async Task<Users> GetUserById(string id)
        {
            return await Collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstOrDefaultAsync();
        }
    }
}
