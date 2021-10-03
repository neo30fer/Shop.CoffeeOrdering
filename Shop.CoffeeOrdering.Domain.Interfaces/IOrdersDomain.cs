using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Shop.CoffeeOrdering.Domain.Entity;

namespace Shop.CoffeeOrdering.Domain.Interfaces
{
    public interface IOrdersDomain
    {
        Task InsertOrder(Orders order);
        Task DeleteOrder(string id);
        Task<List<Orders>> GetAllOrders();
        Task<Orders> GetOrderById(string id);
    }
}
