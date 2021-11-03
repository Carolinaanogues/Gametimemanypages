using System;

namespace manypages.ObjectStructure.Objects
{
    /// <summary>
    /// User profile
    /// </summary>
    public class Profil
    {
        #region Properties

        public Guid Id { get; set; }
        public string Pseudo { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string MotDePasse { get; set; }
        public bool Connected { get; set; }

        #endregion

        #region Constructors

        public Profil(string pseudo, string nom, string prenom, DateTime birthDate, string email, string motDePasse)
        {
            Id = Guid.NewGuid();
            Pseudo = pseudo;
            Nom = nom;
            Prenom = prenom;
            BirthDate = birthDate;
            Email = email;
            MotDePasse = motDePasse;
            Connected = false;
        }

        #endregion
    }
}