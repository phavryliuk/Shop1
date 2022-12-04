using System.Collections.Generic;
using Shop1.Data.Models;

namespace Shop1.Data.interfaces;

public interface ICarsCategory
{
    public IEnumerable<Category> AllCategories { get; }
}