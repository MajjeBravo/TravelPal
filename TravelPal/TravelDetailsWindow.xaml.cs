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
using System.Windows.Shapes;
using TravelPal.Models.Enums;
using TravelPal.Models.Travels;
using TravelPal.Models.User;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelDetailsWindow.xaml
    /// </summary>
    public partial class TravelDetailsWindow : Window
    {
        public TravelDetailsWindow(Travel travel)
        {
            InitializeComponent();
            txtDepartureLocation.Text = travel.destination;
            txtTravelers.Text = travel.travellers.ToString();

            cbArrivalCountry.ItemsSource = Enum.GetValues(typeof(Country));
            cbArrivalCountry.SelectedItem =travel.countries;

            cmbTravelType.Items.Add("Vacation");
            cmbTravelType.Items.Add("Trip");
            cmbTravelType.SelectedItem = travel.GetType() == typeof(Trip) ? "Trip" : "Vacation";
            cmbTripType.ItemsSource = Enum.GetValues(typeof(TripType));
            tbTravelDays.Text = travel.travelDays.ToString();
            lbStartDate.Content = travel.startDate.ToString("dd/MM/yyyy");
            lbEndDate.Content = travel.endDate.ToString("dd/MM/yyyy");
           
            if (cmbTravelType.SelectedItem == "Trip")
            {
                cmbTripType.SelectedItem = ((Trip) travel).type;
                cmbAllInclusive.Visibility = Visibility.Hidden;

            }
            else
            {
                cmbAllInclusive.IsChecked = ((Vacation)travel).AllInclusive;
                cmbTripType.Visibility = Visibility.Hidden;

            }

            lvPackingList.ItemsSource = travel.PackingList;
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
