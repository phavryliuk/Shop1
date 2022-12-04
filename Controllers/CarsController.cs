using Microsoft.AspNetCore.Mvc;
using Shop1.Data.interfaces;
using Shop1.ViewModels;
using System.Linq;


namespace Shop1.Controllers
{
    namespace Shop.Controllers
    {
        public class CarsController : Controller
        {
            private readonly IAllCars _allCars;
            private readonly ICarsCategory _allCategories;

            public CarsController(IAllCars iAllCars, ICarsCategory iCarsCat)
            {
                _allCars = iAllCars;
                _allCategories = iCarsCat;
            }

            public ViewResult List()
            {
                CarsListViewModel obj = new CarsListViewModel();
                obj.allCars = _allCars.Cars;
                obj.CurrCategory = "Автомобілі";
                return View(obj);
            }
        }
    }
} 