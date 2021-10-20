using System.Windows;

namespace manypages
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MyWindow_Loaded;
        }

        private void MyWindow_Loaded(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Home());
        }
    }
}