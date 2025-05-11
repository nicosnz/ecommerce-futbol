﻿using System;
using System.Collections.Generic;

namespace backend_ecommerce.Models;

public partial class OrderItem
{
    public long Id { get; set; }

    public long? OrderId { get; set; }

    public long? ProductId { get; set; }

    public int Cantidad { get; set; }

    public decimal Price { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}
