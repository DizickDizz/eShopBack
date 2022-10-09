using System.ComponentModel.DataAnnotations.Schema;
using ColumnAttribute = SQLite.ColumnAttribute;

namespace WebApplication1.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("product_id")]
        public int ProductId { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("state")]
        public int State { get; set; }
    }
}
