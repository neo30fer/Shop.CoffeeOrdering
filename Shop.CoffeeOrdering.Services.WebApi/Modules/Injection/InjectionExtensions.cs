using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.CofeeOrdering.Domain;
using Shop.CoffeeOrdering.Common.Interfaces;
using Shop.CoffeeOrdering.Domain.Core;
using Shop.CoffeeOrdering.Domain.Interfaces;
using Shop.CoffeeOrdering.Infrastructure.Data;
using Shop.CoffeeOrdering.Infrastructure.Interface;
using Shop.CoffeeOrdering.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.CoffeeOrdering.Services.WebApi.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<IDBFactory, MongoDBFactory>();
            services.AddScoped<IItemsRepository, ItemsRepository>();
            services.AddScoped<IItemsDomain, ItemsDomain>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<IOrdersDomain, OrdersDomain>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IUsersDomain, UsersDomain>();

            return services;
        }
    }
}
