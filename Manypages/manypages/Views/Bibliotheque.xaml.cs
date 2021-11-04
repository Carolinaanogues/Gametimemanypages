using System;
using System.Windows;
using manypages.Models;
using manypages.ObjectStructure.Objects;
using manypages.ObjectStructure.Enums;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Collections.Generic;

namespace manypages
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Bibliotheque
    {
        #region Propriété
        public ModelProfiles Profiles { get; set; }
        public Profil Profile { get; set; }
        public ModelJeux IModelJeux { get; set; }
        public ModelHistorique IModelHistorique { get; set; }

        private int _selectedItemIndex = 0;
        #endregion

        #region Methodes
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="pf">Instance du Profile</param>
        /// <param name="mp"></param>
        /// <param name="mj">Instance de modèle de jeu</param>
        /// <param name="mh">Instance de modèle de l'historique</param>
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

        /// <summary>
        /// Retour au menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Home_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Home(Profile, Profiles, IModelJeux, IModelHistorique));
        }

        /// <summary>
        /// Page Bibliothèque de jeu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Biblio_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Bibliotheque(Profile, Profiles, IModelJeux, IModelHistorique));
        }

        /// <summary>
        /// Page Historique de jeu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Historique_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Historique(Profile, Profiles, IModelJeux, IModelHistorique));
        }

        /// <summary>
        /// Page de Profile du compte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Profile_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Profile(Profile, Profiles, IModelJeux, IModelHistorique));
        }

        /// <summary>
        /// Bouton ajouter un jeu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddGameBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IModelJeux.Add(
                                GameNameTB.Text,
                                GameDescTB.Text,
                                "",
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

        /// <summary>
        /// Bouton editer un joueur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditGameBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IModelJeux.Update(
                                _selectedItemIndex,
                                GameNameTB.Text,
                                GameDescTB.Text,
                                "",
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

        /// <summary>
        /// Bouton retirer un jeu de la bibliothèque
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveGameBtn_Click(object sender, RoutedEventArgs e)
        {
            Jeuxvideo vg = IModelJeux.GetByIndex(_selectedItemIndex);
            List<int> tmp = (from historique in IModelHistorique.Hist
                             where vg.Id == historique.Games.Item1.Id
                             select IModelHistorique.Hist.IndexOf(historique)).ToList();

            foreach (int i in tmp)
            {
                IModelHistorique.Hist.RemoveAt(i);
            }
            IModelJeux.Delete(_selectedItemIndex);
            ResetFieldValue();
        }

        /// <summary>
        /// Réinitialiser les champs de la page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetFieldBtn_Click(object sender, RoutedEventArgs e)
        {
           
            ResetFieldValue();
        }

        /// <summary>
        /// Détection de click dans la liste et remplissage des champs avec les valeurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_Click(object sender, RoutedEventArgs e)
        {
            Jeuxvideo selectedItem = (Jeuxvideo)GameLibraryLV.SelectedItem;
            _selectedItemIndex = GameLibraryLV.SelectedIndex;

            if (selectedItem == null)
                return;
            
            GameNameTB.Text = selectedItem.Nom;
            GameDescTB.Text = selectedItem.Description;
            ReleaseDateDP.SelectedDate = selectedItem.Date;
            GameGenderCB.SelectedItem = selectedItem.Genre;
            GamePEGICB.SelectedItem = selectedItem.Pegi;
            GamePlateformCB.SelectedItem = selectedItem.Plateforme;
            GameVersionCB.SelectedItem = selectedItem.Version;
            
        }

        /// <summary>
        /// Réinisialisation des valeurs de champs
        /// </summary>
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
        #endregion
    }
}