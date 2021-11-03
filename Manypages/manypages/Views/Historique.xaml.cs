using System;
using System.Windows;
using manypages.Models;
using manypages.ObjectStructure.Enums;
using manypages.ObjectStructure.Objects;

namespace manypages
{
    /// <summary>
    /// Logique d'interaction pour Historique.xaml
    /// </summary>
    public partial class Historique
    {
        public Profil Profile { get; set; }
        public ModelProfiles Profiles { get; set; }
        public ModelJeux IModelJeux { get; set; }
        public ModelHistorique IModelHistorique { get; set; }
        public Historique(Profil pf, ModelProfiles mp, ModelJeux mj, ModelHistorique mh)
        {
            DataContext = this;
            Profiles = mp;
            IModelJeux = mj;
            IModelJeux.Add("test1", "asdf", new []{"", ""}, DateTime.Now, Genre.FPS, PEGI.PEGI3, Plateforme.Switch, VersionPays.PAL);
            IModelHistorique = mh;
            InitializeComponent();
        }

        private void btn_Home_Copy2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Profile(Profile, Profiles, IModelJeux, IModelHistorique));
        }

        private void btn_Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Home(Profile, Profiles, IModelJeux, IModelHistorique));
        }

        private void btn_Biblio_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Bibliotheque(Profile, Profiles, IModelJeux, IModelHistorique));
        }

        private void btn_Historique_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Historique(Profile, Profiles, IModelJeux, IModelHistorique));
        }
    }
}