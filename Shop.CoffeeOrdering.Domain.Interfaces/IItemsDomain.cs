using Shop.CoffeeOrdering.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.CoffeeOrdering.Domain.Interfaces
{
    public interface IItemsDomain
    {
        Task InsertItem(Items item);
        Task UpdateItem(Items item);
        Task DeleteItem(string id);
        Task<List<Items>> GetAllItems();
        Task<Items> GetItemById(string id);
    }
}
