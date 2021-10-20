using System.Windows;

namespace manypages
{
    /// <summary>
    /// Logique d'interaction pour Historique.xaml
    /// </summary>
    public partial class Historique
    {
        public Historique()
        {
            InitializeComponent();
        }

        private void btn_Home_Copy2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Profile());
        }

        private void btn_Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Home());
        }
    }
}
