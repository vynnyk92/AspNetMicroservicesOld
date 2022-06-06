using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Discount.API.Entities;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Discount.API.Repositories
{
    public interface IDiscountRepository
    {
        Task<Coupon> GetDiscount(string prodcutName);
        Task<bool> CreateDiscount(Coupon coupon);
        Task<bool> UpdateDiscount(Coupon coupon);
        Task<bool> DeleteDiscount(int couponId);
    }

    public class DiscountRepository : IDiscountRepository
    {
        private readonly string _connectionString;

        public DiscountRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DiscountDb");
        }

        public async Task<Coupon> GetDiscount(string prodcutName)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var result = await connection.QueryFirstOrDefaultAsync<Coupon>(
                    $"SELECT * FROM Coupon WHERE ProductName = @ProdcutName", new
                    {
                        ProdcutName = prodcutName
                    });

                return result;
            }
        }

        public Task<bool> CreateDiscount(Coupon coupon)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateDiscount(Coupon coupon)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDiscount(int couponId)
        {
            throw new NotImplementedException();
        }
    }
}
