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
        public ModelJeux Jeux { get; set; }
        public ModelHistorique Historique { get; set; }

        #endregion

        #region Constructor

        public Login(ModelProfiles mp, ModelJeux mj, ModelHistorique mh)
        {
            Profiles = mp;
            Jeux = mj;
            Historique = mh;
            Profiles.Add("admin", "admin", "admin", DateTime.Now, "a@a.com", "admin");
            InitializeComponent();
        }

        #endregion

        #region Login

        /// <summary>
        /// Méthode de login dans l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogToApp(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!Profiles.UserLogin(usrTxt.Text, psswrdTxt.Password))
            {
                ErrorLabel.Content = "Nom d'utilisateur ou mot de passe invalide";
                return;
            }

            ErrorLabel.Content = "";

            NavigationService?.Navigate(new Home(Profiles.GetByUsername(usrTxt.Text), Profiles, Jeux, Historique));
        }

        /// <summary>
        /// Redirection vers la page de création de compte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoToCreateAccount(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Createaccount(Profiles, Jeux, Historique));
        }

        #endregion
    }
}