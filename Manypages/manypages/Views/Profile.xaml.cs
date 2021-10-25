using System.Windows;
using System;
using System.IO;
using Microsoft.Win32;

namespace manypages
{
    /// <summary>
    /// Logique d'interaction pour Profile.xaml
    /// </summary>
    public partial class Profile
    {
        public Profile()
        {
            InitializeComponent();
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

        private void btn_Profile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Profile());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            labelimg.Content = openFileDialog.FileName;
            
        }
    }
}