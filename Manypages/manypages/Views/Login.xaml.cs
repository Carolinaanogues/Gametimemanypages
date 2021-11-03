using System;
using manypages.Models;
using manypages.ObjectStructure.Objects;

namespace manypages
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login
    {
        #region Properties

        public ModelProfiles Profiles { get; set; } = new ModelProfiles();

        #endregion

        #region Navigation

        private void btn_Home_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Home());
        }

        #endregion

        #region Constructor

        public Login()
        {
            InitializeComponent();
            Profiles.Add("admin", "admin", "admin", DateTime.Now, "a@a.com", "admin");
        }

        #endregion

        #region Login

        private void LogToApp(object sender, System.Windows.RoutedEventArgs e)
        {
            
            if (!Profiles.UserLogin(usrTxt.Text, psswrdTxt.Password))
            {
                ErrorLabel.Content = "Nom d'utilisateur ou mot de passe invalide";
                return;
            }

            ErrorLabel.Content = "";

            NavigationService?.Navigate(new Home());

        }

        private void GoToCreateAccount(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Createaccount());
        }

        #endregion
    }
}