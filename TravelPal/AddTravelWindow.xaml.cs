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
            
            
            cbArrivalCountry.ItemsSource = Enum.GetValues(typeof(Country));
            cbArrivalCountry.SelectedIndex = 0;

        



            string travelers = txtTravelers.Text;



            cmbTravelType.Items.Add("Vacation");
            cmbTravelType.Items.Add("Trip");
            cmbTravelType.SelectedIndex = 0;
            cmbTripType.Items.Add("Leisure");
            cmbTripType.Items.Add("Work");
            cmbTripType.SelectedIndex = 0;




            this.userManager = userManager;
        }

        
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            if(txtDepartureLocation.Text.Length < 3)
            {
                MessageBox.Show("Departure must be more than 2 letters.");
                return;
            }
            if(!int.TryParse(txtTravelers.Text, out i) || txtTravelers.Text.Length < 1)
            {
                MessageBox.Show("Travelers must be number.");
                return;

            }

            string departureLocation = txtDepartureLocation.Text;
            Country arrivalCountry = (Country)cbArrivalCountry.SelectedItem;
            int numberOfTravelers = Convert.ToInt32(txtTravelers.Text != null ? txtTravelers.Text : "");


            User signedInUser = (User)userManager.signedInUser;


            if(cmbTravelType.Text == "Trip")
            {
                userManager.addTravel(signedInUser, new Trip(departureLocation, arrivalCountry, numberOfTravelers, DateTime.Now, DateTime.Now, 1, cmbTripType.Text == "Leisure" ? TripType.Leisure : TripType.Work));

            }
            else
            {
                userManager.addTravel(signedInUser, new Vacation(departureLocation, arrivalCountry, numberOfTravelers, DateTime.Now, DateTime.Now, 1, (bool)cmbAllInclusive.IsChecked));

            }


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



        private void cmbTravelType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String selectedTravelType = cmbTravelType.SelectedItem as string;

            if (selectedTravelType == "Trip")
            {
                cmbTripType.Visibility = Visibility.Visible;
                cmbAllInclusive.Visibility = Visibility.Hidden;
            }
            else if (selectedTravelType == "Vacation")
            {
                cmbAllInclusive.Visibility = Visibility.Visible;
                cmbTripType.Visibility = Visibility.Hidden;
            }
        }

       
    }
}
