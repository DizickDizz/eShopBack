namespace WebApplication1.Entities
{
    public class User
    {
        public Guid Id = Guid.NewGuid();
        public Cart Cart { get; set; }
        public List<Order> OrderList { get; set; }
    }
}
