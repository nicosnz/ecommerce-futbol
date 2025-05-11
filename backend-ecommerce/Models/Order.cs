using System;
using System.Collections.Generic;

namespace backend_ecommerce.Models;

public partial class Order
{
    public long Id { get; set; }

    public long? CustomerId { get; set; }

    public DateTimeOffset? OrderDate { get; set; }

    public decimal Total { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
