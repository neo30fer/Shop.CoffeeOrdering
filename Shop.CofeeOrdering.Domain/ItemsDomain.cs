using Shop.CoffeeOrdering.Domain.Entity;
using Shop.CoffeeOrdering.Domain.Interfaces;
using Shop.CoffeeOrdering.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.CofeeOrdering.Domain
{
    public class ItemsDomain : IItemsDomain
    {
        private readonly IItemsRepository _itemsRepository;
        public ItemsDomain(IItemsRepository itemsRepository)
        {
            _itemsRepository = itemsRepository;
        }

        public async Task InsertItem(Items item)
        {
            await _itemsRepository.InsertItem(item);
        }
        
        public async Task UpdateItem(Items item)
        {
            await _itemsRepository.UpdateItem(item);
        }

        public async Task DeleteItem(string id)
        {
            await _itemsRepository.DeleteItem(id);
        }

        public async Task<List<Items>> GetAllItems()
        {
            return await _itemsRepository.GetAllItems();
        }

        public async Task<Items> GetItemById(string id)
        {
            return await _itemsRepository.GetItemById(id);
        }
    }
}
