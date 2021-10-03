using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Shop.CoffeeOrdering.Domain.Entity
{
    public class Items
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string ItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Tax { get; set; }
    }
}
