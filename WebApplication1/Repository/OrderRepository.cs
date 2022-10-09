using SQLite;
using WebApplication1.DTOs;
using WebApplication1.Entities;

namespace WebApplication1.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string DbFilePath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName + @"\eShopDBGenerator\bin\Debug\net6.0\e-shop.db";
        public void Create(Order order)
        {
            using (var db = new SQLiteConnection(DbFilePath))
            {
                var sqlQuery = "INSERT INTO Orders (user_id, order_price, order_status) VALUES(@user_id, @order_price, @order_status)";
                db.Execute(sqlQuery, order.UserId, order.OrderPrice, order.OrderStatus);
            }
        }
        public int GetEntityId(int userId)
        {
            using (var db = new SQLiteConnection(DbFilePath))
            {
                return db.ExecuteScalar<int>("SELECT MAX(Id) FROM Orders WHERE user_id = @user_id", userId);
            }
        }
        public List<Order> GetOrdersByUserId(int userId)
        {
            using (var db = new SQLiteConnection(DbFilePath))
            {
                return db.Query<Order>("SELECT * FROM Orders WHERE user_id = @user_id").ToList();
            }
        }
        
        public List<Order> GetOrderListForSpecificUser(int userId)
        {
            using (var db = new SQLiteConnection(DbFilePath))
            {
                return db.Query<Order>("SELECT * FROM Orders WHERE user_id = @user_id", userId).ToList();
            }
        }
        public List<OrderLine> GetOrderItems(int userId)
        {
            using (var db = new SQLiteConnection(DbFilePath))
            {
                return db.Query<OrderLine>("SELECT * FROM OrderItems WHERE user_id = @user_id", userId).ToList();
            }
        }
        public void CreateOrderItemsLine(Order item, OrderLine orderLine)
        {
            using (var db = new SQLiteConnection(DbFilePath))
            {
                var sqlQuery = "INSERT INTO OrderItems (user_id, order_id, product_id, quantity) VALUES(@user_id, @order_id, @product_id, @quantity)";
                db.Execute(sqlQuery, item.UserId, item.Id, orderLine.ProductId, orderLine.Quantity);
            }
        }

        public void Delete(int itemId)
        {
            using (var db = new SQLiteConnection(DbFilePath))
            {
                var sqlQuery = "DELETE FROM Orders WHERE Id = @id";
                db.Execute(sqlQuery, itemId);
            }
        }
        

        public void TransferTheOrder(int orderId)
        {
            using (var db = new SQLiteConnection(DbFilePath))
            {
                var sqlQuery = "UPDATE Orders SET order_status = 1 WHERE Id = @Id";
                db.Execute(sqlQuery, orderId);
            }
        }

    }
}
