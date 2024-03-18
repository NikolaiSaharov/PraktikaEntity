using System;
using System.Collections.Generic;
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

namespace PRAKTIKA2
{
    public partial class MainWindow : Window
    {
        private Window currentWindow;
        private AVIACASSA2Entities Bd = new AVIACASSA2Entities();
        public MainWindow()
        {
            InitializeComponent();
            ShowCurrentWindow(new PassengersWindow());
        }

        private void ShowCurrentWindow(Window window)
        {
            if (currentWindow != null)
            {
                currentWindow.Close();
            }

            currentWindow = window;
            currentWindow.Show();
        }

        private void btnPassengers_Click(object sender, RoutedEventArgs e)
        {
            ShowCurrentWindow(new PassengersWindow());
        }

        private void btnFlights_Click(object sender, RoutedEventArgs e)
        {
            ShowCurrentWindow(new FlightsWindow());
        }

        private void btnTickets_Click(object sender, RoutedEventArgs e)
        {
            ShowCurrentWindow(new TicketsWindow());
        }
    }
}
