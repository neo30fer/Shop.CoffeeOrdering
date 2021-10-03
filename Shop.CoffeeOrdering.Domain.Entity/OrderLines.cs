using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.CoffeeOrdering.Domain.Entity
{
    public class OrderLines
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public Items Item { get; set; }
        public decimal Price { get; set; }
        public decimal Tax { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
    }
}
