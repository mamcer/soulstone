namespace Soulstone.Mp3
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Data;

    using Soulstone.Data;
    
    /// <summary>
    /// Allow make searchs and obtain a specific MusicTrack.
    /// </summary>
    public sealed class MusicTrackManager
    {
        #region private fields

        /// <summary>
        /// The unique instance of the MusicTrackManager class.
        /// </summary>
        private static MusicTrackManager instance;

        /// <summary>
        /// The datalayer.
        /// </summary>
        private DataLayerBase dataLayer;
        
        #endregion

        #region constructor

        /// <summary>
        /// Prevents a default instance of the MusicTrackManager class from being created.
        /// </summary>
        private MusicTrackManager() 
        {
        }
        #endregion

        #region public properties

        /// <summary>
        /// Gets the unique instance of the MusicTrackManager class.
        /// </summary>
        public static MusicTrackManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MusicTrackManager();
                }

                return instance;
            }
        }

        #endregion

        #region private properties

        /// <summary>
        /// Gets the DataLayer object.
        /// </summary>
        private DataLayerBase DataLayer
        {
            get
            {
                if (this.dataLayer == null)
                {
                    this.dataLayer = DataLayerFactory.Instance.GetDataLayer(DataLayerType.SqlServer);
                }

                return this.dataLayer;
            }
        }

        #endregion

        #region public methods

        /// <summary>
        /// Calls the DataLayer TestConnection method to test the underlying connection.
        /// </summary>
        /// <returns>True or false.</returns>
        public bool StartupCheck()
        {
            return this.DataLayer.TestConnection();
        }

        /// <summary>
        /// Make a search in the underlying DataLayer.
        /// </summary>
        /// <param name="album">The album to be searched. Can be empty.</param>
        /// <param name="artist">The artist to be searched. Can be empty.</param>
        /// <param name="title">The title to be searched. Can be empty.</param>
        /// <param name="year">The year to be searched. 0 for nothing.</param>
        /// <param name="genre">The genre to be searched. Can be empty.</param>
        /// <returns>A datatable with the result.</returns>
        public DataTable Search(string album, string artist, string title, int year, string genre)
        {
            return this.DataLayer.Search(album, artist, title, year, genre);
        }

        /// <summary>
        /// Returns a specific MusicTrack.
        /// </summary>
        /// <param name="musicTrackId">The music track id.</param>
        /// <returns>A DataRow with the info.</returns>
        public DataRow GetMusicTrack(Guid musicTrackId)
        {
            return this.DataLayer.GetMusicTrack(musicTrackId);
        }

        /// <summary>
        /// Returns the total file and font count.
        /// </summary>
        /// <returns>A DataRow with the info.</returns>
        public DataRow GetTotalFileCount()
        {
            return this.DataLayer.GetTotalFileCount();
        }

        #endregion
    }
}
