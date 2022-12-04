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

    public ViewResult Index()
    {
        return View();
    }
}