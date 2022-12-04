using System.Collections.Generic;
using Shop1.Data.Models;

namespace Shop1.ViewModels;

public class CarsListViewModel
{
    public IEnumerable<Car> allCars { get; set; }
    public string CurrCategory { get; set; }
} 