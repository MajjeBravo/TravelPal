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
            this.user.removeTravel((Travel)lvTravels.SelectedItem);
            lvTravels.Items.Remove(lvTravels.SelectedItem);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
