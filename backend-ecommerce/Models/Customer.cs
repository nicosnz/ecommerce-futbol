using System;
using System.Collections.Generic;

namespace backend_ecommerce.Models;

public partial class Customer
{
    public long Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? Telefono { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
