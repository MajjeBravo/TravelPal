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
    /// Interaction logic for UserDetailsWindow.xaml
    /// </summary>
    public partial class UserDetailsWindow : Window
    {
        private UserManager userManager = new();
        public UserDetailsWindow(UserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;
            IUser user = userManager.signedInUser;
            txtUsername.Text = user.Username;

            cmbCountry.ItemsSource = Enum.GetValues(typeof(Country));
            cmbCountry.SelectedIndex = cmbCountry.Items.IndexOf(user.Location);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            if (pswNewPassword.Password.Length > 0)
            {
                if(pswNewPassword.Password == pswCmfPassword.Password)
                {
                    bool[] validateInputs = userManager.ValidateUserInput(userManager.signedInUser, txtUsername.Text, pswNewPassword.Password);

                    if (!validateInputs[0])
                    {
                        MessageBox.Show("Username is already taken");
                        return;
                    }
                    if(!validateInputs[1])
                    {
                        MessageBox.Show("Password must be more than 3 and less than 20 characters");
                        return;
                    }

                    if(pswNewPassword.Password != userManager.signedInUser.Password)
                    {
                        userManager.updatePassword(userManager.signedInUser, pswNewPassword.Password);
                    }

                    if (txtUsername.Text != userManager.signedInUser.Username)
                    {
                        userManager.updateUsername(userManager.signedInUser, txtUsername.Text);
                    }


                    TravelsWindow travelsWindow = new(userManager);
                    travelsWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Passwords dont match");
                }
                userManager.updateCountry(userManager.signedInUser, (Country)cmbCountry.SelectedItem);

            }
            else
            {
                MessageBox.Show("Enter your password to save changes");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new TravelsWindow(userManager);
            this.Close();
            travelsWindow.Show();
            return;
        }
        
    }
}
