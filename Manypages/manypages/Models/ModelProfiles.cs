using System;
using System.Collections.ObjectModel;
using System.Linq;
using manypages.ObjectStructure.Objects;

namespace manypages.Models
{
    public class LogicProfiles
    {
        #region Properties

        public static ObservableCollection<Profil> Profiles { get; set; } = new ObservableCollection<Profil>();

        #endregion

        #region CRUDJeuxvideo

        /// <summary>
        /// Get a user by its index in the ObservableCollection
        /// </summary>
        /// <param name="index">index where the object is in the list</param>
        /// <returns>user found</returns>
        public static Profil GetByIndex(int index) => Profiles[index];

        /// <summary>
        /// Get a user by its Guid
        /// </summary>
        /// <param name="id">the guid to search</param>
        /// <returns>user found</returns>
        public static Profil GetByGuid(Guid id) => Profiles.First(u => u.Id == id);

        /// <summary>
        /// Add a new user in the ObservableCollection
        /// </summary>
        /// <param name="pseudo">user's pseudo</param>
        /// <param name="nom">user's last name</param>
        /// <param name="prenom">user's first name</param>
        /// <param name="birthdate">user's birthdate</param>
        /// <param name="email">user's email</param>
        /// <param name="mdp">user's password</param>
        public static void Add(string pseudo, string nom, string prenom, DateTime birthdate, string email,
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
        public static void Update(int index, string pseudo, string nom, string prenom, DateTime birthdate, string email,
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
        public static void Delete(int index) => Profiles.RemoveAt(index);

        /// <summary>
        /// Set a user to its default value based on its index
        /// </summary>
        /// <param name="index">where the user is</param>
        public static void Reset(int index)
        {
            Profiles[index].Nom = "";
            Profiles[index].Pseudo = "";
            Profiles[index].Prenom = "";
            Profiles[index].BirthDate = DateTime.Now;
            Profiles[index].Email = "";
            Profiles[index].MotDePasse = "";
        }

        #endregion
    }
}