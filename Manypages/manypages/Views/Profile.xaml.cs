using System.Windows;
using Microsoft.Win32;
using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using manypages.Models;
using manypages.ObjectStructure.Objects;
using System.ComponentModel;

//using System.Windows.Controls;
//using System.Windows.Media.Imaging;

namespace manypages
{
    /// <summary>
    /// Logique d'interaction pour Profile.xaml
    /// </summary>
    public partial class Profile
    {
        public Profil IProfile { get; set; }
        public ModelProfiles Profiles { get; set; }
        public ModelHistorique IModelHistorique { get; set; }
        public ModelJeux IModelJeux { get; set; }

        public Profile(Profil pf, ModelProfiles mp, ModelJeux mj, ModelHistorique mh)
        {
            DataContext = this;
            Profiles = mp;
            IProfile = pf;
            IModelJeux = mj;
            IModelHistorique = mh;
            InitializeComponent();
        }
        /// <summary>
        /// Redirectionne vers page Home
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Home(IProfile, Profiles, IModelJeux, IModelHistorique));
        }
        /// <summary>
        /// Redirectionne vers page Bibliotheque
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Biblio_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Bibliotheque(IProfile, Profiles, IModelJeux, IModelHistorique));
        }
        /// <summary>
        /// Redirectionne vers page Historique
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Historique_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Historique(IProfile, Profiles, IModelJeux, IModelHistorique));
        }
        /// <summary>
        /// Redirectionne vers page Profil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Profile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Profile(IProfile, Profiles, IModelJeux, IModelHistorique));
        }
        /// <summary>
        /// Bouton image permet d'ouvrir l'explorateur et choisir une image, aprés l'afficher
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png"
            };
            if (openFileDialog.ShowDialog() != true) return;


            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(openFileDialog.FileName);
            bitmapImage.EndInit();
            Image img = new Image
            {
                Source = bitmapImage
            };
            imgdisplay.Source = img.Source;
        }
        /// <summary>
        /// Bouton Editer permet la modif du profil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditDataBtn_Click(object sender, RoutedEventArgs e)
        {
            datepicker.IsEnabled = true;
            txtemail.IsReadOnly = false;
            txtnom.IsReadOnly = false;
            txtprenom.IsReadOnly = false;
            txtpseudo.IsReadOnly = false;
            txtpasswd.IsReadOnly = false;
            update.IsEnabled = true;
            btn_putimg.IsEnabled = true;
        }
        /// <summary>
        /// Bouton update permet de sauvegarder les modifications
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void update_Click(object sender, RoutedEventArgs e)
        {
            Profiles.Update(
                Profiles.GetIndex(IProfile),
                txtpseudo.Text,
                txtnom.Text,
                txtprenom.Text,
                datepicker.SelectedDate.Value,
                txtemail.Text,
                txtpasswd.Text
            );
            datepicker.IsEnabled = false;
            txtemail.IsReadOnly = true;
            txtnom.IsReadOnly = true;
            txtprenom.IsReadOnly = true;
            txtpseudo.IsReadOnly = true;
            txtpasswd.IsReadOnly = true;
            update.IsEnabled = true;
            btn_putimg.IsEnabled = false;
            update.IsEnabled = false;
        }
        /// <summary>
        /// Bouton supprimer permet de supprimer le compte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SupDataBtn_Click(object sender, RoutedEventArgs e)
        {
            int index = Profiles.GetIndex(IProfile);
            Profiles.Delete(index);
            NavigationService?.Navigate(new Login(Profiles, IModelJeux, IModelHistorique));
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO implémenter la fonction reset qui reprend les valeurs de la personne connectée et écrase les textbox
            // Monsieur vous êtes très sympathique ce fut un plaisir de participer à ce cours inter avec vous. signé William Pasquier.
            // (On peut toujours négocier une bonne note en l'échange de mes quelques Bitcoin si jamais ^^)
        }
    }
}