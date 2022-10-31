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
using System.Windows.Navigation;
using System.Windows.Shapes;
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
