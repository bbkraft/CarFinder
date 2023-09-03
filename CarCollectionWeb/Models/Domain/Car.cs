using CarCollectionWeb.Models.ViewModel;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;

namespace CarCollectionWeb.Models.Domain;

public partial class Car
{
    public int Id { get; set; }

    public string? CarBrand { get; set; }

    public string? CarModel { get; set; }

    public int Year { get; set; }

    public int EngineСapacity { get; set; }

    public FuelTypeEnum FuelType { get; set; }

    public int CarCategoryId { get; set; }

    public virtual CarCategory CarCategory { get; set; } = null!;
    
}

public enum FuelTypeEnum
{
    Petrol = 0,
    Diesel = 1,
    Gasoline = 2,
}
