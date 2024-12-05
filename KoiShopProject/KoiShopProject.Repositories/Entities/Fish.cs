using System;
using System.Collections.Generic;

namespace KoiShopProject.Repositories.Entities;

public partial class Fish
{
    public int KoiId { get; set; }

    public int IdCategory { get; set; }

    public string Name { get; set; } = null!;

    public string Origin { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public float Age { get; set; }

    public float Size { get; set; }

    public string Breed { get; set; } = null!;

    public float FoodAmountPerDay { get; set; }

    public string? Image { get; set; }

    public float Price { get; set; }

    public virtual Koifishcategory IdCategoryNavigation { get; set; } = null!;

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();
}
