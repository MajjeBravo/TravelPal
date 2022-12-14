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
using TravelPal.Models.PackingListItems;
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
            cDatePicker.SelectedDate = DateTime.Now;



            setPassportItem(userManager.signedInUser.Location, (Country)cbArrivalCountry.SelectedItem);
            this.userManager = userManager;

            
        }


        // check if passport is required: (EU - EU not req) all other cases passport req.
        public bool isPassportRequired(Country departureCountry, Country destinationCountry)
        {


            return !(isEuCountry(departureCountry) && isEuCountry(destinationCountry));
        }

        public bool isEuCountry(Country country)
        {

            return Enum.GetNames(typeof(EuCountry)).Contains(country.ToString());

        }

        // Automaticly add passport to packinglist item
        public void setPassportItem(Country departureCountry,Country destinationCountry )
        {
            if(hasPassportItemInPackingList())
            {
                getPassportItem().Required = isPassportRequired(departureCountry, destinationCountry);
                lvPackingList.Items.Refresh();
            }
            else
            {
                TravelDocument passportDocument = new TravelDocument("Passport", isPassportRequired(departureCountry, destinationCountry));
                lvPackingList.Items.Add(passportDocument);

            }
        }

        // Adding passport to packinglist depending on requirment
        public TravelDocument getPassportItem()
        {
            return (TravelDocument)lvPackingList.Items.GetItemAt(0);
        }
        public bool hasPassportItemInPackingList()
        {

            return lvPackingList.Items.Count > 0;

        }

        // Add item from user input to packinglist
        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            if (tbPackingListItemLabel.Text.Length < 1)
                MessageBox.Show("Please type in an item to add");
            return;
               
;            if(cbDocument.IsChecked.Value)
            {
                lvPackingList.Items.Add(new TravelDocument(tbPackingListItemLabel.Text, cbRequired.IsChecked.Value));
            }
            else
            {

                int quantity = 0;
              
                if (!int.TryParse(tbQuantity.Text, out quantity))
                {
                    MessageBox.Show("Quantity must be atleast 1.");
                    return;

                }


                lvPackingList.Items.Add(new OtherItem(tbPackingListItemLabel.Text, quantity));

            }
        }

        // Save new added travel with contingencie
            private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            if(txtDepartureLocation.Text.Length < 3)
            {
                MessageBox.Show("Destination must be more than 2 letters.");
                return;
            }
            if(!int.TryParse(txtTravelers.Text, out i) || txtTravelers.Text.Length < 1)
            {
                MessageBox.Show("Travelers must be atleast 1.");
                return;

            }

            string departureLocation = txtDepartureLocation.Text;
            Country arrivalCountry = (Country)cbArrivalCountry.SelectedItem;
            int numberOfTravelers = Convert.ToInt32(txtTravelers.Text != null ? txtTravelers.Text : "");


            User signedInUser = (User)userManager.signedInUser;
            List<PackingListItem> packingList = lvPackingList.Items.Cast<PackingListItem>().Select(Item => (PackingListItem)Item).ToList();

            // Selecting travel days start and enddate with datepicker

            if (cDatePicker.SelectedDates == null || cDatePicker.SelectedDates.Count < 1 )
            {
                MessageBox.Show("Select travel day.");
                return;

            }

            DateTime startDate = cDatePicker.SelectedDates[0];
            DateTime endDate = cDatePicker.SelectedDates[cDatePicker.SelectedDates.Count()-1];

            if (cmbTravelType.Text == "Trip")
            {
                userManager.addTravel(signedInUser, new Trip(departureLocation, arrivalCountry, numberOfTravelers, startDate,endDate, packingList, cmbTripType.Text == "Leisure" ? TripType.Leisure : TripType.Work));

            }
            else
            {

                 userManager.addTravel(signedInUser, new Vacation(departureLocation, arrivalCountry, numberOfTravelers, startDate, endDate, packingList, (bool)cmbAllInclusive.IsChecked));

            }


            
            this.Close();



           



        
        }
        // Turn on off visibility for Document selection checkbox 
        private void cbDocument_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if(cbDocument.IsChecked.Value)
            {
                cbRequired.Visibility = Visibility.Visible;
                tbQuantity.Visibility = Visibility.Hidden;

            }
            else
            {
                cbRequired.Visibility = Visibility.Hidden;
                tbQuantity.Visibility = Visibility.Visible;
            }
        }

        // Selecting new arrival country and updating layout to refresh page
        private void cbArrivalCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            setPassportItem(userManager.signedInUser.Location, (Country)cbArrivalCountry.SelectedItem);
            lvPackingList.UpdateLayout();


        }

        // Triptype selectionchange based on type of travel 
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
        // window closing with button and window "x"
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
            
                TravelsWindow travelsWindow = new TravelsWindow(userManager);
                travelsWindow.Show();
          
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    
}
