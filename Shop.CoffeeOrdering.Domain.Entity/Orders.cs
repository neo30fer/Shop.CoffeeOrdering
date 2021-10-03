using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.CoffeeOrdering.Domain.Entity
{
    public class Orders
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalDiscount { get; set; }
        public List<OrderLines> OrderLines { get; set; }
        public Users User { get; set; }
    }
}
