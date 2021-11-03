namespace manypages
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Bibliotheque
    {
        public Bibliotheque()
        {
            InitializeComponent();
        }

        private void btn_Home_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Home());
        }

        private void btn_Biblio_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Bibliotheque());
        }

        private void btn_Historique_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Historique());
        }

        private void btn_Profile_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Profile());
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}