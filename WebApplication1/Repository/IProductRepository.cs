using WebApplication1.Entities;

namespace WebApplication1.Repository;

public interface IProductRepository 
{
    List<Product> GetEntityList();
    Product GetEntity(int id);
    void DecreaseAmount(int productId, int newAmount);
    int GetAmount(int id);
    void Delete(int itemId);
}