using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Psapnetcore.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psaspnetcore.Data
{
    public class PsancDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Restaurant> Restaurants { get; set; }
        
        public PsancDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration["ConnectionStrings:SqlLocalDb"];
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
