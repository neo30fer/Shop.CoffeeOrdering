using Shop.CoffeeOrdering.Common.Interfaces;
using Shop.CoffeeOrdering.Domain.Entity;
using Shop.CoffeeOrdering.Domain.Interfaces;
using Shop.CoffeeOrdering.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.CoffeeOrdering.Domain.Core
{
    public class UsersDomain : IUsersDomain
    {
        private readonly IUsersRepository _usersRepository;

        public UsersDomain(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        
        public Users Authenticate(string userName, string password)
        {
            return _usersRepository.Authenticate(userName, password);
        }

        public async Task<Users> GetUserById(string id)
        {
            return await _usersRepository.GetUserById(id);
        }
    }
}
