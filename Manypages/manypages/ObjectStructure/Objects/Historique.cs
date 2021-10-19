using System;
using System.Collections.ObjectModel;
using manypages.ObjectStructure.Enums;

namespace manypages.ObjectStructure.Objects
{
    /// <summary>
    /// Link between a user and some video games
    /// </summary>
    public class Historique
    {
        #region Properties

        public Profil Profile { get; set; }

        /// <summary>
        /// 1st element: Jeuxvideo, 2nd element: Status enum
        /// </summary>
        public ObservableCollection<Tuple<Jeuxvideo, Status>> Games { get; set; }

        #endregion

        #region Constructors

        public Historique(Profil profile, ObservableCollection<Tuple<Jeuxvideo, Status>> games)
        {
            Profile = profile;
            Games = games;
        }

        #endregion
    }
}