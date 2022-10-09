using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.DTOs;
using ColumnAttribute = SQLite.ColumnAttribute;

namespace WebApplication1.Entities
{
    public class Order
    {
        public int Id { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("order_price")]
        public float OrderPrice { get; set; }
        [Column("order_status")]
        public int OrderStatus { get; set; }
        public List<OrderLine> Lines { get; set; }

        public Order()
        {
            Lines = new();
        }
    }
}
