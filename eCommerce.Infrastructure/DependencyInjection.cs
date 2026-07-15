using eCommerce.Core.RepositortyContracts;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using eCommerce.Infrastructure.DbContext;


namespace eCommerce.Infrastructure
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Extension method to add infrastructure services to the DI conatiner.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<DapperDbContext>();

            return services;
        }

    }
}
