using Shop.CoffeeOrdering.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.CoffeeOrdering.Infrastructure.Interface
{
    public interface IOrdersRepository
    {
        Task InsertOrder(Orders order);
        Task DeleteOrder(string id);
        Task<List<Orders>> GetAllOrders();
        Task<Orders> GetOrderById(string id);
    }
}
