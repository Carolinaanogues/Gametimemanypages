using manypages.Models;
using manypages.ObjectStructure.Objects;

namespace manypages
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Bibliotheque
    {
        public ModelProfiles Profiles { get; set; }
        public Profil Profile { get; set; }
        public ModelJeux IModelJeux { get; set; }
        public ModelHistorique IModelHistorique { get; set; }
        public Bibliotheque(Profil pf, ModelProfiles mp, ModelJeux mj, ModelHistorique mh)
        {
            Profiles = mp;
            Profile = pf;
            IModelJeux = mj;
            IModelHistorique = mh;
            DataContext = this;
            InitializeComponent();
        }

        private void btn_Home_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Home(Profile, Profiles, IModelJeux, IModelHistorique));
        }

        private void btn_Biblio_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Bibliotheque(Profile, Profiles, IModelJeux, IModelHistorique));
        }

        private void btn_Historique_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Historique(Profile, Profiles, IModelJeux, IModelHistorique));
        }

        private void btn_Profile_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Profile(Profile, Profiles, IModelJeux, IModelHistorique));
        }
    }
}