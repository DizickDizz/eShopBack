using WebApplication1.Entities;

namespace WebApplication1.Repository;

public interface ICartRepository 
{
    void Create(Cart cart);
    void Update(Cart cart);
    Cart GetCart(int userId, int productId);
    List<Cart> GetUsersPurchases(int userId);
    void Delete(int userId, int productId);
    void DeleteAll(int id);
}