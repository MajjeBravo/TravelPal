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


        public TravelsWindow(UserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;
            if (userManager.signedInUser.GetType() == typeof(Admin))
            {
                btnAddTravel.Visibility = Visibility.Hidden;
            }
            DateTime date = new DateTime();

            if(userManager.signedInUser == null)
            {
                this.Close();
                return;
            }

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
                        //treeViewItem.ItemsSource = theUser.Travels.Select((travel, i) => (i+1) + ": " + travel.GetInfo());
                        treeViewItem.Tag = user;
                        treeViewItem.Header = user.Username;
                        tTreeView.Items.Add(treeViewItem);
                        

                    }

                });
               

            }
            else
            {
                User user = (User)userManager.signedInUser;
                user.Travels.ForEach(travel =>
                {
                    TreeViewItem item = new();

                    item.Header = travel.GetInfo();
                    item.Tag = travel;
                    tTreeView.Items.Add(item);
                    lblUsername.Content = user.Username;
                }
                 );
            }


        }

   

        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            AddTravelWindow addTravelWindow = new(userManager);
            addTravelWindow.Show();
            Close();
            
        }

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

        }

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

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new(userManager);
            mainWindow.Show();
            this.Close();
            
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Info TravelPal");
        }
    }
}
