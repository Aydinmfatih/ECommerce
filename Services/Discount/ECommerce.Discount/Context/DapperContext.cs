using ECommerce.Discount.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ECommerce.Discount.Context
{
    public class DapperContext:DbContext
    {
        private readonly IConfiguration _configuration;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        private readonly string _connectionString;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS;initial Catalog=ECommerceDiscountDb;integrated Security=True;");
        }

        public DbSet<Coupon> Coupons { get; set; }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

    }
}
