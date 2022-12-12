using Microsoft.AspNetCore.Mvc;
using Shop1.Data.interfaces;
using Shop1.Data.Models;

namespace Shop1.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;


        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }



        public IActionResult Checkout()
        {
            return View();
        }
    }
}
