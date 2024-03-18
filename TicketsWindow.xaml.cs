using System.Windows;
using System.Data.Entity;

namespace PRAKTIKA2
{
    public partial class TicketsWindow : Window
    {
        private AVIACASSA2Entities dbContext;

        public TicketsWindow()
        {
            InitializeComponent();
            dbContext = new AVIACASSA2Entities();
            LoadTickets();
        }

        private void LoadTickets()
        {
            dbContext.Tickets.Load();
            ticketsDataGrid.ItemsSource = dbContext.Tickets.Local;
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
            FlightsWindow flightsWindow = new FlightsWindow();
            flightsWindow.Show();
            this.Close();
        }

        private void ShowNextWindow()
        {
            // Если следующее окно не определено, можно закрыть текущее окно
            this.Close();
        }
    }
}