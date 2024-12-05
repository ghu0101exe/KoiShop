using System;
using System.Collections.Generic;

namespace KoiShopProject.Repositories.Entities;

public partial class Staff
{
    public int StaffId { get; set; }

    public string StaffName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Blogpost> Blogposts { get; set; } = new List<Blogpost>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
