using System;
using Shop1.Data.interfaces;
using Shop1.Data.Models;
using Shop1.Models;

namespace Shop1.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDbContent appDbContent;
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDbContent appDbContent, ShopCart shopCart)
        {
            this.appDbContent = appDbContent;
            this.shopCart = shopCart;
        }

        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDbContent.Order.Add(order);

            var items = shopCart.listShopItems;

            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    CarId = el.car.id,
                    orderId = order.id,
                    price = el.car.price
                };

                appDbContent.OrderDetail.Add(orderDetail);
            }
            appDbContent.SaveChanges();

        }
    }
}
