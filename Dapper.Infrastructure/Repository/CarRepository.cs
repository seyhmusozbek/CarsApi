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
    public class CarRepository : ICarRepository
    {
        private readonly IConfiguration configuration;
        public CarRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<int> AddAsync(Car entity)
        {
            entity.AddedOn = DateTime.Now;
            var sql = "Insert into Cars (Brand,Model,Description,IsLightOn,IsDoorOn,Price,AddedOn,AddedBy)VALUES(@Brand,@Model,@Description,@IsLightOn,@IsDoorOn,@Price,@AddedOn,@AddedBy)";
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            
            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;

        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Cars WHERE Id = @Id";
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

            connection.Open();
            var result = await connection.ExecuteAsync(sql, new { Id = id });
            return result;

        }

        public async Task<IReadOnlyList<Car>> GetAllAsync()
        {
            var sql = "SELECT * FROM Cars";
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

            connection.Open();
            var result = await connection.QueryAsync<Car>(sql);
            return result.ToList();

        }

        public async Task<Car> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Cars WHERE Id = @Id";
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

            connection.Open();
            var result = await connection.QuerySingleOrDefaultAsync<Car>(sql, new { Id = id });
            return result;

        }

        public async Task<int> UpdateAsync(Car entity)
        {
            entity.ModifiedOn = DateTime.Now;
            var sql = "UPDATE Cars SET Brand=ISNULL(@Brand,Brand), Model=ISNULL(@Model,Model), Description=ISNULL(@Description,Description), IsLightOn=ISNULL(@IsLightOn,IsLightOn), IsDoorOn=ISNULL(@IsDoorOn,IsDoorOn), ModifiedOn=ISNULL(@ModifiedOn,ModifiedOn), ModifiedBy=ISNULL(@ModifiedBy,ModifiedBy) WHERE Id = @Id";
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
        }
    }
}
