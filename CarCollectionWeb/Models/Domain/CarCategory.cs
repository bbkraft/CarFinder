using CarCollectionWeb.Models.Domain;
using System;
using System.Collections.Generic;

namespace CarCollectionWeb;

public partial class CarCategory
{
    public int Id { get; set; }

    public string NameCategory { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
