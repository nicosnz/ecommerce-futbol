using System;
using System.Collections.Generic;

namespace backend_ecommerce.Models;

public partial class Team
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Pais { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
