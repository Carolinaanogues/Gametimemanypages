using System.Windows;
using manypages.Models;

namespace manypages
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public ModelProfiles Profiles { get; set; } = new ModelProfiles();
        public ModelJeux Jeux { get; set; } = new ModelJeux();
        public ModelHistorique Historique { get; set; } = new ModelHistorique();
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MyWindow_Loaded;
        }

        private void MyWindow_Loaded(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Login(Profiles, Jeux, Historique));
        }
    }
}