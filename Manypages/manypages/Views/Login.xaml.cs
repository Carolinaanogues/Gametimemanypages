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

        public ModelProfiles Profiles { get; set; }

        #endregion

        #region Constructor

        public Login()
        {
            Profiles = new ModelProfiles();
            InitializeComponent();
            Profiles.Add("admin", "admin", "admin", DateTime.Now, "a@a.com", "admin");
        }

        public Login(ModelProfiles profiles)
        {
            Profiles = profiles;
            InitializeComponent();
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
            NavigationService?.Navigate(new Createaccount(Profiles));
        }

        #endregion
    }
}