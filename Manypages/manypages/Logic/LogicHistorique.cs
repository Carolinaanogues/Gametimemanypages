using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using manypages.ObjectStructure.Enums;
using manypages.ObjectStructure.Objects;

namespace manypages.Logic
{
    public class LogicHistorique
    {
        #region Properties

        public static List<manypages.ObjectStructure.Objects.Historique> Hist { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Get a Historique By its user. If history was not found, create a new historique object
        /// </summary>
        /// <param name="user">get history for which user</param>
        /// <returns>1st item : index in the list, 2nd item : user's history</returns>
        public static Tuple<int, manypages.ObjectStructure.Objects.Historique> GetByUser(Profil user)
        {
            try
            {
                return new Tuple<int, manypages.ObjectStructure.Objects.Historique>(
                    Hist.FindIndex(h => h.Profile.Id == user.Id),
                    Hist.First(h => h.Profile.Id == user.Id));
            }
            catch (InvalidOperationException)
            {
                manypages.ObjectStructure.Objects.Historique hist =
                    new manypages.ObjectStructure.Objects.Historique(user,
                        new ObservableCollection<Tuple<Jeuxvideo, Status>>());
                Hist.Add(hist);
                return new Tuple<int, manypages.ObjectStructure.Objects.Historique>(Hist.Count - 1, hist);
            }
        }

        /// <summary>
        /// Add a new game to the user's history
        /// </summary>
        /// <param name="index">index of the connected user</param>
        /// <param name="game">the video game to add</param>
        public static void AddGame(int index, Jeuxvideo game) =>
            Hist[index].Games.Add(new Tuple<Jeuxvideo, Status>(game, Status.Started));

        /// <summary>
        /// Set a game in progress
        /// </summary>
        /// <param name="user">user index (GetByUser(user).Item1)</param>
        /// <param name="game">Selected game (index in list, we can get that with ViewList.SelectedIndex)</param>
        public static void SetInProgress(int user, int game) => Hist[user].Games[game] =
            new Tuple<Jeuxvideo, Status>(Hist[user].Games[game].Item1, Status.InProgress);


        /// <summary>
        /// Set a game finished
        /// </summary>
        /// <param name="user">user index (GetByUser(user).Item1)</param>
        /// <param name="game">Selected game (index in list, we can get that with ViewList.SelectedIndex)</param>
        public static void SetFinished(int user, int game) => Hist[user].Games[game] =
            new Tuple<Jeuxvideo, Status>(Hist[user].Games[game].Item1, Status.Finished);

        #endregion
    }
}