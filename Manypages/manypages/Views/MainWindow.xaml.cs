using System.Windows;
using manypages.Models;

namespace manypages
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        #region Properties

        public ModelProfiles Profiles { get; set; } = new ModelProfiles();
        public ModelJeux Jeux { get; set; } = new ModelJeux();
        public ModelHistorique Historique { get; set; } = new ModelHistorique();

        #endregion
        
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MyWindow_Loaded;
        }

        /// <summary>
        /// Load login page py default
        /// </summary>
        private void MyWindow_Loaded(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Login(Profiles, Jeux, Historique));
        }
    }
}