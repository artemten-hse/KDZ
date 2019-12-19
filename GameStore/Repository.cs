using GameStore.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameStore
{
    public class Repository
    {
        public List<Client> Clients;
        public List<Game> Games;
        public List<Order> Orders;
        public List<Cashier> Cashiers;
        public List<Game> Popularity;

        public Repository()
        {
            LoadData();
        }
        private T Deserialize<T>(string fileName)
        {
            using (var sr = new StreamReader(fileName))
            {
                using (var jsonReader = new JsonTextReader(sr))
                {
                    var serializer = new JsonSerializer();
                    return serializer.Deserialize<T>(jsonReader);
                }
            }
        }

        private void Serialize<T>(string fileName, T data)
        {
            using (var sw = new StreamWriter(fileName))
            {
                using (var jsonWriter = new JsonTextWriter(sw))
                {
                    jsonWriter.Formatting = Formatting.Indented;

                    var serializer = new JsonSerializer();
                    serializer.Serialize(jsonWriter, data);
                }
            }
        }

        private const string GamesFileName = "Data/Games.json";
        private const string OrdersFileName = "Data/Orders.json";
        private const string ClientsFileName = "Data/Clients.json";
        private const string CashierFileName = "Data/Cashier.json";
        private void LoadData()
        {
            Clients = Deserialize<List<Client>>(ClientsFileName);
            Games = Deserialize<List<Game>>(GamesFileName);
            Orders = Deserialize<List<Order>>(OrdersFileName);
            Cashiers = Deserialize<List<Cashier>>(CashierFileName);
        }

        public decimal? GetProfitByDateGap(DateTime startDate, DateTime endDate)
        {
            decimal? profit = 0;
            foreach (var element in Orders)
            {
                if (element.OrderTime >= startDate && element.OrderTime <= endDate)
                {
                    profit += element.TotalPrice;
                }
            }
            return profit;
        }


    }
}
