using System.Collections.Generic;
using Shop1.Data.Models;

namespace Shop1.Data.interfaces;

public interface IAllCars
{
    IEnumerable<Car> Cars { get; }
}