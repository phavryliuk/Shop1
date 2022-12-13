﻿namespace Shop1.Data.Models
{
    public class OrderDetail
    {

        public int id { get; set; }
        public int orderId { get; set; }
        public int CarId { get; set; }
        public int price { get; set; }

        public virtual Car car  { get; set; }

        public virtual Order order { get; set; }


}
}
