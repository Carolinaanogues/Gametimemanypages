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
        public Profil IProfile { get; set; }
        public ModelHistorique IModelHistorique { get; set; }
        public ModelJeux IModelJeux { get; set; }
        
        public Profile(Profil pf, ModelJeux mj, ModelHistorique mh)
        {
            IProfile = pf;
            IModelJeux = mj;
            IModelHistorique = mh;
            InitializeComponent();
        }


        private void btn_Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Home(IProfile, IModelJeux, IModelHistorique));
        }

        private void btn_Biblio_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Bibliotheque(IProfile, IModelJeux, IModelHistorique));
        }

        private void btn_Historique_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Historique(IProfile, IModelJeux, IModelHistorique));
        }

        private void btn_Profile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Profile(IProfile, IModelJeux, IModelHistorique));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                labelimg.Content = openFileDialog.FileName;

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
}