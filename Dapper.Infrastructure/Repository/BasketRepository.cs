using Dapper.Application.Interfaces;
using Dapper.Core.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper.Infrastructure.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IConfiguration configuration;
        public BasketRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<int> AddAsync(Basket entity)
        {
            entity.AddedOn = DateTime.Now;
            var sql = "Insert into Baskets (CarId, Quantity, Price, AddedBy, AddedOn, Description)VALUES(@CarId,@Quantity,@Price,@AddedBy,@AddedOn,@Description)";
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            
            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Baskets WHERE Id = @Id";
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

            connection.Open();
            var result = await connection.ExecuteAsync(sql, new { Id = id });
            return result;
        }

        public async Task<IReadOnlyList<Basket>> GetAllAsync()
        {
            var sql = "SELECT * FROM Baskets";
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

            connection.Open();
            var result = await connection.QueryAsync<Basket>(sql);
            return result.ToList();

        }

        public async Task<Basket> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Baskets WHERE Id = @Id";
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

            connection.Open();
            var result = await connection.QuerySingleOrDefaultAsync<Basket>(sql, new { Id = id });
            return result;

        }

        public async Task<int> UpdateAsync(Basket entity)
        {
            entity.ModifiedOn = DateTime.Now;
            var sql = "UPDATE Baskets SET Quantity=@Quantity,ModifiedBy=@ModifiedBy WHERE Id = @Id";
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
        }
    }
}
