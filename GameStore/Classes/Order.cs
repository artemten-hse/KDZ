using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.Classes
{
    public class Order
    {
        public DateTime OrderTime { get; set; }
        public string Client { get; set; }
        public string Cashier { get; set; }
        public List<string> OrderList;
        public decimal? TotalPrice { get; set; }
    }
}
