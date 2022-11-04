using System;
using System.Collections.Generic;
using System.Windows;
using TravelPal.Models.Enums;
using TravelPal.Models.PackingListItems;
using TravelPal.Models.User;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   
        UserManager userManager = new();
        public MainWindow()
        {
            // Two pre-set default accounts 
            InitializeComponent();
            Admin admin = new Admin("admin","password", Country.Sweden);
            User user = new User("Gandalf", "password", Country.Sweden);
            List<PackingListItem> packingList = new();
            packingList.Add(new TravelDocument("Passport", false));
            Models.Travels.Trip gibraltar = new("Gibraltar", Country.Spain, 3, DateTime.Now, DateTime.Now.AddDays(4), packingList,TripType.Leisure);
            Models.Travels.Vacation kandahar = new("Kandahar", Country.Denmark, 8, DateTime.Now, DateTime.Now.AddDays(4), packingList, true);
            user.Travels.Add(gibraltar);
            user.Travels.Add(kandahar);

            userManager.addUser(admin);
            userManager.addUser(user);

        }
        public MainWindow(UserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;

        }
        // Sign in button to login with contingencies
        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {

            if (userManager.signInUser(txtUsername.Text, pswPassword.Password))
            {

                TravelsWindow travelsWindow = new(userManager);
                travelsWindow.Show();
                this.Close();
                
            }
            else
            {
                lblWarning.Content = "Username or Password Is Incorrect! Try Again!";
            }
        }

        // Register button - open new register window and close main login window
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new(userManager);
            this.Close();
            registerWindow.Show();
            
        }
    }
}
