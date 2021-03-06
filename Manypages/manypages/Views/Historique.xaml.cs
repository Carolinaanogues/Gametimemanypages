using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
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
        #region Properties

        public Profil Profile { get; set; }
        public ModelProfiles Profiles { get; set; }
        public ModelJeux IModelJeux { get; set; }
        public ModelHistorique IModelHistorique { get; set; }

        #endregion

        #region Constructors

        public Historique(Profil pf, ModelProfiles mp, ModelJeux mj, ModelHistorique mh)
        {
            DataContext = this;
            Profile = pf;
            Profiles = mp;
            IModelJeux = mj;
            IModelHistorique = mh;
            IModelHistorique.Display =
                new ObservableCollection<ObjectStructure.Objects.Historique>(IModelHistorique.Hist
                    .Where(o => o.Profile.Id == Profile.Id).ToList());
            IModelHistorique.ConnectedProfile = Profile;
            InitializeComponent();
        }

        #endregion

        #region NavigationService

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

        #endregion


        #region Methods

        /// <summary>
        /// Add a game to history
        /// </summary>
        private void AddGameToHistorique(object sender, RoutedEventArgs e)
        {
            Jeuxvideo vg = (Jeuxvideo)ComboBoxGame.SelectedItem;
            if (vg == null)
                return;
            ObjectStructure.Objects.Historique hist =
                new ObjectStructure.Objects.Historique(Profile, new Tuple<Jeuxvideo, Status>(vg, Status.Started));
            IModelHistorique.AddGame(hist);
            btn_Historique_Click(sender, e);
        }

        private void SetFinished(object sender, RoutedEventArgs e)
        {
            UpdateStatus((ObjectStructure.Objects.Historique)ListViewHistorique.SelectedItem, Status.Finished);
            CollectionViewSource.GetDefaultView(IModelHistorique.Display).Refresh();
        }

        private void SetInProgress(object sender, RoutedEventArgs e)
        {
            UpdateStatus((ObjectStructure.Objects.Historique)ListViewHistorique.SelectedItem, Status.InProgress);
            CollectionViewSource.GetDefaultView(IModelHistorique.Display).Refresh();
        }

        private void UpdateStatus(ObjectStructure.Objects.Historique hist, Status status)
        {
            if (hist != null)
                hist.Games = new Tuple<Jeuxvideo, Status>(hist.Games.Item1, status);
        }

        /// <summary>
        /// Load a game view by double clicking on a record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadGameFromHist(object sender, RoutedEventArgs e)
        {
            ObjectStructure.Objects.Historique hist =
                (ObjectStructure.Objects.Historique)ListViewHistorique.SelectedItem;
            Jeuxvideo vg = hist.Games.Item1;
            int index = IModelJeux.GetIndex(vg);
            NavigationService?.Navigate(new Bibliotheque(index, Profile, Profiles, IModelJeux, IModelHistorique));
        }

        #endregion
    }
}