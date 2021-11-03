using System.Windows;
using manypages.Models;
using manypages.ObjectStructure.Objects;

namespace manypages
{
    /// <summary>
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home
    {
        public Profil Profile { get; set; }
        public ModelProfiles Profiles { get; set; }
        public ModelJeux IModelJeux { get; set; }
        public ModelHistorique IModelHistorique { get; set; }
        public Home(Profil profile)
        {
            InitializeComponent();
            Profile = profile;
            IModelJeux = new ModelJeux();
            IModelHistorique = new ModelHistorique();
        }

        public Home(Profil profile, ModelProfiles mp, ModelJeux mj, ModelHistorique mh)
        {
            InitializeComponent();
            Profiles = mp;
            Profile = profile;
            IModelJeux = mj;
            IModelHistorique = mh;
        }

        private void btn_Home_Copy_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Bibliotheque(Profile, Profiles, IModelJeux, IModelHistorique));
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Login(Profiles, IModelJeux, IModelHistorique));
        }

        private void btn_Home_Copy1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Historique(Profile, Profiles, IModelJeux, IModelHistorique));
        }

        private void btn_Createacc_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Profile(Profile, Profiles, IModelJeux, IModelHistorique));
        }
    }
}