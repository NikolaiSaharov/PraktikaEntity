using System.Windows;
using System.Data.Entity;

namespace PRAKTIKA2
{
    public partial class FlightsWindow : Window
    {
        private AVIACASSA2Entities dbContext;

        public FlightsWindow()
        {
            InitializeComponent();
            dbContext = new AVIACASSA2Entities();
            LoadFlights();
        }

        private void LoadFlights()
        {
            dbContext.Flights.Load();
            flightsDataGrid.ItemsSource = dbContext.Flights.Local;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ShowPreviousWindow();
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            ShowNextWindow();
        }

        private void ShowPreviousWindow()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void ShowNextWindow()
        {
            TicketsWindow ticketsWindow = new TicketsWindow();
            ticketsWindow.Show();
            this.Close();
        }
    }
}