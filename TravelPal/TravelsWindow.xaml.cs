using System;
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

        private TravelManager travelManager = new();

        public TravelsWindow(UserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;
            DateTime date = new DateTime();

            if(userManager.signedInUser == null)
            {
                this.Close();
                return;
            }
          

            User user = (User)userManager.signedInUser;
            

            user.Travels.ForEach(travel =>
            {
                ListViewItem item = new();
      
                item.Content = travel.GetInfo();
                item.Tag = travel;
                lvListView.Items.Add(item);

                }
            );
            lblUsername.Content = user.Username;

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
            if (lvListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("To show details, please select an item from the list!");
                return;
            }

        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lvListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("To remove, please select an item from the list!");
                return;
            }
            ListViewItem selectedItem = lvListView.SelectedItem as ListViewItem;
            travelManager.removeTravel(selectedItem.Tag as Travel);
            lvListView.Items.RemoveAt(lvListView.SelectedIndex);
            
        }

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            this.Close();
            
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Info TravelPal");
        }
    }
}
