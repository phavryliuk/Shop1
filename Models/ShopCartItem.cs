using Shop1.Data.Models;

namespace Shop1.Models
{
    public class ShopCartItem
    {

        public int id { get; set; }
        public Car car { get; set; }

        public int price { get; set; } 

        public string ShopCartId { get; set; }

    }
}
