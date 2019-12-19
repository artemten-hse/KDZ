using GameStore.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameStore
{
    class Repository
    {
        public List<Client> Clients;
        public List<Game> Games;
        public List<Order> Orders;
        public List<Cashier> Cashiers;

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
        private const string GamesFileName = "data/Games.json";
        private const string OrdersFileName = "data/Orders.json";
        private const string ClientsFileName = "data/Clients.json";

        private void LoadData() {
            Orders = Deserialize<List<Order>>(OrdersFileName);
            Games = Deserialize<List<Game>>(GamesFileName);
            Clients = Deserialize<List<Client>>(ClientsFileName);
        }



    }
}
