using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.DbContext
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _connection;

        public DapperDbContext(IConfiguration configuration)
        {
            _configuration = configuration;

            string? connectionString = 
                _configuration.GetConnectionString("PostgresConnectionString");
          
         
            // carete a new npgsqlconnection with retrived connection string
            _connection = new Npgsql.NpgsqlConnection(connectionString);  

        }

        public IDbConnection DbConnection => _connection;

        //public IDbConnection DbConnection
        //{
        //    get
        //    {
        //        return _connection;
        //    }
        //}


    }
}
