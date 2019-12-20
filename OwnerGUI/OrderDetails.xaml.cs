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
    /// Логика взаимодействия для OrderDetails.xaml
    /// </summary>
    public partial class OrderDetails : Window
    {
        public OrderDetails(Order order)
        {
            InitializeComponent();
            detailsListBox.ItemsSource = order.OrderList;
        }
    }
}
