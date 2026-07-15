using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositortyContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using eCommerce.Infrastructure.DbContext;
using Dapper;

namespace eCommerce.Infrastructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly DapperDbContext _dbContext;

        public UserRepository(DapperDbContext dapperDbContext) {
            this._dbContext = dapperDbContext;
        }

        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            user.UserID = Guid.NewGuid();

            string query = """
                            INSERT INTO public."Users"
                            ("UserID", "Email", "Password", "PersonName", "Gender") 
                            VALUES (@UserID, @Email, @Password, @PersonName, @Gender);
                            """;

            //string query = "INSERT INTO public.\"Users\" (\"UserID\", \"Email\", \"Password\", \"PersonName\", \"Gender\") VALUES (@UserID, @Email, @Password, @PersonName, @Gender)";
            int rowsAffected =
            await _dbContext.DbConnection.ExecuteAsync(query, user);

            if(rowsAffected > 0)
            {
                return user;
            }
            else
            {
                return null;
            }

        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
        {
            string query = """
                SELECT * FROM "Users" WHERE "Email" = @email and "Password" = @password
                """;
            var parameters = new { email = email, password = password };

            ApplicationUser? user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);

            return user;
           
        }
    }
}
