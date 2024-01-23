using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace UserDatabase.Api.Models
{
    public class OrderedItem
    {
        public Guid id { get; set; }
        public Guid order_id { get; set; }
        public decimal price { get; set; }

        public int quantity { get; set; }
        public virtual ShippingOrder ShippingOrder { get; set; }
    }
}
