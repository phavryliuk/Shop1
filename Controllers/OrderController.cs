using Microsoft.AspNetCore.Mvc;
using Shop1.Data.interfaces;
using Shop1.Data.Models;

namespace Shop1.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders _allOrders;
        private readonly ShopCart _shopCart;


        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this._allOrders = allOrders;
            this._shopCart = shopCart;
        }



        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {

            _shopCart.listShopItems = _shopCart.getShopitems();

            if (_shopCart.listShopItems.Count == 0)
            {
                ModelState.AddModelError("","Ви не додали в кошик жодного товару");
            }

            if (ModelState.IsValid)
            {
                _allOrders.createOrder(order);
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Дякуємо, Ваше замовлення прийнято. Очікуйте дзвінка від адміністратора!";
            return View();
        }
    }
}
