using WebApplication1.Entities;

namespace WebApplication1.DTOs;

public class CartItem
{
    public Product Product { get; set; }
    public int Quantity { get; set; }
}