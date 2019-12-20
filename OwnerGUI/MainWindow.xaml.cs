using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GameStore;
using GameStore.Classes;

namespace OwnerGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Repository repo = new Repository();
        public MainWindow()
        {
            InitializeComponent();
            Orders();
        }

        private void ProfitButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate = Convert.ToDateTime(StarDateTextBox.Text);
            DateTime endDate = Convert.ToDateTime(EndDateTextBox.Text);
            decimal? profit = repo.GetProfitByDateGap(startDate, endDate);
            MessageBox.Show($"Your profit is {profit}");
        }

        private void Orders()
        {
            OrderDataGrid.ItemsSource = null;
            OrderDataGrid.ItemsSource = repo.Orders;
            repo.PopularityCheckForGame();
            PopularityDataGrid.ItemsSource = null;
            PopularityDataGrid.ItemsSource = repo.Games;
            clientDataGrid.ItemsSource = null;
            clientDataGrid.ItemsSource = repo.Clients;
        }

        private void OrderDetailButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedOrder = OrderDataGrid.SelectedItem as Order;
            if (selectedOrder == null)
            {
                MessageBox.Show("Необходимо выбрать заказ!");
                return;
            }
            var orderDetailsWindow = new OrderDetails(selectedOrder);
            if (orderDetailsWindow.ShowDialog() == true)
            {
                Orders();
            }
        }

        private void ClientInfoButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedClient = clientDataGrid.SelectedItem as Client;
            if (selectedClient == null)
            {
                MessageBox.Show("Необходимо выбрать клиента!");
                return;
            }
            var clientInfoWindow = new ClientInfoWindow(selectedClient);
            if (clientInfoWindow.ShowDialog() == true)
            {
                Orders();
            }
        }
    }
}
