using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TravelPal.Models.Travels;
using TravelPal.Models.User;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        private UserManager userManager;

        // Check if the signed in user is admin - If yes; hide remove button, show all user and user trips button 
        public TravelsWindow(UserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;
            if (userManager.signedInUser.GetType() == typeof(Admin))
            {
                btnAddTravel.Visibility = Visibility.Hidden;
                btnDetails.Visibility = Visibility.Hidden;
                btnRemove.Content = "User trips";
            }
            else
            {
                    btnAddTravel.Visibility = Visibility.Visible;
                    btnDetails.Visibility = Visibility.Visible;
                    btnRemove.Content = "Remove";
            }
            DateTime date = new DateTime();

            if(userManager.signedInUser == null)
            {
                this.Close();
                return;
            }
            // If signed in user admin show user in list, 
            if(userManager.signedInUser.GetType() == typeof(Admin))
            {
                Admin user = (Admin)userManager.signedInUser;
                lblUsername.Content = user.Username;
                userManager.users.ForEach(user =>
                {
                    if (user.GetType() == typeof(User))
                    {

                        User theUser = (User)user;

                        TreeViewItem treeViewItem = new();
                      
                        treeViewItem.Tag = user;
                        treeViewItem.Header = user.Username;
                        tTreeView.Items.Add(treeViewItem);
                        

                    }

                });
               

            }
            else
            {
                User user = (User)userManager.signedInUser;
                lblUsername.Content = user.Username;
                user.Travels.ForEach(travel =>
                {
                    TreeViewItem item = new();

                    item.Header = travel.GetInfo();
                    item.Tag = travel;
                    tTreeView.Items.Add(item);
                    
                }
                 );
            }


        }

   
        // Button to add new travels 
        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            AddTravelWindow addTravelWindow = new(userManager);
            addTravelWindow.Show();
            Close();
            
        }
        // Button to update current user - change name + password + country
        private void btnUserDetails_Click(object sender, RoutedEventArgs e)
        {
            UserDetailsWindow userDetailsWindow = new(userManager);

            userDetailsWindow.Show();
            this.Close();
        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            if (tTreeView.SelectedItem == null)
            {
                MessageBox.Show("To show details, please select an item from the list!");
                return;
            }

            TreeViewItem selectedItem = tTreeView.SelectedItem as TreeViewItem;

            TravelDetailsWindow travelDetailsTravelWindow = new(selectedItem.Tag as Travel);
            travelDetailsTravelWindow.Show();

        }
        // Button Remove to delete current trips from list
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (tTreeView.SelectedItem == null)
            {
                MessageBox.Show("To remove, please select an item from the list!");
                return;
            }
            TreeViewItem selectedItem = tTreeView.SelectedItem as TreeViewItem;

            if(userManager.signedInUser.GetType() == typeof(User))
            {
                userManager.removeTravel((User)userManager.signedInUser, selectedItem.Tag as Travel);
                tTreeView.Items.Remove(selectedItem);
            }
            else // if admin
            {
                User userToRemoveTravelFrom = (User)selectedItem.Tag;

                RemoveTravelWindow removeTravelWindow = new(userToRemoveTravelFrom);
                removeTravelWindow.Show();

            }



        }

        // Sign out button, closes window and opens up MainWindow
        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new(userManager);
            mainWindow.Show();
            this.Close();
            
        }

        // Info button with random info about travelpal
        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Info TravelPal, App to help manage your travels - Created 2022");
        }
    }
}
