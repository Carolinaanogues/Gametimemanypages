using System.Windows;

namespace manypages
{
    /// <summary>
    /// Logique d'interaction pour Profile.xaml
    /// </summary>
    public partial class Profile
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void btn_Profile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Profile());
        }
    }
}