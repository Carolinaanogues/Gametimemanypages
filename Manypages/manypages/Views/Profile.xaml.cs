using System.Windows;
using System.Windows.Controls;

namespace manypages
{
    /// <summary>
    /// Logique d'interaction pour Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void btn_Profile_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Profile());
        }
    }
}
