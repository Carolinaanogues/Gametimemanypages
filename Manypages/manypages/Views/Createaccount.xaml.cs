using manypages.Models;
using System;

namespace manypages
{
    /// <summary>
    /// Logique d'interaction pour Createaccount.xaml
    /// </summary>
    public partial class Createaccount
    {
        public ModelProfiles Profiles { get; set; }
        public ModelJeux Jeux { get; set; }
        public ModelHistorique Historique { get; set; }

        // Constructor
        public Createaccount(ModelProfiles mp, ModelJeux mj, ModelHistorique mh)
        {
            Profiles = mp;
            Jeux = mj;
            Historique = mh;
            InitializeComponent();
        }

        /// <summary>
        /// Bouton retour sur la page Login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Home_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Login(Profiles, Jeux, Historique));
        }

        #region CreateProfile

        /// <summary>
        /// Création d'un neauvou profil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateAccount(object sender, System.Windows.RoutedEventArgs e)
        {
            // Vérification des champs s'ils sont bien remplis
            if (CheckEmpty(txtNickname.Text) || CheckEmpty(pwdPassword.Password) || CheckEmpty(txtName.Text) ||
                CheckEmpty(txtFirstName.Text) || CheckEmpty(dpBirthDate.Text) || CheckEmpty(txtEmail.Text))
            {
                lblErr1.Content = "Veuillez remplir tous les champs !";
                return;
            }

            // Vérifier selon le pseudo si l'utilisateur existe déjà, sinon insersion d'un nouveau compte dans ModelProfiles
            try
            {
                Profiles.GetByUsername(txtNickname.Text);
            }
            catch (InvalidOperationException)
            {

                Profiles.Add(txtNickname.Text, txtName.Text, txtFirstName.Text, DateTime.Parse(dpBirthDate.Text),
                    txtEmail.Text, pwdPassword.Password);
                // Redirection vers la page login après la création du compte
                NavigationService?.Navigate(new Login(Profiles, Jeux, Historique));
                return;
            }

            lblErr1.Content = "Le pseudo existe déjà.";
        }

        /// <summary>
        /// Méthode pour vérifier le remplissage du champs
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        private bool CheckEmpty(string txt)
        {
            return string.IsNullOrEmpty(txt);
        }

        #endregion
    }
}