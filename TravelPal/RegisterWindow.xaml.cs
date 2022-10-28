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

        public RegisterWindow(UserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;

            cmbCountry.ItemsSource = Enum.GetValues(typeof(Country));
            cmbCountry.SelectedIndex = 0;
        }
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Country country = (Country)cmbCountry.SelectedItem;
            User newUser = new User(txtUsername.Text, pswPassword.ToString(), country);

            if (userManager.addUser(newUser))
            {
                this.Close();
            }
            else
            {
                lblWarning.Content = "Could not create user!";
            }
        }

    }
}
