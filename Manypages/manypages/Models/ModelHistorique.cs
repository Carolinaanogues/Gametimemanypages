using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using manypages.ObjectStructure.Objects;

namespace manypages.Models
{
    public class ModelHistorique
    {
        #region Properties

        public Profil ConnectedProfile { get; set; }

        public ObservableCollection<ObjectStructure.Objects.Historique> Hist { get; set; } =
            new ObservableCollection<ObjectStructure.Objects.Historique>();

        public ObservableCollection<ObjectStructure.Objects.Historique> Display { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Add a new game to the user's history
        /// </summary>
        /// <param name="index">index of the connected user</param>
        /// <param name="game">the video game to add</param>
        public void AddGame(ObjectStructure.Objects.Historique hist) => Hist.Add(hist);

        #endregion
    }
}