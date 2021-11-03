using System.Windows;

namespace manypages
{
    /// <summary>
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btn_Home_Copy_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Bibliotheque());
        }

        private void btn_Home_Copy2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Profile());
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Login());
        }

        private void btn_Home_Copy1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Historique());
        }

        private void btn_Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Home());
        }
    }
}