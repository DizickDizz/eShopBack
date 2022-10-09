using SQLite;
using WebApplication1.Entities;
using System.Configuration;
using System.Collections.Specialized;

namespace WebApplication1.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly string DbFilePath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName + @"\eShopDBGenerator\bin\Debug\net6.0\e-shop.db";

        public void Create(Cart cart)
        {
            using (var db = new SQLiteConnection(DbFilePath))
            {
                var sqlQuery = "INSERT INTO Carts (user_id, product_id, quantity, state) VALUES (@user_id, @product_id, @quantity, 1)";
                db.Execute(sqlQuery, cart.UserId, cart.ProductId, cart.Quantity);
            }
        }
        public void Update(Cart cart)
        {
            using (var db = new SQLiteConnection(DbFilePath))
            {
                var sqlQuery = "UPDATE Carts SET state = 1, quantity = @quantity WHERE user_id = @user_id AND product_id = @product_id";
                db.Execute(sqlQuery, cart.Quantity, cart.UserId, cart.ProductId);
            }
        }
        public List<Cart> GetUsersPurchases(int userId)
        {
            using (var db = new SQLiteConnection(DbFilePath))
            {
                return db.Query<Cart>("SELECT * FROM Carts WHERE user_id = @id AND state = 1", userId).ToList();
            }
        }

        public void Delete(int userId, int productId)
        {
            using (var db = new SQLiteConnection(DbFilePath))
            {
                var sqlQuery = "UPDATE Carts SET state = 0 WHERE user_id = @user_id AND product_id = @product_id";
                db.Execute(sqlQuery, userId, productId);
            }
        }

        public void DeleteAll(int id)
        {
            using (var db = new SQLiteConnection(DbFilePath))
            {
                var sqlQuery = "UPDATE Carts SET state = 0 WHERE user_id = @user_id";
                db.Execute(sqlQuery, id);
            }
        }

        public Cart GetCart(int userId, int productId)
        {
            using (var db = new SQLiteConnection(DbFilePath))
            { 
                return db.Query<Cart>("SELECT * FROM Carts WHERE user_id = @user_id AND product_id = @product_id", userId, productId).FirstOrDefault();
            }
        }
    }
}
