using GameStore;
using GameStore.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OwnerGUI
{
    /// <summary>
    /// Логика взаимодействия для ClientInfoWindow.xaml
    /// </summary>
    public partial class ClientInfoWindow : Window
    {
        Repository repo = new Repository();
        public List<Order> clientOrders = new List<Order>();
        public ClientInfoWindow(Client client)
        {
            InitializeComponent();
            foreach (var element in repo.Orders)
            {
                if (element.Client == client.Name)
                {
                    clientOrders.Add(element);
                }
            }
            clientOrdersDataGrid.ItemsSource = clientOrders;
        }

        private void ClientOrderDetails_Click(object sender, RoutedEventArgs e)
        {
            var selectedOrder = clientOrdersDataGrid.SelectedItem as Order;
            if (selectedOrder == null)
            {
                MessageBox.Show("Необходимо выбрать заказ!");
                return;
            }
            var orderDetailsWindow = new OrderDetails(selectedOrder);
            orderDetailsWindow.ShowDialog();
        }
    }
}
