using Shop.CoffeeOrdering.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.CoffeeOrdering.Infrastructure.Interface
{
    public interface IUsersRepository
    {
        Users Authenticate(string username, string password);
        Task<Users> GetUserById(string id);
    }
}
