using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.Classes
{
    public class Game
    {
        public string Name { get; set; }
        public string Publisher { get; set; }
        public int AmountLeft { get; set; }
        public string Platform { get; set; }
    }
}
