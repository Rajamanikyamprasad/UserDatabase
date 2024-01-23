
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserDatabase.Api.Models
{
    public class ShippingOrder
    {
        [Key]
        public Guid order_id { get; set; }
        public DateTime order_date { get; set; }

        public virtual ICollection<OrderedItem>? OrderedItem { get; set; }
    }
}
