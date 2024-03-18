using System.Windows;
using System.Data.Entity;
using System.Linq;
using PRAKTIKA2;
using System.Collections.ObjectModel;
using System;
using System.Windows.Controls;

namespace PRAKTIKA2
{
    public partial class PassengersWindow : Window
    {
        private AVIACASSA2Entities dbContext;
        
        public PassengersWindow()
        {
            InitializeComponent();
            dbContext = new AVIACASSA2Entities();
            LoadPassengers();
        }
        public class Passenger
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string FirstName { get; internal set; }
            public string LastName { get; internal set; }
            // Другие свойства, если они есть
        }
        private void LoadPassengers()
        {
            using (var context = new AVIACASSA2Entities())
            {
                try
                {
                    passengersDataGrid.ItemsSource = context.Passengers.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
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
            // Предыдущее окно не определено, поэтому закрываем текущее окно
            this.Close();
        }

        private void ShowNextWindow()
        {
            FlightsWindow flightsWindow = new FlightsWindow();
            flightsWindow.Show();
            this.Close();
        }

        private void Dob(object sender, RoutedEventArgs e)
        {
            /*using (var context = new AVIACASSA2Entities())
            {
                var newPassenger = new Passenger 
                {
                    FirstName = FirstName.Text, 
                    LastName = LastName.Text,
                    Email = Email.Text,
                    Phone = Phone.Text
                };

                context.Passengers.Add(newPassenger);
                passengersDataGrid.ItemsSource = context.Passengers.ToList();
            }*/
        }


        private void Izm(object sender, RoutedEventArgs e)
        {
            if (passengersDataGrid.SelectedItem != null)
            {
                var selectedPassenger = (Passenger)passengersDataGrid.SelectedItem;
                using (var context = new AVIACASSA2Entities())
                {
                    var passengerToUpdate = context.Passengers.Find(selectedPassenger.Id);
                    if (passengerToUpdate != null)
                    {
                        passengerToUpdate.FirstName = FirstNameIzm.Text;
                        passengerToUpdate.LastName = LastNameIzm.Text;
                        passengerToUpdate.Email = EmailIzm.Text;
                        passengerToUpdate.Phone = PhoneIzm.Text;

                        context.SaveChanges();
                        passengersDataGrid.ItemsSource = context.Passengers.ToList();
                    }
                }
            }
        }

        private void Del(object sender, RoutedEventArgs e)
        {
            if (passengersDataGrid.SelectedItem != null)
            {
                var selectedPassenger = (Passenger)passengersDataGrid.SelectedItem;
                using (var context = new AVIACASSA2Entities())
                {
                    var passengerToDelete = context.Passengers.Find(selectedPassenger.Id);
                    if (passengerToDelete != null)
                    {
                        context.Passengers.Remove(passengerToDelete);
                        context.SaveChanges();
                        passengersDataGrid.ItemsSource = context.Passengers.ToList();
                    }
                }
            }
        }
        private void passengersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (passengersDataGrid.SelectedItem != null)
            {
                var selectedPassenger = (Passenger)passengersDataGrid.SelectedItem;
                FirstNameIzm.Text = selectedPassenger.FirstName;
                LastNameIzm.Text = selectedPassenger.LastName;
                EmailIzm.Text = selectedPassenger.Email;
                PhoneIzm.Text = selectedPassenger.Phone;
            }
        }
    }
}