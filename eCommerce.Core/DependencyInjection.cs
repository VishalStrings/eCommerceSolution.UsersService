using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace eCommerce.Core
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Extension method to add infrastructure services to the DI conatiner.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>

        public static IServiceCollection AddCore(this IServiceCollection services)
        {

            services.AddTransient<IUsersService, UsersService>();

            return services;
        }



    }
}
