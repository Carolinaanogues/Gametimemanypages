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
        public Createaccount(ModelProfiles mp, ModelJeux mj, ModelHistorique mh)
        {
            Profiles = mp;
            Jeux = mj;
            Historique = mh;
            InitializeComponent();
        }

        private void btn_Home_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Login(Profiles, Jeux, Historique));
        }

        #region CreateProfile

        private void CreateAccount(object sender, System.Windows.RoutedEventArgs e)
        {
            if (CheckEmpty(txtNickname.Text) || CheckEmpty(pwdPassword.Password)
                || CheckEmpty(txtName.Text) || CheckEmpty(txtFirstName.Text)
                || CheckEmpty(dpBirthDate.Text) || CheckEmpty(txtEmail.Text))
            {
                lblErr1.Content = "Veuillez remplir tous les champs !";
                return;
            }

            try
            {
                Profiles.GetByUsername(txtNickname.Text);
            }
            catch (InvalidOperationException)
            {
                //Profil NewProfile = new Profil(txtNickname.Text, txtName.Text, txtFirstName.Text, DateTime.Parse(dpBirthDate.Text), txtEmail.Text, pwdPassword.Password);
                Profiles.Add(txtNickname.Text, txtName.Text, txtFirstName.Text, DateTime.Parse(dpBirthDate.Text), txtEmail.Text, pwdPassword.Password);
                NavigationService?.Navigate(new Login(Profiles, Jeux, Historique));
                return;
            }

            lblErr2.Content = "Le pseudo existe déjà.";


        }

        private bool CheckEmpty(string txt)
        {
            return string.IsNullOrEmpty(txt);
        }

        #endregion
    }
}