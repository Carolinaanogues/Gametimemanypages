using System;
using System.Collections.ObjectModel;
using System.Linq;
using manypages.ObjectStructure.Objects;

namespace manypages.Models
{
    public class ModelProfiles
    {
        #region Properties

        public ObservableCollection<Profil> Profiles { get; set; } = new ObservableCollection<Profil>();

        #endregion

        #region CRUDJeuxvideo

        public int GetIndex(Profil pf)
        {
            return Profiles.IndexOf(Profiles.First(p => p.Id == pf.Id));
        }

        /// <summary>
        /// Get a user by its username
        /// </summary>
        /// <param name="username">the username to search</param>
        /// <returns>a profile object</returns>
        public Profil GetByUsername(string username) => Profiles.First(u => u.Pseudo == username);

        /// <summary>
        /// Add a new user in the ObservableCollection
        /// </summary>
        /// <param name="pseudo">user's pseudo</param>
        /// <param name="nom">user's last name</param>
        /// <param name="prenom">user's first name</param>
        /// <param name="birthdate">user's birthdate</param>
        /// <param name="email">user's email</param>
        /// <param name="mdp">user's password</param>
        public void Add(string pseudo, string nom, string prenom, DateTime birthdate, string email,
            string mdp) =>
            Profiles.Add(new Profil(pseudo, nom, prenom, birthdate, email, mdp));

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="index">the index of this user</param>
        /// <param name="pseudo">new pseudo</param>
        /// <param name="nom">new last name</param>
        /// <param name="prenom">new first name</param>
        /// <param name="birthdate">new birthdate</param>
        /// <param name="email">new email</param>
        /// <param name="mdp">new password</param>
        public void Update(int index, string pseudo, string nom, string prenom, DateTime birthdate, string email,
            string mdp)
        {
            if (index < 0)
                return;

            Profiles[index].Nom = nom;
            Profiles[index].Pseudo = pseudo;
            Profiles[index].Prenom = prenom;
            Profiles[index].BirthDate = birthdate;
            Profiles[index].Email = email;
            Profiles[index].MotDePasse = mdp;
        }

        /// <summary>
        /// Delete a user based on its index in the ObservableCollection
        /// </summary>
        /// <param name="index">where the user is</param>
        public void Delete(int index) => Profiles.RemoveAt(index);

        public bool UserLogin(string username, string password)
        {
            try
            {
                Profil profile = GetByUsername(username);
                if (profile.MotDePasse != password)
                    throw new InvalidOperationException("invalid password");
            }
            catch (InvalidOperationException)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}