using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using Shop1.Migrations;
using Shop1.Models;

namespace Shop1.Data.Models
{
    public class ShopCart
    {
        private readonly AppDbContent appDbContent;

        public ShopCart(AppDbContent appDbContent)
        {
            this.appDbContent = appDbContent;

        }
        public string ShopCartId { get; set; }

        public List<ShopCartItem> listShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
             ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
             var context = services.GetService<AppDbContent>();
             string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

             session.SetString("CartId", shopCartId);

             return new ShopCart(context)
             {
                 ShopCartId = shopCartId
             };
        }

        public void AddToCart(Car car)
        {
            appDbContent.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                car = car,
                price = car.price
            });
            appDbContent.SaveChanges();
        }

      

        public List<ShopCartItem> getShopitems()
        {
            return appDbContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.car).ToList();
        }
    }
}
