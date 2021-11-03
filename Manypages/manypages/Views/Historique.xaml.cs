using System;
using System.Windows;
using manypages.Models;
using manypages.ObjectStructure.Enums;

namespace manypages
{
    /// <summary>
    /// Logique d'interaction pour Historique.xaml
    /// </summary>
    public partial class Historique
    {
        public ModelJeux IModelJeux { get; set; }
        public ModelHistorique IModelHistorique { get; set; }
        public Historique()
        {
            DataContext = this;
            IModelJeux = new ModelJeux();
            IModelJeux.Add("test1", "asdf", new []{"", ""}, DateTime.Now, Genre.FPS, PEGI.PEGI3, Plateforme.Switch, VersionPays.PAL);
            IModelHistorique = new ModelHistorique();
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

        private void btn_Biblio_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Bibliotheque());
        }

        private void btn_Historique_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Historique());
        }
    }
}