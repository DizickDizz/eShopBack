using WebApplication1.DTOs;
using WebApplication1.Entities;
using WebApplication1.Repository;

namespace WebApplication1.Services
{
    public class CartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public CartService(ICartRepository cartRepository, 
            IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;

        }

        public void AddItem(Product product, int quantity, int userId)
        {
            var existingCart = _cartRepository.GetCart(userId, product.Id);

            if (existingCart is null)
            {
                var cart = new Cart { UserId = userId, ProductId = product.Id, Quantity = quantity };
                _cartRepository.Create(cart);
                return;
            }

            if (existingCart.State == 1)
                existingCart.Quantity += quantity;

            _cartRepository.Update(existingCart);
        }

        public void RemoveLine(int userId, int productId)
        {
            _cartRepository.Delete(userId, productId);
        }

        public void RemoveAll(int userId)
        {
            _cartRepository.DeleteAll(userId);
        }

        public List<CartItem> GetCart(int userId)
        {
            var cart = _cartRepository.GetUsersPurchases(userId);
            var cartItems = new List<CartItem>();
            for (int i = 0; i < cart.Count; i++)
            {
                cartItems.Add(new CartItem() {Product = _productRepository.GetEntity(cart[i].ProductId), Quantity = cart[i].Quantity});
            }

            return cartItems;
        }

    }
}
