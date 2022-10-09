using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SQLite;
using System.Data;
using WebApplication1.Entities;

namespace WebApplication1.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly string DbFilePath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName + @"\eShopDBGenerator\bin\Debug\net6.0\e-shop.db";
        public List<Product> GetEntityList()
        {
            using (var db = new SQLiteConnection(DbFilePath))
            {
                return db.Query<Product>("SELECT * FROM Products").ToList();
            }
        }

        public Product GetEntity(int id)
        {
            using (var db = new SQLiteConnection(DbFilePath))
            {
                return db.Query<Product>("SELECT * FROM Products WHERE Id = @id", id).FirstOrDefault();
            }
        }

        public int GetAmount(int id)
        {
            using (var db = new SQLiteConnection(DbFilePath))
            {
                return db.ExecuteScalar<int>("SELECT amount_left FROM Products WHERE Id = @id", id);
            }
        }

        public void Delete(int productId)
        {
            using (var db = new SQLiteConnection(DbFilePath))
            {
                var sqlQuery = "DELETE FROM Products WHERE Id = @id";
                db.Execute(sqlQuery, productId);
            }
        }

        public void DecreaseAmount(int productId, int newAmount)
        {
            using (var db = new SQLiteConnection(DbFilePath))
            {
                var sqlQuery = "UPDATE Products SET amount_left = @newAmount WHERE Id = @id";
                db.Execute(sqlQuery, newAmount, productId);
            }
        }
    }
}
