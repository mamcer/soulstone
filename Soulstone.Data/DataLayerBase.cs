namespace Soulstone.Data
{
    using System;
    using System.Data;
    
    /// <summary>
    /// Abstract class base class for every DataLayer.
    /// </summary>
    public abstract class DataLayerBase
    {
        #region public abstract methods

        /// <summary>
        /// Test the underlying connection.
        /// </summary>
        /// <returns>true or false.</returns>
        public abstract bool TestConnection();

        /// <summary>
        /// Create a host with the given name.
        /// </summary>
        /// <param name="hostName">The name of the host.</param>
        public abstract void CreateHost(string hostName);

        /// <summary>
        /// Create or update the Music Track info.
        /// </summary>
        /// <param name="hostName">The host name where the Music Track belongs.</param>
        /// <param name="filePath">The path to the song.</param>
        /// <param name="album">The album of the song.</param>
        /// <param name="artist">The artist of the song.</param>
        /// <param name="title">The title of the song.</param>
        /// <param name="year">The year of the song.</param>
        /// <param name="genre">The genre.</param>
        public abstract void CreateOrUpdateMusicTrack(string hostName, string filePath, string album, string artist, string title, int year, string genre);
        
        /// <summary>
        /// Remove obsolete entries from the database.
        /// </summary>
        public abstract void DeleteObsoleteEntries();
        
        /// <summary>
        /// Remove all obsolete entries from the database taking into account the given number of failed updates. 
        /// </summary>
        /// <param name="failedUpdateNumber">Over that number the entries will be removed.</param>
        public abstract void DeleteObsoleteEntries(int failedUpdateNumber);

        /// <summary>
        /// Search for a file in the database.
        /// </summary>
        /// <param name="album">The album to be searched. Can be empty.</param>
        /// <param name="artist">The artist to be searched. Can be empty.</param>
        /// <param name="title">The title to be searched. Can be empty.</param>
        /// <param name="year">The year to be searched. 0 for nothing.</param>
        /// <param name="genre">The genre to be searched. Can be empty.</param>
        /// <returns>A datatable with the result.</returns>
        public abstract DataTable Search(string album, string artist, string title, int year, string genre);
        
        /// <summary>
        /// Get all the info to create a MusicTrack object.
        /// </summary>
        /// <param name="musicTrackId">The id of the MusicTrack.</param>
        /// <returns>A DataRow with the info.</returns>
        public abstract DataRow GetMusicTrack(Guid musicTrackId);

        /// <summary>
        /// Get all hosts stored into the database.
        /// </summary>
        /// <returns>A DataTable with the hosts info.</returns>
        public abstract DataTable GetAllHosts();

        /// <summary>
        /// Check if a particular hosts exists.
        /// </summary>
        /// <param name="hostName">The name of the host to be searched.</param>
        /// <returns>True or false.</returns>
        public abstract bool HostExists(string hostName);

        /// <summary>
        /// Get the total file count and file fonts.
        /// </summary>
        /// <returns>A DataRow with the two values.</returns>
        public abstract DataRow GetTotalFileCount();
     
        #endregion
    }
}