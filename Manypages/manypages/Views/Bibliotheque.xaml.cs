using System;
using System.Windows;
using manypages.Models;
using manypages.ObjectStructure.Objects;
using manypages.ObjectStructure.Enums;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

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

        private int _selectedItemIndex = 0;

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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Veuillez remplir tout les champs\n{ex.Message}", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void EditGameBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IModelJeux.Update(
                                _selectedItemIndex,
                                GameNameTB.Text,
                                GameDescTB.Text,
                                new[] { "", "" },
                                ReleaseDateDP.SelectedDate.Value,
                                (Genre)GameGenderCB.SelectedItem,
                                (PEGI)GamePEGICB.SelectedItem,
                                (Plateforme)GamePlateformCB.SelectedItem,
                                (VersionPays)GameVersionCB.SelectedItem
                               );
                CollectionViewSource.GetDefaultView(IModelJeux.Vgs).Refresh();
                ResetFieldValue();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veuillez remplir tout les champs\n{ex.Message}", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RemoveGameBtn_Click(object sender, RoutedEventArgs e)
        {
            IModelJeux.Delete(_selectedItemIndex);
            ResetFieldValue();
        }

        private void ResetFieldBtn_Click(object sender, RoutedEventArgs e)
        {
            ResetFieldValue();
        }

        private void listView_Click(object sender, RoutedEventArgs e)
        {
            Jeuxvideo selectedItem = (Jeuxvideo)GameLibraryLV.SelectedItem;
            _selectedItemIndex = GameLibraryLV.SelectedIndex;

            if (selectedItem != null)
            {
                GameNameTB.Text = selectedItem.Nom;
                GameDescTB.Text = selectedItem.Description;
                ReleaseDateDP.SelectedDate = selectedItem.Date;
                GameGenderCB.SelectedItem = selectedItem.Genre;
                GamePEGICB.SelectedItem = selectedItem.Pegi;
                GamePlateformCB.SelectedItem = selectedItem.Plateforme;
                GameVersionCB.SelectedItem = selectedItem.Version;
            }
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