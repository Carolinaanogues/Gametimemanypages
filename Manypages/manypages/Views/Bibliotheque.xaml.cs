using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System;
using System.Windows;
using Microsoft.Win32;
using manypages.Models;
using manypages.ObjectStructure.Objects;
using manypages.ObjectStructure.Enums;
using System.Linq;

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

            GamePlateformCB.ItemsSource = Enum.GetValues(typeof(Plateforme)).Cast<Plateforme>();
            GameGenderCB.ItemsSource = Enum.GetValues(typeof(Genre)).Cast<Genre>();
            GamePEGICB.ItemsSource = Enum.GetValues(typeof(PEGI)).Cast<PEGI>();
            GameVersionCB.ItemsSource = Enum.GetValues(typeof(VersionPays)).Cast<VersionPays>();
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

        private void AddGameBtn_Click(object sender, RoutedEventArgs e)
        {
            IModelJeux.Add(
                             GameNameTB.Text,
                             GameDescTB.Text,
                             new[] { "", "" },
                             ReleaseDateDP.SelectedDate.Value,
                             (Genre)GameGenderCB.SelectedItem,
                             (PEGI)GamePEGICB.SelectedItem,
                             (Plateforme)GamePlateformCB.SelectedItem,
                             (VersionPays)GameVersionCB.SelectedItem
                          );
            ResetFieldValue();
        }


        private void RemoveGameBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditGameBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ResetFieldBtn_Click(object sender, RoutedEventArgs e)
        {
            ResetFieldValue();
        }

        private void ResetFieldValue()
        {
            GameNameTB.Text = "";
            GameDescTB.Text = "";
            ReleaseDateDP.SelectedDate = null;
            GameGenderCB.SelectedItem = null;
            GamePEGICB.SelectedItem = null;
            GamePlateformCB.SelectedItem = null;
            GameVersionCB.SelectedItem = null;
        }
    }
}