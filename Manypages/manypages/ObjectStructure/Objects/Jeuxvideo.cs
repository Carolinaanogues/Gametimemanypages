using System;
using manypages.ObjectStructure.Enums;

namespace manypages.ObjectStructure.Objects
{
    /// <summary>
    /// A single video game
    /// </summary>
    public class Jeuxvideo
    {
        #region Properties

        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        public Genre Genre { get; set; }
        public PEGI Pegi { get; set; }
        public Plateforme Plateforme { get; set; }
        public VersionPays Version { get; set; }

        #endregion

        #region Constructors

        public Jeuxvideo(string nom, string description, string image, DateTime date, Genre genre, PEGI pegi,
            Plateforme plateforme, VersionPays version)
        {
            Id = Guid.NewGuid();
            Nom = nom;
            Description = description;
            Image = image;
            Date = date;
            Genre = genre;
            Pegi = pegi;
            Plateforme = plateforme;
            Version = version;
        }

        #endregion
    }
}