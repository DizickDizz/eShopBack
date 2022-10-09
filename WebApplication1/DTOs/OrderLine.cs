using ColumnAttribute = SQLite.ColumnAttribute;

namespace WebApplication1.DTOs
{
    public class OrderLine
    {
        public int Quantity { get; set; }
        [Column("order_id")]
        public int OrderId { get; set; }
        [Column("product_id")]
        public int ProductId { get; set; }
    }
}
