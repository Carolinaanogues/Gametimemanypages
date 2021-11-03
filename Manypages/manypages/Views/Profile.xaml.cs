using System.Windows;
using Microsoft.Win32;
using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using manypages.Models;
using manypages.ObjectStructure.Objects;

//using System.Windows.Controls;
//using System.Windows.Media.Imaging;

namespace manypages
{
    /// <summary>
    /// Logique d'interaction pour Profile.xaml
    /// </summary>
    public partial class Profile
    {
        private ObjectStructure.Objects.Profil profile;
        private ModelProfiles profiles;
        private ModelJeux modelJeux;
        private ModelHistorique modelHistorique;

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

        private void btn_Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Home(IProfile, Profiles, IModelJeux, IModelHistorique));
        }

        private void btn_Biblio_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Bibliotheque(IProfile, Profiles, IModelJeux, IModelHistorique));
        }

        private void btn_Historique_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Historique(IProfile, Profiles, IModelJeux, IModelHistorique));
        }

        private void btn_Profile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Profile(IProfile, Profiles, IModelJeux, IModelHistorique));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != true) return;
            openFileDialog.Filter = "Image files (*.png)|(*.jpg)";
           

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
    }
}