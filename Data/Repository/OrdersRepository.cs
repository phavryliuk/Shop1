using System;
using Shop1.Data.interfaces;
using Shop1.Data.Models;

namespace Shop1.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDbContent _appDbContent;
        private readonly ShopCart _shopCart;

        public OrdersRepository(AppDbContent appDbContent, ShopCart shopCart)
        {
            this._appDbContent = appDbContent;
            this._shopCart = shopCart;
        }

        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            _appDbContent.Order.Add(order);

            var items = _shopCart.listShopItems;

            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    CarId = el.car.id,
                    orderId = order.id,
                    price = el.car.price
                };
                _appDbContent.OrderDetail.Add(orderDetail);
            }

            //_appDbContent.SaveChanges();

        }
    }
}
