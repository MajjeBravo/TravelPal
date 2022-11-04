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
using TravelPal.Models.User;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private UserManager userManager;


        // Preselected country in checkbox as index 0 "afghanistan" to avoid user to register without country
        public RegisterWindow(UserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;
            
            cmbCountry.ItemsSource = Enum.GetValues(typeof(Country));
            cmbCountry.SelectedIndex = 0;
        }

        // Register button that check criterias has been met, if no warnings, if yes add user and close window
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Country country = (Country)cmbCountry.SelectedItem;

            User newUser = new User(txtUsername.Text, pswPassword.Password.ToString(), country);

            if (userManager.addUser(newUser))
            {
                MainWindow mainWindow = new MainWindow(userManager);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                lblWarning.Content = "Could not create user, Username must be min. 3 long and Password min 5 long!";
            }
        }
       
        // Button to close window if user wish to cancel - return to mainwindow
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(userManager);
            mainWindow.Show();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

