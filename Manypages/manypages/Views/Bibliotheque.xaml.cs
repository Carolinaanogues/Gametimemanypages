using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System;
using System.Windows;
using Microsoft.Win32;

namespace manypages
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Bibliotheque
    {
        public Bibliotheque()
        {
            InitializeComponent();
        }

        private void btn_Home_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Home());
        }

        private void btn_Biblio_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Bibliotheque());
        }

        private void btn_Historique_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Historique());
        }

        private void btn_Profile_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Profile());
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            
            }
        }
    }
}