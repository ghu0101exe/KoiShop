using System;
using System.Collections.Generic;

namespace KoiShopProject.Repositories.Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public int StaffId { get; set; }

    public DateOnly? OrderDate { get; set; }

    public string? Status { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();

    public virtual Staff Staff { get; set; } = null!;
}
