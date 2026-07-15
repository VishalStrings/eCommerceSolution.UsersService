using eCommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.RepositortyContracts
{
    public interface IUserRepository
    {
        /// <summary>
        /// Method to add a user to datastore and return added user. 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<ApplicationUser?> AddUser(ApplicationUser user);
        /// <summary>
        /// To reterive existing user by username and password. 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task <ApplicationUser?>GetUserByEmailAndPassword(string? email, string? password);
    }
}
