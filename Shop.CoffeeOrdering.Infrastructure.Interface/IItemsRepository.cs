using Shop.CoffeeOrdering.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.CoffeeOrdering.Infrastructure.Interface
{
    public interface IItemsRepository
    {
        Task InsertItem(Items item);
        Task UpdateItem(Items item);
        Task DeleteItem(string id);
        Task<List<Items>> GetAllItems();
        Task<Items> GetItemById(string id);
    }
}
