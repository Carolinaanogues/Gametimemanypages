namespace manypages
{
    /// <summary>
    /// Logique d'interaction pour Createaccount.xaml
    /// </summary>
    public partial class Createaccount
    {
        public Createaccount()
        {
            InitializeComponent();
        }

        private void btn_Home_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Home());
        }
    }
}