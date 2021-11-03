using manypages.Models;

namespace manypages
{
    /// <summary>
    /// Logique d'interaction pour Createaccount.xaml
    /// </summary>
    public partial class Createaccount
    {
        public ModelProfiles Profiles { get; set; }
        public ModelJeux Jeux { get; set; }
        public ModelHistorique Historique { get; set; }
        public Createaccount(ModelProfiles mp, ModelJeux mj, ModelHistorique mh)
        {
            Profiles = mp;
            Jeux = mj;
            Historique = mh;
            InitializeComponent();
        }

        private void btn_Home_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Login(Profiles, Jeux, Historique));
        }
    }
}