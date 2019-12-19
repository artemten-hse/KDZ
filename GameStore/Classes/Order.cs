using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.Classes
{
    public class Order
    {
        public DateTime OrderTime { get; set; }
        public Client Client { get; set; }
        public Cashier Cashier { get; set; }
        public List<Game> OrderList;
        public int TotalPrice { get; set; }
    }
}
