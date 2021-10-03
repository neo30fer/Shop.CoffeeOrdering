using MongoDB.Driver;
using System;

namespace Shop.CoffeeOrdering.Common.Interfaces
{
    public interface IDBFactory
    {
        IMongoDatabase Database { get; }
    }
}
