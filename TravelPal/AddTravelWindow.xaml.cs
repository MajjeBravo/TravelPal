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
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
        private UserManager userManager;
        private object travelManager;

        public AddTravelWindow(UserManager userManager)
        {
            InitializeComponent();
            
            this.userManager = userManager;
            string departureCountry = txtDepartureLocation.Text;
            
            string[] arrivalCountries = Enum.GetNames(typeof(Country));
            cbArrivalCountry.ItemsSource = arrivalCountries;
            cbArrivalCountry.SelectedIndex = 0;

            string[] arrivalCountry = Enum.GetNames(typeof(Country));
            cbArrivalCountry.ItemsSource = arrivalCountries;



            string travelers = txtTravelers.Text;



            string[] travelTypes = Enum.GetNames(typeof(TripType));
            cmbTravelType.ItemsSource = travelTypes;



            string[] tripTypes = Enum.GetNames(typeof(TripType));
            cmbTripType.ItemsSource = tripTypes;



            this.userManager = userManager;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string departureLocation = txtDepartureLocation.Text;
            // Country arrivalCountry = (Country)cbArrivalCountry.SelectedItem;
            //int numberOfTravelers = Convert.ToInt32(txtTravelers.Text);

            User signedInUser = (User)userManager.signedInUser;
            userManager.addTravel(signedInUser, new Trip("hej", Country.Afghanistan, 4, DateTime.Now, DateTime.Now, 4, TripType.Leisure));
            TravelsWindow travelsWindow = new(userManager);
            
            travelsWindow.Show();
            this.Close();



            //if (selectedTripType == "Trip")
            //{
            //    string tripTypeString = cmbTripType.SelectedItem as string;



            //    TripType tripType = (TripType)Enum.Parse(typeof(TripType), tripTypeString);



            //    Travel newTravel = travelManager.AddTravel(departureCountry, country, numberOfTravelers, tripType);

            //    if (userManager.signedInUser is User)
            //    {
            //        User user = userManager.signedInUser as User;



            //        user.Travels.Add(newTravel);



            //        userManager.signedInUser = user;
            //    }
            //}
            //else if (selectedTravelType == "Vacation")
            //{
            //    bool allInclusive = (bool)cmbAllInclusive.IsChecked;



            //    Travel newTravel = travelManager.AddTravel(departureCountry, country, numberOfTravelers, allInclusive);



            //    if (userManager.signedInUser is User)
            //    {
            //        User user = userManager.signedInUser as User;



            //        user.Travels.Add(newTravel);



            //        userManager.signedInUser = user;
            //    }
            //}



            //TravelsWindow travelsWindow = new(userManager, travelManager);
            //travelsWindow.Show();



            Close();
        }



        private void cbTravelType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //selectedTravelType = cmbTravelType.SelectedItem as string;



            //if (selectedTravelType == "Trip")
            //{
            //    cmbTripType.Visibility = Visibility.Visible;
            //    cmbAllInclusive.Visibility = Visibility.Hidden;
            //}
            //else if (selectedTripType == "Vacation")
            //{
            //    cmbAllInclusive.Visibility = Visibility.Visible;
            //    cmbTripType.Visibility = Visibility.Hidden;
            //}
        }
  
      
    }
}
