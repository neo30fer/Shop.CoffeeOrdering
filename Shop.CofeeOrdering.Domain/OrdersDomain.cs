using Shop.CoffeeOrdering.Domain.Entity;
using Shop.CoffeeOrdering.Domain.Interfaces;
using Shop.CoffeeOrdering.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.CoffeeOrdering.Domain.Core
{
    public class OrdersDomain : IOrdersDomain
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IItemsRepository _itemsRepository;
        private readonly IUsersRepository _usersRepository;
        public OrdersDomain(IOrdersRepository ordersRepository, IItemsRepository itemsRepository, IUsersRepository usersRepository)
        {
            _ordersRepository = ordersRepository;
            _itemsRepository = itemsRepository;
            _usersRepository = usersRepository;
        }

        public async Task InsertOrder(Orders order)
        {
            order.OrderLines.ForEach(a =>
            {
                a.Item = _itemsRepository.GetItemById(a.Item.ItemId).Result;
                a.Price = a.Item.Price;
                a.Tax = (a.Item.Tax / 100) * a.Price;
                a.Subtotal = (a.Quantity * (a.Price + a.Tax)) - a.Discount;
            });

            order.User = _usersRepository.GetUserById(order.User.UserId).Result;
            order.Date = DateTime.Now;
            order.Total = (from a in order.OrderLines select a.Subtotal).Sum();
            order.TotalTax = (from a in order.OrderLines select a.Tax).Sum();
            order.TotalDiscount = (from a in order.OrderLines select a.Discount).Sum();

            await _ordersRepository.InsertOrder(order);
        }

        public async Task DeleteOrder(string id)
        {
            await _ordersRepository.DeleteOrder(id);
        }

        public async Task<List<Orders>> GetAllOrders()
        {
            return await _ordersRepository.GetAllOrders();
        }

        public async Task<Orders> GetOrderById(string id)
        {
            return await _ordersRepository.GetOrderById(id);
        }
    }
}
