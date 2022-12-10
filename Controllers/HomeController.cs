using Microsoft.AspNetCore.Mvc;
using Shop1.Data.interfaces;

namespace Shop1.Controllers;

public class HomeController : Controller
{
    private IAllCars _carRep;

    public HomeController(IAllCars carRep)
    {
        _carRep = carRep;
    }
    
    //Маршрутизація головної сторінки
    public ViewResult Index()
    {
        return View();
    }

    //Маршрутизація сторінки авто
    public ViewResult CarPage()
    {
        return View();
    }

    //Маршрутизація сторінки умов 
    public IActionResult Privacy()
    {
        return View();
    }
}