using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using manypages.ObjectStructure.Enums;
using manypages.ObjectStructure.Objects;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace manypages.Models
{
    public class ModelJeux
    {
        #region Properties

        public ObservableCollection<Jeuxvideo> Vgs { get; set; }

        #endregion

        #region Constructors

        public ModelJeux()
        {
            Vgs = new ObservableCollection<Jeuxvideo>();
        }

        #endregion

        #region CRUDJeuxvideo

        /// <summary>
        /// Get a video game by its index in the ObservableCollection
        /// </summary>
        /// <param name="index">index where the object is in the list</param>
        /// <returns>Video game found</returns>
        public Jeuxvideo GetByIndex(int index) => Vgs[index];

        /// <summary>
        /// Get a video game by its Guid
        /// </summary>
        /// <param name="id">the guid to search</param>
        /// <returns>video game found</returns>
        public Jeuxvideo GetByGuid(Guid id) => Vgs.First(vg => vg.Id == id);

        /// <summary>
        /// Get a video game by its index
        /// </summary>
        /// <param name="vg">the video game to search</param>
        /// <returns>the index of this video game</returns>
        public int GetIndex(Jeuxvideo vg) => Vgs.IndexOf(Vgs.First(j => j.Id == vg.Id));

        /// <summary>
        /// Add a new video game in the ObservableCollection
        /// </summary>
        /// <param name="nom">video game's name</param>
        /// <param name="description">video game's description</param>
        /// <param name="image">array of string (path to each image)</param>
        /// <param name="date">video game's release date</param>
        /// <param name="genre">video game's type</param>
        /// <param name="pegi">PEGI 18 motherfucker</param>
        /// <param name="plateforme">Which plateforme the video game is</param>
        /// <param name="version">PAL or NTSC</param>
        public void Add(string nom, string description, string image, DateTime date, Genre genre, PEGI pegi,
            Plateforme plateforme, VersionPays version) =>
            Vgs.Add(new Jeuxvideo(nom, description, image, date, genre, pegi, plateforme, version));

        /// <summary>
        /// Update a video game with new info
        /// </summary>
        /// <param name="index">index of the video game in the ObservableCollection</param>
        /// <param name="nom">video game's name</param>
        /// <param name="description">video game's description</param>
        /// <param name="image">array of string (path to each image)</param>
        /// <param name="date">video game's release date</param>
        /// <param name="genre">video game's type</param>
        /// <param name="pegi">PEGI 18 motherfucker</param>
        /// <param name="plateforme">Which plateforme the video game is</param>
        /// <param name="version">PAL or NTSC</param>
        public void Update(int index, string nom, string description, string image, DateTime date,
            Genre genre, PEGI pegi, Plateforme plateforme, VersionPays version)
        {
            if (index < 0)
                return;

            Vgs[index].Nom = nom;
            Vgs[index].Description = description;
            Vgs[index].Image = image;
            Vgs[index].Date = date;
            Vgs[index].Genre = genre;
            Vgs[index].Pegi = pegi;
            Vgs[index].Plateforme = plateforme;
            Vgs[index].Version = version;
        }

        /// <summary>
        /// Delete a video game based on its index in the ObservableCollection
        /// </summary>
        /// <param name="index">where the video game at</param>
        public void Delete(int index) => Vgs.RemoveAt(index);

        /// <summary>
        /// Set a video game to its default value based on its index
        /// </summary>
        /// <param name="index">where the video game at</param>
        public void Reset(int index)
        {
            Vgs[index].Nom = "";
            Vgs[index].Description = "";
            Vgs[index].Image = "";
            Vgs[index].Date = DateTime.Now;
            Vgs[index].Genre = Genre.RPG;
            Vgs[index].Pegi = PEGI.PEGI18;
            Vgs[index].Plateforme = Plateforme.PC;
            Vgs[index].Version = VersionPays.NTSC;
        }

        #endregion

        #region ImageManipulation

        /// <summary>
        /// Resize an image
        /// </summary>
        /// <param name="imgUri">the uri's image</param>
        /// <returns>The new path where the image is saved</returns>
        public string ResizeImage(Uri imgUri)
        {
            using Image image = Image.Load(imgUri.AbsolutePath);
            int width = image.Width / 2;
            int height = image.Height / 2;
            image.Mutate(x => x.Resize(width, height));
            string newPath = NewPath(imgUri);
            image.Save(newPath);
            return newPath;
        }

        #endregion

        #region Utils

        private string NewPath(Uri imgUri)
        {
            Random random = new Random();
            byte[] buffer = new byte[16];
            random.NextBytes(buffer);
            string rdmStr = string.Concat(buffer.Select(x => x.ToString("X2")).ToArray()).ToLower();
            return $"{Path.GetFullPath("./../../assets/GameImages")}\\{rdmStr}.{imgUri.ToString().Split('.').Last()}";
        }

        #endregion
    }
}