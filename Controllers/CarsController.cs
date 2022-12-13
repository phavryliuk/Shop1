using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Shop1.Data.interfaces;
using Shop1.ViewModels;
using System.Linq;
using Shop1.Data.Models;


namespace Shop1.Controllers
{
    namespace Shop.Controllers
    {
        public class CarsController : Controller
        {
            private readonly IAllCars _allCars;
            public ICarsCategory allCategories { get; }

            public CarsController(IAllCars iAllCars, ICarsCategory iCarsCat)
            {
                _allCars = iAllCars;
                allCategories = iCarsCat;
            }

            [Route("Cars/List")]
            [Route("Cars/List/{category}")]
            public ViewResult List(string category)
            {
                IEnumerable<Car> cars = null;
                string CurrCategory = "";

                if (string.IsNullOrEmpty(category))
                {
                    cars = _allCars.Cars.OrderBy(i => i.id);
                }

                else
                {
                    if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                    {
                        cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Електромобілі")).OrderBy(i => i.id);
                        CurrCategory = "Електромобілі";
                    }
                    

                    else if (string.Equals("diesel", category, StringComparison.OrdinalIgnoreCase))
                    {
                        cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Дизельні")).OrderBy(i => i.id);
                        CurrCategory = "Дизельні";
                    }

                    else if (string.Equals("gasoline", category, StringComparison.OrdinalIgnoreCase))
                    {
                        cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Бензинові")).OrderBy(i => i.id);
                        CurrCategory = "Бензинові";
                    }

                    else if (string.Equals("motorcycle", category, StringComparison.OrdinalIgnoreCase))
                    {
                        cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Мотоцикли")).OrderBy(i => i.id);
                        CurrCategory = "Мотоцикли";
                    }

                    else if (string.Equals("bicycle", category, StringComparison.OrdinalIgnoreCase))
                    {
                        cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Велосипеди")).OrderBy(i => i.id);
                        CurrCategory = "Велосипеди";
                    }



                }

                var carObj = new CarsListViewModel
                {
                    allCars = cars,
                    CurrCategory = CurrCategory
                };





                ViewBag.Title = "Автомобілі";

                return View(carObj);
            }
        }
    }
} 