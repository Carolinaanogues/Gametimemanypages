using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace manypages
{
    /// <summary>
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btn_Home_Copy_Click(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void btn_Home_Copy2_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Profile());
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Login());
        }

        private void btn_Home_Copy1_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Historique());
        }
    }
}
