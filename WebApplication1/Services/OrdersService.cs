using WebApplication1.Entities;
using WebApplication1.Repository;
using WebApplication1.DTOs;

namespace WebApplication1.Services
{
    public class OrdersService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrdersService(IOrderRepository orderRepository, ICartRepository cartRepository, 
            IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }
        public bool CheckOut(int userId)
        {   
            var UsersPurchases = _cartRepository.GetUsersPurchases(userId); 
            var order = new Order() { UserId = userId}; 

            foreach (var Purchases in UsersPurchases)
            {
                var product = _productRepository.GetEntity(Purchases.ProductId);
                var quantity = Purchases.Quantity;

                var amountLeft = _productRepository.GetAmount(Purchases.ProductId); 
                if (quantity > amountLeft) 
                    return false;

                var OrderLine = new OrderLine() { ProductId = product.Id, Quantity = quantity};
                order.Lines.Add(OrderLine);
                order.OrderPrice += product.Cost * quantity;
            }

            _orderRepository.Create(order);

            order.Id = _orderRepository.GetEntityId(userId);
            for (int i = 0; i < order.Lines.Count; i++)
            {
                _orderRepository.CreateOrderItemsLine(order, order.Lines[i]);

                var productId = order.Lines[i].ProductId;
                var newAmount = _productRepository.GetAmount(productId) - order.Lines[i].Quantity;
                _productRepository.DecreaseAmount(productId, newAmount);
            }

            _cartRepository.DeleteAll(userId);

            return true;
        }

        public List<Order> GetAllOrders(int userId)
        {
            var orderWithoutItems = _orderRepository.GetOrderListForSpecificUser(userId);
            var orderItems = _orderRepository.GetOrderItems(userId);

            for (int orderCount = 0; orderCount < orderWithoutItems.Count; orderCount++)
            {
                for (int itemsCount = 0; itemsCount < orderItems.Count; itemsCount++)
                {
                    if (orderItems[itemsCount].OrderId == orderWithoutItems[orderCount].Id)
                    {
                        orderWithoutItems[orderCount].Lines.Add(orderItems[itemsCount]);
                    }
                }
            }

            return orderWithoutItems;

        }

        public void TransferTheOrder(int orderId)
        {
            _orderRepository.TransferTheOrder(orderId);
        }
    }


}
