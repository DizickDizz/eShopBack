using WebApplication1.DTOs;
using WebApplication1.Entities;

namespace WebApplication1.Repository;

public interface IOrderRepository 
{
    void Create(Order order);
    int GetEntityId(int userId);
    List<Order> GetOrdersByUserId(int userId);
    List<Order> GetOrderListForSpecificUser(int userId);
    List<OrderLine> GetOrderItems(int userId);
    void TransferTheOrder(int orderId);
    void CreateOrderItemsLine(Order item, OrderLine orderLine);
    void Delete(int itemId);
}