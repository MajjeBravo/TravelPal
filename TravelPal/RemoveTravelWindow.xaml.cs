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
using TravelPal.Models.Travels;
using TravelPal.Models.User;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for RemoveTravelWindow.xaml
    /// </summary>
    public partial class RemoveTravelWindow : Window
    {
        private User user;

        public RemoveTravelWindow(User user)
        {
            this.user = user;

            InitializeComponent();
           lblUsername.Content = user.Username;
            user.Travels.ForEach(travel =>
            {
                ListViewItem item = new();
                item.Tag = travel;
                item.Content = travel.GetInfo();
                lvTravels.Items.Add(item);
            });
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lvTravels.SelectedItem == null)
            {
                MessageBox.Show("To remove, please select an item from the list!");
                return;
            }
            ListViewItem selectedItem = lvTravels.SelectedItem as ListViewItem;
            user.removeTravel(selectedItem.Tag as Travel);
            lvTravels.Items.RemoveAt(lvTravels.SelectedIndex);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
