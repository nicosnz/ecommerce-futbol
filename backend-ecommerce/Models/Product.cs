using System;
using System.Collections.Generic;

namespace backend_ecommerce.Models;

public partial class Product
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int Stock { get; set; }

    public long? TeamId { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Team? Team { get; set; }
}
