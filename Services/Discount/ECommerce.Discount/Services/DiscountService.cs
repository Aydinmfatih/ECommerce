using AutoMapper;
using Dapper;
using ECommerce.Discount.Context;
using ECommerce.Discount.Dtos;
using ECommerce.Discount.Models;
using System.Reflection.Metadata;

namespace ECommerce.Discount.Services
{
    public class DiscountService:IDiscountService
    {
        private readonly DapperContext _context;

        public DiscountService(DapperContext dapperContext)
        {
            _context = dapperContext;
        }

        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            string query = "insert into Coupons (Code ,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";
            var paramaters = new DynamicParameters();
            paramaters.Add("@code", createCouponDto.Code);
            paramaters.Add("@rate", createCouponDto.Rate);
            paramaters.Add("@isActive", true);
            paramaters.Add("@validDate", DateTime.Now.AddDays(10));
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }

        }

        public async Task DeleteCouponAsync(int id)
        {
            string query = "Delete from Coupons Where CouponId = @couponId";
            var paramaters = new DynamicParameters();
            paramaters.Add("couponId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }

        public async Task<List<ResultCouponDto>> GetAllCouponsAsync()
        {
            string query = "Select * from Coupons";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<ResultCouponDto> GetCouponById(int id)
        {
            string query = "select * from Coupons Where CouponId = @couponId";
            var paramaters = new DynamicParameters();
            paramaters.Add("couponId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultCouponDto>(query,paramaters);
                return values;
            }

        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "Update Coupons set Code=@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate where CouponId = @couponId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@code", updateCouponDto.Code);
            paramaters.Add("@rate", updateCouponDto.Rate);
            paramaters.Add("@isActive", updateCouponDto);
            paramaters.Add("@validDate", updateCouponDto.ValidDate);
            paramaters.Add("@couponId", updateCouponDto.CouponId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }
    }
}
