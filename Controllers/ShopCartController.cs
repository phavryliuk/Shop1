﻿
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Shop1.Data.interfaces;
using Shop1.Data.Models;
using Shop1.ViewModels;


namespace Shop1.Controllers
{
    public class ShopCartController : Controller
    {

        private readonly IAllCars _carRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllCars carRep, ShopCart shopCart)
        {
            _carRep = carRep;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var items = _shopCart.getShopitems();
            _shopCart.listShopItems = items;

            var obj = new ShopCartViewModel
            {
                ShopCart = _shopCart
            };

            return View(obj);

        }

        public RedirectToActionResult addToCart(int id)
        {
            var item = _carRep.Cars.FirstOrDefault( i => i.id == id);
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }

            return RedirectToAction("Index");
        }
    }
}
