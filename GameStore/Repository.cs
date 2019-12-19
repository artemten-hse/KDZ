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
        public List<GameOrder> Games;
        public List<Order> Orders;
        public List<Cashier> Cashiers;
        public List<GamePopularity> Popularity = new List<GamePopularity>();

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
            Games = Deserialize<List<GameOrder>>(GamesFileName);
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

        public void PopularityCheckForGame()
        {

            int soldcheck = 0;
            foreach (var element in Orders)
            {
                foreach (var secondElement in Games)
                {
                    if (element.OrderList.Contains(secondElement.Name))
                    {
                        string publisher = secondElement.Publisher;
                        string game = secondElement.Name;
                        string platform = secondElement.Platform;
                        soldcheck += 1;
                        Popularity.Add(new GamePopularity { Name = game, AmountSold = soldcheck, Publisher = publisher, Platform = platform });
                    }
                }
            }
        }
    }
}
