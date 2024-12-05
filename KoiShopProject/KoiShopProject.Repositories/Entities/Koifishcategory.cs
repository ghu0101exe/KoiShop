using System;
using System.Collections.Generic;

namespace KoiShopProject.Repositories.Entities;

public partial class Koifishcategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Fish> Fish { get; set; } = new List<Fish>();
}
