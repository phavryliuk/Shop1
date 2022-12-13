using Microsoft.AspNetCore.Mvc;
using Shop1.Data.interfaces;

namespace Shop1.Controllers;

public class HomeController : Controller
{
    public IAllCars carRep { get; }

    public HomeController(IAllCars carRep)
    {
        this.carRep = carRep;
    }
    
    //Маршрутизація головної сторінки
    public ViewResult Index()
    {
        return View();
    }

    //Маршрутизація сторінки новин
    public ViewResult News()
    {
        return View();
    }

    //Маршрутизація сторінки умов 
    public IActionResult Privacy()
    {
        return View();
    }
}