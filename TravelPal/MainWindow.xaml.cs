using System;
using System.Windows;
using TravelPal.Models.Enums;
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
            Models.Travels.Trip gibraltar = new("Gibraltar", Country.Spain, 3, DateTime.Now, DateTime.Now.AddDays(4), 4, TripType.Leisure);
            Models.Travels.Vacation kandahar = new("Kandahar", Country.Afghanistan, 8, DateTime.Now, DateTime.Now.AddDays(4), 4, true);
            user.Travels.Add(gibraltar);
            user.Travels.Add(kandahar);

            userManager.addUser(admin);
            userManager.addUser(user);

        }

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
                lblWarning.Content = "Username or password wrong!";
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new(userManager);

            registerWindow.Show();
            
        }
    }
}
